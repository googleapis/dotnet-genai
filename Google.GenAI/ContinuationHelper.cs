/*
 * Copyright 2026 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using Google.GenAI.Types;

namespace Google.GenAI
{
  /// <summary>
  /// State of one <c>GenerateContentStreamAsync</c> call with automatic continuation.
  /// </summary>
  /// <remarks>
  /// A stream is made of one or more hops (HTTP requests). Each hop after the first resumes
  /// from a continuation token. The caller drives the loop:
  /// <code>
  /// var state = new StreamContinuation(config);
  /// while (true) {
  ///   GenerateContentConfig? callConfig = state.StartHop();
  ///   ExceptionDispatchInfo? error = null;
  ///   // Stream the request with callConfig; for each chunk: yield return state.Observe(chunk);
  ///   // if streaming throws (other than cancellation): error = ExceptionDispatchInfo.Capture(ex);
  ///   if (!state.EndHop(error)) yield break;
  /// }
  /// </code>
  /// Per-hop state lives in a <see cref="Hop"/> that is replaced wholesale by
  /// <see cref="StartHop"/>, so it can't leak from one hop into the next. Loop state (whether
  /// continuation is enabled, the usage accumulated across finished hops, the token to resume
  /// from, the number of consecutive reconnects without progress, and the latest error since
  /// the stream last made progress) carries across hops. See <see cref="EndHop"/> for which
  /// failures are retried and which error is thrown when the stream gives up.
  ///
  /// Usage metadata: within a hop, each chunk's usage metadata is the server's running total for
  /// that hop, so the latest one is the hop's usage (chunks are not summed). Across hops, the
  /// hops' usage is summed, since each hop is a separate request. Each yielded chunk that has
  /// usage metadata carries the usage of all previous hops plus its own.
  /// </remarks>
  internal sealed class StreamContinuation
  {
    /// <summary>What was observed during one hop (HTTP request) of a continuation stream.</summary>
    internal sealed class Hop
    {
      /// <summary>
      /// The continuation token the hop was requested with (null for the initial request).
      /// </summary>
      public byte[]? StartToken { get; set; }

      /// <summary>Latest continuation token received during the hop.</summary>
      public byte[]? Token { get; set; }

      /// <summary>
      /// The finish reason received during the hop, or null if the stream ended (or failed)
      /// without one.
      /// </summary>
      public FinishReason? FinishReason { get; set; }

      public bool HasPromptFeedback { get; set; }

      /// <summary>Whether the hop already yielded candidate content parts.</summary>
      public bool HasYieldedContent { get; set; }

      /// <summary>
      /// Whether the hop received any chunk (i.e. the server accepted the request and started
      /// streaming).
      /// </summary>
      public bool ReceivedAnyChunk { get; set; }

      /// <summary>
      /// Usage for the whole stream so far: the usage of all previous hops plus this hop's latest
      /// usage metadata. Within a hop, each chunk's usage metadata is the server's running total
      /// for the hop, so it replaces the previous value (it is not summed); a chunk without usage
      /// metadata leaves it unchanged.
      /// </summary>
      public GenerateContentResponseUsageMetadata? Usage { get; set; }
    }

    private readonly GenerateContentConfig? _config;
    // Usage of all finished hops, summed. Each hop is a separate request whose usage the server
    // reports independently, so hop totals are added (unlike chunks within a hop; see Hop.Usage).
    private GenerateContentResponseUsageMetadata? _accumulatedUsageAcrossHops;
    // Token the next hop resumes from (null for the initial request).
    private byte[]? _resumeToken;
    // The most recent error raised by a hop since the stream last made progress. Rethrown if
    // the stream gives up, so that an error is not hidden by a later retry that ends cleanly
    // without progress.
    private System.Runtime.ExceptionServices.ExceptionDispatchInfo? _lastError;

    public StreamContinuation(GenerateContentConfig? config)
    {
      _config = config;
      EnableContinuation =
          ContinuationHelper.ShouldEnableAutomaticContinuation(config, defaultEnabled: true);
    }

    public bool EnableContinuation { get; }

    /// <summary>
    /// Number of consecutive hops that ended without a new continuation token. Settable only
    /// so tests can exercise <see cref="NextResumeToken"/>.
    /// </summary>
    internal int ReconnectsWithoutProgress { get; set; }

    /// <summary>
    /// The current hop. Replaced by <see cref="StartHop"/>; settable only so tests can exercise
    /// <see cref="NextResumeToken"/>.
    /// </summary>
    internal Hop CurrentHop { get; set; } = new Hop();

    /// <summary>Starts a new hop and returns the config to request it with.</summary>
    public GenerateContentConfig? StartHop()
    {
      CurrentHop = new Hop { StartToken = _resumeToken };
      return _resumeToken != null
          ? ContinuationHelper.PrepareContinuationConfig(_config, _resumeToken)
          : _config;
    }

    /// <summary>
    /// Records one streamed chunk and returns the chunk to yield. The returned chunk has its
    /// intermediate FinishReason cleared when the stream will auto-continue, and its
    /// UsageMetadata (if any) set to this hop's latest usage plus the usage of all previous hops.
    /// </summary>
    public GenerateContentResponse Observe(GenerateContentResponse chunk)
    {
      Hop hop = CurrentHop;
      hop.ReceivedAnyChunk = true;
      if (chunk.PromptFeedback != null)
      {
        hop.HasPromptFeedback = true;
      }
      if (chunk.Candidates is { Count: > 0 } candidates)
      {
        var cand = candidates[0];
        if (cand.Content?.Parts is { Count: > 0 })
        {
          hop.HasYieldedContent = true;
        }
        if (cand.FinishReason != null)
        {
          hop.FinishReason = cand.FinishReason;
        }
        if (cand.ContinuationToken is { Length: > 0 })
        {
          hop.Token = cand.ContinuationToken;
        }
        else if (cand.FinishReason != null &&
                 !ContinuationHelper.IsResumableFinishReason(cand.FinishReason))
        {
          hop.Token = null;
        }
        chunk = ContinuationHelper.ClearIntermediateFinishReason(
            chunk, EnableContinuation, hop.Token);
      }
      if (chunk.UsageMetadata != null)
      {
        if (_accumulatedUsageAcrossHops != null)
        {
          var mergedUsage = ContinuationHelper.MergeUsageMetadata(
              _accumulatedUsageAcrossHops, chunk.UsageMetadata);
          chunk = chunk with { UsageMetadata = mergedUsage };
          hop.Usage = mergedUsage;
        }
        else
        {
          hop.Usage = chunk.UsageMetadata;
        }
      }
      return chunk;
    }

    /// <summary>
    /// Ends the current hop. Returns true if another hop should be started.
    /// If the stream fails or ends without a terminal finish reason, the next hop resumes from
    /// the latest checkpoint token. If the hop failed before emitting a checkpoint of its own
    /// and before yielding content, it is retried from the token it started with.
    /// </summary>
    /// <remarks>
    /// Only failures of an accepted stream are retried here (a dropped connection, or a stream
    /// that ends early). A request the server rejected before streaming anything (an
    /// <see cref="ApiException"/> from an HTTP error status, or from an error as the first
    /// event) is rethrown immediately: retrying rejected requests, with backoff, is the job of
    /// <see cref="Types.HttpOptions.RetryOptions"/>.
    ///
    /// When the stream gives up, the latest error thrown since the stream last made progress is
    /// rethrown, even if a later retry ended without an error. Errors are never invented: a
    /// stream that only ever ended cleanly ends normally.
    /// </remarks>
    /// <param name="error">The exception raised while streaming the hop, if any. It is
    /// rethrown (with its original stack trace) if the stream can't be resumed. If the API
    /// returned no error since the stream last made progress, the stream ends normally and the
    /// caller keeps everything already yielded.</param>
    public bool EndHop(System.Runtime.ExceptionServices.ExceptionDispatchInfo? error)
    {
      Hop hop = CurrentHop;
      if (hop.Usage != null)
      {
        _accumulatedUsageAcrossHops = hop.Usage;
      }
      if (error?.SourceException is ApiException && !hop.ReceivedAnyChunk)
      {
        // Rejected request: leave retries to HttpOptions.RetryOptions.
        error.Throw();
      }
      bool madeProgress = hop.HasYieldedContent || IsNewToken(hop);
      if (error != null)
      {
        _lastError = error;
      }
      else if (madeProgress)
      {
        _lastError = null;
      }
      (_resumeToken, ReconnectsWithoutProgress) = NextResumeToken();
      if (ContinuationHelper.CanResumeStream(
              EnableContinuation, _resumeToken, hop.FinishReason, hop.HasPromptFeedback))
      {
        return true;
      }
      error?.Throw();
      bool gaveUp = (hop.FinishReason == null
                     || hop.FinishReason == Types.FinishReason.FinishReasonUnspecified)
          && !hop.HasPromptFeedback;
      if (gaveUp)
      {
        _lastError?.Throw();
      }
      return false;
    }

    /// <summary>
    /// Returns the token to resume the next hop from (or null to stop) and the updated
    /// reconnect count. Long-decode checkpoints are only emitted part way through each hop, so
    /// a connection can drop before the hop has produced a checkpoint of its own. In that case
    /// the hop can be retried from the token it was started with, provided no candidate
    /// content parts have been yielded yet. Internal (rather than private) only for tests.
    /// </summary>
    internal (byte[]? ContinuationToken, int ReconnectsWithoutProgress) NextResumeToken()
    {
      Hop hop = CurrentHop;
      int reconnects = ReconnectsWithoutProgress;
      if ((hop.FinishReason != null &&
           hop.FinishReason != Types.FinishReason.FinishReasonUnspecified)
          || hop.HasPromptFeedback)
      {
        if (hop.FinishReason == Types.FinishReason.Continuation
            && !hop.HasPromptFeedback
            && IsNewToken(hop))
        {
          return (hop.Token, 0);
        }
        // The server ended the hop without a new token or with PromptFeedback;
        // replaying the same token would only repeat the hop.
        return (null, 0);
      }
      if (IsNewToken(hop))
      {
        return (hop.Token, 0);
      }
      if (hop.HasYieldedContent
          || reconnects >= ContinuationHelper.MaxStreamReconnectsWithoutProgress)
      {
        return (null, reconnects);
      }
      return (hop.StartToken, reconnects + 1);
    }

    private static bool IsNewToken(Hop hop)
    {
      return hop.Token is { Length: > 0 } token
          && (hop.StartToken == null || !token.AsSpan().SequenceEqual(hop.StartToken));
    }
  }

  internal static class ContinuationHelper
  {
    private static readonly HashSet<string> TerminalHopFields = new(StringComparer.OrdinalIgnoreCase)
    {
      "continuationToken",
      "finishReason",
      "finishMessage"
    };

    /// <summary>
    /// Evaluates whether automatic continuation is enabled.
    /// Defaults to true unless explicitly disabled via config.
    /// </summary>
    public static bool ShouldEnableAutomaticContinuation(
        GenerateContentConfig? config,
        bool defaultEnabled = true)
    {
      if (config == null)
      {
        return defaultEnabled;
      }

      // If unset, fall back to defaultEnabled (defaults to true).
      if (config.AutomaticContinuation == null)
      {
        return defaultEnabled;
      }

      return config.AutomaticContinuation.Value;
    }

    /// <summary>
    /// Checks whether finish_reason permits resumption.
    /// Per the continuation protocol, when a continuation_token is present the
    /// backend only sets finish_reason to null (intermediate checkpoint chunk)
    /// or CONTINUATION (stream end).
    /// </summary>
    public static bool IsResumableFinishReason(FinishReason? finishReason)
    {
      return finishReason == null || finishReason == FinishReason.Continuation;
    }

    /// <summary>
    /// Maximum number of consecutive streaming reconnects that do not receive a new
    /// checkpoint continuation token before the error is surfaced to the caller.
    /// </summary>
    public const int MaxStreamReconnectsWithoutProgress = 3;

    /// <summary>
    /// Checks whether a streaming hop can resume with the given continuation state.
    /// </summary>
    public static bool CanResumeStream(
        bool enableContinuation,
        byte[]? continuationToken,
        FinishReason? finishReason,
        bool hasPromptFeedback = false)
    {
      return enableContinuation
          && !hasPromptFeedback
          && continuationToken is { Length: > 0 }
          && IsResumableFinishReason(finishReason);
    }

    /// <summary>
    /// Clears FinishReason on intermediate streaming chunks that will automatically resume.
    /// </summary>
    public static GenerateContentResponse ClearIntermediateFinishReason(
        GenerateContentResponse chunk,
        bool enableContinuation,
        byte[]? continuationToken)
    {
      if (chunk.Candidates is not { Count: > 0 } candidates)
      {
        return chunk;
      }
      var firstCandidate = candidates[0];
      if (firstCandidate.FinishReason != null
          && CanResumeStream(enableContinuation, continuationToken, firstCandidate.FinishReason))
      {
        var updatedCandidates = new List<Candidate>(candidates)
        {
          [0] = firstCandidate with { FinishReason = null }
        };
        return chunk with { Candidates = updatedCandidates };
      }
      return chunk;
    }

    /// <summary>
    /// Checks candidate 0 for a valid continuation_token when finish_reason is CONTINUATION.
    /// </summary>
    public static byte[]? ShouldContinueGeneration(GenerateContentResponse? response)
    {
      Candidate? candidate = response?.Candidates?.FirstOrDefault();
      if (candidate?.ContinuationToken is { Length: > 0 } continuationToken &&
          IsResumableFinishReason(candidate.FinishReason))
      {
        return continuationToken;
      }
      return null;
    }

    /// <summary>
    /// Clones the config with continuationToken set, leaving the original config unmutated.
    /// Since GenerateContentConfig is a C# record, we use the record 'with' expression.
    /// </summary>
    public static GenerateContentConfig PrepareContinuationConfig(
        GenerateContentConfig? baseConfig,
        byte[]? continuationToken)
    {
      if (baseConfig == null)
      {
        return new GenerateContentConfig { ContinuationToken = continuationToken };
      }
      return baseConfig with { ContinuationToken = continuationToken };
    }

    /// <summary>
    /// Merges two <see cref="GenerateContentResponseUsageMetadata"/> instances across continuation hops.
    /// Token counts and modality details are summed across hops, while
    /// <see cref="GenerateContentResponseUsageMetadata.InitialPromptTokenCount"/> preserves the initial hop's prompt token count.
    /// </summary>
    public static GenerateContentResponseUsageMetadata? MergeUsageMetadata(
        GenerateContentResponseUsageMetadata? prev,
        GenerateContentResponseUsageMetadata? curr)
    {
      if (prev == null) return curr;
      if (curr == null) return prev;

      JsonNode? prevNode = JsonNode.Parse(
          JsonSerializer.Serialize(prev, JsonConfig.TypeInfo<GenerateContentResponseUsageMetadata>()));
      JsonNode? currNode = JsonNode.Parse(
          JsonSerializer.Serialize(curr, JsonConfig.TypeInfo<GenerateContentResponseUsageMetadata>()));
      JsonNode? mergedNode = MergeJsonNodes(prevNode, currNode, fieldName: "usageMetadata");
      string mergedJson = mergedNode?.ToJsonString(JsonConfig.InternalSerializerOptions) ?? "{}";
      var merged = GenerateContentResponseUsageMetadata.FromJson(mergedJson)
          ?? mergedNode?.Deserialize(JsonConfig.TypeInfo<GenerateContentResponseUsageMetadata>())
          ?? new GenerateContentResponseUsageMetadata();
      merged.InitialPromptTokenCount = prev.InitialPromptTokenCount ?? curr.InitialPromptTokenCount;
      return merged;
    }

    /// <summary>
    /// Merges multiple continuation hop responses into a single combined response.
    /// </summary>
    public static GenerateContentResponse MergeContinuationResponses(
        IReadOnlyList<GenerateContentResponse> responses)
    {
      if (responses == null || responses.Count == 0)
      {
        return new GenerateContentResponse();
      }
      if (responses.Count == 1)
      {
        return responses[0];
      }

      string firstJson = JsonSerializer.Serialize(responses[0], JsonConfig.TypeInfo<GenerateContentResponse>());
      JsonNode? mergedNode = JsonNode.Parse(firstJson);

      for (int i = 1; i < responses.Count; i++)
      {
        string nextJson = JsonSerializer.Serialize(responses[i], JsonConfig.TypeInfo<GenerateContentResponse>());
        JsonNode? nextNode = JsonNode.Parse(nextJson);
        mergedNode = MergeJsonNodes(mergedNode, nextNode, fieldName: null);
      }

      string mergedJson = mergedNode?.ToJsonString(JsonConfig.InternalSerializerOptions) ?? "{}";
      var finalResponse = GenerateContentResponse.FromJson(mergedJson)
          ?? mergedNode?.Deserialize(JsonConfig.TypeInfo<GenerateContentResponse>())
          ?? throw new InvalidOperationException("Failed to deserialize merged GenerateContentResponse.");

      int? firstInitialPrompt = responses
          .Select(r => r.UsageMetadata?.InitialPromptTokenCount)
          .FirstOrDefault(v => v != null);
      if (finalResponse.UsageMetadata != null && firstInitialPrompt != null)
      {
        finalResponse.UsageMetadata.InitialPromptTokenCount = firstInitialPrompt;
      }

      // SdkHttpResponse is [JsonIgnore], retain from the latest hop
      finalResponse.SdkHttpResponse = responses[responses.Count - 1].SdkHttpResponse;
      return finalResponse;
    }

    private static JsonNode? MergeJsonNodes(
        JsonNode? prev,
        JsonNode? curr,
        string? fieldName)
    {
      // Terminal hop fields always overwrite with curr (even if null)
      if (fieldName != null && TerminalHopFields.Contains(fieldName))
      {
        return curr?.DeepClone();
      }

      // Merge preserved candidates against an empty Candidate when curr.Candidates
      // is null/empty so terminal continuation state is cleared before null fallback.
      if (string.Equals(fieldName, "candidates", StringComparison.OrdinalIgnoreCase) &&
          prev is JsonArray prevCandidates &&
          prevCandidates.Count > 0 &&
          (curr is not JsonArray currCandidates || currCandidates.Count == 0))
      {
        var mergedCandidates = new JsonArray();
        foreach (var item in prevCandidates)
        {
          mergedCandidates.Add(MergeJsonNodes(item, new JsonObject(), "candidate"));
        }
        return mergedCandidates;
      }

      // Null / absent handling: keep non-null side
      if (curr == null) return prev?.DeepClone();
      if (prev == null) return curr?.DeepClone();

      // Nested Objects
      if (prev is JsonObject prevObj && curr is JsonObject currObj)
      {
        var mergedObj = new JsonObject();
        var allKeys = new HashSet<string>(
            prevObj.Select(kv => kv.Key).Concat(currObj.Select(kv => kv.Key)));

        foreach (var key in allKeys)
        {
          prevObj.TryGetPropertyValue(key, out var pVal);
          currObj.TryGetPropertyValue(key, out var cVal);
          mergedObj[key] = MergeJsonNodes(pVal, cVal, key);
        }
        return mergedObj;
      }

      // Lists / Arrays
      if (prev is JsonArray prevArr && curr is JsonArray currArr)
      {
        // candidates: merge element-wise (Candidate 0 with Candidate 0)
        if (string.Equals(fieldName, "candidates", StringComparison.OrdinalIgnoreCase))
        {
          var mergedArr = new JsonArray();
          int maxCount = Math.Max(prevArr.Count, currArr.Count);
          for (int i = 0; i < maxCount; i++)
          {
            var p = i < prevArr.Count ? prevArr[i] : null;
            var c = i < currArr.Count ? currArr[i] : null;
            if (p is JsonObject prevCand && c is JsonObject currCand)
            {
              c = ShiftGroundingSupports(prevCand, currCand);
            }
            mergedArr.Add(MergeJsonNodes(p, c, "candidate"));
          }
          return mergedArr;
        }

        // ModalityTokenCount lists (*TokensDetails): group by modality and sum tokenCount
        if (fieldName != null &&
            (fieldName.EndsWith("TokensDetails", StringComparison.OrdinalIgnoreCase) ||
             fieldName.EndsWith("tokens_details", StringComparison.OrdinalIgnoreCase)))
        {
          return MergeModalityTokenCounts(prevArr, currArr);
        }

        // safetyRatings: group by category and keep latest rating
        if (string.Equals(fieldName, "safetyRatings", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(fieldName, "safety_ratings", StringComparison.OrdinalIgnoreCase))
        {
          return MergeSafetyRatings(prevArr, currArr);
        }

        // Default: Concatenate prev + curr preserving all items in order (preserves Part(text=""))
        var concatenated = new JsonArray();
        foreach (var item in prevArr) concatenated.Add(item?.DeepClone());
        foreach (var item in currArr) concatenated.Add(item?.DeepClone());
        return concatenated;
      }

      // Numbers (sum tokenCount / *Count / *Sum)
      if (prev is JsonValue prevVal && curr is JsonValue currVal &&
          prev.GetValueKind() == JsonValueKind.Number && curr.GetValueKind() == JsonValueKind.Number)
      {
        bool shouldSum =
            string.Equals(fieldName, "tokenCount", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(fieldName, "token_count", StringComparison.OrdinalIgnoreCase) ||
            (fieldName != null && (
                fieldName.EndsWith("Count", StringComparison.OrdinalIgnoreCase) ||
                fieldName.EndsWith("_count", StringComparison.OrdinalIgnoreCase) ||
                fieldName.EndsWith("Sum", StringComparison.OrdinalIgnoreCase) ||
                fieldName.EndsWith("_sum", StringComparison.OrdinalIgnoreCase)));

        if (shouldSum)
        {
          if (prevVal.TryGetValue<long>(out long prevL) && currVal.TryGetValue<long>(out long currL))
          {
            return JsonValue.Create(prevL + currL);
          }
          if (prevVal.TryGetValue<double>(out double prevD) && currVal.TryGetValue<double>(out double currD))
          {
            return JsonValue.Create(prevD + currD);
          }
        }
        return curr.DeepClone();
      }

      // Other Scalars (strings, booleans, enums) - latest hop wins
      return curr.DeepClone();
    }

    private static JsonObject ShiftGroundingSupports(JsonObject prevCandidate, JsonObject currCandidate)
    {
      if (!currCandidate.TryGetPropertyValue("groundingMetadata", out var currGmNode) ||
          currGmNode is not JsonObject currGmObj ||
          !currGmObj.TryGetPropertyValue("groundingSupports", out var currSupportsNode) ||
          currSupportsNode is not JsonArray currSupportsArr ||
          currSupportsArr.Count == 0)
      {
        return currCandidate;
      }

      int partOffset = 0;
      if (prevCandidate.TryGetPropertyValue("content", out var prevContentNode) &&
          prevContentNode is JsonObject prevContentObj &&
          prevContentObj.TryGetPropertyValue("parts", out var prevPartsNode) &&
          prevPartsNode is JsonArray prevPartsArr)
      {
        partOffset = prevPartsArr.Count;
      }

      int chunkOffset = 0;
      if (prevCandidate.TryGetPropertyValue("groundingMetadata", out var prevGmNode) &&
          prevGmNode is JsonObject prevGmObj &&
          prevGmObj.TryGetPropertyValue("groundingChunks", out var prevChunksNode) &&
          prevChunksNode is JsonArray prevChunksArr)
      {
        chunkOffset = prevChunksArr.Count;
      }

      if (partOffset == 0 && chunkOffset == 0)
      {
        return currCandidate;
      }

      var shiftedCandidate = (JsonObject)currCandidate.DeepClone();
      var shiftedGm = (JsonObject)shiftedCandidate["groundingMetadata"]!;
      var shiftedSupports = (JsonArray)shiftedGm["groundingSupports"]!;

      foreach (var supportNode in shiftedSupports)
      {
        if (supportNode is not JsonObject supportObj) continue;

        if (chunkOffset > 0 &&
            supportObj.TryGetPropertyValue("groundingChunkIndices", out var indicesNode) &&
            indicesNode is JsonArray indicesArr)
        {
          for (int i = 0; i < indicesArr.Count; i++)
          {
            if (indicesArr[i] is JsonValue idxVal && idxVal.TryGetValue<int>(out int idx))
            {
              indicesArr[i] = JsonValue.Create(idx + chunkOffset);
            }
          }
        }

        if (partOffset > 0 &&
            supportObj.TryGetPropertyValue("segment", out var segmentNode) &&
            segmentNode is JsonObject segmentObj)
        {
          int prevPartIndex = 0;
          if (segmentObj.TryGetPropertyValue("partIndex", out var partIdxNode) &&
              partIdxNode is JsonValue partIdxVal &&
              partIdxVal.TryGetValue<int>(out int parsedPartIdx))
          {
            prevPartIndex = parsedPartIdx;
          }
          segmentObj["partIndex"] = JsonValue.Create(prevPartIndex + partOffset);
        }
      }

      return shiftedCandidate;
    }

    private static JsonArray MergeModalityTokenCounts(JsonArray prevArr, JsonArray currArr)
    {
      var countsByModality = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
      var order = new List<string>();

      void Accumulate(JsonArray arr)
      {
        foreach (var node in arr)
        {
          if (node is JsonObject obj)
          {
            string? modality = null;
            if (obj.TryGetPropertyValue("modality", out var mNode) && mNode != null)
            {
              modality = mNode.ToString();
            }
            if (modality == null) continue;

            long count = 0;
            if ((obj.TryGetPropertyValue("tokenCount", out var cNode) ||
                 obj.TryGetPropertyValue("token_count", out cNode)) &&
                cNode is JsonValue cVal &&
                cVal.TryGetValue<long>(out long parsedCount))
            {
              count = parsedCount;
            }

            if (!countsByModality.ContainsKey(modality))
            {
              countsByModality[modality] = 0;
              order.Add(modality);
            }
            countsByModality[modality] += count;
          }
        }
      }

      Accumulate(prevArr);
      Accumulate(currArr);

      var result = new JsonArray();
      foreach (var mod in order)
      {
        result.Add(new JsonObject
        {
          ["modality"] = mod,
          ["tokenCount"] = countsByModality[mod]
        });
      }
      return result;
    }

    private static JsonArray MergeSafetyRatings(JsonArray prevArr, JsonArray currArr)
    {
      var byCategory = new Dictionary<string, JsonNode?>(StringComparer.OrdinalIgnoreCase);
      var order = new List<string>();

      void Accumulate(JsonArray arr)
      {
        foreach (var node in arr)
        {
          if (node is JsonObject obj &&
              obj.TryGetPropertyValue("category", out var cNode) &&
              cNode != null)
          {
            string cat = cNode.ToString();
            if (!byCategory.ContainsKey(cat))
            {
              order.Add(cat);
            }
            byCategory[cat] = node.DeepClone();
          }
        }
      }

      Accumulate(prevArr);
      Accumulate(currArr);

      var result = new JsonArray();
      foreach (var cat in order)
      {
        result.Add(byCategory[cat]);
      }
      return result;
    }
  }
}
