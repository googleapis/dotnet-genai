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
  /// The configuration for routing the request to a specific model. This can be used to control
  /// which model is used for the generation, either automatically or by specifying a model name.
  /// This data type is not supported in Gemini API.
  /// </summary>

  public record GenerationConfigRoutingConfig {
    /// <summary>
    /// In this mode, the model is selected automatically based on the content of the request.
    /// </summary>
    [JsonPropertyName("autoMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfigRoutingConfigAutoRoutingMode ? AutoMode { get; set; }

    /// <summary>
    /// In this mode, the model is specified manually.
    /// </summary>
    [JsonPropertyName("manualMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerationConfigRoutingConfigManualRoutingMode
        ? ManualMode {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerationConfigRoutingConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerationConfigRoutingConfig object, or null if deserialization
    /// fails.</returns>
    public static GenerationConfigRoutingConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerationConfigRoutingConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
