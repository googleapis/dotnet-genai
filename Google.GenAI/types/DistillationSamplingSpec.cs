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
  /// Distillation sampling spec for tuning.
  /// </summary>

  public record DistillationSamplingSpec {
    /// <summary>
    /// The base teacher model that is being distilled. See Supported models
    /// (https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/tuning#supported_models).
    /// </summary>
    [JsonPropertyName("baseTeacherModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? BaseTeacherModel { get; set; }

    /// <summary>
    /// The resource name of the Tuned teacher model. Format:
    /// `projects/{project}/locations/{location}/models/{model}`.
    /// </summary>
    [JsonPropertyName("tunedTeacherModelSource")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TunedTeacherModelSource {
            get; set;
          }

    /// <summary>
    /// Cloud Storage path to file containing validation dataset for distillation. The dataset must
    /// be formatted as a JSONL file.
    /// </summary>
    [JsonPropertyName("validationDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ValidationDatasetUri {
            get; set;
          }

    /// <summary>
    /// Cloud Storage path to file containing prompt dataset for distillation. The dataset must be
    /// formatted as a JSONL file.
    /// </summary>
    [JsonPropertyName("promptDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PromptDatasetUri {
            get; set;
          }

    /// <summary>
    /// Hyperparameters for distillation tuning.
    /// </summary>
    [JsonPropertyName("hyperparameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DistillationHyperParameters
        ? Hyperparameters {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a DistillationSamplingSpec object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized DistillationSamplingSpec object, or null if deserialization
    /// fails.</returns>
    public static DistillationSamplingSpec
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<DistillationSamplingSpec>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
