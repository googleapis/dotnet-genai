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

public class PlaceCitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlaceCitation
        {
            EndIndex = 0,
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            StartIndex = 0,
            Url = "url",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("place_citation");
        int expectedEndIndex = 0;
        string expectedName = "name";
        string expectedPlaceID = "place_id";
        List<PlaceCitationReviewSnippet> expectedReviewSnippets =
            new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            };
        int expectedStartIndex = 0;
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedEndIndex, model.EndIndex);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlaceID, model.PlaceID);
        Assert.NotNull(model.ReviewSnippets);
        Assert.Equal(expectedReviewSnippets.Count, model.ReviewSnippets.Count);
        for (int i = 0; i < expectedReviewSnippets.Count; i++)
        {
            Assert.Equal(expectedReviewSnippets[i], model.ReviewSnippets[i]);
        }
        Assert.Equal(expectedStartIndex, model.StartIndex);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlaceCitation
        {
            EndIndex = 0,
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            StartIndex = 0,
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlaceCitation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlaceCitation
        {
            EndIndex = 0,
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            StartIndex = 0,
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlaceCitation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("place_citation");
        int expectedEndIndex = 0;
        string expectedName = "name";
        string expectedPlaceID = "place_id";
        List<PlaceCitationReviewSnippet> expectedReviewSnippets =
            new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            };
        int expectedStartIndex = 0;
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedEndIndex, deserialized.EndIndex);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPlaceID, deserialized.PlaceID);
        Assert.NotNull(deserialized.ReviewSnippets);
        Assert.Equal(expectedReviewSnippets.Count, deserialized.ReviewSnippets.Count);
        for (int i = 0; i < expectedReviewSnippets.Count; i++)
        {
            Assert.Equal(expectedReviewSnippets[i], deserialized.ReviewSnippets[i]);
        }
        Assert.Equal(expectedStartIndex, deserialized.StartIndex);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlaceCitation
        {
            EndIndex = 0,
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            StartIndex = 0,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlaceCitation { };

        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PlaceID);
        Assert.False(model.RawData.ContainsKey("place_id"));
        Assert.Null(model.ReviewSnippets);
        Assert.False(model.RawData.ContainsKey("review_snippets"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlaceCitation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlaceCitation
        {
            // Null should be interpreted as omitted for these properties
            EndIndex = null,
            Name = null,
            PlaceID = null,
            ReviewSnippets = null,
            StartIndex = null,
            Url = null,
        };

        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PlaceID);
        Assert.False(model.RawData.ContainsKey("place_id"));
        Assert.Null(model.ReviewSnippets);
        Assert.False(model.RawData.ContainsKey("review_snippets"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlaceCitation
        {
            // Null should be interpreted as omitted for these properties
            EndIndex = null,
            Name = null,
            PlaceID = null,
            ReviewSnippets = null,
            StartIndex = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlaceCitation
        {
            EndIndex = 0,
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            StartIndex = 0,
            Url = "url",
        };

        PlaceCitation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlaceCitationReviewSnippetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlaceCitationReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        string expectedReviewID = "review_id";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedReviewID, model.ReviewID);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlaceCitationReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlaceCitationReviewSnippet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlaceCitationReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlaceCitationReviewSnippet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReviewID = "review_id";
        string expectedTitle = "title";
        string expectedUrl = "url";

        Assert.Equal(expectedReviewID, deserialized.ReviewID);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlaceCitationReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlaceCitationReviewSnippet { };

        Assert.Null(model.ReviewID);
        Assert.False(model.RawData.ContainsKey("review_id"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlaceCitationReviewSnippet { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlaceCitationReviewSnippet
        {
            // Null should be interpreted as omitted for these properties
            ReviewID = null,
            Title = null,
            Url = null,
        };

        Assert.Null(model.ReviewID);
        Assert.False(model.RawData.ContainsKey("review_id"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlaceCitationReviewSnippet
        {
            // Null should be interpreted as omitted for these properties
            ReviewID = null,
            Title = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlaceCitationReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        PlaceCitationReviewSnippet copied = new(model);

        Assert.Equal(model, copied);
    }
}
