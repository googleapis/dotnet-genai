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
  /// Response message for PredictionService.GenerateContent.
  /// </summary>

  public record GenerateContentResponse {
    /// <summary>
    /// Response variations returned by the model.
    /// </summary>
    [JsonPropertyName("candidates")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Candidate> ? Candidates { get; set; }

    /// <summary>
    /// Timestamp when the request is made to the server.
    /// </summary>
    [JsonPropertyName("createTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime
        ? CreateTime {
            get; set;
          }

    /// <summary>
    /// Output only. The model version used to generate the response.
    /// </summary>
    [JsonPropertyName("modelVersion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ModelVersion {
            get; set;
          }

    /// <summary>
    /// Output only. Content filter results for a prompt sent in the request. Note: Sent only in the
    /// first stream chunk. Only happens when no candidates were generated due to content
    /// violations.
    /// </summary>
    [JsonPropertyName("promptFeedback")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerateContentResponsePromptFeedback
        ? PromptFeedback {
            get; set;
          }

    /// <summary>
    /// Output only. response_id is used to identify each response. It is the encoding of the
    /// event_id.
    /// </summary>
    [JsonPropertyName("responseId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? ResponseId {
            get; set;
          }

    /// <summary>
    /// Usage metadata about the response(s).
    /// </summary>
    [JsonPropertyName("usageMetadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GenerateContentResponseUsageMetadata
        ? UsageMetadata {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GenerateContentResponse object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerateContentResponse object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static GenerateContentResponse
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GenerateContentResponse>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
