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
  /// A tuning job.
  /// </summary>

  public record TuningJob {
    /// <summary>
    /// Used to retain the full HTTP response.
    /// </summary>
    [JsonPropertyName("sdkHttpResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpResponse ? SdkHttpResponse { get; set; }

    /// <summary>
    /// Output only. Identifier. Resource name of a TuningJob. Format:
    /// `projects/{project}/locations/{location}/tuningJobs/{tuning_job}`
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Name {
            get; set;
          }

    /// <summary>
    /// Output only. The detailed state of the job.
    /// </summary>
    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JobState
        ? State {
            get; set;
          }

    /// <summary>
    /// Output only. Time when the TuningJob was created.
    /// </summary>
    [JsonPropertyName("createTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? CreateTime {
            get; set;
          }

    /// <summary>
    /// Output only. Time when the TuningJob for the first time entered the `JOB_STATE_RUNNING`
    /// state.
    /// </summary>
    [JsonPropertyName("startTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? StartTime {
            get; set;
          }

    /// <summary>
    /// Output only. Time when the TuningJob entered any of the following JobStates:
    /// `JOB_STATE_SUCCEEDED`, `JOB_STATE_FAILED`, `JOB_STATE_CANCELLED`, `JOB_STATE_EXPIRED`.
    /// </summary>
    [JsonPropertyName("endTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? EndTime {
            get; set;
          }

    /// <summary>
    /// Output only. Time when the TuningJob was most recently updated.
    /// </summary>
    [JsonPropertyName("updateTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? UpdateTime {
            get; set;
          }

    /// <summary>
    /// Output only. Only populated when job's state is `JOB_STATE_FAILED` or `JOB_STATE_CANCELLED`.
    /// </summary>
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleRpcStatus
        ? Error {
            get; set;
          }

    /// <summary>
    /// Optional. The description of the TuningJob.
    /// </summary>
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Description {
            get; set;
          }

    /// <summary>
    /// The base model that is being tuned. See Supported models
    /// (https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/tuning#supported_models).
    /// </summary>
    [JsonPropertyName("baseModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? BaseModel {
            get; set;
          }

    /// <summary>
    /// Output only. The tuned model resources associated with this TuningJob.
    /// </summary>
    [JsonPropertyName("tunedModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TunedModel
        ? TunedModel {
            get; set;
          }

    /// <summary>
    /// The pre-tuned model for continuous tuning.
    /// </summary>
    [JsonPropertyName("preTunedModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PreTunedModel
        ? PreTunedModel {
            get; set;
          }

    /// <summary>
    /// Tuning Spec for Supervised Fine Tuning.
    /// </summary>
    [JsonPropertyName("supervisedTuningSpec")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SupervisedTuningSpec
        ? SupervisedTuningSpec {
            get; set;
          }

    /// <summary>
    /// Tuning Spec for Preference Optimization.
    /// </summary>
    [JsonPropertyName("preferenceOptimizationSpec")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PreferenceOptimizationSpec
        ? PreferenceOptimizationSpec {
            get; set;
          }

    /// <summary>
    /// Output only. The tuning data statistics associated with this TuningJob.
    /// </summary>
    [JsonPropertyName("tuningDataStats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TuningDataStats
        ? TuningDataStats {
            get; set;
          }

    /// <summary>
    /// Customer-managed encryption key options for a TuningJob. If this is set, then all resources
    /// created by the TuningJob will be encrypted with the provided encryption key.
    /// </summary>
    [JsonPropertyName("encryptionSpec")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EncryptionSpec
        ? EncryptionSpec {
            get; set;
          }

    /// <summary>
    /// Tuning Spec for open sourced and third party Partner models.
    /// </summary>
    [JsonPropertyName("partnerModelTuningSpec")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PartnerModelTuningSpec
        ? PartnerModelTuningSpec {
            get; set;
          }

    /// <summary>
    /// Optional. The user-provided path to custom model weights. Set this field to tune a custom
    /// model. The path must be a Cloud Storage directory that contains the model weights in
    /// .safetensors format along with associated model metadata files. If this field is set, the
    /// base_model field must still be set to indicate which base model the custom model is derived
    /// from. This feature is only available for open source models.
    /// </summary>
    [JsonPropertyName("customBaseModel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? CustomBaseModel {
            get; set;
          }

    /// <summary>
    /// Output only. Evaluation runs for the Tuning Job.
    /// </summary>
    [JsonPropertyName("evaluateDatasetRuns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<EvaluateDatasetRun>
        ? EvaluateDatasetRuns {
            get; set;
          }

    /// <summary>
    /// Output only. The Experiment associated with this TuningJob.
    /// </summary>
    [JsonPropertyName("experiment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Experiment {
            get; set;
          }

    /// <summary>
    /// Tuning Spec for Full Fine Tuning.
    /// </summary>
    [JsonPropertyName("fullFineTuningSpec")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FullFineTuningSpec
        ? FullFineTuningSpec {
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
    /// Optional. Cloud Storage path to the directory where tuning job outputs are written to. This
    /// field is only available and required for open source models.
    /// </summary>
    [JsonPropertyName("outputUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputUri {
            get; set;
          }

    /// <summary>
    /// Output only. The resource name of the PipelineJob associated with the TuningJob. Format:
    /// `projects/{project}/locations/{location}/pipelineJobs/{pipeline_job}`.
    /// </summary>
    [JsonPropertyName("pipelineJob")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? PipelineJob {
            get; set;
          }

    /// <summary>
    /// The service account that the tuningJob workload runs as. If not specified, the Vertex AI
    /// Secure Fine-Tuned Service Agent in the project will be used. See
    /// https://cloud.google.com/iam/docs/service-agents#vertex-ai-secure-fine-tuning-service-agent
    /// Users starting the pipeline must have the `iam.serviceAccounts.actAs` permission on this
    /// service account.
    /// </summary>
    [JsonPropertyName("serviceAccount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ServiceAccount {
            get; set;
          }

    /// <summary>
    /// Optional. The display name of the TunedModel. The name can be up to 128 characters long and
    /// can consist of any UTF-8 characters. For continuous tuning, tuned_model_display_name will by
    /// default use the same display name as the pre-tuned model. If a new display name is provided,
    /// the tuning job will create a new model instead of a new version.
    /// </summary>
    [JsonPropertyName("tunedModelDisplayName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TunedModelDisplayName {
            get; set;
          }

    /// <summary>
    /// Output only. The detail state of the tuning job (while the overall `JobState` is running).
    /// </summary>
    [JsonPropertyName("tuningJobState")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TuningJobState
        ? TuningJobState {
            get; set;
          }

    /// <summary>
    /// Tuning Spec for Veo Tuning.
    /// </summary>
    [JsonPropertyName("veoTuningSpec")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VeoTuningSpec
        ? VeoTuningSpec {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a TuningJob object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized TuningJob object, or null if deserialization fails.</returns>
    public static TuningJob ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<TuningJob>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
