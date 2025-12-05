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
  /// Tuning Spec for Full Fine Tuning. This data type is not supported in Gemini API.
  /// </summary>

  public record FullFineTuningSpec {
    /// <summary>
    /// Optional. Hyperparameters for Full Fine Tuning.
    /// </summary>
    [JsonPropertyName("hyperParameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupervisedHyperParameters ? HyperParameters { get; set; }

    /// <summary>
    /// Training dataset used for tuning. The dataset can be specified as either a Cloud Storage
    /// path to a JSONL file or as the resource name of a Vertex Multimodal Dataset.
    /// </summary>
    [JsonPropertyName("trainingDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TrainingDatasetUri {
            get; set;
          }

    /// <summary>
    /// Optional. Validation dataset used for tuning. The dataset can be specified as either a Cloud
    /// Storage path to a JSONL file or as the resource name of a Vertex Multimodal Dataset.
    /// </summary>
    [JsonPropertyName("validationDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ValidationDatasetUri {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a FullFineTuningSpec object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized FullFineTuningSpec object, or null if deserialization
    /// fails.</returns>
    public static FullFineTuningSpec
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<FullFineTuningSpec>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
