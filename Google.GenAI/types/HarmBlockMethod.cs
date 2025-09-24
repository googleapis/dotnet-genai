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
  /// Optional. Specify if the threshold is used for probability or severity score. If not
  /// specified, the threshold is used for probability score.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<HarmBlockMethod>))]
  public enum HarmBlockMethod {
    /// <summary>
    /// The harm block method is unspecified.
    /// </summary>
    [JsonPropertyName("HARM_BLOCK_METHOD_UNSPECIFIED")] HARM_BLOCK_METHOD_UNSPECIFIED,

    /// <summary>
    /// The harm block method uses both probability and severity scores.
    /// </summary>
    [JsonPropertyName("SEVERITY")] SEVERITY,

    /// <summary>
    /// The harm block method uses the probability score.
    /// </summary>
    [JsonPropertyName("PROBABILITY")] PROBABILITY
  }
}
