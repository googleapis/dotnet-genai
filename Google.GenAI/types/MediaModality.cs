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
  /// Server content modalities.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<MediaModality>))]
  public enum MediaModality {
    /// <summary>
    /// The modality is unspecified.
    /// </summary>
    [JsonPropertyName("MODALITY_UNSPECIFIED")] MODALITY_UNSPECIFIED,

    /// <summary>
    /// Plain text.
    /// </summary>
    [JsonPropertyName("TEXT")] TEXT,

    /// <summary>
    /// Images.
    /// </summary>
    [JsonPropertyName("IMAGE")] IMAGE,

    /// <summary>
    /// Video.
    /// </summary>
    [JsonPropertyName("VIDEO")] VIDEO,

    /// <summary>
    /// Audio.
    /// </summary>
    [JsonPropertyName("AUDIO")] AUDIO,

    /// <summary>
    /// Document, e.g. PDF.
    /// </summary>
    [JsonPropertyName("DOCUMENT")] DOCUMENT
  }
}
