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

using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

using Google.GenAI.Types;

namespace Google.GenAI
{
  /// </summary>/// <summary>
  /// Live class encapsulates the logic for connecting to Google's GenAI Live API.
  /// Use <see cref="Live.ConnectAsync"/> to establish a websocket connection session.
  /// </summary>
  public class Live
  {
    private readonly ApiClient _apiClient;

    public Live(ApiClient apiClient)
    {
      _apiClient = apiClient;
    }

    /// <summary>
    /// Establishes a websocket connection to the specified model with the given configuration.
    /// </summary>
    /// <param name="model">
    /// The name of the model to connect to. For example "gemini-2.0-flash-live-preview-04-09".
    /// </param>
    /// <param name="config">
    /// The parameters for establishing a connection to the model.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to use for the connection.</param>
    /// <returns> <see cref="AsyncSession"/> </returns>
    public async Task<AsyncSession> ConnectAsync(string model, LiveConnectConfig config, CancellationToken cancellationToken = default)
    {
      var clientWebSocket = new ClientWebSocket();
      await SetRequestHeadersAsync(clientWebSocket, cancellationToken);
      Uri serverUri = GetServerUri();
      await clientWebSocket.ConnectAsync(serverUri, cancellationToken);
      string setupClientMessage = getSetupMessage(model, config);
      byte[] buffer = Encoding.UTF8.GetBytes(setupClientMessage);
      try
      {
        await clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, cancellationToken);
      }
      catch (Exception ex)
      {
        throw new InvalidOperationException($"Error sending setup message: {ex.Message}", ex);
      }

      return new AsyncSession(clientWebSocket, _apiClient);
    }

    private async Task SetRequestHeadersAsync(ClientWebSocket clientWebSocket, CancellationToken cancellationToken = default)
    {
      if (_apiClient.VertexAI)
      {
        if (_apiClient.Credentials == null)
        {
          throw new InvalidOperationException("GoogleAuth credentials are required for Vertex AI.");
        }

        string accessToken = await _apiClient.Credentials.GetAccessTokenForRequestAsync(cancellationToken: cancellationToken);
        if (string.IsNullOrEmpty(accessToken))
        {
          throw new InvalidOperationException("Failed to retrieve access token from credentials.");
        }
        clientWebSocket.Options.SetRequestHeader("Authorization", $"Bearer {accessToken}");
      }
      else
      {
        if (string.IsNullOrEmpty(_apiClient.ApiKey))
        {
          throw new InvalidOperationException("An API key is required for Gemini API connections.");
        }
        clientWebSocket.Options.SetRequestHeader("x-goog-api-key", _apiClient.ApiKey);
      }

      foreach (var header in _apiClient?.HttpOptions?.Headers ?? new Dictionary<string, string>())
      {
        clientWebSocket.Options.SetRequestHeader(header.Key, header.Value);
      }
    }

