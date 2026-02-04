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
  /// Data type of the schema field.
  /// </summary>

  [JsonConverter(typeof(TypeConverter))]
  public readonly record struct Type : IEquatable<Type> {
    public string Value { get; }

    private Type(string value) {
      Value = value;
    }

    /// <summary>
    /// Not specified, should not be used.
    /// </summary>
    public static Type TypeUnspecified { get; } = new("TYPE_UNSPECIFIED");

    /// <summary>
    /// OpenAPI string type
    /// </summary>
    public static Type String { get; } = new("STRING");

    /// <summary>
    /// OpenAPI number type
    /// </summary>
    public static Type Number { get; } = new("NUMBER");

    /// <summary>
    /// OpenAPI integer type
    /// </summary>
    public static Type Integer { get; } = new("INTEGER");

    /// <summary>
    /// OpenAPI boolean type
    /// </summary>
    public static Type Boolean { get; } = new("BOOLEAN");

    /// <summary>
    /// OpenAPI array type
    /// </summary>
    public static Type Array { get; } = new("ARRAY");

    /// <summary>
    /// OpenAPI object type
    /// </summary>
    public static Type Object { get; } = new("OBJECT");

    /// <summary>
    /// Null type
    /// </summary>
    public static Type Null { get; } = new("NULL");

    public static IReadOnlyList<Type> AllValues {
      get;
    } = new[] { TypeUnspecified, String, Number, Integer, Boolean, Array, Object, Null };

    public static Type FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new Type("TYPE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new Type(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator Type(string value) => FromString(value);

    public bool Equals(Type other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class TypeConverter : JsonConverter<Google.GenAI.Types.Type> {
    public override Google.GenAI.Types.Type Read(ref Utf8JsonReader reader,
                                                 System.Type typeToConvert,
                                                 JsonSerializerOptions options) {
      var value = reader.GetString();
      return Google.GenAI.Types.Type.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, Google.GenAI.Types.Type value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
