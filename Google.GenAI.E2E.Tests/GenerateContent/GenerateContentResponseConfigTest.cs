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
using System.Text.Json;
using System.Threading.Tasks;

using Google.GenAI;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

using GoogleType = Google.GenAI.Types;

[TestClass]
public class GenerateContentResponseConfigTest {
  private static TestServerProcess? _server;
  private Client vertexClient;
  private Client geminiClient;
  private string modelName;
  private GoogleType.Schema countryInfo = new GoogleType.Schema {
    Properties =
        new Dictionary<string, GoogleType.Schema> {
          { "title", new GoogleType.Schema { Type = GoogleType.Type.STRING, Title = "Title" } },
          { "population",
            new GoogleType.Schema { Type = GoogleType.Type.INTEGER, Title = "Population" } },
          { "capital", new GoogleType.Schema { Type = GoogleType.Type.STRING, Title = "Capital" } },
          { "continent",
            new GoogleType.Schema { Type = GoogleType.Type.STRING, Title = "Continent" } },
          { "language",
            new GoogleType.Schema { Type = GoogleType.Type.STRING, Title = "Language" } }
        },
    PropertyOrdering =
        new List<string> { "title", "population", "capital", "continent", "language" },
    Required = new List<string> { "title", "population", "capital", "continent", "language" },
    Title = "CountryInfo", Type = GoogleType.Type.OBJECT
  };
  private GoogleType.Schema restaurantInfo = new GoogleType.Schema {
    Properties =
        new Dictionary<string, GoogleType.Schema> {
          { "name", new GoogleType.Schema { Type = GoogleType.Type.STRING, Title = "Name" } },
          { "city", new GoogleType.Schema { Type = GoogleType.Type.STRING, Title = "City",
                                            Default = "New York" } },
          { "address", new GoogleType.Schema { Type = GoogleType.Type.STRING, Title = "Address" } },
          { "rating", new GoogleType.Schema { Type = GoogleType.Type.NUMBER, Title = "Rating",
                                              Default = 3.0 } }
        },
    PropertyOrdering = new List<string> { "name", "city", "address", "rating" },
    Required = new List<string> { "name", "city", "address", "rating" }, Title = "restaurantInfo",
    Type = GoogleType.Type.OBJECT
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
    modelName = "gemini-2.0-flash";
  }

  [TestMethod]
  public async Task GenerateContentResponseSchemaVertexTest() {
    var vertexResponse = await vertexClient.Models.GenerateContentAsync(
        model: modelName, contents: "Give me information about Australia",
        config: new GoogleType.GenerateContentConfig { ResponseMimeType = "application/json",
                                                       ResponseSchema = countryInfo });

    Assert.IsNotNull(vertexResponse.Candidates);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
    string text = vertexResponse.Candidates.First().Content.Parts.First().Text;
    var parsedText = JsonSerializer.Deserialize<Dictionary<string, object>>(text);
    Assert.IsNotNull(parsedText);
    Assert.IsNotNull(parsedText["title"]);
    Assert.IsNotNull(parsedText["population"]);
    Assert.IsNotNull(parsedText["capital"]);
    Assert.IsNotNull(parsedText["continent"]);
    Assert.IsNotNull(parsedText["language"]);
  }

  [TestMethod]
  public async Task GenerateContentResponseSchemaGeminiTest() {
    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "Give me information about Australia",
        config: new GoogleType.GenerateContentConfig { ResponseMimeType = "application/json",
                                                       ResponseSchema = countryInfo });

