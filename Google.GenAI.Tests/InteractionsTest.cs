// Copyright 2026 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.GenAI.Interactions.Models.Interactions;
using Google.GenAI.Interactions.Models.Requests;
using Google.GenAI.Types;
using Task = System.Threading.Tasks.Task;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Google.GenAI.Tests
{
    [TestClass]
    public class InteractionsTest
    {
        private class FakeHttpMessageHandler : HttpMessageHandler
        {
            public Func<HttpRequestMessage, Task<HttpResponseMessage>> Handler { get; set; } = default!;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Handler(request);
            }
        }

        [TestMethod]
        public async Task TestInteractions_GeminiUrlAndAuth()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            var client = new Client(vertexAI: false, apiKey: "my-gemini-key", clientOptions: options);

            HttpRequestMessage? capturedRequest = null;
            fakeHandler.Handler = (req) =>
            {
                capturedRequest = req;
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            };

            // Call interactions endpoint
            var body = CreateInteractionRequestBody.CreateCreateModelInteraction(new CreateModelInteraction
            {
                Model = "gemini-2.5-flash"
            });
            await client.Interactions.CreateAsync(body);

            Assert.IsNotNull(capturedRequest);
            // Verify path/URL
            Assert.AreEqual("https://generativelanguage.googleapis.com/v1beta/interactions", capturedRequest.RequestUri?.AbsoluteUri);
            // Verify header
            Assert.IsTrue(capturedRequest.Headers.Contains("x-goog-api-key"));
            Assert.AreEqual("my-gemini-key", string.Join("", capturedRequest.Headers.GetValues("x-goog-api-key")));
            // Verify default API Revision
            Assert.IsTrue(capturedRequest.Headers.Contains("Api-Revision"));
            Assert.AreEqual("2026-05-20", string.Join("", capturedRequest.Headers.GetValues("Api-Revision")));
        }

        [TestMethod]
        public async Task TestInteractions_VertexUrlAndAuth()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            var mockCredential = new Mock<ICredential>();
            mockCredential
                .Setup(c => c.GetAccessTokenForRequestAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("my-oauth-token");

            var httpOptions = new HttpOptions
            {
                Headers = new Dictionary<string, string>
                {
                    { "x-goog-user-project", "my-quota-project" },
                    { "Api-Revision", "2026-99-99" }
                }
            };

            var client = new Client(
                vertexAI: true,
                project: "my-project",
                location: "us-central1",
                credential: mockCredential.Object,
                httpOptions: httpOptions,
                clientOptions: options);

            HttpRequestMessage? capturedRequest = null;
            fakeHandler.Handler = (req) =>
            {
                capturedRequest = req;
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            };

            // Call interactions endpoint
            var body = CreateInteractionRequestBody.CreateCreateModelInteraction(new CreateModelInteraction
            {
                Model = "gemini-2.5-flash"
            });
            await client.Interactions.CreateAsync(body);

            Assert.IsNotNull(capturedRequest);
            // Verify path/URL
            Assert.AreEqual("https://us-central1-aiplatform.googleapis.com/v1beta1/projects/my-project/locations/us-central1/interactions", capturedRequest.RequestUri?.AbsoluteUri);
            // Verify auth header
            Assert.IsTrue(capturedRequest.Headers.Contains("Authorization"));
            Assert.AreEqual("Bearer my-oauth-token", string.Join("", capturedRequest.Headers.GetValues("Authorization")));
            // Verify custom header propagates
            Assert.IsTrue(capturedRequest.Headers.Contains("x-goog-user-project"));
            Assert.AreEqual("my-quota-project", string.Join("", capturedRequest.Headers.GetValues("x-goog-user-project")));
            // Verify custom Api-Revision override
            Assert.IsTrue(capturedRequest.Headers.Contains("Api-Revision"));
            Assert.AreEqual("2026-99-99", string.Join("", capturedRequest.Headers.GetValues("Api-Revision")));
        }

        [TestMethod]
        public async Task TestWebhooks_List()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            var client = new Client(vertexAI: true, project: "my-project", location: "us-central1", credential: GoogleCredential.FromAccessToken("my-oauth-token"), clientOptions: options);

            HttpRequestMessage? capturedRequest = null;
            fakeHandler.Handler = (req) =>
            {
                capturedRequest = req;
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"webhooks\": []}", Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            };

            var result = await client.Webhooks.ListAsync();

            Assert.IsNotNull(result);
            Assert.IsNotNull(capturedRequest);
            Assert.AreEqual(HttpMethod.Get, capturedRequest.Method);
            Assert.AreEqual("https://us-central1-aiplatform.googleapis.com/v1beta1/projects/my-project/locations/us-central1/webhooks", capturedRequest.RequestUri?.AbsoluteUri);
            Assert.IsTrue(capturedRequest.Headers.Contains("Authorization"));
            Assert.AreEqual("Bearer my-oauth-token", string.Join("", capturedRequest.Headers.GetValues("Authorization")));
        }

        [TestMethod]
        public async Task TestAgents_List()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            var client = new Client(vertexAI: true, project: "my-project", location: "us-central1", credential: GoogleCredential.FromAccessToken("my-oauth-token"), clientOptions: options);

            HttpRequestMessage? capturedRequest = null;
            fakeHandler.Handler = (req) =>
            {
                capturedRequest = req;
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"agents\": []}", Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            };

            var result = await client.Agents.ListAsync();

            Assert.IsNotNull(result);
            Assert.IsNotNull(capturedRequest);
            Assert.AreEqual(HttpMethod.Get, capturedRequest.Method);
            Assert.AreEqual("https://us-central1-aiplatform.googleapis.com/v1beta1/projects/my-project/locations/us-central1/agents", capturedRequest.RequestUri?.AbsoluteUri);
            Assert.IsTrue(capturedRequest.Headers.Contains("Authorization"));
            Assert.AreEqual("Bearer my-oauth-token", string.Join("", capturedRequest.Headers.GetValues("Authorization")));
        }

        [TestMethod]
        public async Task TestInteractions_AsyncOAuthTokenAndCancellation()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            using var cts = new CancellationTokenSource();
            var mockCredential = new Mock<ICredential>();
            mockCredential
                .Setup(c => c.GetAccessTokenForRequestAsync(It.IsAny<string>(), cts.Token))
                .ReturnsAsync("my-async-oauth-token");

            var client = new Client(
                vertexAI: true,
                project: "my-project",
                location: "us-central1",
                credential: mockCredential.Object,
                clientOptions: options);

            HttpRequestMessage? capturedRequest = null;
            fakeHandler.Handler = (req) =>
            {
                capturedRequest = req;
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            };

            var body = CreateInteractionRequestBody.CreateCreateModelInteraction(new CreateModelInteraction
            {
                Model = "gemini-2.5-flash"
            });
            await client.Interactions.CreateAsync(body, cancellationToken: cts.Token);

            Assert.IsNotNull(capturedRequest);
            Assert.IsTrue(capturedRequest.Headers.Contains("Authorization"));
            Assert.AreEqual("Bearer my-async-oauth-token", string.Join("", capturedRequest.Headers.GetValues("Authorization")));
            mockCredential.Verify(c => c.GetAccessTokenForRequestAsync(It.IsAny<string>(), cts.Token), Times.Once);
        }

        [TestMethod]
        public async Task TestGaosHttpClient_ApiKeyPrecedenceOverCredentials()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);
            var mockCredential = new Mock<ICredential>();
            var gaosClient = new GaosHttpClient(httpClient, mockCredential.Object);

            HttpRequestMessage? capturedRequest = null;
            fakeHandler.Handler = (req) =>
            {
                capturedRequest = req;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://example.com/test");
            request.Headers.Add("x-goog-api-key", "my-api-key");

            await gaosClient.SendAsync(request);

            Assert.IsNotNull(capturedRequest);
            Assert.IsTrue(capturedRequest.Headers.Contains("x-goog-api-key"));
            Assert.IsFalse(capturedRequest.Headers.Contains("Authorization"));
            mockCredential.Verify(c => c.GetAccessTokenForRequestAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [TestMethod]
        public async Task TestInteractions_EmptyToken_ThrowsInvalidOperationException()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            var mockCredential = new Mock<ICredential>();
            mockCredential
                .Setup(c => c.GetAccessTokenForRequestAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string?)null);

            var client = new Client(
                vertexAI: true,
                project: "my-project",
                location: "us-central1",
                credential: mockCredential.Object,
                clientOptions: options);

            fakeHandler.Handler = (req) =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            };

            var body = CreateInteractionRequestBody.CreateCreateModelInteraction(new CreateModelInteraction
            {
                Model = "gemini-2.5-flash"
            });

            var ex = await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                () => client.Interactions.CreateAsync(body));
            Assert.IsTrue(ex.Message.Contains("Failed to obtain access token from credentials"));
        }

