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

public class ModelTest : TestBase
{
    [Theory]
    [InlineData(Model.Gemini2_5ComputerUsePreview10_2025)]
    [InlineData(Model.Gemini2_5Flash)]
    [InlineData(Model.Gemini2_5FlashImage)]
    [InlineData(Model.Gemini2_5FlashLite)]
    [InlineData(Model.Gemini2_5FlashLitePreview09_2025)]
    [InlineData(Model.Gemini2_5FlashNativeAudioPreview12_2025)]
    [InlineData(Model.Gemini2_5FlashPreview09_2025)]
    [InlineData(Model.Gemini2_5FlashPreviewTts)]
    [InlineData(Model.Gemini2_5Pro)]
    [InlineData(Model.Gemini2_5ProPreviewTts)]
    [InlineData(Model.Gemini3FlashPreview)]
    [InlineData(Model.Gemini3ProImagePreview)]
    [InlineData(Model.Gemini3ProPreview)]
    [InlineData(Model.Gemini3_1ProPreview)]
    [InlineData(Model.Gemini3_1FlashImagePreview)]
    [InlineData(Model.Gemini3_1FlashLitePreview)]
    [InlineData(Model.Lyria3ClipPreview)]
    [InlineData(Model.Lyria3ProPreview)]
    public void Validation_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Model.Gemini2_5ComputerUsePreview10_2025)]
    [InlineData(Model.Gemini2_5Flash)]
    [InlineData(Model.Gemini2_5FlashImage)]
    [InlineData(Model.Gemini2_5FlashLite)]
    [InlineData(Model.Gemini2_5FlashLitePreview09_2025)]
    [InlineData(Model.Gemini2_5FlashNativeAudioPreview12_2025)]
    [InlineData(Model.Gemini2_5FlashPreview09_2025)]
    [InlineData(Model.Gemini2_5FlashPreviewTts)]
    [InlineData(Model.Gemini2_5Pro)]
    [InlineData(Model.Gemini2_5ProPreviewTts)]
    [InlineData(Model.Gemini3FlashPreview)]
    [InlineData(Model.Gemini3ProImagePreview)]
    [InlineData(Model.Gemini3ProPreview)]
    [InlineData(Model.Gemini3_1ProPreview)]
    [InlineData(Model.Gemini3_1FlashImagePreview)]
    [InlineData(Model.Gemini3_1FlashLitePreview)]
    [InlineData(Model.Lyria3ClipPreview)]
    [InlineData(Model.Lyria3ProPreview)]
    public void SerializationRoundtrip_Works(Model rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Model> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Model>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
