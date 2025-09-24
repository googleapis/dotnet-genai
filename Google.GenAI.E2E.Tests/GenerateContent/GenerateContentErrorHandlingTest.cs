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
using System.Threading.Tasks;

using Google.GenAI;
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class GenerateContentErrorHandlingTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string modelName;
  public TestContext TestContext { get; set; }

  [ClassInitialize]
  public static void ClassInit(TestContext _) {
    _server = TestServer.StartTestServer();
  }
  [ClassCleanup]
  public static void ClassCleanup() {
    TestServer.StopTestServer(_server);
  }

  [TestInitialize]
  public void TestInit() {
    // Test server specific setup.
    if (_server == null) {
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
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "gemini-2.0-flash";
  }

  [TestMethod]
  public async Task GenerateContentWrongModelNameVertexTest() {
    var ex = await Assert.ThrowsExceptionAsync<ClientError>(async () => {
      await vertexClient.Models.GenerateContentAsync(model: "wrong-model-name",
                                                     contents: "What is the capital of France?");
    });

    StringAssert.Contains(ex.Message, "wrong-model-name");
    StringAssert.Contains(ex.Message, "Details");
    StringAssert.Contains(ex.Message, "[ORIGINAL ERROR] generic::not_found");
  }

  [TestMethod]
  public async Task GenerateContentWrongModelNameGeminiTest() {
    var ex = await Assert.ThrowsExceptionAsync<ClientError>(async () => {
      await geminiClient.Models.GenerateContentAsync(model: "wrong-model-name",
                                                     contents: "What is the capital of France?");
    });

    StringAssert.Contains(ex.Message, "wrong-model-name");
    StringAssert.Contains(ex.Message, "Details");
    StringAssert.Contains(ex.Message, "[ORIGINAL ERROR] generic::not_found");
  }

  [TestMethod]
  public async Task GenerateContentEnterpriseWebSearchVertexTest() {
    var vertexResponse = await vertexClient.Models.GenerateContentAsync(
        model: modelName,
        contents: new Content { Parts =
                                    new List<Part> { new Part { Text = "Why is the sky blue?" } },
                                Role = "user" },
        config: new GenerateContentConfig { Tools = new List<Tool> {
          new Tool { EnterpriseWebSearch =
                         new EnterpriseWebSearch {
                           ExcludeDomains = new List<string> { "amazon.com" },
                         } }
        } });

    Assert.IsNotNull(vertexResponse);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
    Assert.IsNotNull(vertexResponse.Candidates[0].Content.Parts[0].Text);
    Assert.IsNotNull(vertexResponse.Candidates[0].GroundingMetadata);
  }

  [TestMethod]
  public async Task GenerateContentEnterpriseWebSearchGeminiTest() {
    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.GenerateContentAsync(
          model: modelName,
          contents: new Content { Parts =
                                      new List<Part> { new Part { Text = "Why is the sky blue?" } },
                                  Role = "user" },
          config: new GenerateContentConfig { Tools = new List<Tool> {
            new Tool { EnterpriseWebSearch =
                           new EnterpriseWebSearch {
                             ExcludeDomains = new List<string> { "amazon.com" },
                           } }
          } });
    });

    Assert.AreEqual(ex.Message, "enterpriseWebSearch parameter is not supported in Gemini API.");
  }

  [TestMethod]
  public async Task GenerateContentMultiSpeakerVoiceConfigVertexTest() {
    var ex =
        await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
          await vertexClient.Models.GenerateContentAsync(
              model: "gemini-2.0-flash-exp",
              contents: "Alice says 'Hi', Bob replies with 'what\'s up?'",
              config: new GenerateContentConfig {
                ResponseModalities = new List<string> { "AUDIO" },
                SpeechConfig =
                    new SpeechConfig {
                      MultiSpeakerVoiceConfig =
                          new MultiSpeakerVoiceConfig {
                            SpeakerVoiceConfigs =
                                new List<SpeakerVoiceConfig> {
                                  new SpeakerVoiceConfig {
                                    Speaker = "Alice",
                                    VoiceConfig = new VoiceConfig { PrebuiltVoiceConfig =
                                                                        new PrebuiltVoiceConfig {
                                                                          VoiceName = "leda"
                                                                        } }
                                  },
                                  new SpeakerVoiceConfig {
                                    Speaker = "Bob",
                                    VoiceConfig = new VoiceConfig { PrebuiltVoiceConfig =
                                                                        new PrebuiltVoiceConfig {
                                                                          VoiceName = "kore"
                                                                        } }
                                  }
                                }
                          }
                    }
              });
        });

    Assert.AreEqual(ex.Message, "multiSpeakerVoiceConfig parameter is not supported in Vertex AI.");
  }

  [TestMethod]
  public async Task GenerateContentLabelsVertexTest() {
    var vertexResponse = await vertexClient.Models.GenerateContentAsync(
        model: modelName, contents: "What is the capital of France?",
        config: new GenerateContentConfig {
          Labels = new Dictionary<string, string> { { "test-label-key", "test-label-value" } }
        });

    Assert.IsNotNull(vertexResponse);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
    Assert.IsNotNull(vertexResponse.Candidates[0].Content.Parts[0].Text);
  }

  [TestMethod]
  public async Task GenerateContentLabelsGeminiTest() {
    var ex = await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => {
      await geminiClient.Models.GenerateContentAsync(
          model: modelName, contents: "What is the capital of France?",
          config: new GenerateContentConfig {
            Labels = new Dictionary<string, string> { { "test-label-key", "test-label-value" } }
          });
    });

    Assert.AreEqual(ex.Message, "labels parameter is not supported in Gemini API.");
  }
}
