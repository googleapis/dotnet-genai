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
  /// The status of the underlying model. This is used to indicate the stage of the underlying model
  /// and the retirement time if applicable. This data type is not supported in Vertex AI.
  /// </summary>

  public record ModelStatus {
    /// <summary>
    /// A message explaining the model status.
    /// </summary>
    [JsonPropertyName("message")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Message { get; set; }

    /// <summary>
    /// The stage of the underlying model.
    /// </summary>
    [JsonPropertyName("modelStage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ModelStage
        ? ModelStage {
            get; set;
          }

    /// <summary>
    /// The time at which the model will be retired.
    /// </summary>
    [JsonPropertyName("retirementTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? RetirementTime {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ModelStatus object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ModelStatus object, or null if deserialization fails.</returns>
    public static ModelStatus ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ModelStatus>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
