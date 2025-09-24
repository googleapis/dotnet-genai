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
  /// Marks the end of user activity.    This can only be sent if automatic (i.e. server-side)
  /// activity detection is   disabled.
  /// </summary>

  public record RealtimeInputConfig {
    /// <summary>
    /// If not set, automatic activity detection is enabled by default. If automatic voice detection
    /// is disabled, the client must send activity signals.
    /// </summary>
    [JsonPropertyName("automaticActivityDetection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AutomaticActivityDetection ? AutomaticActivityDetection { get; set; }

    /// <summary>
    /// Defines what effect activity has.
    /// </summary>
    [JsonPropertyName("activityHandling")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ActivityHandling
        ? ActivityHandling {
            get; set;
          }

    /// <summary>
    /// Defines which input is included in the user's turn.
    /// </summary>
    [JsonPropertyName("turnCoverage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TurnCoverage
        ? TurnCoverage {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a RealtimeInputConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RealtimeInputConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static RealtimeInputConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<RealtimeInputConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
