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
  /// Enum that specifies the language of the text in the prompt.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<ImagePromptLanguage>))]
  public enum ImagePromptLanguage {
    /// <summary>
    /// Auto-detect the language.
    /// </summary>
    [JsonPropertyName("auto")] auto,

    /// <summary>
    /// English
    /// </summary>
    [JsonPropertyName("en")] en,

    /// <summary>
    /// Japanese
    /// </summary>
    [JsonPropertyName("ja")] ja,

    /// <summary>
    /// Korean
    /// </summary>
    [JsonPropertyName("ko")] ko,

    /// <summary>
    /// Hindi
    /// </summary>
    [JsonPropertyName("hi")] hi,

    /// <summary>
    /// Chinese
    /// </summary>
    [JsonPropertyName("zh")] zh,

    /// <summary>
    /// Portuguese
    /// </summary>
    [JsonPropertyName("pt")] pt,

    /// <summary>
    /// Spanish
    /// </summary>
    [JsonPropertyName("es")] es
  }
}
