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
  /// The stage of the underlying model. This enum is not supported in Vertex AI.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum ModelStage {
    /// <summary>
    /// Unspecified model stage.
    /// </summary>
    [JsonPropertyName("MODEL_STAGE_UNSPECIFIED")] MODEL_STAGE_UNSPECIFIED,

    /// <summary>
    /// The underlying model is subject to lots of tunings.
    /// </summary>
    [JsonPropertyName("UNSTABLE_EXPERIMENTAL")] UNSTABLE_EXPERIMENTAL,

    /// <summary>
    /// Models in this stage are for experimental purposes only.
    /// </summary>
    [JsonPropertyName("EXPERIMENTAL")] EXPERIMENTAL,

    /// <summary>
    /// Models in this stage are more mature than experimental models.
    /// </summary>
    [JsonPropertyName("PREVIEW")] PREVIEW,

    /// <summary>
    /// Models in this stage are considered stable and ready for production use.
    /// </summary>
    [JsonPropertyName("STABLE")] STABLE,

    /// <summary>
    /// If the model is on this stage, it means that this model is on the path to deprecation in
    /// near future. Only existing customers can use this model.
    /// </summary>
    [JsonPropertyName("LEGACY")] LEGACY,

    /// <summary>
    /// Models in this stage are deprecated. These models cannot be used.
    /// </summary>
    [JsonPropertyName("DEPRECATED")] DEPRECATED,

    /// <summary>
    /// Models in this stage are retired. These models cannot be used.
    /// </summary>
    [JsonPropertyName("RETIRED")] RETIRED
  }
}
