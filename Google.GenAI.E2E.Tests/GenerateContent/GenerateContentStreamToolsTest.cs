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
public class GenerateContentStreamToolsTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string modelName;
  private GoogleTypes.FunctionDeclaration getWeatherDeclaration =
      new GoogleTypes.FunctionDeclaration {
        Name = "GetWeather", Description = "return the real time weather of the location",
        Parameters =
            new GoogleTypes.Schema {
              Type = GoogleTypes.Type.OBJECT,
              Properties =
                  new Dictionary<string, GoogleTypes.Schema> {
                    { "location", new GoogleTypes.Schema { Type = GoogleTypes.Type.STRING } }
                  },
              Required = new List<string> { "location" }
            },
        Response = new GoogleTypes.Schema { Type = GoogleTypes.Type.STRING }
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
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    vertexClient = new Client(project: project, location: location, vertexAI: true,
                              httpOptions: vertexClientHttpOptions);
    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    // Specific setup for this test class
    modelName = "gemini-2.0-flash";
  }

  [TestMethod]
  public async Task GenerateContentStreamManualFunctionCallVertexTest() {
    await foreach (var chunk in vertexClient.Models.GenerateContentStreamAsync(
                       model: modelName, contents: "What's the weather like in Melbourne?",
                       config: new GoogleTypes.GenerateContentConfig {
                         Tools = new List<GoogleTypes.Tool> { new GoogleTypes.Tool {
                           FunctionDeclarations =
                               new List<GoogleTypes.FunctionDeclaration> { getWeatherDeclaration }
                         } }
                       })) {
      Assert.IsNotNull(chunk.Candidates);
      Assert.IsTrue(chunk.Candidates.Count >= 1);
      var firstCandidate = chunk.Candidates.FirstOrDefault();
      Assert.IsNotNull(firstCandidate);
      Assert.IsNotNull(firstCandidate.Content);
      Assert.IsNotNull(firstCandidate.Content.Parts);
      Assert.IsTrue(firstCandidate.Content.Parts.Count >= 1);
      var firstPart = firstCandidate.Content.Parts.FirstOrDefault();
      Assert.IsNotNull(firstPart);
      Assert.IsNotNull(firstPart.FunctionCall);
      Assert.AreEqual("GetWeather", firstPart.FunctionCall.Name);
    }
  }

  [TestMethod]
  public async Task GenerateContentStreamManualFunctionCallGeminiTest() {
    await foreach (var chunk in geminiClient.Models.GenerateContentStreamAsync(
                       model: modelName, contents: "What's the weather like in Melbourne?",
                       config: new GoogleTypes.GenerateContentConfig {
                         Tools = new List<GoogleTypes.Tool> { new GoogleTypes.Tool {
                           FunctionDeclarations =
                               new List<GoogleTypes.FunctionDeclaration> { getWeatherDeclaration }
                         } }
                       })) {
      Assert.IsNotNull(chunk.Candidates);
      Assert.IsTrue(chunk.Candidates.Count >= 1);
      var firstCandidate = chunk.Candidates.FirstOrDefault();
      Assert.IsNotNull(firstCandidate);
      Assert.IsNotNull(firstCandidate.Content);
      Assert.IsNotNull(firstCandidate.Content.Parts);
      Assert.IsTrue(firstCandidate.Content.Parts.Count >= 1);
      var firstPart = firstCandidate.Content.Parts.FirstOrDefault();
      Assert.IsNotNull(firstPart);
      Assert.IsNotNull(firstPart.FunctionCall);
      Assert.AreEqual("GetWeather", firstPart.FunctionCall.Name);
    }
  }

  [TestMethod]
  public async Task GenerateContentStreamGoogleSearchVertexTest() {
    var tool = new Tool { GoogleSearch = new GoogleSearch() };
    var generateContentConfig = new GenerateContentConfig { Tools = new List<Tool> { tool } };

    await foreach (var chunk in vertexClient.Models.GenerateContentStreamAsync(
                       model: modelName, contents: "What's the weather like in Melbourne?",
                       config: generateContentConfig)) {
      Assert.IsNotNull(chunk.Candidates);
      Assert.IsTrue(chunk.Candidates.Count >= 1);
      Assert.IsNotNull(chunk.Candidates.First().Content.Parts.First().Text);
      Assert.IsNotNull(chunk.Candidates.First().GroundingMetadata);
    }
  }

  [TestMethod]
  public async Task GenerateContentStreamGoogleSearchGeminiTest() {
    var tool = new Tool { GoogleSearch = new GoogleSearch() };
    var generateContentConfig = new GenerateContentConfig { Tools = new List<Tool> { tool } };

    await foreach (var chunk in geminiClient.Models.GenerateContentStreamAsync(
                       model: modelName, contents: "What's the weather like in Melbourne?",
                       config: generateContentConfig)) {
      Assert.IsNotNull(chunk.Candidates);
      Assert.IsTrue(chunk.Candidates.Count >= 1);
      Assert.IsNotNull(chunk.Candidates.First().Content.Parts.First().Text);
      Assert.IsNotNull(chunk.Candidates.First().GroundingMetadata);
    }
  }
}
