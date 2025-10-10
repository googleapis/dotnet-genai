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
  /// Configuration for a Mask reference image.
  /// </summary>

  public record MaskReferenceConfig {
    /// <summary>
    /// Prompts the model to generate a mask instead of you needing to  provide one (unless
    /// MASK_MODE_USER_PROVIDED is used).
    /// </summary>
    [JsonPropertyName("maskMode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MaskReferenceMode ? MaskMode { get; set; }

    /// <summary>
    /// A list of up to 5 class ids to use for semantic segmentation.  Automatically creates an
    /// image mask based on specific objects.
    /// </summary>
    [JsonPropertyName("segmentationClasses")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<int>
        ? SegmentationClasses {
            get; set;
          }

    /// <summary>
    /// Dilation percentage of the mask provided.  Float between 0 and 1.
    /// </summary>
    [JsonPropertyName("maskDilation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? MaskDilation {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a MaskReferenceConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized MaskReferenceConfig object, or null if deserialization
    /// fails.</returns>
    public static MaskReferenceConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<MaskReferenceConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
