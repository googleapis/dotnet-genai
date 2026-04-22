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

public class McpServerToolResultContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpServerToolResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        McpServerToolResultContentResult expectedResult = JsonSerializer.Deserialize<JsonElement>(
            "{}"
        );
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
        var model = new McpServerToolResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpServerToolResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        McpServerToolResultContentResult expectedResult = JsonSerializer.Deserialize<JsonElement>(
            "{}"
        );
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
        var model = new McpServerToolResultContent
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
        var model = new McpServerToolResultContent
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
        var model = new McpServerToolResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new McpServerToolResultContent
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
        var model = new McpServerToolResultContent
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
        var model = new McpServerToolResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            Name = "name",
            ServerName = "server_name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        McpServerToolResultContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class McpServerToolResultContentResultTest : TestBase
{
    [Fact]
    public void JsonElementValidationWorks()
    {
        McpServerToolResultContentResult value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void FunctionResultSubcontentListValidationWorks()
    {
        McpServerToolResultContentResult value = new(
            new List<McpServerToolResultContentResultFunctionResultSubcontent>()
            {
                new McpServerToolResultContentResultFunctionResultSubcontent(
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
        McpServerToolResultContentResult value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        McpServerToolResultContentResult value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultContentResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultSubcontentListSerializationRoundtripWorks()
    {
        McpServerToolResultContentResult value = new(
            new List<McpServerToolResultContentResultFunctionResultSubcontent>()
            {
                new McpServerToolResultContentResultFunctionResultSubcontent(
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
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultContentResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        McpServerToolResultContentResult value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServerToolResultContentResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class McpServerToolResultContentResultFunctionResultSubcontentTest : TestBase
{
    [Fact]
    public void TextContentValidationWorks()
    {
        McpServerToolResultContentResultFunctionResultSubcontent value = new TextContent()
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
        McpServerToolResultContentResultFunctionResultSubcontent value = new ImageContent()
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
        McpServerToolResultContentResultFunctionResultSubcontent value = new TextContent()
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
            JsonSerializer.Deserialize<McpServerToolResultContentResultFunctionResultSubcontent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        McpServerToolResultContentResultFunctionResultSubcontent value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<McpServerToolResultContentResultFunctionResultSubcontent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
