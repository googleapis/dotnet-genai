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

// Auto-generated code. Do not edit.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Tool to support computer use.
  /// </summary>

  public record ComputerUse {
    /// <summary>
    /// The environment being operated.
    /// </summary>
    [JsonPropertyName("environment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Environment ? Environment { get; set; }

    /// <summary>
    /// By default, predefined functions are included in the final model call. Some of them can be
    /// explicitly excluded from being automatically included. This can serve two purposes:  1.
    /// Using a more restricted / different action space.  2. Improving the definitions /
    /// instructions of predefined functions.
    /// </summary>
    [JsonPropertyName("excludedPredefinedFunctions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? ExcludedPredefinedFunctions {
            get; set;
          }

    /// <summary>
    /// Optional. Whether enable the prompt injection detection check on computer-use request.
    /// </summary>
    [JsonPropertyName("enablePromptInjectionDetection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnablePromptInjectionDetection {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ComputerUse object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ComputerUse object, or null if deserialization fails.</returns>
    public static ComputerUse ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ComputerUse>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
