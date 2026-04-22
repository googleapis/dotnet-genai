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

public class TextContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextContent
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

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        List<Annotation> expectedAnnotations = new List<Annotation>()
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
        };

        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Annotations);
        Assert.Equal(expectedAnnotations.Count, model.Annotations.Count);
        for (int i = 0; i < expectedAnnotations.Count; i++)
        {
            Assert.Equal(expectedAnnotations[i], model.Annotations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TextContent
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextContent
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");
        List<Annotation> expectedAnnotations = new List<Annotation>()
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
        };

        Assert.Equal(expectedText, deserialized.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Annotations);
        Assert.Equal(expectedAnnotations.Count, deserialized.Annotations.Count);
        for (int i = 0; i < expectedAnnotations.Count; i++)
        {
            Assert.Equal(expectedAnnotations[i], deserialized.Annotations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TextContent
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextContent { Text = "text" };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextContent { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextContent
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Annotations = null,
        };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextContent
        {
            Text = "text",

            // Null should be interpreted as omitted for these properties
            Annotations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextContent
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

        TextContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
