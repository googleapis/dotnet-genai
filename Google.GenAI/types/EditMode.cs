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
  /// Enum representing the editing mode.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<EditMode>))]
  public enum EditMode {
    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_DEFAULT")] EDIT_MODE_DEFAULT,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_INPAINT_REMOVAL")] EDIT_MODE_INPAINT_REMOVAL,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_INPAINT_INSERTION")] EDIT_MODE_INPAINT_INSERTION,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_OUTPAINT")] EDIT_MODE_OUTPAINT,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_CONTROLLED_EDITING")] EDIT_MODE_CONTROLLED_EDITING,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_STYLE")] EDIT_MODE_STYLE,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_BGSWAP")] EDIT_MODE_BGSWAP,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("EDIT_MODE_PRODUCT_IMAGE")] EDIT_MODE_PRODUCT_IMAGE
  }
}