#if NET8_0_OR_GREATER
        [TestMethod]
        public void TestInteractions_AotAndExperimentalAttributes()
        {
            var properties = new[]
            {
                typeof(Client).GetProperty(nameof(Client.Interactions)),
                typeof(Client).GetProperty(nameof(Client.Webhooks)),
                typeof(Client).GetProperty(nameof(Client.Agents)),
                typeof(Client).GetProperty(nameof(Client.Environments)),
                typeof(Client).GetProperty(nameof(Client.Triggers)),
            };

            var targetFramework = typeof(Client).Assembly.GetCustomAttribute<System.Runtime.Versioning.TargetFrameworkAttribute>()?.FrameworkName ?? "";
            bool isNet8Assembly = targetFramework.IndexOf(".NETCoreApp", StringComparison.OrdinalIgnoreCase) >= 0;

            if (isNet8Assembly)
            {
                foreach (var prop in properties)
                {
                    Assert.IsNotNull(prop, "Property should not be null");
                    var expAttr = prop.GetCustomAttribute<ExperimentalAttribute>();
                    Assert.IsNotNull(expAttr, $"{prop.Name} should have [Experimental]");
                    Assert.AreEqual("GENAI_GAOS_001", expAttr.DiagnosticId);

                    var getter = prop.GetGetMethod();
                    Assert.IsNotNull(getter, $"{prop.Name} getter should exist");
                    var rucAttr = getter.GetCustomAttribute<RequiresUnreferencedCodeAttribute>();
                    Assert.IsNotNull(rucAttr, $"{prop.Name} getter should have [RequiresUnreferencedCode]");

                    var rdcAttr = getter.GetCustomAttribute<RequiresDynamicCodeAttribute>();
                    Assert.IsNotNull(rdcAttr, $"{prop.Name} getter should have [RequiresDynamicCode]");
                }

                // Verify Interactions.GenAI and Interactions.IGenAI
                var genAiType = typeof(Google.GenAI.Interactions.GenAI);
                Assert.IsNotNull(genAiType);

                var iGenAiType = typeof(Google.GenAI.Interactions.IGenAI);
                Assert.IsNotNull(iGenAiType);
            }
            else
            {
                // Verify [Obsolete] fallback on netstandard2.0 assembly
                foreach (var prop in properties)
                {
                    Assert.IsNotNull(prop, "Property should not be null");
                    var obsAttr = prop.GetCustomAttribute<ObsoleteAttribute>();
                    Assert.IsNotNull(obsAttr, $"{prop.Name} should have [Obsolete]");
                    StringAssert.Contains(obsAttr.Message, "is an experimental preview (GENAI_GAOS_001)");
                    StringAssert.Contains(obsAttr.Message, "issues/159");
                }

                var genAiType = typeof(Google.GenAI.Interactions.GenAI);
                Assert.IsNotNull(genAiType);

                var iGenAiType = typeof(Google.GenAI.Interactions.IGenAI);
                Assert.IsNotNull(iGenAiType);
            }
        }
#endif
    }
}

