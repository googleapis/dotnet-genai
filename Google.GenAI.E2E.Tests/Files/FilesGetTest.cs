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
public class FilesGetTest
{
    private static TestServerProcess? _server;
    private Client vertexClient;
    private Client geminiClient;
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

    }

    [TestMethod]
    public async Task GetVertexTest()
    {
       var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
       {
         await vertexClient.Files.GetAsync(name: "fileName");
       });

       StringAssert.Contains(ex.Message, "This method is only supported in Gemini Developer API mode");
    }

    [TestMethod]
    public async Task GetFullFileNameGeminiTest()
    {
       string fileName = "files/s0pa54alni6w";
       var response = await geminiClient.Files.GetAsync(name: fileName);

       Assert.IsInstanceOfType(response, typeof(Google.GenAI.Types.File));
       Assert.AreEqual(response.Name, fileName);
    }

    [TestMethod]
    public async Task GetShortFileNameGeminiTest()
    {
       string fileName = "s0pa54alni6w";
       var response = await geminiClient.Files.GetAsync(name: fileName);

       string fullFileName = "files/" + fileName;
       Assert.IsInstanceOfType(response, typeof(Google.GenAI.Types.File));
       Assert.AreEqual(response.Name, fullFileName);
    }

}
