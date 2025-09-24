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
  /// Optional parameters for the embed_content method.
  /// </summary>

  public record EmbedContentConfig {
    /// <summary>
    /// Used to override HTTP request options.
    /// </summary>
    [JsonPropertyName("httpOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpOptions ? HttpOptions { get; set; }

    /// <summary>
    /// Type of task for which the embedding will be used.
    /// </summary>
    [JsonPropertyName("taskType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? TaskType {
            get; set;
          }

    /// <summary>
    /// Title for the text. Only applicable when TaskType is       `RETRIEVAL_DOCUMENT`.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Title {
            get; set;
          }

    /// <summary>
    /// Reduced dimension for the output embedding. If set,       excessive values in the output
    /// embedding are truncated from the end.       Supported by newer models since 2024 only. You
    /// cannot set this value if       using the earlier model (`models/embedding-001`).
    /// </summary>
    [JsonPropertyName("outputDimensionality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? OutputDimensionality {
            get; set;
          }

    /// <summary>
    /// Vertex API only. The MIME type of the input.
    /// </summary>
    [JsonPropertyName("mimeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? MimeType {
            get; set;
          }

    /// <summary>
    /// Vertex API only. Whether to silently truncate inputs longer than       the max sequence
    /// length. If this option is set to false, oversized inputs       will lead to an
    /// INVALID_ARGUMENT error, similar to other text APIs.
    /// </summary>
    [JsonPropertyName("autoTruncate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? AutoTruncate {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a EmbedContentConfig object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized EmbedContentConfig object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static EmbedContentConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<EmbedContentConfig>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
