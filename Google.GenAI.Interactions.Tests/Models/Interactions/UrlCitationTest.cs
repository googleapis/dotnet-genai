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
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class UrlCitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("url_citation");
        int expectedEndIndex = 0;
        int expectedStartIndex = 0;
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedEndIndex, model.EndIndex);
        Assert.Equal(expectedStartIndex, model.StartIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlCitation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlCitation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("url_citation");
        int expectedEndIndex = 0;
        int expectedStartIndex = 0;
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedEndIndex, deserialized.EndIndex);
        Assert.Equal(expectedStartIndex, deserialized.StartIndex);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlCitation { };

        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UrlCitation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UrlCitation
        {
            // Null should be interpreted as omitted for these properties
            EndIndex = null,
            StartIndex = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UrlCitation
        {
            // Null should be interpreted as omitted for these properties
            EndIndex = null,
            StartIndex = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlCitation
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };

        UrlCitation copied = new(model);

        Assert.Equal(model, copied);
    }
}
