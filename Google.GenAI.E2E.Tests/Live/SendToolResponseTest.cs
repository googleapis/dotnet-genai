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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.GenAI;
using GoogleType = Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestServerSdk;

[TestClass]
public class SendToolResponseTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string vertexModelName;
  private string geminiModelName;
  public TestContext TestContext { get; set; }

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
    // Common setup for both clients
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    vertexModelName = "gemini-2.0-flash-live-preview-04-09";
    geminiModelName = "gemini-live-2.5-flash-preview";
  }

  [TestMethod]
  public async Task SendToolResponseFunctionResponseGeminiTest() {
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName);
    await geminiSession.InitializeSessionAsync();

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var functionResponse = new GoogleType.FunctionResponse {
      Name = "getStatus", Response = new Dictionary<string, object> { ["mood"] = "happy" }
    };

    await geminiSession.SendToolResponseAsync(new GoogleType.LiveSendToolResponseParameters {
      FunctionResponses = new List<GoogleType.FunctionResponse> { functionResponse }
    });

    // Unlike Vertex, Gemini doesn't return server content for this mocked function response usage
    // So we just check that the send doesn't cause error.

    await geminiSession.CloseAsync();
  }

  [TestMethod]
  public async Task SendToolResponseFunctionResponseVertexTest() {
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName);
    await vertexSession.InitializeSessionAsync();

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var functionResponse = new GoogleType.FunctionResponse {
      Name = "getStatus", Response = new Dictionary<string, object> { ["mood"] = "happy" }
    };

    await vertexSession.SendToolResponseAsync(new GoogleType.LiveSendToolResponseParameters {
      FunctionResponses = new List<GoogleType.FunctionResponse> { functionResponse }
    });

    var message = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(message.ServerContent);

    await vertexSession.CloseAsync();
  }
}
