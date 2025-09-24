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
  /// An image.
  /// </summary>

  public record Image {
    /// <summary>
    /// The Cloud Storage URI of the image. ``Image`` can contain a value       for this field or
    /// the ``image_bytes`` field but not both.
    /// </summary>
    [JsonPropertyName("gcsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? GcsUri { get; set; }

    /// <summary>
    /// The image bytes data. ``Image`` can contain a value for this field       or the ``gcs_uri``
    /// field but not both.
    /// </summary>
    [JsonPropertyName("imageBytes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public byte[]
        ? ImageBytes {
            get; set;
          }

    /// <summary>
    /// The MIME type of the image.
    /// </summary>
    [JsonPropertyName("mimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? MimeType {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Image object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Image object, or null if deserialization fails.</returns>
    /// </summary>
    public static Image ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<Image>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
