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

namespace Google.GenAI.Types
{
  /// <summary>
  /// Usage metadata about the content generation request and response. This message provides a
  /// detailed breakdown of token usage and other relevant metrics. This data type is not supported
  /// in Gemini API.
  /// </summary>

  public record GenerateContentResponseUsageMetadata
  {
    /// <summary>
    /// Output only. A detailed breakdown of the token count for each modality in the cached
    /// content.
    /// </summary>
    [JsonPropertyName("cacheTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>? CacheTokensDetails { get; set; }

    /// <summary>
    /// Output only. The number of tokens in the cached content that was used for this request.
    /// </summary>
    [JsonPropertyName("cachedContentTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CachedContentTokenCount
    {
      get; set;
    }

    /// <summary>
    /// The total number of tokens in the generated candidates.
    /// </summary>
    [JsonPropertyName("candidatesTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? CandidatesTokenCount
    {
      get; set;
    }

    /// <summary>
    /// Output only. A detailed breakdown of the token count for each modality in the generated
    /// candidates.
    /// </summary>
    [JsonPropertyName("candidatesTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? CandidatesTokensDetails
    {
      get; set;
    }

    /// <summary>
    /// The total number of tokens in the prompt. This includes any text, images, or other media
    /// provided in the request. When `cached_content` is set, this also includes the number of
    /// tokens in the cached content.
    /// </summary>
    [JsonPropertyName("promptTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? PromptTokenCount
    {
      get; set;
    }

    /// <summary>
    /// Output only. A detailed breakdown of the token count for each modality in the prompt.
    /// </summary>
    [JsonPropertyName("promptTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? PromptTokensDetails
    {
      get; set;
    }

    /// <summary>
    /// Output only. The number of tokens that were part of the model's generated "thoughts" output,
    /// if applicable.
    /// </summary>
    [JsonPropertyName("thoughtsTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ThoughtsTokenCount
    {
      get; set;
    }

    /// <summary>
    /// Output only. The number of tokens in the results from tool executions, which are provided
    /// back to the model as input, if applicable.
    /// </summary>
    [JsonPropertyName("toolUsePromptTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? ToolUsePromptTokenCount
    {
      get; set;
    }

    /// <summary>
    /// Output only. A detailed breakdown by modality of the token counts from the results of tool
    /// executions, which are provided back to the model as input.
    /// </summary>
    [JsonPropertyName("toolUsePromptTokensDetails")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ModalityTokenCount>
        ? ToolUsePromptTokensDetails
    {
      get; set;
    }

    /// <summary>
    /// The total number of tokens for the entire request. This is the sum of `prompt_token_count`,
    /// `candidates_token_count`, `tool_use_prompt_token_count`, and `thoughts_token_count`.
    /// </summary>
    [JsonPropertyName("totalTokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? TotalTokenCount
    {
      get; set;
    }

    /// <summary>
    /// Output only. The traffic type for this request.
    /// </summary>
    [JsonPropertyName("trafficType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TrafficType
        ? TrafficType
    {
      get; set;
    }

    /// <summary>
    /// Deserializes a JSON string to a GenerateContentResponseUsageMetadata object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerateContentResponseUsageMetadata object, or null if
    /// deserialization fails.</returns>
    public static GenerateContentResponseUsageMetadata
        ? FromJson(string jsonString, JsonSerializerOptions? options = null)
    {
      try
      {
        return JsonSerializer.Deserialize<GenerateContentResponseUsageMetadata>(jsonString,
                                                                                options);
      }
      catch (JsonException e)
      {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
