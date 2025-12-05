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

using System.Text.Json.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Output only. The detail state of the tuning job (while the overall `JobState` is running).
  /// This enum is not supported in Gemini API.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum TuningJobState {
    /// <summary>
    /// Default tuning job state.
    /// </summary>
    [JsonPropertyName("TUNING_JOB_STATE_UNSPECIFIED")] TUNING_JOB_STATE_UNSPECIFIED,

    /// <summary>
    /// Tuning job is waiting for job quota.
    /// </summary>
    [JsonPropertyName("TUNING_JOB_STATE_WAITING_FOR_QUOTA")] TUNING_JOB_STATE_WAITING_FOR_QUOTA,

    /// <summary>
    /// Tuning job is validating the dataset.
    /// </summary>
    [JsonPropertyName("TUNING_JOB_STATE_PROCESSING_DATASET")] TUNING_JOB_STATE_PROCESSING_DATASET,

    /// <summary>
    /// Tuning job is waiting for hardware capacity.
    /// </summary>
    [JsonPropertyName(
        "TUNING_JOB_STATE_WAITING_FOR_CAPACITY")] TUNING_JOB_STATE_WAITING_FOR_CAPACITY,

    /// <summary>
    /// Tuning job is running.
    /// </summary>
    [JsonPropertyName("TUNING_JOB_STATE_TUNING")] TUNING_JOB_STATE_TUNING,

    /// <summary>
    /// Tuning job is doing some post processing steps.
    /// </summary>
    [JsonPropertyName("TUNING_JOB_STATE_POST_PROCESSING")] TUNING_JOB_STATE_POST_PROCESSING
  }
}
