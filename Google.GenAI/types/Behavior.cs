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
  /// Specifies the function Behavior. Currently only non-blocking functions are supported. If not
  /// specified, the system keeps the current function call behavior. This field is currently only
  /// supported by the BidiGenerateContent method.
  /// </summary>

  [JsonConverter(typeof(BehaviorConverter))]
  public readonly record struct Behavior : IEquatable<Behavior> {
    public string Value { get; }

    private Behavior(string value) {
      Value = value;
    }

    /// <summary>
    /// This value is unspecified.
    /// </summary>
    public static Behavior Unspecified { get; } = new("UNSPECIFIED");

    /// <summary>
    /// If set, the system will wait to receive the function response before continuing the
    /// conversation.
    /// </summary>
    public static Behavior Blocking { get; } = new("BLOCKING");

    /// <summary>
    /// If set, the system will not wait to receive the function response. Instead, it will attempt
    /// to handle function responses as they become available while maintaining the conversation
    /// between the user and the model.
    /// </summary>
    public static Behavior NonBlocking { get; } = new("NON_BLOCKING");

    public static IReadOnlyList<Behavior> AllValues {
      get;
    } = new[] { Unspecified, Blocking, NonBlocking };

    public static Behavior FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new Behavior("UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new Behavior(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator Behavior(string value) => FromString(value);

    public bool Equals(Behavior other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class BehaviorConverter : JsonConverter<Behavior> {
    public override Behavior Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                  JsonSerializerOptions options) {
      var value = reader.GetString();
      return Behavior.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, Behavior value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
