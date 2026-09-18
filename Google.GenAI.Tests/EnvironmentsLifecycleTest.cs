/*
 * Copyright 2026 Google LLC
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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Gaos;
using Google.GenAI.Gaos.Models.Components;
using Google.GenAI.Gaos.Models.Requests;
using Google.GenAI.Gaos.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests
{
    [TestClass]
    public class EnvironmentsLifecycleTest
    {
        private class MockHttpClient : IGenAIHttpClient
        {
            public Func<HttpRequestMessage, Task<HttpResponseMessage>> Handler { get; set; } =
                _ => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));

            public List<HttpRequestMessage> Requests { get; } = new List<HttpRequestMessage>();

            public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
            {
                Requests.Add(request);
                return await Handler(request);
            }

            public Task<HttpRequestMessage> CloneAsync(HttpRequestMessage request)
            {
                var clone = new HttpRequestMessage(request.Method, request.RequestUri);
                if (request.Content != null)
                {
                    clone.Content = request.Content;
                }
                foreach (var header in request.Headers)
                {
                    clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
                return Task.FromResult(clone);
            }
        }

        [TestMethod]
        public void Client_Exposes_Environments_Files()
        {
            var client = new Client(apiKey: "test-api-key");
            Assert.IsNotNull(client.Environments);
            Assert.IsNotNull(client.Environments.Files);
        }

        [TestMethod]
        public async Task EnvironmentsCrudLifecycle_Success()
        {
            var mockClient = new MockHttpClient();
            var envJson = "{\"id\": \"env-123\", \"name\": \"environments/env-123\", \"status\": \"active\", \"display_name\": \"Test Env\"}";
            var listJson = "{\"environments\": [{\"id\": \"env-123\", \"name\": \"environments/env-123\"}], \"next_page_token\": \"\"}";

            mockClient.Handler = (request) =>
            {
                var uri = request.RequestUri!.ToString();
                if (request.Method == HttpMethod.Post || request.Method == HttpMethod.Put)
                {
                    Assert.IsTrue(uri.Contains("/v1alpha/environments"));
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(envJson, Encoding.UTF8, "application/json")
                    });
                }
                else if (request.Method == HttpMethod.Get)
                {
                    if (uri.Contains("page_size="))
                    {
                        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(listJson, Encoding.UTF8, "application/json")
                        });
                    }
                    else
                    {
                        Assert.IsTrue(uri.EndsWith("/v1alpha/environments/env-123"));
                        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(envJson, Encoding.UTF8, "application/json")
                        });
                    }
                }
                else if (request.Method == HttpMethod.Delete)
                {
                    Assert.IsTrue(uri.EndsWith("/v1alpha/environments/env-123"));
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent("{}", Encoding.UTF8, "application/json")
                    });
                }

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
            };

            var sdkConfig = new SDKConfig(mockClient)
            {
                ApiVersion = "v1alpha",
                ServerUrl = "https://generativelanguage.googleapis.com",
                SecuritySource = () => new Security { ApiKey = "test-key" }
            };
            Google.GenAI.Gaos.IEnvironments environments = new Google.GenAI.Gaos.Environments(sdkConfig);

            // 1. Create
            var createRes = await environments.CreateEnvironmentAsync(new Google.GenAI.Gaos.Models.Environments.CreateEnvironmentRequest());
            Assert.IsNotNull(createRes.Environment);
            Assert.AreEqual("env-123", createRes.Environment.Id);

            // 2. List
            var listRes = await environments.ListEnvironmentsAsync(pageSize: 10);
            Assert.IsNotNull(listRes.ListEnvironmentsResponseValue);
            Assert.IsNotNull(listRes.ListEnvironmentsResponseValue.Environments);
            Assert.AreEqual(1, listRes.ListEnvironmentsResponseValue.Environments.Count);

            // 3. Get with clean ID
            var getRes = await environments.GetEnvironmentAsync("env-123");
            Assert.IsNotNull(getRes.Environment);
            Assert.AreEqual("env-123", getRes.Environment.Id);

            // 4. Get with 'environments/' prefix
            var getResPrefix = await environments.GetEnvironmentAsync("environments/env-123");
            Assert.IsNotNull(getResPrefix.Environment);
            Assert.AreEqual("env-123", getResPrefix.Environment.Id);

            // 5. Delete with clean ID
            var deleteRes = await environments.DeleteEnvironmentAsync("env-123");
            Assert.IsNotNull(deleteRes.Empty);

            // 6. Delete with 'environments/' prefix
            var deleteResPrefix = await environments.DeleteEnvironmentAsync("environments/env-123");
            Assert.IsNotNull(deleteResPrefix.Empty);
        }

        [TestMethod]
        public async Task EnvironmentsFilesLifecycle_Success()
        {
            var mockClient = new MockHttpClient();
            var uploadUrl = "https://upload.googleapis.com/upload/session123";
            var expectedBytes = Encoding.UTF8.GetBytes("File content for download");
            var listFilesJson = "{\"files\": [{\"name\": \"environments/env-123/files/test.txt\", \"path\": \"test.txt\", \"size_bytes\": 12}], \"next_page_token\": \"\"}";

            mockClient.Handler = async (request) =>
            {
                var uri = request.RequestUri!.ToString();
                if (request.Method == HttpMethod.Put)
                {
                    Assert.IsTrue(uri.Contains("/upload/v1alpha/environments/env-123/files/test.txt?overwrite=true&extract=false"));
                    Assert.AreEqual("resumable", request.Headers.GetValues("X-Goog-Upload-Protocol").FirstOrDefault());
                    Assert.AreEqual("start", request.Headers.GetValues("X-Goog-Upload-Command").FirstOrDefault());
                    Assert.AreEqual("12", request.Headers.GetValues("X-Goog-Upload-Header-Content-Length").FirstOrDefault());
                    Assert.AreEqual("text/plain", request.Headers.GetValues("X-Goog-Upload-Header-Content-Type").FirstOrDefault());

                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Headers.Add("x-goog-upload-url", uploadUrl);
                    response.Headers.Add("x-goog-upload-status", "active");
                    return response;
                }
                else if (request.Method == HttpMethod.Post)
                {
                    Assert.AreEqual(uploadUrl, uri);
                    Assert.AreEqual("upload, finalize", request.Headers.GetValues("X-Goog-Upload-Command").FirstOrDefault());
                    Assert.AreEqual("0", request.Headers.GetValues("X-Goog-Upload-Offset").FirstOrDefault());

                    var bytes = await request.Content!.ReadAsByteArrayAsync();
                    Assert.AreEqual("Hello World!", Encoding.UTF8.GetString(bytes));

                    var jsonResponse = "{\"name\": \"environments/env-123/files/test.txt\", \"path\": \"test.txt\", \"size_bytes\": 12}";
                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                    };
                }
                else if (request.Method == HttpMethod.Get)
                {
                    if (uri.Contains("alt=media"))
                    {
                        Assert.IsTrue(uri.Contains("/v1alpha/environments/env-123/files/test.txt?alt=media"));
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(expectedBytes)
                        };
                    }
                    else
                    {
                        Assert.IsTrue(uri.Contains("/v1alpha/environments/env-123/files"));
                        Assert.IsFalse(uri.Contains("/files//"));
                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(listFilesJson, Encoding.UTF8, "application/json")
                        };
                    }
                }

                return new HttpResponseMessage(HttpStatusCode.NotFound);
            };

            var sdkConfig = new SDKConfig(mockClient)
            {
                ApiVersion = "v1alpha",
                ServerUrl = "https://generativelanguage.googleapis.com",
                SecuritySource = () => new Security { ApiKey = "test-key" }
            };
            Google.GenAI.Gaos.IFiles files = new Google.GenAI.Gaos.Files(sdkConfig);

            // 1. Upload
            var contentBytes = Encoding.UTF8.GetBytes("Hello World!");
            var uploadResponse = await files.UploadAsync("env-123", "test.txt", contentBytes, "text/plain");
            Assert.IsNotNull(uploadResponse.Files);
            Assert.IsNotNull(uploadResponse.Files.Files);
            Assert.AreEqual(1, uploadResponse.Files.Files.Count);
            Assert.AreEqual("environments/env-123/files/test.txt", uploadResponse.Files.Files[0].Name);
            Assert.AreEqual("test.txt", uploadResponse.Files.Files[0].Path);
            Assert.AreEqual("12", uploadResponse.Files.Files[0].SizeBytes);

            // 2. List with clean ID
            var listResponse = await files.ListAsync("env-123");
            Assert.IsNotNull(listResponse.GetEnvironmentFilesResponseValue);
            Assert.IsNotNull(listResponse.GetEnvironmentFilesResponseValue.Files);
            Assert.AreEqual(1, listResponse.GetEnvironmentFilesResponseValue.Files.Count);

            // 3. List with prefix
            var listResponsePrefix = await files.ListAsync("environments/env-123");
            Assert.IsNotNull(listResponsePrefix.GetEnvironmentFilesResponseValue);
            Assert.AreEqual(1, listResponsePrefix.GetEnvironmentFilesResponseValue.Files!.Count);

            // 4. Download with clean ID
            var downloadBytes = await files.DownloadAsync("env-123", "test.txt");
            CollectionAssert.AreEqual(expectedBytes, downloadBytes);

            // 5. Download with prefix
            var downloadBytesPrefix = await files.DownloadAsync("environments/env-123", "test.txt");
            CollectionAssert.AreEqual(expectedBytes, downloadBytesPrefix);
        }

        [TestMethod]
        public async Task UploadAsync_ExtractArchive_Success()
        {
            var mockClient = new MockHttpClient();
            var uploadUrl = "https://upload.googleapis.com/upload/session456";

            mockClient.Handler = (request) =>
            {
                if (request.Method == HttpMethod.Put)
                {
                    Assert.IsTrue(request.RequestUri!.ToString().Contains("/upload/v1alpha/environments/test-env/files/archive.tar.gz?overwrite=true&extract=true"));
                    Assert.AreEqual("resumable", request.Headers.GetValues("X-Goog-Upload-Protocol").FirstOrDefault());
                    Assert.AreEqual("start", request.Headers.GetValues("X-Goog-Upload-Command").FirstOrDefault());

                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Headers.Add("X-Goog-Upload-URL", uploadUrl);
                    response.Headers.Add("x-goog-upload-status", "active");
                    return Task.FromResult(response);
                }
                else if (request.Method == HttpMethod.Post)
                {
                    Assert.AreEqual(uploadUrl, request.RequestUri!.ToString());
                    var jsonResponse = "{\"files\": [{\"name\": \"environments/test-env/files/a.txt\", \"path\": \"a.txt\", \"size_bytes\": 5}, {\"name\": \"environments/test-env/files/b.txt\", \"path\": \"b.txt\", \"size_bytes\": 10}]}";
                    var response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json")
                    };
                    return Task.FromResult(response);
                }

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
            };

            var sdkConfig = new SDKConfig(mockClient)
            {
                ApiVersion = "v1alpha",
                ServerUrl = "https://generativelanguage.googleapis.com",
                SecuritySource = () => new Security { ApiKey = "test-key" }
            };
            Google.GenAI.Gaos.IFiles files = new Google.GenAI.Gaos.Files(sdkConfig);

            var tempFile = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(tempFile, new byte[] { 1, 2, 3, 4 });
                var req = new UploadEnvironmentFileRequest
                {
                    Environment = "test-env",
                    FilePath = tempFile,
                    Path = "archive.tar.gz",
                    Extract = true
                };

                var uploadResponse = await files.UploadAsync(req);

                Assert.IsNotNull(uploadResponse.Files);
                Assert.IsNotNull(uploadResponse.Files.Files);
                Assert.AreEqual(2, uploadResponse.Files.Files.Count);
                Assert.AreEqual("environments/test-env/files/a.txt", uploadResponse.Files.Files[0].Name);
                Assert.AreEqual("a.txt", uploadResponse.Files.Files[0].Path);
                Assert.AreEqual("5", uploadResponse.Files.Files[0].SizeBytes);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }
    }
}
