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

public class AudioContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudioContent
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("audio");
        int expectedChannels = 0;
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, MimeType> expectedMimeType = MimeType.AudioWav;
        int expectedRate = 0;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedChannels, model.Channels);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedRate, model.Rate);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudioContent
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudioContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudioContent
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AudioContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("audio");
        int expectedChannels = 0;
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, MimeType> expectedMimeType = MimeType.AudioWav;
        int expectedRate = 0;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedChannels, deserialized.Channels);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedRate, deserialized.Rate);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudioContent
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AudioContent { };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AudioContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AudioContent
        {
            // Null should be interpreted as omitted for these properties
            Channels = null,
            Data = null,
            MimeType = null,
            Rate = null,
            Uri = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AudioContent
        {
            // Null should be interpreted as omitted for these properties
            Channels = null,
            Data = null,
            MimeType = null,
            Rate = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AudioContent
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        AudioContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MimeTypeTest : TestBase
{
    [Theory]
    [InlineData(MimeType.AudioWav)]
    [InlineData(MimeType.AudioMp3)]
    [InlineData(MimeType.AudioAiff)]
    [InlineData(MimeType.AudioAac)]
    [InlineData(MimeType.AudioOgg)]
    [InlineData(MimeType.AudioFlac)]
    [InlineData(MimeType.AudioMpeg)]
    [InlineData(MimeType.AudioM4a)]
    [InlineData(MimeType.AudioL16)]
    public void Validation_Works(MimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MimeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MimeType.AudioWav)]
    [InlineData(MimeType.AudioMp3)]
    [InlineData(MimeType.AudioAiff)]
    [InlineData(MimeType.AudioAac)]
    [InlineData(MimeType.AudioOgg)]
    [InlineData(MimeType.AudioFlac)]
    [InlineData(MimeType.AudioMpeg)]
    [InlineData(MimeType.AudioM4a)]
    [InlineData(MimeType.AudioL16)]
    public void SerializationRoundtrip_Works(MimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MimeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
