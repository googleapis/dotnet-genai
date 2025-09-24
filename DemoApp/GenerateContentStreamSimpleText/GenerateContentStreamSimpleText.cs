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

public class GenerateContentStreamSimpleText {
  public static async Task SendRequestAsync() {
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    var geminiClient = new Client(apiKey: apiKey);

    try {
      Console.WriteLine("=== Gemini API Streaming Response ===");
      Console.Write("Response: ");

      await foreach (var chunk in geminiClient.Models.GenerateContentStreamAsync(
                         model: "gemini-2.0-flash",
                         contents: "Tell me a short story about a brave knight.")) {
        var text = chunk.Candidates?[0]?.Content?.Parts?[0]?.Text;
        if (!string.IsNullOrEmpty(text)) {
          Console.Write(text);
        }
      }
      Console.WriteLine("\n=== End of Gemini Streaming ===\n");
    } catch (ClientError ex) {
      Console.WriteLine($"Client error occurred with Gemini API: {ex.Message}");
      Console.WriteLine($"Status Code: {ex.StatusCode}, Status: {ex.Status}");
    } catch (ServerError ex) {
      Console.WriteLine($"Server error occurred with Gemini API: {ex.Message}");
      Console.WriteLine($"Status Code: {ex.StatusCode}, Status: {ex.Status}");
    } catch (HttpRequestException ex) {
      Console.WriteLine($"HTTP error occurred with Gemini API: {ex.Message}");
    }

    string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string location = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
    Content contents = new Content {
      Role = "user",
      Parts = new List<Part> { new Part { Text = "Tell me a short story about a brave knight." } }
    };

    var vertexClient = new Client(project: project, location: location, vertexAI: true);

    try {
      Console.WriteLine("=== Vertex AI Streaming Response ===");
      Console.Write("Response: ");

      await foreach (var chunk in vertexClient.Models.GenerateContentStreamAsync(
                         model: "gemini-2.0-flash", contents: contents)) {
        var text = chunk.Candidates?[0]?.Content?.Parts?[0]?.Text;
        if (!string.IsNullOrEmpty(text)) {
          Console.Write(text);
        }
      }
      Console.WriteLine("\n=== End of Vertex AI Streaming ===\n");
    } catch (ClientError ex) {
      Console.WriteLine($"Client error occurred with Vertex AI: {ex.Message}");
      Console.WriteLine($"Status Code: {ex.StatusCode}, Status: {ex.Status}");
    } catch (ServerError ex) {
      Console.WriteLine($"Server error occurred with Vertex AI: {ex.Message}");
      Console.WriteLine($"Status Code: {ex.StatusCode}, Status: {ex.Status}");
    } catch (Exception ex) {
      Console.WriteLine($"An error occurred with Vertex AI: {ex.Message}");
    }
  }
}
