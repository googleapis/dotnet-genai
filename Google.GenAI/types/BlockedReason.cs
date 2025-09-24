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
  /// Output only. Blocked reason.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<BlockedReason>))]
  public enum BlockedReason {
    /// <summary>
    /// Unspecified blocked reason.
    /// </summary>
    [JsonPropertyName("BLOCKED_REASON_UNSPECIFIED")] BLOCKED_REASON_UNSPECIFIED,

    /// <summary>
    /// Candidates blocked due to safety.
    /// </summary>
    [JsonPropertyName("SAFETY")] SAFETY,

    /// <summary>
    /// Candidates blocked due to other reason.
    /// </summary>
    [JsonPropertyName("OTHER")] OTHER,

    /// <summary>
    /// Candidates blocked due to the terms which are included from the terminology blocklist.
    /// </summary>
    [JsonPropertyName("BLOCKLIST")] BLOCKLIST,

    /// <summary>
    /// Candidates blocked due to prohibited content.
    /// </summary>
    [JsonPropertyName("PROHIBITED_CONTENT")] PROHIBITED_CONTENT,

    /// <summary>
    /// Candidates blocked due to unsafe image generation content.
    /// </summary>
    [JsonPropertyName("IMAGE_SAFETY")] IMAGE_SAFETY
  }
}
