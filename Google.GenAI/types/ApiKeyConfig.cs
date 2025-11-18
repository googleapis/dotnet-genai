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

namespace Google.GenAI.Types
{
  /// <summary>
  /// Config for authentication with API key. This data type is not supported in Gemini API.
  /// </summary>

  public record ApiKeyConfig
  {
    /// <summary>
    /// Optional. The name of the SecretManager secret version resource storing the API key. Format:
    /// `projects/{project}/secrets/{secrete}/versions/{version}` - If both `api_key_secret` and
    /// `api_key_string` are specified, this field takes precedence over `api_key_string`. - If
    /// specified, the `secretmanager.versions.access` permission should be granted to Vertex AI
    /// Extension Service Agent
    /// (https://cloud.google.com/vertex-ai/docs/general/access-control#service-agents) on the
    /// specified resource.
    /// </summary>
    [JsonPropertyName("apiKeySecret")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKeySecret { get; set; }

    /// <summary>
    /// Optional. The API key to be used in the request directly.
    /// </summary>
    [JsonPropertyName("apiKeyString")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ApiKeyString
    {
      get; set;
    }

    /// <summary>
    /// Optional. The location of the API key.
    /// </summary>
    [JsonPropertyName("httpElementLocation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpElementLocation
        ? HttpElementLocation
    {
      get; set;
    }

    /// <summary>
    /// Optional. The parameter name of the API key. E.g. If the API request is
    /// "https://example.com/act?api_key=", "api_key" would be the parameter name.
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Name
    {
      get; set;
    }

    /// <summary>
    /// Deserializes a JSON string to a ApiKeyConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ApiKeyConfig object, or null if deserialization fails.</returns>
    public static ApiKeyConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<ApiKeyConfig>(jsonString, options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
