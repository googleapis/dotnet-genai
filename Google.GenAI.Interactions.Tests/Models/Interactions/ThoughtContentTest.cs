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

public class ThoughtContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThoughtContent
        {
            Signature = "U3RhaW5sZXNzIHJvY2tz",
            Summary = new List<Summary>()
            {
                new Summary(
                    new TextContent()
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
                    }
                ),
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("thought");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";
        List<Summary> expectedSummary = new List<Summary>()
        {
            new Summary(
                new TextContent()
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
                }
            ),
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
        Assert.NotNull(model.Summary);
        Assert.Equal(expectedSummary.Count, model.Summary.Count);
        for (int i = 0; i < expectedSummary.Count; i++)
        {
            Assert.Equal(expectedSummary[i], model.Summary[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThoughtContent
        {
            Signature = "U3RhaW5sZXNzIHJvY2tz",
            Summary = new List<Summary>()
            {
                new Summary(
                    new TextContent()
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
                    }
                ),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThoughtContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThoughtContent
        {
            Signature = "U3RhaW5sZXNzIHJvY2tz",
            Summary = new List<Summary>()
            {
                new Summary(
                    new TextContent()
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
                    }
                ),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThoughtContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("thought");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";
        List<Summary> expectedSummary = new List<Summary>()
        {
            new Summary(
                new TextContent()
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
                }
            ),
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
        Assert.NotNull(deserialized.Summary);
        Assert.Equal(expectedSummary.Count, deserialized.Summary.Count);
        for (int i = 0; i < expectedSummary.Count; i++)
        {
            Assert.Equal(expectedSummary[i], deserialized.Summary[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThoughtContent
        {
            Signature = "U3RhaW5sZXNzIHJvY2tz",
            Summary = new List<Summary>()
            {
                new Summary(
                    new TextContent()
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
                    }
                ),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThoughtContent { };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThoughtContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ThoughtContent
        {
            // Null should be interpreted as omitted for these properties
            Signature = null,
            Summary = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
        Assert.Null(model.Summary);
        Assert.False(model.RawData.ContainsKey("summary"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThoughtContent
        {
            // Null should be interpreted as omitted for these properties
            Signature = null,
            Summary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThoughtContent
        {
            Signature = "U3RhaW5sZXNzIHJvY2tz",
            Summary = new List<Summary>()
            {
                new Summary(
                    new TextContent()
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
                    }
                ),
            },
        };

        ThoughtContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SummaryTest : TestBase
{
    [Fact]
    public void TextContentValidationWorks()
    {
        Summary value = new TextContent()
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
        value.Validate();
    }

    [Fact]
    public void ImageContentValidationWorks()
    {
        Summary value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void TextContentSerializationRoundtripWorks()
    {
        Summary value = new TextContent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        Summary value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
