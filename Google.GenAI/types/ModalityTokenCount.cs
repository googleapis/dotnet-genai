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
  /// Represents a breakdown of token usage by modality. This message is used in CountTokensResponse
  /// and GenerateContentResponse.UsageMetadata to provide a detailed view of how many tokens are
  /// used by each modality (e.g., text, image, video) in a request. This is particularly useful for
  /// multimodal models, allowing you to track and manage token consumption for billing and quota
  /// purposes.
  /// </summary>

  public record ModalityTokenCount {
    /// <summary>
    /// The modality that this token count applies to.
    /// </summary>
    [JsonPropertyName("modality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MediaModality ? Modality { get; set; }

    /// <summary>
    /// The number of tokens counted for this modality.
    /// </summary>
    [JsonPropertyName("tokenCount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int
        ? TokenCount {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a ModalityTokenCount object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized ModalityTokenCount object, or null if deserialization
    /// fails.</returns>
    public static ModalityTokenCount
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<ModalityTokenCount>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
