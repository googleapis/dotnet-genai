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
/// An image content block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImageContent, ImageContentFromRaw>))]
public sealed record class ImageContent : JsonModel
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
    /// The image content.
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
    /// The mime type of the image.
    /// </summary>
    public ApiEnum<string, ImageContentMimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ImageContentMimeType>>(
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
    public ApiEnum<string, ImageContentResolution>? Resolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ImageContentResolution>>(
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
    /// The URI of the image.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("image")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Data;
        this.MimeType?.Validate();
        this.Resolution?.Validate();
        _ = this.Uri;
    }

    public ImageContent()
    {
        this.Type = JsonSerializer.SerializeToElement("image");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageContent(ImageContent imageContent)
        : base(imageContent) { }
#pragma warning restore CS8618

    public ImageContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("image");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageContentFromRaw.FromRawUnchecked"/>
    public static ImageContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageContentFromRaw : IFromRawJson<ImageContent>
{
    /// <inheritdoc/>
    public ImageContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageContent.FromRawUnchecked(rawData);
}

/// <summary>
/// The mime type of the image.
/// </summary>
[JsonConverter(typeof(ImageContentMimeTypeConverter))]
public enum ImageContentMimeType
{
    ImagePng,
    ImageJpeg,
    ImageWebp,
    ImageHeic,
    ImageHeif,
    ImageGif,
    ImageBmp,
    ImageTiff,
}

sealed class ImageContentMimeTypeConverter : JsonConverter<ImageContentMimeType>
{
    public override ImageContentMimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image/png" => ImageContentMimeType.ImagePng,
            "image/jpeg" => ImageContentMimeType.ImageJpeg,
            "image/webp" => ImageContentMimeType.ImageWebp,
            "image/heic" => ImageContentMimeType.ImageHeic,
            "image/heif" => ImageContentMimeType.ImageHeif,
            "image/gif" => ImageContentMimeType.ImageGif,
            "image/bmp" => ImageContentMimeType.ImageBmp,
            "image/tiff" => ImageContentMimeType.ImageTiff,
            _ => (ImageContentMimeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageContentMimeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImageContentMimeType.ImagePng => "image/png",
                ImageContentMimeType.ImageJpeg => "image/jpeg",
                ImageContentMimeType.ImageWebp => "image/webp",
                ImageContentMimeType.ImageHeic => "image/heic",
                ImageContentMimeType.ImageHeif => "image/heif",
                ImageContentMimeType.ImageGif => "image/gif",
                ImageContentMimeType.ImageBmp => "image/bmp",
                ImageContentMimeType.ImageTiff => "image/tiff",
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
[JsonConverter(typeof(ImageContentResolutionConverter))]
public enum ImageContentResolution
{
    Low,
    Medium,
    High,
    UltraHigh,
}

sealed class ImageContentResolutionConverter : JsonConverter<ImageContentResolution>
{
    public override ImageContentResolution Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => ImageContentResolution.Low,
            "medium" => ImageContentResolution.Medium,
            "high" => ImageContentResolution.High,
            "ultra_high" => ImageContentResolution.UltraHigh,
            _ => (ImageContentResolution)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageContentResolution value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImageContentResolution.Low => "low",
                ImageContentResolution.Medium => "medium",
                ImageContentResolution.High => "high",
                ImageContentResolution.UltraHigh => "ultra_high",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
