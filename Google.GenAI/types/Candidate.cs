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
  /// A response candidate generated from the model.
  /// </summary>

  public record Candidate {
    /// <summary>
    /// Contains the multi-part content of the response.
    /// </summary>
    [JsonPropertyName("content")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Content ? Content { get; set; }

    /// <summary>
    /// Source attribution of the generated content.
    /// </summary>
    [JsonPropertyName("citationMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CitationMetadata
        ? CitationMetadata {
            get; set;
          }

    /// <summary>
    /// Describes the reason the model stopped generating tokens.
    /// </summary>
    [JsonPropertyName("finishMessage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? FinishMessage {
            get; set;
          }

    /// <summary>
    /// Number of tokens for this candidate.
    /// </summary>
    [JsonPropertyName("tokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? TokenCount {
            get; set;
          }

    /// <summary>
    /// The reason why the model stopped generating tokens.       If empty, the model has not
    /// stopped generating the tokens.
    /// </summary>
    [JsonPropertyName("finishReason")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FinishReason
        ? FinishReason {
            get; set;
          }

    /// <summary>
    /// Metadata related to url context retrieval tool.
    /// </summary>
    [JsonPropertyName("urlContextMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public UrlContextMetadata
        ? UrlContextMetadata {
            get; set;
          }

    /// <summary>
    /// Output only. Average log probability score of the candidate.
    /// </summary>
    [JsonPropertyName("avgLogprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? AvgLogprobs {
            get; set;
          }

    /// <summary>
    /// Output only. Metadata specifies sources used to ground generated content.
    /// </summary>
    [JsonPropertyName("groundingMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GroundingMetadata
        ? GroundingMetadata {
            get; set;
          }

    /// <summary>
    /// Output only. Index of the candidate.
    /// </summary>
    [JsonPropertyName("index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Index {
            get; set;
          }

    /// <summary>
    /// Output only. Log-likelihood scores for the response tokens and top tokens
    /// </summary>
    [JsonPropertyName("logprobsResult")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LogprobsResult
        ? LogprobsResult {
            get; set;
          }

    /// <summary>
    /// Output only. List of ratings for the safety of a response candidate. There is at most one
    /// rating per category.
    /// </summary>
    [JsonPropertyName("safetyRatings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SafetyRating>
        ? SafetyRatings {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Candidate object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Candidate object, or null if deserialization fails.</returns>
    /// </summary>
    public static Candidate ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<Candidate>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
