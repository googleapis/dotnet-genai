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
  /// Response for the list files method.
  /// </summary>

  public record ListFilesResponse {
    /// <summary>
    /// Used to retain the full HTTP response.
    /// </summary>
    [JsonPropertyName("sdkHttpResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpResponse ? SdkHttpResponse { get; set; }

    /// <summary>
    /// A token that can be sent as a `page_token` into a subsequent `ListFiles` call. This field is
    /// not supported in Vertex AI.
    /// </summary>
    [JsonPropertyName("nextPageToken")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? NextPageToken {
            get; set;
          }

    /// <summary>
    /// The list of `File`s. This field is not supported in Vertex AI.
    /// </summary>
    [JsonPropertyName("files")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Google.GenAI.Types.File>
        ? Files {
            get; set;
          }

    /// <summary>
    /// The files. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ClaudeFile>
        ? Data {
            get; set;
          }

    /// <summary>
    /// Opaque cursor for the next page. Unset on the last page, and always unset when `ids` was
    /// supplied, since batch fetch is single-page. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("nextPage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? NextPage {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ListFilesResponse object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ListFilesResponse object, or null if deserialization
    /// fails.</returns>
    public static ListFilesResponse
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<ListFilesResponse>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
