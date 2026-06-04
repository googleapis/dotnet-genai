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
    /// The total number of tokens in the prompt. This includes any text, images, or other media
    /// provided in the request. When `cached_content` is set, this also includes the number of
    /// tokens in the cached content.
    /// </summary>
    [JsonPropertyName("promptTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int ? PromptTokenCount { get; set; }

    /// <summary>
    /// Output only. The number of tokens in the cached content that was used for this request.
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
    /// Output only. The number of tokens in the results from tool executions, which are provided
    /// back to the model as input, if applicable.
    /// </summary>
    [JsonPropertyName("toolUsePromptTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ToolUsePromptTokenCount {
            get; set;
          }

    /// <summary>
    /// Output only. The number of tokens that were part of the model's generated "thoughts" output,
    /// if applicable.
    /// </summary>
    [JsonPropertyName("thoughtsTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ThoughtsTokenCount {
            get; set;
          }

    /// <summary>
    /// The total number of tokens for the entire request. This is the sum of `prompt_token_count`,
    /// `candidates_token_count`, `tool_use_prompt_token_count`, and `thoughts_token_count`.
    /// </summary>
    [JsonPropertyName("totalTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? TotalTokenCount {
            get; set;
          }

    /// <summary>
    /// Output only. A detailed breakdown of the token count for each modality in the prompt.
    /// </summary>
    [JsonPropertyName("promptTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? PromptTokensDetails {
            get; set;
          }

    /// <summary>
    /// Output only. A detailed breakdown of the token count for each modality in the cached
    /// content.
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
    /// Output only. A detailed breakdown by modality of the token counts from the results of tool
    /// executions, which are provided back to the model as input.
    /// </summary>
    [JsonPropertyName("toolUsePromptTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? ToolUsePromptTokensDetails {
            get; set;
          }

    /// <summary>
    /// Output only. The traffic type for this request. This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("trafficType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TrafficType
        ? TrafficType {
            get; set;
          }

    /// <summary>
    /// Output only. Service tier of the request. This field is not supported in Vertex AI.
    /// </summary>
    [JsonPropertyName("serviceTier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ServiceTier
        ? ServiceTier {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a UsageMetadata object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized UsageMetadata object, or null if deserialization fails.</returns>
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
