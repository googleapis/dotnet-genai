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

using System.Text.Json.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Aggregation metric. This enum is not supported in Gemini API.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum AggregationMetric {
    /// <summary>
    /// Unspecified aggregation metric.
    /// </summary>
    [JsonPropertyName("AGGREGATION_METRIC_UNSPECIFIED")] AGGREGATION_METRIC_UNSPECIFIED,

    /// <summary>
    /// Average aggregation metric. Not supported for Pairwise metric.
    /// </summary>
    [JsonPropertyName("AVERAGE")] AVERAGE,

    /// <summary>
    /// Mode aggregation metric.
    /// </summary>
    [JsonPropertyName("MODE")] MODE,

    /// <summary>
    /// Standard deviation aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("STANDARD_DEVIATION")] STANDARD_DEVIATION,

    /// <summary>
    /// Variance aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("VARIANCE")] VARIANCE,

    /// <summary>
    /// Minimum aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("MINIMUM")] MINIMUM,

    /// <summary>
    /// Maximum aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("MAXIMUM")] MAXIMUM,

    /// <summary>
    /// Median aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("MEDIAN")] MEDIAN,

    /// <summary>
    /// 90th percentile aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("PERCENTILE_P90")] PERCENTILE_P90,

    /// <summary>
    /// 95th percentile aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("PERCENTILE_P95")] PERCENTILE_P95,

    /// <summary>
    /// 99th percentile aggregation metric. Not supported for pairwise metric.
    /// </summary>
    [JsonPropertyName("PERCENTILE_P99")] PERCENTILE_P99
  }
}
