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
  /// Statistics computed over a tuning dataset. This data type is not supported in Gemini API.
  /// </summary>

  public record DatasetStats {
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
    /// Output only. Number of billable characters in the tuning dataset.
    /// </summary>
    [JsonPropertyName("totalBillableCharacterCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? TotalBillableCharacterCount {
            get; set;
          }

    /// <summary>
    /// Output only. Number of tuning characters in the tuning dataset.
    /// </summary>
    [JsonPropertyName("totalTuningCharacterCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(StringToNullableLongConverter))]
    public long
        ? TotalTuningCharacterCount {
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
    /// Output only. Sample user messages in the training dataset uri.
    /// </summary>
    [JsonPropertyName("userDatasetExamples")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Content>
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
    /// Output only. Dataset distributions for the messages per example.
    /// </summary>
    [JsonPropertyName("userMessagePerExampleDistribution")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DatasetDistribution
        ? UserMessagePerExampleDistribution {
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
    /// Deserializes a JSON string to a DatasetStats object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized DatasetStats object, or null if deserialization fails.</returns>
    public static DatasetStats
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<DatasetStats>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
