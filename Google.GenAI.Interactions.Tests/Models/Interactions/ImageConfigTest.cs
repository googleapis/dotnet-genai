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

using System.Text.Json;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class ImageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageConfig { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K };

        ApiEnum<string, AspectRatio> expectedAspectRatio = AspectRatio.V1_1;
        ApiEnum<string, ImageSize> expectedImageSize = ImageSize.V1K;

        Assert.Equal(expectedAspectRatio, model.AspectRatio);
        Assert.Equal(expectedImageSize, model.ImageSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageConfig { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageConfig { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AspectRatio> expectedAspectRatio = AspectRatio.V1_1;
        ApiEnum<string, ImageSize> expectedImageSize = ImageSize.V1K;

        Assert.Equal(expectedAspectRatio, deserialized.AspectRatio);
        Assert.Equal(expectedImageSize, deserialized.ImageSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageConfig { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageConfig { };

        Assert.Null(model.AspectRatio);
        Assert.False(model.RawData.ContainsKey("aspect_ratio"));
        Assert.Null(model.ImageSize);
        Assert.False(model.RawData.ContainsKey("image_size"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageConfig
        {
            // Null should be interpreted as omitted for these properties
            AspectRatio = null,
            ImageSize = null,
        };

        Assert.Null(model.AspectRatio);
        Assert.False(model.RawData.ContainsKey("aspect_ratio"));
        Assert.Null(model.ImageSize);
        Assert.False(model.RawData.ContainsKey("image_size"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageConfig
        {
            // Null should be interpreted as omitted for these properties
            AspectRatio = null,
            ImageSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageConfig { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K };

        ImageConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AspectRatioTest : TestBase
{
    [Theory]
    [InlineData(AspectRatio.V1_1)]
    [InlineData(AspectRatio.V2_3)]
    [InlineData(AspectRatio.V3_2)]
    [InlineData(AspectRatio.V3_4)]
    [InlineData(AspectRatio.V4_3)]
    [InlineData(AspectRatio.V4_5)]
    [InlineData(AspectRatio.V5_4)]
    [InlineData(AspectRatio.V9_16)]
    [InlineData(AspectRatio.V16_9)]
    [InlineData(AspectRatio.V21_9)]
    [InlineData(AspectRatio.V1_8)]
    [InlineData(AspectRatio.V8_1)]
    [InlineData(AspectRatio.V1_4)]
    [InlineData(AspectRatio.V4_1)]
    public void Validation_Works(AspectRatio rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AspectRatio> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AspectRatio>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AspectRatio.V1_1)]
    [InlineData(AspectRatio.V2_3)]
    [InlineData(AspectRatio.V3_2)]
    [InlineData(AspectRatio.V3_4)]
    [InlineData(AspectRatio.V4_3)]
    [InlineData(AspectRatio.V4_5)]
    [InlineData(AspectRatio.V5_4)]
    [InlineData(AspectRatio.V9_16)]
    [InlineData(AspectRatio.V16_9)]
    [InlineData(AspectRatio.V21_9)]
    [InlineData(AspectRatio.V1_8)]
    [InlineData(AspectRatio.V8_1)]
    [InlineData(AspectRatio.V1_4)]
    [InlineData(AspectRatio.V4_1)]
    public void SerializationRoundtrip_Works(AspectRatio rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AspectRatio> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AspectRatio>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AspectRatio>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AspectRatio>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ImageSizeTest : TestBase
{
    [Theory]
    [InlineData(ImageSize.V1K)]
    [InlineData(ImageSize.V2K)]
    [InlineData(ImageSize.V4K)]
    [InlineData(ImageSize.V512)]
    public void Validation_Works(ImageSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageSize> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ImageSize.V1K)]
    [InlineData(ImageSize.V2K)]
    [InlineData(ImageSize.V4K)]
    [InlineData(ImageSize.V512)]
    public void SerializationRoundtrip_Works(ImageSize rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageSize> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageSize>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageSize>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
