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
  /// Response for the embed_content method.
  /// </summary>

  public record EmbedContentResponse {
    /// <summary>
    /// Used to retain the full HTTP response.
    /// </summary>
    [JsonPropertyName("sdkHttpResponse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HttpResponse ? SdkHttpResponse { get; set; }

    /// <summary>
    /// The embeddings for each request, in the same order as provided in the batch request.
    /// </summary>
    [JsonPropertyName("embeddings")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ContentEmbedding>
        ? Embeddings {
            get; set;
          }

    /// <summary>
    /// Gemini Enterprise Agent Platform only. Metadata about the request.
    /// </summary>
    [JsonPropertyName("metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public EmbedContentMetadata
        ? Metadata {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a EmbedContentResponse object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized EmbedContentResponse object, or null if deserialization
    /// fails.</returns>
    public static EmbedContentResponse
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<EmbedContentResponse>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
