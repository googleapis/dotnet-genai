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
  /// The image generation configuration to be used in GenerateContentConfig.
  /// </summary>

  public record ImageConfig {
    /// <summary>
    /// Aspect ratio of the generated images. Supported values are "1:1", "2:3", "3:2", "3:4",
    /// "4:3", "9:16", "16:9", and "21:9".
    /// </summary>
    [JsonPropertyName("aspectRatio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? AspectRatio { get; set; }

    /// <summary>
    /// Optional. Specifies the size of generated images. Supported values are `1K`, `2K`, `4K`. If
    /// not specified, the model will use default value `1K`.
    /// </summary>
    [JsonPropertyName("imageSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ImageSize {
            get; set;
          }

    /// <summary>
    /// MIME type of the generated image. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("outputMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputMimeType {
            get; set;
          }

    /// <summary>
    /// Compression quality of the generated image (for ``image/jpeg`` only). This field is not
    /// supported in Gemini API.
    /// </summary>
    [JsonPropertyName("outputCompressionQuality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? OutputCompressionQuality {
            get; set;
          }

    /// <summary>
    /// Optional. The image output format for generated images. This field is not supported in
    /// Gemini API.
    /// </summary>
    [JsonPropertyName("imageOutputOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageConfigImageOutputOptions
        ? ImageOutputOptions {
            get; set;
          }

    /// <summary>
    /// Optional. Controls whether the model can generate people. This field is not supported in
    /// Gemini API.
    /// </summary>
    [JsonPropertyName("personGeneration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PersonGeneration
        ? PersonGeneration {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ImageConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ImageConfig object, or null if deserialization fails.</returns>
    public static ImageConfig ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ImageConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
