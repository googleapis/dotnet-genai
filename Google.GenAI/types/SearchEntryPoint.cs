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
  /// Google search entry point.
  /// </summary>

  public record SearchEntryPoint {
    /// <summary>
    /// Optional. Web content snippet that can be embedded in a web page or an app webview.
    /// </summary>
    [JsonPropertyName("renderedContent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? RenderedContent { get; set; }

    /// <summary>
    /// Optional. Base64 encoded JSON representing array of tuple.
    /// </summary>
    [JsonPropertyName("sdkBlob")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte[]
        ? SdkBlob {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a SearchEntryPoint object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SearchEntryPoint object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static SearchEntryPoint
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<SearchEntryPoint>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
