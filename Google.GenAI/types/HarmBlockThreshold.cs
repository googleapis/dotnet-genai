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
  /// The threshold for blocking content. If the harm probability exceeds this threshold, the
  /// content will be blocked.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum HarmBlockThreshold {
    /// <summary>
    /// The harm block threshold is unspecified.
    /// </summary>
    [JsonPropertyName("HARM_BLOCK_THRESHOLD_UNSPECIFIED")] HARM_BLOCK_THRESHOLD_UNSPECIFIED,

    /// <summary>
    /// Block content with a low harm probability or higher.
    /// </summary>
    [JsonPropertyName("BLOCK_LOW_AND_ABOVE")] BLOCK_LOW_AND_ABOVE,

    /// <summary>
    /// Block content with a medium harm probability or higher.
    /// </summary>
    [JsonPropertyName("BLOCK_MEDIUM_AND_ABOVE")] BLOCK_MEDIUM_AND_ABOVE,

    /// <summary>
    /// Block content with a high harm probability.
    /// </summary>
    [JsonPropertyName("BLOCK_ONLY_HIGH")] BLOCK_ONLY_HIGH,

    /// <summary>
    /// Do not block any content, regardless of its harm probability.
    /// </summary>
    [JsonPropertyName("BLOCK_NONE")] BLOCK_NONE,

    /// <summary>
    /// Turn off the safety filter entirely.
    /// </summary>
    [JsonPropertyName("OFF")] OFF
  }
}
