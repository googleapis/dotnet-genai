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
  /// Config for user oauth.
  /// </summary>

  public record AuthConfigOauthConfig {
    /// <summary>
    /// Access token for extension endpoint. Only used to propagate token from
    /// [[ExecuteExtensionRequest.runtime_auth_config]] at request time.
    /// </summary>
    [JsonPropertyName("accessToken")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? AccessToken { get; set; }

    /// <summary>
    /// The service account used to generate access tokens for executing the Extension. - If the
    /// service account is specified, the `iam.serviceAccounts.getAccessToken` permission should be
    /// granted to Vertex AI Extension Service Agent
    /// (https://cloud.google.com/vertex-ai/docs/general/access-control#service-agents) on the
    /// provided service account.
    /// </summary>
    [JsonPropertyName("serviceAccount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ServiceAccount {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AuthConfigOauthConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AuthConfigOauthConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static AuthConfigOauthConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AuthConfigOauthConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
