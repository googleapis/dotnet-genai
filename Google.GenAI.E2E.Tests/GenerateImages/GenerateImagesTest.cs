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
public class GenerateImagesTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
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
    var vertexClientHttpOptions = new HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1454"
    };

    // Common setup for both clients.
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "imagen-3.0-generate-002";
  }

  [TestMethod]
  public async Task GenerateImagesSimpleTextVertexTest() {
    var vertexResponse = await vertexClient.Models.GenerateImagesAsync(
        model: modelName, prompt: "Robot holding a red skateboard", config: null);

    Assert.IsNotNull(vertexResponse.GeneratedImages);
    Assert.IsNotNull(vertexResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task GenerateImagesSimpleTextGeminiTest() {
    var geminiResponse = await geminiClient.Models.GenerateImagesAsync(
        model: modelName, prompt: "Robot holding a red skateboard", config: null);

    Assert.IsNotNull(geminiResponse.GeneratedImages);
    Assert.IsNotNull(geminiResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task GenerateImagesAllConfigParamsVertexTest() {
    var generateImagesConfig = new GenerateImagesConfig {
      AspectRatio = "1:1",
      GuidanceScale = 15.0,
      SafetyFilterLevel = SafetyFilterLevel.BLOCK_MEDIUM_AND_ABOVE,
      NumberOfImages = 1,
      PersonGeneration = PersonGeneration.DONT_ALLOW,
      IncludeSafetyAttributes = true,
      IncludeRaiReason = true,
      OutputMimeType = "image/jpeg",
      OutputCompressionQuality = 80,
      // The below parameters are not supported in Gemini Developer API.
      NegativePrompt = "human",
      AddWatermark = false,
      Seed = 1337,
      Language = ImagePromptLanguage.en,
      EnhancePrompt = true,
    };

    var vertexResponse = await vertexClient.Models.GenerateImagesAsync(
        model: modelName, prompt: "Red skateboard", config: generateImagesConfig);

    Assert.IsNotNull(vertexResponse.GeneratedImages);
    Assert.AreEqual(vertexResponse.GeneratedImages.Count, 1, "Expected 1 generated image.");
    Assert.IsNotNull(vertexResponse.GeneratedImages.First().Image.ImageBytes);
    Assert.IsNotNull(vertexResponse.PositivePromptSafetyAttributes);
  }

  [TestMethod]
  public async Task GenerateImagesAllConfigParamsGeminiTest() {
    var generateImagesConfig = new GenerateImagesConfig {
      AspectRatio = "1:1",
      GuidanceScale = 15.0,
      SafetyFilterLevel = SafetyFilterLevel.BLOCK_LOW_AND_ABOVE,
      NumberOfImages = 1,
      PersonGeneration = PersonGeneration.DONT_ALLOW,
      IncludeSafetyAttributes = true,
      IncludeRaiReason = true,
      OutputMimeType = "image/jpeg",
      OutputCompressionQuality = 80,
    };

    var geminiResponse = await geminiClient.Models.GenerateImagesAsync(
        model: modelName, prompt: "Red skateboard", config: generateImagesConfig);

    Assert.IsNotNull(geminiResponse.GeneratedImages);
    Assert.AreEqual(geminiResponse.GeneratedImages.Count, 1, "Expected 1 generated image.");
    Assert.IsNotNull(geminiResponse.GeneratedImages.First().Image.ImageBytes);
    Assert.IsNotNull(geminiResponse.PositivePromptSafetyAttributes);
  }
}
