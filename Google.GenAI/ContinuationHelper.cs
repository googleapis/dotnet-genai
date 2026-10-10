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
    /// Checks whether finish_reason permits resumption (solely CONTINUATION).
    /// </summary>
    public static bool IsResumableFinishReason(FinishReason? finishReason)
    {
      return finishReason == FinishReason.Continuation;
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
        mergedNode = MergeJsonNodes(mergedNode, nextNode, fieldName: null, isInsideUsageMetadata: false);
      }

      string mergedJson = mergedNode?.ToJsonString(JsonConfig.InternalSerializerOptions) ?? "{}";
      var finalResponse = GenerateContentResponse.FromJson(mergedJson)
          ?? mergedNode?.Deserialize(JsonConfig.TypeInfo<GenerateContentResponse>())
          ?? throw new InvalidOperationException("Failed to deserialize merged GenerateContentResponse.");

      // SdkHttpResponse is [JsonIgnore], retain from the latest hop
      finalResponse.SdkHttpResponse = responses[responses.Count - 1].SdkHttpResponse;
      return finalResponse;
    }

    private static JsonNode? MergeJsonNodes(
        JsonNode? prev,
        JsonNode? curr,
        string? fieldName,
        bool isInsideUsageMetadata)
    {
      // Terminal hop fields always overwrite with curr (even if null)
      if (fieldName != null && TerminalHopFields.Contains(fieldName))
      {
        return curr?.DeepClone();
      }

      // Null / absent handling: keep non-null side
      if (curr == null) return prev?.DeepClone();
      if (prev == null) return curr?.DeepClone();

      // Nested Objects
      if (prev is JsonObject prevObj && curr is JsonObject currObj)
      {
        bool inUsage = isInsideUsageMetadata ||
            string.Equals(fieldName, "usageMetadata", StringComparison.OrdinalIgnoreCase);

        var mergedObj = new JsonObject();
        var allKeys = new HashSet<string>(
            prevObj.Select(kv => kv.Key).Concat(currObj.Select(kv => kv.Key)));

        foreach (var key in allKeys)
        {
          prevObj.TryGetPropertyValue(key, out var pVal);
          currObj.TryGetPropertyValue(key, out var cVal);
          mergedObj[key] = MergeJsonNodes(pVal, cVal, key, inUsage);
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
            mergedArr.Add(MergeJsonNodes(p, c, "candidate", isInsideUsageMetadata));
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

      // Numbers (sum inside usageMetadata or tokenCount / *Count / *Sum)
      if (prev is JsonValue prevVal && curr is JsonValue currVal &&
          prev.GetValueKind() == JsonValueKind.Number && curr.GetValueKind() == JsonValueKind.Number)
      {
        bool shouldSum = isInsideUsageMetadata ||
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
