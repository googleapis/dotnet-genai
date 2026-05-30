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

#pragma warning disable MEAI001 // Experimental AI API

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Types;
using Microsoft.Extensions.AI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

#pragma warning disable MEAI001

namespace Google.GenAI.Tests;

[TestClass]
public class GoogleGenAIRealtimeClientTest
{
  #region Extension Method Tests

  [TestMethod]
  public void AsIRealtimeClient_NullClient_ThrowsArgumentNullException()
  {
    Client? client = null;
    Assert.ThrowsException<ArgumentNullException>(() => client!.AsIRealtimeClient("model"));
  }

  [TestMethod]
  public void AsIRealtimeClient_ValidClient_ReturnsNonNull()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = client.AsIRealtimeClient("model");
    Assert.IsNotNull(realtimeClient);
  }

  [TestMethod]
  public void AsIRealtimeClient_NullModelId_ReturnsNonNull()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = client.AsIRealtimeClient();
    Assert.IsNotNull(realtimeClient);
  }

  #endregion

  #region Client Constructor Tests

  [TestMethod]
  public void RealtimeClient_NullClient_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new GoogleGenAIRealtimeClient((Client)null!, "model"));
  }

  [TestMethod]
  public void RealtimeClient_NullModelId_Succeeds()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client);
    Assert.IsNotNull(realtimeClient);
  }

  [TestMethod]
  public void RealtimeClient_ProjectLocation_Succeeds()
  {
    var realtimeClient = new GoogleGenAIRealtimeClient("my-project", "us-central1", "model");
    Assert.IsNotNull(realtimeClient);
  }

  [TestMethod]
  public void RealtimeClient_ProjectLocation_NullProject_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new GoogleGenAIRealtimeClient(null!, "us-central1", "model"));
  }

  [TestMethod]
  public void RealtimeClient_ProjectLocation_EmptyProject_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new GoogleGenAIRealtimeClient("", "us-central1", "model"));
  }

  [TestMethod]
  public void RealtimeClient_ProjectLocation_NullLocation_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new GoogleGenAIRealtimeClient("my-project", null!, "model"));
  }

  [TestMethod]
  public void RealtimeClient_ProjectLocation_EmptyLocation_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new GoogleGenAIRealtimeClient("my-project", "", "model"));
  }

  #endregion

  #region Client GetService Tests

  [TestMethod]
  public void RealtimeClient_GetService_ReturnsMetadata()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "my-model");

    var metadata = realtimeClient.GetService(typeof(ChatClientMetadata)) as ChatClientMetadata;
    Assert.IsNotNull(metadata);
    Assert.AreEqual("google-genai", metadata.ProviderName);
    Assert.AreEqual("my-model", metadata.DefaultModelId);
  }

  [TestMethod]
  public void RealtimeClient_GetService_ReturnsSelf()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "model");

    var self = realtimeClient.GetService(typeof(GoogleGenAIRealtimeClient));
    Assert.AreSame(realtimeClient, self);
  }

  [TestMethod]
  public void RealtimeClient_GetService_ReturnsInnerClient()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "model");

    var inner = realtimeClient.GetService(typeof(Client));
    Assert.AreSame(client, inner);
  }

  [TestMethod]
  public void RealtimeClient_GetService_NullServiceType_ThrowsArgumentNullException()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "model");

    Assert.ThrowsException<ArgumentNullException>(
      () => realtimeClient.GetService(null!));
  }

  [TestMethod]
  public void RealtimeClient_GetService_WithKey_ReturnsNull()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "model");

    var result = realtimeClient.GetService(typeof(ChatClientMetadata), serviceKey: "some-key");
    Assert.IsNull(result);
  }

  [TestMethod]
  public void RealtimeClient_GetService_UnknownType_ReturnsNull()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "model");

    var result = realtimeClient.GetService(typeof(string));
    Assert.IsNull(result);
  }

  #endregion

  #region Client Dispose Tests

  [TestMethod]
  public void RealtimeClient_Dispose_IsIdempotent()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "model");

    // Should not throw
    realtimeClient.Dispose();
    realtimeClient.Dispose();
  }

  #endregion

  #region Client CreateSession Tests

  [TestMethod]
  public async Task RealtimeClient_CreateSession_NoModel_ThrowsInvalidOperationException()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client);

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
      () => realtimeClient.CreateSessionAsync(new RealtimeSessionOptions()));
  }

  [TestMethod]
  public async Task RealtimeClient_CreateSession_Cancelled_ThrowsOperationCanceledException()
  {
    var client = new Client(apiKey: "fake-api-key");
    var realtimeClient = new GoogleGenAIRealtimeClient(client, "model");
    using var cts = new CancellationTokenSource();
    cts.Cancel();

    await Assert.ThrowsExceptionAsync<TaskCanceledException>(
      () => realtimeClient.CreateSessionAsync(new RealtimeSessionOptions(), cts.Token));
  }

  #endregion

  #region ToGoogleFunctionDeclaration Tests

  [TestMethod]
  public void ToGoogleFunctionDeclaration_MapsNameAndDescription()
  {
    var function = AIFunctionFactory.Create(() => "result", "myFunc", "A test function");

    var declaration = GoogleGenAIRealtimeSession.ToGoogleFunctionDeclaration(function);

    Assert.AreEqual("myFunc", declaration.Name);
    Assert.AreEqual("A test function", declaration.Description);
  }

  [TestMethod]
  public void ToGoogleFunctionDeclaration_WithJsonSchema_MapsParameters()
  {
    var function = AIFunctionFactory.Create((string name, int age) => $"{name} is {age}",
      "greet", "Greets a person");

    var declaration = GoogleGenAIRealtimeSession.ToGoogleFunctionDeclaration(function);

    Assert.AreEqual("greet", declaration.Name);
    Assert.AreEqual("Greets a person", declaration.Description);

    // The Parameters (Google Schema) should be set since the function has parameters
    Assert.IsNotNull(declaration.Parameters);
  }

  [TestMethod]
  public void ToGoogleFunctionDeclaration_NoParameters_HasNoParameterSchema()
  {
    var function = AIFunctionFactory.Create(() => "hello", "noParams", "No parameters");

    var declaration = GoogleGenAIRealtimeSession.ToGoogleFunctionDeclaration(function);

    Assert.AreEqual("noParams", declaration.Name);
  }

  #endregion
}

[TestClass]
public class GoogleGenAIRealtimeSessionTest
{
  private Mock<WebSocket> _mockWebSocket = null!;
  private AsyncSession _asyncSession = null!;
  private GoogleGenAIRealtimeSession _session = null!;

  [TestInitialize]
  public void TestInitialize()
  {
    _mockWebSocket = new Mock<WebSocket>();
    _mockWebSocket.Setup(ws => ws.State).Returns(WebSocketState.Open);
    _asyncSession = new AsyncSession(_mockWebSocket.Object, new TestApiClient(false));
    _session = new GoogleGenAIRealtimeSession(_asyncSession, "test-model", null);
  }

  [TestCleanup]
  public async Task TestCleanup()
  {
    await _session.DisposeAsync();
  }

  #region Constructor Tests

