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
  /// The aggregation result for a single metric. This data type is not supported in Gemini API.
  /// </summary>

  public record AggregationResult {
    /// <summary>
    /// Aggregation metric.
    /// </summary>
    [JsonPropertyName("aggregationMetric")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AggregationMetric ? AggregationMetric { get; set; }

    /// <summary>
    /// Results for bleu metric.
    /// </summary>
    [JsonPropertyName("bleuMetricValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BleuMetricValue
        ? BleuMetricValue {
            get; set;
          }

    /// <summary>
    /// Result for code execution metric.
    /// </summary>
    [JsonPropertyName("customCodeExecutionResult")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CustomCodeExecutionResult
        ? CustomCodeExecutionResult {
            get; set;
          }

    /// <summary>
    /// Results for exact match metric.
    /// </summary>
    [JsonPropertyName("exactMatchMetricValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ExactMatchMetricValue
        ? ExactMatchMetricValue {
            get; set;
          }

    /// <summary>
    /// Result for pairwise metric.
    /// </summary>
    [JsonPropertyName("pairwiseMetricResult")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PairwiseMetricResult
        ? PairwiseMetricResult {
            get; set;
          }

    /// <summary>
    /// Result for pointwise metric.
    /// </summary>
    [JsonPropertyName("pointwiseMetricResult")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PointwiseMetricResult
        ? PointwiseMetricResult {
            get; set;
          }

    /// <summary>
    /// Results for rouge metric.
    /// </summary>
    [JsonPropertyName("rougeMetricValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RougeMetricValue
        ? RougeMetricValue {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a AggregationResult object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized AggregationResult object, or null if deserialization
    /// fails.</returns>
    public static AggregationResult
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<AggregationResult>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
