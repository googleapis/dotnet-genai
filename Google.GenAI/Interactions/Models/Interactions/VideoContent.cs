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
/// A video content block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VideoContent, VideoContentFromRaw>))]
public sealed record class VideoContent : JsonModel
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
    /// The video content.
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
    /// The mime type of the video.
    /// </summary>
    public ApiEnum<string, VideoContentMimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VideoContentMimeType>>(
                "mime_type"
            );
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
    /// The resolution of the media.
    /// </summary>
    public ApiEnum<string, VideoContentResolution>? Resolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VideoContentResolution>>(
                "resolution"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resolution", value);
        }
    }

    /// <summary>
    /// The URI of the video.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("video")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Data;
        this.MimeType?.Validate();
        this.Resolution?.Validate();
        _ = this.Uri;
    }

    public VideoContent()
    {
        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoContent(VideoContent videoContent)
        : base(videoContent) { }
#pragma warning restore CS8618

    public VideoContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoContentFromRaw.FromRawUnchecked"/>
    public static VideoContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoContentFromRaw : IFromRawJson<VideoContent>
{
    /// <inheritdoc/>
    public VideoContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VideoContent.FromRawUnchecked(rawData);
}

/// <summary>
/// The mime type of the video.
/// </summary>
[JsonConverter(typeof(VideoContentMimeTypeConverter))]
public enum VideoContentMimeType
{
    VideoMp4,
    VideoMpeg,
    VideoMpg,
    VideoMov,
    VideoAvi,
    VideoXFlv,
    VideoWebm,
    VideoWmv,
    Video3gpp,
}

sealed class VideoContentMimeTypeConverter : JsonConverter<VideoContentMimeType>
{
    public override VideoContentMimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video/mp4" => VideoContentMimeType.VideoMp4,
            "video/mpeg" => VideoContentMimeType.VideoMpeg,
            "video/mpg" => VideoContentMimeType.VideoMpg,
            "video/mov" => VideoContentMimeType.VideoMov,
            "video/avi" => VideoContentMimeType.VideoAvi,
            "video/x-flv" => VideoContentMimeType.VideoXFlv,
            "video/webm" => VideoContentMimeType.VideoWebm,
            "video/wmv" => VideoContentMimeType.VideoWmv,
            "video/3gpp" => VideoContentMimeType.Video3gpp,
            _ => (VideoContentMimeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoContentMimeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoContentMimeType.VideoMp4 => "video/mp4",
                VideoContentMimeType.VideoMpeg => "video/mpeg",
                VideoContentMimeType.VideoMpg => "video/mpg",
                VideoContentMimeType.VideoMov => "video/mov",
                VideoContentMimeType.VideoAvi => "video/avi",
                VideoContentMimeType.VideoXFlv => "video/x-flv",
                VideoContentMimeType.VideoWebm => "video/webm",
                VideoContentMimeType.VideoWmv => "video/wmv",
                VideoContentMimeType.Video3gpp => "video/3gpp",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The resolution of the media.
/// </summary>
[JsonConverter(typeof(VideoContentResolutionConverter))]
public enum VideoContentResolution
{
    Low,
    Medium,
    High,
    UltraHigh,
}

sealed class VideoContentResolutionConverter : JsonConverter<VideoContentResolution>
{
    public override VideoContentResolution Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => VideoContentResolution.Low,
            "medium" => VideoContentResolution.Medium,
            "high" => VideoContentResolution.High,
            "ultra_high" => VideoContentResolution.UltraHigh,
            _ => (VideoContentResolution)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoContentResolution value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoContentResolution.Low => "low",
                VideoContentResolution.Medium => "medium",
                VideoContentResolution.High => "high",
                VideoContentResolution.UltraHigh => "ultra_high",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
