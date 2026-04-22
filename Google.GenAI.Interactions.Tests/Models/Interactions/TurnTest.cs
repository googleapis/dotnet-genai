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

public class TurnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Turn
        {
            Content = new(
                new List<Content>()
                {
                    new Content(
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
                }
            ),
            Role = "role",
        };

        TurnContent expectedContent = new(
            new List<Content>()
            {
                new Content(
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
            }
        );
        string expectedRole = "role";

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Turn
        {
            Content = new(
                new List<Content>()
                {
                    new Content(
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
                }
            ),
            Role = "role",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Turn>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Turn
        {
            Content = new(
                new List<Content>()
                {
                    new Content(
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
                }
            ),
            Role = "role",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Turn>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        TurnContent expectedContent = new(
            new List<Content>()
            {
                new Content(
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
            }
        );
        string expectedRole = "role";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Turn
        {
            Content = new(
                new List<Content>()
                {
                    new Content(
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
                }
            ),
            Role = "role",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Turn { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Turn { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Turn
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Role = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Role);
        Assert.False(model.RawData.ContainsKey("role"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Turn
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
            Role = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Turn
        {
            Content = new(
                new List<Content>()
                {
                    new Content(
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
                }
            ),
            Role = "role",
        };

        Turn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TurnContentTest : TestBase
{
    [Fact]
    public void ListValidationWorks()
    {
        TurnContent value = new(
            new List<Content>()
            {
                new Content(
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TurnContent value = "string";
        value.Validate();
    }

    [Fact]
    public void ListSerializationRoundtripWorks()
    {
        TurnContent value = new(
            new List<Content>()
            {
                new Content(
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
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TurnContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TurnContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TurnContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
