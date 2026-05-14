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
using System.Threading.Tasks;

using Google.GenAI;
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class EditImageErrorHandlingTest {
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
    modelName = "imagen-3.0-capability-002";
  }

  [TestMethod]
  public async Task EditImageWrongModelNameVertexTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Style reference image
    var styleReferenceImage = new StyleReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/google_small.png"),
      ReferenceId = 1,
      Config =
          new StyleReferenceConfig {
            StyleDescription = "glowing",
          }
    };
    referenceImages.Add(styleReferenceImage);

    var editImageConfig = new EditImageConfig {
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
    };

    var ex = await Assert.ThrowsExceptionAsync<ClientError>(async () => {
      await enterpriseClient.Models.EditImageAsync(
        model: "wrong-model-name",
        prompt: "Generate an image in glowing style [1] based on the following caption: A church in the mountain.",
        referenceImages: referenceImages,
        config: editImageConfig);
    });

    StringAssert.Contains(ex.Message, "wrong-model-name");
    StringAssert.Contains(ex.Message, "Details");
    StringAssert.Contains(ex.Message, "[ORIGINAL ERROR] generic::not_found");
  }

  [TestMethod]
  public async Task EditImageNotSupportedGeminiTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Style reference image
    var styleReferenceImage = new StyleReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/google_small.png"),
      ReferenceId = 1,
      Config =
          new StyleReferenceConfig {
            StyleDescription = "glowing",
          }
    };
    referenceImages.Add(styleReferenceImage);

    var editImageConfig = new EditImageConfig {
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
    };

    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.EditImageAsync(
        model: modelName,
        prompt: "Generate an image in glowing style [1] based on the following caption: A church in the mountain.",
        referenceImages: referenceImages,
        config: editImageConfig);
    });

    StringAssert.Contains(ex.Message, "only supported in Gemini Enterprise Agent Platform mode");
  }

  [TestMethod]
  public async Task EditImagesNonexistentFileTest() {
    var ex = Assert.ThrowsException<IOException>(() => {
      Image.FromFile("TestAssets/file.fileExtension");
    });

    StringAssert.Contains(ex.Message, "Failed to read image from file");
  }
}
