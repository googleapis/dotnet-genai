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
using System.Collections.Generic;
using System.Text.Json;

namespace Google.GenAI.Types {
  /// <summary>
  /// Aggregation metric. This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(AggregationMetricConverter))]
  public readonly record struct AggregationMetric : IEquatable<AggregationMetric> {
    public string Value { get; }

    private AggregationMetric(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified aggregation metric.
    /// </summary>
    public static AggregationMetric AggregationMetricUnspecified {
      get;
    } = new("AGGREGATION_METRIC_UNSPECIFIED");

    /// <summary>
    /// Average aggregation metric. Not supported for Pairwise metric.
    /// </summary>
    public static AggregationMetric Average { get; } = new("AVERAGE");

    /// <summary>
    /// Mode aggregation metric.
    /// </summary>
    public static AggregationMetric Mode { get; } = new("MODE");

    /// <summary>
    /// Standard deviation aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric StandardDeviation { get; } = new("STANDARD_DEVIATION");

    /// <summary>
    /// Variance aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric Variance { get; } = new("VARIANCE");

    /// <summary>
    /// Minimum aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric Minimum { get; } = new("MINIMUM");

    /// <summary>
    /// Maximum aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric Maximum { get; } = new("MAXIMUM");

    /// <summary>
    /// Median aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric Median { get; } = new("MEDIAN");

    /// <summary>
    /// 90th percentile aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric PercentileP90 { get; } = new("PERCENTILE_P90");

    /// <summary>
    /// 95th percentile aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric PercentileP95 { get; } = new("PERCENTILE_P95");

    /// <summary>
    /// 99th percentile aggregation metric. Not supported for pairwise metric.
    /// </summary>
    public static AggregationMetric PercentileP99 { get; } = new("PERCENTILE_P99");

    public static IReadOnlyList<AggregationMetric> AllValues {
      get;
    } = new[] { AggregationMetricUnspecified,
                Average,
                Mode,
                StandardDeviation,
                Variance,
                Minimum,
                Maximum,
                Median,
                PercentileP90,
                PercentileP95,
                PercentileP99 };

    public static AggregationMetric FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new AggregationMetric("AGGREGATION_METRIC_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new AggregationMetric(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator AggregationMetric(string value) => FromString(value);

    public bool Equals(AggregationMetric other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class AggregationMetricConverter : JsonConverter<AggregationMetric> {
    public override AggregationMetric Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                           JsonSerializerOptions options) {
      var value = reader.GetString();
      return AggregationMetric.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, AggregationMetric value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
