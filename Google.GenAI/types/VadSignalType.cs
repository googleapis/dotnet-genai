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
  /// The type of the VAD signal.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum VadSignalType {
    /// <summary>
    /// The default is VAD_SIGNAL_TYPE_UNSPECIFIED.
    /// </summary>
    [JsonPropertyName("VAD_SIGNAL_TYPE_UNSPECIFIED")] VAD_SIGNAL_TYPE_UNSPECIFIED,

    /// <summary>
    /// Start of sentence signal.
    /// </summary>
    [JsonPropertyName("VAD_SIGNAL_TYPE_SOS")] VAD_SIGNAL_TYPE_SOS,

    /// <summary>
    /// End of sentence signal.
    /// </summary>
    [JsonPropertyName("VAD_SIGNAL_TYPE_EOS")] VAD_SIGNAL_TYPE_EOS
  }
}
