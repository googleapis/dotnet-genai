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
  /// Safety rating corresponding to the generated content.
  /// </summary>

  public record SafetyRating {
    /// <summary>
    /// Output only. Indicates whether the content was filtered out because of this rating.
    /// </summary>
    [JsonPropertyName("blocked")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool ? Blocked { get; set; }

    /// <summary>
    /// Output only. Harm category.
    /// </summary>
    [JsonPropertyName("category")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HarmCategory
        ? Category {
            get; set;
          }

    /// <summary>
    /// Output only. The overwritten threshold for the safety category of Gemini 2.0 image out. If
    /// minors are detected in the output image, the threshold of each safety category will be
    /// overwritten if user sets a lower threshold.
    /// </summary>
    [JsonPropertyName("overwrittenThreshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HarmBlockThreshold
        ? OverwrittenThreshold {
            get; set;
          }

    /// <summary>
    /// Output only. Harm probability levels in the content.
    /// </summary>
    [JsonPropertyName("probability")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HarmProbability
        ? Probability {
            get; set;
          }

    /// <summary>
    /// Output only. Harm probability score.
    /// </summary>
    [JsonPropertyName("probabilityScore")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? ProbabilityScore {
            get; set;
          }

    /// <summary>
    /// Output only. Harm severity levels in the content.
    /// </summary>
    [JsonPropertyName("severity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HarmSeverity
        ? Severity {
            get; set;
          }

    /// <summary>
    /// Output only. Harm severity score.
    /// </summary>
    [JsonPropertyName("severityScore")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? SeverityScore {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a SafetyRating object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized SafetyRating object, or null if deserialization fails.</returns>
    /// </summary>
    public static SafetyRating
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<SafetyRating>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
