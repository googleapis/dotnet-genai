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

namespace Google.GenAI.Types
{
  /// <summary>
  /// Configuration for recontextualizing an image.
  /// </summary>

  public record RecontextImageConfig
  {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions? HttpOptions { get; set; }

    /// <summary>
    /// Number of images to generate.
    /// </summary>
    [JsonPropertyName("numberOfImages")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? NumberOfImages
    {
      get; set;
    }

    /// <summary>
    /// The number of sampling steps. A higher value has better image quality, while a lower value
    /// has better latency.
    /// </summary>
    [JsonPropertyName("baseSteps")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? BaseSteps
    {
      get; set;
    }

    /// <summary>
    /// Cloud Storage URI used to store the generated images.
    /// </summary>
    [JsonPropertyName("outputGcsUri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputGcsUri
    {
      get; set;
    }

    /// <summary>
    /// Random seed for image generation.
    /// </summary>
    [JsonPropertyName("seed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Seed
    {
      get; set;
    }

    /// <summary>
    /// Filter level for safety filtering.
    /// </summary>
    [JsonPropertyName("safetyFilterLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SafetyFilterLevel
        ? SafetyFilterLevel
    {
      get; set;
    }

    /// <summary>
    /// Whether allow to generate person images, and restrict to specific ages.
    /// </summary>
    [JsonPropertyName("personGeneration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PersonGeneration
        ? PersonGeneration
    {
      get; set;
    }

    /// <summary>
    /// Whether to add a SynthID watermark to the generated images.
    /// </summary>
    [JsonPropertyName("addWatermark")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? AddWatermark
    {
      get; set;
    }

    /// <summary>
    /// MIME type of the generated image.
    /// </summary>
    [JsonPropertyName("outputMimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? OutputMimeType
    {
      get; set;
    }

    /// <summary>
    /// Compression quality of the generated image (for ``image/jpeg`` only).
    /// </summary>
    [JsonPropertyName("outputCompressionQuality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? OutputCompressionQuality
    {
      get; set;
    }

    /// <summary>
    /// Whether to use the prompt rewriting logic.
    /// </summary>
    [JsonPropertyName("enhancePrompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? EnhancePrompt
    {
      get; set;
    }

    /// <summary>
    /// User specified labels to track billing usage.
    /// </summary>
    [JsonPropertyName("labels")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>
        ? Labels
    {
      get; set;
    }

    /// <summary>
    /// Deserializes a JSON string to a RecontextImageConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RecontextImageConfig object, or null if deserialization
    /// fails.</returns>
    public static RecontextImageConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<RecontextImageConfig>(jsonString, options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
