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
  /// The orientation of the video. Defaults to LANDSCAPE. This enum is not supported in Gemini API.
  /// </summary>

  [JsonConverter(typeof(VideoOrientationConverter))]
  public readonly record struct VideoOrientation : IEquatable<VideoOrientation> {
    public string Value { get; }

    private VideoOrientation(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified video orientation. Defaults to landscape.
    /// </summary>
    public static VideoOrientation VideoOrientationUnspecified {
      get;
    } = new("VIDEO_ORIENTATION_UNSPECIFIED");

    /// <summary>
    /// Landscape orientation (e.g. 16:9, 1280x720).
    /// </summary>
    public static VideoOrientation Landscape { get; } = new("LANDSCAPE");

    /// <summary>
    /// Portrait orientation (e.g. 9:16, 720x1280).
    /// </summary>
    public static VideoOrientation Portrait { get; } = new("PORTRAIT");

    public static IReadOnlyList<VideoOrientation> AllValues {
      get;
    } = new[] { VideoOrientationUnspecified, Landscape, Portrait };

    public static VideoOrientation FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new VideoOrientation("VIDEO_ORIENTATION_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new VideoOrientation(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator VideoOrientation(string value) => FromString(value);

    public bool Equals(VideoOrientation other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class VideoOrientationConverter : JsonConverter<VideoOrientation> {
    public override VideoOrientation Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                          JsonSerializerOptions options) {
      var value = reader.GetString();
      return VideoOrientation.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, VideoOrientation value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
