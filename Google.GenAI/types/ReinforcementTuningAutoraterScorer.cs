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
  /// Reinforcement tuning autorater scorer.
  /// </summary>

  public record ReinforcementTuningAutoraterScorer {
    /// <summary>
    /// Autorater config for evaluation.
    /// </summary>
    [JsonPropertyName("autoraterConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AutoraterConfig ? AutoraterConfig { get; set; }

    /// <summary>
    /// Allows substituting `prompt`, `response`, `system_instruction` and `references.reference`
    /// (each wrapped in double curly braces) into the autorater prompt.
    /// </summary>
    [JsonPropertyName("autoraterPrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? AutoraterPrompt {
            get; set;
          }

    /// <summary>
    /// Parses autorater returned response.
    /// </summary>
    [JsonPropertyName("autoraterResponseParseConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningParseResponseConfig
        ? AutoraterResponseParseConfig {
            get; set;
          }

    /// <summary>
    /// Scores autorater responses by directly converting parsed autorater response to float reward.
    /// </summary>
    [JsonPropertyName("parsedResponseConversionScorer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningAutoraterScorerParsedResponseConversionScorer
        ? ParsedResponseConversionScorer {
            get; set;
          }

    /// <summary>
    /// Scores autorater responses by using exact string match reward scorer.
    /// </summary>
    [JsonPropertyName("exactMatchScorer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningAutoraterScorerExactMatchScorer
        ? ExactMatchScorer {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ReinforcementTuningAutoraterScorer object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReinforcementTuningAutoraterScorer object, or null if
    /// deserialization fails.</returns>
    public static ReinforcementTuningAutoraterScorer
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ReinforcementTuningAutoraterScorer>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
