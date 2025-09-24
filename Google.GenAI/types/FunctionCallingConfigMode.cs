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
  /// Config for the function calling config mode.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter<FunctionCallingConfigMode>))]
  public enum FunctionCallingConfigMode {
    /// <summary>
    /// The function calling config mode is unspecified. Should not be used.
    /// </summary>
    [JsonPropertyName("MODE_UNSPECIFIED")] MODE_UNSPECIFIED,

    /// <summary>
    /// Default model behavior, model decides to predict either function calls or natural language
    /// response.
    /// </summary>
    [JsonPropertyName("AUTO")] AUTO,

    /// <summary>
    /// Model is constrained to always predicting function calls only. If "allowed_function_names"
    /// are set, the predicted function calls will be limited to any one of
    /// "allowed_function_names", else the predicted function calls will be any one of the provided
    /// "function_declarations".
    /// </summary>
    [JsonPropertyName("ANY")] ANY,

    /// <summary>
    /// Model will not predict any function calls. Model behavior is same as when not passing any
    /// function declarations.
    /// </summary>
    [JsonPropertyName("NONE")] NONE,

    /// <summary>
    /// Model decides to predict either a function call or a natural language response, but will
    /// validate function calls with constrained decoding. If "allowed_function_names" are set, the
    /// predicted function call will be limited to any one of "allowed_function_names", else the
    /// predicted function call will be any one of the provided "function_declarations".
    /// </summary>
    [JsonPropertyName("VALIDATED")] VALIDATED
  }
}
