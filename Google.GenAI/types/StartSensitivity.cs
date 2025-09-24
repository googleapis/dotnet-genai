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
  /// Start of speech sensitivity.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<StartSensitivity>))]
  public enum StartSensitivity {
    /// <summary>
    /// The default is START_SENSITIVITY_LOW.
    /// </summary>
    [JsonPropertyName("START_SENSITIVITY_UNSPECIFIED")] START_SENSITIVITY_UNSPECIFIED,

    /// <summary>
    /// Automatic detection will detect the start of speech more often.
    /// </summary>
    [JsonPropertyName("START_SENSITIVITY_HIGH")] START_SENSITIVITY_HIGH,

    /// <summary>
    /// Automatic detection will detect the start of speech less often.
    /// </summary>
    [JsonPropertyName("START_SENSITIVITY_LOW")] START_SENSITIVITY_LOW
  }
}
