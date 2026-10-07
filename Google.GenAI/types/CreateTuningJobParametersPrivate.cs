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
  /// Fine-tuning job creation parameters - optional fields.
  /// </summary>

  internal record CreateTuningJobParametersPrivate {
    /// <summary>
    /// The base model that is being tuned, e.g., "gemini-flash-latest".
    /// </summary>
    [JsonPropertyName("baseModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? BaseModel { get; set; }

    /// <summary>
    /// The PreTunedModel that is being tuned.
    /// </summary>
    [JsonPropertyName("preTunedModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PreTunedModel
        ? PreTunedModel {
            get; set;
          }

    /// <summary>
    /// Cloud Storage path to file containing training dataset for tuning. The dataset must be
    /// formatted as a JSONL file.
    /// </summary>
    [JsonPropertyName("trainingDataset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TuningDataset
        ? TrainingDataset {
            get; set;
          }

    /// <summary>
    /// Configuration for the tuning job.
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CreateTuningJobConfig
        ? Config {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a CreateTuningJobParametersPrivate object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized CreateTuningJobParametersPrivate object, or null if
    /// deserialization fails.</returns>
    public static CreateTuningJobParametersPrivate
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(
            jsonString, JsonConfig.TypeInfo<CreateTuningJobParametersPrivate>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
