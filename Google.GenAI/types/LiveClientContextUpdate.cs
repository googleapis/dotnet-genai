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
  /// Updates to the context of the current session.  Only fields that are set will be updated.
  /// Updates are guaranteed to be processed *in order* with the rest of the inputs.
  /// </summary>

  public record LiveClientContextUpdate {
    /// <summary>
    /// Updated system instruction for the model. If set, overrides
    /// `BidiGenerateContentSetup.system_instruction`. The system instructions are part of the model
    /// preamble, so updating them invalidates the prefix cache. Clients should only update this
    /// field when strictly necessary as it might have a performance impact on the model generation.
    /// </summary>
    [JsonPropertyName("systemInstruction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Content ? SystemInstruction { get; set; }

    /// <summary>
    /// An updated list of tools the model may use to generate the subsequent responses. If set,
    /// this list replaces the previously provided tools. The tools are part of the model preamble,
    /// so updating them invalidates the prefix cache. Clients should only update this field when
    /// strictly necessary as it might have a performance impact on the model generation.
    /// </summary>
    [JsonPropertyName("tools")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LiveClientContextUpdateTools
        ? Tools {
            get; set;
          }

    /// <summary>
    /// Deserializes a JSON string to a LiveClientContextUpdate object.
    /// </summary>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="options">Optional JsonSerializerOptions.</param>
    /// <returns>The deserialized LiveClientContextUpdate object, or null if deserialization
    /// fails.</returns>
    public static LiveClientContextUpdate
        ? FromJson(string jsonString, JsonSerializerOptions? options = null) {
      try {
        return JsonSerializer.Deserialize(jsonString,
                                          JsonConfig.TypeInfo<LiveClientContextUpdate>(options));
      } catch (JsonException e) {
        Console.Error.WriteLine($"Error deserializing JSON: {e.ToString()}");
        return null;
      }
    }
  }
}
