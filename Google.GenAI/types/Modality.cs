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
  /// Server content modalities.
  /// </summary>

  [JsonConverter(typeof(ModalityConverter))]
  public readonly record struct Modality : IEquatable<Modality> {
    public string Value { get; }

    private Modality(string value) {
      Value = value;
    }

    /// <summary>
    /// The modality is unspecified.
    /// </summary>
    public static Modality ModalityUnspecified { get; } = new("MODALITY_UNSPECIFIED");

    /// <summary>
    /// Indicates the model should return text
    /// </summary>
    public static Modality Text { get; } = new("TEXT");

    /// <summary>
    /// Indicates the model should return images.
    /// </summary>
    public static Modality Image { get; } = new("IMAGE");

    /// <summary>
    /// Indicates the model should return audio.
    /// </summary>
    public static Modality Audio { get; } = new("AUDIO");

    /// <summary>
    /// Indicates the model should return video.
    /// </summary>
    public static Modality Video { get; } = new("VIDEO");

    public static IReadOnlyList<Modality> AllValues {
      get;
    } = new[] { ModalityUnspecified, Text, Image, Audio, Video };

    public static Modality FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new Modality("MODALITY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new Modality(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator Modality(string value) => FromString(value);

    public bool Equals(Modality other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ModalityConverter : JsonConverter<Modality> {
    public override Modality Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                  JsonSerializerOptions options) {
      var value = reader.GetString();
      return Modality.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, Modality value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
