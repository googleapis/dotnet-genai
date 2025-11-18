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

namespace Google.GenAI.Types
{
  /// <summary>
  /// The location of the API key. This enum is not supported in Gemini API.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum HttpElementLocation
  {
    /// <summary>
    ///
    /// </summary>
    [JsonPropertyName("HTTP_IN_UNSPECIFIED")] HTTP_IN_UNSPECIFIED,

    /// <summary>
    /// Element is in the HTTP request query.
    /// </summary>
    [JsonPropertyName("HTTP_IN_QUERY")] HTTP_IN_QUERY,

    /// <summary>
    /// Element is in the HTTP request header.
    /// </summary>
    [JsonPropertyName("HTTP_IN_HEADER")] HTTP_IN_HEADER,

    /// <summary>
    /// Element is in the HTTP request path.
    /// </summary>
    [JsonPropertyName("HTTP_IN_PATH")] HTTP_IN_PATH,

    /// <summary>
    /// Element is in the HTTP request body.
    /// </summary>
    [JsonPropertyName("HTTP_IN_BODY")] HTTP_IN_BODY,

    /// <summary>
    /// Element is in the HTTP request cookie.
    /// </summary>
    [JsonPropertyName("HTTP_IN_COOKIE")] HTTP_IN_COOKIE
  }
}
