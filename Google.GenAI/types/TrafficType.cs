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
  /// Output only. The traffic type for this request. This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(TrafficTypeConverter))]
  public readonly record struct TrafficType : IEquatable<TrafficType> {
    public string Value { get; }

    private TrafficType(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified request traffic type.
    /// </summary>
    public static TrafficType TrafficTypeUnspecified { get; } = new("TRAFFIC_TYPE_UNSPECIFIED");

    /// <summary>
    /// The request was processed using Pay-As-You-Go quota.
    /// </summary>
    public static TrafficType OnDemand { get; } = new("ON_DEMAND");

    /// <summary>
    /// Type for Priority Pay-As-You-Go traffic.
    /// </summary>
    public static TrafficType OnDemandPriority { get; } = new("ON_DEMAND_PRIORITY");

    /// <summary>
    /// Type for Flex traffic.
    /// </summary>
    public static TrafficType OnDemandFlex { get; } = new("ON_DEMAND_FLEX");

    /// <summary>
    /// Type for Provisioned Throughput traffic.
    /// </summary>
    public static TrafficType ProvisionedThroughput { get; } = new("PROVISIONED_THROUGHPUT");

    public static IReadOnlyList<TrafficType> AllValues {
      get;
    } = new[] { TrafficTypeUnspecified, OnDemand, OnDemandPriority, OnDemandFlex,
                ProvisionedThroughput };

    public static TrafficType FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new TrafficType("TRAFFIC_TYPE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new TrafficType(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator TrafficType(string value) => FromString(value);

    public bool Equals(TrafficType other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TrafficTypeConverter : JsonConverter<TrafficType> {
    public override TrafficType Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                     JsonSerializerOptions options) {
      var value = reader.GetString();
      return TrafficType.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, TrafficType value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
