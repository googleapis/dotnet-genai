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
  /// Retrieve from Vertex RAG Store for grounding.
  /// </summary>

  public record VertexRagStore {
    /// <summary>
    /// Optional. Deprecated. Please use rag_resources instead.
    /// </summary>
    [JsonPropertyName("ragCorpora")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> ? RagCorpora { get; set; }

    /// <summary>
    /// Optional. The representation of the rag source. It can be used to specify corpus only or
    /// ragfiles. Currently only support one corpus or multiple files from one corpus. In the future
    /// we may open up multiple corpora support.
    /// </summary>
    [JsonPropertyName("ragResources")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<VertexRagStoreRagResource>
        ? RagResources {
            get; set;
          }

    /// <summary>
    /// Optional. The retrieval config for the Rag query.
    /// </summary>
    [JsonPropertyName("ragRetrievalConfig")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RagRetrievalConfig
        ? RagRetrievalConfig {
            get; set;
          }

    /// <summary>
    /// Optional. Number of top k results to return from the selected corpora.
    /// </summary>
    [JsonPropertyName("similarityTopK")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? SimilarityTopK {
            get; set;
          }

    /// <summary>
    /// Optional. Currently only supported for Gemini Multimodal Live API. In Gemini Multimodal Live
    /// API, if `store_context` bool is specified, Gemini will leverage it to automatically memorize
    /// the interactions between the client and Gemini, and retrieve context when needed to augment
    /// the response generation for users' ongoing and future interactions.
    /// </summary>
    [JsonPropertyName("storeContext")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool
        ? StoreContext {
            get; set;
          }

    /// <summary>
    /// Optional. Only return results with vector distance smaller than the threshold.
    /// </summary>
    [JsonPropertyName("vectorDistanceThreshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double
        ? VectorDistanceThreshold {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a VertexRagStore object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized VertexRagStore object, or null if deserialization fails.</returns>
    /// </summary>
    public static VertexRagStore
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<VertexRagStore>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
