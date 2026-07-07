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
  /// Evaluates parsed response using match type against expression.
  /// </summary>

  public record ReinforcementTuningStringMatchRewardScorerStringMatchExpression {
    /// <summary>
    /// Match operation to use for evaluation.
    /// </summary>
    [JsonPropertyName("matchOperation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MatchOperation ? MatchOperation { get; set; }

    /// <summary>
    /// String or regular expression to match against. Customer can also provide a references map
    /// (key/value pairs) whose value will be substituted into the expression by referencing
    /// `references.key_name` (wrapped in double curly braces).
    /// </summary>
    [JsonPropertyName("expression")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Expression {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a
    /// ReinforcementTuningStringMatchRewardScorerStringMatchExpression object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReinforcementTuningStringMatchRewardScorerStringMatchExpression
    /// object, or null if deserialization fails.</returns>
    public static ReinforcementTuningStringMatchRewardScorerStringMatchExpression
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer
            .Deserialize<ReinforcementTuningStringMatchRewardScorerStringMatchExpression>(
                jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
