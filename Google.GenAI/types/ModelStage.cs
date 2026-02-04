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
using System.Collections.Generic;
using System.Text.Json;

namespace Google.GenAI.Types {
  /// <summary>
  /// The stage of the underlying model. This enum is not supported in Vertex AI.
  /// </summary>

  [JsonConverter(typeof(ModelStageConverter))]
  public readonly record struct ModelStage : IEquatable<ModelStage> {
    public string Value { get; }

    private ModelStage(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified model stage.
    /// </summary>
    public static ModelStage ModelStageUnspecified { get; } = new("MODEL_STAGE_UNSPECIFIED");

    /// <summary>
    /// The underlying model is subject to lots of tunings.
    /// </summary>
    public static ModelStage UnstableExperimental { get; } = new("UNSTABLE_EXPERIMENTAL");

    /// <summary>
    /// Models in this stage are for experimental purposes only.
    /// </summary>
    public static ModelStage Experimental { get; } = new("EXPERIMENTAL");

    /// <summary>
    /// Models in this stage are more mature than experimental models.
    /// </summary>
    public static ModelStage Preview { get; } = new("PREVIEW");

    /// <summary>
    /// Models in this stage are considered stable and ready for production use.
    /// </summary>
    public static ModelStage Stable { get; } = new("STABLE");

    /// <summary>
    /// If the model is on this stage, it means that this model is on the path to deprecation in
    /// near future. Only existing customers can use this model.
    /// </summary>
    public static ModelStage Legacy { get; } = new("LEGACY");

    /// <summary>
    /// Models in this stage are deprecated. These models cannot be used.
    /// </summary>
    public static ModelStage Deprecated { get; } = new("DEPRECATED");

    /// <summary>
    /// Models in this stage are retired. These models cannot be used.
    /// </summary>
    public static ModelStage Retired { get; } = new("RETIRED");

    public static IReadOnlyList<ModelStage> AllValues {
      get;
    } = new[] { ModelStageUnspecified,
                UnstableExperimental,
                Experimental,
                Preview,
                Stable,
                Legacy,
                Deprecated,
                Retired };

    public static ModelStage FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ModelStage("MODEL_STAGE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ModelStage(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ModelStage(string value) => FromString(value);

    public bool Equals(ModelStage other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ModelStageConverter : JsonConverter<ModelStage> {
    public override ModelStage Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                    JsonSerializerOptions options) {
      var value = reader.GetString();
      return ModelStage.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ModelStage value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
