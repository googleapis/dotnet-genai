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
  /// Configuration for upscaling an image.    For more information on this configuration, refer to
  /// the `Imagen API reference documentation
  /// <https://cloud.google.com/vertex-ai/generative-ai/docs/model-reference/imagen-api>`_.
  /// </summary>

  public record UpscaleImageConfig {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions ? HttpOptions { get; set; }

    /// <summary>
    /// Cloud Storage URI used to store the generated images.
    /// </summary>
    [JsonPropertyName("outputGcsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputGcsUri {
            get; set;
          }

    /// <summary>
    /// Whether to include a reason for filtered-out images in the       response.
    /// </summary>
    [JsonPropertyName("includeRaiReason")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? IncludeRaiReason {
            get; set;
          }

    /// <summary>
    /// The image format that the output should be saved as.
    /// </summary>
    [JsonPropertyName("outputMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputMimeType {
            get; set;
          }

    /// <summary>
    /// The level of compression. Only applicable if the       ``output_mime_type`` is
    /// ``image/jpeg``.
    /// </summary>
    [JsonPropertyName("outputCompressionQuality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? OutputCompressionQuality {
            get; set;
          }

    /// <summary>
    /// Whether to add an image enhancing step before upscaling.       It is expected to suppress
    /// the noise and JPEG compression artifacts       from the input image.
    /// </summary>
    [JsonPropertyName("enhanceInputImage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnhanceInputImage {
            get; set;
          }

    /// <summary>
    /// With a higher image preservation factor, the original image       pixels are more respected.
    /// With a lower image preservation factor, the       output image will have be more different
    /// from the input image, but       with finer details and less noise.
    /// </summary>
    [JsonPropertyName("imagePreservationFactor")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? ImagePreservationFactor {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a UpscaleImageConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized UpscaleImageConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static UpscaleImageConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<UpscaleImageConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
