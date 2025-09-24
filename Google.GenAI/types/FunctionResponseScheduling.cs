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

using System.Text.Json.Serialization;

namespace Google.GenAI.Types {
  /// <summary>
  /// Specifies how the response should be scheduled in the conversation.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<FunctionResponseScheduling>))]
  public enum FunctionResponseScheduling {
    /// <summary>
    /// This value is unused.
    /// </summary>
    [JsonPropertyName("SCHEDULING_UNSPECIFIED")] SCHEDULING_UNSPECIFIED,

    /// <summary>
    /// Only add the result to the conversation context, do not interrupt or trigger generation.
    /// </summary>
    [JsonPropertyName("SILENT")] SILENT,

    /// <summary>
    /// Add the result to the conversation context, and prompt to generate output without
    /// interrupting ongoing generation.
    /// </summary>
    [JsonPropertyName("WHEN_IDLE")] WHEN_IDLE,

    /// <summary>
    /// Add the result to the conversation context, interrupt ongoing generation and prompt to
    /// generate output.
    /// </summary>
    [JsonPropertyName("INTERRUPT")] INTERRUPT
  }
}
