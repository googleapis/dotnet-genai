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
  /// Distillation tuning spec for tuning.
  /// </summary>

  public record DistillationSpec {
    /// <summary>
    /// The GCS URI of the prompt dataset to use during distillation.
    /// </summary>
    [JsonPropertyName("promptDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? PromptDatasetUri { get; set; }

    /// <summary>
    /// The base teacher model that is being distilled. See Supported models
    /// (https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/tuning#supported_models).
    /// </summary>
    [JsonPropertyName("baseTeacherModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? BaseTeacherModel {
            get; set;
          }

    /// <summary>
    /// Optional. Hyperparameters for Distillation.
    /// </summary>
    [JsonPropertyName("hyperParameters")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DistillationHyperParameters
        ? HyperParameters {
            get; set;
          }

    /// <summary>
    /// Deprecated. A path in a Cloud Storage bucket, which will be treated as the root output
    /// directory of the distillation pipeline. It is used by the system to generate the paths of
    /// output artifacts.
    /// </summary>
    [JsonPropertyName("pipelineRootDirectory")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PipelineRootDirectory {
            get; set;
          }

    /// <summary>
    /// The student model that is being tuned, e.g., "google/gemma-2b-1.1-it". Deprecated. Use
    /// base_model instead.
    /// </summary>
    [JsonPropertyName("studentModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? StudentModel {
            get; set;
          }

    /// <summary>
    /// Deprecated. Cloud Storage path to file containing training dataset for tuning. The dataset
    /// must be formatted as a JSONL file.
    /// </summary>
    [JsonPropertyName("trainingDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TrainingDatasetUri {
            get; set;
          }

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
    /// Optional. Cloud Storage path to file containing validation dataset for tuning. The dataset
    /// must be formatted as a JSONL file.
    /// </summary>
    [JsonPropertyName("validationDatasetUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ValidationDatasetUri {
            get; set;
          }

    /// <summary>
    /// Tuning mode for tuning.
    /// </summary>
    [JsonPropertyName("tuningMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TuningMode
        ? TuningMode {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a DistillationSpec object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized DistillationSpec object, or null if deserialization
    /// fails.</returns>
    public static DistillationSpec
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<DistillationSpec>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
