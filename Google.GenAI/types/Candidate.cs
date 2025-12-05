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
    /// The reason why the model stopped generating tokens. If empty, the model has not stopped
    /// generating the tokens.
    /// </summary>
    [JsonPropertyName("finishReason")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FinishReason
        ? FinishReason {
            get; set;
          }

    /// <summary>
    /// Output only. Grounding metadata for the candidate.  This field is populated for
    /// `GenerateContent` calls.
    /// </summary>
    [JsonPropertyName("groundingMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GroundingMetadata
        ? GroundingMetadata {
            get; set;
          }

    /// <summary>
    /// Output only. The average log probability of the tokens in this candidate. This is a
    /// length-normalized score that can be used to compare the quality of candidates of different
    /// lengths. A higher average log probability suggests a more confident and coherent response.
    /// </summary>
    [JsonPropertyName("avgLogprobs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? AvgLogprobs {
            get; set;
          }

    /// <summary>
    /// Output only. The 0-based index of this candidate in the list of generated responses. This is
    /// useful for distinguishing between multiple candidates when `candidate_count` > 1.
    /// </summary>
    [JsonPropertyName("index")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? Index {
            get; set;
          }

    /// <summary>
    /// Output only. The detailed log probability information for the tokens in this candidate. This
    /// is useful for debugging, understanding model uncertainty, and identifying potential
    /// "hallucinations".
    /// </summary>
    [JsonPropertyName("logprobsResult")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LogprobsResult
        ? LogprobsResult {
            get; set;
          }

    /// <summary>
    /// Output only. A list of ratings for the safety of a response candidate. There is at most one
    /// rating per category.
    /// </summary>
    [JsonPropertyName("safetyRatings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<SafetyRating>
        ? SafetyRatings {
            get; set;
          }

    /// <summary>
    /// Output only. Metadata returned when the model uses the `url_context` tool to get information
    /// from a user-provided URL.
    /// </summary>
    [JsonPropertyName("urlContextMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public UrlContextMetadata
        ? UrlContextMetadata {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a Candidate object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized Candidate object, or null if deserialization fails.</returns>
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
