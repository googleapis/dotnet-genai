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
  /// Fine-tuning job creation request - optional fields.
  /// </summary>

  public record CreateTuningJobConfig {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions ? HttpOptions { get; set; }

    /// <summary>
    /// The method to use for tuning (SUPERVISED_FINE_TUNING or PREFERENCE_TUNING or DISTILLATION).
    /// If not set, the default method (SFT) will be used.
    /// </summary>
    [JsonPropertyName("method")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TuningMethod
        ? Method {
            get; set;
          }

    /// <summary>
    /// Validation dataset for tuning. The dataset must be formatted as a JSONL file.
    /// </summary>
    [JsonPropertyName("validationDataset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TuningValidationDataset
        ? ValidationDataset {
            get; set;
          }

    /// <summary>
    /// The display name of the tuned Model. The name can be up to 128 characters long and can
    /// consist of any UTF-8 characters.
    /// </summary>
    [JsonPropertyName("tunedModelDisplayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TunedModelDisplayName {
            get; set;
          }

    /// <summary>
    /// The description of the TuningJob
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Description {
            get; set;
          }

    /// <summary>
    /// Number of complete passes the model makes over the entire training dataset during training.
    /// </summary>
    [JsonPropertyName("epochCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? EpochCount {
            get; set;
          }

    /// <summary>
    /// Multiplier for adjusting the default learning rate.
    /// </summary>
    [JsonPropertyName("learningRateMultiplier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? LearningRateMultiplier {
            get; set;
          }

    /// <summary>
    /// If set to true, disable intermediate checkpoints and only the last checkpoint will be
    /// exported. Otherwise, enable intermediate checkpoints.
    /// </summary>
    [JsonPropertyName("exportLastCheckpointOnly")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? ExportLastCheckpointOnly {
            get; set;
          }

    /// <summary>
    /// The optional checkpoint id of the pre-tuned model to use for tuning, if applicable.
    /// </summary>
    [JsonPropertyName("preTunedModelCheckpointId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PreTunedModelCheckpointId {
            get; set;
          }

    /// <summary>
    /// Adapter size for tuning.
    /// </summary>
    [JsonPropertyName("adapterSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdapterSize
        ? AdapterSize {
            get; set;
          }

    /// <summary>
    /// The batch size hyperparameter for tuning. If not set, a default of 4 or 16 will be used
    /// based on the number of training examples.
    /// </summary>
    [JsonPropertyName("batchSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? BatchSize {
            get; set;
          }

    /// <summary>
    /// The learning rate hyperparameter for tuning. If not set, a default of 0.001 or 0.0002 will
    /// be calculated based on the number of training examples.
    /// </summary>
    [JsonPropertyName("learningRate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? LearningRate {
            get; set;
          }

    /// <summary>
    /// Optional. The labels with user-defined metadata to organize TuningJob and generated
    /// resources such as Model and Endpoint. Label keys and values can be no longer than 64
    /// characters (Unicode codepoints), can only contain lowercase letters, numeric characters,
    /// underscores and dashes. International characters are allowed. See https://goo.gl/xmQnxf for
    /// more information and examples of labels.
    /// </summary>
    [JsonPropertyName("labels")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>
        ? Labels {
            get; set;
          }

    /// <summary>
    /// Weight for KL Divergence regularization, Preference Optimization tuning only.
    /// </summary>
    [JsonPropertyName("beta")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Beta {
            get; set;
          }

    /// <summary>
    /// The base teacher model that is being distilled. Distillation only.
    /// </summary>
    [JsonPropertyName("baseTeacherModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? BaseTeacherModel {
            get; set;
          }

    /// <summary>
    /// The resource name of the Tuned teacher model. Distillation only.
    /// </summary>
    [JsonPropertyName("tunedTeacherModelSource")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TunedTeacherModelSource {
            get; set;
          }

    /// <summary>
    /// Multiplier for adjusting the weight of the SFT loss. Distillation only.
    /// </summary>
    [JsonPropertyName("sftLossWeightMultiplier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? SftLossWeightMultiplier {
            get; set;
          }

    /// <summary>
    /// The Google Cloud Storage location where the tuning job outputs are written.
    /// </summary>
    [JsonPropertyName("outputUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputUri {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a CreateTuningJobConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized CreateTuningJobConfig object, or null if deserialization
    /// fails.</returns>
    public static CreateTuningJobConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<CreateTuningJobConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
