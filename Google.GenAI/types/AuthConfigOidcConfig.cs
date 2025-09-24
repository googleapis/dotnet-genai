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

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Config for user OIDC auth.
  /// </summary>

  public record AuthConfigOidcConfig {
    /// <summary>
    /// OpenID Connect formatted ID token for extension endpoint. Only used to propagate token from
    /// [[ExecuteExtensionRequest.runtime_auth_config]] at request time.
    /// </summary>
    [JsonPropertyName("idToken")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? IdToken { get; set; }

    /// <summary>
    /// The service account used to generate an OpenID Connect (OIDC)-compatible JWT token signed by
    /// the Google OIDC Provider (accounts.google.com) for extension endpoint
    /// (https://cloud.google.com/iam/docs/create-short-lived-credentials-direct#sa-credentials-oidc).
    /// - The audience for the token will be set to the URL in the server url defined in the OpenApi
    /// spec. - If the service account is provided, the service account should grant
    /// `iam.serviceAccounts.getOpenIdToken` permission to Vertex AI Extension Service Agent
    /// (https://cloud.google.com/vertex-ai/docs/general/access-control#service-agents).
    /// </summary>
    [JsonPropertyName("serviceAccount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ServiceAccount {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AuthConfigOidcConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AuthConfigOidcConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static AuthConfigOidcConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AuthConfigOidcConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
