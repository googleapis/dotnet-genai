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
using System.Threading.Tasks;

using Google.GenAI;
using GoogleType = Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;
using System.Threading.Channels;
using System.Net.WebSockets;

[TestClass]
public class ErrorHandlingTests {
  private static TestServerProcess? _server;
  private Client vertexClient = null!;
  private Client geminiClient = null!;
  private string vertexModelName = null!;
  private string geminiModelName = null!;
  public TestContext TestContext { get; set; } = null!;

  [ClassInitialize]
  public static void ClassInit(TestContext _) {
    _server = TestServer.StartTestServer();
  }

  [ClassCleanup]
  public static void ClassCleanup() {
    TestServer.StopTestServer(_server);
  }

  [TestInitialize]
  public void TestInit() {
    // Test server specific setup.
    if (_server == null) {
      throw new InvalidOperationException("Test server is not initialized.");
    }
    var geminiClientHttpOptions = new GoogleType.HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1453"
    };
    var vertexClientHttpOptions = new GoogleType.HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1454"
    };

    // Common setup for both clients.
    string? project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string? apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    vertexModelName = "gemini-2.0-flash-live-preview-04-09";
    geminiModelName = "gemini-live-2.5-flash-preview";
  }

  [TestMethod]
  public async Task SendClientContentAsync_AfterSessionClosed_ThrowsExceptionGeminiTest() {
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName);
    await geminiSession.InitializeSessionAsync();

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await geminiSession.CloseAsync();

    var clientContent = new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Role = "user", Parts = new List<GoogleType.Part> { new GoogleType.Part { Text = "Hello" } }
      } },
      TurnComplete = true
    };

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
        async () => await geminiSession.SendClientContentAsync(clientContent));
  }

  [TestMethod]
  public async Task SendClientContentAsync_AfterSessionClosed_ThrowsExceptionVertexTest() {
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName);
    await vertexSession.InitializeSessionAsync();

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await vertexSession.CloseAsync();

    var clientContent = new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Role = "user", Parts = new List<GoogleType.Part> { new GoogleType.Part { Text = "Hello" } }
      } },
      TurnComplete = true
    };

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
        async () => await vertexSession.SendClientContentAsync(clientContent));
  }

  [TestMethod]
  public async Task SendRealtimeInputAsync_AfterSessionClosed_ThrowsExceptionGeminiTest() {
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName);
    await geminiSession.InitializeSessionAsync();

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await geminiSession.CloseAsync();

    var realtimeInput =
        new GoogleType.LiveSendRealtimeInputParameters { Audio = new GoogleType.Blob {
          MimeType = "audio/pcm", Data = new byte[] { 0x00, 0x01, 0x02, 0x03 }
        } };

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
        async () => await geminiSession.SendRealtimeInputAsync(realtimeInput));
  }

  [TestMethod]
  public async Task SendRealtimeInputAsync_AfterSessionClosed_ThrowsExceptionVertexTest() {
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName);
    await vertexSession.InitializeSessionAsync();

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await vertexSession.CloseAsync();

    var realtimeInput =
        new GoogleType.LiveSendRealtimeInputParameters { Audio = new GoogleType.Blob {
          MimeType = "audio/pcm", Data = new byte[] { 0x00, 0x01, 0x02, 0x03 }
        } };

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
        async () => await vertexSession.SendRealtimeInputAsync(realtimeInput));
  }

  [TestMethod]
  public async Task SendToolResponseAsync_AfterSessionClosed_ThrowsExceptionGeminiTest() {
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName);
    await geminiSession.InitializeSessionAsync();

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await geminiSession.CloseAsync();

    var toolResponse = new GoogleType.LiveSendToolResponseParameters {
      FunctionResponses = new List<GoogleType.FunctionResponse> { new GoogleType.FunctionResponse {
        Name = "test_function", Response = new Dictionary<string, object> { { "result", "test" } }
      } }
    };

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
        async () => await geminiSession.SendToolResponseAsync(toolResponse));
  }

  [TestMethod]
  public async Task SendToolResponseAsync_AfterSessionClosed_ThrowsExceptionVertexTest() {
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName);
    await vertexSession.InitializeSessionAsync();

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await vertexSession.CloseAsync();

    var toolResponse = new GoogleType.LiveSendToolResponseParameters {
      FunctionResponses = new List<GoogleType.FunctionResponse> { new GoogleType.FunctionResponse {
        Name = "test_function", Response = new Dictionary<string, object> { { "result", "test" } }
      } }
    };

    await Assert.ThrowsExceptionAsync<InvalidOperationException>(
        async () => await vertexSession.SendToolResponseAsync(toolResponse));
  }

  [TestMethod]
  public async Task CloseAsync_CalledMultipleTimes_DoesNotThrowGeminiTest() {
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName);
    await geminiSession.InitializeSessionAsync();

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    // Close the session multiple times - should not throw
    await geminiSession.CloseAsync();
    await geminiSession.CloseAsync();
    await geminiSession.CloseAsync();
  }

  [TestMethod]
  public async Task CloseAsync_CalledMultipleTimes_DoesNotThrowVertexTest() {
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName);
    await vertexSession.InitializeSessionAsync();

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    // Close the session multiple times - should not throw
    await vertexSession.CloseAsync();
    await vertexSession.CloseAsync();
    await vertexSession.CloseAsync();
  }

  [TestMethod]
  public async Task ReceiveAsync_AfterSessionClosed_ThrowsExceptionGeminiTest() {
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName);
    await geminiSession.InitializeSessionAsync();

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await geminiSession.CloseAsync();

    // Try to receive after closing - this should fail
    await Assert.ThrowsExceptionAsync<ChannelClosedException>(
        async () => await geminiSession.ReceiveAsync());
  }

  [TestMethod]
  public async Task ReceiveAsync_AfterSessionClosed_ThrowsExceptionVertexTest() {
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName);
    await vertexSession.InitializeSessionAsync();

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    await vertexSession.CloseAsync();

    // Try to receive after closing - this should fail
    await Assert.ThrowsExceptionAsync<ChannelClosedException>(
        async () => await vertexSession.ReceiveAsync());
  }
}