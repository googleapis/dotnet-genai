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

using Google.Apis.Auth.OAuth2;
using Google.GenAI;
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

namespace Google.GenAI.E2E.Tests.Files
{
    [TestClass]
    public class FilesRegisterTest
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
        public async Task RegisterVertexTest()
        {
           var uris = new List<string> { "gs://bucket/file" };
           var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () =>
           {
             await vertexClient.Files.RegisterFilesAsync(uris, GoogleCredential.FromAccessToken("fake-token"));
           });

           StringAssert.Contains(ex.Message, "This method is only supported in the Gemini Developer API client");
        }

        [TestMethod]
        public async Task RegisterFilesGeminiTest()
        {
           var uris = new List<string> { "gs://tensorflow_docs/image.jpg" };
           var credential = TestServer.IsReplayMode ? GoogleCredential.FromAccessToken("fake-token") : await GoogleCredential.GetApplicationDefaultAsync();
           var response = await geminiClient.Files.RegisterFilesAsync(uris, credential);

           Assert.IsInstanceOfType(response, typeof(RegisterFilesResponse));
           Assert.IsNotNull(response.Files);
           Assert.AreEqual(1, response.Files.Count);
           // The API might return either the GCS URI or a generativelanguage URI.
           Assert.IsFalse(string.IsNullOrEmpty(response.Files[0].Uri));
           Assert.AreEqual("files/", response.Files[0].Name.Substring(0, 6));
        }

        [TestMethod]
        public async Task RegisterAndGenerateGeminiTest()
        {
            var uris = new List<string> { "gs://tensorflow_docs/image.jpg" };
            var credential = TestServer.IsReplayMode ? GoogleCredential.FromAccessToken("fake-token") : await GoogleCredential.GetApplicationDefaultAsync();
            var registerResponse = await geminiClient.Files.RegisterFilesAsync(uris, credential);

            var registeredFile = registerResponse.Files[0];

            // Wait for the file to be processed.
            var file = await geminiClient.Files.GetAsync(registeredFile.Name);
            int attempts = 0;
            while (file.State != FileState.Active && attempts < 20) {
                attempts++;
                if (!TestServer.IsReplayMode)
                {
                    await Task.Delay(5000);
                }
                file = await geminiClient.Files.GetAsync(registeredFile.Name);
            }

            var contents = new List<Content>
            {
                new Content
                {
                    Role = "user",
                    Parts = new List<Part>
                    {
                        new Part { Text = "What is in this image?" },
                        new Part { FileData = new FileData { FileUri = registeredFile.Uri, MimeType = registeredFile.MimeType } }
                    }
                }
            };

            var generateResponse = await geminiClient.Models.GenerateContentAsync(
                model: "gemini-2.5-flash",
                contents: contents
            );

            Assert.IsNotNull(generateResponse);
            Assert.IsNotNull(generateResponse.Candidates);
        }

    }
}
