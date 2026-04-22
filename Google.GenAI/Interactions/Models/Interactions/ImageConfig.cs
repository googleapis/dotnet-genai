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
/// The configuration for image interaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImageConfig, ImageConfigFromRaw>))]
public sealed record class ImageConfig : JsonModel
{
    public ApiEnum<string, AspectRatio>? AspectRatio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AspectRatio>>("aspect_ratio");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aspect_ratio", value);
        }
    }

    public ApiEnum<string, ImageSize>? ImageSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ImageSize>>("image_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("image_size", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AspectRatio?.Validate();
        this.ImageSize?.Validate();
    }

    public ImageConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageConfig(ImageConfig imageConfig)
        : base(imageConfig) { }
#pragma warning restore CS8618

    public ImageConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageConfigFromRaw.FromRawUnchecked"/>
    public static ImageConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageConfigFromRaw : IFromRawJson<ImageConfig>
{
    /// <inheritdoc/>
    public ImageConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AspectRatioConverter))]
public enum AspectRatio
{
    V1_1,
    V2_3,
    V3_2,
    V3_4,
    V4_3,
    V4_5,
    V5_4,
    V9_16,
    V16_9,
    V21_9,
    V1_8,
    V8_1,
    V1_4,
    V4_1,
}

sealed class AspectRatioConverter : JsonConverter<AspectRatio>
{
    public override AspectRatio Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1:1" => AspectRatio.V1_1,
            "2:3" => AspectRatio.V2_3,
            "3:2" => AspectRatio.V3_2,
            "3:4" => AspectRatio.V3_4,
            "4:3" => AspectRatio.V4_3,
            "4:5" => AspectRatio.V4_5,
            "5:4" => AspectRatio.V5_4,
            "9:16" => AspectRatio.V9_16,
            "16:9" => AspectRatio.V16_9,
            "21:9" => AspectRatio.V21_9,
            "1:8" => AspectRatio.V1_8,
            "8:1" => AspectRatio.V8_1,
            "1:4" => AspectRatio.V1_4,
            "4:1" => AspectRatio.V4_1,
            _ => (AspectRatio)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AspectRatio value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AspectRatio.V1_1 => "1:1",
                AspectRatio.V2_3 => "2:3",
                AspectRatio.V3_2 => "3:2",
                AspectRatio.V3_4 => "3:4",
                AspectRatio.V4_3 => "4:3",
                AspectRatio.V4_5 => "4:5",
                AspectRatio.V5_4 => "5:4",
                AspectRatio.V9_16 => "9:16",
                AspectRatio.V16_9 => "16:9",
                AspectRatio.V21_9 => "21:9",
                AspectRatio.V1_8 => "1:8",
                AspectRatio.V8_1 => "8:1",
                AspectRatio.V1_4 => "1:4",
                AspectRatio.V4_1 => "4:1",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ImageSizeConverter))]
public enum ImageSize
{
    V1K,
    V2K,
    V4K,
    V512,
}

sealed class ImageSizeConverter : JsonConverter<ImageSize>
{
    public override ImageSize Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1K" => ImageSize.V1K,
            "2K" => ImageSize.V2K,
            "4K" => ImageSize.V4K,
            "512" => ImageSize.V512,
            _ => (ImageSize)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageSize value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImageSize.V1K => "1K",
                ImageSize.V2K => "2K",
                ImageSize.V4K => "4K",
                ImageSize.V512 => "512",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
