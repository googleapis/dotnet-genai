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

public class CodeExecutionCallArgumentsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CodeExecutionCallArguments { Code = "code", Language = Language.Python };

        string expectedCode = "code";
        ApiEnum<string, Language> expectedLanguage = Language.Python;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedLanguage, model.Language);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CodeExecutionCallArguments { Code = "code", Language = Language.Python };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionCallArguments>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CodeExecutionCallArguments { Code = "code", Language = Language.Python };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionCallArguments>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        ApiEnum<string, Language> expectedLanguage = Language.Python;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedLanguage, deserialized.Language);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CodeExecutionCallArguments { Code = "code", Language = Language.Python };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CodeExecutionCallArguments { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CodeExecutionCallArguments { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CodeExecutionCallArguments
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Language = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CodeExecutionCallArguments
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            Language = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CodeExecutionCallArguments { Code = "code", Language = Language.Python };

        CodeExecutionCallArguments copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LanguageTest : TestBase
{
    [Theory]
    [InlineData(Language.Python)]
    public void Validation_Works(Language rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Language> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Language>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Language.Python)]
    public void SerializationRoundtrip_Works(Language rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Language> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Language>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Language>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Language>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
