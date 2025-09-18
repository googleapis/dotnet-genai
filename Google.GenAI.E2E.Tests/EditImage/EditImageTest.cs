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
public class EditImageTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string capabilityModelName;
  private string generateModelName;
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
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    generateModelName = "imagen-3.0-generate-001";
    capabilityModelName = "imagen-3.0-capability-002";
  }

  [TestMethod]
  public async Task EditImageMaskReferenceVertexTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Raw reference image
    var rawReferenceImage = new RawReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/google_small.png", "image/png"),
      ReferenceId = 1,
    };
    referenceImages.Add(rawReferenceImage);

    // Mask reference image
    var maskReferenceImage = new MaskReferenceImage {
      ReferenceId = 2,
      Config =
          new MaskReferenceConfig {
            MaskMode = MaskReferenceMode.MASK_MODE_BACKGROUND,
            MaskDilation = 0.06,
          }
    };
    referenceImages.Add(maskReferenceImage);

    var editImageConfig = new EditImageConfig {
      EditMode = EditMode.EDIT_MODE_INPAINT_INSERTION,
      NumberOfImages = 1,
      NegativePrompt = "human",
      GuidanceScale = 15.0,
      SafetyFilterLevel = SafetyFilterLevel.BLOCK_LOW_AND_ABOVE,
      PersonGeneration = PersonGeneration.DONT_ALLOW,
      IncludeSafetyAttributes = false,
      IncludeRaiReason = true,
      OutputMimeType = "image/jpeg",
      OutputCompressionQuality = 80,
      BaseSteps = 32,
      AddWatermark = false,
    };

    var editImageResponse = await vertexClient.Models.EditImageAsync(
        model: capabilityModelName,
        prompt: "Change the colors of [1] using the mask [2]",
        referenceImages: referenceImages,
        config: editImageConfig);

    Assert.IsNotNull(editImageResponse.GeneratedImages);
    Assert.IsNotNull(editImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task EditImageMaskReferenceUserProvidedVertexTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Raw reference image
    var rawReferenceImage = new RawReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/google_small.png", "image/png"),
      ReferenceId = 1,
    };
    referenceImages.Add(rawReferenceImage);

    // Mask reference image
    var maskReferenceImage = new MaskReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/checkerboard.png", "image/png"),
      ReferenceId = 2,
      Config =
          new MaskReferenceConfig {
            MaskMode = MaskReferenceMode.MASK_MODE_USER_PROVIDED,
            MaskDilation = 0.06,
          }
    };
    referenceImages.Add(maskReferenceImage);

    var editImageConfig = new EditImageConfig {
      EditMode = EditMode.EDIT_MODE_INPAINT_INSERTION,
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
    };

    var editImageResponse = await vertexClient.Models.EditImageAsync(
        model: capabilityModelName,
        prompt: "Change the colors of [1] using the mask [2]",
        referenceImages: referenceImages,
        config: editImageConfig);

    Assert.IsNotNull(editImageResponse.GeneratedImages);
    Assert.IsNotNull(editImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task EditImageControlReferenceUserProvidedVertexTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Raw reference image
    var rawReferenceImage = new RawReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/google_small.png", "image/png"),
      ReferenceId = 1,
    };
    referenceImages.Add(rawReferenceImage);

    // Control reference image
    var controlReferenceImage = new ControlReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/checkerboard.png", "image/png"),
      ReferenceId = 2,
      Config =
          new ControlReferenceConfig {
            ControlType = ControlReferenceType.CONTROL_TYPE_SCRIBBLE,
            EnableControlImageComputation = false,
          }
    };
    referenceImages.Add(controlReferenceImage);

    var editImageConfig = new EditImageConfig {
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
    };

    var editImageResponse = await vertexClient.Models.EditImageAsync(
        model: capabilityModelName,
        prompt: "Change the colors aligning with the scribble map [2]",
        referenceImages: referenceImages,
        config: editImageConfig);

    Assert.IsNotNull(editImageResponse.GeneratedImages);
    Assert.IsNotNull(editImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task EditImageStyleReferenceVertexTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Style reference image
    var styleReferenceImage = new StyleReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/google_small.png", "image/png"),
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

    var editImageResponse = await vertexClient.Models.EditImageAsync(
        model: capabilityModelName,
        prompt: "Generate an image in glowing style [1] based on the following caption: A church in the mountain.",
        referenceImages: referenceImages,
        config: editImageConfig);

    Assert.IsNotNull(editImageResponse.GeneratedImages);
    Assert.IsNotNull(editImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task EditImageSubjectReferenceVertexTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Subject reference image
    var subjectReferenceImage = new SubjectReferenceImage {
      ReferenceImage = Image.FromFile("TestAssets/google_small.png", "image/png"),
      ReferenceId = 1,
      Config =
          new SubjectReferenceConfig {
            SubjectType = SubjectReferenceType.SUBJECT_TYPE_PRODUCT,
            SubjectDescription = "A product logo that is a multi-colored letter G",
          }
    };
    referenceImages.Add(subjectReferenceImage);

    var editImageResponse = await vertexClient.Models.EditImageAsync(
        model: capabilityModelName,
        prompt: "Generate an image containing a mug with the product logo [1] visible on the side of the mug.",
        referenceImages: referenceImages,
        config: new EditImageConfig { OutputMimeType = "image/jpeg" });

    Assert.IsNotNull(editImageResponse.GeneratedImages);
    Assert.IsNotNull(editImageResponse.GeneratedImages.First().Image.ImageBytes);
  }

  [TestMethod]
  public async Task EditImageContentReferenceIngredientsVertexTest() {
    List<IReferenceImage> referenceImages = new List<IReferenceImage>();

    // Content reference image
    var dogContentReferenceImage = new ContentReferenceImage {
      ReferenceImage = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/dog.jpg",
      },
      ReferenceId = 1,
    };
    referenceImages.Add(dogContentReferenceImage);

    // Style reference image
    var cyberpunkContentReferenceImage = new StyleReferenceImage {
      ReferenceImage = new Image {
        GcsUri = "gs://genai-sdk-tests/inputs/images/cyberpunk.jpg",
      },
      ReferenceId = 2,
      Config =
          new StyleReferenceConfig {
            StyleDescription = "cyberpunk style",
          }
    };
    referenceImages.Add(cyberpunkContentReferenceImage);

    var editImageConfig = new EditImageConfig {
      NumberOfImages = 1,
      OutputMimeType = "image/jpeg",
    };

    var editImageResponse = await vertexClient.Models.EditImageAsync(
        model: capabilityModelName,
        prompt: "Dog in [1] sleeping on the ground at the bottom of the image with the cyberpunk city landscape in [2] in the background.",
        referenceImages: referenceImages,
        config: editImageConfig);

    Assert.IsNotNull(editImageResponse.GeneratedImages);
    Assert.IsNotNull(editImageResponse.GeneratedImages.First().Image.ImageBytes);
  }
}
