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
  /// Config for the dynamic retrieval config mode.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<DynamicRetrievalConfigMode>))]
  public enum DynamicRetrievalConfigMode {
    /// <summary>
    /// Always trigger retrieval.
    /// </summary>
    [JsonPropertyName("MODE_UNSPECIFIED")] MODE_UNSPECIFIED,

    /// <summary>
    /// Run retrieval only when system decides it is necessary.
    /// </summary>
    [JsonPropertyName("MODE_DYNAMIC")] MODE_DYNAMIC
  }
}
