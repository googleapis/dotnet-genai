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
  /// Config for ranking and reranking.
  /// </summary>

  public record RagRetrievalConfigRanking {
    /// <summary>
    /// Optional. Config for LlmRanker.
    /// </summary>
    [JsonPropertyName("llmRanker")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RagRetrievalConfigRankingLlmRanker ? LlmRanker { get; set; }

    /// <summary>
    /// Optional. Config for Rank Service.
    /// </summary>
    [JsonPropertyName("rankService")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RagRetrievalConfigRankingRankService
        ? RankService {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a RagRetrievalConfigRanking object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized RagRetrievalConfigRanking object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static RagRetrievalConfigRanking
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<RagRetrievalConfigRanking>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
