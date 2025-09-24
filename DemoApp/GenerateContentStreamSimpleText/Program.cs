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

/// <summary>
/// The main entry point for the application.
/// </summary>
public class Program
{
  /// <summary>
  /// Runs the streaming content generation demonstration.
  /// </summary>
  /// <param name="args">Command-line arguments (not used).</param>
  public static async Task Main(string[] args)
  {
    try
    {
      // Invoke the static SendRequestAsync method from the GenerateContentStreamSimpleText class.
      await GenerateContentStreamSimpleText.SendRequestAsync();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"A critical error occurred: {ex.Message}");
    }
  }
}
