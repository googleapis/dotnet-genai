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
  /// The config for generating an images.
  /// </summary>

  public record GenerateImagesConfig {
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
    /// Description of what to discourage in the generated images.
    /// </summary>
    [JsonPropertyName("negativePrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? NegativePrompt {
            get; set;
          }

    /// <summary>
    /// Number of images to generate.
    /// </summary>
    [JsonPropertyName("numberOfImages")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? NumberOfImages {
            get; set;
          }

    /// <summary>
    /// Aspect ratio of the generated images. Supported values are       "1:1", "3:4", "4:3",
    /// "9:16", and "16:9".
    /// </summary>
    [JsonPropertyName("aspectRatio")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? AspectRatio {
            get; set;
          }

    /// <summary>
    /// Controls how much the model adheres to the text prompt. Large       values increase output
    /// and prompt alignment, but may compromise image       quality.
    /// </summary>
    [JsonPropertyName("guidanceScale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? GuidanceScale {
            get; set;
          }

    /// <summary>
    /// Random seed for image generation. This is not available when       ``add_watermark`` is set
    /// to true.
    /// </summary>
    [JsonPropertyName("seed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Seed {
            get; set;
          }

    /// <summary>
    /// Filter level for safety filtering.
    /// </summary>
    [JsonPropertyName("safetyFilterLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SafetyFilterLevel
        ? SafetyFilterLevel {
            get; set;
          }

    /// <summary>
    /// Allows generation of people by the model.
    /// </summary>
    [JsonPropertyName("personGeneration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PersonGeneration
        ? PersonGeneration {
            get; set;
          }

    /// <summary>
    /// Whether to report the safety scores of each generated image and       the positive prompt in
    /// the response.
    /// </summary>
    [JsonPropertyName("includeSafetyAttributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? IncludeSafetyAttributes {
            get; set;
          }

    /// <summary>
    /// Whether to include the Responsible AI filter reason if the image       is filtered out of
    /// the response.
    /// </summary>
    [JsonPropertyName("includeRaiReason")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? IncludeRaiReason {
            get; set;
          }

    /// <summary>
    /// Language of the text in the prompt.
    /// </summary>
    [JsonPropertyName("language")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImagePromptLanguage
        ? Language {
            get; set;
          }

    /// <summary>
    /// MIME type of the generated image.
    /// </summary>
    [JsonPropertyName("outputMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputMimeType {
            get; set;
          }

    /// <summary>
    /// Compression quality of the generated image (for ``image/jpeg``       only).
    /// </summary>
    [JsonPropertyName("outputCompressionQuality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? OutputCompressionQuality {
            get; set;
          }

    /// <summary>
    /// Whether to add a watermark to the generated images.
    /// </summary>
    [JsonPropertyName("addWatermark")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? AddWatermark {
            get; set;
          }

    /// <summary>
    /// The size of the largest dimension of the generated image.       Supported sizes are 1K and
    /// 2K (not supported for Imagen 3 models).
    /// </summary>
    [JsonPropertyName("imageSize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ImageSize {
            get; set;
          }

    /// <summary>
    /// Whether to use the prompt rewriting logic.
    /// </summary>
    [JsonPropertyName("enhancePrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnhancePrompt {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerateImagesConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerateImagesConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static GenerateImagesConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerateImagesConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
