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

using System.Text.Json;
using System.Text.Json.Nodes;

using Google.GenAI;
using Google.GenAI.Types;

public static class JsonParser
{
  public static void ParseJson()
  {
    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };

    string contentJson = "{\"parts\":[{\"text\":\"Explain how AI works\"}]}";

    Console.WriteLine("Parsing content JSON: " + contentJson);

    try
    {
      Content? content = Content.FromJson(contentJson, options);

      Console.WriteLine("Using FromJson: Content: " + content);

      if (content != null)
      {
        Console.WriteLine("Using FromJson: Content: " + content);
      }
      else
      {
        Console.WriteLine("Using FromJson: Failed to parse contentParams (result is null).");
      }
    }
    catch (JsonException jsonEx)
    {
      Console.WriteLine($"Error parsing JSON: {jsonEx.Message}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An unexpected error occurred during JSON parsing: {ex.Message}");
    }

    Console.WriteLine("Trying Common object modification methods:");
    JsonObject container = new JsonObject();
    Common.SetValueByPath(container, new string[] { "firstMember" }, "firstValue");
    Common.SetValueByPath(container, new string[] { "secondMember", "childMember" }, 42);
    Common.SetValueByPath(container, new string[] { "thirdMember", "childArray" }, new List<String>() { "foo", "bar", "baz" });

    Console.WriteLine("Generated JSON: " + container);
    Console.WriteLine("child member value: " + Common.GetValueByPath(container, new string[] { "secondMember", "childMember" }));
    Console.WriteLine("array member value: " + Common.GetValueByPath(container, new string[] { "thirdMember", "childArray[]" }));
  }
}
