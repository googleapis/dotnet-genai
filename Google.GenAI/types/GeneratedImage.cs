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
  /// An output image.
  /// </summary>

  public record GeneratedImage {
    /// <summary>
    /// The output image data.
    /// </summary>
    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Image ? Image { get; set; }

    /// <summary>
    /// Responsible AI filter reason if the image is filtered out of the       response.
    /// </summary>
    [JsonPropertyName("raiFilteredReason")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? RaiFilteredReason {
            get; set;
          }

    /// <summary>
    /// Safety attributes of the image. Lists of RAI categories and their       scores of each
    /// content.
    /// </summary>
    [JsonPropertyName("safetyAttributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SafetyAttributes
        ? SafetyAttributes {
            get; set;
          }

    /// <summary>
    /// The rewritten prompt used for the image generation if the prompt       enhancer is enabled.
    /// </summary>
    [JsonPropertyName("enhancedPrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? EnhancedPrompt {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GeneratedImage object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GeneratedImage object, or null if deserialization fails.</returns>
    /// </summary>
    public static GeneratedImage
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GeneratedImage>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
