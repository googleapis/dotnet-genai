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
using System.Text;
using System.Threading.Tasks;

using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class GenerateContentContinuationTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
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
    if (_server == null) {
      throw new InvalidOperationException("Test server is not initialized.");
    }
    var geminiClientHttpOptions = new HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1453",
      Timeout = 600000
    };

    // Common setup for both clients.
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    // Continuation is only supported on the global Vertex AI endpoint.
    string location = "global";
    string apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY");

    string vertexBaseUrl = location.Equals("global", StringComparison.OrdinalIgnoreCase)
        ? "http://localhost:1455"
        : "http://localhost:1454";

    var vertexClientHttpOptions = new HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = vertexBaseUrl,
      Timeout = 600000
    };

    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);
  }

  [TestMethod]
  [Timeout(600000)]
  public async Task GenerateContentAutomaticContinuationGeminiTest() {
    var response = await geminiClient.Models.GenerateContentAsync(
        model: "REDACTED",
        contents: "Write an exhaustive, multi-chapter textbook on compiler design that is around 40,000 tokens long.",
        config: new GenerateContentConfig {
          AutomaticContinuation = true
        });

    Assert.IsNotNull(response);
    Assert.IsNotNull(response.Candidates);
    Assert.AreEqual(FinishReason.Stop, response.Candidates[0].FinishReason);
    Assert.IsNull(response.Candidates[0].ContinuationToken);

    var usage = response.UsageMetadata;
    int outputTokens = (usage?.CandidatesTokenCount ?? 0) + (usage?.ThoughtsTokenCount ?? 0);
    Assert.IsTrue(outputTokens > 32768, $"Only {outputTokens} output tokens");
  }

  [TestMethod]
  [Timeout(600000)]
  public async Task GenerateContentAutomaticContinuationVertexTest() {
    var response = await vertexClient.Models.GenerateContentAsync(
        model: "REDACTED",
        contents: "Write an exhaustive, multi-chapter textbook on compiler design that is around 40,000 tokens long.",
        config: new GenerateContentConfig {
          AutomaticContinuation = true
        });

    Assert.IsNotNull(response);
    Assert.IsNotNull(response.Candidates);
    Assert.AreEqual(FinishReason.Stop, response.Candidates[0].FinishReason);
    Assert.IsNull(response.Candidates[0].ContinuationToken);

    var usage = response.UsageMetadata;
    int outputTokens = (usage?.CandidatesTokenCount ?? 0) + (usage?.ThoughtsTokenCount ?? 0);
    Assert.IsTrue(outputTokens > 32768, $"Only {outputTokens} output tokens");
  }
}

