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
  /// Config for HTTP Basic Authentication.
  /// </summary>

  public record AuthConfigHttpBasicAuthConfig {
    /// <summary>
    /// The name of the SecretManager secret version resource storing the base64 encoded
    /// credentials. Format: `projects/{project}/secrets/{secrete}/versions/{version}` - If
    /// specified, the `secretmanager.versions.access` permission should be granted to Vertex AI
    /// Extension Service Agent
    /// (https://cloud.google.com/vertex-ai/docs/general/access-control#service-agents) on the
    /// specified resource.
    /// </summary>
    [JsonPropertyName("credentialSecret")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? CredentialSecret { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a AuthConfigHttpBasicAuthConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AuthConfigHttpBasicAuthConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static AuthConfigHttpBasicAuthConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AuthConfigHttpBasicAuthConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
