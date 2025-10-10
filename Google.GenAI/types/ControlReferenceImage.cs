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
  /// A control reference image.   The image of the control reference image is either a control
  /// image provided  by the user, or a regular image which the backend will use to generate a
  /// control image of. In the case of the latter, the  enable_control_image_computation field in
  /// the config should be set to True.   A control image is an image that represents a sketch image
  /// of areas for the  model to fill in based on the prompt.
  /// </summary>

  public record ControlReferenceImage : IReferenceImageInternal {
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
    /// Configuration for the control reference image.
    /// </summary>
    [JsonPropertyName("config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ControlReferenceConfig
        ? Config {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ControlReferenceImage object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ControlReferenceImage object, or null if deserialization
    /// fails.</returns>
    public static ControlReferenceImage
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ControlReferenceImage>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }

    ReferenceImageAPI IReferenceImageInternal.ToReferenceImageAPI() {
      return new ReferenceImageAPI { ReferenceImage = this.ReferenceImage,
                                     ReferenceId = this.ReferenceId,
                                     ControlImageConfig = this.Config,
                                     ReferenceType = "REFERENCE_TYPE_CONTROL" };
    }
  }
}
