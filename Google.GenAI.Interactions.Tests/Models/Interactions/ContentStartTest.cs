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

public class ContentStartTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,
            EventID = "event_id",
        };

        Content expectedContent = new TextContent()
        {
            Text = "text",
            Annotations = new List<Annotation>()
            {
                new Annotation(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            },
        };
        JsonElement expectedEventType = JsonSerializer.SerializeToElement("content.start");
        int expectedIndex = 0;
        string expectedEventID = "event_id";

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedEventType, model.EventType));
        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,
            EventID = "event_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentStart>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,
            EventID = "event_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentStart>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Content expectedContent = new TextContent()
        {
            Text = "text",
            Annotations = new List<Annotation>()
            {
                new Annotation(
                    new UrlCitation()
                    {
                        EndIndex = 0,
                        StartIndex = 0,
                        Title = "title",
                        Url = "url",
                    }
                ),
            },
        };
        JsonElement expectedEventType = JsonSerializer.SerializeToElement("content.start");
        int expectedIndex = 0;
        string expectedEventID = "event_id";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedEventType, deserialized.EventType));
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,
            EventID = "event_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,
        };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContentStart
        {
            Content = new TextContent()
            {
                Text = "text",
                Annotations = new List<Annotation>()
                {
                    new Annotation(
                        new UrlCitation()
                        {
                            EndIndex = 0,
                            StartIndex = 0,
                            Title = "title",
                            Url = "url",
                        }
                    ),
                },
            },
            Index = 0,
            EventID = "event_id",
        };

        ContentStart copied = new(model);

        Assert.Equal(model, copied);
    }
}
