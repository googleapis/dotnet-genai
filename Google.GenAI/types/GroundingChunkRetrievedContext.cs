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
  /// Context retrieved from a data source to ground the model's response. This is used when a
  /// retrieval tool fetches information from a user-provided corpus or a public dataset.
  /// </summary>

  public record GroundingChunkRetrievedContext {
    /// <summary>
    /// Output only. The full resource name of the referenced Vertex AI Search document. This is
    /// used to identify the specific document that was retrieved. The format is
    /// `projects/{project}/locations/{location}/collections/{collection}/dataStores/{data_store}/branches/{branch}/documents/{document}`.
    /// This field is not supported in Gemini API.
    /// </summary>
    [JsonPropertyName("documentName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? DocumentName { get; set; }

    /// <summary>
    /// Additional context for a Retrieval-Augmented Generation (RAG) retrieval result. This is
    /// populated only when the RAG retrieval tool is used. This field is not supported in Gemini
    /// API.
    /// </summary>
    [JsonPropertyName("ragChunk")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RagChunk
        ? RagChunk {
            get; set;
          }

    /// <summary>
    /// The content of the retrieved data source.
    /// </summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Text {
            get; set;
          }

    /// <summary>
    /// The title of the retrieved data source.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Title {
            get; set;
          }

    /// <summary>
    /// The URI of the retrieved data source.
    /// </summary>
    [JsonPropertyName("uri")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? Uri {
            get; set;
          }

    /// <summary>
    /// Optional. Name of the `FileSearchStore` containing the document. Example:
    /// `fileSearchStores/123`. This field is not supported in Vertex AI.
    /// </summary>
    [JsonPropertyName("fileSearchStore")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? FileSearchStore {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a GroundingChunkRetrievedContext object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GroundingChunkRetrievedContext object, or null if deserialization
    /// fails.</returns>
    public static GroundingChunkRetrievedContext
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<GroundingChunkRetrievedContext>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
