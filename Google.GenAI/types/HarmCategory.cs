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
  /// Harm category.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum HarmCategory
  {
    /// <summary>
    /// The harm category is unspecified.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_UNSPECIFIED")] HARM_CATEGORY_UNSPECIFIED,

    /// <summary>
    /// The harm category is harassment.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_HARASSMENT")] HARM_CATEGORY_HARASSMENT,

    /// <summary>
    /// The harm category is hate speech.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_HATE_SPEECH")] HARM_CATEGORY_HATE_SPEECH,

    /// <summary>
    /// The harm category is sexually explicit content.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_SEXUALLY_EXPLICIT")] HARM_CATEGORY_SEXUALLY_EXPLICIT,

    /// <summary>
    /// The harm category is dangerous content.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_DANGEROUS_CONTENT")] HARM_CATEGORY_DANGEROUS_CONTENT,

    /// <summary>
    /// Deprecated: Election filter is not longer supported. The harm category is civic integrity.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_CIVIC_INTEGRITY")] HARM_CATEGORY_CIVIC_INTEGRITY,

    /// <summary>
    /// The harm category is image hate. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_IMAGE_HATE")] HARM_CATEGORY_IMAGE_HATE,

    /// <summary>
    /// The harm category is image dangerous content. This enum value is not supported in Gemini
    /// API.
    /// </summary>
    [JsonPropertyName(
        "HARM_CATEGORY_IMAGE_DANGEROUS_CONTENT")]
    HARM_CATEGORY_IMAGE_DANGEROUS_CONTENT,

    /// <summary>
    /// The harm category is image harassment. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_IMAGE_HARASSMENT")] HARM_CATEGORY_IMAGE_HARASSMENT,

    /// <summary>
    /// The harm category is image sexually explicit content. This enum value is not supported in
    /// Gemini API.
    /// </summary>
    [JsonPropertyName(
        "HARM_CATEGORY_IMAGE_SEXUALLY_EXPLICIT")]
    HARM_CATEGORY_IMAGE_SEXUALLY_EXPLICIT,

    /// <summary>
    /// The harm category is for jailbreak prompts. This enum value is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("HARM_CATEGORY_JAILBREAK")] HARM_CATEGORY_JAILBREAK
  }
}
