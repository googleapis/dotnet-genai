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
  /// Hyperparameters for Reinforcement Tuning.
  /// </summary>

  public record ReinforcementTuningHyperParameters {
    /// <summary>
    /// Optional. Number of training epoches for the tuning job.
    /// </summary>
    [JsonPropertyName("epochCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long ? EpochCount { get; set; }

    /// <summary>
    /// Learning rate multiplier for Reinforcement Learning.
    /// </summary>
    [JsonPropertyName("learningRateMultiplier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? LearningRateMultiplier {
            get; set;
          }

    /// <summary>
    /// Optional. Adapter size for Reinforcement Tuning.
    /// </summary>
    [JsonPropertyName("adapterSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdapterSize
        ? AdapterSize {
            get; set;
          }

    /// <summary>
    /// Optional. Number of different responses to generate per prompt during tuning.
    /// </summary>
    [JsonPropertyName("samplesPerPrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? SamplesPerPrompt {
            get; set;
          }

    /// <summary>
    /// Optional. Batch size for the tuning job. How many prompts to process at a train step. If not
    /// set, the batch size will be determined automatically.
    /// </summary>
    [JsonPropertyName("batchSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? BatchSize {
            get; set;
          }

    /// <summary>
    /// Optional. How often at steps to evaluate the tuning job during training. If not set, evel
    /// will be run per epoch. `total_steps = epoch_count * samples_per_prompt /
    /// total_prompts_in_dataset`
    /// </summary>
    [JsonPropertyName("evaluateInterval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? EvaluateInterval {
            get; set;
          }

    /// <summary>
    /// Optional. How often at steps to save checkpoints during training. If not set, one checkpoint
    /// per epoch will be set. ```total_steps = epoch_count * samples_per_prompt /
    /// total_prompts_in_dataset```
    /// </summary>
    [JsonPropertyName("checkpointInterval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CheckpointInterval {
            get; set;
          }

    /// <summary>
    /// Optional. The maximum number of tokens to generate per prompt. Default to 32768.
    /// </summary>
    [JsonPropertyName("maxOutputTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxOutputTokens {
            get; set;
          }

    /// <summary>
    /// Indicates the maximum thinking depth during tuning. Starting from Gemini 3.5 models, the old
    /// thinking_budget will no longer be supported and will result in a user error if set. Instead,
    /// users should use the thinking_level parameter to control the maximum thinking depth.
    /// </summary>
    [JsonPropertyName("thinkingLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningThinkingLevel
        ? ThinkingLevel {
            get; set;
          }

    /// <summary>
    /// Optional. The thinking budget for the tuning job to optimize for (Gemini 2.5 only). * -1
    /// means dynamic thinking * 0 means no thinking * > 0 means thinking budget in tokens If not
    /// set, default to -1 (dynamic thinking).
    /// </summary>
    [JsonPropertyName("thinkingBudget")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ThinkingBudget {
            get; set;
          }

    /// <summary>
    /// Optional. Number of steps for the tuning job (mutually exclusive with epoch_count).
    /// </summary>
    [JsonPropertyName("stepCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? StepCount {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ReinforcementTuningHyperParameters object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReinforcementTuningHyperParameters object, or null if
    /// deserialization fails.</returns>
    public static ReinforcementTuningHyperParameters
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(
            jsonString, JsonConfig.TypeInfo<ReinforcementTuningHyperParameters>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