    private Uri GetServerUri()
    {
      string baseUrl = _apiClient.HttpOptions?.BaseUrl;
      if (string.IsNullOrEmpty(baseUrl))
      {
        throw new InvalidOperationException("BaseUrl is not set in Client.");
      }
      try
      {
        var baseUri = new Uri(baseUrl);
        var uriBuilder = new UriBuilder(baseUri)
        {
            Scheme = baseUri.Scheme == "http" ? "ws" : "wss"
        };

        string wsBaseUrl = uriBuilder.Uri.ToString().TrimEnd('/');

        if (_apiClient.VertexAI)
        {
            string apiVersion = _apiClient.HttpOptions?.ApiVersion ?? "v1beta1";
            return new Uri($"{wsBaseUrl}/ws/google.cloud.aiplatform.{apiVersion}.LlmBidiService/BidiGenerateContent");
        }
        else
        {
            string apiVersion = _apiClient.HttpOptions?.ApiVersion ?? "v1beta";
            return new Uri($"{wsBaseUrl}/ws/google.ai.generativelanguage.{apiVersion}.GenerativeService.BidiGenerateContent");
        }
      }
      catch (UriFormatException e)
      {
        throw new InvalidOperationException("Failed to parse URL.", e);
      }
    }
    private string getSetupMessage(string model, LiveConnectConfig config)
    {
      var transformedModel = Transformers.TModel(this._apiClient, model);
      if (_apiClient.VertexAI && transformedModel != null && transformedModel.StartsWith("publishers/"))
      {
        transformedModel = string.Format(
          "projects/{0}/locations/{1}/{2}",
          _apiClient.Project,
          _apiClient.Location,
          transformedModel
        );
      }
      LiveConnectParameters parameters = new LiveConnectParameters
      {
        Model = transformedModel,
        Config = config,
      };
      LiveConverters liveConverters = new LiveConverters(_apiClient);
      string jsonString = JsonSerializer.Serialize(parameters);
      JsonNode? parameterNode = JsonNode.Parse(jsonString);
      if (parameterNode == null)
      {
        throw new InvalidOperationException("Failed to parse jsonString into a JsonNode.");
      }
      JsonNode body;
      if (_apiClient.VertexAI)
      {
        body = liveConverters.LiveConnectParametersToVertex(_apiClient, parameterNode, new JsonObject());
      }
      else
      {
        body = liveConverters.LiveConnectParametersToMldev(_apiClient, parameterNode, new JsonObject());
      }
      body?.AsObject().Remove("config");
      return JsonSerializer.Serialize(body, JsonConfig.JsonSerializerOptions);
    }

  }
  /// <summary>
  /// Represents a websocket connection to the Google's GenAI Live API.
  /// This class is not meant to be instantiated directly.
  /// Instead, use <see cref="Live.ConnectAsync"/> to create an instance.
  /// </summary>
  public class AsyncSession : IAsyncDisposable
  {
    private readonly WebSocket _webSocket;
    private readonly ApiClient _apiClient;
    private int _isDisposed = 0; // 0 = false, 1 = true. Used with Interlocked.

    public AsyncSession(WebSocket webSocket, ApiClient apiClient)
    {
      _webSocket = webSocket;
      _apiClient = apiClient;
    }

    /// <summary>
    /// Sends non-realtime, turn-based content to the model.
    /// <para>
    /// There are two ways to send messages to the live API:
    /// <c>SendClientContentAsync</c> and <c>SendRealtimeInputAsync</c>.
    /// </para>
    /// <para>
    /// <c>SendClientContentAsync</c> messages are added to the model context
    /// <b>in order</b>. Because <c>SendClientContentAsync</c> guarantees the order
    /// of messages between the client and the server, the model cannot respond as
    /// quickly as with <c>SendRealtimeInputAsync</c>. This is most noticeable when
    /// sending objects that require significant preprocessing time (typically images).
    /// </para>
    /// <para>
    /// <c>SendRealtimeInputAsync</c> sends a list of <see cref="Content"/> objects,
    /// which offers more options than the <see cref="Blob"/> objects sent by
    /// <c>SendClientContentAsync</c>.
    /// </para>
    /// <para>
    /// The main use cases for <c>SendClientContentAsync</c> over
    /// <c>SendRealtimeInputAsync</c> are:
    /// <list type="number">
    /// <item>
    /// Prefilling a conversation context (including sending anything that can't be
    /// represented as a realtime message) before starting a realtime conversation.
    /// </item>
    /// <item>
    /// Conducting a non-realtime conversation with the live API.
    /// </item>
    /// </list>
    /// <b>Caution:</b> Interleaving <c>SendClientContentAsync</c> and
    /// <c>SendRealtimeInputAsync</c> in the same conversation is not recommended and
    /// can lead to unexpected behavior.
    /// </para>
    /// </summary>
    /// <param name="clientContent">
    /// The client content to send to the model.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to use for the send operation.</param>
    /// <returns></returns>
    public async Task SendClientContentAsync(LiveSendClientContentParameters clientContent, CancellationToken cancellationToken = default)
    {
      LiveClientMessage liveClientMessage = new LiveClientMessage();
      liveClientMessage.ClientContent = new LiveClientContent();
      liveClientMessage.ClientContent.Turns = clientContent.Turns;
      liveClientMessage.ClientContent.TurnComplete = clientContent.TurnComplete;

      await send(liveClientMessage, cancellationToken);
    }

    /// <summary>
    /// Sends realtime input to the model. With <c>SendRealtimeInputAsync</c>,
    /// Google's GenAI Live API will respond to audio automatically based on voice
    /// activity detection (VAD). <c>SendRealtimeInputAsync</c> is optimized for
    /// responsiveness at the expense of deterministic ordering of the conversation
    /// messages. Response tokens are added to the context as they become available.
    /// </summary>
    /// <param name="realtimeInput">
    /// The realtime input to send to the model.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to use for the send operation.</param>
    /// <returns></returns>
    public async Task SendRealtimeInputAsync(LiveSendRealtimeInputParameters realtimeInput, CancellationToken cancellationToken = default)
    {
      LiveClientMessage liveClientMessage = new LiveClientMessage();
      liveClientMessage.RealtimeInputParameters = realtimeInput;
      await send(liveClientMessage, cancellationToken);
    }

    public async Task SendToolResponseAsync(LiveSendToolResponseParameters toolResponse, CancellationToken cancellationToken = default)
    {
      LiveClientMessage liveClientMessage = new LiveClientMessage();
      liveClientMessage.ToolResponse = new LiveClientToolResponse
      {
        FunctionResponses = toolResponse.FunctionResponses
      };
      await send(liveClientMessage, cancellationToken);
    }

    /// <summary>
    /// Receives model responses from the server.
    /// </summary>
    /// <returns>
    /// A <see cref="LiveServerMessage"/> containing the model's response, or <c>null</c> if the
    /// connection has been gracefully closed.
    /// </returns>
    /// <exception cref="InvalidOperationException">Thrown if an empty or invalid message is received.</exception>
    /// <exception cref="WebSocketException">Thrown for underlying WebSocket errors that are not a graceful close.</exception>
    public async Task<LiveServerMessage?> ReceiveAsync(CancellationToken cancellationToken = default)
    {
      if (_isDisposed == 1)
      {
        return null;
      }

      switch (_webSocket.State)
      {
        case WebSocketState.Connecting:
          throw new InvalidOperationException("Cannot receive data while the WebSocket is still connecting. Ensure that the ConnectAsync method has completed.");
        case WebSocketState.Open:
          break; // Proceed with receiving.
        default:
          return null;
      }

      var buffer = new byte[4096];
      var messageBuilder = new StringBuilder();
      WebSocketReceiveResult result;

      try
      {
        do
        {
          result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
          if (result.MessageType == WebSocketMessageType.Close)
          {
            return null;
          }
          messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
        }
        while (!result.EndOfMessage);
      }
      catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
      {
        return null;
      }

      var messageString = messageBuilder.ToString();
      if (string.IsNullOrEmpty(messageString))
      {
        throw new InvalidOperationException("Received an empty message from the server.");
      }

      var serverMessage = LiveServerMessage.FromJson(messageString);
      if (serverMessage == null)
      {
        throw new InvalidOperationException("Failed to deserialize server message because it is null.");
      }
      return serverMessage;
    }

    /// <summary>
    /// Closes the WebSocket connection gracefully. This method is thread-safe and idempotent.
    /// </summary>
    public async Task CloseAsync()
    {
      // Atomically check and set the disposed flag to ensure this block runs only once.
      // Critical to avoid race conditions in multi-threaded scenarios.
      if (Interlocked.CompareExchange(ref _isDisposed, 1, 0) != 0)
      {
        return;
      }

      try
      {
        if (_webSocket.State == WebSocketState.Open || _webSocket.State == WebSocketState.Connecting)
        {
          await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
        }
        else if (_webSocket.State == WebSocketState.CloseReceived)
        {
          await _webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Acknowledging server close", CancellationToken.None);
        }
        // For other states (None, CloseSent, Closed, Aborted), no action is needed.
      }
      catch (Exception ex) when (ex is ObjectDisposedException || ex is InvalidOperationException ||
                                 ex is WebSocketException || ex is OperationCanceledException ||
                                 ex is IOException)
      {
        // Suppress exceptions during cleanup as the primary goal is to release resources.
        // Optionally, these exceptions can be logged for debugging purposes.
      }
      finally
      {
        _webSocket.Dispose();
      }
    }

    /// <summary>
    /// Asynchronously disposes the session by closing the WebSocket connection.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
      await CloseAsync();
    }

    private async Task send(LiveClientMessage liveClientMessage, CancellationToken cancellationToken = default)
    {
      JsonNode? liveClientMessageNode = JsonNode.Parse(JsonSerializer.Serialize(liveClientMessage, JsonConfig.JsonSerializerOptions));
      if (liveClientMessageNode == null)
      {
        throw new InvalidOperationException("Failed to parse liveClientMessage into a JsonNode.");
      }
      LiveConverters liveConverters = new LiveConverters(_apiClient);
      JsonNode body;
      if (_apiClient.VertexAI)
      {
        body = liveConverters.LiveClientMessageToVertex(liveClientMessageNode, new JsonObject());
      }
      else
      {
        body = liveConverters.LiveClientMessageToMldev(liveClientMessageNode, new JsonObject());
      }
      string jsonMessage = JsonSerializer.Serialize(body, JsonConfig.JsonSerializerOptions);
      byte[] buffer = Encoding.UTF8.GetBytes(jsonMessage);

      if (_webSocket.State != WebSocketState.Open)
      {
        throw new InvalidOperationException($"WebSocket is not open. State: {_webSocket.State}");
      }
      await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, cancellationToken);
    }
  }
}
