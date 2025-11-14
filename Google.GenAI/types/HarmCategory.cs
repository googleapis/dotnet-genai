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
  /// The harm category to be blocked.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum HarmCategory {
    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_UNSPECIFIED")] HARM_CATEGORY_UNSPECIFIED,

    /// <summary>
    /// Abusive, threatening, or content intended to bully, torment, or ridicule.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_HARASSMENT")] HARM_CATEGORY_HARASSMENT,

    /// <summary>
    /// Content that promotes violence or incites hatred against individuals or groups based on
    /// certain attributes.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_HATE_SPEECH")] HARM_CATEGORY_HATE_SPEECH,

    /// <summary>
    /// Content that contains sexually explicit material.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_SEXUALLY_EXPLICIT")] HARM_CATEGORY_SEXUALLY_EXPLICIT,

    /// <summary>
    /// Content that promotes, facilitates, or enables dangerous activities.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_DANGEROUS_CONTENT")] HARM_CATEGORY_DANGEROUS_CONTENT,

    /// <summary>
    /// Deprecated: Election filter is not longer supported. The harm category is civic integrity.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_CIVIC_INTEGRITY")] HARM_CATEGORY_CIVIC_INTEGRITY,

    /// <summary>
    /// Images that contain hate speech. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_IMAGE_HATE")] HARM_CATEGORY_IMAGE_HATE,

    /// <summary>
    /// Images that contain dangerous content. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName(
        "HARM_CATEGORY_IMAGE_DANGEROUS_CONTENT")] HARM_CATEGORY_IMAGE_DANGEROUS_CONTENT,

    /// <summary>
    /// Images that contain harassment. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_IMAGE_HARASSMENT")] HARM_CATEGORY_IMAGE_HARASSMENT,

    /// <summary>
    /// Images that contain sexually explicit content. This enum value is not supported in Gemini
    /// API.
    /// </summary>
    [JsonPropertyName(
        "HARM_CATEGORY_IMAGE_SEXUALLY_EXPLICIT")] HARM_CATEGORY_IMAGE_SEXUALLY_EXPLICIT,

    /// <summary>
    /// Prompts designed to bypass safety filters. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_JAILBREAK")] HARM_CATEGORY_JAILBREAK
  }
}