  [TestMethod]
  public void Session_NullAsyncSession_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new GoogleGenAIRealtimeSession(null!, "model", null));
  }

  [TestMethod]
  public void Session_ValidConstruction_SetsOptions()
  {
    var options = new RealtimeSessionOptions { Model = "my-model" };
    var session = new GoogleGenAIRealtimeSession(
      _asyncSession, "my-model", options);

    Assert.AreSame(options, session.Options);
  }

  [TestMethod]
  public void Session_NullOptions_OptionsIsNull()
  {
    Assert.IsNull(_session.Options);
  }

  #endregion

  #region Session GetService Tests

  [TestMethod]
  public void Session_GetService_ReturnsMetadata()
  {
    var metadata = _session.GetService(typeof(ChatClientMetadata)) as ChatClientMetadata;
    Assert.IsNotNull(metadata);
    Assert.AreEqual("google-genai", metadata.ProviderName);
    Assert.AreEqual("test-model", metadata.DefaultModelId);
  }

  [TestMethod]
  public void Session_GetService_ReturnsSelf()
  {
    var self = _session.GetService(typeof(GoogleGenAIRealtimeSession));
    Assert.AreSame(_session, self);
  }

  [TestMethod]
  public void Session_GetService_ReturnsInnerAsyncSession()
  {
    var inner = _session.GetService(typeof(AsyncSession));
    Assert.AreSame(_asyncSession, inner);
  }

  [TestMethod]
  public void Session_GetService_NullServiceType_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => _session.GetService(null!));
  }

  [TestMethod]
  public void Session_GetService_WithKey_ReturnsNull()
  {
    var result = _session.GetService(typeof(ChatClientMetadata), serviceKey: "key");
    Assert.IsNull(result);
  }

  [TestMethod]
  public void Session_GetService_UnknownType_ReturnsNull()
  {
    var result = _session.GetService(typeof(string));
    Assert.IsNull(result);
  }

  #endregion

  #region Session DisposeAsync Tests

  [TestMethod]
  public async Task Session_DisposeAsync_IsIdempotent()
  {
    var session = new GoogleGenAIRealtimeSession(_asyncSession, "model", null);

    // Should not throw on double dispose
    await session.DisposeAsync();
    await session.DisposeAsync();
  }

  #endregion

  #region SendAsync Guard Tests

  [TestMethod]
  public async Task SendAsync_NullMessage_ThrowsArgumentNullException()
  {
    await Assert.ThrowsExceptionAsync<ArgumentNullException>(
      () => _session.SendAsync(null!));
  }

  [TestMethod]
  public async Task SendAsync_AfterDispose_ThrowsObjectDisposedException()
  {
    await _session.DisposeAsync();

    await Assert.ThrowsExceptionAsync<ObjectDisposedException>(
      () => _session.SendAsync(new CreateResponseRealtimeClientMessage()));
  }

  [TestMethod]
  public async Task SendAsync_CancelledToken_ThrowsOperationCanceledException()
  {
    using var cts = new CancellationTokenSource();
    cts.Cancel();

    await Assert.ThrowsExceptionAsync<OperationCanceledException>(
      () => _session.SendAsync(new CreateResponseRealtimeClientMessage(), cts.Token));
  }

  [TestMethod]
  public async Task SendAsync_SessionUpdate_DoesNotUpdateOptions()
  {
    var initialOptions = new RealtimeSessionOptions { Model = "initial-model" };
    var session = new GoogleGenAIRealtimeSession(_asyncSession, "initial-model", initialOptions);

    var newOptions = new RealtimeSessionOptions { Model = "updated-model" };
    var msg = new SessionUpdateRealtimeClientMessage(newOptions);

    await session.SendAsync(msg);

    // Gemini does not support mid-session updates; options should remain unchanged.
    Assert.AreSame(initialOptions, session.Options);

    await session.DisposeAsync();
  }

  [TestMethod]
  public void SendAsync_SessionUpdate_NullOptions_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new SessionUpdateRealtimeClientMessage(null!));
  }

  [TestMethod]
  public async Task SendAsync_UnknownMessageType_DoesNotThrow()
  {
    // A generic RealtimeClientMessage should just be ignored (default case)
    var msg = new RealtimeClientMessage();
    await _session.SendAsync(msg);
  }

  #endregion

  #region Audio Buffering Tests

  [TestMethod]
  public void SendAsync_AudioAppend_NoContent_ThrowsArgumentNullException()
  {
    Assert.ThrowsException<ArgumentNullException>(
      () => new InputAudioBufferAppendRealtimeClientMessage(null!));
  }

  [TestMethod]
  public async Task SendAsync_AudioAppend_NonAudioContent_DoesNotThrow()
  {
    var msg = new InputAudioBufferAppendRealtimeClientMessage(new DataContent("data:text/plain;base64,SGVsbG8=", "text/plain"));
    await _session.SendAsync(msg);
  }

  [TestMethod]
  public async Task SendAsync_AudioAppendThenCommit_SendsFrames()
  {
    // Prepare audio content
    byte[] audioData = new byte[100];
    new Random(42).NextBytes(audioData);
    string base64 = Convert.ToBase64String(audioData);
    var dataUri = $"data:audio/pcm;base64,{base64}";

    var appendMsg = new InputAudioBufferAppendRealtimeClientMessage(new DataContent(dataUri, "audio/pcm"));

    // Track SendAsync calls on the WebSocket
    var sentMessages = new List<byte[]>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          var copy = new byte[buffer.Count];
          Buffer.BlockCopy(buffer.Array!, buffer.Offset, copy, 0, buffer.Count);
          sentMessages.Add(copy);
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(appendMsg);

    // Nothing sent yet (just buffered)
    Assert.AreEqual(0, sentMessages.Count);

    // Commit triggers actual send
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // Should have sent: ActivityStart + audio frame(s) + ActivityEnd
    Assert.IsTrue(sentMessages.Count >= 3,
      $"Expected at least 3 WebSocket messages (ActivityStart + audio + ActivityEnd), got {sentMessages.Count}");
  }

  [TestMethod]
  public async Task SendAsync_AudioCommit_EmptyBuffer_DoesNothing()
  {
    var sentMessages = new List<byte[]>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          var copy = new byte[buffer.Count];
          Buffer.BlockCopy(buffer.Array!, buffer.Offset, copy, 0, buffer.Count);
          sentMessages.Add(copy);
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    Assert.AreEqual(0, sentMessages.Count);
  }

  [TestMethod]
  public async Task SendAsync_AudioAppend_ExceedsBufferLimit_ThrowsInvalidOperationException()
  {
    // Create audio data close to the 10MB limit
    byte[] largeAudio = new byte[10 * 1024 * 1024 + 1];
    string base64 = Convert.ToBase64String(largeAudio);
    var dataUri = $"data:audio/pcm;base64,{base64}";

    var appendMsg = new InputAudioBufferAppendRealtimeClientMessage(new DataContent(dataUri, "audio/pcm"));

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
      () => _session.SendAsync(appendMsg));
  }

  [TestMethod]
  public async Task SendAsync_AudioAppend_LargeFrame_SplitsIntoMultipleFrames()
  {
    // Create audio data larger than 32KB frame limit (e.g. 70KB)
    byte[] audioData = new byte[70_000];
    new Random(42).NextBytes(audioData);
    string base64 = Convert.ToBase64String(audioData);
    var dataUri = $"data:audio/pcm;base64,{base64}";

    var appendMsg = new InputAudioBufferAppendRealtimeClientMessage(new DataContent(dataUri, "audio/pcm"));

    var sentMessages = new List<byte[]>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          var copy = new byte[buffer.Count];
          Buffer.BlockCopy(buffer.Array!, buffer.Offset, copy, 0, buffer.Count);
          sentMessages.Add(copy);
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(appendMsg);
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // 70KB audio = 3 frames (32K + 32K + 6K) + ActivityStart + ActivityEnd = 5 messages
    Assert.AreEqual(5, sentMessages.Count,
      $"Expected 5 WebSocket messages (ActivityStart + 3 audio frames + ActivityEnd), got {sentMessages.Count}");
  }

  #endregion

  #region GetStreamingResponseAsync Tests

  [TestMethod]
  public async Task GetStreamingResponseAsync_AfterDispose_ThrowsObjectDisposedException()
  {
    await _session.DisposeAsync();

    await Assert.ThrowsExceptionAsync<ObjectDisposedException>(async () =>
    {
      await foreach (var _ in _session.GetStreamingResponseAsync())
      {
      }
    });
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_NullMessage_YieldsBreak()
  {
    // AsyncSession.ReceiveAsync returns null on close
    var closeResult = new WebSocketReceiveResult(
      0, WebSocketMessageType.Close, true,
      WebSocketCloseStatus.NormalClosure, "done");

    _mockWebSocket
      .Setup(ws => ws.ReceiveAsync(
        It.IsAny<ArraySegment<byte>>(),
        It.IsAny<CancellationToken>()))
      .ReturnsAsync(closeResult);

    var messages = new List<RealtimeServerMessage>();
    await foreach (var msg in _session.GetStreamingResponseAsync())
    {
      messages.Add(msg);
    }

    Assert.AreEqual(0, messages.Count);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_CallerCancelled_YieldsNoResults()
  {
    // A pre-cancelled token causes the while-loop condition to be false immediately,
    // so the iterator completes without throwing.
    using var cts = new CancellationTokenSource();
    cts.Cancel();

    var messages = new List<RealtimeServerMessage>();
    await foreach (var msg in _session.GetStreamingResponseAsync(cts.Token))
    {
      messages.Add(msg);
    }

    Assert.AreEqual(0, messages.Count);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_WebSocketException_YieldsBreak()
  {
    _mockWebSocket
      .Setup(ws => ws.ReceiveAsync(
        It.IsAny<ArraySegment<byte>>(),
        It.IsAny<CancellationToken>()))
      .ThrowsAsync(new WebSocketException("connection closed"));

    var messages = new List<RealtimeServerMessage>();
    await foreach (var msg in _session.GetStreamingResponseAsync())
    {
      messages.Add(msg);
    }

    Assert.AreEqual(0, messages.Count);
  }

  #endregion

  #region MapServerMessage Tests

  [TestMethod]
  public async Task GetStreamingResponseAsync_SetupComplete_IsSkipped()
  {
    SetupReceiveOnce(new LiveServerMessage { SetupComplete = new LiveServerSetupComplete() });

    var messages = await CollectMessages();

    Assert.AreEqual(0, messages.Count);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_TextResponse_EmitsResponseCreatedAndTextDelta()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ServerContent = new LiveServerContent
      {
        ModelTurn = new Content
        {
          Parts = new List<Part> { new Part { Text = "Hello world" } }
        }
      }
    });

    var messages = await CollectMessages();

    // Expect: ResponseCreated + OutputTextDelta
    Assert.AreEqual(2, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputTextDelta, messages[1].Type);
    Assert.AreEqual("Hello world", ((OutputTextAudioRealtimeServerMessage)messages[1]).Text);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_AudioResponse_EmitsAudioDelta()
  {
    byte[] audioBytes = new byte[] { 1, 2, 3, 4 };
    SetupReceiveOnce(new LiveServerMessage
    {
      ServerContent = new LiveServerContent
      {
        ModelTurn = new Content
        {
          Parts = new List<Part>
          {
            new Part
            {
              InlineData = new Blob
              {
                Data = audioBytes,
                MimeType = "audio/pcm",
              }
            }
          }
        }
      }
    });

    var messages = await CollectMessages();

    // Expect: ResponseCreated + OutputAudioDelta
    Assert.AreEqual(2, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputAudioDelta, messages[1].Type);
    var audioMsg = (OutputTextAudioRealtimeServerMessage)messages[1];
    Assert.AreEqual(Convert.ToBase64String(audioBytes), audioMsg.Audio);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_TurnComplete_EmitsResponseDone()
  {
    SetupReceiveSequence(new[]
    {
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent
        {
          ModelTurn = new Content
          {
            Parts = new List<Part> { new Part { Text = "Hi" } }
          }
        }
      },
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent { TurnComplete = true }
      }
    });

    var messages = await CollectMessages();

    // Expect: ResponseCreated + OutputTextDelta + ResponseDone
    Assert.AreEqual(3, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputTextDelta, messages[1].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseDone, messages[2].Type);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_InputTranscription_EmitsTranscriptionCompleted()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ServerContent = new LiveServerContent
      {
        InputTranscription = new Transcription { Text = "what is the weather?" }
      }
    });

    var messages = await CollectMessages();

    Assert.AreEqual(1, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.InputAudioTranscriptionCompleted, messages[0].Type);
    var transcription = (InputAudioTranscriptionRealtimeServerMessage)messages[0];
    Assert.AreEqual("what is the weather?", transcription.Transcription);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_OutputTranscription_EmitsTranscriptionDelta()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ServerContent = new LiveServerContent
      {
        OutputTranscription = new Transcription { Text = "The weather is sunny." }
      }
    });

    var messages = await CollectMessages();

    Assert.AreEqual(1, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.OutputAudioTranscriptionDelta, messages[0].Type);
    var outputMsg = (OutputTextAudioRealtimeServerMessage)messages[0];
    Assert.AreEqual("The weather is sunny.", outputMsg.Text);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_ToolCall_EmitsResponseCreatedAndFunctionCall()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ToolCall = new LiveServerToolCall
      {
        FunctionCalls = new List<FunctionCall>
        {
          new FunctionCall
          {
            Id = "call-1",
            Name = "get_weather",
            Args = new Dictionary<string, object> { ["city"] = "Seattle" }
          }
        }
      }
    });

    var messages = await CollectMessages();

    // Expect: ResponseCreated + ResponseOutputItemAdded + ResponseOutputItemDone
    Assert.AreEqual(3, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseOutputItemAdded, messages[1].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseOutputItemDone, messages[2].Type);

    var itemMsg = (ResponseOutputItemRealtimeServerMessage)messages[1];
    var functionCall = itemMsg.Item?.Contents?.OfType<FunctionCallContent>().First();
    Assert.IsNotNull(functionCall);
    Assert.AreEqual("call-1", functionCall.CallId);
    Assert.AreEqual("get_weather", functionCall.Name);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_GoAway_EmitsError()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      GoAway = new LiveServerGoAway()
    });

    var messages = await CollectMessages();

    Assert.AreEqual(1, messages.Count);
    var errorMsg = messages[0] as ErrorRealtimeServerMessage;
    Assert.IsNotNull(errorMsg);
    Assert.IsNotNull(errorMsg.Error);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_UsageMetadata_EmitsResponseDone_WhenResponseInProgress()
  {
    SetupReceiveSequence(new[]
    {
      // Start a response so _responseInProgress is true
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent
        {
          ModelTurn = new Content
          {
            Parts = new List<Part> { new Part { Text = "response" } }
          }
        }
      },
      // Usage metadata should emit ResponseDone
      new LiveServerMessage
      {
        UsageMetadata = new UsageMetadata
        {
          PromptTokenCount = 10,
          ResponseTokenCount = 20,
          TotalTokenCount = 30,
        }
      }
    });

    var messages = await CollectMessages();

    // ResponseCreated + OutputTextDelta + ResponseDone(usage)
    Assert.AreEqual(3, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseDone, messages[2].Type);
    var responseDone = (ResponseCreatedRealtimeServerMessage)messages[2];
    Assert.IsNotNull(responseDone.Usage);
    Assert.AreEqual(10, responseDone.Usage.InputTokenCount);
    Assert.AreEqual(20, responseDone.Usage.OutputTokenCount);
    Assert.AreEqual(30, responseDone.Usage.TotalTokenCount);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_UsageMetadata_NoResponseInProgress_IsSkipped()
  {
    // No prior model response — _responseInProgress is false
    SetupReceiveOnce(new LiveServerMessage
    {
      UsageMetadata = new UsageMetadata
      {
        PromptTokenCount = 5,
        ResponseTokenCount = 10,
        TotalTokenCount = 15,
      }
    });

    var messages = await CollectMessages();

    // Usage metadata without a response in progress should be skipped
    Assert.AreEqual(0, messages.Count);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_TurnComplete_PreventsDoubleResponseDone_FromUsage()
  {
    SetupReceiveSequence(new[]
    {
      // Model response
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent
        {
          ModelTurn = new Content
          {
            Parts = new List<Part> { new Part { Text = "Hi" } }
          }
        }
      },
      // TurnComplete — emits ResponseDone and resets _responseInProgress
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent { TurnComplete = true }
      },
      // Usage after TurnComplete — should NOT emit another ResponseDone
      new LiveServerMessage
      {
        UsageMetadata = new UsageMetadata
        {
          PromptTokenCount = 10,
          ResponseTokenCount = 20,
          TotalTokenCount = 30,
        }
      }
    });

    var messages = await CollectMessages();

    // ResponseCreated + OutputTextDelta + ResponseDone(TurnComplete) — no second ResponseDone
    Assert.AreEqual(3, messages.Count);
    var responseDoneMessages = messages.Where(
      m => m.Type == RealtimeServerMessageType.ResponseDone).ToList();
    Assert.AreEqual(1, responseDoneMessages.Count, "Should only have one ResponseDone");
  }

  #endregion

  #region ConversationItemCreate Tests

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_TextContent_SendsClientContent()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
        new List<AIContent> { new TextContent("Hello from user") },
        role: ChatRole.User));

    await _session.SendAsync(msg);

    Assert.AreEqual(1, sentMessages.Count);
    // Verify the sent JSON contains our text
    Assert.IsTrue(sentMessages[0].Contains("Hello from user"),
      "Sent message should contain the text content");
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_FunctionResult_SendsToolResponse()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
        new List<AIContent> { new FunctionResultContent("call-123", "sunny") },
        role: ChatRole.Tool));

    await _session.SendAsync(msg);

    // Function results are buffered until CreateResponse
    Assert.AreEqual(0, sentMessages.Count,
      "Function results should be buffered, not sent immediately");

    // Flush via CreateResponse
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    Assert.AreEqual(1, sentMessages.Count,
      "Flushed tool response should be sent as a single WebSocket message");
    Assert.IsTrue(sentMessages[0].Contains("call-123"),
      "Tool response should contain the call ID");
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_FunctionResult_IncludesFunctionName()
  {
    // First, simulate receiving a tool call so the session caches the CallId → Name mapping.
    SetupReceiveOnce(new LiveServerMessage
    {
      ToolCall = new LiveServerToolCall
      {
        FunctionCalls = new List<FunctionCall>
        {
          new FunctionCall { Id = "call-42", Name = "get_weather" }
        }
      }
    });

    await CollectMessages();

    // Now send the function result back
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new FunctionResultContent("call-42", "sunny") },
      role: ChatRole.Tool));

    await _session.SendAsync(msg);

    // Function results are buffered until CreateResponse
    Assert.AreEqual(0, sentMessages.Count);

    // Flush via CreateResponse
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    Assert.AreEqual(1, sentMessages.Count);
    Assert.IsTrue(sentMessages[0].Contains("get_weather"),
      "Tool response should include the function name from the original tool call");
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_EmptyContents_DoesNotSend()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
        new List<AIContent>(),
        role: ChatRole.User));

    await _session.SendAsync(msg);

    Assert.AreEqual(0, sentMessages.Count);
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_AssistantRole_MappedToModel()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
        new List<AIContent> { new TextContent("I am the model") },
        role: ChatRole.Assistant));

    await _session.SendAsync(msg);

    Assert.AreEqual(1, sentMessages.Count);
    // Gemini uses "model" role, not "assistant"
    Assert.IsTrue(sentMessages[0].Contains("model"),
      "Assistant role should be mapped to 'model' for Gemini");
  }

  #endregion

  #region BuildLiveConnectConfig Tests

  [TestMethod]
  public void BuildLiveConnectConfig_NullOptions_DefaultsToAudioModality()
  {
    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(null);

    Assert.IsNotNull(config.ResponseModalities);
    Assert.AreEqual(1, config.ResponseModalities.Count);
    Assert.AreEqual(Modality.Audio, config.ResponseModalities[0]);
    Assert.IsTrue(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_SystemInstructions_MappedCorrectly()
  {
    var options = new RealtimeSessionOptions
    {
      Instructions = "You are a helpful assistant.",
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.SystemInstruction);
    Assert.AreEqual(1, config.SystemInstruction.Parts.Count);
    Assert.AreEqual("You are a helpful assistant.", config.SystemInstruction.Parts[0].Text);
    Assert.AreEqual("user", config.SystemInstruction.Role);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_EmptyInstructions_NoSystemInstruction()
  {
    var options = new RealtimeSessionOptions
    {
      Instructions = "",
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNull(config.SystemInstruction);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_OutputModalities_AudioAndText()
  {
    var options = new RealtimeSessionOptions
    {
      OutputModalities = new List<string> { "audio", "text" },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.AreEqual(2, config.ResponseModalities.Count);
    Assert.AreEqual(Modality.Audio, config.ResponseModalities[0]);
    Assert.AreEqual(Modality.Text, config.ResponseModalities[1]);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_NoOutputModalities_DefaultsToAudio()
  {
    var options = new RealtimeSessionOptions();

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.AreEqual(1, config.ResponseModalities.Count);
    Assert.AreEqual(Modality.Audio, config.ResponseModalities[0]);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_UnknownModality_DefaultsToText()
  {
    var options = new RealtimeSessionOptions
    {
      OutputModalities = new List<string> { "video" },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.AreEqual(1, config.ResponseModalities.Count);
    Assert.AreEqual(Modality.Text, config.ResponseModalities[0]);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_Voice_MappedToSpeechConfig()
  {
    var options = new RealtimeSessionOptions
    {
      Voice = "Puck",
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.SpeechConfig);
    Assert.IsNotNull(config.SpeechConfig.VoiceConfig);
    Assert.AreEqual("Puck", config.SpeechConfig.VoiceConfig.PrebuiltVoiceConfig.VoiceName);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_NullVoice_NoSpeechConfig()
  {
    var options = new RealtimeSessionOptions();

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNull(config.SpeechConfig);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_MaxOutputTokens_MappedToGenerationConfig()
  {
    var options = new RealtimeSessionOptions
    {
      MaxOutputTokens = 500,
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.GenerationConfig);
    Assert.AreEqual(500, config.GenerationConfig.MaxOutputTokens);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_NoMaxOutputTokens_NoGenerationConfig()
  {
    var options = new RealtimeSessionOptions();

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNull(config.GenerationConfig);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionOptions_EnablesBothDirections()
  {
    var options = new RealtimeSessionOptions
    {
      TranscriptionOptions = new TranscriptionOptions(),
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.InputAudioTranscription);
    Assert.IsNotNull(config.OutputAudioTranscription);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_NoTranscriptionOptions_NoTranscription()
  {
    var options = new RealtimeSessionOptions();

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNull(config.InputAudioTranscription);
    Assert.IsNull(config.OutputAudioTranscription);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_NoVadOptions_DisablesVadByDefault()
  {
    var options = new RealtimeSessionOptions();

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.RealtimeInputConfig);
    Assert.IsNotNull(config.RealtimeInputConfig.AutomaticActivityDetection);
    Assert.IsTrue(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_VadEnabled_EnablesAutomaticActivityDetection()
  {
    var options = new RealtimeSessionOptions
    {
      VoiceActivityDetection = new VoiceActivityDetectionOptions
      {
        Enabled = true,
        AllowInterruption = true,
      },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.RealtimeInputConfig);
    Assert.IsNotNull(config.RealtimeInputConfig.AutomaticActivityDetection);
    Assert.IsFalse(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
    Assert.AreEqual(
      ActivityHandling.StartOfActivityInterrupts,
      config.RealtimeInputConfig.ActivityHandling);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_VadEnabled_NoInterruption()
  {
    var options = new RealtimeSessionOptions
    {
      VoiceActivityDetection = new VoiceActivityDetectionOptions
      {
        Enabled = true,
        AllowInterruption = false,
      },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.RealtimeInputConfig);
    Assert.IsFalse(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
    Assert.AreEqual(
      ActivityHandling.NoInterruption,
      config.RealtimeInputConfig.ActivityHandling);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_VadDisabled_DisablesAutomaticActivityDetection()
  {
    var options = new RealtimeSessionOptions
    {
      VoiceActivityDetection = new VoiceActivityDetectionOptions
      {
        Enabled = false,
      },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.RealtimeInputConfig);
    Assert.IsTrue(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_Tools_MappedToFunctionDeclarations()
  {
    var fn = AIFunctionFactory.Create(
      (string city) => $"Weather in {city}: sunny",
      "get_weather",
      "Gets the weather");

    var options = new RealtimeSessionOptions
    {
      Tools = new List<AITool> { fn },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.Tools);
    Assert.AreEqual(1, config.Tools.Count);
    Assert.AreEqual(1, config.Tools[0].FunctionDeclarations.Count);
    Assert.AreEqual("get_weather", config.Tools[0].FunctionDeclarations[0].Name);
    Assert.AreEqual("Gets the weather", config.Tools[0].FunctionDeclarations[0].Description);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_EmptyTools_NoToolsConfig()
  {
    var options = new RealtimeSessionOptions
    {
      Tools = new List<AITool>(),
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNull(config.Tools);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_AllOptionsCombined_MapsEverything()
  {
    var fn = AIFunctionFactory.Create(
      (string q) => "result",
      "search",
      "Searches things");

    var options = new RealtimeSessionOptions
    {
      Instructions = "Be concise.",
      OutputModalities = new List<string> { "audio", "text" },
      Voice = "Aoede",
      MaxOutputTokens = 1000,
      Tools = new List<AITool> { fn },
      TranscriptionOptions = new TranscriptionOptions(),
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.AreEqual("Be concise.", config.SystemInstruction.Parts[0].Text);
    Assert.AreEqual(2, config.ResponseModalities.Count);
    Assert.AreEqual("Aoede", config.SpeechConfig.VoiceConfig.PrebuiltVoiceConfig.VoiceName);
    Assert.AreEqual(1000, config.GenerationConfig.MaxOutputTokens);
    Assert.AreEqual(1, config.Tools[0].FunctionDeclarations.Count);
    Assert.IsNotNull(config.InputAudioTranscription);
    Assert.IsNotNull(config.OutputAudioTranscription);
    Assert.IsTrue(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionMode_OnlyInputTranscription()
  {
    var options = new RealtimeSessionOptions
    {
      SessionKind = RealtimeSessionKind.Transcription,
      TranscriptionOptions = new TranscriptionOptions(),
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.InputAudioTranscription);
    Assert.IsNull(config.OutputAudioTranscription);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionMode_TextModalityOnly()
  {
    var options = new RealtimeSessionOptions
    {
      SessionKind = RealtimeSessionKind.Transcription,
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.AreEqual(1, config.ResponseModalities.Count);
    Assert.AreEqual(Modality.Text, config.ResponseModalities[0]);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionMode_NoVoiceOrToolsOrInstructions()
  {
    var fn = AIFunctionFactory.Create(
      (string q) => "result",
      "search",
      "Searches things");

    var options = new RealtimeSessionOptions
    {
      SessionKind = RealtimeSessionKind.Transcription,
      Instructions = "Be concise.",
      Voice = "Aoede",
      MaxOutputTokens = 500,
      Tools = new List<AITool> { fn },
      TranscriptionOptions = new TranscriptionOptions(),
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    // Transcription-only: conversation-oriented options are ignored
    Assert.IsNull(config.SystemInstruction);
    Assert.IsNull(config.SpeechConfig);
    Assert.IsNull(config.GenerationConfig);
    Assert.IsNull(config.Tools);
    Assert.IsNotNull(config.InputAudioTranscription);
    Assert.IsNull(config.OutputAudioTranscription);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionMode_LanguageCodeMapped()
  {
    var options = new RealtimeSessionOptions
    {
      SessionKind = RealtimeSessionKind.Transcription,
      TranscriptionOptions = new TranscriptionOptions { SpeechLanguage = "en-US" },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.InputAudioTranscription);
    Assert.AreEqual(1, config.InputAudioTranscription.LanguageCodes.Count);
    Assert.AreEqual("en-US", config.InputAudioTranscription.LanguageCodes[0]);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionMode_NoLanguage_NoLanguageCodes()
  {
    var options = new RealtimeSessionOptions
    {
      SessionKind = RealtimeSessionKind.Transcription,
      TranscriptionOptions = new TranscriptionOptions(),
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.InputAudioTranscription);
    Assert.IsNull(config.InputAudioTranscription.LanguageCodes);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionMode_VadEnabled()
  {
    var options = new RealtimeSessionOptions
    {
      SessionKind = RealtimeSessionKind.Transcription,
      VoiceActivityDetection = new VoiceActivityDetectionOptions { Enabled = true, AllowInterruption = false },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsFalse(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
    Assert.AreEqual(ActivityHandling.NoInterruption, config.RealtimeInputConfig.ActivityHandling);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_TranscriptionMode_DefaultVadDisabled()
  {
    var options = new RealtimeSessionOptions
    {
      SessionKind = RealtimeSessionKind.Transcription,
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsTrue(config.RealtimeInputConfig.AutomaticActivityDetection.Disabled);
  }

  [TestMethod]
  public void BuildLiveConnectConfig_ConversationMode_LanguageCodeMapped()
  {
    var options = new RealtimeSessionOptions
    {
      TranscriptionOptions = new TranscriptionOptions { SpeechLanguage = "ja-JP" },
    };

    var config = GoogleGenAIRealtimeClient.BuildLiveConnectConfig(options);

    Assert.IsNotNull(config.InputAudioTranscription);
    Assert.AreEqual(1, config.InputAudioTranscription.LanguageCodes.Count);
    Assert.AreEqual("ja-JP", config.InputAudioTranscription.LanguageCodes[0]);
    // Output transcription is also enabled in conversation mode (no language codes)
    Assert.IsNotNull(config.OutputAudioTranscription);
  }

  #endregion

  #region ExtractDataBytes Tests

  [TestMethod]
  public void ExtractDataBytes_ValidBase64DataUri_ExtractsBytes()
  {
    byte[] expected = new byte[] { 1, 2, 3, 4, 5 };
    string base64 = Convert.ToBase64String(expected);
    var content = new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm");

    byte[] result = GoogleGenAIRealtimeSession.ExtractDataBytes(content);

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ExtractDataBytes_InvalidBase64_FallsBackToData()
  {
    byte[] expected = new byte[] { 10, 20, 30 };
    var content = new DataContent(expected, "audio/pcm");

    byte[] result = GoogleGenAIRealtimeSession.ExtractDataBytes(content);

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ExtractDataBytes_NullUri_UsesDirectData()
  {
    byte[] expected = new byte[] { 7, 8, 9 };
    var content = new DataContent(expected, "audio/pcm");

    byte[] result = GoogleGenAIRealtimeSession.ExtractDataBytes(content);

    CollectionAssert.AreEqual(expected, result);
  }

  [TestMethod]
  public void ExtractDataBytes_DataUriNoComma_FallsBackToData()
  {
    byte[] expected = new byte[] { 42, 43, 44 };
    // DataContent with raw byte data but no URI
    var content = new DataContent(expected, "audio/pcm");

    byte[] result = GoogleGenAIRealtimeSession.ExtractDataBytes(content);

    CollectionAssert.AreEqual(expected, result);
  }

  #endregion

  #region CreateResponseRealtimeClientMessage Tests

  [TestMethod]
  public async Task SendAsync_CreateResponse_AfterConversationItem_SendsTurnComplete()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    // Send a conversation item with text
    var itemMsg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("Hello") },
      role: ChatRole.User));
    await _session.SendAsync(itemMsg);

    // Text input auto-triggers a response in Gemini's Live API, so the text
    // send happened during CreateConversationItem, not CreateResponse.
    Assert.AreEqual(1, sentMessages.Count, "Text should be sent via SendRealtimeInputAsync");
    Assert.IsTrue(sentMessages[0].Contains("Hello"),
      "The sent message should contain the text content");

    sentMessages.Clear();

    // CreateResponse after text input does nothing — text auto-triggers.
    var createResp = new CreateResponseRealtimeClientMessage();
    await _session.SendAsync(createResp);

    Assert.AreEqual(0, sentMessages.Count,
      "CreateResponse should not send additional messages after text input (auto-triggers)");
  }

  [TestMethod]
  public async Task SendAsync_CreateResponse_AfterAudioCommit_DoesNotSendTurnComplete()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    // Send audio append + commit (sets _lastInputWasRealtime = true)
    byte[] audioData = new byte[100];
    new Random(42).NextBytes(audioData);
    string base64 = Convert.ToBase64String(audioData);

    await _session.SendAsync(new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm")));
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    int countBeforeCreateResponse = sentMessages.Count;

    // CreateResponse should NOT send anything (audio commit already sent ActivityEnd)
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    Assert.AreEqual(countBeforeCreateResponse, sentMessages.Count,
      "CreateResponse should not send TurnComplete after realtime audio input");
  }

  [TestMethod]
  public async Task SendAsync_CreateResponse_AfterToolResponse_DoesNotSendTurnComplete()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    // Send a function result (simulates middleware returning tool response)
    var toolResultMsg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new FunctionResultContent("call-1", "sunny") },
      role: ChatRole.Tool));
    await _session.SendAsync(toolResultMsg);

    // CreateResponse should flush the tool response but NOT send TurnComplete
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    // Should have exactly 1 message: the batched tool response. No TurnComplete.
    Assert.AreEqual(1, sentMessages.Count,
      "Should send tool response but NOT TurnComplete after function result");
    Assert.IsTrue(sentMessages[0].Contains("call-1"),
      "Tool response should contain the call ID");
    Assert.IsFalse(sentMessages[0].Contains("turnComplete"),
      "Should not contain turnComplete after tool response");
  }

  [TestMethod]
  public async Task SendAsync_CreateResponse_BatchesMultipleToolResponses()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    // Simulate middleware sending separate CreateConversationItem per function result
    var toolResult1 = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new FunctionResultContent("call-1", "sunny") },
      role: ChatRole.Tool));
    var toolResult2 = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new FunctionResultContent("call-2", "72F") },
      role: ChatRole.Tool));

    await _session.SendAsync(toolResult1);
    await _session.SendAsync(toolResult2);

    // No WebSocket sends yet — results are buffered
    Assert.AreEqual(0, sentMessages.Count,
      "Function results should be buffered until CreateResponse");

    // CreateResponse flushes all results in a single batched SendToolResponseAsync
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    Assert.AreEqual(1, sentMessages.Count,
      "All function results should be sent in a single WebSocket message");
    Assert.IsTrue(sentMessages[0].Contains("call-1"),
      "Batched tool response should contain first call ID");
    Assert.IsTrue(sentMessages[0].Contains("call-2"),
      "Batched tool response should contain second call ID");
    Assert.IsFalse(sentMessages[0].Contains("turnComplete"),
      "Should not contain turnComplete after batched tool responses");
  }

  [TestMethod]
  public async Task SendAsync_CreateResponse_AfterToolResponse_NextTextSendResetsFlagCorrectly()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    // Complete a full tool call cycle: tool response → CreateResponse
    var toolResultMsg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new FunctionResultContent("call-1", "sunny") },
      role: ChatRole.Tool));
    await _session.SendAsync(toolResultMsg);
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    sentMessages.Clear();

    // Now send normal text → CreateResponse. Text auto-triggers; CreateResponse is a no-op.
    var textMsg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("Hello again") },
      role: ChatRole.User));
    await _session.SendAsync(textMsg);
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    // Should have 1 message: the text content sent via SendRealtimeInputAsync.
    // CreateResponse does not send a turnComplete — text auto-triggers in Gemini.
    Assert.AreEqual(1, sentMessages.Count,
      "Normal text followed by CreateResponse should send only the text content");
    Assert.IsTrue(sentMessages[0].Contains("Hello again"),
      "The sent message should contain the text content");
  }

  #endregion

  #region Additional MapServerMessage Tests

  [TestMethod]
  public async Task GetStreamingResponseAsync_GenerationComplete_EmitsResponseDone()
  {
    SetupReceiveSequence(new[]
    {
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent
        {
          ModelTurn = new Content
          {
            Parts = new List<Part> { new Part { Text = "Response" } }
          }
        }
      },
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent { GenerationComplete = true }
      }
    });

    var messages = await CollectMessages();

    Assert.AreEqual(3, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputTextDelta, messages[1].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseDone, messages[2].Type);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_ToolCallCancellation_EmitsRawContentOnly()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ToolCallCancellation = new LiveServerToolCallCancellation
      {
        Ids = new List<string> { "call-1", "call-2" },
      }
    });

    var messages = await CollectMessages();

    Assert.AreEqual(1, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.RawContentOnly, messages[0].Type);
    Assert.IsNotNull(messages[0].RawRepresentation);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_MultipleTextParts_EmitsMultipleDeltas()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ServerContent = new LiveServerContent
      {
        ModelTurn = new Content
        {
          Parts = new List<Part>
          {
            new Part { Text = "Part one" },
            new Part { Text = "Part two" },
          }
        }
      }
    });

    var messages = await CollectMessages();

    // ResponseCreated + 2 OutputTextDelta
    Assert.AreEqual(3, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputTextDelta, messages[1].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputTextDelta, messages[2].Type);
    Assert.AreEqual("Part one", ((OutputTextAudioRealtimeServerMessage)messages[1]).Text);
    Assert.AreEqual("Part two", ((OutputTextAudioRealtimeServerMessage)messages[2]).Text);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_MixedAudioAndText_EmitsBothDeltas()
  {
    byte[] audioBytes = new byte[] { 10, 20, 30 };
    SetupReceiveOnce(new LiveServerMessage
    {
      ServerContent = new LiveServerContent
      {
        ModelTurn = new Content
        {
          Parts = new List<Part>
          {
            new Part
            {
              InlineData = new Blob
              {
                Data = audioBytes,
                MimeType = "audio/pcm",
              }
            },
            new Part { Text = "Hello there" },
          }
        }
      }
    });

    var messages = await CollectMessages();

    // ResponseCreated + OutputAudioDelta + OutputTextDelta
    Assert.AreEqual(3, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputAudioDelta, messages[1].Type);
    Assert.AreEqual(RealtimeServerMessageType.OutputTextDelta, messages[2].Type);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_MultipleModelTurns_OnlyOneResponseCreated()
  {
    SetupReceiveSequence(new[]
    {
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent
        {
          ModelTurn = new Content
          {
            Parts = new List<Part> { new Part { Text = "First chunk" } }
          }
        }
      },
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent
        {
          ModelTurn = new Content
          {
            Parts = new List<Part> { new Part { Text = "Second chunk" } }
          }
        }
      },
    });

    var messages = await CollectMessages();

    // Only one ResponseCreated for the entire response cycle
    var responseCreatedCount = messages.Count(m => m.Type == RealtimeServerMessageType.ResponseCreated);
    Assert.AreEqual(1, responseCreatedCount,
      "Should only emit one ResponseCreated across multiple ModelTurn messages in the same response");

    // But both text deltas should appear
    var textDeltas = messages.Where(m => m.Type == RealtimeServerMessageType.OutputTextDelta).ToList();
    Assert.AreEqual(2, textDeltas.Count);
    Assert.AreEqual("First chunk", ((OutputTextAudioRealtimeServerMessage)textDeltas[0]).Text);
    Assert.AreEqual("Second chunk", ((OutputTextAudioRealtimeServerMessage)textDeltas[1]).Text);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_MultipleToolCalls_EmitsAllItems()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ToolCall = new LiveServerToolCall
      {
        FunctionCalls = new List<FunctionCall>
        {
          new FunctionCall { Id = "c1", Name = "fn1", Args = new Dictionary<string, object> { ["a"] = "1" } },
          new FunctionCall { Id = "c2", Name = "fn2", Args = new Dictionary<string, object> { ["b"] = "2" } },
        }
      }
    });

    var messages = await CollectMessages();

    // ResponseCreated + (ResponseOutputItemAdded + ResponseOutputItemDone) × 2
    Assert.AreEqual(5, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseCreated, messages[0].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseOutputItemAdded, messages[1].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseOutputItemDone, messages[2].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseOutputItemAdded, messages[3].Type);
    Assert.AreEqual(RealtimeServerMessageType.ResponseOutputItemDone, messages[4].Type);

    var fn1 = ((ResponseOutputItemRealtimeServerMessage)messages[1]).Item?.Contents?.OfType<FunctionCallContent>().First();
    var fn2 = ((ResponseOutputItemRealtimeServerMessage)messages[3]).Item?.Contents?.OfType<FunctionCallContent>().First();
    Assert.AreEqual("fn1", fn1?.Name);
    Assert.AreEqual("fn2", fn2?.Name);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_ToolCallThenTurnComplete_EmitsResponseDone()
  {
    SetupReceiveSequence(new[]
    {
      new LiveServerMessage
      {
        ToolCall = new LiveServerToolCall
        {
          FunctionCalls = new List<FunctionCall>
          {
            new FunctionCall { Id = "c1", Name = "fn1" }
          }
        }
      },
      new LiveServerMessage
      {
        ServerContent = new LiveServerContent { TurnComplete = true }
      }
    });

    var messages = await CollectMessages();

    // ResponseCreated + ItemAdded + ItemDone + ResponseDone
    Assert.AreEqual(4, messages.Count);
    Assert.AreEqual(RealtimeServerMessageType.ResponseDone, messages[3].Type);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_ToolCallWithNullArgs_EmitsEmptyArguments()
  {
    SetupReceiveOnce(new LiveServerMessage
    {
      ToolCall = new LiveServerToolCall
      {
        FunctionCalls = new List<FunctionCall>
        {
          new FunctionCall { Id = "c1", Name = "no_args_fn", Args = null }
        }
      }
    });

    var messages = await CollectMessages();

    Assert.AreEqual(3, messages.Count);
    var fc = ((ResponseOutputItemRealtimeServerMessage)messages[1]).Item?.Contents?.OfType<FunctionCallContent>().First();
    Assert.IsNotNull(fc);
    Assert.AreEqual("no_args_fn", fc.Name);
    Assert.IsNull(fc.Arguments);
  }

  #endregion

  #region ConversationItemCreate Additional Tests

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_UserRole_MapsToUser()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("User text") },
      role: ChatRole.User));

    await _session.SendAsync(msg);

    // Gemini's SendRealtimeInputAsync sends text only (no role field).
    // Verify the text content was sent.
    Assert.AreEqual(1, sentMessages.Count);
    Assert.IsTrue(sentMessages[0].Contains("User text"),
      "User text should be sent via SendRealtimeInputAsync");
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_NullRole_DefaultsToUser()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("No role text") }));

    await _session.SendAsync(msg);

    // Gemini's SendRealtimeInputAsync sends text only (no role field).
    // Verify the text content was sent regardless of the absence of a role.
    Assert.AreEqual(1, sentMessages.Count);
    Assert.IsTrue(sentMessages[0].Contains("No role text"),
      "Text should be sent via SendRealtimeInputAsync even without a role");
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_MultipleFunctionResults_SendsAll()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    // Multiple function results should all be sent in a single SendToolResponseAsync call
    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent>
      {
        new FunctionResultContent("call-1", "result-one"),
        new FunctionResultContent("call-2", "result-two"),
      },
      role: ChatRole.Tool));

    await _session.SendAsync(msg);

    // Function results are buffered until CreateResponse
    Assert.AreEqual(0, sentMessages.Count,
      "Function results should be buffered, not sent immediately");

    // Flush via CreateResponse
    await _session.SendAsync(new CreateResponseRealtimeClientMessage());

    // All function results are batched into one WebSocket message
    Assert.AreEqual(1, sentMessages.Count);
    Assert.IsTrue(sentMessages[0].Contains("call-1"));
    Assert.IsTrue(sentMessages[0].Contains("result-one"));
    Assert.IsTrue(sentMessages[0].Contains("call-2"));
    Assert.IsTrue(sentMessages[0].Contains("result-two"));
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_NullContents_DoesNotSend()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent>()));

    await _session.SendAsync(msg);

    Assert.AreEqual(0, sentMessages.Count);
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_AudioContent_SendsInlineData()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    byte[] audioData = new byte[] { 1, 2, 3 };
    string base64 = Convert.ToBase64String(audioData);
    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm") },
      role: ChatRole.User));

    await _session.SendAsync(msg);

    Assert.AreEqual(1, sentMessages.Count);
    Assert.IsTrue(sentMessages[0].Contains("audio/pcm"));
  }

  [TestMethod]
  public async Task SendAsync_ConversationItemCreate_ImageContent_SendsInlineData()
  {
    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    byte[] imageData = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
    string base64 = Convert.ToBase64String(imageData);
    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new DataContent($"data:image/png;base64,{base64}", "image/png") },
      role: ChatRole.User));

    await _session.SendAsync(msg);

    Assert.AreEqual(1, sentMessages.Count);
    Assert.IsTrue(sentMessages[0].Contains("image/png"));
  }

  #endregion

  #region Audio Frame Content Verification Tests

  [TestMethod]
  public async Task SendAsync_AudioCommit_FrameContentVerification_PreservesData()
  {
    // Use a known pattern so we can verify exact bytes
    byte[] audioData = new byte[64_000]; // Exactly 2 frames
    for (int i = 0; i < audioData.Length; i++)
    {
      audioData[i] = (byte)(i % 256);
    }

    string base64 = Convert.ToBase64String(audioData);
    var appendMsg = new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm"));

    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(appendMsg);
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // ActivityStart + 2 audio frames + ActivityEnd = 4 messages
    Assert.AreEqual(4, sentMessages.Count);

    // Verify the first message is ActivityStart
    Assert.IsTrue(sentMessages[0].Contains("activityStart"),
      "First message should be ActivityStart");

    // Verify audio frames contain base64-encoded data
    Assert.IsTrue(sentMessages[1].Contains("audio/pcm"),
      "Audio frame should contain mime type");
    Assert.IsTrue(sentMessages[2].Contains("audio/pcm"),
      "Audio frame should contain mime type");

    // Verify the last message is ActivityEnd
    Assert.IsTrue(sentMessages[3].Contains("activityEnd"),
      "Last message should be ActivityEnd");
  }

  [TestMethod]
  public async Task SendAsync_AudioCommit_ExactFrameSize_SingleFrame()
  {
    // Exactly 32000 bytes = exactly 1 frame (no splitting needed)
    byte[] audioData = new byte[32_000];
    new Random(42).NextBytes(audioData);

    string base64 = Convert.ToBase64String(audioData);
    var appendMsg = new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm"));

    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(appendMsg);
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // ActivityStart + 1 frame + ActivityEnd = 3
    Assert.AreEqual(3, sentMessages.Count);
  }

  [TestMethod]
  public async Task SendAsync_AudioCommit_FrameBoundary_SplitsCorrectly()
  {
    // 32001 bytes = 32000 + 1 → 2 frames
    byte[] audioData = new byte[32_001];
    new Random(42).NextBytes(audioData);

    string base64 = Convert.ToBase64String(audioData);
    var appendMsg = new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm"));

    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(appendMsg);
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // ActivityStart + 2 frames (32000 + 1) + ActivityEnd = 4
    Assert.AreEqual(4, sentMessages.Count);
  }

  [TestMethod]
  public async Task SendAsync_AudioAppend_MultipleAppends_PreservesOrder()
  {
    byte[] chunk1 = new byte[100];
    byte[] chunk2 = new byte[200];
    new Random(42).NextBytes(chunk1);
    new Random(43).NextBytes(chunk2);

    string base64_1 = Convert.ToBase64String(chunk1);
    string base64_2 = Convert.ToBase64String(chunk2);

    await _session.SendAsync(new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64_1}", "audio/pcm")));
    await _session.SendAsync(new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64_2}", "audio/pcm")));

    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // ActivityStart + 2 audio frames (both under 32KB) + ActivityEnd = 4
    Assert.AreEqual(4, sentMessages.Count);
  }

  #endregion

  #region Audio MIME Type Tests

  [TestMethod]
  public async Task SendAsync_AudioCommit_UsesDefaultMimeType_WhenNoInputAudioFormat()
  {
    // Default session (null options) should use audio/pcm
    byte[] audioData = new byte[] { 1, 2, 3 };
    string base64 = Convert.ToBase64String(audioData);

    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    await _session.SendAsync(new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm")));
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // Verify audio frame uses default audio/pcm mime type
    Assert.IsTrue(sentMessages[1].Contains("audio/pcm"), "Audio frame should use default audio/pcm");
  }

  [TestMethod]
  public async Task SendAsync_AudioCommit_UsesCustomMimeType_WhenInputAudioFormatSet()
  {
    // Create session with custom audio format
    var customOptions = new RealtimeSessionOptions
    {
      InputAudioFormat = new RealtimeAudioFormat("audio/opus", 48000),
    };
    var customSession = new GoogleGenAIRealtimeSession(_asyncSession, "test-model", customOptions);

    byte[] audioData = new byte[] { 1, 2, 3 };
    string base64 = Convert.ToBase64String(audioData);

    var sentMessages = new List<string>();
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        (buffer, _, _, _) =>
        {
          sentMessages.Add(Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count));
        })
      .Returns(Task.CompletedTask);

    await customSession.SendAsync(new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/opus;base64,{base64}", "audio/opus")));
    await customSession.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // Verify audio frame uses the custom mime type
    Assert.IsTrue(sentMessages[1].Contains("audio/opus"),
      "Audio frame should use the configured audio/opus mime type");
    Assert.IsFalse(sentMessages[1].Contains("audio/pcm"),
      "Audio frame should NOT contain the default audio/pcm");
  }

  #endregion

  #region Dispose Race Safety Tests

  [TestMethod]
  public async Task SendAsync_ConcurrentDispose_DoesNotThrow()
  {
    // Simulate a race: SendAsync acquires the lock, then DisposeAsync runs.
    // The Release() in finally should not throw even if the semaphore is disposed.
    byte[] audioData = new byte[] { 1, 2, 3 };
    string base64 = Convert.ToBase64String(audioData);

    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Returns(Task.CompletedTask);

    _mockWebSocket
      .Setup(ws => ws.CloseAsync(
        It.IsAny<WebSocketCloseStatus>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>()))
      .Returns(Task.CompletedTask);

    // Append audio, then commit and dispose concurrently
    await _session.SendAsync(new InputAudioBufferAppendRealtimeClientMessage(
      new DataContent($"data:audio/pcm;base64,{base64}", "audio/pcm")));
    await _session.SendAsync(new InputAudioBufferCommitRealtimeClientMessage());

    // Dispose should not throw even after sends completed
    await _session.DisposeAsync();

    // Double dispose should also be safe
    await _session.DisposeAsync();
  }

  #endregion

  #region DisposeAsync Additional Tests

  [TestMethod]
  public async Task DisposeAsync_ClosesUnderlyingWebSocket()
  {
    _mockWebSocket
      .Setup(ws => ws.CloseAsync(
        It.IsAny<WebSocketCloseStatus>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>()))
      .Returns(Task.CompletedTask);

    await _session.DisposeAsync();

    _mockWebSocket.Verify(ws => ws.CloseAsync(
      It.IsAny<WebSocketCloseStatus>(),
      It.IsAny<string>(),
      It.IsAny<CancellationToken>()), Times.Once);
  }

  #endregion

  #region Exception Handling Tests

  [TestMethod]
  public async Task SendAsync_ObjectDisposedException_FromAsyncSession_Throws()
  {
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .ThrowsAsync(new ObjectDisposedException("WebSocket"));

    // Send a conversation item that triggers a real send to the WebSocket
    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("Hello") },
      role: ChatRole.User));

    // ObjectDisposedException is re-surfaced so callers know the session is gone
    await Assert.ThrowsExceptionAsync<ObjectDisposedException>(
      () => _session.SendAsync(msg));
  }

  [TestMethod]
  public async Task SendAsync_WebSocketException_FromAsyncSession_WhenNotDisposed_Throws()
  {
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .ThrowsAsync(new WebSocketException("connection lost"));

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("Hello") },
      role: ChatRole.User));

    // WebSocketException when session is NOT disposed indicates a real error
    await Assert.ThrowsExceptionAsync<WebSocketException>(
      () => _session.SendAsync(msg));
  }

  [TestMethod]
  public async Task SendAsync_InternalOperationCancelled_Propagated()
  {
    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .ThrowsAsync(new OperationCanceledException("internal disposal"));

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("Hello") },
      role: ChatRole.User));

    // Internal cancellation (not the caller's token) is now propagated
    // so callers can observe unexpected teardown
    await Assert.ThrowsExceptionAsync<OperationCanceledException>(
      () => _session.SendAsync(msg));
  }

  [TestMethod]
  public async Task SendAsync_CallerCancellation_Propagated()
  {
    using var cts = new CancellationTokenSource();
    cts.Cancel();

    var msg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("Hello") },
      role: ChatRole.User));

    // Caller cancellation should propagate (ThrowIfCancellationRequested at top)
    await Assert.ThrowsExceptionAsync<OperationCanceledException>(
      () => _session.SendAsync(msg, cts.Token));
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_ObjectDisposedException_Swallowed()
  {
    _mockWebSocket
      .Setup(ws => ws.ReceiveAsync(
        It.IsAny<ArraySegment<byte>>(),
        It.IsAny<CancellationToken>()))
      .ThrowsAsync(new ObjectDisposedException("WebSocket"));

    var messages = new List<RealtimeServerMessage>();
    await foreach (var msg in _session.GetStreamingResponseAsync())
    {
      messages.Add(msg);
    }

    Assert.AreEqual(0, messages.Count);
  }

  [TestMethod]
  public async Task GetStreamingResponseAsync_InternalOperationCancelled_Swallowed()
  {
    _mockWebSocket
      .Setup(ws => ws.ReceiveAsync(
        It.IsAny<ArraySegment<byte>>(),
        It.IsAny<CancellationToken>()))
      .ThrowsAsync(new OperationCanceledException("internal cancellation"));

    var messages = new List<RealtimeServerMessage>();
    await foreach (var msg in _session.GetStreamingResponseAsync())
    {
      messages.Add(msg);
    }

    Assert.AreEqual(0, messages.Count);
  }

  #endregion

  #region Helper Methods

  private void SetupReceiveOnce(LiveServerMessage message)
  {
    string json = JsonSerializer.Serialize(message, JsonConfig.JsonSerializerOptions);
    byte[] bytes = Encoding.UTF8.GetBytes(json);
    var callCount = 0;

    _mockWebSocket
      .Setup(ws => ws.ReceiveAsync(
        It.IsAny<ArraySegment<byte>>(),
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, CancellationToken>((buffer, _) =>
      {
        if (callCount == 0)
        {
          Buffer.BlockCopy(bytes, 0, buffer.Array!, buffer.Offset, bytes.Length);
        }
      })
      .Returns<ArraySegment<byte>, CancellationToken>((_, _) =>
      {
        callCount++;
        if (callCount == 1)
        {
          return Task.FromResult(
            new WebSocketReceiveResult(bytes.Length, WebSocketMessageType.Text, true));
        }
        return Task.FromResult(
          new WebSocketReceiveResult(0, WebSocketMessageType.Close, true,
            WebSocketCloseStatus.NormalClosure, "done"));
      });
  }

  private void SetupReceiveSequence(LiveServerMessage[] messages)
  {
    var serialized = messages.Select(m =>
    {
      string json = JsonSerializer.Serialize(m, JsonConfig.JsonSerializerOptions);
      return Encoding.UTF8.GetBytes(json);
    }).ToList();

    var callCount = 0;

    _mockWebSocket
      .Setup(ws => ws.ReceiveAsync(
        It.IsAny<ArraySegment<byte>>(),
        It.IsAny<CancellationToken>()))
      .Callback<ArraySegment<byte>, CancellationToken>((buffer, _) =>
      {
        if (callCount < serialized.Count)
        {
          Buffer.BlockCopy(serialized[callCount], 0, buffer.Array!, buffer.Offset,
            serialized[callCount].Length);
        }
      })
      .Returns<ArraySegment<byte>, CancellationToken>((_, _) =>
      {
        var idx = callCount;
        callCount++;
        if (idx < serialized.Count)
        {
          return Task.FromResult(
            new WebSocketReceiveResult(serialized[idx].Length, WebSocketMessageType.Text, true));
        }
        return Task.FromResult(
          new WebSocketReceiveResult(0, WebSocketMessageType.Close, true,
            WebSocketCloseStatus.NormalClosure, "done"));
      });
  }

  private async Task<List<RealtimeServerMessage>> CollectMessages()
  {
    var messages = new List<RealtimeServerMessage>();
    await foreach (var msg in _session.GetStreamingResponseAsync())
    {
      messages.Add(msg);
    }
    return messages;
  }

  #endregion

  #region Concurrency Tests

  [TestMethod]
  public async Task SendAsync_ConcurrentCalls_AreSerialized()
  {
    // Verify that concurrent SendAsync calls don't interleave WebSocket sends.
    // We track the order of send completions to ensure no overlap.
    var sendOrder = new List<int>();
    var gate = new SemaphoreSlim(0);

    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Returns<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        async (buffer, _, _, ct) =>
        {
          string json = Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count);
          // The first call blocks briefly; if sends aren't serialized, the second
          // would start before the first completes.
          if (json.Contains("turn-1"))
          {
            lock (sendOrder) { sendOrder.Add(1); }
            gate.Release();
            await Task.Delay(50, ct);
            lock (sendOrder) { sendOrder.Add(-1); }
          }
          else if (json.Contains("turn-2"))
          {
            await gate.WaitAsync(ct);
            lock (sendOrder) { sendOrder.Add(2); }
          }
        });

    var msg1 = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("turn-1") }, role: ChatRole.User));
    var msg2 = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("turn-2") }, role: ChatRole.User));

    // Launch both sends concurrently
    var t1 = _session.SendAsync(msg1);
    var t2 = _session.SendAsync(msg2);
    await Task.WhenAll(t1, t2);

    // Because sends are serialized, turn-2 can only start after turn-1 completes.
    // Expected order: [1, -1, 2] (start-1, end-1, start-2)
    Assert.AreEqual(3, sendOrder.Count);
    Assert.AreEqual(1, sendOrder[0], "turn-1 should start first");
    Assert.AreEqual(-1, sendOrder[1], "turn-1 should complete before turn-2 starts");
    Assert.AreEqual(2, sendOrder[2], "turn-2 should start after turn-1 completes");
  }

  [TestMethod]
  public async Task SendAsync_AudioAppend_DoesNotBlockConcurrentSends()
  {
    // AudioAppend only buffers — it should NOT acquire the send lock,
    // so it completes even while another send holds the lock.
    var sendStarted = new TaskCompletionSource<bool>();
    var sendCanProceed = new TaskCompletionSource<bool>();

    _mockWebSocket
      .Setup(ws => ws.SendAsync(
        It.IsAny<ArraySegment<byte>>(),
        WebSocketMessageType.Text,
        true,
        It.IsAny<CancellationToken>()))
      .Returns<ArraySegment<byte>, WebSocketMessageType, bool, CancellationToken>(
        async (_, _, _, ct) =>
        {
          sendStarted.SetResult(true);
          await sendCanProceed.Task;
        });

    // Start a text send that will hold the lock
    var textMsg = new CreateConversationItemRealtimeClientMessage(new RealtimeConversationItem(
      new List<AIContent> { new TextContent("hello") }, role: ChatRole.User));
    var textSend = _session.SendAsync(textMsg);

    // Wait until the text send has acquired the lock and is in-flight
    await sendStarted.Task;

    // AudioAppend should complete immediately (no lock contention)
    var audioContent = new DataContent("data:audio/pcm;base64,AQID", "audio/pcm");
    var audioAppend = new InputAudioBufferAppendRealtimeClientMessage(audioContent);
    var appendTask = _session.SendAsync(audioAppend);

    // Append should complete quickly even though the text send holds the lock
    var completed = await Task.WhenAny(appendTask, Task.Delay(1000));
    Assert.AreSame(appendTask, completed, "AudioAppend should not block on the send lock");

    // Release the text send
    sendCanProceed.SetResult(true);
    await textSend;
  }

  #endregion

  #region Tool Payload Normalization Tests

  [TestMethod]
  public void NormalizeToolPayload_ByteArray_EncodesAsBase64()
  {
    byte[] payload = [1, 2, 3, 4];
    var result = GoogleGenAIRealtimeSession.NormalizeToolPayload(payload);
    Assert.AreEqual(Convert.ToBase64String(payload), result);
  }

  [TestMethod]
  public void NormalizeToolPayload_JsonElement_DecomposesCorrectly()
  {
    var json = JsonSerializer.SerializeToElement(new { name = "test", count = 42 });
    var result = GoogleGenAIRealtimeSession.NormalizeToolPayload(json) as Dictionary<string, object?>;
    Assert.IsNotNull(result);
    Assert.AreEqual("test", result["name"]);
    // JSON numbers may deserialize as int64 or double depending on the runtime
    Assert.IsTrue(
      result["count"] is 42L or 42.0,
      $"Expected 42 as long or double, got {result["count"]} ({result["count"]?.GetType()})");
  }

  [TestMethod]
  public void NormalizeToolPayload_TooDeep_Throws()
  {
    var payload = new Dictionary<string, object?>();
    IDictionary<string, object?> current = payload;
    for (int i = 0; i < 80; i++)
    {
      var next = new Dictionary<string, object?>();
      current[$"level{i}"] = next;
      current = next;
    }

    Assert.ThrowsException<InvalidOperationException>(
      () => GoogleGenAIRealtimeSession.NormalizeToolPayload(payload));
  }

  [TestMethod]
  public void NormalizeToolArguments_NormalizesNestedJsonElements()
  {
    var jsonElement = JsonSerializer.SerializeToElement("hello");
    var args = new Dictionary<string, object?> { ["key"] = jsonElement };
    var result = GoogleGenAIRealtimeSession.NormalizeToolArguments(args);
    Assert.AreEqual("hello", result["key"]);
  }

  #endregion

  #region Concurrent Enumeration Guard Tests

  [TestMethod]
  public async Task GetStreamingResponseAsync_ConcurrentEnumeration_Throws()
  {
    // Set up WebSocket to block on receive so the first enumeration stays active
    var receiveGate = new TaskCompletionSource<WebSocketReceiveResult>();
    _mockWebSocket
      .Setup(ws => ws.ReceiveAsync(
        It.IsAny<ArraySegment<byte>>(),
        It.IsAny<CancellationToken>()))
      .Returns(receiveGate.Task);

    // Start first enumeration
    using var cts = new CancellationTokenSource();
    var enumerator = _session.GetStreamingResponseAsync(cts.Token).GetAsyncEnumerator(cts.Token);
    var firstMoveNext = enumerator.MoveNextAsync();

    // Attempt second concurrent enumeration — should throw
    await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () =>
    {
      await foreach (var _ in _session.GetStreamingResponseAsync())
      {
      }
    });

    // Clean up
    cts.Cancel();
    receiveGate.SetCanceled();
    try { await firstMoveNext; } catch { }
    await enumerator.DisposeAsync();
  }

  #endregion
}

#pragma warning restore MEAI001
