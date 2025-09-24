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
  /// Retrieve from data source powered by external API for grounding. The external API is not owned
  /// by Google, but need to follow the pre-defined API spec.
  /// </summary>

  public record ExternalApi {
    /// <summary>
    /// The authentication config to access the API. Deprecated. Please use auth_config instead.
    /// </summary>
    [JsonPropertyName("apiAuth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApiAuth ? ApiAuth { get; set; }

    /// <summary>
    /// The API spec that the external API implements.
    /// </summary>
    [JsonPropertyName("apiSpec")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApiSpec
        ? ApiSpec {
            get; set;
          }

    /// <summary>
    /// The authentication config to access the API.
    /// </summary>
    [JsonPropertyName("authConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthConfig
        ? AuthConfig {
            get; set;
          }

    /// <summary>
    /// Parameters for the elastic search API.
    /// </summary>
    [JsonPropertyName("elasticSearchParams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExternalApiElasticSearchParams
        ? ElasticSearchParams {
            get; set;
          }

    /// <summary>
    /// The endpoint of the external API. The system will call the API at this endpoint to retrieve
    /// the data for grounding. Example: https://acme.com:443/search
    /// </summary>
    [JsonPropertyName("endpoint")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Endpoint {
            get; set;
          }

    /// <summary>
    /// Parameters for the simple search API.
    /// </summary>
    [JsonPropertyName("simpleSearchParams")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExternalApiSimpleSearchParams
        ? SimpleSearchParams {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ExternalApi object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ExternalApi object, or null if deserialization fails.</returns>
    /// </summary>
    public static ExternalApi ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ExternalApi>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
