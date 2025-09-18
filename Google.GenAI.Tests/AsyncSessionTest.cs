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

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Google.GenAI.Tests {
  [TestClass]
  public class TestApiClient : ApiClient {
    private readonly bool VertexAI;

    public TestApiClient(bool vertexAI) : base("test-api-key", null) {
      VertexAI = vertexAI;
    }

    public override Task<ApiResponse> RequestAsync(HttpMethod httpMethod, string path,
                                                   string requestJson,
                                                   HttpOptions? requestHttpOptions,
                                                   CancellationToken cancellationToken = default) {
      return Task.FromResult<ApiResponse>(new TestApiResponse { Body = "{}" });
    }

    public override IAsyncEnumerable<ApiResponse> RequestStreamAsync(
        HttpMethod httpMethod, string path, string requestJson, HttpOptions? requestHttpOptions,
        [EnumeratorCancellation] CancellationToken cancellationToken = default) {
      return GetDummyAsyncEnumerable(cancellationToken);
    }

    private async IAsyncEnumerable<ApiResponse> GetDummyAsyncEnumerable(
        [EnumeratorCancellation] CancellationToken cancellationToken = default) {
      yield return new TestApiResponse { Body = "{}" };
      await Task.CompletedTask;
    }
  }

  public class TestApiResponse : ApiResponse {
    public string Body { get; set; } = "";

    public override HttpContent GetEntity() {
      return new StringContent(Body);
    }

    public override HttpResponseHeaders GetHeaders() {
      var response = new HttpResponseMessage();
      return response.Headers;
    }
  }

  [TestClass]
  public class AsyncSessionTest {
    private Mock<WebSocket> _mockWebSocket;
    private AsyncSession _asyncSession;

    [TestInitialize]
    public void TestInitialize() {
      _mockWebSocket = new Mock<WebSocket>();
      _asyncSession = new AsyncSession(_mockWebSocket.Object, new TestApiClient(false));
    }

    [TestMethod]
    public async Task ReceiveAsync_WhenServerSendsCloseMessage_ShouldReturnNull() {
      var closeStatus = WebSocketCloseStatus.PolicyViolation;
      var closeStatusDescription = "Server initiated close due to policy violation.";
      var closeResult = new WebSocketReceiveResult(0, WebSocketMessageType.Close, true, closeStatus,
                                                   closeStatusDescription);

      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);
      _mockWebSocket
          .Setup(ws =>
                     ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
          .ReturnsAsync(closeResult);

      var result = await _asyncSession.ReceiveAsync();

      Assert.IsNull(result);
      _mockWebSocket.Verify(
          ws => ws.CloseOutputAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(),
                                    It.IsAny<CancellationToken>()),
          Times.Never);
    }

    [TestMethod]
    public async Task ReceiveAsync_WhenMessageIsEmptyString_ShouldThrowInvalidOperationException() {
      var emptyReceiveResult = new WebSocketReceiveResult(0, WebSocketMessageType.Text, true);
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);
      _mockWebSocket
          .Setup(ws =>
                     ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
          .ReturnsAsync(emptyReceiveResult);

      var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
          async () => await _asyncSession.ReceiveAsync());

      Assert.AreEqual("Received an empty message from the server.", exception.Message);
    }

    [TestMethod]
    public async Task
    ReceiveAsync_WhenValidSingleFrameMessageReceived_ShouldReturnDeserializedMessage() {
      var expectedLiveServerMessage =
          new LiveServerMessage { ServerContent = new LiveServerContent {
            ModelTurn =
                new Types.Content {
                  Parts = new List<Types.Part> { new Types.Part { Text = "Test message" } }
                }
          } };
      string expectedSerializedLiveServeMessage =
          JsonSerializer.Serialize(expectedLiveServerMessage, JsonConfig.JsonSerializerOptions);
      byte[] messageBytes = Encoding.UTF8.GetBytes(expectedSerializedLiveServeMessage);
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);

      _mockWebSocket
          .Setup(ws =>
                     ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
          .Callback<ArraySegment<byte>, CancellationToken>((buffer, token) => {
            Array.Copy(messageBytes, 0, buffer.Array!, buffer.Offset, messageBytes.Length);
          })
          .ReturnsAsync(
              new WebSocketReceiveResult(messageBytes.Length, WebSocketMessageType.Text, true));

      var actualLiveServerMessage = await _asyncSession.ReceiveAsync();

      Assert.AreEqual(
          expectedSerializedLiveServeMessage,
          JsonSerializer.Serialize(actualLiveServerMessage, JsonConfig.JsonSerializerOptions));
    }

    [TestMethod]
    public async Task
    ReceiveAsync_WhenMessageDeserializesToNull_ShouldThrowInvalidOperationException() {
      string jsonNull = "null";
      byte[] messageBytes = Encoding.UTF8.GetBytes(jsonNull);
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);

      _mockWebSocket
          .Setup(ws =>
                     ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
          .Callback<ArraySegment<byte>, CancellationToken>((buffer, token) => {
            Array.Copy(messageBytes, 0, buffer.Array!, buffer.Offset, messageBytes.Length);
          })
          .ReturnsAsync(
              new WebSocketReceiveResult(messageBytes.Length, WebSocketMessageType.Text, true));

      var exception = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
          async () => await _asyncSession.ReceiveAsync());

      Assert.AreEqual("Failed to deserialize server message because it is null.",
                      exception.Message);
    }

    [TestMethod]
    public async Task
    ReceiveAsync_WhenMultiFrameMessageReceived_ShouldReturnCombinedDeserializedMessage() {
      var part1 = "{\"serverContent\":{\"modelTurn\":{\"parts\":[{\"text\":\"Hello\"}]}}";
      var part2 = "}";
      var fullMessage = part1 + part2;
      var expectedMessage = JsonSerializer.Deserialize<LiveServerMessage>(
          fullMessage, JsonConfig.JsonSerializerOptions);
      var part1Bytes = Encoding.UTF8.GetBytes(part1);
      var part2Bytes = Encoding.UTF8.GetBytes(part2);
      var callCount = 0;
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);

      _mockWebSocket
          .Setup(ws =>
                     ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
          .Callback<ArraySegment<byte>, CancellationToken>((buffer, token) => {
            if (callCount == 0) {
              Array.Copy(part1Bytes, 0, buffer.Array!, buffer.Offset, part1Bytes.Length);
            } else {
              Array.Copy(part2Bytes, 0, buffer.Array!, buffer.Offset, part2Bytes.Length);
            }
            callCount++;
          })
          .ReturnsAsync(() => {
            if (callCount == 1) {
              return new WebSocketReceiveResult(part1Bytes.Length, WebSocketMessageType.Text,
                                                false);
            } else {
              return new WebSocketReceiveResult(part2Bytes.Length, WebSocketMessageType.Text, true);
            }
          });

      var actualMessage = await _asyncSession.ReceiveAsync();

      Assert.AreEqual(JsonSerializer.Serialize(expectedMessage, JsonConfig.JsonSerializerOptions),
                      JsonSerializer.Serialize(actualMessage, JsonConfig.JsonSerializerOptions));
    }

    [TestMethod]
    public async Task SendClientContentAsync_WithValidContent_ShouldSendCorrectMessage() {
      var clientContent = new LiveSendClientContentParameters {
        Turns = new List<Types.Content> { new Types.Content {
          Role = "user", Parts = new List<Part> { new Part { Text = "Test" } }
        } },
        TurnComplete = true
      };
      string? sentMessage = null;
      WebSocketMessageType? sentType = null;
      bool? sentEndOfMessage = null;
      CancellationToken? sentToken = null;

      _mockWebSocket
          .Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true,
                                    It.IsAny<CancellationToken>()))
          .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
              (buffer, messageType, endOfMessage, token) => {
                sentMessage = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
                sentType = messageType;
                sentEndOfMessage = endOfMessage;
                sentToken = token;
              })
          .Returns(Task.CompletedTask);
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);

      await _asyncSession.SendClientContentAsync(clientContent);

      Assert.IsNotNull(sentMessage);
      var sentObject = JsonNode.Parse(sentMessage);
      Assert.IsNotNull(sentObject["clientContent"]);
      Assert.AreEqual("Test", (string)sentObject["clientContent"]["turns"][0]["parts"][0]["text"]);
      Assert.AreEqual(WebSocketMessageType.Text, sentType);
      Assert.IsTrue(sentEndOfMessage.HasValue && sentEndOfMessage.Value);
      Assert.IsNotNull(sentToken);
    }

    [TestMethod]
    public async Task SendRealtimeInputAsync_WithValidInput_ShouldSendCorrectMessage() {
      var realtimeInput = new LiveSendRealtimeInputParameters { Text = "Realtime Test" };
      string? sentMessage = null;
      WebSocketMessageType? sentType = null;
      bool? sentEndOfMessage = null;
      CancellationToken? sentToken = null;

      _mockWebSocket
          .Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true,
                                    It.IsAny<CancellationToken>()))
          .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
              (buffer, messageType, endOfMessage, token) => {
                sentMessage = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
                sentType = messageType;
                sentEndOfMessage = endOfMessage;
                sentToken = token;
              })
          .Returns(Task.CompletedTask);
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);

      await _asyncSession.SendRealtimeInputAsync(realtimeInput);

      Assert.IsNotNull(sentMessage);
      var sentObject = JsonNode.Parse(sentMessage);
      Assert.IsNotNull(sentObject["realtime_input"]);
      Assert.AreEqual("Realtime Test", (string)sentObject["realtime_input"]["text"]);
      Assert.AreEqual(WebSocketMessageType.Text, sentType);
      Assert.IsTrue(sentEndOfMessage.HasValue && sentEndOfMessage.Value);
      Assert.IsNotNull(sentToken);
    }

    [TestMethod]
    public async Task SendToolResponseAsync_WithValidResponse_ShouldSendCorrectMessage() {
      var toolResponse =
          new LiveSendToolResponseParameters { FunctionResponses = new List<FunctionResponse> {
            new FunctionResponse { Name = "test-func", Response = new Dictionary<string, object>() }
          } };
      string? sentMessage = null;
      WebSocketMessageType? sentType = null;
      bool? sentEndOfMessage = null;
      CancellationToken? sentToken = null;

      _mockWebSocket
          .Setup(ws => ws.SendAsync(It.IsAny<ArraySegment<byte>>(), WebSocketMessageType.Text, true,
                                    It.IsAny<CancellationToken>()))
          .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
              (buffer, messageType, endOfMessage, token) => {
                sentMessage = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
                sentType = messageType;
                sentEndOfMessage = endOfMessage;
                sentToken = token;
              })
          .Returns(Task.CompletedTask);
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);

      await _asyncSession.SendToolResponseAsync(toolResponse);

      Assert.IsNotNull(sentMessage);
      var sentObject = JsonNode.Parse(sentMessage);
      Assert.IsNotNull(sentObject["toolResponse"]);
      Assert.AreEqual("test-func",
                      (string)sentObject["toolResponse"]["functionResponses"][0]["name"]);
      Assert.AreEqual(WebSocketMessageType.Text, sentType);
      Assert.IsTrue(sentEndOfMessage.HasValue && sentEndOfMessage.Value);
      Assert.IsNotNull(sentToken);
    }

    [TestMethod]
    public async Task SendAsync_WhenWebSocketNotOpen_ShouldThrowInvalidOperationException() {
      var clientContent = new LiveSendClientContentParameters();

      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Closed);

      var ex = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
          () => _asyncSession.SendClientContentAsync(clientContent));

      Assert.AreEqual("WebSocket is not open. State: Closed", ex.Message);
    }

    [TestMethod]
    public async Task SendAsync_WhenSendAsyncThrows_ShouldThrowOriginalException() {
      var clientContent = new LiveSendClientContentParameters();
      var originalException = new WebSocketException("Send failed");

      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);
      _mockWebSocket
          .Setup(ws =>
                     ws.SendAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<WebSocketMessageType>(),
                                  It.IsAny<bool>(), It.IsAny<CancellationToken>()))
          .ThrowsAsync(originalException);

      var ex = await Assert.ThrowsExceptionAsync<WebSocketException>(
          () => _asyncSession.SendClientContentAsync(clientContent));

      Assert.AreSame(originalException, ex);
    }

    [TestMethod]
    public async Task CloseAsync_ShouldCallWebSocketCloseAsync() {
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);
      _mockWebSocket
          .Setup(ws => ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing",
                                     It.IsAny<CancellationToken>()))
          .Returns(Task.CompletedTask)
          .Verifiable();

      await _asyncSession.CloseAsync();

      _mockWebSocket.Verify();
    }

    [TestMethod]
    public async Task CloseAsync_WhenWebSocketIsCloseReceived_ShouldCallCloseOutputAsync() {
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.CloseReceived);
      _mockWebSocket
          .Setup(ws => ws.CloseOutputAsync(WebSocketCloseStatus.NormalClosure,
                                           "Acknowledging server close",
                                           It.IsAny<CancellationToken>()))
          .Returns(Task.CompletedTask)
          .Verifiable();

      await _asyncSession.CloseAsync();

      _mockWebSocket.Verify();
    }

    [TestMethod]
    public async Task CloseAsync_WhenWebSocketIsAlreadyClosed_ShouldNotCallAnyCloseMethod() {
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Closed);

      await _asyncSession.CloseAsync();

      _mockWebSocket.Verify(ws => ws.CloseAsync(It.IsAny<WebSocketCloseStatus>(),
                                                It.IsAny<string>(), It.IsAny<CancellationToken>()),
                            Times.Never);
      _mockWebSocket.Verify(
          ws => ws.CloseOutputAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(),
                                    It.IsAny<CancellationToken>()),
          Times.Never);
    }

    [TestMethod]
    public async Task CloseAsync_WhenWebSocketThrowsException_ShouldNotPropagate() {
      _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);
      _mockWebSocket
          .Setup(ws => ws.CloseAsync(It.IsAny<WebSocketCloseStatus>(), It.IsAny<string>(),
                                     It.IsAny<CancellationToken>()))
          .ThrowsAsync(new WebSocketException("Connection closed by remote party"));
      _mockWebSocket.Setup(ws => ws.Dispose()).Verifiable();

      await _asyncSession.CloseAsync();

      _mockWebSocket.Verify(ws => ws.Dispose(), Times.Once);
    }
  }
}
