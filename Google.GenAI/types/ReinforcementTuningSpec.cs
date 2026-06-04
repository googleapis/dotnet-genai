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
  /// Reinforcement tuning spec for tuning.
  /// </summary>

  public record ReinforcementTuningSpec {
    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("compositeRewardConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CompositeReinforcementTuningRewardConfig ? CompositeRewardConfig { get; set; }

    /// <summary>
    /// Cloud Storage path to file containing training dataset for tuning. The dataset must be
    /// formatted as a JSONL file.
    /// </summary>
    [JsonPropertyName("trainingDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TrainingDatasetUri {
            get; set;
          }

    /// <summary>
    /// Cloud Storage path to file containing validation dataset for tuning. The dataset must be
    /// formatted as a JSONL file. If no validation dataset is provided, by default the API splits
    /// 25% of the training dataset or 50 examples, whichever is larger, as the validation dataset.
    /// </summary>
    [JsonPropertyName("validationDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ValidationDatasetUri {
            get; set;
          }

    /// <summary>
    /// Additional hyper-parameters to use during tuning.
    /// </summary>
    [JsonPropertyName("hyperParameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningHyperParameters
        ? HyperParameters {
            get; set;
          }

    /// <summary>
    /// Single reward function configuration for reinforcement tuning.
    /// </summary>
    [JsonPropertyName("singleRewardConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SingleReinforcementTuningRewardConfig
        ? SingleRewardConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ReinforcementTuningSpec object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReinforcementTuningSpec object, or null if deserialization
    /// fails.</returns>
    public static ReinforcementTuningSpec
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ReinforcementTuningSpec>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
