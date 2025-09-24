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
using GoogleType = Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class SendClientContentTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string vertexModelName;
  private string geminiModelName;
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
    var geminiClientHttpOptions = new GoogleType.HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1453"
    };
    var vertexClientHttpOptions = new GoogleType.HttpOptions {
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
    vertexModelName = "gemini-2.0-flash-live-preview-04-09";
    geminiModelName = "gemini-live-2.5-flash-preview";
  }

  [TestMethod]
  public async Task SendClientContentSimpleTextGeminiTest() {
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName);
    await geminiSession.InitializeSessionAsync();

    await geminiSession.SendClientContentAsync(new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Role = "user", Parts = new List<GoogleType.Part> { new GoogleType.Part {
                         Text = "Hello what should we talk about?"
                       } }
      } },
      TurnComplete = true
    });

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var message = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(message.ServerContent);

    await geminiSession.CloseAsync();
  }

  [TestMethod]
  public async Task SendClientContentSimpleTextVertexTest() {
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName);
    await vertexSession.InitializeSessionAsync();

    await vertexSession.SendClientContentAsync(new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Role = "user", Parts = new List<GoogleType.Part> { new GoogleType.Part {
                         Text = "Hello what should we talk about?"
                       } }
      } },
      TurnComplete = true
    });

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var message = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(message.ServerContent);

    await vertexSession.CloseAsync();
  }

  [TestMethod]
  public async Task SendClientContentSystemInstructionGeminiTest() {
    var config = new GoogleType.LiveConnectConfig {
      SystemInstruction =
          new GoogleType.Content {
            Parts = new List<GoogleType.Part> { new GoogleType.Part {
              Text = "You are a helpful chatbot that specializes in providing fun facts."
            } }
          },
      ResponseModalities = new List<GoogleType.Modality> { GoogleType.Modality.TEXT }
    };
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName, config);
    await geminiSession.InitializeSessionAsync();

    await geminiSession.SendClientContentAsync(new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Role = "user", Parts = new List<GoogleType.Part> { new GoogleType.Part {
                         Text = "Tell me a fun fact about the ocean."
                       } }
      } },
      TurnComplete = true
    });

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var message = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(message.ServerContent);
    Assert.IsNotNull(message.ServerContent.ModelTurn);
    Assert.IsNotNull(message.ServerContent.ModelTurn.Parts);
    Assert.IsTrue(message.ServerContent.ModelTurn.Parts.Any(), "Parts collection is empty.");

    var textPart =
        message.ServerContent.ModelTurn.Parts.FirstOrDefault(p => !string.IsNullOrEmpty(p.Text));
    Assert.IsNotNull(textPart, "No text content found in the response.");
    Assert.IsNotNull(textPart.Text);

    await geminiSession.CloseAsync();
  }

  [TestMethod]
  public async Task SendClientContentSystemInstructionVertexTest() {
    var config = new GoogleType.LiveConnectConfig {
      SystemInstruction =
          new GoogleType.Content {
            Parts = new List<GoogleType.Part> { new GoogleType.Part {
              Text = "You are a helpful chatbot that specializes in providing fun facts."
            } }
          },
      ResponseModalities = new List<GoogleType.Modality> { GoogleType.Modality.TEXT }
    };
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName, config);
    await vertexSession.InitializeSessionAsync();

    await vertexSession.SendClientContentAsync(new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Parts = new List<GoogleType.Part> { new GoogleType.Part {
          Text = "Tell me a fun fact about the ocean."
        } }
      } },
      TurnComplete = true
    });

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var message = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(message.ServerContent);
    Assert.IsNotNull(message.ServerContent.ModelTurn);
    Assert.IsNotNull(message.ServerContent.ModelTurn.Parts);
    Assert.IsTrue(message.ServerContent.ModelTurn.Parts.Any(), "Parts collection is empty.");

    var textPart =
        message.ServerContent.ModelTurn.Parts.FirstOrDefault(p => !string.IsNullOrEmpty(p.Text));
    Assert.IsNotNull(textPart, "No text content found in the response.");
    Assert.IsNotNull(textPart.Text);

    await vertexSession.CloseAsync();
  }

  [TestMethod]
  public async Task SendClientContentToolsGeminiTest() {
    var config =
        new GoogleType.LiveConnectConfig {
          Tools = new List<GoogleType.Tool> { new GoogleType.Tool {
            FunctionDeclarations =
                new List<GoogleType.FunctionDeclaration> { new GoogleType.FunctionDeclaration {
                  Name = "GetCurrentWeather",
                  Description = "Get the current weather in a given location",
                  Parameters =
                      new GoogleType
                          .Schema { Type = GoogleType.Type.OBJECT,
                                    Properties = new Dictionary<string, GoogleType.Schema> { { "location", new GoogleType
                                                                                                               .Schema { Type = GoogleType
                                                                                                                                    .Type
                                                                                                                                    .STRING,
                                                                                                                         Description = "The city and state, e.g. San Francisco, CA" } } },
                                    Required = new List<string> { "location" } }
                } }
          } }
        };
    var geminiSession = new SessionWithQueue(geminiClient, geminiModelName, config);
    await geminiSession.InitializeSessionAsync();

    await geminiSession.SendClientContentAsync(new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Parts = new List<GoogleType.Part> { new GoogleType.Part {
          Text = "what is the weather in Redmond Washington"
        } }
      } },
      TurnComplete = true
    });

    var setupMessage = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var message = await geminiSession.ReceiveAsync();
    Assert.IsNotNull(message.ServerContent);
    Assert.IsNotNull(message.ServerContent?.ModelTurn?.Parts);
    Assert.IsTrue(message.ServerContent.ModelTurn.Parts.Any(), "Parts collection is empty.");
    Assert.IsNotNull(message.ServerContent.ModelTurn.Parts.First().ExecutableCode);
    Assert.IsNotNull(message.ServerContent.ModelTurn.Parts.First().ExecutableCode?.Code);
    StringAssert.Contains(message.ServerContent.ModelTurn.Parts.First().ExecutableCode.Code,
                          "GetCurrentWeather");

    await geminiSession.CloseAsync();
  }

  [TestMethod]
  public async Task SendClientContentToolsVertexTest() {
    var config =
        new GoogleType.LiveConnectConfig {
          Tools = new List<GoogleType.Tool> { new GoogleType.Tool {
            FunctionDeclarations =
                new List<GoogleType.FunctionDeclaration> { new GoogleType.FunctionDeclaration {
                  Name = "GetCurrentWeather",
                  Description = "Get the current weather in a given location",
                  Parameters =
                      new GoogleType
                          .Schema { Type = GoogleType.Type.OBJECT,
                                    Properties = new Dictionary<string, GoogleType.Schema> { { "location", new GoogleType
                                                                                                               .Schema { Type = GoogleType
                                                                                                                                    .Type
                                                                                                                                    .STRING,
                                                                                                                         Description = "The city and state, e.g. San Francisco, CA" } } },
                                    Required = new List<string> { "location" } }
                } }
          } }
        };
    var vertexSession = new SessionWithQueue(vertexClient, vertexModelName, config);
    await vertexSession.InitializeSessionAsync();

    await vertexSession.SendClientContentAsync(new GoogleType.LiveSendClientContentParameters {
      Turns =
          new List<GoogleType.Content> {
            new GoogleType.Content { Parts = new List<GoogleType.Part> { new GoogleType.Part {
                                       Text = "what is the weather in Redmond Washington"
                                     } } },
          },
      TurnComplete = true
    });

    var setupMessage = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(setupMessage.SetupComplete);

    var message = await vertexSession.ReceiveAsync();
    Assert.IsNotNull(message.ToolCall);
    Assert.AreEqual("GetCurrentWeather", message.ToolCall.FunctionCalls.First().Name);

    await vertexSession.CloseAsync();
  }
}
