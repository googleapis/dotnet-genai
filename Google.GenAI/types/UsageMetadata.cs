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
  /// Usage metadata about response(s).
  /// </summary>

  public record UsageMetadata {
    /// <summary>
    /// Number of tokens in the prompt. When `cached_content` is set, this is still the total
    /// effective prompt size meaning this includes the number of tokens in the cached content.
    /// </summary>
    [JsonPropertyName("promptTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int ? PromptTokenCount { get; set; }

    /// <summary>
    /// Number of tokens in the cached part of the prompt (the cached content).
    /// </summary>
    [JsonPropertyName("cachedContentTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CachedContentTokenCount {
            get; set;
          }

    /// <summary>
    /// Total number of tokens across all the generated response candidates.
    /// </summary>
    [JsonPropertyName("responseTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ResponseTokenCount {
            get; set;
          }

    /// <summary>
    /// Number of tokens present in tool-use prompt(s).
    /// </summary>
    [JsonPropertyName("toolUsePromptTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ToolUsePromptTokenCount {
            get; set;
          }

    /// <summary>
    /// Number of tokens of thoughts for thinking models.
    /// </summary>
    [JsonPropertyName("thoughtsTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ThoughtsTokenCount {
            get; set;
          }

    /// <summary>
    /// Total token count for prompt, response candidates, and tool-use prompts(if present).
    /// </summary>
    [JsonPropertyName("totalTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? TotalTokenCount {
            get; set;
          }

    /// <summary>
    /// List of modalities that were processed in the request input.
    /// </summary>
    [JsonPropertyName("promptTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? PromptTokensDetails {
            get; set;
          }

    /// <summary>
    /// List of modalities that were processed in the cache input.
    /// </summary>
    [JsonPropertyName("cacheTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? CacheTokensDetails {
            get; set;
          }

    /// <summary>
    /// List of modalities that were returned in the response.
    /// </summary>
    [JsonPropertyName("responseTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? ResponseTokensDetails {
            get; set;
          }

    /// <summary>
    /// List of modalities that were processed in the tool-use prompt.
    /// </summary>
    [JsonPropertyName("toolUsePromptTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? ToolUsePromptTokensDetails {
            get; set;
          }

    /// <summary>
    /// Traffic type. This shows whether a request consumes Pay-As-You-Go  or Provisioned Throughput
    /// quota.
    /// </summary>
    [JsonPropertyName("trafficType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TrafficType
        ? TrafficType {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a UsageMetadata object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized UsageMetadata object, or null if deserialization fails.</returns>
    /// </summary>
    public static UsageMetadata
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<UsageMetadata>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
