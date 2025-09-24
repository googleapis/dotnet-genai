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
  /// The API spec that the external API implements.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<ApiSpec>))]
  public enum ApiSpec {
    /// <summary>
    /// Unspecified API spec. This value should not be used.
    /// </summary>
    [JsonPropertyName("API_SPEC_UNSPECIFIED")] API_SPEC_UNSPECIFIED,

    /// <summary>
    /// Simple search API spec.
    /// </summary>
    [JsonPropertyName("SIMPLE_SEARCH")] SIMPLE_SEARCH,

    /// <summary>
    /// Elastic search API spec.
    /// </summary>
    [JsonPropertyName("ELASTIC_SEARCH")] ELASTIC_SEARCH
  }
}
