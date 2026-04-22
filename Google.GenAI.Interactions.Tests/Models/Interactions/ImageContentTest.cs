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

public class ImageContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageContent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, ImageContentMimeType> expectedMimeType = ImageContentMimeType.ImagePng;
        ApiEnum<string, ImageContentResolution> expectedResolution = ImageContentResolution.Low;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedResolution, model.Resolution);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageContent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageContent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, ImageContentMimeType> expectedMimeType = ImageContentMimeType.ImagePng;
        ApiEnum<string, ImageContentResolution> expectedResolution = ImageContentResolution.Low;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedResolution, deserialized.Resolution);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageContent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageContent { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Resolution);
        Assert.False(model.RawData.ContainsKey("resolution"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageContent
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Resolution = null,
            Uri = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Resolution);
        Assert.False(model.RawData.ContainsKey("resolution"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageContent
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Resolution = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageContent
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };

        ImageContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageContentMimeTypeTest : TestBase
{
    [Theory]
    [InlineData(ImageContentMimeType.ImagePng)]
    [InlineData(ImageContentMimeType.ImageJpeg)]
    [InlineData(ImageContentMimeType.ImageWebp)]
    [InlineData(ImageContentMimeType.ImageHeic)]
    [InlineData(ImageContentMimeType.ImageHeif)]
    [InlineData(ImageContentMimeType.ImageGif)]
    [InlineData(ImageContentMimeType.ImageBmp)]
    [InlineData(ImageContentMimeType.ImageTiff)]
    public void Validation_Works(ImageContentMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageContentMimeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageContentMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ImageContentMimeType.ImagePng)]
    [InlineData(ImageContentMimeType.ImageJpeg)]
    [InlineData(ImageContentMimeType.ImageWebp)]
    [InlineData(ImageContentMimeType.ImageHeic)]
    [InlineData(ImageContentMimeType.ImageHeif)]
    [InlineData(ImageContentMimeType.ImageGif)]
    [InlineData(ImageContentMimeType.ImageBmp)]
    [InlineData(ImageContentMimeType.ImageTiff)]
    public void SerializationRoundtrip_Works(ImageContentMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageContentMimeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageContentMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageContentMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageContentMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ImageContentResolutionTest : TestBase
{
    [Theory]
    [InlineData(ImageContentResolution.Low)]
    [InlineData(ImageContentResolution.Medium)]
    [InlineData(ImageContentResolution.High)]
    [InlineData(ImageContentResolution.UltraHigh)]
    public void Validation_Works(ImageContentResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageContentResolution> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageContentResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ImageContentResolution.Low)]
    [InlineData(ImageContentResolution.Medium)]
    [InlineData(ImageContentResolution.High)]
    [InlineData(ImageContentResolution.UltraHigh)]
    public void SerializationRoundtrip_Works(ImageContentResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageContentResolution> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageContentResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageContentResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageContentResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
