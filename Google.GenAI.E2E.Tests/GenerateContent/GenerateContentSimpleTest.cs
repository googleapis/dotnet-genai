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
using System.Linq;
using System.Threading.Tasks;

using Google.GenAI;
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class GenerateContentSimpleTest {
  private static TestServerProcess? _server;
  private Client enterpriseClient;
  private Client geminiClient;
  private string modelName;
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
    var geminiClientHttpOptions = new HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1453"
    };
    var enterpriseClientHttpOptions = new HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1454"
    };

    // Common setup for both clients.
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    enterpriseClient = new Client(project: project, location: location, enterprise: true,
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: enterpriseClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, enterprise: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "gemini-2.0-flash";
  }

  [TestMethod]
  public async Task GenerateContentSimpleTextVertexTest() {
    var vertexResponse = await enterpriseClient.Models.GenerateContentAsync(
        model: modelName, contents: "What is the capital of France?");

    Assert.IsNotNull(vertexResponse.Candidates);
    StringAssert.Contains(vertexResponse.Text, "Paris");
  }

  [TestMethod]
  public async Task GenerateContentSimpleTextGeminiTest() {
    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "What is the capital of France?");

    Assert.IsNotNull(geminiResponse.Candidates);
    StringAssert.Contains(geminiResponse.Text, "Paris");
  }

  [TestMethod]
  public async Task GenerateContentSystemInstructionVertexTest() {
    var generateContentConfig = new GenerateContentConfig { SystemInstruction = new Content {
      Parts = new List<Part> { new Part { Text = "I say high you say low." } }
    } };
    var vertexResponse = await enterpriseClient.Models.GenerateContentAsync(
        model: modelName, contents: "high", config: generateContentConfig);

    Assert.IsNotNull(vertexResponse.Candidates);
    StringAssert.Contains(vertexResponse.Text, "low");
  }

  [TestMethod]
  public async Task GenerateContentSystemInstructionGeminiTest() {
    var generateContentConfig = new GenerateContentConfig { SystemInstruction = new Content {
      Parts = new List<Part> { new Part { Text = "I say high you say low." } }
    } };
    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "high", config: generateContentConfig);

    Assert.IsNotNull(geminiResponse.Candidates);
    StringAssert.Contains(geminiResponse.Text, "low");
  }

  [TestMethod]
  public async Task GenerateContentGenerationConfigVertexTest() {
    var generateContentConfig =
        new GenerateContentConfig { Temperature = 0.5, TopP = 0.9, MaxOutputTokens = 100,
                                    ResponseModalities = new List<string> { "TEXT" } };
    var vertexResponse = await enterpriseClient.Models.GenerateContentAsync(
        model: modelName, contents: "Why is the sky blue?", config: generateContentConfig);

    Assert.IsNotNull(vertexResponse.Candidates);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
  }

  [TestMethod]
  public async Task GenerateContentGenerationConfigGeminiTest() {
    var generateContentConfig =
        new GenerateContentConfig { Temperature = 0.5, TopP = 0.9, MaxOutputTokens = 100,
                                    ResponseModalities = new List<string> { "TEXT" } };
    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "Why is the sky blue?", config: generateContentConfig);

    Assert.IsNotNull(geminiResponse.Candidates);
    Assert.IsTrue(geminiResponse.Candidates.Count >= 1);
  }

  [TestMethod]
  public async Task GenerateContentSafetySettingsGeminiTest() {
    var safetySettings = new List<SafetySetting> {
      new SafetySetting { Category = HarmCategory.HarmCategoryHateSpeech,
                          Threshold = HarmBlockThreshold.BlockLowAndAbove }
    };
    var generateContentConfig =
        new GenerateContentConfig { SafetySettings = new List<SafetySetting>(safetySettings) };

    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "What hate speech is prohibited by responsible AI?",
        config: generateContentConfig);

    Assert.IsNotNull(geminiResponse.Candidates);
    Assert.IsTrue(geminiResponse.Candidates.Count >= 1);
    Assert.IsNotNull(geminiResponse.Candidates.First().Content.Parts.First().Text);
    Assert.IsNotNull(geminiResponse.Candidates.First().SafetyRatings);
  }

  [TestMethod]
  public async Task GenerateContentSafetySettingsVertexTest() {
    var safetySettings = new List<SafetySetting> {
      new SafetySetting { Category = HarmCategory.HarmCategoryHateSpeech,
                          Threshold = HarmBlockThreshold.BlockLowAndAbove }
    };
    var generateContentConfig =
        new GenerateContentConfig { SafetySettings = new List<SafetySetting>(safetySettings) };

    var vertexResponse = await enterpriseClient.Models.GenerateContentAsync(
        model: modelName, contents: "What hate speech is prohibited by responsible AI?",
        config: generateContentConfig);

    Assert.IsNotNull(vertexResponse.Candidates);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
    Assert.IsNotNull(vertexResponse.Text);
    Assert.IsNotNull(vertexResponse.Candidates.First().SafetyRatings);
  }
}
