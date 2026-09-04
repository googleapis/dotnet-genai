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
  /// How the model processes this part's media for understanding. Only meaningful for video parts
  /// (`inline_data` or `file_data` with video mime). Non-video parts ignore this field.
  /// </summary>

  [JsonConverter(typeof(MediaProcessingConverter))]
  public readonly record struct MediaProcessing : IEquatable<MediaProcessing> {
    public string Value { get; }

    private MediaProcessing(string value) {
      Value = value;
    }

    /// <summary>
    /// Default. Uses model-specific processing (3.5 Pro+ -> `AGENTIC`, older models -> `STATIC`).
    /// </summary>
    public static MediaProcessing MediaProcessingUnspecified {
      get;
    } = new("MEDIA_PROCESSING_UNSPECIFIED");

    /// <summary>
    /// Fixed-rate frame extraction. All frames placed in context.
    /// </summary>
    public static MediaProcessing Static { get; } = new("STATIC");

    /// <summary>
    /// Model-driven dynamic navigation. Recommended for most use cases.
    /// </summary>
    public static MediaProcessing Agentic { get; } = new("AGENTIC");

    public static IReadOnlyList<MediaProcessing> AllValues {
      get;
    } = new[] { MediaProcessingUnspecified, Static, Agentic };

    public static MediaProcessing FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new MediaProcessing("MEDIA_PROCESSING_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new MediaProcessing(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator MediaProcessing(string value) => FromString(value);

    public bool Equals(MediaProcessing other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class MediaProcessingConverter : JsonConverter<MediaProcessing> {
    public override MediaProcessing Read(ref Utf8JsonReader reader, System.Type typeToConvert,
                                         JsonSerializerOptions options) {
      var value = reader.GetString();
      return MediaProcessing.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, MediaProcessing value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
