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
  /// Options for feature selection preference.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<FeatureSelectionPreference>))]
  public enum FeatureSelectionPreference {
    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName(
        "FEATURE_SELECTION_PREFERENCE_UNSPECIFIED")] FEATURE_SELECTION_PREFERENCE_UNSPECIFIED,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("PRIORITIZE_QUALITY")] PRIORITIZE_QUALITY,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("BALANCED")] BALANCED,

    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("PRIORITIZE_COST")] PRIORITIZE_COST
  }
}
