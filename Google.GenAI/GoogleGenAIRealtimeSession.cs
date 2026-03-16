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

using System.Collections.Concurrent;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
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

  // Serializes all WebSocket send operations. Required because:
  //   1. WebSocket.SendAsync is NOT thread-safe for concurrent calls.
  //   2. FunctionInvokingRealtimeSession middleware can call SendAsync (to return
  //      function results) concurrently with the caller's own SendAsync (e.g., audio).
  //   3. HandleAudioCommitAsync sends a multi-message sequence (ActivityStart →
  //      audio frames → ActivityEnd) that must be atomic.
  private readonly SemaphoreSlim _sendLock = new(1, 1);

  // Track whether audio was sent via SendRealtimeInputAsync to avoid mixing with SendClientContentAsync.
  private bool _lastInputWasRealtime;

  // Track whether a tool response was just sent. After SendToolResponseAsync, the server
  // automatically continues generating — sending TurnComplete would be unexpected.
  private bool _lastSendWasToolResponse;

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
            // Do not send TurnComplete — it would cause the server to close the connection.
            _lastSendWasToolResponse = false;
          }
          else if (!_lastInputWasRealtime)
          {
            await _asyncSession.SendClientContentAsync(
              new LiveSendClientContentParameters { TurnComplete = true },
              cancellationToken).ConfigureAwait(false);
          }
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
    catch (Exception ex) when (ex is OperationCanceledException or ObjectDisposedException or WebSocketException)
    {
      // These exceptions are expected during session teardown and are swallowed:
      //   - OperationCanceledException: internal cancellation from disposal (not the caller's token).
      //   - ObjectDisposedException: DisposeAsync was called on another thread while an
      //     operation was in-flight on the underlying WebSocket.
      //   - WebSocketException: the connection was closed (server disconnect or local close).
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
    await _asyncSession.DisposeAsync().ConfigureAwait(false);
    _sendLock.Dispose();
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

    _lastInputWasRealtime = true;

    // When VAD is disabled, explicit ActivityStart/ActivityEnd framing is required.
    // ActivityStart marks the beginning of user speech; ActivityEnd triggers model response.
    // When VAD is enabled, the server auto-detects speech boundaries — skip framing.
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

    // When VAD is disabled, signal end of user activity — this triggers the model to respond.
    // When VAD is enabled, the server detects end of speech automatically.
    if (!_vadEnabled)
    {
      await _asyncSession.SendRealtimeInputAsync(
        new LiveSendRealtimeInputParameters
        {
          ActivityEnd = new ActivityEnd()
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
            ["result"] = functionResult.Result?.ToString() ?? string.Empty
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

    // Otherwise, treat as text/content conversation input
    var parts = new List<Part>();
    foreach (var content in itemCreate.Item.Contents)
    {
      if (content is TextContent textContent && !string.IsNullOrEmpty(textContent.Text))
      {
        parts.Add(new Part { Text = textContent.Text });
      }
      else if (content is DataContent dataContent)
      {
        if (dataContent.HasTopLevelMediaType("audio"))
        {
          parts.Add(new Part
          {
            InlineData = new Blob
            {
              Data = ExtractDataBytes(dataContent),
              MimeType = dataContent.MediaType ?? "audio/pcm",
            }
          });
        }
        else if (dataContent.HasTopLevelMediaType("image"))
        {
          byte[] imageBytes = ExtractDataBytes(dataContent);
          parts.Add(new Part
          {
            InlineData = new Blob
            {
              Data = imageBytes,
              MimeType = dataContent.MediaType ?? "image/png",
            }
          });
        }
      }
    }

    if (parts.Count == 0)
    {
      return;
    }

    string role = itemCreate.Item.Role?.Value switch
    {
      "assistant" => "model",
      _ => "user",
    };

    _lastInputWasRealtime = false;
    _lastSendWasToolResponse = false;
    await _asyncSession.SendClientContentAsync(
      new LiveSendClientContentParameters
      {
        Turns = new List<Content>
        {
          new Content
          {
            Parts = parts,
            Role = role,
          }
        },
      },
      cancellationToken).ConfigureAwait(false);
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
        if (fc.Id is not null && fc.Name is not null)
        {
          _callIdToFunctionName[fc.Id] = fc.Name;
        }

        var contents = new List<AIContent>
        {
          new FunctionCallContent(
            fc.Id ?? string.Empty,
            fc.Name ?? string.Empty,
            fc.Args?.ToDictionary(kvp => kvp.Key, kvp => (object?)kvp.Value))
        };

        var item = new RealtimeConversationItem(contents, id: fc.Id, role: ChatRole.Assistant);

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

    // Map the JSON schema for parameters
    if (aiFunction.JsonSchema is JsonElement schemaElement &&
        schemaElement.ValueKind != JsonValueKind.Undefined)
    {
      declaration.ParametersJsonSchema = schemaElement;
    }

    return declaration;
  }

  #endregion
}

