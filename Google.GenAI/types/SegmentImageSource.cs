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
  /// A set of source input(s) for image segmentation.
  /// </summary>

  public record SegmentImageSource
  {
    /// <summary>
    /// A text prompt for guiding the model during image segmentation. Required for prompt mode and
    /// semantic mode, disallowed for other modes.
    /// </summary>
    [JsonPropertyName("prompt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Prompt { get; set; }

    /// <summary>
    /// The image to be segmented.
    /// </summary>
    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Image
        ? Image
    {
      get; set;
    }

    /// <summary>
    /// The brush scribble to guide segmentation. Required for the interactive mode, disallowed for
    /// other modes.
    /// </summary>
    [JsonPropertyName("scribbleImage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ScribbleImage
        ? ScribbleImage
    {
      get; set;
    }

    /// <summary>
    /// Deserializes a JSON string to a SegmentImageSource object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SegmentImageSource object, or null if deserialization
    /// fails.</returns>
    public static SegmentImageSource
        ? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<SegmentImageSource>(jsonString, options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
