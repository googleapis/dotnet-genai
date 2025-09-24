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

using Google.GenAI;
using Google.GenAI.Types;

public class GenerateContentSimpleText {
  public static async Task SendRequestAsync() {
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    var geminiClient = new Client(apiKey: apiKey);
    try {
      var geminiResponse = await geminiClient.Models.GenerateContentAsync(
          model: "gemini-2.0-flash", contents: "What is the capital of France?");
      Console.WriteLine("Gemini API Response:");
      Console.WriteLine(geminiResponse);
    } catch (HttpRequestException ex) {
      Console.WriteLine($"An error occurred with Gemini API: {ex.ToString()}");
    }

    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    Content contents = new Content {
      Role = "user", Parts = new List<Part> { new Part { Text = "What is the capital of France?" } }
    };

    var vertexClient = new Client(project: project, location: location, vertexAI: true);
    try {
      var vertexResponse = await vertexClient.Models.GenerateContentAsync(model: "gemini-2.0-flash",
                                                                          contents: contents);
      Console.WriteLine("Vertex AI API Response:");
      Console.WriteLine(vertexResponse);
    } catch (Exception ex) {
      Console.WriteLine($"An error occurred with Vertex AI API: {ex.Message}");
    }
  }
}