    Assert.IsNotNull(geminiResponse.Candidates);
    Assert.IsTrue(geminiResponse.Candidates.Count >= 1);
    string text = geminiResponse.Candidates.First().Content.Parts.First().Text;
    var parsedText = JsonSerializer.Deserialize<Dictionary<string, object>>(text);
    Assert.IsNotNull(parsedText);
    Assert.IsNotNull(parsedText["title"]);
    Assert.IsNotNull(parsedText["population"]);
    Assert.IsNotNull(parsedText["capital"]);
    Assert.IsNotNull(parsedText["continent"]);
    Assert.IsNotNull(parsedText["language"]);
  }

  [TestMethod]
  public async Task GenerateContentResponseSchemaWithDefaultVertexTest() {
    var vertexResponse = await vertexClient.Models.GenerateContentAsync(
        model: modelName, contents: "Can you recommend a restaurant for me?",
        config: new GoogleType.GenerateContentConfig { ResponseMimeType = "application/json",
                                                       ResponseSchema = restaurantInfo });

    Assert.IsNotNull(vertexResponse.Candidates);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
    string text = vertexResponse.Candidates.First().Content.Parts.First().Text;
    var parsedText = JsonSerializer.Deserialize<Dictionary<string, object>>(text);
    Assert.IsNotNull(parsedText);
    Assert.IsNotNull(parsedText["name"]);
    Assert.AreEqual(parsedText["city"].ToString(), "New York");
    Assert.IsNotNull(parsedText["address"]);
    Assert.IsNotNull(parsedText["rating"]);
  }

  [TestMethod]
  public async Task GenerateContentResponseSchemaWithDefaultGeminiTest() {
    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: modelName, contents: "Can you recommend a restaurant for me?",
        config: new GoogleType.GenerateContentConfig { ResponseMimeType = "application/json",
                                                       ResponseSchema = restaurantInfo });

    Assert.IsNotNull(geminiResponse.Candidates);
    Assert.IsTrue(geminiResponse.Candidates.Count >= 1);
    string text = geminiResponse.Candidates.First().Content.Parts.First().Text;
    var parsedText = JsonSerializer.Deserialize<Dictionary<string, object>>(text);
    Assert.IsNotNull(parsedText);
    Assert.IsNotNull(parsedText["name"]);
    Assert.AreEqual(parsedText["city"].ToString(), "New York");
    Assert.IsNotNull(parsedText["address"]);
    Assert.IsNotNull(parsedText["rating"]);
  }
  [TestMethod]
  public async Task GenerateContentResponseModalityImageVertexTest() {
    var vertexResponse = await vertexClient.Models.GenerateContentAsync(
        model: "gemini-2.0-flash-preview-image-generation",
        contents: "Can you generate an image of a cat?",
        config: new GoogleType.GenerateContentConfig { ResponseModalities =
                                                           new List<string> { "TEXT", "IMAGE" } });

    Assert.IsNotNull(vertexResponse.Candidates);
    Assert.IsTrue(vertexResponse.Candidates.Count >= 1);
    Assert.IsNotNull(vertexResponse.Candidates.First().Content.Parts.First().Text);
    Assert.IsNotNull(vertexResponse.Candidates.First().Content.Parts[1].InlineData);
    Assert.IsNotNull(vertexResponse.Candidates.First().Content.Parts[1].InlineData.Data);
    StringAssert.Contains(vertexResponse.Candidates.First().Content.Parts[1].InlineData.MimeType,
                          "image");
  }
  [TestMethod]
  public async Task GenerateContentResponseModalityImageGeminiTest() {
    var geminiResponse = await geminiClient.Models.GenerateContentAsync(
        model: "gemini-2.0-flash-preview-image-generation",
        contents: "Can you generate an image of a cat?",
        config: new GoogleType.GenerateContentConfig { ResponseModalities =
                                                           new List<string> { "TEXT", "IMAGE" } });

    Assert.IsNotNull(geminiResponse.Candidates);
    Assert.IsTrue(geminiResponse.Candidates.Count >= 1);
    Assert.IsNotNull(geminiResponse.Candidates.First().Content.Parts.First().Text);
    Assert.IsNotNull(geminiResponse.Candidates.First().Content.Parts[1].InlineData);
    Assert.IsNotNull(geminiResponse.Candidates.First().Content.Parts[1].InlineData.Data);
    StringAssert.Contains(geminiResponse.Candidates.First().Content.Parts[1].InlineData.MimeType,
                          "image");
  }
}
