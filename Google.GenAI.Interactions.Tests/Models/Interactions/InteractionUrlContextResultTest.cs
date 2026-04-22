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

public class InteractionUrlContextResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InteractionUrlContextResult
        {
            Status = InteractionUrlContextResultStatus.Success,
            Url = "url",
        };

        ApiEnum<string, InteractionUrlContextResultStatus> expectedStatus =
            InteractionUrlContextResultStatus.Success;
        string expectedUrl = "url";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InteractionUrlContextResult
        {
            Status = InteractionUrlContextResultStatus.Success,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionUrlContextResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InteractionUrlContextResult
        {
            Status = InteractionUrlContextResultStatus.Success,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionUrlContextResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InteractionUrlContextResultStatus> expectedStatus =
            InteractionUrlContextResultStatus.Success;
        string expectedUrl = "url";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InteractionUrlContextResult
        {
            Status = InteractionUrlContextResultStatus.Success,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InteractionUrlContextResult { };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InteractionUrlContextResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InteractionUrlContextResult
        {
            // Null should be interpreted as omitted for these properties
            Status = null,
            Url = null,
        };

        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InteractionUrlContextResult
        {
            // Null should be interpreted as omitted for these properties
            Status = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InteractionUrlContextResult
        {
            Status = InteractionUrlContextResultStatus.Success,
            Url = "url",
        };

        InteractionUrlContextResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InteractionUrlContextResultStatusTest : TestBase
{
    [Theory]
    [InlineData(InteractionUrlContextResultStatus.Success)]
    [InlineData(InteractionUrlContextResultStatus.Error)]
    [InlineData(InteractionUrlContextResultStatus.Paywall)]
    [InlineData(InteractionUrlContextResultStatus.Unsafe)]
    public void Validation_Works(InteractionUrlContextResultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionUrlContextResultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionUrlContextResultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InteractionUrlContextResultStatus.Success)]
    [InlineData(InteractionUrlContextResultStatus.Error)]
    [InlineData(InteractionUrlContextResultStatus.Paywall)]
    [InlineData(InteractionUrlContextResultStatus.Unsafe)]
    public void SerializationRoundtrip_Works(InteractionUrlContextResultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionUrlContextResultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InteractionUrlContextResultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionUrlContextResultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InteractionUrlContextResultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
