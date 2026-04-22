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

public class GoogleMapsResultContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        List<InteractionGoogleMapsResult> expectedResult = new List<InteractionGoogleMapsResult>()
        {
            new InteractionGoogleMapsResult()
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
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_result");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedResult.Count, model.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], model.Result[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMapsResultContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMapsResultContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        List<InteractionGoogleMapsResult> expectedResult = new List<InteractionGoogleMapsResult>()
        {
            new InteractionGoogleMapsResult()
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
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_result");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedResult.Count, deserialized.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], deserialized.Result[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleMapsResultContent
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleMapsResult>()
            {
                new InteractionGoogleMapsResult()
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
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        GoogleMapsResultContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
