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
  /// A `Web` chunk is a piece of evidence that comes from a web page. It contains the URI of the
  /// web page, the title of the page, and the domain of the page. This is used to provide the user
  /// with a link to the source of the information.
  /// </summary>

  public record GroundingChunkWeb {
    /// <summary>
    /// The domain of the web page that contains the evidence. This can be used to filter out
    /// low-quality sources. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("domain")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? Domain { get; set; }

    /// <summary>
    /// The title of the web page that contains the evidence.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Title {
            get; set;
          }

    /// <summary>
    /// The URI of the web page that contains the evidence.
    /// </summary>
    [JsonPropertyName("uri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Uri {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingChunkWeb object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingChunkWeb object, or null if deserialization
    /// fails.</returns>
    public static GroundingChunkWeb
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingChunkWeb>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
