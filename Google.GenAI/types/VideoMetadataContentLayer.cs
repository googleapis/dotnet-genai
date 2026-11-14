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
  /// Content layers to extract from a video.
  /// </summary>

  [JsonConverter(typeof(VideoMetadataContentLayerConverter))]
  public readonly record struct VideoMetadataContentLayer : IEquatable<VideoMetadataContentLayer> {
    public string Value { get; }

    private VideoMetadataContentLayer(string value) {
      Value = value;
    }

    /// <summary>
    /// Default value.
    /// </summary>
    public static VideoMetadataContentLayer ContentLayerUnspecified {
      get;
    } = new("CONTENT_LAYER_UNSPECIFIED");

    /// <summary>
    /// Extract video frames.
    /// </summary>
    public static VideoMetadataContentLayer Frames { get; } = new("FRAMES");

    /// <summary>
    /// Extract audio track.
    /// </summary>
    public static VideoMetadataContentLayer Audio { get; } = new("AUDIO");

    /// <summary>
    /// Extract audio transcript.
    /// </summary>
    public static VideoMetadataContentLayer Transcript { get; } = new("TRANSCRIPT");

    public static IReadOnlyList<VideoMetadataContentLayer> AllValues {
      get;
    } = new[] { ContentLayerUnspecified, Frames, Audio, Transcript };

    public static VideoMetadataContentLayer FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new VideoMetadataContentLayer("CONTENT_LAYER_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new VideoMetadataContentLayer(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator VideoMetadataContentLayer(string value) => FromString(value);

    public bool Equals(VideoMetadataContentLayer other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class VideoMetadataContentLayerConverter : JsonConverter<VideoMetadataContentLayer> {
    public override VideoMetadataContentLayer Read(ref Utf8JsonReader reader,
                                                   System.Type typeToConvert,
                                                   JsonSerializerOptions options) {
      var value = reader.GetString();
      return VideoMetadataContentLayer.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, VideoMetadataContentLayer value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
