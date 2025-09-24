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
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class GenerateImagesErrorHandlingTest {
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
  public async Task GenerateImagesWrongModelNameVertexTest() {
    var ex = await Assert.ThrowsExceptionAsync<ClientError>(async () => {
      await vertexClient.Models.GenerateImagesAsync(model: "wrong-model-name",
                                                    prompt: "Red skateboard", config: null);
    });

    StringAssert.Contains(ex.Message, "wrong-model-name");
    StringAssert.Contains(ex.Message, "Details");
    StringAssert.Contains(ex.Message, "[ORIGINAL ERROR] generic::not_found");
  }

  [TestMethod]
  public async Task GenerateImagesWrongModelNameGeminiTest() {
    var ex = await Assert.ThrowsExceptionAsync<ClientError>(async () => {
      await geminiClient.Models.GenerateImagesAsync(model: "wrong-model-name",
                                                    prompt: "Red skateboard", config: null);
    });

    StringAssert.Contains(ex.Message, "wrong-model-name");
    StringAssert.Contains(ex.Message, "Details");
    StringAssert.Contains(ex.Message, "[ORIGINAL ERROR] generic::not_found");
  }

  [TestMethod]
  public async Task GenerateImagesBlockedVertexTest() {
    var vertexResponse =
        await vertexClient.Models.GenerateImagesAsync(model: modelName, prompt: "Violence and gore",
                                                      config: new GenerateImagesConfig {
                                                        NumberOfImages = 1,
                                                        IncludeRaiReason = true,
                                                      });

    Assert.IsNotNull(vertexResponse);
    Assert.IsTrue(vertexResponse.GeneratedImages.Count == 1);
    Assert.IsNotNull(vertexResponse.GeneratedImages[0].RaiFilteredReason);
  }

  [TestMethod]
  public async Task GenerateImagesBlockedGeminiTest() {
    var vertexResponse =
        await geminiClient.Models.GenerateImagesAsync(model: modelName, prompt: "Violence and gore",
                                                      config: new GenerateImagesConfig {
                                                        NumberOfImages = 1,
                                                        IncludeRaiReason = true,
                                                      });

    Assert.IsNotNull(vertexResponse);
    Assert.IsTrue(vertexResponse.GeneratedImages.Count == 1);
    Assert.IsNotNull(vertexResponse.GeneratedImages[0].RaiFilteredReason);
  }

  [TestMethod]
  public async Task GenerateImagesGeminiTest() {
    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.GenerateImagesAsync(model: modelName, prompt: "Red skateboard",
                                                    config: new GenerateImagesConfig {
                                                      Seed = 1337,
                                                    });
    });

    Assert.AreEqual(ex.Message, "seed parameter is not supported in Gemini API.");
  }
}
