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
public class EmbedContentTest {
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
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "text-embedding-004";
  }

  [TestMethod]
  public async Task EmbedContentSimpleTextVertexTest() {
    var contents = new List<Content> {
      new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
    };
    var vertexResponse = await vertexClient.Models.EmbedContentAsync(
        model: modelName, contents: contents, config: null);

    Assert.IsNotNull(vertexResponse.Embeddings);
  }

  [TestMethod]
  public async Task EmbedContentSimpleTextGeminiTest() {
    var contents = new List<Content> {
      new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
    };
    var geminiResponse = await geminiClient.Models.EmbedContentAsync(
        model: modelName, contents: contents, config: null);

    Assert.IsNotNull(geminiResponse.Embeddings);
  }

  [TestMethod]
  public async Task EmbedContentSingleStringVertexTest() {
    var vertexResponse = await vertexClient.Models.EmbedContentAsync(
        model: modelName, contents: "What is your name?", config: null);

    Assert.IsNotNull(vertexResponse.Embeddings);
  }

  [TestMethod]
  public async Task EmbedContentSingleStringGeminiTest() {
    var geminiResponse = await geminiClient.Models.EmbedContentAsync(
        model: modelName, contents: "What is your name?", config: null);

    Assert.IsNotNull(geminiResponse.Embeddings);
  }

  [TestMethod]
  public async Task EmbedContentMultiTextVertexTest() {
    var contents = new List<Content> {
      new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } },
      new Content { Parts = new List<Part> { new Part { Text = "I am a model." } } }
    };
    var config = new EmbedContentConfig { OutputDimensionality = 10, Title = "test_title",
                                         TaskType = "RETRIEVAL_DOCUMENT" };
    var vertexResponse =
        await vertexClient.Models.EmbedContentAsync(model: modelName, contents: contents, config: config);

    Assert.IsNotNull(vertexResponse.Embeddings);
    Assert.AreEqual(2, vertexResponse.Embeddings.Count);
  }

  [TestMethod]
  public async Task EmbedContentMultiTextGeminiTest() {
    var contents = new List<Content> {
      new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } },
      new Content { Parts = new List<Part> { new Part { Text = "I am a model." } } }
    };
    var config = new EmbedContentConfig { OutputDimensionality = 10, Title = "test_title",
                                         TaskType = "RETRIEVAL_DOCUMENT" };
    var geminiResponse =
        await geminiClient.Models.EmbedContentAsync(model: modelName, contents: contents, config: config);

    Assert.IsNotNull(geminiResponse.Embeddings);
    Assert.AreEqual(2, geminiResponse.Embeddings.Count);
  }

  [TestMethod]
  public async Task EmbedContentMimeTypeNotSupportedGeminiTest()
  {
      var contents = new List<Content> {
          new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
      };
      var config = new EmbedContentConfig
      {
          OutputDimensionality = 10,
          MimeType = "text/plain"
      };
      var exception = await Assert.ThrowsExceptionAsync<NotSupportedException>(
          () => geminiClient.Models.EmbedContentAsync(model: modelName, contents: contents, config: config));

      Assert.IsTrue(exception.Message.Contains("mimeType parameter is not supported"));
  }

  [TestMethod]
  public async Task EmbedContentAutoTruncateNotSupportedGeminiTest()
  {
      var contents = new List<Content> {
          new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
      };
      var config = new EmbedContentConfig
      {
          OutputDimensionality = 10,
          AutoTruncate = true
      };
      var exception = await Assert.ThrowsExceptionAsync<NotSupportedException>(
          () => geminiClient.Models.EmbedContentAsync(model: modelName, contents: contents, config: config));

      Assert.IsTrue(exception.Message.Contains("autoTruncate parameter is not supported"));
  }

  [TestMethod]
  public async Task EmbedContentNewApiTextOnlyWithConfigVertexTest()
  {
      var contents = new List<Content> {
        new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
      };
      var config = new EmbedContentConfig {
          OutputDimensionality = 10,
          Title = "test_title",
          TaskType = "RETRIEVAL_DOCUMENT",
          AutoTruncate = true,
          HttpOptions = new HttpOptions {
              Headers = new Dictionary<string, string> { { "test", "headers" } }
          }
      };
      var vertexResponse = await vertexClient.Models.EmbedContentAsync(
          model: "gemini-embedding-2-exp-11-2025", contents: contents, config: config);

      Assert.IsNotNull(vertexResponse);
      Assert.IsNotNull(vertexResponse.Embeddings);
  }

  [TestMethod]
  public async Task EmbedContentNewApiTextOnlyWithConfigGeminiTest()
  {
      var contents = new List<Content> {
          new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
      };
      var config = new EmbedContentConfig {
          OutputDimensionality = 10,
          Title = "test_title",
          TaskType = "RETRIEVAL_DOCUMENT",
          AutoTruncate = true,
          HttpOptions = new HttpOptions {
              Headers = new Dictionary<string, string> { { "test", "headers" } }
          }
      };

      var exception = await Assert.ThrowsExceptionAsync<NotSupportedException>(
          () => geminiClient.Models.EmbedContentAsync(model: "gemini-embedding-2-exp-11-2025", contents: contents, config: config));

      Assert.IsTrue(exception.Message.Contains("autoTruncate parameter is not supported"));
  }

    [TestMethod]
    public async Task EmbedContentNewApiTextOnlyVertexTest()
    {
        var contents = new List<Content> {
            new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
        };
        var config = new EmbedContentConfig {
          OutputDimensionality = 100,
        };
        var vertexResponse = await vertexClient.Models.EmbedContentAsync(
            model: "gemini-embedding-2-exp-11-2025", contents: contents, config: config);

        Assert.IsNotNull(vertexResponse);
        Assert.IsNotNull(vertexResponse.Embeddings);
    }

    [TestMethod]
    public async Task EmbedContentNewApiMaasVertexTest()
    {
        var contents = new List<Content> {
            new Content { Parts = new List<Part> { new Part { Text = "What is your name?" } } }
        };
        var config = new EmbedContentConfig {
          OutputDimensionality = 100,
        };
        var vertexResponse = await vertexClient.Models.EmbedContentAsync(
            model: "publishers/intfloat/models/multilingual-e5-large-instruct-maas", contents: contents, config: config);

        Assert.IsNotNull(vertexResponse);
        Assert.IsNotNull(vertexResponse.Embeddings);
    }

    [TestMethod]
    public async Task EmbedContentNewApiGcsImageVertexTest()
    {
        var contents = new List<Content> {
            new Content {
                Parts = new List<Part> {
                    new Part { Text = "Similar things to the following image:" },
                    new Part {
                        FileData = new FileData {
                            MimeType = "image/png",
                            FileUri = "gs://cloud-samples-data/generative-ai/image/a-man-and-a-dog.png"
                        }
                    }
                }
            }
        };
        var config = new EmbedContentConfig {
            OutputDimensionality = 10,
            Title = "test_title",
            TaskType = "RETRIEVAL_DOCUMENT",
            HttpOptions = new HttpOptions {
                Headers = new Dictionary<string, string> { { "test", "headers" } }
            }
        };
        var vertexResponse = await vertexClient.Models.EmbedContentAsync(
            model: "gemini-embedding-2-exp-11-2025", contents: contents, config: config);

        Assert.IsNotNull(vertexResponse);
        Assert.IsNotNull(vertexResponse.Embeddings);
    }

    [TestMethod]
    public async Task EmbedContentNewApiListOfContentsVertexTest()
    {
        var contents = new List<Content> {
            new Content { Parts = new List<Part> { new Part { Text = "hello" } } },
            new Content { Parts = new List<Part> { new Part { Text = "world" } } }
        };
        var exception = await Assert.ThrowsExceptionAsync<ArgumentException>(
            () => vertexClient.Models.EmbedContentAsync(model: "gemini-embedding-2-exp-11-2025", contents: contents, config: null));

        Assert.IsTrue(exception.Message.Contains("The embedContent API for this model only supports one content at a time."));
    }
}
