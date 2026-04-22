// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// An audio content block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AudioContent, AudioContentFromRaw>))]
public sealed record class AudioContent : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The number of audio channels.
    /// </summary>
    public int? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    /// <summary>
    /// The audio content.
    /// </summary>
    public string? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <summary>
    /// The mime type of the audio.
    /// </summary>
    public ApiEnum<string, MimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MimeType>>("mime_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    /// <summary>
    /// The sample rate of the audio.
    /// </summary>
    public int? Rate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    /// <summary>
    /// The URI of the audio.
    /// </summary>
    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("audio")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Channels;
        _ = this.Data;
        this.MimeType?.Validate();
        _ = this.Rate;
        _ = this.Uri;
    }

    public AudioContent()
    {
        this.Type = JsonSerializer.SerializeToElement("audio");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudioContent(AudioContent audioContent)
        : base(audioContent) { }
#pragma warning restore CS8618

    public AudioContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("audio");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudioContentFromRaw.FromRawUnchecked"/>
    public static AudioContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudioContentFromRaw : IFromRawJson<AudioContent>
{
    /// <inheritdoc/>
    public AudioContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AudioContent.FromRawUnchecked(rawData);
}

/// <summary>
/// The mime type of the audio.
/// </summary>
[JsonConverter(typeof(MimeTypeConverter))]
public enum MimeType
{
    AudioWav,
    AudioMp3,
    AudioAiff,
    AudioAac,
    AudioOgg,
    AudioFlac,
    AudioMpeg,
    AudioM4a,
    AudioL16,
    AudioOpus,
    AudioAlaw,
    AudioMulaw,
}

sealed class MimeTypeConverter : JsonConverter<MimeType>
{
    public override MimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "audio/wav" => MimeType.AudioWav,
            "audio/mp3" => MimeType.AudioMp3,
            "audio/aiff" => MimeType.AudioAiff,
            "audio/aac" => MimeType.AudioAac,
            "audio/ogg" => MimeType.AudioOgg,
            "audio/flac" => MimeType.AudioFlac,
            "audio/mpeg" => MimeType.AudioMpeg,
            "audio/m4a" => MimeType.AudioM4a,
            "audio/l16" => MimeType.AudioL16,
            "audio/opus" => MimeType.AudioOpus,
            "audio/alaw" => MimeType.AudioAlaw,
            "audio/mulaw" => MimeType.AudioMulaw,
            _ => (MimeType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, MimeType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MimeType.AudioWav => "audio/wav",
                MimeType.AudioMp3 => "audio/mp3",
                MimeType.AudioAiff => "audio/aiff",
                MimeType.AudioAac => "audio/aac",
                MimeType.AudioOgg => "audio/ogg",
                MimeType.AudioFlac => "audio/flac",
                MimeType.AudioMpeg => "audio/mpeg",
                MimeType.AudioM4a => "audio/m4a",
                MimeType.AudioL16 => "audio/l16",
                MimeType.AudioOpus => "audio/opus",
                MimeType.AudioAlaw => "audio/alaw",
                MimeType.AudioMulaw => "audio/mulaw",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
