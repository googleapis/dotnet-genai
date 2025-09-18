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
  /// Configuration for a Control reference image.
  /// </summary>

  public record ControlReferenceConfig {
    /// <summary>
    /// The type of control reference image to use.
    /// </summary>
    [JsonPropertyName("controlType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ControlReferenceType ? ControlType { get; set; }

    /// <summary>
    /// Defaults to False. When set to True, the control image will be  computed by the model based
    /// on the control type. When set to False,  the control image must be provided by the user.
    /// </summary>
    [JsonPropertyName("enableControlImageComputation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnableControlImageComputation {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ControlReferenceConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ControlReferenceConfig object, or null if deserialization
    /// fails.</returns>
    public static ControlReferenceConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ControlReferenceConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
