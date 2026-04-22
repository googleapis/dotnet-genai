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

public class FunctionResultContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string expectedCallID = "call_id";
        FunctionResultContentResult expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
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
        var model = new FunctionResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResultContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResultContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCallID = "call_id";
        FunctionResultContentResult expectedResult = JsonSerializer.Deserialize<JsonElement>("{}");
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
        var model = new FunctionResultContent
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
        var model = new FunctionResultContent
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
        var model = new FunctionResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionResultContent
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
        var model = new FunctionResultContent
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
        var model = new FunctionResultContent
        {
            CallID = "call_id",
            Result = JsonSerializer.Deserialize<JsonElement>("{}"),
            IsError = true,
            Name = "name",
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        FunctionResultContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FunctionResultContentResultTest : TestBase
{
    [Fact]
    public void JsonElementValidationWorks()
    {
        FunctionResultContentResult value = JsonSerializer.Deserialize<JsonElement>("{}");
        value.Validate();
    }

    [Fact]
    public void FunctionResultSubcontentListValidationWorks()
    {
        FunctionResultContentResult value = new(
            new List<FunctionResultContentResultFunctionResultSubcontent>()
            {
                new FunctionResultContentResultFunctionResultSubcontent(
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
        FunctionResultContentResult value = "string";
        value.Validate();
    }

    [Fact]
    public void JsonElementSerializationRoundtripWorks()
    {
        FunctionResultContentResult value = JsonSerializer.Deserialize<JsonElement>("{}");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResultContentResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FunctionResultSubcontentListSerializationRoundtripWorks()
    {
        FunctionResultContentResult value = new(
            new List<FunctionResultContentResultFunctionResultSubcontent>()
            {
                new FunctionResultContentResultFunctionResultSubcontent(
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
        var deserialized = JsonSerializer.Deserialize<FunctionResultContentResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        FunctionResultContentResult value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionResultContentResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FunctionResultContentResultFunctionResultSubcontentTest : TestBase
{
    [Fact]
    public void TextContentValidationWorks()
    {
        FunctionResultContentResultFunctionResultSubcontent value = new TextContent()
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
        FunctionResultContentResultFunctionResultSubcontent value = new ImageContent()
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
        FunctionResultContentResultFunctionResultSubcontent value = new TextContent()
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
            JsonSerializer.Deserialize<FunctionResultContentResultFunctionResultSubcontent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageContentSerializationRoundtripWorks()
    {
        FunctionResultContentResultFunctionResultSubcontent value = new ImageContent()
        {
            Data = "U3RhaW5sZXNzIHJvY2tz",
            MimeType = ImageContentMimeType.ImagePng,
            Resolution = ImageContentResolution.Low,
            Uri = "uri",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<FunctionResultContentResultFunctionResultSubcontent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
