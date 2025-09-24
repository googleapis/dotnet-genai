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
  /// The definition of the Rag resource.
  /// </summary>

  public record VertexRagStoreRagResource {
    /// <summary>
    /// Optional. RagCorpora resource name. Format:
    /// `projects/{project}/locations/{location}/ragCorpora/{rag_corpus}`
    /// </summary>
    [JsonPropertyName("ragCorpus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? RagCorpus { get; set; }

    /// <summary>
    /// Optional. rag_file_id. The files should be in the same rag_corpus set in rag_corpus field.
    /// </summary>
    [JsonPropertyName("ragFileIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>
        ? RagFileIds {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a VertexRagStoreRagResource object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized VertexRagStoreRagResource object, or null if deserialization
    /// fails.</returns>
    /// </summary>
    public static VertexRagStoreRagResource
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<VertexRagStoreRagResource>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
