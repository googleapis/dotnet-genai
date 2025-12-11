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
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class FilesDownloadTest
{
    private static TestServerProcess? _server;
    private Client vertexClient;
    private Client geminiClient;
    private string fileUri;
    public TestContext TestContext { get; set; }

    [ClassInitialize]
    public static void ClassInit(TestContext _)
    {
        _server = TestServer.StartTestServer();
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        TestServer.StopTestServer(_server);
    }

    [TestInitialize]
    public void TestInit()
    {
        // Test server specific setup.
        if (_server == null)
        {
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
        // Note that replay mode does not return any bytes when downloading a file.
        fileUri = "https://generativelanguage.googleapis.com/v1beta/files/p1crkz5nfru4:download?alt=media";

    }

    [TestMethod]
    public async Task DownloadFileNameVertexTest()
    {
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadAsync(fileName: "fileName");
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadFileNameGeminiTest()
    {
      var stream = await geminiClient.Files.DownloadAsync(
          fileName: fileUri
      );
      using (MemoryStream memoryStream = new MemoryStream()) {
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        byte[] bytes = memoryStream.ToArray();
        // Replay mode does not return any bytes when downloading a file.
        if (!TestServer.IsReplayMode) {
          Assert.IsTrue(bytes.Length > 0);
        }
      }
    }

    [TestMethod]
    public async Task DownloadToFileFileNameVertexTest()
    {
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadToFileAsync(fileName: "fileName", outputPath: "outputPath");
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadToFileFileNameGeminiTest()
    {
      await geminiClient.Files.DownloadToFileAsync(
          fileName: fileUri,
          outputPath: "output.mp4"
      );
    }

    [TestMethod]
    public async Task DownloadFileVertexTest()
    {
      var file = new Google.GenAI.Types.File { Name = "Name"};
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadAsync(file: file);
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadFileGeminiTest()
    {
      var file = new Google.GenAI.Types.File {
        Name = fileUri
      };
      await geminiClient.Files.DownloadAsync(file: file);
    }

    [TestMethod]
    public async Task DownloadVideoGeminiTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = fileUri
      };
      var stream = await geminiClient.Files.DownloadAsync(
          video: video
      );
      using (MemoryStream memoryStream = new MemoryStream()) {
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        byte[] bytes = memoryStream.ToArray();
        // Replay mode does not return any bytes when downloading a file.
        if (!TestServer.IsReplayMode) {
          Assert.IsTrue(bytes.Length > 0);
        }
      }
    }

    [TestMethod]
    public async Task DownloadVideoVertexTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = "fileName"
      };
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadAsync(video: video);
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadGeneratedVideoGeminiTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = fileUri
      };
      var generatedVideo = new Google.GenAI.Types.GeneratedVideo { Video = video };
      var stream = await geminiClient.Files.DownloadAsync(
          generatedVideo: generatedVideo
      );
      using (MemoryStream memoryStream = new MemoryStream()) {
        await stream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;
        byte[] bytes = memoryStream.ToArray();
        // Replay mode does not return any bytes when downloading a file.
        if (!TestServer.IsReplayMode) {
          Assert.IsTrue(bytes.Length > 0);
        }
      }
    }

    [TestMethod]
    public async Task DownloadGeneratedVideoVertexTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = "fileName"
      };
      var generatedVideo = new Google.GenAI.Types.GeneratedVideo { Video = video };
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadAsync(generatedVideo: generatedVideo);
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadToFileFileVertexTest()
    {
      var file = new Google.GenAI.Types.File { Name = "Name"};
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadToFileAsync(file: file, outputPath: "outputPath");
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadToFileFileGeminiTest()
    {
      var file = new Google.GenAI.Types.File {
        Name = fileUri
      };
      await geminiClient.Files.DownloadToFileAsync(file: file, outputPath: "output.mp4");
    }

    [TestMethod]
    public async Task DownloadToFileVideoVertexTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = fileUri
      };
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadToFileAsync(video: video, outputPath: "outputPath");
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadToFileVideoGeminiTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = fileUri
      };
      await geminiClient.Files.DownloadToFileAsync(video: video, outputPath: "output.mp4");
    }

    [TestMethod]
    public async Task DownloadToFileGeneratedVideoVertexTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = fileUri
      };
      var generatedVideo = new Google.GenAI.Types.GeneratedVideo { Video = video };
      var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
      {
        await vertexClient.Files.DownloadToFileAsync(generatedVideo: generatedVideo, outputPath: "outputPath");
      });

      StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
    }

    [TestMethod]
    public async Task DownloadToFileGeneratedVideoGeminiTest()
    {
      var video = new Google.GenAI.Types.Video {
        Uri = fileUri
      };
      var generatedVideo = new Google.GenAI.Types.GeneratedVideo { Video = video };
      await geminiClient.Files.DownloadToFileAsync(generatedVideo: generatedVideo, outputPath: "output.mp4");
    }

}
