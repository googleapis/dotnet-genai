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
public class CancelBatchTest
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
        modelName = "gemini-2.5-flash";
    }

    [TestMethod]
    public async Task CancelBatchJobVertexTest()
    {
        var src = new BatchJobSource
        {
            GcsUri = new List<string> { "gs://unified-genai-tests/batches/input/generate_content_requests.jsonl" },
            Format = "jsonl"
        };
        var config = new CreateBatchJobConfig
        {
            DisplayName = "test_batch_gcs_cancel",
            Dest = new BatchJobDestination
            {
                GcsUri = "gs://unified-genai-tests/batches/output",
                Format = "jsonl"
            }
        };
        var response = await enterpriseClient.Batches.CreateAsync(modelName, src, config);
        await enterpriseClient.Batches.CancelAsync(response.Name);
    }

    [TestMethod]
    public async Task CancelBatchJobGeminiTest()
    {
        var src = new BatchJobSource
        {
            FileName = "files/oi5wupwi0y7e"
        };
        var config = new CreateBatchJobConfig
        {
            DisplayName = "test_batch_file_cancel"
        };
        var createResponse = await geminiClient.Batches.CreateAsync(modelName, src, config);
        await geminiClient.Batches.CancelAsync(createResponse.Name);
    }
}
