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
  /// Config for Google Service Account Authentication.
  /// </summary>

  public record AuthConfigGoogleServiceAccountConfig {
    /// <summary>
    /// Optional. The service account that the extension execution service runs as. - If the service
    /// account is specified, the `iam.serviceAccounts.getAccessToken` permission should be granted
    /// to Vertex AI Extension Service Agent
    /// (https://cloud.google.com/vertex-ai/docs/general/access-control#service-agents) on the
    /// specified service account. - If not specified, the Vertex AI Extension Service Agent will be
    /// used to execute the Extension.
    /// </summary>
    [JsonPropertyName("serviceAccount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? ServiceAccount { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a AuthConfigGoogleServiceAccountConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AuthConfigGoogleServiceAccountConfig object, or null if
    /// deserialization fails.</returns>
    /// </summary>
    public static AuthConfigGoogleServiceAccountConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AuthConfigGoogleServiceAccountConfig>(jsonString,
                                                                                options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
