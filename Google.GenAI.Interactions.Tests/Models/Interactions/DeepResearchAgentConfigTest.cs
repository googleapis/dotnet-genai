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

public class DeepResearchAgentConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeepResearchAgentConfig { ThinkingSummaries = ThinkingSummaries.Auto };

        JsonElement expectedType = JsonSerializer.SerializeToElement("deep-research");
        ApiEnum<string, ThinkingSummaries> expectedThinkingSummaries = ThinkingSummaries.Auto;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedThinkingSummaries, model.ThinkingSummaries);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeepResearchAgentConfig { ThinkingSummaries = ThinkingSummaries.Auto };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeepResearchAgentConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeepResearchAgentConfig { ThinkingSummaries = ThinkingSummaries.Auto };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeepResearchAgentConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("deep-research");
        ApiEnum<string, ThinkingSummaries> expectedThinkingSummaries = ThinkingSummaries.Auto;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedThinkingSummaries, deserialized.ThinkingSummaries);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeepResearchAgentConfig { ThinkingSummaries = ThinkingSummaries.Auto };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeepResearchAgentConfig { };

        Assert.Null(model.ThinkingSummaries);
        Assert.False(model.RawData.ContainsKey("thinking_summaries"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeepResearchAgentConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DeepResearchAgentConfig
        {
            // Null should be interpreted as omitted for these properties
            ThinkingSummaries = null,
        };

        Assert.Null(model.ThinkingSummaries);
        Assert.False(model.RawData.ContainsKey("thinking_summaries"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeepResearchAgentConfig
        {
            // Null should be interpreted as omitted for these properties
            ThinkingSummaries = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeepResearchAgentConfig { ThinkingSummaries = ThinkingSummaries.Auto };

        DeepResearchAgentConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThinkingSummariesTest : TestBase
{
    [Theory]
    [InlineData(ThinkingSummaries.Auto)]
    [InlineData(ThinkingSummaries.None)]
    public void Validation_Works(ThinkingSummaries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingSummaries> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingSummaries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThinkingSummaries.Auto)]
    [InlineData(ThinkingSummaries.None)]
    public void SerializationRoundtrip_Works(ThinkingSummaries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThinkingSummaries> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingSummaries>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThinkingSummaries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThinkingSummaries>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
