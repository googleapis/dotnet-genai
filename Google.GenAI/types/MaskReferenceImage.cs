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
  /// A mask reference image.   This encapsulates either a mask image provided by the user and
  /// configs for  the user provided mask, or only config parameters for the model to generate  a
  /// mask.   A mask image is an image whose non-zero values indicate where to edit the base  image.
  /// If the user provides a mask image, the mask must be in the same  dimensions as the raw image.
  /// </summary>

  public record MaskReferenceImage : IReferenceImageInternal {
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
    /// Configuration for the mask reference image.
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MaskReferenceConfig
        ? Config {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a MaskReferenceImage object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized MaskReferenceImage object, or null if deserialization
    /// fails.</returns>
    public static MaskReferenceImage
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<MaskReferenceImage>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }

    ReferenceImageAPI IReferenceImageInternal.ToReferenceImageAPI() {
      return new ReferenceImageAPI { ReferenceImage = this.ReferenceImage,
                                     ReferenceId = this.ReferenceId, MaskImageConfig = this.Config,
                                     ReferenceType = "REFERENCE_TYPE_MASK" };
    }
  }
}
