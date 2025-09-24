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
  /// Config for Hybrid Search.
  /// </summary>

  public record RagRetrievalConfigHybridSearch {
    /// <summary>
    /// Optional. Alpha value controls the weight between dense and sparse vector search results.
    /// The range is [0, 1], while 0 means sparse vector search only and 1 means dense vector search
    /// only. The default value is 0.5 which balances sparse and dense vector search equally.
    /// </summary>
    [JsonPropertyName("alpha")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double ? Alpha { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a RagRetrievalConfigHybridSearch object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RagRetrievalConfigHybridSearch object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static RagRetrievalConfigHybridSearch
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<RagRetrievalConfigHybridSearch>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
