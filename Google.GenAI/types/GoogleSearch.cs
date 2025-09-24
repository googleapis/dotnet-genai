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
  /// Tool to support Google Search in Model. Powered by Google.
  /// </summary>

  public record GoogleSearch {
    /// <summary>
    /// Optional. Filter search results to a specific time range.       If customers set a start
    /// time, they must set an end time (and vice versa).
    /// </summary>
    [JsonPropertyName("timeRangeFilter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Interval ? TimeRangeFilter { get; set; }

    /// <summary>
    /// Optional. List of domains to be excluded from the search results.       The default limit is
    /// 2000 domains.
    /// </summary>
    [JsonPropertyName("excludeDomains")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? ExcludeDomains {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GoogleSearch object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GoogleSearch object, or null if deserialization fails.</returns>
    /// </summary>
    public static GoogleSearch
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GoogleSearch>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
