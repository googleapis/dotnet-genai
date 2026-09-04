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
        /// The only live model family currently served on the Gemini API. It is audio-native and
        /// rejects a TEXT response modality, so these tests request AUDIO and enable output
        /// transcription for an assertable text signal.
        /// </summary>
        private const string LiveModel = "gemini-3.1-flash-live-preview";

        /// <summary>Caps how many messages a single turn may produce before we give up.</summary>
        private const int MaxMessagesPerTurn = 200;

        private Client geminiClient;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetupClient()
        {
            // This suite ships no recordings; it exists to exercise the live backend nightly.
            if (TestServer.IsReplayMode)
            {
                Assert.Inconclusive(
                    "Skipping live API tests in replay mode: this suite ships no recordings and "
                        + "runs live in the nightly job.");
            }

            string apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
            }
            if (string.IsNullOrEmpty(apiKey))
            {
                Assert.Fail("GEMINI_API_KEY (or GOOGLE_API_KEY) must be set to run the live tests.");
            }

            var httpOptions = new GoogleType.HttpOptions
            {
                Headers = new Dictionary<string, string>
                {
                    { "Test-Name", $"{GetType().FullName}.{TestContext.TestName}" }
                },
                BaseUrl = "http://localhost:1453"
            };
            geminiClient = new Client(apiKey: apiKey, enterprise: false, httpOptions: httpOptions);
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

        [TestMethod]
        [Timeout(180000)]
        public async Task TextInputProducesAudioAndTranscription()
        {
            var session = new SessionWithQueue(geminiClient, LiveModel, NewConfig());
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

        [TestMethod]
        [Timeout(180000)]
        public async Task MultiTurnRetainsContext()
        {
            var session = new SessionWithQueue(geminiClient, LiveModel, NewConfig());
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

        [TestMethod]
        [Timeout(180000)]
        public async Task FunctionCallingCompletesRoundTrip()
        {
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

            var session = new SessionWithQueue(geminiClient, LiveModel, NewConfig(tools));
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

                var followUp = await ReceiveTurnAsync(session);
                Assert.IsFalse(
                    string.IsNullOrWhiteSpace(followUp.Transcript),
                    "Expected the model to respond after the tool result.");
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
        [TestMethod]
        [Timeout(180000)]
        public async Task SendAfterCloseThrows()
        {
            var session = new SessionWithQueue(geminiClient, LiveModel, NewConfig());
            await session.InitializeSessionAsync();
            await session.CloseAsync();

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(
                async () => await session.SendClientContentAsync(UserTurn("Hello.")));
        }
    }
}
