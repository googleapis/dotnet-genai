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
using Google.Apis.Auth.OAuth2;

public class RegisterFiles {
  public static async Task SendRequestAsync() {
    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    // Gemini Developer API client.
    var geminiClient = new Client(apiKey: apiKey);

    // Detect default credentials to use for registering files.
    // This is required because the Gemini Developer client normally uses API keys,
    // but registering files from Google Cloud Storage requires OAuth credentials.
    var credential = await GoogleCredential.GetApplicationDefaultAsync();

    try {
      // 1. Register the file.
      var uris = new List<string> { "gs://tensorflow_docs/image.jpg" };
      var registerResponse = await geminiClient.Files.RegisterFilesAsync(uris, credential);

      Console.WriteLine($"Registered {registerResponse.Files.Count} files.");
      if (registerResponse.Files.Count == 0) {
          Console.WriteLine("No files were registered.");
          return;
      }

      var registeredFile = registerResponse.Files[0];
      Console.WriteLine($"Registered file: {registeredFile.Name}");

      // Wait for the file to be processed.
      Console.WriteLine("Waiting for the file to be processed...");
      var file = await geminiClient.Files.GetAsync(registeredFile.Name);
      int attempts = 0;
      while (file.State != FileState.Active && attempts < 20) {
          attempts++;
          Console.WriteLine($"File state is {file.State}. Waiting 5 seconds (attempt {attempts})...");
          await Task.Delay(5000);
          file = await geminiClient.Files.GetAsync(registeredFile.Name);
      }

      if (file.State != FileState.Active) {
          Console.WriteLine($"File did not become active. Final state: {file.State}");
          return;
      }

      // 2. Use the registered file in a GenerateContent call.
      // We use the file's URI and MIMEType.
      var contents = new List<Content>
      {
          new Content
          {
              Role = "user",
              Parts = new List<Part>
              {
                  new Part { Text = "can you summarize this file?" },
                  new Part { FileData = new FileData { FileUri = registeredFile.Uri, MimeType = registeredFile.MimeType } }
              }
          }
      };

      Console.WriteLine("Generating content using the registered file...");
      var generateResponse = await geminiClient.Models.GenerateContentAsync(
          model: "gemini-2.5-flash",
          contents: contents
      );

      Console.WriteLine($"Response: {generateResponse.Text}");

    } catch (NotSupportedException ex) {
      Console.WriteLine(ex.Message);
    } catch (Exception ex) {
      Console.WriteLine($"An error occurred: {ex.Message}");
    }
  }
}
