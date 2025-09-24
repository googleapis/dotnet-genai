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
  /// An object that represents a latitude/longitude pair.    This is expressed as a pair of doubles
  /// to represent degrees latitude and   degrees longitude. Unless specified otherwise, this object
  /// must conform to the   <a
  /// href="https://en.wikipedia.org/wiki/World_Geodetic_System#1984_version">   WGS84 standard</a>.
  /// Values must be within normalized ranges.
  /// </summary>

  public record LatLng {
    /// <summary>
    /// The latitude in degrees. It must be in the range [-90.0, +90.0].
    /// </summary>
    [JsonPropertyName("latitude")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double ? Latitude { get; set; }

    /// <summary>
    /// The longitude in degrees. It must be in the range [-180.0, +180.0]
    /// </summary>
    [JsonPropertyName("longitude")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? Longitude {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LatLng object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LatLng object, or null if deserialization fails.</returns>
    /// </summary>
    public static LatLng ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LatLng>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
