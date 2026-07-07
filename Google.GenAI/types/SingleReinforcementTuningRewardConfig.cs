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
  /// Single reinforcement tuning reward config.
  /// </summary>

  public record SingleReinforcementTuningRewardConfig {
    /// <summary>
    /// Scores parsed responses for autorater use cases by using a model to compute the reward.
    /// </summary>
    [JsonPropertyName("autoraterScorer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningAutoraterScorer ? AutoraterScorer { get; set; }

    /// <summary>
    /// A unique reward name used to identify each single reinforcement tuning reward.
    /// </summary>
    [JsonPropertyName("rewardName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? RewardName {
            get; set;
          }

    /// <summary>
    /// Defines how to parse sample response.
    /// </summary>
    [JsonPropertyName("parseResponseConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningParseResponseConfig
        ? ParseResponseConfig {
            get; set;
          }

    /// <summary>
    /// Scores parsed responses for code execution use cases.
    /// </summary>
    [JsonPropertyName("codeExecutionRewardScorer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningCodeExecutionRewardScorer
        ? CodeExecutionRewardScorer {
            get; set;
          }

    /// <summary>
    /// Scores parsed responses for simple string matching use cases against reference answer
    /// without writing python code.
    /// </summary>
    [JsonPropertyName("stringMatchRewardScorer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningStringMatchRewardScorer
        ? StringMatchRewardScorer {
            get; set;
          }

    /// <summary>
    /// Scores parsed responses by calling a Cloud Run service.
    /// </summary>
    [JsonPropertyName("cloudRunRewardScorer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningCloudRunRewardScorer
        ? CloudRunRewardScorer {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a SingleReinforcementTuningRewardConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SingleReinforcementTuningRewardConfig object, or null if
    /// deserialization fails.</returns>
    public static SingleReinforcementTuningRewardConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<SingleReinforcementTuningRewardConfig>(jsonString,
                                                                                 options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
