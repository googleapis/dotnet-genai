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

public class InteractionGoogleSearchResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InteractionGoogleSearchResult { SearchSuggestions = "search_suggestions" };

        string expectedSearchSuggestions = "search_suggestions";

        Assert.Equal(expectedSearchSuggestions, model.SearchSuggestions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InteractionGoogleSearchResult { SearchSuggestions = "search_suggestions" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionGoogleSearchResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InteractionGoogleSearchResult { SearchSuggestions = "search_suggestions" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionGoogleSearchResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSearchSuggestions = "search_suggestions";

        Assert.Equal(expectedSearchSuggestions, deserialized.SearchSuggestions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InteractionGoogleSearchResult { SearchSuggestions = "search_suggestions" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InteractionGoogleSearchResult { };

        Assert.Null(model.SearchSuggestions);
        Assert.False(model.RawData.ContainsKey("search_suggestions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InteractionGoogleSearchResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InteractionGoogleSearchResult
        {
            // Null should be interpreted as omitted for these properties
            SearchSuggestions = null,
        };

        Assert.Null(model.SearchSuggestions);
        Assert.False(model.RawData.ContainsKey("search_suggestions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InteractionGoogleSearchResult
        {
            // Null should be interpreted as omitted for these properties
            SearchSuggestions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InteractionGoogleSearchResult { SearchSuggestions = "search_suggestions" };

        InteractionGoogleSearchResult copied = new(model);

        Assert.Equal(model, copied);
    }
}
