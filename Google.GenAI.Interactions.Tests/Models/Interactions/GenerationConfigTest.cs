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

using System.Collections.Generic;
using System.Text.Json;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class GenerationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GenerationConfig
        {
            ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
            MaxOutputTokens = 0,
            Seed = 0,
            SpeechConfig = new List<SpeechConfig>()
            {
                new SpeechConfig()
                {
                    Language = "language",
                    Speaker = "speaker",
                    Voice = "voice",
                },
            },
            StopSequences = new List<string>() { "string" },
            Temperature = 0,
            ThinkingLevel = ThinkingLevel.Minimal,
            ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
            ToolChoice = ToolChoiceType.Auto,
            TopP = 0,
        };

        ImageConfig expectedImageConfig = new()
        {
            AspectRatio = AspectRatio.V1_1,
            ImageSize = ImageSize.V1K,
        };
        int expectedMaxOutputTokens = 0;
        int expectedSeed = 0;
        List<SpeechConfig> expectedSpeechConfig = new List<SpeechConfig>()
        {
            new SpeechConfig()
            {
                Language = "language",
                Speaker = "speaker",
                Voice = "voice",
            },
        };
        List<string> expectedStopSequences = new List<string>() { "string" };
        float expectedTemperature = 0;
        ApiEnum<string, ThinkingLevel> expectedThinkingLevel = ThinkingLevel.Minimal;
        ApiEnum<string, GenerationConfigThinkingSummaries> expectedThinkingSummaries =
            GenerationConfigThinkingSummaries.Auto;
        ToolChoice expectedToolChoice = ToolChoiceType.Auto;
        float expectedTopP = 0;

        Assert.Equal(expectedImageConfig, model.ImageConfig);
        Assert.Equal(expectedMaxOutputTokens, model.MaxOutputTokens);
        Assert.Equal(expectedSeed, model.Seed);
        Assert.NotNull(model.SpeechConfig);
        Assert.Equal(expectedSpeechConfig.Count, model.SpeechConfig.Count);
        for (int i = 0; i < expectedSpeechConfig.Count; i++)
        {
            Assert.Equal(expectedSpeechConfig[i], model.SpeechConfig[i]);
        }
        Assert.NotNull(model.StopSequences);
        Assert.Equal(expectedStopSequences.Count, model.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], model.StopSequences[i]);
        }
        Assert.Equal(expectedTemperature, model.Temperature);
        Assert.Equal(expectedThinkingLevel, model.ThinkingLevel);
        Assert.Equal(expectedThinkingSummaries, model.ThinkingSummaries);
        Assert.Equal(expectedToolChoice, model.ToolChoice);
        Assert.Equal(expectedTopP, model.TopP);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GenerationConfig
        {
            ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
            MaxOutputTokens = 0,
            Seed = 0,
            SpeechConfig = new List<SpeechConfig>()
            {
                new SpeechConfig()
                {
                    Language = "language",
                    Speaker = "speaker",
                    Voice = "voice",
                },
            },
            StopSequences = new List<string>() { "string" },
            Temperature = 0,
            ThinkingLevel = ThinkingLevel.Minimal,
            ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
            ToolChoice = ToolChoiceType.Auto,
            TopP = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GenerationConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GenerationConfig
        {
            ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
            MaxOutputTokens = 0,
            Seed = 0,
            SpeechConfig = new List<SpeechConfig>()
            {
                new SpeechConfig()
                {
                    Language = "language",
                    Speaker = "speaker",
                    Voice = "voice",
                },
            },
            StopSequences = new List<string>() { "string" },
            Temperature = 0,
            ThinkingLevel = ThinkingLevel.Minimal,
            ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
            ToolChoice = ToolChoiceType.Auto,
            TopP = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GenerationConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ImageConfig expectedImageConfig = new()
        {
            AspectRatio = AspectRatio.V1_1,
            ImageSize = ImageSize.V1K,
        };
        int expectedMaxOutputTokens = 0;
        int expectedSeed = 0;
        List<SpeechConfig> expectedSpeechConfig = new List<SpeechConfig>()
        {
            new SpeechConfig()
            {
                Language = "language",
                Speaker = "speaker",
                Voice = "voice",
            },
        };
        List<string> expectedStopSequences = new List<string>() { "string" };
        float expectedTemperature = 0;
        ApiEnum<string, ThinkingLevel> expectedThinkingLevel = ThinkingLevel.Minimal;
        ApiEnum<string, GenerationConfigThinkingSummaries> expectedThinkingSummaries =
            GenerationConfigThinkingSummaries.Auto;
        ToolChoice expectedToolChoice = ToolChoiceType.Auto;
        float expectedTopP = 0;

        Assert.Equal(expectedImageConfig, deserialized.ImageConfig);
        Assert.Equal(expectedMaxOutputTokens, deserialized.MaxOutputTokens);
        Assert.Equal(expectedSeed, deserialized.Seed);
        Assert.NotNull(deserialized.SpeechConfig);
        Assert.Equal(expectedSpeechConfig.Count, deserialized.SpeechConfig.Count);
        for (int i = 0; i < expectedSpeechConfig.Count; i++)
        {
            Assert.Equal(expectedSpeechConfig[i], deserialized.SpeechConfig[i]);
        }
        Assert.NotNull(deserialized.StopSequences);
        Assert.Equal(expectedStopSequences.Count, deserialized.StopSequences.Count);
        for (int i = 0; i < expectedStopSequences.Count; i++)
        {
            Assert.Equal(expectedStopSequences[i], deserialized.StopSequences[i]);
        }
        Assert.Equal(expectedTemperature, deserialized.Temperature);
        Assert.Equal(expectedThinkingLevel, deserialized.ThinkingLevel);
        Assert.Equal(expectedThinkingSummaries, deserialized.ThinkingSummaries);
        Assert.Equal(expectedToolChoice, deserialized.ToolChoice);
        Assert.Equal(expectedTopP, deserialized.TopP);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GenerationConfig
        {
            ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
            MaxOutputTokens = 0,
            Seed = 0,
            SpeechConfig = new List<SpeechConfig>()
            {
                new SpeechConfig()
                {
                    Language = "language",
                    Speaker = "speaker",
                    Voice = "voice",
                },
            },
            StopSequences = new List<string>() { "string" },
            Temperature = 0,
            ThinkingLevel = ThinkingLevel.Minimal,
            ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
            ToolChoice = ToolChoiceType.Auto,
            TopP = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GenerationConfig { };

        Assert.Null(model.ImageConfig);
        Assert.False(model.RawData.ContainsKey("image_config"));
        Assert.Null(model.MaxOutputTokens);
        Assert.False(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.Seed);
        Assert.False(model.RawData.ContainsKey("seed"));
        Assert.Null(model.SpeechConfig);
        Assert.False(model.RawData.ContainsKey("speech_config"));
        Assert.Null(model.StopSequences);
        Assert.False(model.RawData.ContainsKey("stop_sequences"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.ThinkingLevel);
        Assert.False(model.RawData.ContainsKey("thinking_level"));
        Assert.Null(model.ThinkingSummaries);
        Assert.False(model.RawData.ContainsKey("thinking_summaries"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GenerationConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GenerationConfig
        {
            // Null should be interpreted as omitted for these properties
            ImageConfig = null,
            MaxOutputTokens = null,
            Seed = null,
            SpeechConfig = null,
            StopSequences = null,
            Temperature = null,
            ThinkingLevel = null,
            ThinkingSummaries = null,
            ToolChoice = null,
            TopP = null,
        };

        Assert.Null(model.ImageConfig);
        Assert.False(model.RawData.ContainsKey("image_config"));
        Assert.Null(model.MaxOutputTokens);
        Assert.False(model.RawData.ContainsKey("max_output_tokens"));
        Assert.Null(model.Seed);
        Assert.False(model.RawData.ContainsKey("seed"));
        Assert.Null(model.SpeechConfig);
        Assert.False(model.RawData.ContainsKey("speech_config"));
        Assert.Null(model.StopSequences);
        Assert.False(model.RawData.ContainsKey("stop_sequences"));
        Assert.Null(model.Temperature);
        Assert.False(model.RawData.ContainsKey("temperature"));
        Assert.Null(model.ThinkingLevel);
        Assert.False(model.RawData.ContainsKey("thinking_level"));
        Assert.Null(model.ThinkingSummaries);
        Assert.False(model.RawData.ContainsKey("thinking_summaries"));
        Assert.Null(model.ToolChoice);
        Assert.False(model.RawData.ContainsKey("tool_choice"));
        Assert.Null(model.TopP);
        Assert.False(model.RawData.ContainsKey("top_p"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GenerationConfig
        {
            // Null should be interpreted as omitted for these properties
            ImageConfig = null,
            MaxOutputTokens = null,
            Seed = null,
            SpeechConfig = null,
            StopSequences = null,
            Temperature = null,
            ThinkingLevel = null,
            ThinkingSummaries = null,
            ToolChoice = null,
            TopP = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GenerationConfig
        {
            ImageConfig = new() { AspectRatio = AspectRatio.V1_1, ImageSize = ImageSize.V1K },
            MaxOutputTokens = 0,
            Seed = 0,
            SpeechConfig = new List<SpeechConfig>()
            {
                new SpeechConfig()
                {
                    Language = "language",
                    Speaker = "speaker",
                    Voice = "voice",
                },
            },
            StopSequences = new List<string>() { "string" },
            Temperature = 0,
            ThinkingLevel = ThinkingLevel.Minimal,
            ThinkingSummaries = GenerationConfigThinkingSummaries.Auto,
            ToolChoice = ToolChoiceType.Auto,
            TopP = 0,
        };

        GenerationConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GenerationConfigThinkingSummariesTest : TestBase
{
    [Theory]
    [InlineData(GenerationConfigThinkingSummaries.Auto)]
    [InlineData(GenerationConfigThinkingSummaries.None)]
    public void Validation_Works(GenerationConfigThinkingSummaries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GenerationConfigThinkingSummaries> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GenerationConfigThinkingSummaries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GenerationConfigThinkingSummaries.Auto)]
    [InlineData(GenerationConfigThinkingSummaries.None)]
    public void SerializationRoundtrip_Works(GenerationConfigThinkingSummaries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GenerationConfigThinkingSummaries> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GenerationConfigThinkingSummaries>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GenerationConfigThinkingSummaries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GenerationConfigThinkingSummaries>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ToolChoiceTest : TestBase
{
    [Fact]
    public void TypeValidationWorks()
    {
        ToolChoice value = ToolChoiceType.Auto;
        value.Validate();
    }

    [Fact]
    public void ConfigValidationWorks()
    {
        ToolChoice value = new ToolChoiceConfig()
        {
            AllowedTools = new()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };
        value.Validate();
    }

    [Fact]
    public void TypeSerializationRoundtripWorks()
    {
        ToolChoice value = ToolChoiceType.Auto;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ConfigSerializationRoundtripWorks()
    {
        ToolChoice value = new ToolChoiceConfig()
        {
            AllowedTools = new()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoice>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
