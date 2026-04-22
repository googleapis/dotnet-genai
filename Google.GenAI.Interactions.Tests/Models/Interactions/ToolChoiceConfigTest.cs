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

public class ToolChoiceConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolChoiceConfig
        {
            AllowedTools = new()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };

        AllowedTools expectedAllowedTools = new()
        {
            Mode = ToolChoiceType.Auto,
            Tools = new List<string>() { "string" },
        };

        Assert.Equal(expectedAllowedTools, model.AllowedTools);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolChoiceConfig
        {
            AllowedTools = new()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolChoiceConfig
        {
            AllowedTools = new()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChoiceConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AllowedTools expectedAllowedTools = new()
        {
            Mode = ToolChoiceType.Auto,
            Tools = new List<string>() { "string" },
        };

        Assert.Equal(expectedAllowedTools, deserialized.AllowedTools);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolChoiceConfig
        {
            AllowedTools = new()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolChoiceConfig { };

        Assert.Null(model.AllowedTools);
        Assert.False(model.RawData.ContainsKey("allowed_tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolChoiceConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolChoiceConfig
        {
            // Null should be interpreted as omitted for these properties
            AllowedTools = null,
        };

        Assert.Null(model.AllowedTools);
        Assert.False(model.RawData.ContainsKey("allowed_tools"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolChoiceConfig
        {
            // Null should be interpreted as omitted for these properties
            AllowedTools = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolChoiceConfig
        {
            AllowedTools = new()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };

        ToolChoiceConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
