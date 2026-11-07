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
  /// Configures transcription mode. Supported values: `VERBATIM`, `SMART`. If unspecified, defaults
  /// to `VERBATIM` transcription. In `SMART` mode, the model performs disfluency removal
  /// (eliminating filler words, repetitions, and false starts), light grammatical cleanup,
  /// automatic formatting (paragraphs, bullet points, numbered lists), and minor user edits (inline
  /// self-corrections). Timestamps and diarization are incompatible with mode `SMART`.
  /// </summary>

  [JsonConverter(typeof(AudioTranscriptionConfigModeConverter))]
  public readonly record struct AudioTranscriptionConfigMode
      : IEquatable<AudioTranscriptionConfigMode> {
    public string Value { get; }

    private AudioTranscriptionConfigMode(string value) {
      Value = value;
    }

    /// <summary>
    /// Unspecified transcription mode.
    /// </summary>
    public static AudioTranscriptionConfigMode ModeUnspecified { get; } = new("MODE_UNSPECIFIED");

    /// <summary>
    /// Verbatim transcription mode.
    /// </summary>
    public static AudioTranscriptionConfigMode Verbatim { get; } = new("VERBATIM");

    /// <summary>
    /// Smart transcription mode.
    /// </summary>
    public static AudioTranscriptionConfigMode Smart { get; } = new("SMART");

    public static IReadOnlyList<AudioTranscriptionConfigMode> AllValues {
      get;
    } = new[] { ModeUnspecified, Verbatim, Smart };

    public static AudioTranscriptionConfigMode FromString(string value) {
      if (string.IsNullOrEmpty(value)) {
        return new AudioTranscriptionConfigMode("MODE_UNSPECIFIED");
      }

      foreach (var known in AllValues) {
        if (known.Value == value) {
          return known;
        }
      }

      return new AudioTranscriptionConfigMode(value);
    }

    public override string ToString() => Value ?? string.Empty;

    public static implicit operator AudioTranscriptionConfigMode(string value) => FromString(value);

    public bool Equals(AudioTranscriptionConfigMode other) => Value == other.Value;

    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
  }

  public class AudioTranscriptionConfigModeConverter : JsonConverter<AudioTranscriptionConfigMode> {
    public override AudioTranscriptionConfigMode Read(ref Utf8JsonReader reader,
                                                      System.Type typeToConvert,
                                                      JsonSerializerOptions options) {
      var value = reader.GetString();
      return AudioTranscriptionConfigMode.FromString(value);
    }

    public override void Write(Utf8JsonWriter writer, AudioTranscriptionConfigMode value,
                               JsonSerializerOptions options) {
      writer.WriteStringValue(value.Value);
    }
  }
}
