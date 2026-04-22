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
public class EmbeddingBatchTest
{
    private static TestServerProcess? _server;
    private Client enterpriseClient;
    private Client geminiClient;
    private string modelName;
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
        var geminiClientHttpOptions = new HttpOptions
        {
            Headers = new Dictionary<string, string> { { "Test-Name",
                                                    $"{GetType().Name}.{TestContext.TestName}" } },
            BaseUrl = "http://localhost:1453"
        };
        var enterpriseClientHttpOptions = new HttpOptions
        {
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
        modelName = "gemini-embedding-001";
    }

    [TestMethod]
    public async Task CreateEmbeddingBatchWithInlinedRequestsGeminiTest()
    {
        var src = new EmbeddingsBatchJobSource
        {
            InlinedRequests = new EmbedContentBatch
            {
                Config = new EmbedContentConfig { OutputDimensionality = 64 },
                Contents = new List<Content>
                {
                    new Content { Parts = new List<Part> { new Part { Text = "1" } } },
                    new Content { Parts = new List<Part> { new Part { Text = "2" } } },
                    new Content { Parts = new List<Part> { new Part { Text = "3" } } },
                }
            }
        };
        var config = new CreateEmbeddingsBatchJobConfig
        {
            DisplayName = "test_batch_embedding_inlined"
        };

        var response = await geminiClient.Batches.CreateEmbeddingsAsync(modelName, src, config);
        Assert.IsNotNull(response);
        Assert.IsTrue(response.Name.StartsWith("batches/"));
    }

    [TestMethod]
    public async Task CreateEmbeddingBatchWithInlinedRequestsVertexTest()
    {
        var src = new EmbeddingsBatchJobSource
        {
            InlinedRequests = new EmbedContentBatch
            {
                Config = new EmbedContentConfig { OutputDimensionality = 64 },
                Contents = new List<Content>
                {
                    new Content { Parts = new List<Part> { new Part { Text = "1" } } },
                }
            }
        };
        await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
        {
            await enterpriseClient.Batches.CreateEmbeddingsAsync(modelName, src, null);
        });
    }

    [TestMethod]
    public async Task CreateEmbeddingBatchWithFileGeminiTest()
    {
        var src = new EmbeddingsBatchJobSource
        {
            FileName = "files/lqff5js4w14b",
        };
        var config = new CreateEmbeddingsBatchJobConfig
        {
            DisplayName = "test_batch_embedding_file"
        };
        var response = await geminiClient.Batches.CreateEmbeddingsAsync(modelName, src, config);
        Assert.IsNotNull(response);
        Assert.IsTrue(response.Name.StartsWith("batches/"));
    }

    [TestMethod]
    public async Task CreateEmbeddingBatchWithFileVertexTest()
    {
        var src = new EmbeddingsBatchJobSource
        {
            FileName = "files/lqff5js4w14b",
        };
        await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
        {
            await enterpriseClient.Batches.CreateEmbeddingsAsync(modelName, src, null);
        });
    }
}

