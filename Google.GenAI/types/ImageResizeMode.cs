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
  /// Resize mode for the image input for video generation.
  /// </summary>

  [JsonConverter(typeof(ImageResizeModeConverter))]
  public readonly record struct ImageResizeMode : IEquatable<ImageResizeMode> {
    public string Value { get; }

    private ImageResizeMode(string value) {
      Value = value;
    }

    /// <summary>
    /// Crop the image to fit the correct aspect ratio (so we lose parts of the image in the
    /// process).
    /// </summary>
    public static ImageResizeMode Crop { get; } = new("CROP");

    /// <summary>
    /// Pad the image to fit the correct aspect ratio (so we don't lose any parts of the image in
    /// the process).
    /// </summary>
    public static ImageResizeMode Pad { get; } = new("PAD");

    public static IReadOnlyList<ImageResizeMode> AllValues { get; } = new[] { Crop, Pad };

    public static ImageResizeMode FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new ImageResizeMode("UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new ImageResizeMode(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator ImageResizeMode(string value) => FromString(value);

    public bool Equals(ImageResizeMode other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class ImageResizeModeConverter : JsonConverter<ImageResizeMode> {
    public override ImageResizeMode Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                         JsonSerializerOptions options) {
      var value = reader.GetString();
      return ImageResizeMode.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, ImageResizeMode value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
