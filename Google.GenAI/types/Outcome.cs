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
  /// Required. Outcome of the code execution.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<Outcome>))]
  public enum Outcome {
    /// <summary>
    /// Unspecified status. This value should not be used.
    /// </summary>
    [JsonPropertyName("OUTCOME_UNSPECIFIED")] OUTCOME_UNSPECIFIED,

    /// <summary>
    /// Code execution completed successfully.
    /// </summary>
    [JsonPropertyName("OUTCOME_OK")] OUTCOME_OK,

    /// <summary>
    /// Code execution finished but with a failure. `stderr` should contain the reason.
    /// </summary>
    [JsonPropertyName("OUTCOME_FAILED")] OUTCOME_FAILED,

    /// <summary>
    /// Code execution ran for too long, and was cancelled. There may or may not be a partial output
    /// present.
    /// </summary>
    [JsonPropertyName("OUTCOME_DEADLINE_EXCEEDED")] OUTCOME_DEADLINE_EXCEEDED
  }
}
