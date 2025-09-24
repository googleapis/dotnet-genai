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
  /// Type of auth scheme.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<AuthType>))]
  public enum AuthType {
    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("AUTH_TYPE_UNSPECIFIED")] AUTH_TYPE_UNSPECIFIED,

    /// <summary>
    /// No Auth.
    /// </summary>
    [JsonPropertyName("NO_AUTH")] NO_AUTH,

    /// <summary>
    /// API Key Auth.
    /// </summary>
    [JsonPropertyName("API_KEY_AUTH")] API_KEY_AUTH,

    /// <summary>
    /// HTTP Basic Auth.
    /// </summary>
    [JsonPropertyName("HTTP_BASIC_AUTH")] HTTP_BASIC_AUTH,

    /// <summary>
    /// Google Service Account Auth.
    /// </summary>
    [JsonPropertyName("GOOGLE_SERVICE_ACCOUNT_AUTH")] GOOGLE_SERVICE_ACCOUNT_AUTH,

    /// <summary>
    /// OAuth auth.
    /// </summary>
    [JsonPropertyName("OAUTH")] OAUTH,

    /// <summary>
    /// OpenID Connect (OIDC) Auth.
    /// </summary>
    [JsonPropertyName("OIDC_AUTH")] OIDC_AUTH
  }
}
