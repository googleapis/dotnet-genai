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
  /// Statistics computed for datasets used for preference optimization. This data type is not
  /// supported in Gemini API.
  /// </summary>

  public record PreferenceOptimizationDataStats {
    /// <summary>
    /// Output only. A partial sample of the indices (starting from 1) of the dropped examples.
    /// </summary>
    [JsonPropertyName("droppedExampleIndices")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongListConverter))]
    public List<long> ? DroppedExampleIndices { get; set; }

    /// <summary>
    /// Output only. For each index in `dropped_example_indices`, the user-facing reason why the
    /// example was dropped.
    /// </summary>
    [JsonPropertyName("droppedExampleReasons")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? DroppedExampleReasons {
            get; set;
          }

    /// <summary>
    /// Output only. Dataset distributions for scores variance per example.
    /// </summary>
    [JsonPropertyName("scoreVariancePerExampleDistribution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DatasetDistribution
        ? ScoreVariancePerExampleDistribution {
            get; set;
          }

    /// <summary>
    /// Output only. Dataset distributions for scores.
    /// </summary>
    [JsonPropertyName("scoresDistribution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DatasetDistribution
        ? ScoresDistribution {
            get; set;
          }

    /// <summary>
    /// Output only. Number of billable tokens in the tuning dataset.
    /// </summary>
    [JsonPropertyName("totalBillableTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? TotalBillableTokenCount {
            get; set;
          }

    /// <summary>
    /// Output only. Number of examples in the tuning dataset.
    /// </summary>
    [JsonPropertyName("tuningDatasetExampleCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? TuningDatasetExampleCount {
            get; set;
          }

    /// <summary>
    /// Output only. Number of tuning steps for this Tuning Job.
    /// </summary>
    [JsonPropertyName("tuningStepCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? TuningStepCount {
            get; set;
          }

    /// <summary>
    /// Output only. Sample user examples in the training dataset.
    /// </summary>
    [JsonPropertyName("userDatasetExamples")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GeminiPreferenceExample>
        ? UserDatasetExamples {
            get; set;
          }

    /// <summary>
    /// Output only. Dataset distributions for the user input tokens.
    /// </summary>
    [JsonPropertyName("userInputTokenDistribution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DatasetDistribution
        ? UserInputTokenDistribution {
            get; set;
          }

    /// <summary>
    /// Output only. Dataset distributions for the user output tokens.
    /// </summary>
    [JsonPropertyName("userOutputTokenDistribution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DatasetDistribution
        ? UserOutputTokenDistribution {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a PreferenceOptimizationDataStats object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized PreferenceOptimizationDataStats object, or null if deserialization
    /// fails.</returns>
    public static PreferenceOptimizationDataStats
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<PreferenceOptimizationDataStats>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
