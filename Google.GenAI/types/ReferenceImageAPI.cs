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
  /// Private class that represents a Reference image that is sent to API.
  /// </summary>

  internal record ReferenceImageAPI {
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
    [JsonPropertyName("maskImageConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MaskReferenceConfig
        ? MaskImageConfig {
            get; set;
          }

    /// <summary>
    /// Configuration for the control reference image.
    /// </summary>
    [JsonPropertyName("controlImageConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ControlReferenceConfig
        ? ControlImageConfig {
            get; set;
          }

    /// <summary>
    /// Configuration for the style reference image.
    /// </summary>
    [JsonPropertyName("styleImageConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public StyleReferenceConfig
        ? StyleImageConfig {
            get; set;
          }

    /// <summary>
    /// Configuration for the subject reference image.
    /// </summary>
    [JsonPropertyName("subjectImageConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SubjectReferenceConfig
        ? SubjectImageConfig {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ReferenceImageAPI object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ReferenceImageAPI object, or null if deserialization
    /// fails.</returns>
    public static ReferenceImageAPI
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ReferenceImageAPI>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
