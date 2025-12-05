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
  /// Tool to retrieve knowledge from Google Maps.
  /// </summary>

  public record GoogleMaps {
    /// <summary>
    /// The authentication config to access the API. Only API key is supported. This field is not
    /// supported in Gemini API.
    /// </summary>
    [JsonPropertyName("authConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthConfig ? AuthConfig { get; set; }

    /// <summary>
    /// Optional. Whether to return a widget context token in the GroundingMetadata of the response.
    /// Developers can use the widget context token to render a Google Maps widget with geospatial
    /// context related to the places that the model references in the response.
    /// </summary>
    [JsonPropertyName("enableWidget")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnableWidget {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GoogleMaps object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GoogleMaps object, or null if deserialization fails.</returns>
    public static GoogleMaps ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GoogleMaps>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
