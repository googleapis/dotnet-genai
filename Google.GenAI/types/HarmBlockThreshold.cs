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
  /// Required. The harm block threshold.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<HarmBlockThreshold>))]
  public enum HarmBlockThreshold {
    /// <summary>
    /// Unspecified harm block threshold.
    /// </summary>
    [JsonPropertyName("HARM_BLOCK_THRESHOLD_UNSPECIFIED")] HARM_BLOCK_THRESHOLD_UNSPECIFIED,

    /// <summary>
    /// Block low threshold and above (i.e. block more).
    /// </summary>
    [JsonPropertyName("BLOCK_LOW_AND_ABOVE")] BLOCK_LOW_AND_ABOVE,

    /// <summary>
    /// Block medium threshold and above.
    /// </summary>
    [JsonPropertyName("BLOCK_MEDIUM_AND_ABOVE")] BLOCK_MEDIUM_AND_ABOVE,

    /// <summary>
    /// Block only high threshold (i.e. block less).
    /// </summary>
    [JsonPropertyName("BLOCK_ONLY_HIGH")] BLOCK_ONLY_HIGH,

    /// <summary>
    /// Block none.
    /// </summary>
    [JsonPropertyName("BLOCK_NONE")] BLOCK_NONE,

    /// <summary>
    /// Turn off the safety filter.
    /// </summary>
    [JsonPropertyName("OFF")] OFF
  }
}
