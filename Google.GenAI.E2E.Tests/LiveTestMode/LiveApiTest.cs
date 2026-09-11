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
using System.Text;
using System.Threading.Tasks;
using Google.GenAI;
using GoogleType = Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests.LiveTestMode
{
    /// <summary>
    /// API-mode integration tests for the live (bidirectional WebSocket) module. These ship no
    /// recordings and are skipped in replay mode; they reach the live service through the
    /// test-server proxy. See go/genai-sdk:integration-testing.
    ///
    /// <para>This namespace holds the suites that can only run in live test mode. Live/ holds the
    /// live module tests that do ship recordings and so can also run in replay mode.</para>
    /// </summary>
    [TestClass]
    public class LiveApiTest
    {
        /// <summary>
        /// The live model served on the Gemini API. It is audio-native and rejects a TEXT
        /// response modality, so these tests request AUDIO and enable output transcription.
        /// </summary>
        private const string GeminiLiveModel = "gemini-3.1-flash-live-preview";

        /// <summary>
        /// The Vertex counterpart, audio-native in the same way, so the two backends share the
        /// whole test body.
        ///
        /// It is not served on the global endpoint, where setup is rejected with 1008 "Publisher
        /// model ... was not found"; it is available in us-central1, us-east5 and europe-west4.
        /// </summary>
        private const string VertexLiveModel = "gemini-live-2.5-flash-native-audio";

        /// <summary>
        /// Region the Vertex live model is pinned to, overriding the GOOGLE_CLOUD_LOCATION the
        /// Agent Platform wrapper sets to global for the shared suite.
        /// </summary>
        private const string VertexLiveLocation = "us-central1";

        // test-server proxy endpoints (see test-server.yml). The port must agree with the
        // location: a region resolves to <region>-aiplatform.googleapis.com, so the regional
        // endpoint is the right one for this model.
        private const string MldevProxyUrl = "http://localhost:1453";
        private const string VertexRegionalProxyUrl = "http://localhost:1454";

        /// <summary>Caps how many messages a single turn may produce before we give up.</summary>
        private const int MaxMessagesPerTurn = 200;

        private string apiKey = string.Empty;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetupClient()
        {
            // This suite ships no recordings; it exists to exercise the live backends nightly.
            if (TestServer.IsReplayMode)
            {
                Assert.Inconclusive(
                    "Skipping live API tests in replay mode: this suite ships no recordings and "
                        + "runs live in the nightly jobs.");
            }

            apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY") ?? string.Empty;
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY") ?? string.Empty;
            }
            if (string.IsNullOrEmpty(apiKey))
            {
                // The Agent Platform live job runs Vertex only, with no API key at all.
                bool vertexOnly = !string.IsNullOrEmpty(
                    System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_RUN_VERTEX_ONLY_IN_API_MODE"));
                if (!vertexOnly)
                {
                    Assert.Fail(
                        "GEMINI_API_KEY (or GOOGLE_API_KEY) must be set to run the live tests.");
                }
                // Unused: Vertex-only runs never touch the Gemini API client.
                apiKey = "unused-placeholder";
            }
        }

        /// <summary>
        /// Skips the current test when the running job has selected the other backend. Required,
        /// not cosmetic: each live job only has credentials for its own backend.
        /// </summary>
        private static void SkipIfBackendDisabled(bool isVertex)
        {
            bool vertexOnly = !string.IsNullOrEmpty(
                System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_RUN_VERTEX_ONLY_IN_API_MODE"));
            bool geminiOnly = !string.IsNullOrEmpty(
                System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_RUN_GEMINI_ONLY_IN_API_MODE"));

            if (isVertex && geminiOnly)
            {
                Assert.Inconclusive("Skipping Vertex AI live tests (GEMINI ONLY config enabled).");
            }
            else if (!isVertex && vertexOnly)
            {
                Assert.Inconclusive("Skipping Gemini API live tests (VERTEX ONLY config enabled).");
            }
        }

        private static string ModelFor(bool isVertex) =>
            isVertex ? VertexLiveModel : GeminiLiveModel;

        /// <summary>
        /// Builds a client for the given backend, routed through the matching proxy endpoint.
        /// The recording key carries the backend suffix so the two DataRows cannot collide.
        /// </summary>
        private Client CreateClient(bool isVertex)
        {
            var recordingKey =
                $"{GetType().FullName}.{TestContext.TestName}.{(isVertex ? "vertex" : "mldev")}";
            var httpOptions = new GoogleType.HttpOptions
            {
                Headers = new Dictionary<string, string> { { "Test-Name", recordingKey } },
                BaseUrl = isVertex ? VertexRegionalProxyUrl : MldevProxyUrl
            };

            if (!isVertex)
            {
                return new Client(apiKey: apiKey, enterprise: false, httpOptions: httpOptions);
            }

            string project =
                System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT") ?? "cloud-llm-preview1";
            return new Client(
                project: project,
                location: VertexLiveLocation,
                enterprise: true,
                credential: TestServer.GetCredentialForTestMode(),
                httpOptions: httpOptions);
        }

        private static GoogleType.LiveConnectConfig NewConfig(
            List<GoogleType.Tool> tools = null)
        {
            return new GoogleType.LiveConnectConfig
            {
                ResponseModalities = new List<GoogleType.Modality> { GoogleType.Modality.Audio },
                OutputAudioTranscription = new GoogleType.AudioTranscriptionConfig(),
                Tools = tools
            };
        }

        private static GoogleType.LiveSendClientContentParameters UserTurn(string text)
        {
            return new GoogleType.LiveSendClientContentParameters
            {
                Turns = new List<GoogleType.Content>
                {
                    new GoogleType.Content
                    {
                        Role = "user",
                        Parts = new List<GoogleType.Part> { new GoogleType.Part { Text = text } }
                    }
                },
                TurnComplete = true
            };
        }

        /// <summary>Everything a single model turn produced.</summary>
        private sealed class Turn
        {
            public int AudioBytes;
            public string Transcript = string.Empty;
            public List<GoogleType.FunctionCall> ToolCalls = new List<GoogleType.FunctionCall>();
        }

        /// <summary>Drains exactly one model turn, or the tool call that interrupts it.</summary>
        private static async Task<Turn> ReceiveTurnAsync(SessionWithQueue session)
        {
            var turn = new Turn();
            var transcript = new StringBuilder();

            for (int i = 0; i < MaxMessagesPerTurn; i++)
            {
                var message = await session.ReceiveAsync();

                if (message.ToolCall?.FunctionCalls != null
                    && message.ToolCall.FunctionCalls.Count > 0)
                {
                    turn.ToolCalls.AddRange(message.ToolCall.FunctionCalls);
                    turn.Transcript = transcript.ToString();
                    return turn;
                }

                var serverContent = message.ServerContent;
                if (serverContent == null)
                {
                    continue;
                }
                if (serverContent.OutputTranscription?.Text != null)
                {
                    transcript.Append(serverContent.OutputTranscription.Text);
                }
                if (serverContent.ModelTurn?.Parts != null)
                {
                    foreach (var part in serverContent.ModelTurn.Parts)
                    {
                        if (part.InlineData?.Data != null)
                        {
                            turn.AudioBytes += part.InlineData.Data.Length;
                        }
                    }
                }
                if (serverContent.TurnComplete == true)
                {
                    turn.Transcript = transcript.ToString();
                    return turn;
                }
            }

            Assert.Fail($"Model turn did not complete within {MaxMessagesPerTurn} messages.");
            return null;
        }

        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        [Timeout(180000)]
        public async Task TextInputProducesAudioAndTranscription(bool isVertex)
        {
            SkipIfBackendDisabled(isVertex);
            var session = new SessionWithQueue(
                CreateClient(isVertex), ModelFor(isVertex), NewConfig());
            await session.InitializeSessionAsync();
            try
            {
                await session.SendClientContentAsync(UserTurn("Say hello."));
                var turn = await ReceiveTurnAsync(session);

                Assert.IsTrue(turn.AudioBytes > 0, "Expected audio output from the model.");
                Assert.IsFalse(
                    string.IsNullOrWhiteSpace(turn.Transcript),
                    "Expected an output transcription.");
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        [Timeout(180000)]
        public async Task MultiTurnRetainsContext(bool isVertex)
        {
            SkipIfBackendDisabled(isVertex);
            var session = new SessionWithQueue(
                CreateClient(isVertex), ModelFor(isVertex), NewConfig());
            await session.InitializeSessionAsync();
            try
            {
                await session.SendClientContentAsync(
                    UserTurn("Remember the number 42. Just acknowledge it."));
                var first = await ReceiveTurnAsync(session);
                Assert.IsFalse(
                    string.IsNullOrWhiteSpace(first.Transcript),
                    "Expected a response to the first turn.");

                await session.SendClientContentAsync(
                    UserTurn("What number did I ask you to remember?"));
                var second = await ReceiveTurnAsync(session);

                Assert.IsTrue(second.AudioBytes > 0, "Expected audio output on the second turn.");
                StringAssert.Contains(
                    second.Transcript,
                    "42",
                    $"Expected the second turn to recall context from the first, transcript was "
                        + $"\"{second.Transcript}\"");
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        [Timeout(180000)]
        public async Task FunctionCallingCompletesRoundTrip(bool isVertex)
        {
            SkipIfBackendDisabled(isVertex);
            var tools = new List<GoogleType.Tool>
            {
                new GoogleType.Tool
                {
                    FunctionDeclarations = new List<GoogleType.FunctionDeclaration>
                    {
                        new GoogleType.FunctionDeclaration
                        {
                            Name = "turn_on_the_lights",
                            Description = "Turns the lights on in the room.",
                            Parameters = new GoogleType.Schema
                            {
                                Type = GoogleType.Type.Object,
                                Properties = new Dictionary<string, GoogleType.Schema>()
                            }
                        }
                    }
                }
            };

            var session = new SessionWithQueue(
                CreateClient(isVertex), ModelFor(isVertex), NewConfig(tools));
            await session.InitializeSessionAsync();
            try
            {
                await session.SendClientContentAsync(UserTurn("Please turn on the lights."));
                var turn = await ReceiveTurnAsync(session);

                Assert.IsTrue(turn.ToolCalls.Count > 0, "Expected the model to request the tool.");
                var call = turn.ToolCalls[0];
                Assert.AreEqual("turn_on_the_lights", call.Name);

                await session.SendToolResponseAsync(
                    new GoogleType.LiveSendToolResponseParameters
                    {
                        FunctionResponses = new List<GoogleType.FunctionResponse>
                        {
                            new GoogleType.FunctionResponse
                            {
                                Id = call.Id,
                                Name = call.Name,
                                Response = new Dictionary<string, object> { { "result", "ok" } }
                            }
                        }
                    });

                // Both backends must accept the tool result and complete the turn, but only the
                // Gemini API returns assertable content: Vertex emits an empty transcription.
                var followUp = await ReceiveTurnAsync(session);
                if (!isVertex)
                {
                    Assert.IsFalse(
                        string.IsNullOrWhiteSpace(followUp.Transcript),
                        "Expected the model to respond after the tool result.");
                }
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        /// <summary>
        /// This SDK does not validate FunctionResponse ids, so the error pathway covered here is
        /// session lifecycle: sending on a closed session must fail fast rather than hang.
        /// </summary>
        [DataTestMethod]
        [DataRow(false)]
        [DataRow(true)]
        [Timeout(180000)]
        public async Task SendAfterCloseThrows(bool isVertex)
        {
            SkipIfBackendDisabled(isVertex);
            var session = new SessionWithQueue(
                CreateClient(isVertex), ModelFor(isVertex), NewConfig());
            await session.InitializeSessionAsync();
            await session.CloseAsync();

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                async () => await session.SendClientContentAsync(UserTurn("Hello.")));
        }
    }
}
