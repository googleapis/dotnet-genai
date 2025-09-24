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
  /// Output only. Harm probability levels in the content.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<HarmProbability>))]
  public enum HarmProbability {
    /// <summary>
    /// Harm probability unspecified.
    /// </summary>
    [JsonPropertyName("HARM_PROBABILITY_UNSPECIFIED")] HARM_PROBABILITY_UNSPECIFIED,

    /// <summary>
    /// Negligible level of harm.
    /// </summary>
    [JsonPropertyName("NEGLIGIBLE")] NEGLIGIBLE,

    /// <summary>
    /// Low level of harm.
    /// </summary>
    [JsonPropertyName("LOW")] LOW,

    /// <summary>
    /// Medium level of harm.
    /// </summary>
    [JsonPropertyName("MEDIUM")] MEDIUM,

    /// <summary>
    /// High level of harm.
    /// </summary>
    [JsonPropertyName("HIGH")] HIGH
  }
}
