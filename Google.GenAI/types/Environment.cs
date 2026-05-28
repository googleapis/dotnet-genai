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
  /// The environment being operated.
  /// </summary>

  [JsonConverter(typeof(EnvironmentConverter))]
  public readonly record struct Environment : IEquatable<Environment> {
    public string Value { get; }

    private Environment(string value) {
      Value = value;
    }

    /// <summary>
    /// Defaults to browser.
    /// </summary>
    public static Environment EnvironmentUnspecified { get; } = new("ENVIRONMENT_UNSPECIFIED");

    /// <summary>
    /// Operates in a web browser.
    /// </summary>
    public static Environment EnvironmentBrowser { get; } = new("ENVIRONMENT_BROWSER");

    /// <summary>
    /// Operates in a mobile environment.
    /// </summary>
    public static Environment EnvironmentMobile { get; } = new("ENVIRONMENT_MOBILE");

    /// <summary>
    /// Operates in a desktop environment.
    /// </summary>
    public static Environment EnvironmentDesktop { get; } = new("ENVIRONMENT_DESKTOP");

    public static IReadOnlyList<Environment> AllValues {
      get;
    } = new[] { EnvironmentUnspecified, EnvironmentBrowser, EnvironmentMobile, EnvironmentDesktop };

    public static Environment FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new Environment("ENVIRONMENT_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new Environment(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator Environment(string value) => FromString(value);

    public bool Equals(Environment other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class EnvironmentConverter : JsonConverter<Environment> {
    public override Environment Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                     JsonSerializerOptions options) {
      var value = reader.GetString();
      return Environment.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, Environment value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
