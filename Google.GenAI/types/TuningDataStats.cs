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
  /// The tuning data statistic values for TuningJob. This data type is not supported in Gemini API.
  /// </summary>

  public record TuningDataStats {
    /// <summary>
    /// Output only. Statistics for distillation prompt dataset. These statistics do not include the
    /// responses sampled from the teacher model.
    /// </summary>
    [JsonPropertyName("distillationDataStats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DistillationDataStats ? DistillationDataStats { get; set; }

    /// <summary>
    /// Output only. Statistics for preference optimization.
    /// </summary>
    [JsonPropertyName("preferenceOptimizationDataStats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PreferenceOptimizationDataStats
        ? PreferenceOptimizationDataStats {
            get; set;
          }

    /// <summary>
    /// The SFT Tuning data stats.
    /// </summary>
    [JsonPropertyName("supervisedTuningDataStats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupervisedTuningDataStats
        ? SupervisedTuningDataStats {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a TuningDataStats object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized TuningDataStats object, or null if deserialization
    /// fails.</returns>
    public static TuningDataStats
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<TuningDataStats>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
