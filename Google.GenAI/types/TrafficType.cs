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
  /// Output only. Traffic type. This shows whether a request consumes Pay-As-You-Go or Provisioned
  /// Throughput quota.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<TrafficType>))]
  public enum TrafficType {
    /// <summary>
    /// Unspecified request traffic type.
    /// </summary>
    [JsonPropertyName("TRAFFIC_TYPE_UNSPECIFIED")] TRAFFIC_TYPE_UNSPECIFIED,

    /// <summary>
    /// Type for Pay-As-You-Go traffic.
    /// </summary>
    [JsonPropertyName("ON_DEMAND")] ON_DEMAND,

    /// <summary>
    /// Type for Provisioned Throughput traffic.
    /// </summary>
    [JsonPropertyName("PROVISIONED_THROUGHPUT")] PROVISIONED_THROUGHPUT
  }
}
