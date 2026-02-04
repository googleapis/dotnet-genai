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
  /// ParallelAiSearch tool type. A tool that uses the Parallel.ai search engine for grounding. This
  /// data type is not supported in Gemini API.
  /// </summary>

  public record ToolParallelAiSearch {
    /// <summary>
    /// Optional. The API key for ParallelAiSearch. If an API key is not provided, the system will
    /// attempt to verify access by checking for an active Parallel.ai subscription through the
    /// Google Cloud Marketplace. See https://docs.parallel.ai/search/search-quickstart for more
    /// details.
    /// </summary>
    [JsonPropertyName("apiKey")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? ApiKey { get; set; }

    /// <summary>
    /// Optional. Custom configs for ParallelAiSearch. This field can be used to pass any parameter
    /// from the Parallel.ai Search API. See the Parallel.ai documentation for the full list of
    /// available parameters and their usage:
    /// https://docs.parallel.ai/api-reference/search-beta/search Currently only `source_policy`,
    /// `excerpts`, `max_results`, `mode`, `fetch_policy` can be set via this field. For example: {
    /// "source_policy": { "include_domains": ["google.com", "wikipedia.org"], "exclude_domains":
    /// ["example.com"] }, "fetch_policy": { "max_age_seconds": 3600 } }
    /// </summary>
    [JsonPropertyName("customConfigs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>
        ? CustomConfigs {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ToolParallelAiSearch object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ToolParallelAiSearch object, or null if deserialization
    /// fails.</returns>
    public static ToolParallelAiSearch
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ToolParallelAiSearch>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
