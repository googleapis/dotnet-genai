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
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class GoogleMapsCallContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleMapsCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_call");
        GoogleMapsCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedArguments, model.Arguments);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleMapsCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMapsCallContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleMapsCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMapsCallContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_call");
        GoogleMapsCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleMapsCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleMapsCallContent { ID = "id" };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleMapsCallContent { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleMapsCallContent
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Signature = null,
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleMapsCallContent
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleMapsCallContent
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        GoogleMapsCallContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
