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
  /// Defines the types of Google Maps grounding that can be enabled and their configurations. This
  /// data type is not supported in Gemini API.
  /// </summary>

  public record GoogleMapsGroundingTypes {
    /// <summary>
    /// Optional. Enables grounding with Google Maps Places. This is the default grounding type when
    /// no `GroundingTypes` are specified.
    /// </summary>
    [JsonPropertyName("places")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleMapsPlaces ? Places { get; set; }

    /// <summary>
    /// Optional. Enables grounding with Google Maps Routing APIs (ComputeRoutes and
    /// SearchAlongRoute).
    /// </summary>
    [JsonPropertyName("routing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GoogleMapsRouting
        ? Routing {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GoogleMapsGroundingTypes object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GoogleMapsGroundingTypes object, or null if deserialization
    /// fails.</returns>
    public static GoogleMapsGroundingTypes
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<GoogleMapsGroundingTypes>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
