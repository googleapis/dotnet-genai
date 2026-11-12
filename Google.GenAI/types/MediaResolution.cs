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
  /// The token resolution at which input media content is sampled. This is used to control the
  /// trade-off between the quality of the response and the number of tokens used to represent the
  /// media. A higher resolution allows the model to perceive more detail, which can lead to a more
  /// nuanced response, but it will also use more tokens. This does not affect the image dimensions
  /// sent to the model.
  /// </summary>

  [JsonConverter(typeof(MediaResolutionConverter))]
  public readonly record struct MediaResolution : IEquatable<MediaResolution> {
    public string Value { get; }

    private MediaResolution(string value) {
      Value = value;
    }

    /// <summary>
    /// Media resolution has not been set.
    /// </summary>
    public static MediaResolution MediaResolutionUnspecified {
      get;
    } = new("MEDIA_RESOLUTION_UNSPECIFIED");

    /// <summary>
    /// Media resolution set to low (64 tokens).
    /// </summary>
    public static MediaResolution MediaResolutionLow { get; } = new("MEDIA_RESOLUTION_LOW");

    /// <summary>
    /// Media resolution set to medium (256 tokens).
    /// </summary>
    public static MediaResolution MediaResolutionMedium { get; } = new("MEDIA_RESOLUTION_MEDIUM");

    /// <summary>
    /// Media resolution set to high (zoomed reframing with 256 tokens).
    /// </summary>
    public static MediaResolution MediaResolutionHigh { get; } = new("MEDIA_RESOLUTION_HIGH");

    public static IReadOnlyList<MediaResolution> AllValues {
      get;
    } = new[] { MediaResolutionUnspecified, MediaResolutionLow, MediaResolutionMedium,
                MediaResolutionHigh };

    public static MediaResolution FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new MediaResolution("MEDIA_RESOLUTION_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new MediaResolution(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator MediaResolution(string value) => FromString(value);

    public bool Equals(MediaResolution other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class MediaResolutionConverter : JsonConverter<MediaResolution> {
    public override MediaResolution Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                         JsonSerializerOptions options) {
      var value = reader.GetString();
      return MediaResolution.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, MediaResolution value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
