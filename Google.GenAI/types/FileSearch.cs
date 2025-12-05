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
  /// The FileSearch tool that retrieves knowledge from Semantic Retrieval corpora. Files are
  /// imported to Semantic Retrieval corpora using the ImportFile API. This data type is not
  /// supported in Vertex AI.
  /// </summary>

  public record FileSearch {
    /// <summary>
    /// The names of the file_search_stores to retrieve from. Example:
    /// `fileSearchStores/my-file-search-store-123`
    /// </summary>
    [JsonPropertyName("fileSearchStoreNames")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> ? FileSearchStoreNames { get; set; }

    /// <summary>
    /// Optional. Metadata filter to apply to the semantic retrieval documents and chunks.
    /// </summary>
    [JsonPropertyName("metadataFilter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string
        ? MetadataFilter {
            get; set;
          }

    /// <summary>
    /// Optional. The number of semantic retrieval chunks to retrieve.
    /// </summary>
    [JsonPropertyName("topK")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? TopK {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a FileSearch object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized FileSearch object, or null if deserialization fails.</returns>
    public static FileSearch ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<FileSearch>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
