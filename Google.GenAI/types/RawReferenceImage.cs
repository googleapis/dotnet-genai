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
  /// A raw reference image.   A raw reference image represents the base image to edit, provided by
  /// the user.  It can optionally be provided in addition to a mask reference image or  a style
  /// reference image.
  /// </summary>

  public record RawReferenceImage : IReferenceImageInternal {
    /// <summary>
    /// The reference image for the editing operation.
    /// </summary>
    [JsonPropertyName("referenceImage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Image ? ReferenceImage { get; set; }

    /// <summary>
    /// The id of the reference image.
    /// </summary>
    [JsonPropertyName("referenceId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ReferenceId {
            get; set;
          }

    /// <summary>
    /// The type of the reference image. Only set by the SDK.
    /// </summary>
    [JsonPropertyName("referenceType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ReferenceType {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a RawReferenceImage object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RawReferenceImage object, or null if deserialization
    /// fails.</returns>
    public static RawReferenceImage
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<RawReferenceImage>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }

    ReferenceImageAPI IReferenceImageInternal.ToReferenceImageAPI() {
      return new ReferenceImageAPI { ReferenceImage = this.ReferenceImage,
                                     ReferenceId = this.ReferenceId,
                                     ReferenceType = "REFERENCE_TYPE_RAW" };
    }
  }
}
