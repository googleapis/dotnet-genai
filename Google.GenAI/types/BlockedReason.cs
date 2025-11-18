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
  /// Output only. The reason why the prompt was blocked.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum BlockedReason
  {
    /// <summary>
    /// The blocked reason is unspecified.
    /// </summary>
    [JsonPropertyName("BLOCKED_REASON_UNSPECIFIED")] BLOCKED_REASON_UNSPECIFIED,

    /// <summary>
    /// The prompt was blocked for safety reasons.
    /// </summary>
    [JsonPropertyName("SAFETY")] SAFETY,

    /// <summary>
    /// The prompt was blocked for other reasons. For example, it may be due to the prompt's
    /// language, or because it contains other harmful content.
    /// </summary>
    [JsonPropertyName("OTHER")] OTHER,

    /// <summary>
    /// The prompt was blocked because it contains a term from the terminology blocklist.
    /// </summary>
    [JsonPropertyName("BLOCKLIST")] BLOCKLIST,

    /// <summary>
    /// The prompt was blocked because it contains prohibited content.
    /// </summary>
    [JsonPropertyName("PROHIBITED_CONTENT")] PROHIBITED_CONTENT,

    /// <summary>
    /// The prompt was blocked because it contains content that is unsafe for image generation.
    /// </summary>
    [JsonPropertyName("IMAGE_SAFETY")] IMAGE_SAFETY,

    /// <summary>
    /// The prompt was blocked by Model Armor. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("MODEL_ARMOR")] MODEL_ARMOR,

    /// <summary>
    /// The prompt was blocked as a jailbreak attempt. This enum value is not supported in Gemini
    /// API.
    /// </summary>
    [JsonPropertyName("JAILBREAK")] JAILBREAK
  }
}
