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
  /// A tool that enables the model to interact directly with a computer environment.
  /// </summary>

  public record ComputerUse {
    /// <summary>
    /// The target environment where the computer use tool operates.
    /// </summary>
    [JsonPropertyName("environment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Environment ? Environment { get; set; }

    /// <summary>
    /// Optional. A list of predefined functions to explicitly exclude from the model call. By
    /// default, predefined functions
    /// (https://cloud.google.com/vertex-ai/generative-ai/docs/computer-use#supported-actions) are
    /// included. Excluding functions allows for a more restricted action space or custom
    /// definitions for predefined functions.
    /// </summary>
    [JsonPropertyName("excludedPredefinedFunctions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? ExcludedPredefinedFunctions {
            get; set;
          }

    /// <summary>
    /// Optional. Whether to enable the prompt injection detection check on the computer use
    /// request.
    /// </summary>
    [JsonPropertyName("enablePromptInjectionDetection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnablePromptInjectionDetection {
            get; set;
          }

    /// <summary>
    /// Optional. A list of safety policies to disable for the computer use tool.
    /// </summary>
    [JsonPropertyName("disabledSafetyPolicies")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SafetyPolicy>
        ? DisabledSafetyPolicies {
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
        return JsonSerializer.Deserialize(jsonString, JsonConfig.TypeInfo<ComputerUse>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
