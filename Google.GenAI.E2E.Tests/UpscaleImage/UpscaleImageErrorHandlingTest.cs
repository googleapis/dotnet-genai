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
public class UpscaleImageErrorHandlingTest {
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
    var geminiClientHttpOptions = new HttpOptions { Headers = new Dictionary<string, string> {
      { "Test-Name", $"{GetType().Name}.{TestContext.TestName}" }
    } };
    var vertexClientHttpOptions = new HttpOptions { Headers = new Dictionary<string, string> {
      { "Test-Name", $"{GetType().Name}.{TestContext.TestName}" }
    } };

    // Common setup for both clients.
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    Client.setDefaultBaseUrl(vertexBaseUrl: "http://localhost:1454",
                             geminiBaseUrl: "http://localhost:1453");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "imagen-3.0-generate-002";
  }

  [TestMethod]
  public async Task UpscaleImageWrongModelNameVertexTest() {
    // Generate an image first.
    var vertexResponse = await vertexClient.Models.GenerateImagesAsync(
        model: modelName, prompt: "Red skateboard", config: null);

    Assert.IsNotNull(vertexResponse.GeneratedImages);
    Assert.IsNotNull(vertexResponse.GeneratedImages.First().Image.ImageBytes);

    // Upscale the image.
    var ex = await Assert.ThrowsExceptionAsync<ClientError>(async () => {
      await vertexClient.Models.UpscaleImageAsync(
          model: "wrong-model-name", image: vertexResponse.GeneratedImages.First().Image,
          upscaleFactor: "x2", config: null);
    });

    StringAssert.Contains(ex.Message, "wrong-model-name");
    StringAssert.Contains(ex.Message, "Details");
    StringAssert.Contains(ex.Message, "[ORIGINAL ERROR] generic::not_found");
  }

  [TestMethod]
  public async Task UpscaleImageNotSupportedGeminiTest() {
    // Generate an image first.
    var geminiResponse = await geminiClient.Models.GenerateImagesAsync(
        model: modelName, prompt: "Red skateboard", config: null);

    Assert.IsNotNull(geminiResponse.GeneratedImages);
    Assert.IsNotNull(geminiResponse.GeneratedImages.First().Image.ImageBytes);

    // Upscale the image.
    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.UpscaleImageAsync(
          model: modelName, image: geminiResponse.GeneratedImages.First().Image,
          upscaleFactor: "x2", config: null);
    });

    StringAssert.Contains(ex.Message, "This method is only supported in the Vertex AI client.");
  }
}
