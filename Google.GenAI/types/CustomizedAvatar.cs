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
  /// Configures the customized avatar to be used in the session.
  /// </summary>

  public record CustomizedAvatar {
    /// <summary>
    /// The mime type of the reference image, e.g., "image/jpeg".
    /// </summary>
    [JsonPropertyName("imageMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? ImageMimeType { get; set; }

    /// <summary>
    /// The data of the reference image. The dimensions of the reference image should be 9:16
    /// (portrait) with a minimum resolution of 704x1280.
    /// </summary>
    [JsonPropertyName("imageData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte[]
        ? ImageData {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a CustomizedAvatar object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized CustomizedAvatar object, or null if deserialization
    /// fails.</returns>
    public static CustomizedAvatar
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<CustomizedAvatar>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
