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
  /// Output only. Harm severity levels in the content.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<HarmSeverity>))]
  public enum HarmSeverity {
    /// <summary>
    /// Harm severity unspecified.
    /// </summary>
    [JsonPropertyName("HARM_SEVERITY_UNSPECIFIED")] HARM_SEVERITY_UNSPECIFIED,

    /// <summary>
    /// Negligible level of harm severity.
    /// </summary>
    [JsonPropertyName("HARM_SEVERITY_NEGLIGIBLE")] HARM_SEVERITY_NEGLIGIBLE,

    /// <summary>
    /// Low level of harm severity.
    /// </summary>
    [JsonPropertyName("HARM_SEVERITY_LOW")] HARM_SEVERITY_LOW,

    /// <summary>
    /// Medium level of harm severity.
    /// </summary>
    [JsonPropertyName("HARM_SEVERITY_MEDIUM")] HARM_SEVERITY_MEDIUM,

    /// <summary>
    /// High level of harm severity.
    /// </summary>
    [JsonPropertyName("HARM_SEVERITY_HIGH")] HARM_SEVERITY_HIGH
  }
}
