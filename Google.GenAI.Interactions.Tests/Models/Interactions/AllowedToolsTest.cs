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

public class AllowedToolsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AllowedTools
        {
            Mode = ToolChoiceType.Auto,
            Tools = new List<string>() { "string" },
        };

        ApiEnum<string, ToolChoiceType> expectedMode = ToolChoiceType.Auto;
        List<string> expectedTools = new List<string>() { "string" };

        Assert.Equal(expectedMode, model.Mode);
        Assert.NotNull(model.Tools);
        Assert.Equal(expectedTools.Count, model.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], model.Tools[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AllowedTools
        {
            Mode = ToolChoiceType.Auto,
            Tools = new List<string>() { "string" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllowedTools>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AllowedTools
        {
            Mode = ToolChoiceType.Auto,
            Tools = new List<string>() { "string" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AllowedTools>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ToolChoiceType> expectedMode = ToolChoiceType.Auto;
        List<string> expectedTools = new List<string>() { "string" };

        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.NotNull(deserialized.Tools);
        Assert.Equal(expectedTools.Count, deserialized.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], deserialized.Tools[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AllowedTools
        {
            Mode = ToolChoiceType.Auto,
            Tools = new List<string>() { "string" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AllowedTools { };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AllowedTools { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AllowedTools
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
            Tools = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Tools);
        Assert.False(model.RawData.ContainsKey("tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AllowedTools
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
            Tools = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AllowedTools
        {
            Mode = ToolChoiceType.Auto,
            Tools = new List<string>() { "string" },
        };

        AllowedTools copied = new(model);

        Assert.Equal(model, copied);
    }
}
