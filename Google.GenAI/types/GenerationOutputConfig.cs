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
  /// Configuration for persisting output assets to external storage.
  /// </summary>

  public record GenerationOutputConfig {
    /// <summary>
    /// Optional. The Cloud Storage URI prefix or directory where generated media assets should be
    /// written (e.g. "gs://my-bucket/prefix/"). Supported URI schemes: "gs://". When set, media
    /// bytes are written directly to this location and returned as FileData with a file_uri instead
    /// of raw inline bytes.
    /// </summary>
    [JsonPropertyName("outputUriPrefix")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ? OutputUriPrefix { get; set; }

    /// <summary>
    /// Deserializes a JSON string to a GenerationOutputConfig object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized GenerationOutputConfig object, or null if deserialization
    /// fails.</returns>
    public static GenerationOutputConfig
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<GenerationOutputConfig>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
