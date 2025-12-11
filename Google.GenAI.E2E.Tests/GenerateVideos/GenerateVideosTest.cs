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
public class GenerateVideosTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string modelName;
  private string outputGcsUri;
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
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "veo-3.1-generate-preview";
    outputGcsUri = "gs://genai-sdk-tests/temp/videos/";
  }

  [TestMethod]
  public async Task GenerateVideosSimpleTextVertexTest() {
    // TODO(b/464055665): resolve test failure (temporarily skipped) in replay mode
    if (TestServer.IsReplayMode) {
        Assert.Inconclusive("Vertex generate videos tests run in record mode only.");
    }
    var source = new GenerateVideosSource {
      Prompt = "Man with a dog",
    };
    var operation = await vertexClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: null);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await vertexClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.VideoBytes);
  }

  [TestMethod]
  public async Task GenerateVideosSimpleTextGeminiTest() {
    var source = new GenerateVideosSource {
      Prompt = "Man with a dog",
    };
    var operation = await geminiClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: null);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await geminiClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosSourceTextVertexTest() {
    // TODO(b/464055665): resolve test failure (temporarily skipped) in replay mode
    if (TestServer.IsReplayMode) {
        Assert.Inconclusive("Vertex generate videos tests run in record mode only.");
    }
    var source = new GenerateVideosSource {
      Prompt = "Man with a dog",
    };

    var config = new GenerateVideosConfig {
      NumberOfVideos = 1,
      OutputGcsUri = outputGcsUri,
      Fps = 24,
      DurationSeconds = 6,
      Seed = 1,
      AspectRatio = "16:9",
      Resolution = "720p",
      PersonGeneration = "allow_adult",
      NegativePrompt = "ugly, low quality",
      EnhancePrompt = true,
      CompressionQuality = VideoCompressionQuality.LOSSLESS,
    };

    var operation = await vertexClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        // Test Vertex GetAsync http options.
        GetOperationConfig getOperationConfig = new GetOperationConfig {
          HttpOptions = new HttpOptions {
            ApiVersion = "v1"
          },
        };
        operation = await vertexClient.Operations.GetAsync(operation, getOperationConfig);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosSourceTextGeminiTest() {
    var source = new GenerateVideosSource {
      Prompt = "Man with a dog",
    };

    var config = new GenerateVideosConfig {
      NumberOfVideos = 1,
      DurationSeconds = 6,
      AspectRatio = "16:9",
      NegativePrompt = "ugly, low quality",
    };

    var operation = await geminiClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await geminiClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosSourceImageTextVertexTest() {
    // TODO(b/464055665): resolve test failure (temporarily skipped) in replay mode
    if (TestServer.IsReplayMode) {
        Assert.Inconclusive("Vertex generate videos tests run in record mode only.");
    }
    var source = new GenerateVideosSource {
      Prompt = "A neon hologram of a cat driving at top speed.",
      Image = Image.FromFile("TestAssets/bridge1.png"),
    };
    var operation = await vertexClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: null);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await vertexClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.VideoBytes);
  }

  [TestMethod]
  public async Task GenerateVideosSourceImageTextGeminiTest() {
    var source = new GenerateVideosSource {
      Prompt = "A neon hologram of a cat driving at top speed.",
      Image = Image.FromFile("TestAssets/bridge1.png"),
    };
    var operation = await geminiClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: null);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await geminiClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosSourceVideoTextVertexTest() {
    // TODO(tangmatthew): resolve test failure (temporarily skipped) in replay mode
    if (TestServer.IsReplayMode) {
        Assert.Inconclusive("Vertex generate videos tests run in record mode only.");
    }
    var source = new GenerateVideosSource {
      Prompt = "Driving through a tunnel.",
      Video = new Video {
        Uri = "gs://genai-sdk-tests/inputs/videos/cat_driving.mp4",
        MimeType = "video/mp4",
      },
    };

    var config = new GenerateVideosConfig {
      NumberOfVideos = 1,
      OutputGcsUri = outputGcsUri,
    };

    var operation = await vertexClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await vertexClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosSourceGeneratedVideoExtensionGeminiTest() {
    var source1 = new GenerateVideosSource {
      Prompt = "Man with a dog",
    };
    var operation1 = await geminiClient.Models.GenerateVideosAsync(
        model: modelName, source: source1, config: new GenerateVideosConfig{
          NumberOfVideos = 1,
    });

    Assert.IsNotNull(operation1.Name);
    while (operation1.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation1 = await geminiClient.Operations.GetAsync(operation1, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation1.Done);
    Assert.IsTrue(operation1.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation1.Response.GeneratedVideos.First().Video.Uri);

    // Download generated video
    await geminiClient.Files.DownloadToFileAsync(
        generatedVideo: operation1.Response.GeneratedVideos.First(),
        outputPath: "generatedVideo.mp4"
    );
    // Downloaded video is a file. Bytes do not get written to the Video object.
    Assert.IsNull(operation1.Response.GeneratedVideos.First().Video.VideoBytes);


    var source2 = new GenerateVideosSource {
      Prompt = "Driving through a tunnel.",
      Video = operation1.Response.GeneratedVideos.First().Video,
    };
    var operation2 = await geminiClient.Models.GenerateVideosAsync(
        model: modelName, source: source2, config: new GenerateVideosConfig{
          NumberOfVideos = 1,
    });

    Assert.IsNotNull(operation2.Name);
    while (operation2.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation2 = await geminiClient.Operations.GetAsync(operation2, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation2.Done);
    Assert.IsTrue(operation2.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation2.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosFrameInterpolationVertexTest() {
    // TODO(b/464055665): resolve test failure (temporarily skipped) in replay mode
    if (TestServer.IsReplayMode) {
        Assert.Inconclusive("Vertex generate videos tests run in record mode only.");
    }
    var source = new GenerateVideosSource {
      Prompt = "Rain",
      Image = Image.FromFile("TestAssets/man.jpg"),
    };
    var config = new GenerateVideosConfig {
      NumberOfVideos = 1,
      OutputGcsUri = outputGcsUri,
      LastFrame = Image.FromFile("TestAssets/dog.jpg"),
    };
    var operation = await vertexClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await vertexClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosFrameInterpolationGeminiTest() {
    var source = new GenerateVideosSource {
      Prompt = "Rain",
      Image = Image.FromFile("TestAssets/man.jpg"),
    };
    var config = new GenerateVideosConfig {
      NumberOfVideos = 1,
      LastFrame = Image.FromFile("TestAssets/dog.jpg"),
    };
    var operation = await geminiClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await geminiClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosReferenceToVideoVertexTest() {
    // TODO(b/464055665): resolve test failure (temporarily skipped) in replay mode
    if (TestServer.IsReplayMode) {
        Assert.Inconclusive("Vertex generate videos tests run in record mode only.");
    }
    var source = new GenerateVideosSource {
      Prompt = "Chirping birds in a colorful forest",
    };
    List<VideoGenerationReferenceImage> referenceImages = new List<VideoGenerationReferenceImage>();
    referenceImages.Add(new VideoGenerationReferenceImage {
      Image = Image.FromFile("TestAssets/man.jpg"),
      ReferenceType = VideoGenerationReferenceType.ASSET,
    });
    var config = new GenerateVideosConfig {
      NumberOfVideos = 1,
      OutputGcsUri = outputGcsUri,
      ReferenceImages = referenceImages,
    };
    var operation = await vertexClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await vertexClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosReferenceToVideoGeminiTest() {
    var source = new GenerateVideosSource {
      Prompt = "Chirping birds in a colorful forest",
    };
    List<VideoGenerationReferenceImage> referenceImages = new List<VideoGenerationReferenceImage>();
    referenceImages.Add(new VideoGenerationReferenceImage {
      Image = Image.FromFile("TestAssets/man.jpg"),
      ReferenceType = VideoGenerationReferenceType.ASSET,
    });
    var config = new GenerateVideosConfig {
      NumberOfVideos = 1,
      ReferenceImages = referenceImages,
    };
    var operation = await geminiClient.Models.GenerateVideosAsync(
        model: modelName, source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await geminiClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosEditOutpaintVertexTest() {
    // TODO(b/464055665): resolve test failure (temporarily skipped) in replay mode
    if (TestServer.IsReplayMode) {
        Assert.Inconclusive("Vertex generate videos tests run in record mode only.");
    }

    var source = new GenerateVideosSource {
      Prompt = "A mountain landscape",
      Video = new Video {
        Uri = "gs://genai-sdk-tests/inputs/videos/editing_demo.mp4",
        MimeType = "video/mp4",
      },
    };

    var config = new GenerateVideosConfig {
      OutputGcsUri = outputGcsUri,
      AspectRatio = "16:9",
      Mask = new VideoGenerationMask {
        Image = new Image {
          GcsUri = "gs://genai-sdk-tests/inputs/videos/video_outpaint_mask.png",
          MimeType = "image/png",
        },
        MaskMode = VideoGenerationMaskMode.OUTPAINT,
      },
    };
    var operation = await vertexClient.Models.GenerateVideosAsync(
        model: "veo-2.0-generate-exp", source: source, config: config);

    Assert.IsNotNull(operation.Name);
    while (operation.Done != true) {
      try {
        if (!TestServer.IsReplayMode) {
          await Task.Delay(10000);
        }
        operation = await vertexClient.Operations.GetAsync(operation, null);
      } catch (TaskCanceledException) {
        System.Console.WriteLine("Task was cancelled while waiting.");
        break;
      }
    }
    Assert.IsTrue(operation.Done);
    Assert.IsTrue(operation.Response.GeneratedVideos.Count > 0);
    Assert.IsNotNull(operation.Response.GeneratedVideos.First().Video.Uri);
  }

  [TestMethod]
  public async Task GenerateVideosEditOutpaintGeminiNotSupportedTest() {
    var source = new GenerateVideosSource {
      Prompt = "A mountain landscape",
      Video = new Video {
        VideoBytes = new byte[100],
        MimeType = "video/mp4",
      },
    };

    var config = new GenerateVideosConfig {
      AspectRatio = "16:9",
      Mask = new VideoGenerationMask {
        Image = Image.FromFile("TestAssets/google_small.png"),
        MaskMode = VideoGenerationMaskMode.OUTPAINT,
      },
    };

    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.GenerateVideosAsync(
          model: "veo-2.0-generate-exp", source: source, config: config);
    });

    Assert.AreEqual(ex.Message, "mask parameter is not supported in Gemini API.");
  }

}
