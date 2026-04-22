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

public class GoogleSearchCallContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedID = "id";
        GoogleSearchCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search_call");
        ApiEnum<string, SearchType> expectedSearchType = SearchType.WebSearch;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArguments, model.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSearchType, model.SearchType);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearchCallContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearchCallContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        GoogleSearchCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search_call");
        ApiEnum<string, SearchType> expectedSearchType = SearchType.WebSearch;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSearchType, deserialized.SearchType);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
        };

        Assert.Null(model.SearchType);
        Assert.False(model.RawData.ContainsKey("search_type"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },

            // Null should be interpreted as omitted for these properties
            SearchType = null,
            Signature = null,
        };

        Assert.Null(model.SearchType);
        Assert.False(model.RawData.ContainsKey("search_type"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },

            // Null should be interpreted as omitted for these properties
            SearchType = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleSearchCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        GoogleSearchCallContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SearchTypeTest : TestBase
{
    [Theory]
    [InlineData(SearchType.WebSearch)]
    [InlineData(SearchType.ImageSearch)]
    [InlineData(SearchType.EnterpriseWebSearch)]
    public void Validation_Works(SearchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SearchType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SearchType.WebSearch)]
    [InlineData(SearchType.ImageSearch)]
    [InlineData(SearchType.EnterpriseWebSearch)]
    public void SerializationRoundtrip_Works(SearchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SearchType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SearchType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
