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

namespace Google.GenAI.Types
{
  /// <summary>
  /// Sites with confidence level chosen &amp; above this value will be blocked from the search
  /// results. This enum is not supported in Gemini API.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum PhishBlockThreshold
  {
    /// <summary>
    /// Defaults to unspecified.
    /// </summary>
    [JsonPropertyName("PHISH_BLOCK_THRESHOLD_UNSPECIFIED")] PHISH_BLOCK_THRESHOLD_UNSPECIFIED,

    /// <summary>
    /// Blocks Low and above confidence URL that is risky.
    /// </summary>
    [JsonPropertyName("BLOCK_LOW_AND_ABOVE")] BLOCK_LOW_AND_ABOVE,

    /// <summary>
    /// Blocks Medium and above confidence URL that is risky.
    /// </summary>
    [JsonPropertyName("BLOCK_MEDIUM_AND_ABOVE")] BLOCK_MEDIUM_AND_ABOVE,

    /// <summary>
    /// Blocks High and above confidence URL that is risky.
    /// </summary>
    [JsonPropertyName("BLOCK_HIGH_AND_ABOVE")] BLOCK_HIGH_AND_ABOVE,

    /// <summary>
    /// Blocks Higher and above confidence URL that is risky.
    /// </summary>
    [JsonPropertyName("BLOCK_HIGHER_AND_ABOVE")] BLOCK_HIGHER_AND_ABOVE,

    /// <summary>
    /// Blocks Very high and above confidence URL that is risky.
    /// </summary>
    [JsonPropertyName("BLOCK_VERY_HIGH_AND_ABOVE")] BLOCK_VERY_HIGH_AND_ABOVE,

    /// <summary>
    /// Blocks Extremely high confidence URL that is risky.
    /// </summary>
    [JsonPropertyName("BLOCK_ONLY_EXTREMELY_HIGH")] BLOCK_ONLY_EXTREMELY_HIGH
  }
}
