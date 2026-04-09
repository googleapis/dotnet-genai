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
public class ListTuningsTest
{
    private static TestServerProcess? _server;
    private Client vertexClient;
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
        modelName = "gemini-2.5-flash";
    }

    [TestMethod]
    public async Task ListTuningsVertexTest()
    {
        // Create two tuning jobs.
        var trainingDataset = new TuningDataset {
          GcsUri = "gs://cloud-samples-data/ai-platform/generative_ai/gemini-1_5/text/sft_train_data.jsonl"
        };
        var config = new CreateTuningJobConfig {
          EpochCount = 1
        };
        var firstTuningJob = await vertexClient.Tunings.TuneAsync(modelName, trainingDataset, config);
        var secondTuningJob = await vertexClient.Tunings.TuneAsync(modelName, trainingDataset, config);

        var pager = await vertexClient.Tunings.ListAsync(new ListTuningJobsConfig { PageSize = 1 });

        int count = 0;
        await foreach(var item in pager)
        {
            count++;
            if (count >= 2)
            {
                break;
            }
        }

        Assert.IsTrue(count >= 2);
        Assert.AreEqual(1, pager.PageSize);
    }

    [TestMethod]
    public async Task ListTuningsGeminiTest()
    {
        // throws exception, unsupported
        var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
            await geminiClient.Tunings.ListAsync(new ListTuningJobsConfig { PageSize = 1 });
        });

        StringAssert.Contains(ex.Message, "only supported in the Vertex AI client");
    }
}