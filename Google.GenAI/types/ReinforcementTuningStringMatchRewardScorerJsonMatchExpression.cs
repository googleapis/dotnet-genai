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
  /// Converts parsed responses to JSON format, finds the first-level matching key, then performs
  /// StringMatchExpression on the value.
  /// </summary>

  public record ReinforcementTuningStringMatchRewardScorerJsonMatchExpression {
    /// <summary>
    /// Json key name to find the value to match against.
    /// </summary>
    [JsonPropertyName("keyName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? KeyName { get; set; }

    /// <summary>
    /// String match expression to match against the value of json key.
    /// </summary>
    [JsonPropertyName("valueStringMatchExpression")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningStringMatchRewardScorerStringMatchExpression
        ? ValueStringMatchExpression {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a
    /// ReinforcementTuningStringMatchRewardScorerJsonMatchExpression object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReinforcementTuningStringMatchRewardScorerJsonMatchExpression
    /// object, or null if deserialization fails.</returns>
    public static ReinforcementTuningStringMatchRewardScorerJsonMatchExpression
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer
            .Deserialize<ReinforcementTuningStringMatchRewardScorerJsonMatchExpression>(jsonString,
                                                                                        options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
