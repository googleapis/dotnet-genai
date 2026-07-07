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
    /// Number of training epochs for the tuning job.
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
    /// Adapter size for Reinforcement Tuning.
    /// </summary>
    [JsonPropertyName("adapterSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdapterSize
        ? AdapterSize {
            get; set;
          }

    /// <summary>
    /// Number of different responses to generate per prompt during tuning.
    /// </summary>
    [JsonPropertyName("samplesPerPrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? SamplesPerPrompt {
            get; set;
          }

    /// <summary>
    /// Batch size for the tuning job. How many prompts to process at a train step. If not set, the
    /// batch size will be determined automatically.
    /// </summary>
    [JsonPropertyName("batchSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? BatchSize {
            get; set;
          }

    /// <summary>
    /// How often (in steps) to evaluate the tuning job during training. If not set, evaluation will
    /// run per epoch.
    /// </summary>
    [JsonPropertyName("evaluateInterval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? EvaluateInterval {
            get; set;
          }

    /// <summary>
    /// How often (in steps) to save checkpoints during training. If not set, one checkpoint per
    /// epoch will be saved.
    /// </summary>
    [JsonPropertyName("checkpointInterval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CheckpointInterval {
            get; set;
          }

    /// <summary>
    /// The maximum number of tokens to generate per prompt. If not set, defaults to 32768.
    /// </summary>
    [JsonPropertyName("maxOutputTokens")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxOutputTokens {
            get; set;
          }

    /// <summary>
    /// Indicates the maximum thinking depth. Use with earlier models shall result in error.
    /// </summary>
    [JsonPropertyName("thinkingLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ReinforcementTuningThinkingLevel
        ? ThinkingLevel {
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
        return JsonSerializer.Deserialize<ReinforcementTuningHyperParameters>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
