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
/// The main entry point for the JsonParser application.
/// </summary>
public class Program
{
  /// <summary>
  /// Runs the JSON parsing demonstration.
  /// </summary>
  /// <param name="args">Command-line arguments (not used).</param>
  public static void Main(string[] args)
  {
    try
    {
      // Invoke the static ParseJson method directly from the JsonParser class.
      JsonParser.ParseJson();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"A critical error occurred: {ex.Message}");
    }
  } // This brace closes the Main method.
} // This brace closes the Program class.
