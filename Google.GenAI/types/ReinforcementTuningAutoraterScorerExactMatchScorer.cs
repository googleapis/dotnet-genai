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
  /// Scores autorater responses by using exact string match reward scorer.
  /// </summary>

  public record ReinforcementTuningAutoraterScorerExactMatchScorer {
    /// <summary>
    /// Assigns this reward score if parsed response string equals the expression.
    /// </summary>
    [JsonPropertyName("correctAnswerReward")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double ? CorrectAnswerReward { get; set; }

    /// <summary>
    /// Assigns this reward score if parsed reward value does not equal the expression.
    /// </summary>
    [JsonPropertyName("wrongAnswerReward")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? WrongAnswerReward {
            get; set;
          }

    /// <summary>
    /// The string expression to match against. Supports substitution in the format of
    /// `references.reference` (wrapped in double curly braces) before matching. No regex support.
    /// </summary>
    [JsonPropertyName("expression")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Expression {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ReinforcementTuningAutoraterScorerExactMatchScorer object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReinforcementTuningAutoraterScorerExactMatchScorer object, or null
    /// if deserialization fails.</returns>
    public static ReinforcementTuningAutoraterScorerExactMatchScorer
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ReinforcementTuningAutoraterScorerExactMatchScorer>(
            jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
