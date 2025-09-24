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
  /// The media resolution to use.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<MediaResolution>))]
  public enum MediaResolution {
    /// <summary>
    /// Media resolution has not been set
    /// </summary>
    [JsonPropertyName("MEDIA_RESOLUTION_UNSPECIFIED")] MEDIA_RESOLUTION_UNSPECIFIED,

    /// <summary>
    /// Media resolution set to low (64 tokens).
    /// </summary>
    [JsonPropertyName("MEDIA_RESOLUTION_LOW")] MEDIA_RESOLUTION_LOW,

    /// <summary>
    /// Media resolution set to medium (256 tokens).
    /// </summary>
    [JsonPropertyName("MEDIA_RESOLUTION_MEDIUM")] MEDIA_RESOLUTION_MEDIUM,

    /// <summary>
    /// Media resolution set to high (zoomed reframing with 256 tokens).
    /// </summary>
    [JsonPropertyName("MEDIA_RESOLUTION_HIGH")] MEDIA_RESOLUTION_HIGH
  }
}
