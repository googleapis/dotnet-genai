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
  /// Logprobs Result
  /// </summary>

  public record LogprobsResult {
    /// <summary>
    /// Length = total number of decoding steps. The chosen candidates may or may not be in
    /// top_candidates.
    /// </summary>
    [JsonPropertyName("chosenCandidates")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<LogprobsResultCandidate> ? ChosenCandidates { get; set; }

    /// <summary>
    /// Length = total number of decoding steps.
    /// </summary>
    [JsonPropertyName("topCandidates")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<LogprobsResultTopCandidates>
        ? TopCandidates {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LogprobsResult object.
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LogprobsResult object, or null if deserialization fails.</returns>
    /// </summary>
    public static LogprobsResult
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize<LogprobsResult>(jsonString, options);
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
