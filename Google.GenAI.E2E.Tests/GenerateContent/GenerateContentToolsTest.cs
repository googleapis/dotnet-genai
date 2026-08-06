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

using GoogleTypes = Google.GenAI.Types;

[TestClass]
public class GenerateContentToolsTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string modelName;
  private GoogleTypes.FunctionDeclaration getWeatherDeclaration =
      new GoogleTypes.FunctionDeclaration {
        Name = "GetWeather", Description = "return the real time weather of the location",
        Parameters =
            new GoogleTypes.Schema {
              Type = GoogleTypes.Type.Object,
              Properties =
                  new Dictionary<string, GoogleTypes.Schema> {
                    { "location", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } }
                  },
              Required = new List<string> { "location" }
            },
        Response = new GoogleTypes.Schema { Type = GoogleTypes.Type.String }
      };

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
    var geminiClientHttpOptions = new GoogleTypes.HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1453"
    };
    var vertexClientHttpOptions = new GoogleTypes.HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1454"
    };

    // Common setup for both clients.
    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location =
        System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    string apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              credential: TestServer.GetCredentialForTestMode(),
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "gemini-2.0-flash";
  }

  [TestMethod]
  public async Task GenerateContentManualFunctionCallVertexTest() {
    var vertexResponse = await vertexClient.Models.GenerateContentAsync(
        model: modelName, contents: "What's the weather like in Melbourne?",
        config: new GoogleTypes.GenerateContentConfig {
          Tools = new List<GoogleTypes.Tool> { new GoogleTypes.Tool {
            FunctionDeclarations =
                new List<GoogleTypes.FunctionDeclaration> { getWeatherDeclaration }
          } }
        });

    Assert.AreEqual("GetWeather", vertexResponse.FunctionCalls.FirstOrDefault().Name);
  }

  [TestMethod]
  public async Task GenerateContentManualFunctionCallGeminiTest() {
    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "What's the weather like in Melbourne?",
        config: new GoogleTypes.GenerateContentConfig {
          Tools = new List<GoogleTypes.Tool> { new GoogleTypes.Tool {
            FunctionDeclarations =
                new List<GoogleTypes.FunctionDeclaration> { getWeatherDeclaration }
          } }
        });

    Assert.AreEqual("GetWeather", geminiResponse.FunctionCalls.FirstOrDefault().Name);
  }

  [TestMethod]
  public async Task GenerateContentGoogleSearchVertexTest() {
    var tool = new Tool { GoogleSearch = new GoogleSearch() };
    var generateContentConfig = new GenerateContentConfig { Tools = new List<Tool> { tool } };

    var vertexResponse = await vertexClient.Models.GenerateContentAsync(
        model: modelName, contents: "What's the weather like in Melbourne?",
        config: generateContentConfig);

    Assert.IsNotNull(vertexResponse.Candidates);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
    Assert.IsNotNull(vertexResponse.Candidates.First().Content.Parts.First().Text);
    Assert.IsNotNull(vertexResponse.Candidates.First().GroundingMetadata);
  }

  [TestMethod]
  public async Task GenerateContentGoogleSearchGeminiTest() {
    var tool = new Tool { GoogleSearch = new GoogleSearch() };
    var generateContentConfig = new GenerateContentConfig { Tools = new List<Tool> { tool } };

    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "What's the weather like in Melbourne?",
        config: generateContentConfig);

    Assert.IsNotNull(geminiResponse.Candidates);
    Assert.IsTrue(geminiResponse.Candidates.Count >= 1);
    Assert.IsNotNull(geminiResponse.Text);
    Assert.IsNotNull(geminiResponse.Candidates.First().GroundingMetadata);
  }

  [TestMethod]
  public async Task GenerateContentSchemaPropertyOrderingResponseSchemaGeminiTest() {
    var schema = new GoogleTypes.Schema {
      Type = GoogleTypes.Type.Object,
      Properties = new Dictionary<string, GoogleTypes.Schema> {
        { "companyName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
        { "companyShortName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
        { "person", new GoogleTypes.Schema {
            Type = GoogleTypes.Type.Object,
            Properties = new Dictionary<string, GoogleTypes.Schema> {
              { "gender", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
              { "firstName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
              { "lastName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } }
            }
        } }
      }
    };

    string systemInstruction = "Analyze the input and extract the company and person details. The person object should contain gender, firstName, and lastName.";
    string input = "Hauswart-Service AG (short name Hauswart-Service) is represented by Mr. R. Zürcher.";

    var config = new GoogleTypes.GenerateContentConfig {
      ResponseMimeType = "application/json",
      ResponseSchema = schema,
      SystemInstruction = new GoogleTypes.Content {
        Parts = new List<GoogleTypes.Part> { new GoogleTypes.Part { Text = systemInstruction } }
      },
      Temperature = 0,
      MaxOutputTokens = 5000
    };

    var response = await geminiClient.Models.GenerateContentAsync(
        model: "gemini-3.5-flash",
        contents: input,
        config: config
    );

    string responseText = response.Candidates[0].Content.Parts[0].Text;
    Assert.IsNotNull(responseText);
    Assert.IsTrue(responseText.Contains("Zürcher"), "The response should contain the correctly extracted last name.");
    Assert.IsFalse(responseText.Contains("Zürcher2"), "The response should not contain hallucinated timestamps attached to the name.");
  }

  [TestMethod]
  public async Task GenerateContentSchemaPropertyOrderingResponseSchemaVertexTest() {
    var schema = new GoogleTypes.Schema {
      Type = GoogleTypes.Type.Object,
      Properties = new Dictionary<string, GoogleTypes.Schema> {
        { "companyName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
        { "companyShortName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
        { "person", new GoogleTypes.Schema {
            Type = GoogleTypes.Type.Object,
            Properties = new Dictionary<string, GoogleTypes.Schema> {
              { "gender", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
              { "firstName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } },
              { "lastName", new GoogleTypes.Schema { Type = GoogleTypes.Type.String } }
            }
        } }
      }
    };

    string systemInstruction = "Analyze the input and extract the company and person details. The person object should contain gender, firstName, and lastName.";
    string input = "Hauswart-Service AG (short name Hauswart-Service) is represented by Mr. R. Zürcher.";

    var config = new GoogleTypes.GenerateContentConfig {
      ResponseMimeType = "application/json",
      ResponseSchema = schema,
      SystemInstruction = new GoogleTypes.Content {
        Parts = new List<GoogleTypes.Part> { new GoogleTypes.Part { Text = systemInstruction } }
      },
      Temperature = 0,
      MaxOutputTokens = 5000
    };

    var response = await vertexClient.Models.GenerateContentAsync(
        model: "gemini-3.5-flash",
        contents: input,
        config: config
    );

    string responseText = response.Candidates[0].Content.Parts[0].Text;
    Assert.IsNotNull(responseText);
    Assert.IsTrue(responseText.Contains("Zürcher"), "The response should contain the correctly extracted last name.");
    Assert.IsFalse(responseText.Contains("Zürcher2"), "The response should not contain hallucinated timestamps attached to the name.");
  }

  [TestMethod]
  public async Task GenerateContentSchemaPropertyOrderingResponseJsonSchemaGeminiTest() {
    string schemaString = @"
    {
        ""type"": ""object"",
        ""properties"": {
            ""companyName"": { ""type"": ""string"" },
            ""companyShortName"": { ""type"": ""string"" },
            ""person"": {
                ""type"": ""object"",
                ""properties"": {
                    ""gender"": { ""type"": ""string"" },
                    ""firstName"": { ""type"": ""string"" },
                    ""lastName"": { ""type"": ""string"" }
                }
            }
        }
    }";

    string systemInstruction = "Analyze the input and extract the company and person details. The person object should contain gender, firstName, and lastName.";
    string input = "Hauswart-Service AG (short name Hauswart-Service) is represented by Mr. R. Zürcher.";

    var config = new GoogleTypes.GenerateContentConfig {
      ResponseMimeType = "application/json",
      ResponseJsonSchema = System.Text.Json.Nodes.JsonNode.Parse(schemaString),
      SystemInstruction = new GoogleTypes.Content {
        Parts = new List<GoogleTypes.Part> { new GoogleTypes.Part { Text = systemInstruction } }
      },
      Temperature = 0,
      MaxOutputTokens = 5000
    };

    var response = await geminiClient.Models.GenerateContentAsync(
        model: "gemini-3.5-flash",
        contents: input,
        config: config
    );

    string responseText = response.Candidates[0].Content.Parts[0].Text;
    Assert.IsNotNull(responseText);
    Assert.IsTrue(responseText.Contains("Zürcher"), "The response should contain the correctly extracted last name.");
  }

  [TestMethod]
  public async Task GenerateContentSchemaPropertyOrderingResponseJsonSchemaVertexTest() {
    string schemaString = @"
    {
        ""type"": ""object"",
        ""properties"": {
            ""companyName"": { ""type"": ""string"" },
            ""companyShortName"": { ""type"": ""string"" },
            ""person"": {
                ""type"": ""object"",
                ""properties"": {
                    ""gender"": { ""type"": ""string"" },
                    ""firstName"": { ""type"": ""string"" },
                    ""lastName"": { ""type"": ""string"" }
                }
            }
        }
    }";

    string systemInstruction = "Analyze the input and extract the company and person details. The person object should contain gender, firstName, and lastName.";
    string input = "Hauswart-Service AG (short name Hauswart-Service) is represented by Mr. R. Zürcher.";

    var config = new GoogleTypes.GenerateContentConfig {
      ResponseMimeType = "application/json",
      ResponseJsonSchema = System.Text.Json.Nodes.JsonNode.Parse(schemaString),
      SystemInstruction = new GoogleTypes.Content {
        Parts = new List<GoogleTypes.Part> { new GoogleTypes.Part { Text = systemInstruction } }
      },
      Temperature = 0,
      MaxOutputTokens = 5000
    };

    var response = await vertexClient.Models.GenerateContentAsync(
        model: "gemini-3.5-flash",
        contents: input,
        config: config
    );

    string responseText = response.Candidates[0].Content.Parts[0].Text;
    Assert.IsNotNull(responseText);
    Assert.IsTrue(responseText.Contains("Zürcher"), "The response should contain the correctly extracted last name.");
  }
}
