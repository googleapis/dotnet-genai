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
  /// The authentication config to access the API.
  /// </summary>

  public record AuthConfig {
    /// <summary>
    /// The authentication config to access the API. Only API key is supported. This field is not
    /// supported in Gemini API.
    /// </summary>
    [JsonPropertyName("apiKey")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? ApiKey { get; set; }

    /// <summary>
    /// Config for API key auth.
    /// </summary>
    [JsonPropertyName("apiKeyConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApiKeyConfig
        ? ApiKeyConfig {
            get; set;
          }

    /// <summary>
    /// Type of auth scheme.
    /// </summary>
    [JsonPropertyName("authType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthType
        ? AuthType {
            get; set;
          }

    /// <summary>
    /// Config for Google Service Account auth.
    /// </summary>
    [JsonPropertyName("googleServiceAccountConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthConfigGoogleServiceAccountConfig
        ? GoogleServiceAccountConfig {
            get; set;
          }

    /// <summary>
    /// Config for HTTP Basic auth.
    /// </summary>
    [JsonPropertyName("httpBasicAuthConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthConfigHttpBasicAuthConfig
        ? HttpBasicAuthConfig {
            get; set;
          }

    /// <summary>
    /// Config for user oauth.
    /// </summary>
    [JsonPropertyName("oauthConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthConfigOauthConfig
        ? OauthConfig {
            get; set;
          }

    /// <summary>
    /// Config for user OIDC auth.
    /// </summary>
    [JsonPropertyName("oidcConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthConfigOidcConfig
        ? OidcConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AuthConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AuthConfig object, or null if deserialization fails.</returns>
    public static AuthConfig ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AuthConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
