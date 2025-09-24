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
  /// The different ways of handling user activity.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<ActivityHandling>))]
  public enum ActivityHandling {
    /// <summary>
    /// If unspecified, the default behavior is `START_OF_ACTIVITY_INTERRUPTS`.
    /// </summary>
    [JsonPropertyName("ACTIVITY_HANDLING_UNSPECIFIED")] ACTIVITY_HANDLING_UNSPECIFIED,

    /// <summary>
    /// If true, start of activity will interrupt the model's response (also called "barge in"). The
    /// model's current response will be cut-off in the moment of the interruption. This is the
    /// default behavior.
    /// </summary>
    [JsonPropertyName("START_OF_ACTIVITY_INTERRUPTS")] START_OF_ACTIVITY_INTERRUPTS,

    /// <summary>
    /// The model's response will not be interrupted.
    /// </summary>
    [JsonPropertyName("NO_INTERRUPTION")] NO_INTERRUPTION
  }
}
