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
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class ContentDeltaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContentDelta
        {
            Delta = new Text("text"),
            Index = 0,
            EventID = "event_id",
        };

        Delta expectedDelta = new Text("text");
        JsonElement expectedEventType = JsonSerializer.SerializeToElement("content.delta");
        int expectedIndex = 0;
        string expectedEventID = "event_id";

        Assert.Equal(expectedDelta, model.Delta);
        Assert.True(JsonElement.DeepEquals(expectedEventType, model.EventType));
        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContentDelta
        {
            Delta = new Text("text"),
            Index = 0,
            EventID = "event_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentDelta>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContentDelta
        {
            Delta = new Text("text"),
            Index = 0,
            EventID = "event_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContentDelta>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Delta expectedDelta = new Text("text");
        JsonElement expectedEventType = JsonSerializer.SerializeToElement("content.delta");
        int expectedIndex = 0;
        string expectedEventID = "event_id";

        Assert.Equal(expectedDelta, deserialized.Delta);
        Assert.True(JsonElement.DeepEquals(expectedEventType, deserialized.EventType));
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContentDelta
        {
            Delta = new Text("text"),
            Index = 0,
            EventID = "event_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContentDelta { Delta = new Text("text"), Index = 0 };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContentDelta { Delta = new Text("text"), Index = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContentDelta
        {
            Delta = new Text("text"),
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
        var model = new ContentDelta
        {
            Delta = new Text("text"),
            Index = 0,

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContentDelta
        {
            Delta = new Text("text"),
            Index = 0,
            EventID = "event_id",
        };

        ContentDelta copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeltaTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        Delta value = new Text("text");
        value.Validate();
    }

    [Fact]
    public void ImageValidationWorks()
    {
        Delta value = new Image()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageMimeType.ImagePng,
            Resolution = Resolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void AudioValidationWorks()
    {
        Delta value = new Audio()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = AudioMimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void DocumentValidationWorks()
    {
        Delta value = new Document()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void VideoValidationWorks()
    {
        Delta value = new Video()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoMimeType.VideoMp4,
            Resolution = VideoResolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void ThoughtSummaryValidationWorks()
    {
        Delta value = new ThoughtSummary()
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
        };
        value.Validate();
    }

    [Fact]
    public void ThoughtSignatureValidationWorks()
    {
        Delta value = new ThoughtSignature() { Signature = "U3RhaW5sZXNzIHJvY2tz" };
        value.Validate();
    }

    [Fact]
    public void FunctionCallValidationWorks()
    {
        Delta value = new FunctionCall()
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
        Delta value = new CodeExecutionCall()
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
        Delta value = new UrlContextCall()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleSearchCallValidationWorks()
    {
        Delta value = new GoogleSearchCall()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        value.Validate();
    }

    [Fact]
    public void McpServerToolCallValidationWorks()
    {
        Delta value = new McpServerToolCall()
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
    public void FileSearchCallValidationWorks()
    {
        Delta value = new FileSearchCall() { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsCallValidationWorks()
    {
        Delta value = new GoogleMapsCall()
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
        Delta value = new FunctionResult()
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
        Delta value = new CodeExecutionResult()
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
        Delta value = new UrlContextResult()
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
        Delta value = new GoogleSearchResult()
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
        Delta value = new McpServerToolResult()
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
        Delta value = new FileSearchResult()
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
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
        Delta value = new GoogleMapsResult()
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
    public void TextAnnotationValidationWorks()
    {
        Delta value = new TextAnnotation()
        {
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
    public void TextSerializationRoundtripWorks()
    {
        Delta value = new Text("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        Delta value = new Image()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageMimeType.ImagePng,
            Resolution = Resolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AudioSerializationRoundtripWorks()
    {
        Delta value = new Audio()
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = AudioMimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DocumentSerializationRoundtripWorks()
    {
        Delta value = new Document()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentMimeType.ApplicationPdf,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VideoSerializationRoundtripWorks()
    {
        Delta value = new Video()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoMimeType.VideoMp4,
            Resolution = VideoResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThoughtSummarySerializationRoundtripWorks()
    {
        Delta value = new ThoughtSummary()
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
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThoughtSignatureSerializationRoundtripWorks()
    {
        Delta value = new ThoughtSignature() { Signature = "U3RhaW5sZXNzIHJvY2tz" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionCallSerializationRoundtripWorks()
    {
        Delta value = new FunctionCall()
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
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionCallSerializationRoundtripWorks()
    {
        Delta value = new CodeExecutionCall()
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextCallSerializationRoundtripWorks()
    {
        Delta value = new UrlContextCall()
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchCallSerializationRoundtripWorks()
    {
        Delta value = new GoogleSearchCall()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolCallSerializationRoundtripWorks()
    {
        Delta value = new McpServerToolCall()
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
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchCallSerializationRoundtripWorks()
    {
        Delta value = new FileSearchCall() { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsCallSerializationRoundtripWorks()
    {
        Delta value = new GoogleMapsCall()
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultSerializationRoundtripWorks()
    {
        Delta value = new FunctionResult()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionResultSerializationRoundtripWorks()
    {
        Delta value = new CodeExecutionResult()
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextResultSerializationRoundtripWorks()
    {
        Delta value = new UrlContextResult()
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
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchResultSerializationRoundtripWorks()
    {
        Delta value = new GoogleSearchResult()
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
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerToolResultSerializationRoundtripWorks()
    {
        Delta value = new McpServerToolResult()
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchResultSerializationRoundtripWorks()
    {
        Delta value = new FileSearchResult()
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
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
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsResultSerializationRoundtripWorks()
    {
        Delta value = new GoogleMapsResult()
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
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextAnnotationSerializationRoundtripWorks()
    {
        Delta value = new TextAnnotation()
        {
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
        var deserialized = JsonSerializer.Deserialize<Delta>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Text { TextValue = "text" };

        string expectedTextValue = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.Equal(expectedTextValue, model.TextValue);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Text { TextValue = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Text { TextValue = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedTextValue = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.Equal(expectedTextValue, deserialized.TextValue);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Text { TextValue = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Text { TextValue = "text" };

        Text copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Image
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageMimeType.ImagePng,
            Resolution = Resolution.Low,
            Uri = "uri",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, ImageMimeType> expectedMimeType = ImageMimeType.ImagePng;
        ApiEnum<string, Resolution> expectedResolution = Resolution.Low;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedResolution, model.Resolution);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Image
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageMimeType.ImagePng,
            Resolution = Resolution.Low,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Image>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Image
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageMimeType.ImagePng,
            Resolution = Resolution.Low,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Image>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("image");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, ImageMimeType> expectedMimeType = ImageMimeType.ImagePng;
        ApiEnum<string, Resolution> expectedResolution = Resolution.Low;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedResolution, deserialized.Resolution);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Image
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageMimeType.ImagePng,
            Resolution = Resolution.Low,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Image { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Resolution);
        Assert.False(model.RawData.ContainsKey("resolution"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Image { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Image
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Resolution = null,
            Uri = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Resolution);
        Assert.False(model.RawData.ContainsKey("resolution"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Image
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Resolution = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Image
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageMimeType.ImagePng,
            Resolution = Resolution.Low,
            Uri = "uri",
        };

        Image copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageMimeTypeTest : TestBase
{
    [Theory]
    [InlineData(ImageMimeType.ImagePng)]
    [InlineData(ImageMimeType.ImageJpeg)]
    [InlineData(ImageMimeType.ImageWebp)]
    [InlineData(ImageMimeType.ImageHeic)]
    [InlineData(ImageMimeType.ImageHeif)]
    [InlineData(ImageMimeType.ImageGif)]
    [InlineData(ImageMimeType.ImageBmp)]
    [InlineData(ImageMimeType.ImageTiff)]
    public void Validation_Works(ImageMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageMimeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ImageMimeType.ImagePng)]
    [InlineData(ImageMimeType.ImageJpeg)]
    [InlineData(ImageMimeType.ImageWebp)]
    [InlineData(ImageMimeType.ImageHeic)]
    [InlineData(ImageMimeType.ImageHeif)]
    [InlineData(ImageMimeType.ImageGif)]
    [InlineData(ImageMimeType.ImageBmp)]
    [InlineData(ImageMimeType.ImageTiff)]
    public void SerializationRoundtrip_Works(ImageMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageMimeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResolutionTest : TestBase
{
    [Theory]
    [InlineData(Resolution.Low)]
    [InlineData(Resolution.Medium)]
    [InlineData(Resolution.High)]
    [InlineData(Resolution.UltraHigh)]
    public void Validation_Works(Resolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Resolution> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Resolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Resolution.Low)]
    [InlineData(Resolution.Medium)]
    [InlineData(Resolution.High)]
    [InlineData(Resolution.UltraHigh)]
    public void SerializationRoundtrip_Works(Resolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Resolution> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Resolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Resolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Resolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AudioTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Audio
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = AudioMimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("audio");
        int expectedChannels = 0;
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, AudioMimeType> expectedMimeType = AudioMimeType.AudioWav;
        int expectedRate = 0;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedChannels, model.Channels);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedRate, model.Rate);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Audio
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = AudioMimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Audio>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Audio
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = AudioMimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Audio>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("audio");
        int expectedChannels = 0;
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, AudioMimeType> expectedMimeType = AudioMimeType.AudioWav;
        int expectedRate = 0;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedChannels, deserialized.Channels);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedRate, deserialized.Rate);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Audio
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = AudioMimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Audio { };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Audio { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Audio
        {
            // Null should be interpreted as omitted for these properties
            Channels = null,
            Data = null,
            MimeType = null,
            Rate = null,
            Uri = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Rate);
        Assert.False(model.RawData.ContainsKey("rate"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Audio
        {
            // Null should be interpreted as omitted for these properties
            Channels = null,
            Data = null,
            MimeType = null,
            Rate = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Audio
        {
            Channels = 0,
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = AudioMimeType.AudioWav,
            Rate = 0,
            Uri = "uri",
        };

        Audio copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AudioMimeTypeTest : TestBase
{
    [Theory]
    [InlineData(AudioMimeType.AudioWav)]
    [InlineData(AudioMimeType.AudioMp3)]
    [InlineData(AudioMimeType.AudioAiff)]
    [InlineData(AudioMimeType.AudioAac)]
    [InlineData(AudioMimeType.AudioOgg)]
    [InlineData(AudioMimeType.AudioFlac)]
    [InlineData(AudioMimeType.AudioMpeg)]
    [InlineData(AudioMimeType.AudioM4a)]
    [InlineData(AudioMimeType.AudioL16)]
    public void Validation_Works(AudioMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudioMimeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudioMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AudioMimeType.AudioWav)]
    [InlineData(AudioMimeType.AudioMp3)]
    [InlineData(AudioMimeType.AudioAiff)]
    [InlineData(AudioMimeType.AudioAac)]
    [InlineData(AudioMimeType.AudioOgg)]
    [InlineData(AudioMimeType.AudioFlac)]
    [InlineData(AudioMimeType.AudioMpeg)]
    [InlineData(AudioMimeType.AudioM4a)]
    [InlineData(AudioMimeType.AudioL16)]
    public void SerializationRoundtrip_Works(AudioMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AudioMimeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudioMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AudioMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AudioMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Document
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentMimeType.ApplicationPdf,
            Uri = "uri",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("document");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, DocumentMimeType> expectedMimeType = DocumentMimeType.ApplicationPdf;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Document
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentMimeType.ApplicationPdf,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Document
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentMimeType.ApplicationPdf,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Document>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("document");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, DocumentMimeType> expectedMimeType = DocumentMimeType.ApplicationPdf;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Document
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentMimeType.ApplicationPdf,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Document { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Document { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Document
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Uri = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Document
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Document
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = DocumentMimeType.ApplicationPdf,
            Uri = "uri",
        };

        Document copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DocumentMimeTypeTest : TestBase
{
    [Theory]
    [InlineData(DocumentMimeType.ApplicationPdf)]
    public void Validation_Works(DocumentMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentMimeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DocumentMimeType.ApplicationPdf)]
    public void SerializationRoundtrip_Works(DocumentMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentMimeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VideoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Video
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoMimeType.VideoMp4,
            Resolution = VideoResolution.Low,
            Uri = "uri",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("video");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, VideoMimeType> expectedMimeType = VideoMimeType.VideoMp4;
        ApiEnum<string, VideoResolution> expectedResolution = VideoResolution.Low;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedResolution, model.Resolution);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Video
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoMimeType.VideoMp4,
            Resolution = VideoResolution.Low,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Video>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Video
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoMimeType.VideoMp4,
            Resolution = VideoResolution.Low,
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Video>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("video");
        string expectedData = "U3RhaW5sZXNzIHJvY2tz";
        ApiEnum<string, VideoMimeType> expectedMimeType = VideoMimeType.VideoMp4;
        ApiEnum<string, VideoResolution> expectedResolution = VideoResolution.Low;
        string expectedUri = "uri";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedResolution, deserialized.Resolution);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Video
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoMimeType.VideoMp4,
            Resolution = VideoResolution.Low,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Video { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Resolution);
        Assert.False(model.RawData.ContainsKey("resolution"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Video { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Video
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Resolution = null,
            Uri = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.MimeType);
        Assert.False(model.RawData.ContainsKey("mime_type"));
        Assert.Null(model.Resolution);
        Assert.False(model.RawData.ContainsKey("resolution"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Video
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
            MimeType = null,
            Resolution = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Video
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = VideoMimeType.VideoMp4,
            Resolution = VideoResolution.Low,
            Uri = "uri",
        };

        Video copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VideoMimeTypeTest : TestBase
{
    [Theory]
    [InlineData(VideoMimeType.VideoMp4)]
    [InlineData(VideoMimeType.VideoMpeg)]
    [InlineData(VideoMimeType.VideoMpg)]
    [InlineData(VideoMimeType.VideoMov)]
    [InlineData(VideoMimeType.VideoAvi)]
    [InlineData(VideoMimeType.VideoXFlv)]
    [InlineData(VideoMimeType.VideoWebm)]
    [InlineData(VideoMimeType.VideoWmv)]
    [InlineData(VideoMimeType.Video3gpp)]
    public void Validation_Works(VideoMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoMimeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VideoMimeType.VideoMp4)]
    [InlineData(VideoMimeType.VideoMpeg)]
    [InlineData(VideoMimeType.VideoMpg)]
    [InlineData(VideoMimeType.VideoMov)]
    [InlineData(VideoMimeType.VideoAvi)]
    [InlineData(VideoMimeType.VideoXFlv)]
    [InlineData(VideoMimeType.VideoWebm)]
    [InlineData(VideoMimeType.VideoWmv)]
    [InlineData(VideoMimeType.Video3gpp)]
    public void SerializationRoundtrip_Works(VideoMimeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoMimeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoMimeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoMimeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VideoResolutionTest : TestBase
{
    [Theory]
    [InlineData(VideoResolution.Low)]
    [InlineData(VideoResolution.Medium)]
    [InlineData(VideoResolution.High)]
    [InlineData(VideoResolution.UltraHigh)]
    public void Validation_Works(VideoResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoResolution> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VideoResolution.Low)]
    [InlineData(VideoResolution.Medium)]
    [InlineData(VideoResolution.High)]
    [InlineData(VideoResolution.UltraHigh)]
    public void SerializationRoundtrip_Works(VideoResolution rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VideoResolution> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VideoResolution>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VideoResolution>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThoughtSummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThoughtSummary
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
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("thought_summary");
        ThoughtSummaryContent expectedContent = new TextContent()
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

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedContent, model.Content);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThoughtSummary
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThoughtSummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThoughtSummary
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThoughtSummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("thought_summary");
        ThoughtSummaryContent expectedContent = new TextContent()
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

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedContent, deserialized.Content);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThoughtSummary
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThoughtSummary { };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThoughtSummary { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ThoughtSummary
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThoughtSummary
        {
            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThoughtSummary
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
        };

        ThoughtSummary copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThoughtSummaryContentTest : TestBase
{
    [Fact]
    public void TextValidationWorks()
    {
        ThoughtSummaryContent value = new TextContent()
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
        ThoughtSummaryContent value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        value.Validate();
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        ThoughtSummaryContent value = new TextContent()
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
        var deserialized = JsonSerializer.Deserialize<ThoughtSummaryContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        ThoughtSummaryContent value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThoughtSummaryContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThoughtSignatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThoughtSignature { Signature = "U3RhaW5sZXNzIHJvY2tz" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("thought_signature");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThoughtSignature { Signature = "U3RhaW5sZXNzIHJvY2tz" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThoughtSignature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThoughtSignature { Signature = "U3RhaW5sZXNzIHJvY2tz" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThoughtSignature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("thought_signature");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThoughtSignature { Signature = "U3RhaW5sZXNzIHJvY2tz" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThoughtSignature { };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThoughtSignature { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ThoughtSignature
        {
            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThoughtSignature
        {
            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThoughtSignature { Signature = "U3RhaW5sZXNzIHJvY2tz" };

        ThoughtSignature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedArguments = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("function_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(model.Arguments.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Arguments[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedArguments = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("function_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(deserialized.Arguments.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Arguments[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        FunctionCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CodeExecutionCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedID = "id";
        CodeExecutionCallArguments expectedArguments = new()
        {
            Code = "code",
            Language = Language.Python,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArguments, model.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        CodeExecutionCallArguments expectedArguments = new()
        {
            Code = "code",
            Language = Language.Python,
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CodeExecutionCall
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        CodeExecutionCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlContextCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedID = "id";
        UrlContextCallArguments expectedArguments = new()
        {
            Urls = new List<string>() { "string" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("url_context_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArguments, model.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlContextCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlContextCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        UrlContextCallArguments expectedArguments = new()
        {
            Urls = new List<string>() { "string" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("url_context_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlContextCall
        {
            ID = "id",
            Arguments = new() { Urls = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        UrlContextCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleSearchCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedID = "id";
        GoogleSearchCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArguments, model.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearchCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearchCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        GoogleSearchCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleSearchCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        GoogleSearchCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class McpServerToolCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpServerToolCall
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

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedArguments = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        string expectedServerName = "server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_server_tool_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArguments.Count, model.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(model.Arguments.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Arguments[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedServerName, model.ServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpServerToolCall
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpServerToolCall
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedArguments = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
        string expectedServerName = "server_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_server_tool_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArguments.Count, deserialized.Arguments.Count);
        foreach (var item in expectedArguments)
        {
            Assert.True(deserialized.Arguments.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Arguments[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedServerName, deserialized.ServerName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpServerToolCall
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new McpServerToolCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new McpServerToolCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new McpServerToolCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new McpServerToolCall
        {
            ID = "id",
            Arguments = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            ServerName = "server_name",

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpServerToolCall
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

        McpServerToolCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileSearchCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileSearchCall { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file_search_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileSearchCall { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearchCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileSearchCall { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearchCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("file_search_call");
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileSearchCall { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileSearchCall { ID = "id" };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileSearchCall { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileSearchCall
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileSearchCall
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileSearchCall { ID = "id", Signature = "U3RhaW5sZXNzIHJvY2tz" };

        FileSearchCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleMapsCallTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleMapsCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_call");
        GoogleMapsCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedArguments, model.Arguments);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleMapsCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMapsCall>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleMapsCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMapsCall>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_call");
        GoogleMapsCallArguments expectedArguments = new()
        {
            Queries = new List<string>() { "string" },
        };
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedArguments, deserialized.Arguments);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleMapsCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleMapsCall { ID = "id" };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleMapsCall { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleMapsCall
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Signature = null,
        };

        Assert.Null(model.Arguments);
        Assert.False(model.RawData.ContainsKey("arguments"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleMapsCall
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Arguments = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleMapsCall
        {
            ID = "id",
            Arguments = new() { Queries = new List<string>() { "string" } },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        GoogleMapsCall copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        Result expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedType = JsonSerializer.SerializeToElement("function_result");
        bool expectedIsError = true;
        string expectedName = "name";
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedResult, model.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        Result expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedType = JsonSerializer.SerializeToElement("function_result");
        bool expectedIsError = true;
        string expectedName = "name";
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Name = null,
            Signature = null,
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Name = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        FunctionResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void JsonElementValidationWorks()
    {
        Result value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void FunctionResultSubcontentListValidationWorks()
    {
        Result value = new(
            new List<FunctionResultSubcontent>()
            {
                new FunctionResultSubcontent(
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
        Result value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        Result value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultSubcontentListSerializationRoundtripWorks()
    {
        Result value = new(
            new List<FunctionResultSubcontent>()
            {
                new FunctionResultSubcontent(
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
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Result value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FunctionResultSubcontentTest : TestBase
{
    [Fact]
    public void TextContentValidationWorks()
    {
        FunctionResultSubcontent value = new TextContent()
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
        FunctionResultSubcontent value = new ImageContent()
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
        FunctionResultSubcontent value = new TextContent()
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
        var deserialized = JsonSerializer.Deserialize<FunctionResultSubcontent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        FunctionResultSubcontent value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResultSubcontent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CodeExecutionResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CodeExecutionResult
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        string expectedResult = "result";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_result");
        bool expectedIsError = true;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedResult, model.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CodeExecutionResult
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CodeExecutionResult
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        string expectedResult = "result";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_result");
        bool expectedIsError = true;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CodeExecutionResult
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CodeExecutionResult { CallID = "call_id", Result = "result" };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CodeExecutionResult { CallID = "call_id", Result = "result" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CodeExecutionResult
        {
            CallID = "call_id",
            Result = "result",

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Signature = null,
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CodeExecutionResult
        {
            CallID = "call_id",
            Result = "result",

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CodeExecutionResult
        {
            CallID = "call_id",
            Result = "result",
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        CodeExecutionResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UrlContextResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UrlContextResult
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

        string expectedCallID = "call_id";
        List<InteractionUrlContextResult> expectedResult = new List<InteractionUrlContextResult>()
        {
            new InteractionUrlContextResult()
            {
                Status = InteractionUrlContextResultStatus.Success,
                Url = "url",
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("url_context_result");
        bool expectedIsError = true;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedResult.Count, model.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], model.Result[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UrlContextResult
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlContextResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UrlContextResult
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlContextResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        List<InteractionUrlContextResult> expectedResult = new List<InteractionUrlContextResult>()
        {
            new InteractionUrlContextResult()
            {
                Status = InteractionUrlContextResultStatus.Success,
                Url = "url",
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("url_context_result");
        bool expectedIsError = true;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedResult.Count, deserialized.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], deserialized.Result[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UrlContextResult
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UrlContextResult
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
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UrlContextResult
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UrlContextResult
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

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Signature = null,
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UrlContextResult
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

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UrlContextResult
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

        UrlContextResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleSearchResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        List<InteractionGoogleSearchResult> expectedResult =
            new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search_result");
        bool expectedIsError = true;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedResult.Count, model.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], model.Result[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearchResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearchResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        List<InteractionGoogleSearchResult> expectedResult =
            new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            };
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search_result");
        bool expectedIsError = true;
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedResult.Count, deserialized.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], deserialized.Result[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Signature = null,
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },

            // Null should be interpreted as omitted for these properties
            IsError = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleSearchResult
        {
            CallID = "call_id",
            Result = new List<InteractionGoogleSearchResult>()
            {
                new InteractionGoogleSearchResult() { SearchSuggestions = "search_suggestions" },
            },
            IsError = true,
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        GoogleSearchResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class McpServerToolResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        McpServerToolResultResult expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_server_tool_result");
        string expectedName = "name";
        string expectedServerName = "server_name";
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.Equal(expectedResult, model.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedServerName, model.ServerName);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        McpServerToolResultResult expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_server_tool_result");
        string expectedName = "name";
        string expectedServerName = "server_name";
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedServerName, deserialized.ServerName);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ServerName);
        Assert.False(model.RawData.ContainsKey("server_name"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            Name = null,
            ServerName = null,
            Signature = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.ServerName);
        Assert.False(model.RawData.ContainsKey("server_name"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),

            // Null should be interpreted as omitted for these properties
            Name = null,
            ServerName = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpServerToolResult
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        McpServerToolResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class McpServerToolResultResultTest : TestBase
{
    [Fact]
    public void JsonElementValidationWorks()
    {
        McpServerToolResultResult value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void FunctionResultSubcontentListValidationWorks()
    {
        McpServerToolResultResult value = new(
            new List<McpServerToolResultResultFunctionResultSubcontent>()
            {
                new McpServerToolResultResultFunctionResultSubcontent(
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
        McpServerToolResultResult value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        McpServerToolResultResult value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultSubcontentListSerializationRoundtripWorks()
    {
        McpServerToolResultResult value = new(
            new List<McpServerToolResultResultFunctionResultSubcontent>()
            {
                new McpServerToolResultResultFunctionResultSubcontent(
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
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        McpServerToolResultResult value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class McpServerToolResultResultFunctionResultSubcontentTest : TestBase
{
    [Fact]
    public void TextContentValidationWorks()
    {
        McpServerToolResultResultFunctionResultSubcontent value = new TextContent()
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
        McpServerToolResultResultFunctionResultSubcontent value = new ImageContent()
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
        McpServerToolResultResultFunctionResultSubcontent value = new TextContent()
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
        var deserialized =
            JsonSerializer.Deserialize<McpServerToolResultResultFunctionResultSubcontent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        McpServerToolResultResultFunctionResultSubcontent value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<McpServerToolResultResultFunctionResultSubcontent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class FileSearchResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        List<FileSearchResultResult> expectedResult = new List<FileSearchResultResult>()
        {
            new FileSearchResultResult()
            {
                CustomMetadata = new List<JsonElement>()
                {
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("file_search_result");
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
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearchResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearchResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        List<FileSearchResultResult> expectedResult = new List<FileSearchResultResult>()
        {
            new FileSearchResultResult()
            {
                CustomMetadata = new List<JsonElement>()
                {
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };
        JsonElement expectedType = JsonSerializer.SerializeToElement("file_search_result");
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
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
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
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
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
        var model = new FileSearchResult
        {
            CallID = "call_id",
            Result = new List<FileSearchResultResult>()
            {
                new FileSearchResultResult()
                {
                    CustomMetadata = new List<JsonElement>()
                    {
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        FileSearchResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileSearchResultResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileSearchResultResult
        {
            CustomMetadata = new List<JsonElement>()
            {
                JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        List<JsonElement> expectedCustomMetadata = new List<JsonElement>()
        {
            JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.NotNull(model.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, model.CustomMetadata.Count);
        for (int i = 0; i < expectedCustomMetadata.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedCustomMetadata[i], model.CustomMetadata[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileSearchResultResult
        {
            CustomMetadata = new List<JsonElement>()
            {
                JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearchResultResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileSearchResultResult
        {
            CustomMetadata = new List<JsonElement>()
            {
                JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearchResultResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JsonElement> expectedCustomMetadata = new List<JsonElement>()
        {
            JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.NotNull(deserialized.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, deserialized.CustomMetadata.Count);
        for (int i = 0; i < expectedCustomMetadata.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedCustomMetadata[i], deserialized.CustomMetadata[i])
            );
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileSearchResultResult
        {
            CustomMetadata = new List<JsonElement>()
            {
                JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileSearchResultResult { };

        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("custom_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileSearchResultResult { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileSearchResultResult
        {
            // Null should be interpreted as omitted for these properties
            CustomMetadata = null,
        };

        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("custom_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileSearchResultResult
        {
            // Null should be interpreted as omitted for these properties
            CustomMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileSearchResultResult
        {
            CustomMetadata = new List<JsonElement>()
            {
                JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        FileSearchResultResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleMapsResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleMapsResult
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_result");
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
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, model.CallID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Result);
        Assert.Equal(expectedResult.Count, model.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], model.Result[i]);
        }
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleMapsResult
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
        var deserialized = JsonSerializer.Deserialize<GoogleMapsResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleMapsResult
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
        var deserialized = JsonSerializer.Deserialize<GoogleMapsResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps_result");
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
        string expectedSignature = "U3RhaW5sZXNzIHJvY2tz";

        Assert.Equal(expectedCallID, deserialized.CallID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Result);
        Assert.Equal(expectedResult.Count, deserialized.Result.Count);
        for (int i = 0; i < expectedResult.Count; i++)
        {
            Assert.Equal(expectedResult[i], deserialized.Result[i]);
        }
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleMapsResult
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
        var model = new GoogleMapsResult { CallID = "call_id" };

        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleMapsResult { CallID = "call_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleMapsResult
        {
            CallID = "call_id",

            // Null should be interpreted as omitted for these properties
            Result = null,
            Signature = null,
        };

        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleMapsResult
        {
            CallID = "call_id",

            // Null should be interpreted as omitted for these properties
            Result = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleMapsResult
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

        GoogleMapsResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextAnnotationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextAnnotation
        {
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

        JsonElement expectedType = JsonSerializer.SerializeToElement("text_annotation");
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
        var model = new TextAnnotation
        {
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
        var deserialized = JsonSerializer.Deserialize<TextAnnotation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextAnnotation
        {
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
        var deserialized = JsonSerializer.Deserialize<TextAnnotation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("text_annotation");
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
        var model = new TextAnnotation
        {
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
        var model = new TextAnnotation { };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TextAnnotation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TextAnnotation
        {
            // Null should be interpreted as omitted for these properties
            Annotations = null,
        };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TextAnnotation
        {
            // Null should be interpreted as omitted for these properties
            Annotations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextAnnotation
        {
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

        TextAnnotation copied = new(model);

        Assert.Equal(model, copied);
    }
}
