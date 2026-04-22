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

public class InteractionGoogleMapsResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InteractionGoogleMapsResult
        {
            Places = new List<Place>()
            {
                new Place()
                {
                    Name = "name",
                    PlaceID = "place_id",
                    ReviewSnippets = new List<ReviewSnippet>()
                    {
                        new ReviewSnippet()
                        {
                            ReviewID = "review_id",
                            Title = "title",
                            Url = "url",
                        },
                    },
                    Url = "url",
                },
            },
            WidgetContextToken = "widget_context_token",
        };

        List<Place> expectedPlaces = new List<Place>()
        {
            new Place()
            {
                Name = "name",
                PlaceID = "place_id",
                ReviewSnippets = new List<ReviewSnippet>()
                {
                    new ReviewSnippet()
                    {
                        ReviewID = "review_id",
                        Title = "title",
                        Url = "url",
                    },
                },
                Url = "url",
            },
        };
        string expectedWidgetContextToken = "widget_context_token";

        Assert.NotNull(model.Places);
        Assert.Equal(expectedPlaces.Count, model.Places.Count);
        for (int i = 0; i < expectedPlaces.Count; i++)
        {
            Assert.Equal(expectedPlaces[i], model.Places[i]);
        }
        Assert.Equal(expectedWidgetContextToken, model.WidgetContextToken);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InteractionGoogleMapsResult
        {
            Places = new List<Place>()
            {
                new Place()
                {
                    Name = "name",
                    PlaceID = "place_id",
                    ReviewSnippets = new List<ReviewSnippet>()
                    {
                        new ReviewSnippet()
                        {
                            ReviewID = "review_id",
                            Title = "title",
                            Url = "url",
                        },
                    },
                    Url = "url",
                },
            },
            WidgetContextToken = "widget_context_token",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionGoogleMapsResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InteractionGoogleMapsResult
        {
            Places = new List<Place>()
            {
                new Place()
                {
                    Name = "name",
                    PlaceID = "place_id",
                    ReviewSnippets = new List<ReviewSnippet>()
                    {
                        new ReviewSnippet()
                        {
                            ReviewID = "review_id",
                            Title = "title",
                            Url = "url",
                        },
                    },
                    Url = "url",
                },
            },
            WidgetContextToken = "widget_context_token",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionGoogleMapsResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Place> expectedPlaces = new List<Place>()
        {
            new Place()
            {
                Name = "name",
                PlaceID = "place_id",
                ReviewSnippets = new List<ReviewSnippet>()
                {
                    new ReviewSnippet()
                    {
                        ReviewID = "review_id",
                        Title = "title",
                        Url = "url",
                    },
                },
                Url = "url",
            },
        };
        string expectedWidgetContextToken = "widget_context_token";

        Assert.NotNull(deserialized.Places);
        Assert.Equal(expectedPlaces.Count, deserialized.Places.Count);
        for (int i = 0; i < expectedPlaces.Count; i++)
        {
            Assert.Equal(expectedPlaces[i], deserialized.Places[i]);
        }
        Assert.Equal(expectedWidgetContextToken, deserialized.WidgetContextToken);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InteractionGoogleMapsResult
        {
            Places = new List<Place>()
            {
                new Place()
                {
                    Name = "name",
                    PlaceID = "place_id",
                    ReviewSnippets = new List<ReviewSnippet>()
                    {
                        new ReviewSnippet()
                        {
                            ReviewID = "review_id",
                            Title = "title",
                            Url = "url",
                        },
                    },
                    Url = "url",
                },
            },
            WidgetContextToken = "widget_context_token",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InteractionGoogleMapsResult { };

        Assert.Null(model.Places);
        Assert.False(model.RawData.ContainsKey("places"));
        Assert.Null(model.WidgetContextToken);
        Assert.False(model.RawData.ContainsKey("widget_context_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InteractionGoogleMapsResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InteractionGoogleMapsResult
        {
            // Null should be interpreted as omitted for these properties
            Places = null,
            WidgetContextToken = null,
        };

        Assert.Null(model.Places);
        Assert.False(model.RawData.ContainsKey("places"));
        Assert.Null(model.WidgetContextToken);
        Assert.False(model.RawData.ContainsKey("widget_context_token"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InteractionGoogleMapsResult
        {
            // Null should be interpreted as omitted for these properties
            Places = null,
            WidgetContextToken = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InteractionGoogleMapsResult
        {
            Places = new List<Place>()
            {
                new Place()
                {
                    Name = "name",
                    PlaceID = "place_id",
                    ReviewSnippets = new List<ReviewSnippet>()
                    {
                        new ReviewSnippet()
                        {
                            ReviewID = "review_id",
                            Title = "title",
                            Url = "url",
                        },
                    },
                    Url = "url",
                },
            },
            WidgetContextToken = "widget_context_token",
        };

        InteractionGoogleMapsResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlaceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Place
        {
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<ReviewSnippet>()
            {
                new ReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            Url = "url",
        };

        string expectedName = "name";
        string expectedPlaceID = "place_id";
        List<ReviewSnippet> expectedReviewSnippets = new List<ReviewSnippet>()
        {
            new ReviewSnippet()
            {
                ReviewID = "review_id",
                Title = "title",
                Url = "url",
            },
        };
        string expectedUrl = "url";

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPlaceID, model.PlaceID);
        Assert.NotNull(model.ReviewSnippets);
        Assert.Equal(expectedReviewSnippets.Count, model.ReviewSnippets.Count);
        for (int i = 0; i < expectedReviewSnippets.Count; i++)
        {
            Assert.Equal(expectedReviewSnippets[i], model.ReviewSnippets[i]);
        }
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Place
        {
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<ReviewSnippet>()
            {
                new ReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Place>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Place
        {
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<ReviewSnippet>()
            {
                new ReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Place>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        string expectedPlaceID = "place_id";
        List<ReviewSnippet> expectedReviewSnippets = new List<ReviewSnippet>()
        {
            new ReviewSnippet()
            {
                ReviewID = "review_id",
                Title = "title",
                Url = "url",
            },
        };
        string expectedUrl = "url";

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPlaceID, deserialized.PlaceID);
        Assert.NotNull(deserialized.ReviewSnippets);
        Assert.Equal(expectedReviewSnippets.Count, deserialized.ReviewSnippets.Count);
        for (int i = 0; i < expectedReviewSnippets.Count; i++)
        {
            Assert.Equal(expectedReviewSnippets[i], deserialized.ReviewSnippets[i]);
        }
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Place
        {
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<ReviewSnippet>()
            {
                new ReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Place { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PlaceID);
        Assert.False(model.RawData.ContainsKey("place_id"));
        Assert.Null(model.ReviewSnippets);
        Assert.False(model.RawData.ContainsKey("review_snippets"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Place { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Place
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            PlaceID = null,
            ReviewSnippets = null,
            Url = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PlaceID);
        Assert.False(model.RawData.ContainsKey("place_id"));
        Assert.Null(model.ReviewSnippets);
        Assert.False(model.RawData.ContainsKey("review_snippets"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Place
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            PlaceID = null,
            ReviewSnippets = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Place
        {
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<ReviewSnippet>()
            {
                new ReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            Url = "url",
        };

        Place copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReviewSnippetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReviewSnippet
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
        var model = new ReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewSnippet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewSnippet>(
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
        var model = new ReviewSnippet
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
        var model = new ReviewSnippet { };

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
        var model = new ReviewSnippet { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReviewSnippet
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
        var model = new ReviewSnippet
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
        var model = new ReviewSnippet
        {
            ReviewID = "review_id",
            Title = "title",
            Url = "url",
        };

        ReviewSnippet copied = new(model);

        Assert.Equal(model, copied);
    }
}
