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
  /// An entry point for displaying Google Search results. A `SearchEntryPoint` is populated when
  /// the grounding source for a model's response is Google Search. It provides information that you
  /// can use to display the search results in your application.
  /// </summary>

  public record SearchEntryPoint {
    /// <summary>
    /// Optional. An HTML snippet that can be embedded in a web page or an application's webview.
    /// This snippet displays a search result, including the title, URL, and a brief description of
    /// the search result.
    /// </summary>
    [JsonPropertyName("renderedContent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? RenderedContent { get; set; }

    /// <summary>
    /// Optional. A base64-encoded JSON object that contains a list of search queries and their
    /// corresponding search URLs. This information can be used to build a custom search UI.
    /// </summary>
    [JsonPropertyName("sdkBlob")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte[]
        ? SdkBlob {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a SearchEntryPoint object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SearchEntryPoint object, or null if deserialization
    /// fails.</returns>
    public static SearchEntryPoint
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<SearchEntryPoint>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
