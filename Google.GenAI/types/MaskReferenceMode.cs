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
  /// Enum representing the mask mode of a mask reference image.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<MaskReferenceMode>))]
  public enum MaskReferenceMode {
    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("MASK_MODE_DEFAULT")] MASK_MODE_DEFAULT,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("MASK_MODE_USER_PROVIDED")] MASK_MODE_USER_PROVIDED,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("MASK_MODE_BACKGROUND")] MASK_MODE_BACKGROUND,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("MASK_MODE_FOREGROUND")] MASK_MODE_FOREGROUND,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("MASK_MODE_SEMANTIC")] MASK_MODE_SEMANTIC
  }
}
