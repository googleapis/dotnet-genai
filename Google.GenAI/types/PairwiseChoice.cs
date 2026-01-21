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
  /// Output only. Pairwise metric choice. This enum is not supported in Gemini API.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum PairwiseChoice {
    /// <summary>
    /// Unspecified prediction choice.
    /// </summary>
    [JsonPropertyName("PAIRWISE_CHOICE_UNSPECIFIED")] PAIRWISE_CHOICE_UNSPECIFIED,

    /// <summary>
    /// Baseline prediction wins
    /// </summary>
    [JsonPropertyName("BASELINE")] BASELINE,

    /// <summary>
    /// Candidate prediction wins
    /// </summary>
    [JsonPropertyName("CANDIDATE")] CANDIDATE,

    /// <summary>
    /// Winner cannot be determined
    /// </summary>
    [JsonPropertyName("TIE")] TIE
  }
}
