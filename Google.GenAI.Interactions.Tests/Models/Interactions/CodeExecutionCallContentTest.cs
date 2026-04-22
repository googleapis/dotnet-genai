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

using System.Text.Json;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class CodeExecutionCallContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CodeExecutionCallContent
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
        var model = new CodeExecutionCallContent
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionCallContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CodeExecutionCallContent
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecutionCallContent>(
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
        var model = new CodeExecutionCallContent
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
        var model = new CodeExecutionCallContent
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
        var model = new CodeExecutionCallContent
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CodeExecutionCallContent
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
        var model = new CodeExecutionCallContent
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
        var model = new CodeExecutionCallContent
        {
            ID = "id",
            Arguments = new() { Code = "code", Language = Language.Python },
            Signature = "U3RhaW5sZXNzIHJvY2tz",
        };

        CodeExecutionCallContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
