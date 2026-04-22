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

public class ContentTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        Content value = new TextContent()
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
    public void ImageValidationWorks()
    {
        Content value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void AudioValidationWorks()
    {
        Content value = new AudioContent()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void DocumentValidationWorks()
    {
        Content value = new DocumentContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentContentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void VideoValidationWorks()
    {
        Content value = new VideoContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoContentMimeType.VideoMp4,
            Resolution = VideoContentResolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void ThoughtValidationWorks()
    {
        Content value = new ThoughtContent()
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
        value.Validate();
    }

    [Fact]
    public void FunctionCallValidationWorks()
    {
        Content value = new FunctionCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionCallValidationWorks()
    {
        Content value = new CodeExecutionCallContent()
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void UrlContextCallValidationWorks()
    {
        Content value = new UrlContextCallContent()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void McpServerToolCallValidationWorks()
    {
        Content value = new McpServerToolCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleSearchCallValidationWorks()
    {
        Content value = new GoogleSearchCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void FileSearchCallValidationWorks()
    {
        Content value = new FileSearchCallContent()
        {
            ID = "id",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsCallValidationWorks()
    {
        Content value = new GoogleMapsCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void FunctionResultValidationWorks()
    {
        Content value = new FunctionResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionResultValidationWorks()
    {
        Content value = new CodeExecutionResultContent()
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void UrlContextResultValidationWorks()
    {
        Content value = new UrlContextResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionUrlContextResult>()
            {
                new InteractionUrlContextResult()
                {
                    Status = InteractionUrlContextResultStatus.Success,
                    Url = "url",
                },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleSearchResultValidationWorks()
    {
        Content value = new GoogleSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void McpServerToolResultValidationWorks()
    {
        Content value = new McpServerToolResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void FileSearchResultValidationWorks()
    {
        Content value = new FileSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<FileSearchResultContentResult>()
            {
                new FileSearchResultContentResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsResultValidationWorks()
    {
        Content value = new GoogleMapsResultContent()
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
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        Content value = new TextContent()
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
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        Content value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AudioSerializationRoundtripWorks()
    {
        Content value = new AudioContent()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = MimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DocumentSerializationRoundtripWorks()
    {
        Content value = new DocumentContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentContentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoSerializationRoundtripWorks()
    {
        Content value = new VideoContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoContentMimeType.VideoMp4,
            Resolution = VideoContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThoughtSerializationRoundtripWorks()
    {
        Content value = new ThoughtContent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionCallSerializationRoundtripWorks()
    {
        Content value = new FunctionCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionCallSerializationRoundtripWorks()
    {
        Content value = new CodeExecutionCallContent()
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextCallSerializationRoundtripWorks()
    {
        Content value = new UrlContextCallContent()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolCallSerializationRoundtripWorks()
    {
        Content value = new McpServerToolCallContent()
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchCallSerializationRoundtripWorks()
    {
        Content value = new GoogleSearchCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            SearchType = SearchType.WebSearch,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchCallSerializationRoundtripWorks()
    {
        Content value = new FileSearchCallContent()
        {
            ID = "id",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsCallSerializationRoundtripWorks()
    {
        Content value = new GoogleMapsCallContent()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultSerializationRoundtripWorks()
    {
        Content value = new FunctionResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionResultSerializationRoundtripWorks()
    {
        Content value = new CodeExecutionResultContent()
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextResultSerializationRoundtripWorks()
    {
        Content value = new UrlContextResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionUrlContextResult>()
            {
                new InteractionUrlContextResult()
                {
                    Status = InteractionUrlContextResultStatus.Success,
                    Url = "url",
                },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchResultSerializationRoundtripWorks()
    {
        Content value = new GoogleSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolResultSerializationRoundtripWorks()
    {
        Content value = new McpServerToolResultContent()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchResultSerializationRoundtripWorks()
    {
        Content value = new FileSearchResultContent()
        {
            CallID = "call_id",
            Result = new List<FileSearchResultContentResult>()
            {
                new FileSearchResultContentResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsResultSerializationRoundtripWorks()
    {
        Content value = new GoogleMapsResultContent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
