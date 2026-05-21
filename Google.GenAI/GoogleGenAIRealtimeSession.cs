/*
 * Copyright 2025 Google LLC
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

using System.Collections;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text.Json;

using Google.GenAI;
using Google.GenAI.Types;

namespace Microsoft.Extensions.AI;

/// <summary>
/// Provides an <see cref="IRealtimeClientSession"/> implementation for Google GenAI's Live API,
/// wrapping an <see cref="AsyncSession"/> WebSocket connection.
/// </summary>
#if NET8_0_OR_GREATER
[System.Diagnostics.CodeAnalysis.Experimental("MEAI001")]
#endif
public sealed class GoogleGenAIRealtimeSession : IRealtimeClientSession
{
  private readonly AsyncSession _asyncSession;
  private readonly ChatClientMetadata _metadata;
  private int _disposed;

  // Buffer for audio chunks between Append and Commit.
  // Protected by _audioBufferLock. Capped at MaxAudioBufferBytes to prevent unbounded growth.
  private readonly List<byte[]> _audioBuffer = new();
  private readonly object _audioBufferLock = new();
  private int _audioBufferSize;

  /// <summary>Maximum buffered audio size (10 MB). Exceeding this throws <see cref="InvalidOperationException"/>.</summary>
  private const int MaxAudioBufferBytes = 10 * 1024 * 1024;

  // Track whether a response is in progress to emit ResponseCreated only once per response.
  // Accessed only from GetStreamingResponseAsync's single enumeration; callers must not
  // enumerate concurrently.
  private bool _responseInProgress;

  // Guards against multiple concurrent GetStreamingResponseAsync enumerations. A single
  // WebSocket can't safely serve two concurrent readers.
  private int _activeStreamingEnumeration;

  /// <summary>Maximum nesting depth for tool payloads to prevent stack overflow from malicious/malformed data.</summary>
  private const int MaxToolPayloadDepth = 64;

  // Serializes all WebSocket send operations. Required because:
  //   1. WebSocket.SendAsync is NOT thread-safe for concurrent calls.
  //   2. FunctionInvokingRealtimeSession middleware can call SendAsync (to return
  //      function results) concurrently with the caller's own SendAsync (e.g., audio).
  //   3. HandleAudioCommitAsync sends a multi-message sequence (ActivityStart →
  //      audio frames → ActivityEnd) that must be atomic.
  private readonly SemaphoreSlim _sendLock = new(1, 1);

  // Track whether a tool response was just sent. After SendToolResponseAsync, the server
  // automatically continues generating — sending TurnComplete would be unexpected.
  private bool _lastSendWasToolResponse;

  // Track whether the last content sent was media (image/video/audio via CreateConversationItem)
  // that does not auto-trigger a model response. Unlike text, media input requires an explicit
  // ActivityEnd signal in CreateResponse to prompt the model to respond.
  private bool _pendingMediaNeedsTrigger;

  // Maps function call IDs to function names. Populated when ToolCall messages arrive,
  // consumed when sending FunctionResponse back to the server.
  private readonly ConcurrentDictionary<string, string> _callIdToFunctionName = new();

  // Accumulates function results across multiple CreateConversationItem sends so they can
  // be batched into a single SendToolResponseAsync call. The MEAI middleware sends one
  // CreateConversationItem per function result followed by a single CreateResponse.
  // Gemini expects all function results in one SendToolResponseAsync call, so we buffer
  // them here and flush on CreateResponse.
  private readonly List<FunctionResponse> _pendingToolResponses = new();

  // When true, automatic VAD is enabled and the server handles speech boundary detection.
  // ActivityStart/ActivityEnd framing is skipped during audio commit.
  private readonly bool _vadEnabled;

  // The MIME type for audio frames sent to the server, derived from InputAudioFormat.
  private readonly string _inputAudioMimeType;

  /// <inheritdoc />
  public RealtimeSessionOptions? Options { get; private set; }

  /// <summary>Initializes a new instance wrapping a connected <see cref="AsyncSession"/>.</summary>
  /// <param name="asyncSession">The connected <see cref="AsyncSession"/> for WebSocket communication.</param>
  /// <param name="model">The model name for metadata.</param>
  /// <param name="initialOptions">Optional initial session options.</param>
  public GoogleGenAIRealtimeSession(
    AsyncSession asyncSession,
    string model,
    RealtimeSessionOptions? initialOptions)
  {
    _asyncSession = asyncSession ?? throw new ArgumentNullException(nameof(asyncSession));
    _metadata = new ChatClientMetadata("google-genai", defaultModelId: model);
    Options = initialOptions;
    _vadEnabled = initialOptions?.VoiceActivityDetection is { Enabled: true };
    _inputAudioMimeType = initialOptions?.InputAudioFormat?.MediaType ?? "audio/pcm";
  }

  /// <inheritdoc />
  public async Task SendAsync(
    RealtimeClientMessage message,
    CancellationToken cancellationToken = default)
  {
    if (message is null)
    {
      throw new ArgumentNullException(nameof(message));
    }

    if (Volatile.Read(ref _disposed) != 0)
    {
      throw new ObjectDisposedException(nameof(GoogleGenAIRealtimeSession));
    }

    cancellationToken.ThrowIfCancellationRequested();

    // AudioAppend only buffers data in memory — no WebSocket I/O, no lock needed.
    if (message is InputAudioBufferAppendRealtimeClientMessage audioAppend)
    {
      HandleAudioAppend(audioAppend);
      return;
    }

    // All other message types perform WebSocket I/O and must be serialized.
    // WaitAsync may throw ObjectDisposedException if DisposeAsync races between the
    // _disposed check above and this call — treat it the same as a post-dispose send.
    try
    {
      await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
    }
    catch (ObjectDisposedException)
    {
      throw new ObjectDisposedException(nameof(GoogleGenAIRealtimeSession));
    }

    try
    {
      // Recheck after acquiring lock to avoid race with DisposeAsync
      if (Volatile.Read(ref _disposed) != 0)
      {
        throw new ObjectDisposedException(nameof(GoogleGenAIRealtimeSession));
      }

      switch (message)
      {
        case InputAudioBufferCommitRealtimeClientMessage:
          await HandleAudioCommitAsync(cancellationToken).ConfigureAwait(false);
          break;

        case CreateConversationItemRealtimeClientMessage itemCreate:
          await HandleConversationItemCreateAsync(itemCreate, cancellationToken).ConfigureAwait(false);
          break;

        case SessionUpdateRealtimeClientMessage:
          // Gemini's Live API does not support mid-session reconfiguration.
          break;

        case CreateResponseRealtimeClientMessage:
          if (_pendingToolResponses.Count > 0)
          {
            // Flush all buffered function results in a single SendToolResponseAsync call.
            // The MEAI middleware sends one CreateConversationItem per function result,
            // but Gemini expects all results in one call.
            await _asyncSession.SendToolResponseAsync(
              new LiveSendToolResponseParameters
              {
                FunctionResponses = new List<FunctionResponse>(_pendingToolResponses)
              },
              cancellationToken).ConfigureAwait(false);
            _pendingToolResponses.Clear();
            _lastSendWasToolResponse = true;
          }

          if (_lastSendWasToolResponse)
          {
            // After a tool response, Gemini automatically continues generating.
            // Do not send ActivityEnd — it would be unexpected.
            _lastSendWasToolResponse = false;
          }
          else if (_pendingMediaNeedsTrigger)
          {
            // Media inputs (image, video) via SendRealtimeInputAsync are added to
            // the model's context but don't auto-trigger a response. Gemini's Live API
            // has no equivalent to OpenAI's CreateResponse command — the only way to
            // trigger a response is via text input. Send a minimal whitespace text to
            // prompt the model to respond about the media in context without biasing
            // the response content.
            _pendingMediaNeedsTrigger = false;
            await _asyncSession.SendRealtimeInputAsync(
              new LiveSendRealtimeInputParameters
              {
                Text = " ",
              },
              cancellationToken).ConfigureAwait(false);
          }
          // For text input: auto-triggers, no signal needed.
          // For audio commit: ActivityEnd/AudioStreamEnd already sent in HandleAudioCommitAsync.
          break;

        default:
          break;
      }
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      // The caller explicitly cancelled via their token — propagate so they
      // can observe the cancellation they requested.
      throw;
    }
    catch (ObjectDisposedException)
    {
      throw new ObjectDisposedException(nameof(GoogleGenAIRealtimeSession));
    }
    catch (WebSocketException) when (Volatile.Read(ref _disposed) != 0)
    {
      // WebSocketException during/after disposal is expected — swallow.
    }
    finally
    {
      try
      {
        _sendLock.Release();
      }
      catch (ObjectDisposedException)
      {
        // DisposeAsync was called concurrently and disposed the semaphore.
      }
    }
  }

  /// <inheritdoc />
  public async IAsyncEnumerable<RealtimeServerMessage> GetStreamingResponseAsync(
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
  {
    if (Volatile.Read(ref _disposed) != 0)
    {
      throw new ObjectDisposedException(nameof(GoogleGenAIRealtimeSession));
    }

    if (Interlocked.CompareExchange(ref _activeStreamingEnumeration, 1, 0) != 0)
    {
      throw new InvalidOperationException(
        "Only one active streaming enumeration is allowed at a time. " +
        "Await or cancel the existing enumeration before starting a new one.");
    }

    try
    {
    while (!cancellationToken.IsCancellationRequested)
    {
      LiveServerMessage? serverMessage;
      try
      {
        serverMessage = await _asyncSession.ReceiveAsync(cancellationToken).ConfigureAwait(false);
      }
      catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
      {
        // The caller explicitly cancelled via their token — propagate so they
        // can observe the cancellation they requested.
        throw;
      }
      catch (Exception ex) when (ex is OperationCanceledException or ObjectDisposedException or WebSocketException)
      {
        // These exceptions are expected during session teardown and are swallowed:
        //   - OperationCanceledException: internal cancellation from disposal (not the caller's token).
        //   - ObjectDisposedException: DisposeAsync was called on another thread while an
        //     operation was in-flight on the underlying WebSocket.
        //   - WebSocketException: the connection was closed (server disconnect or local close).
        yield break;
      }

      if (serverMessage is null)
      {
        yield break;
      }

      // Map Google Live server messages to MEAI server message types
      foreach (var mapped in MapServerMessage(serverMessage))
      {
        yield return mapped;
      }
    }
    }
    finally
    {
      Volatile.Write(ref _activeStreamingEnumeration, 0);
    }
  }

  /// <inheritdoc />
  public object? GetService(System.Type serviceType, object? serviceKey = null)
  {
    if (serviceType is null)
    {
      throw new ArgumentNullException(nameof(serviceType));
    }

    if (serviceKey is not null)
    {
      return null;
    }

    if (serviceType == typeof(ChatClientMetadata))
    {
      return _metadata;
    }

    if (serviceType.IsInstanceOfType(this))
    {
      return this;
    }

    if (serviceType.IsInstanceOfType(_asyncSession))
    {
      return _asyncSession;
    }

    return null;
  }

  /// <inheritdoc />
  public async ValueTask DisposeAsync()
  {
    if (Interlocked.Exchange(ref _disposed, 1) != 0)
    {
      return;
    }

    _responseInProgress = false;

    Exception? firstException = null;
    try
    {
      await _asyncSession.DisposeAsync().ConfigureAwait(false);
    }
    catch (Exception ex)
    {
      firstException = ex;
    }

    try
    {
      _sendLock.Dispose();
    }
    catch (Exception ex) when (firstException is null)
    {
      firstException = ex;
    }

    if (firstException is not null)
    {
      ExceptionDispatchInfo.Capture(firstException).Throw();
    }
  }

  #region Send Helpers (MEAI → Google GenAI)

  private void HandleAudioAppend(
    InputAudioBufferAppendRealtimeClientMessage audioAppend)
  {
    if (audioAppend.Content is null || !audioAppend.Content.HasTopLevelMediaType("audio"))
    {
      return;
    }

    byte[] audioBytes = ExtractDataBytes(audioAppend.Content);

    // Buffer audio data; it will be sent on commit with proper activity framing.
    lock (_audioBufferLock)
    {
      if (_audioBufferSize + audioBytes.Length > MaxAudioBufferBytes)
      {
        throw new InvalidOperationException(
          $"Audio buffer would exceed {MaxAudioBufferBytes} bytes. " +
          "Call AudioBufferCommit before appending more audio.");
      }

      _audioBuffer.Add(audioBytes);
      _audioBufferSize += audioBytes.Length;
    }
  }

  private async Task HandleAudioCommitAsync(CancellationToken cancellationToken)
  {
    List<byte[]> bufferedChunks;
    lock (_audioBufferLock)
    {
      if (_audioBuffer.Count == 0)
      {
        return;
      }

      // Snapshot and clear the buffer. Avoids consolidating all chunks into a
      // single array only to re-split — instead we send each buffered chunk directly.
      bufferedChunks = new List<byte[]>(_audioBuffer);
      _audioBuffer.Clear();
      _audioBufferSize = 0;
    }

    _lastSendWasToolResponse = false;
    _pendingMediaNeedsTrigger = false;

    // When VAD is disabled, explicit ActivityStart/ActivityEnd framing is required
    // to mark speech boundaries and trigger the model to respond.
    // When VAD is enabled, the server auto-detects speech boundaries —
    // sending explicit framing conflicts with automatic detection.
    if (!_vadEnabled)
    {
      await _asyncSession.SendRealtimeInputAsync(
        new LiveSendRealtimeInputParameters
        {
          ActivityStart = new ActivityStart()
        },
        cancellationToken).ConfigureAwait(false);
    }

    // Send buffered chunks directly, splitting only those that exceed the frame size limit.
    const int maxFrameBytes = 32_000;
    foreach (var buffered in bufferedChunks)
    {
      if (buffered.Length <= maxFrameBytes)
      {
        // Common case: chunk fits in a single frame — send without copying
        await SendAudioFrameAsync(buffered, cancellationToken).ConfigureAwait(false);
      }
      else
      {
        // Large chunk: split into frames
        for (int i = 0; i < buffered.Length; i += maxFrameBytes)
        {
          int len = Math.Min(maxFrameBytes, buffered.Length - i);
          byte[] frame = new byte[len];
          Buffer.BlockCopy(buffered, i, frame, 0, len);
          await SendAudioFrameAsync(frame, cancellationToken).ConfigureAwait(false);
        }
      }
    }

    // When VAD is disabled, signal end of user activity to trigger the model's response.
    // When VAD is enabled, send AudioStreamEnd to indicate the mic was turned off and the
    // server should process the buffered audio. AudioStreamEnd is specifically designed for
    // the push-to-talk pattern with automatic activity detection.
    if (!_vadEnabled)
    {
      await _asyncSession.SendRealtimeInputAsync(
        new LiveSendRealtimeInputParameters
        {
          ActivityEnd = new ActivityEnd()
        },
        cancellationToken).ConfigureAwait(false);
    }
    else
    {
      await _asyncSession.SendRealtimeInputAsync(
        new LiveSendRealtimeInputParameters
        {
          AudioStreamEnd = true
        },
        cancellationToken).ConfigureAwait(false);
    }
  }

  private Task SendAudioFrameAsync(byte[] data, CancellationToken cancellationToken)
  {
    return _asyncSession.SendRealtimeInputAsync(
      new LiveSendRealtimeInputParameters
      {
        Audio = new Blob
        {
          Data = data,
          MimeType = _inputAudioMimeType,
        }
      },
      cancellationToken);
  }

  private async Task HandleConversationItemCreateAsync(
    CreateConversationItemRealtimeClientMessage itemCreate,
    CancellationToken cancellationToken)
  {
    if (itemCreate.Item?.Contents is null or { Count: 0 })
    {
      return;
    }

    // Collect all function results (tool responses use a separate API call).
    var functionResults = new List<FunctionResponse>();
    foreach (var content in itemCreate.Item.Contents)
    {
      if (content is FunctionResultContent functionResult)
      {
        _callIdToFunctionName.TryRemove(functionResult.CallId, out var functionName);
        functionResults.Add(new FunctionResponse
        {
          Id = functionResult.CallId,
          Name = functionName ?? string.Empty,
          Response = new Dictionary<string, object>
          {
            ["result"] = NormalizeToolPayload(functionResult.Result) ?? string.Empty
          }
        });
      }
    }

    if (functionResults.Count > 0)
    {
      // Buffer function results — they will be flushed as a single batched
      // SendToolResponseAsync call when CreateResponse arrives.
      _pendingToolResponses.AddRange(functionResults);
      _lastSendWasToolResponse = true;
      return;
    }

    // Send text and media via SendRealtimeInputAsync without activity framing.
    // Text auto-triggers a model response. Images/audio are treated as streaming
    // context by Gemini's Live API — they do NOT auto-trigger a response.
    // When only media is sent (no accompanying text), we append a brief text prompt
    // so the model knows to respond about the media content.
    bool hasText = false;
    bool hasMedia = false;
    foreach (var content in itemCreate.Item.Contents)
    {
      if (content is TextContent textContent && !string.IsNullOrEmpty(textContent.Text))
      {
        hasText = true;
        _lastSendWasToolResponse = false;
        await _asyncSession.SendRealtimeInputAsync(
          new LiveSendRealtimeInputParameters
          {
            Text = textContent.Text,
          },
          cancellationToken).ConfigureAwait(false);
      }
      else if (content is DataContent dataContent)
      {
        if (dataContent.HasTopLevelMediaType("image"))
        {
          hasMedia = true;
          _lastSendWasToolResponse = false;
          await _asyncSession.SendRealtimeInputAsync(
            new LiveSendRealtimeInputParameters
            {
              Video = new Blob
              {
                Data = ExtractDataBytes(dataContent),
                MimeType = dataContent.MediaType ?? "image/jpeg",
              }
            },
            cancellationToken).ConfigureAwait(false);
        }
        else if (dataContent.HasTopLevelMediaType("audio"))
        {
          hasMedia = true;
          _lastSendWasToolResponse = false;
          await _asyncSession.SendRealtimeInputAsync(
            new LiveSendRealtimeInputParameters
            {
              Audio = new Blob
              {
                Data = ExtractDataBytes(dataContent),
                MimeType = dataContent.MediaType ?? _inputAudioMimeType,
              }
            },
            cancellationToken).ConfigureAwait(false);
        }
      }
    }

    if (hasMedia && !hasText)
    {
      // Gemini treats media as streaming context (like a video frame) and won't
      // respond until it receives a text/voice prompt. Send a brief text to
      // trigger a response about the media content.
      _pendingMediaNeedsTrigger = true;
    }
  }

  internal static byte[] ExtractDataBytes(DataContent content)
  {
    string? dataUri = content.Uri?.ToString();

    if (dataUri is not null)
    {
      int commaIndex = dataUri.LastIndexOf(',');
      if (commaIndex >= 0 && commaIndex < dataUri.Length - 1)
      {
        string base64 = dataUri.Substring(commaIndex + 1);
        try
        {
          return Convert.FromBase64String(base64);
        }
        catch (FormatException)
        {
          // Fall through to content.Data.ToArray() below
        }
      }
    }

    return content.Data.ToArray();
  }

  #endregion

  #region Tool Payload Normalization

  internal static Dictionary<string, object?> NormalizeToolArguments(IReadOnlyDictionary<string, object?> arguments, int depth = 0)
  {
    ValidateToolPayloadDepth(depth);

    var normalized = new Dictionary<string, object?>(arguments.Count);
    foreach (var pair in arguments)
    {
      normalized[pair.Key] = NormalizeToolPayload(pair.Value, depth + 1);
    }
    return normalized;
  }

  internal static object? NormalizeToolPayload(object? value, int depth = 0)
  {
    ValidateToolPayloadDepth(depth);

    switch (value)
    {
      case null:
        return null;

      case JsonElement element:
        return ConvertJsonElementToToolPayload(element, depth + 1);

      case JsonDocument document:
        return ConvertJsonElementToToolPayload(document.RootElement, depth + 1);

      case TextContent textContent:
        return textContent.Text ?? "";

      case DataContent dataContent:
        return new Dictionary<string, object?>
        {
          ["data"] = Convert.ToBase64String(ExtractDataBytes(dataContent)),
          ["mimeType"] = dataContent.MediaType,
          ["name"] = dataContent.Name,
        };

      case UriContent uriContent:
        return new Dictionary<string, object?>
        {
          ["uri"] = uriContent.Uri.AbsoluteUri,
          ["mimeType"] = uriContent.MediaType,
        };

      case IEnumerable<KeyValuePair<string, object?>> pairs:
        return NormalizeToolArguments(pairs.ToDictionary(pair => pair.Key, pair => pair.Value), depth + 1);

      case IDictionary dictionary:
        var mapped = new Dictionary<string, object?>();
        foreach (DictionaryEntry entry in dictionary)
        {
          if (entry.Key is string key)
          {
            mapped[key] = NormalizeToolPayload(entry.Value, depth + 1);
          }
        }
        return mapped;

      case IEnumerable<AIContent> aiContents:
        return aiContents.Select(content => NormalizeToolPayload(content, depth + 1)).ToList();

      case string or bool or byte or sbyte or short or ushort or int or uint or long or ulong or
        float or double or decimal:
        return value;

      case byte[] bytes:
        return Convert.ToBase64String(bytes);

      case ReadOnlyMemory<byte> readOnlyMemory:
        return Convert.ToBase64String(readOnlyMemory.ToArray());

      case Memory<byte> memory:
        return Convert.ToBase64String(memory.ToArray());

      case Enum enumValue:
        return enumValue.ToString();

      case IEnumerable enumerable when value is not string:
        var list = new List<object?>();
        foreach (object? item in enumerable)
        {
          list.Add(NormalizeToolPayload(item, depth + 1));
        }
        return list;

      default:
        return value.ToString();
    }
  }

  private static object? ConvertJsonElementToToolPayload(JsonElement element, int depth)
  {
    ValidateToolPayloadDepth(depth);

    switch (element.ValueKind)
    {
      case JsonValueKind.Object:
        var dictionary = new Dictionary<string, object?>();
        foreach (var property in element.EnumerateObject())
        {
          dictionary[property.Name] = ConvertJsonElementToToolPayload(property.Value, depth + 1);
        }
        return dictionary;

      case JsonValueKind.Array:
        var arrayList = new List<object?>();
        foreach (var item in element.EnumerateArray())
        {
          arrayList.Add(ConvertJsonElementToToolPayload(item, depth + 1));
        }
        return arrayList;

      case JsonValueKind.String:
        return element.GetString();

      case JsonValueKind.Number:
        return element.TryGetInt64(out long intValue) ? intValue : element.GetDouble();

      case JsonValueKind.True:
        return true;

      case JsonValueKind.False:
        return false;

      case JsonValueKind.Null:
      case JsonValueKind.Undefined:
      default:
        return null;
    }
  }

  private static void ValidateToolPayloadDepth(int depth)
  {
    if (depth > MaxToolPayloadDepth)
    {
      throw new InvalidOperationException(
        $"Realtime tool payloads exceed the maximum supported nesting depth of {MaxToolPayloadDepth}.");
    }
  }

  #endregion

  #region Receive Helpers (Google GenAI → MEAI)

  private IEnumerable<RealtimeServerMessage> MapServerMessage(LiveServerMessage serverMessage)
  {
    // SetupComplete — skip (internal protocol message, not relevant to MEAI consumers)
    if (serverMessage.SetupComplete is not null)
    {
      yield break;
    }

    // Server content (model responses — audio, text, transcription)
    if (serverMessage.ServerContent is { } serverContent)
    {
      foreach (var msg in MapServerContent(serverContent, serverMessage))
      {
        yield return msg;
      }
    }

    // Tool calls — emit ResponseCreated (if not already), then ResponseOutputItemAdded + ResponseOutputItemDone for each
    if (serverMessage.ToolCall is { FunctionCalls: { Count: > 0 } functionCalls })
    {
      if (!_responseInProgress)
      {
        _responseInProgress = true;
        yield return new ResponseCreatedRealtimeServerMessage(RealtimeServerMessageType.ResponseCreated)
        {
          RawRepresentation = serverMessage,
        };
      }

      foreach (var fc in functionCalls)
      {
        // Ensure every function call has a usable ID for the round-trip mapping.
        var callId = fc.Id ?? Guid.NewGuid().ToString();
        var functionName = fc.Name ?? string.Empty;

        _callIdToFunctionName[callId] = functionName;

        var contents = new List<AIContent>
        {
          fc.Args is not null
            ? FunctionCallContent.CreateFromParsedArguments(
                fc.Args, callId, functionName,
                static args => args is IReadOnlyDictionary<string, object?> dictionary
                  ? NormalizeToolArguments(dictionary) : null)
            : new FunctionCallContent(callId, functionName)
        };

        var item = new RealtimeConversationItem(contents, id: callId, role: ChatRole.Assistant);

        // Emit ResponseOutputItemAdded (signals start of output item)
        yield return new ResponseOutputItemRealtimeServerMessage(RealtimeServerMessageType.ResponseOutputItemAdded)
        {
          Item = item,
          RawRepresentation = serverMessage,
        };

        // Emit ResponseOutputItemDone (required by FunctionInvokingRealtimeSession middleware)
        yield return new ResponseOutputItemRealtimeServerMessage(RealtimeServerMessageType.ResponseOutputItemDone)
        {
          Item = item,
          RawRepresentation = serverMessage,
        };
      }
    }

    // Tool call cancellation
    if (serverMessage.ToolCallCancellation is { Ids: { Count: > 0 } })
    {
      yield return new RealtimeServerMessage
      {
        Type = RealtimeServerMessageType.RawContentOnly,
        RawRepresentation = serverMessage,
      };
    }

    // Usage metadata — emit as ResponseDone only if one wasn't already emitted
    // by TurnComplete/GenerationComplete above (which resets _responseInProgress).
    if (serverMessage.UsageMetadata is { } usage && _responseInProgress)
    {
      _responseInProgress = false;
      yield return new ResponseCreatedRealtimeServerMessage(RealtimeServerMessageType.ResponseDone)
      {
        Usage = new UsageDetails
        {
          InputTokenCount = usage.PromptTokenCount ?? 0,
          OutputTokenCount = usage.ResponseTokenCount ?? 0,
          TotalTokenCount = usage.TotalTokenCount ?? 0,
        },
        RawRepresentation = serverMessage,
      };
    }

    // GoAway (server disconnect)
    if (serverMessage.GoAway is not null)
    {
      yield return new ErrorRealtimeServerMessage
      {
        Error = new ErrorContent("Server is disconnecting (GoAway)"),
        RawRepresentation = serverMessage,
      };
    }
  }

  private IEnumerable<RealtimeServerMessage> MapServerContent(
    LiveServerContent serverContent,
    LiveServerMessage rawMessage)
  {
    if (serverContent.ModelTurn?.Parts is { Count: > 0 } parts)
    {
      // Emit ResponseCreated once when a new response cycle begins
      if (!_responseInProgress)
      {
        _responseInProgress = true;
        yield return new ResponseCreatedRealtimeServerMessage(RealtimeServerMessageType.ResponseCreated)
        {
          RawRepresentation = rawMessage,
        };
      }

      foreach (var part in parts)
      {
        // Audio data
        if (part.InlineData is { Data: not null } blob &&
            blob.MimeType?.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) == true)
        {
          yield return new OutputTextAudioRealtimeServerMessage(RealtimeServerMessageType.OutputAudioDelta)
          {
            Audio = Convert.ToBase64String(blob.Data),
            RawRepresentation = rawMessage,
          };
        }

        // Text response
        if (!string.IsNullOrEmpty(part.Text))
        {
          yield return new OutputTextAudioRealtimeServerMessage(RealtimeServerMessageType.OutputTextDelta)
          {
            Text = part.Text,
            RawRepresentation = rawMessage,
          };
        }
      }
    }

    // Input transcription
    if (serverContent.InputTranscription is { Text: not null } inputTranscription)
    {
      yield return new InputAudioTranscriptionRealtimeServerMessage(RealtimeServerMessageType.InputAudioTranscriptionCompleted)
      {
        Transcription = inputTranscription.Text,
        RawRepresentation = rawMessage,
      };
    }

    // Output transcription
    if (serverContent.OutputTranscription is { Text: not null } outputTranscription)
    {
      yield return new OutputTextAudioRealtimeServerMessage(RealtimeServerMessageType.OutputAudioTranscriptionDelta)
      {
        Text = outputTranscription.Text,
        RawRepresentation = rawMessage,
      };
    }

    // Turn complete or generation complete — reset response tracking and emit ResponseDone
    if (serverContent.TurnComplete == true || serverContent.GenerationComplete == true)
    {
      _responseInProgress = false;
      yield return new ResponseCreatedRealtimeServerMessage(RealtimeServerMessageType.ResponseDone)
      {
        RawRepresentation = rawMessage,
      };
    }
  }

  #endregion

  #region Tool Mapping Helpers

  /// <summary>
  /// Converts an <see cref="AIFunction"/> to a Google GenAI <see cref="FunctionDeclaration"/>,
  /// mapping the function name, description, and JSON schema for parameters.
  /// </summary>
  /// <param name="aiFunction">The AI function to convert.</param>
  /// <returns>A Google GenAI function declaration.</returns>
  internal static FunctionDeclaration ToGoogleFunctionDeclaration(AIFunction aiFunction)
  {
    var declaration = new FunctionDeclaration
    {
      Name = aiFunction.Name,
      Description = aiFunction.Description,
    };

    // Convert the MEAI JSON schema to a Google Schema object.
    // Google's API expects the Schema type with uppercase type names (STRING, OBJECT, etc.),
    // not raw JSON schema with lowercase types. Using Parameters instead of ParametersJsonSchema
    // ensures compatibility with the Live API's function calling.
    if (aiFunction.JsonSchema is JsonElement schemaElement &&
        schemaElement.ValueKind == JsonValueKind.Object)
    {
      declaration.Parameters = ConvertJsonSchemaToGoogleSchema(schemaElement);
    }

    return declaration;
  }

  /// <summary>
  /// Recursively converts a standard JSON Schema <see cref="JsonElement"/> to a Google GenAI
  /// <see cref="Schema"/> object, mapping lowercase type names to Google's uppercase enum values.
  /// </summary>
  internal static Schema ConvertJsonSchemaToGoogleSchema(JsonElement element)
  {
    var schema = new Schema();

    if (element.TryGetProperty("type", out var typeValue))
    {
      schema.Type = typeValue.GetString()?.ToLowerInvariant() switch
      {
        "object" => Google.GenAI.Types.Type.Object,
        "string" => Google.GenAI.Types.Type.String,
        "integer" => Google.GenAI.Types.Type.Integer,
        "number" => Google.GenAI.Types.Type.Number,
        "boolean" => Google.GenAI.Types.Type.Boolean,
        "array" => Google.GenAI.Types.Type.Array,
        _ => null
      };
    }

    if (element.TryGetProperty("description", out var desc) &&
        desc.ValueKind == JsonValueKind.String)
    {
      schema.Description = desc.GetString();
    }

    if (element.TryGetProperty("properties", out var props) &&
        props.ValueKind == JsonValueKind.Object)
    {
      schema.Properties = new Dictionary<string, Schema>();
      foreach (var prop in props.EnumerateObject())
      {
        schema.Properties[prop.Name] = ConvertJsonSchemaToGoogleSchema(prop.Value);
      }
    }

    if (element.TryGetProperty("required", out var req) &&
        req.ValueKind == JsonValueKind.Array)
    {
      schema.Required = new List<string>();
      foreach (var item in req.EnumerateArray())
      {
        if (item.ValueKind == JsonValueKind.String)
        {
          schema.Required.Add(item.GetString()!);
        }
      }
    }

    if (element.TryGetProperty("items", out var items) &&
        items.ValueKind == JsonValueKind.Object)
    {
      schema.Items = ConvertJsonSchemaToGoogleSchema(items);
    }

    return schema;
  }

  #endregion
}

