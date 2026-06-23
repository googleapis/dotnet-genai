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
using Google.GenAI.Gaos.Models.Interactions;
using Google.GenAI.Gaos.Models.Requests;
using Google.GenAI.Types;
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
        public async Task TestInteractions_LegacyLyriaNonStreaming()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            var client = new Client(vertexAI: false, apiKey: "my-key", clientOptions: options);

            fakeHandler.Handler = (req) =>
            {
                var legacyJson = @"{
                    ""id"": ""my-lyria-id"",
                    ""model"": ""lyria-3-pro-preview"",
                    ""outputs"": [
                        {
                            ""parts"": [
                                {
                                    ""text"": ""legacy lyria response text""
                                }
                            ]
                        }
                    ]
                }";
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(legacyJson, Encoding.UTF8, "application/json")
                };
                return Task.FromResult(response);
            };

            var body = CreateInteractionRequestBody.CreateCreateModelInteraction(new CreateModelInteraction
            {
                Model = "lyria-3-pro-preview"
            });
            var response = await client.Interactions.CreateAsync(body);
            var interaction = response.Interaction;

            Assert.IsNotNull(interaction);
            Assert.AreEqual("my-lyria-id", interaction.Id);
            Assert.AreEqual("lyria-3-pro-preview", interaction.Model?.ToString());
            
            // Outputs should be removed, and steps should be populated
            Assert.IsNotNull(interaction.Steps);
            Assert.AreEqual(1, interaction.Steps.Count);
            var step = interaction.Steps[0];
            Assert.IsNotNull(step.ModelOutputStep);
            Assert.AreEqual("model_output", step.ModelOutputStep.Type);
            Assert.IsNotNull(step.ModelOutputStep.Content);
            Assert.AreEqual(1, step.ModelOutputStep.Content.Count);
            Assert.AreEqual("legacy lyria response text", step.ModelOutputStep.Content[0].TextContent!.Text);
        }

        [TestMethod]
        public async Task TestInteractions_LegacyLyriaStreaming()
        {
            var fakeHandler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(fakeHandler);

            var options = new ClientOptions
            {
                HttpClientFactory = () => httpClient
            };

            var client = new Client(vertexAI: false, apiKey: "my-key", clientOptions: options);

            fakeHandler.Handler = (req) =>
            {
                // Streaming responses separated by newlines, with legacy event names and shapes
                var ssePayload = "event: interaction.start\n" +
                                 "data: {\"interaction\": {\"id\": \"my-id\", \"model\": \"lyria-3-pro-preview\", \"outputs\": [{\"parts\": [{\"text\": \"starting output\"}]}]}}\n\n" +
                                 "event: content.start\n" +
                                 "data: {\"content\": {\"parts\": [{\"text\": \"delta text 1\"}]}}\n\n" +
                                 "event: content.delta\n" +
                                 "data: {\"delta\": {\"parts\": [{\"text\": \"delta text 2\"}]}}\n\n" +
                                 "event: content.stop\n" +
                                 "data: {\"index\": 0}\n\n" +
                                 "event: interaction.complete\n" +
                                 "data: {\"interaction\": {\"id\": \"my-id\", \"model\": \"lyria-3-pro-preview\", \"outputs\": [{\"parts\": [{\"text\": \"starting output\"}]}]}}\n\n";

                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(ssePayload, Encoding.UTF8, "text/event-stream")
                };
                return Task.FromResult(response);
            };

            var body = CreateInteractionRequestBody.CreateCreateModelInteraction(new CreateModelInteraction
            {
                Model = "lyria-3-pro-preview"
            });
            var response = await client.Interactions.CreateAsync(body);
            var stream = response.InteractionSSEStreamEvent;
            Assert.IsNotNull(stream);

            var events = new List<InteractionSSEStreamEvent>();
            while (!stream.IsClosed)
            {
                var ev = await stream.Next();
                if (ev != null)
                {
                    events.Add(ev);
                }
            }

            Assert.AreEqual(5, events.Count);

            // 1. interaction.start -> interaction.created, outputs -> steps
            var ev1 = events[0];
            Assert.IsNotNull(ev1.GetDataInteractionCreated());
            var it1 = ev1.GetDataInteractionCreated()!.Interaction;
            Assert.IsNotNull(it1.Steps);
            Assert.AreEqual(1, it1.Steps.Count);
            Assert.AreEqual("starting output", it1.Steps[0].ModelOutputStep!.Content![0].TextContent!.Text);

            // 2. content.start -> step.start, content -> step
            var ev2 = events[1];
            Assert.IsNotNull(ev2.GetDataStepStart());
            var s2 = ev2.GetDataStepStart()!.Step;
            Assert.AreEqual("model_output", s2.ModelOutputStep!.Type);
            Assert.AreEqual("delta text 1", s2.ModelOutputStep!.Content![0].TextContent!.Text);

            // 3. content.delta -> step.delta
            var ev3 = events[2];
            Assert.IsNotNull(ev3.GetDataStepDelta());
            Assert.AreEqual("step.delta", ev3.Data.StepDelta!.EventType);

            // 4. content.stop -> step.stop
            var ev4 = events[3];
            Assert.IsNotNull(ev4.GetDataStepStop());
            Assert.AreEqual("step.stop", ev4.Data.StepStop!.EventType);

            // 5. interaction.complete -> interaction.completed
            var ev5 = events[4];
            Assert.IsNotNull(ev5.GetDataInteractionCompleted());
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
    }
}
