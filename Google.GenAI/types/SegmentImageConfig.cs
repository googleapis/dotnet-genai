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
  /// Configuration for segmenting an image.
  /// </summary>

  public record SegmentImageConfig
  {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions? HttpOptions { get; set; }

    /// <summary>
    /// The segmentation mode to use.
    /// </summary>
    [JsonPropertyName("mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SegmentMode
        ? Mode
    {
      get; set;
    }

    /// <summary>
    /// The maximum number of predictions to return up to, by top confidence score.
    /// </summary>
    [JsonPropertyName("maxPredictions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? MaxPredictions
    {
      get; set;
    }

    /// <summary>
    /// The confidence score threshold for the detections as a decimal value. Only predictions with
    /// a confidence score higher than this threshold will be returned.
    /// </summary>
    [JsonPropertyName("confidenceThreshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? ConfidenceThreshold
    {
      get; set;
    }

    /// <summary>
    /// A decimal value representing how much dilation to apply to the masks. 0 for no dilation. 1.0
    /// means the masked area covers the whole image.
    /// </summary>
    [JsonPropertyName("maskDilation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? MaskDilation
    {
      get; set;
    }

    /// <summary>
    /// The binary color threshold to apply to the masks. The threshold can be set to a decimal
    /// value between 0 and 255 non-inclusive. Set to -1 for no binary color thresholding.
    /// </summary>
    [JsonPropertyName("binaryColorThreshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? BinaryColorThreshold
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
    /// Deserializes a JSON string to a SegmentImageConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SegmentImageConfig object, or null if deserialization
    /// fails.</returns>
    public static SegmentImageConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<SegmentImageConfig>(jsonString, options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
