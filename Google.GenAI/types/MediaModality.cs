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
  /// The modality that this token count applies to.
  /// </summary>

  [JsonConverter(typeof(MediaModalityConverter))]
  public readonly record struct MediaModality : IEquatable<MediaModality> {
    public string Value { get; }

    private MediaModality(string value) {
      Value = value;
    }

    /// <summary>
    /// When a modality is not specified, it is treated as `TEXT`.
    /// </summary>
    public static MediaModality ModalityUnspecified { get; } = new("MODALITY_UNSPECIFIED");

    /// <summary>
    /// The `Part` contains plain text.
    /// </summary>
    public static MediaModality Text { get; } = new("TEXT");

    /// <summary>
    /// The `Part` contains an image.
    /// </summary>
    public static MediaModality Image { get; } = new("IMAGE");

    /// <summary>
    /// The `Part` contains a video.
    /// </summary>
    public static MediaModality Video { get; } = new("VIDEO");

    /// <summary>
    /// The `Part` contains audio.
    /// </summary>
    public static MediaModality Audio { get; } = new("AUDIO");

    /// <summary>
    /// The `Part` contains a document, such as a PDF.
    /// </summary>
    public static MediaModality Document { get; } = new("DOCUMENT");

    public static IReadOnlyList<MediaModality> AllValues {
      get;
    } = new[] { ModalityUnspecified, Text, Image, Video, Audio, Document };

    public static MediaModality FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new MediaModality("MODALITY_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new MediaModality(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator MediaModality(string value) => FromString(value);

    public bool Equals(MediaModality other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class MediaModalityConverter : JsonConverter<MediaModality> {
    public override MediaModality Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                       JsonSerializerOptions options) {
      var value = reader.GetString();
      return MediaModality.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, MediaModality value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
