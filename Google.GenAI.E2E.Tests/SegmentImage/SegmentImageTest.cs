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
public class SegmentImageTest {
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
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "image-segmentation-001";
  }

  [TestMethod]
  public async Task SegmentImageGeminiTest() {
    var segmentImageConfig = new SegmentImageConfig {
      Mode = SegmentMode.Foreground,
      MaxPredictions = 1,
    };

    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.SegmentImageAsync(
        model: modelName,
        source: new SegmentImageSource {
          Image = Image.FromFile("TestAssets/google.png"),
        },
        config: segmentImageConfig);
    });

    StringAssert.Contains(ex.Message, "only supported in the Gemini Enterprise Agent Platform");
  }

  [TestMethod]
  public async Task SegmentImageForegroundVertexTest() {
    var segmentImageConfig = new SegmentImageConfig {
      Mode = SegmentMode.Foreground,
      MaxPredictions = 1,
      ConfidenceThreshold = 0.02,
      MaskDilation = 0.02,
      BinaryColorThreshold = 98,
      Labels = new Dictionary<string, string> { ["imagen_label_key"] = "segment_image" },
    };

    var segmentImageResponse = await vertexClient.Models.SegmentImageAsync(
        model: modelName,
        source: new SegmentImageSource {
          Image = Image.FromFile("TestAssets/google.png"),
        },
        config: segmentImageConfig);

    Assert.IsNotNull(segmentImageResponse.GeneratedMasks);
    Assert.IsNotNull(segmentImageResponse.GeneratedMasks.First().Mask.ImageBytes);
    Assert.IsInstanceOfType(segmentImageResponse.GeneratedMasks.First().Labels.First().Score, typeof(double));
  }

  [TestMethod]
  public async Task SegmentImageBackgroundVertexTest() {
    var segmentImageConfig = new SegmentImageConfig {
      Mode = SegmentMode.Background,
      MaxPredictions = 1,
    };

    var segmentImageResponse = await vertexClient.Models.SegmentImageAsync(
        model: modelName,
        source: new SegmentImageSource {
          Image = Image.FromFile("TestAssets/google.png"),
        },
        config: segmentImageConfig);

    Assert.IsNotNull(segmentImageResponse.GeneratedMasks);
    Assert.IsNotNull(segmentImageResponse.GeneratedMasks.First().Mask.ImageBytes);
    Assert.IsInstanceOfType(segmentImageResponse.GeneratedMasks.First().Labels.First().Score, typeof(double));
  }

  [TestMethod]
  public async Task SegmentImagePromptVertexTest() {
    var segmentImageConfig = new SegmentImageConfig {
      Mode = SegmentMode.Prompt,
      MaxPredictions = 1,
    };

    var segmentImageResponse = await vertexClient.Models.SegmentImageAsync(
        model: modelName,
        source: new SegmentImageSource {
          Image = Image.FromFile("TestAssets/google.png"),
          Prompt = "The letter G",
        },
        config: segmentImageConfig);

    Assert.IsNotNull(segmentImageResponse.GeneratedMasks);
    Assert.IsNotNull(segmentImageResponse.GeneratedMasks.First().Mask.ImageBytes);
    Assert.IsInstanceOfType(segmentImageResponse.GeneratedMasks.First().Labels.First().Score, typeof(double));
  }

  [TestMethod]
  public async Task SegmentImageSemanticVertexTest() {
    var segmentImageConfig = new SegmentImageConfig {
      Mode = SegmentMode.Semantic,
      MaxPredictions = 1,
    };

    var segmentImageResponse = await vertexClient.Models.SegmentImageAsync(
        model: modelName,
        source: new SegmentImageSource {
          Image = Image.FromFile("TestAssets/skateboard_stop_sign.jpg"),
          Prompt = "skateboard",
        },
        config: segmentImageConfig);

    Assert.IsNotNull(segmentImageResponse.GeneratedMasks);
    Assert.IsNotNull(segmentImageResponse.GeneratedMasks.First().Mask.ImageBytes);
    // Semantic segmentation does not return scores.
  }

  [TestMethod]
  public async Task SegmentImageInteractiveVertexTest() {
    var segmentImageConfig = new SegmentImageConfig {
      Mode = SegmentMode.Interactive,
      MaxPredictions = 1,
    };

    var segmentImageResponse = await vertexClient.Models.SegmentImageAsync(
        model: modelName,
        source: new SegmentImageSource {
          Image = Image.FromFile("TestAssets/skateboard_stop_sign.jpg"),
          ScribbleImage = new ScribbleImage {
            Image = Image.FromFile("TestAssets/segmentation_scribble.jpg"),
          },
        },
        config: segmentImageConfig);

    Assert.IsNotNull(segmentImageResponse.GeneratedMasks);
    Assert.IsNotNull(segmentImageResponse.GeneratedMasks.First().Mask.ImageBytes);
    // Interactive segmentation does not return scores.
  }
}
