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

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            CachedTokensByModality = new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            },
            InputTokensByModality = new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            OutputTokensByModality = new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            ToolUseTokensByModality = new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            TotalCachedTokens = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        List<CachedTokensByModality> expectedCachedTokensByModality =
            new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            };
        List<InputTokensByModality> expectedInputTokensByModality =
            new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            };
        List<OutputTokensByModality> expectedOutputTokensByModality =
            new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            };
        List<ToolUseTokensByModality> expectedToolUseTokensByModality =
            new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            };
        int expectedTotalCachedTokens = 0;
        int expectedTotalInputTokens = 0;
        int expectedTotalOutputTokens = 0;
        int expectedTotalThoughtTokens = 0;
        int expectedTotalTokens = 0;
        int expectedTotalToolUseTokens = 0;

        Assert.NotNull(model.CachedTokensByModality);
        Assert.Equal(expectedCachedTokensByModality.Count, model.CachedTokensByModality.Count);
        for (int i = 0; i < expectedCachedTokensByModality.Count; i++)
        {
            Assert.Equal(expectedCachedTokensByModality[i], model.CachedTokensByModality[i]);
        }
        Assert.NotNull(model.InputTokensByModality);
        Assert.Equal(expectedInputTokensByModality.Count, model.InputTokensByModality.Count);
        for (int i = 0; i < expectedInputTokensByModality.Count; i++)
        {
            Assert.Equal(expectedInputTokensByModality[i], model.InputTokensByModality[i]);
        }
        Assert.NotNull(model.OutputTokensByModality);
        Assert.Equal(expectedOutputTokensByModality.Count, model.OutputTokensByModality.Count);
        for (int i = 0; i < expectedOutputTokensByModality.Count; i++)
        {
            Assert.Equal(expectedOutputTokensByModality[i], model.OutputTokensByModality[i]);
        }
        Assert.NotNull(model.ToolUseTokensByModality);
        Assert.Equal(expectedToolUseTokensByModality.Count, model.ToolUseTokensByModality.Count);
        for (int i = 0; i < expectedToolUseTokensByModality.Count; i++)
        {
            Assert.Equal(expectedToolUseTokensByModality[i], model.ToolUseTokensByModality[i]);
        }
        Assert.Equal(expectedTotalCachedTokens, model.TotalCachedTokens);
        Assert.Equal(expectedTotalInputTokens, model.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, model.TotalOutputTokens);
        Assert.Equal(expectedTotalThoughtTokens, model.TotalThoughtTokens);
        Assert.Equal(expectedTotalTokens, model.TotalTokens);
        Assert.Equal(expectedTotalToolUseTokens, model.TotalToolUseTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            CachedTokensByModality = new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            },
            InputTokensByModality = new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            OutputTokensByModality = new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            ToolUseTokensByModality = new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            TotalCachedTokens = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            CachedTokensByModality = new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            },
            InputTokensByModality = new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            OutputTokensByModality = new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            ToolUseTokensByModality = new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            TotalCachedTokens = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<CachedTokensByModality> expectedCachedTokensByModality =
            new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            };
        List<InputTokensByModality> expectedInputTokensByModality =
            new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            };
        List<OutputTokensByModality> expectedOutputTokensByModality =
            new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            };
        List<ToolUseTokensByModality> expectedToolUseTokensByModality =
            new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            };
        int expectedTotalCachedTokens = 0;
        int expectedTotalInputTokens = 0;
        int expectedTotalOutputTokens = 0;
        int expectedTotalThoughtTokens = 0;
        int expectedTotalTokens = 0;
        int expectedTotalToolUseTokens = 0;

        Assert.NotNull(deserialized.CachedTokensByModality);
        Assert.Equal(
            expectedCachedTokensByModality.Count,
            deserialized.CachedTokensByModality.Count
        );
        for (int i = 0; i < expectedCachedTokensByModality.Count; i++)
        {
            Assert.Equal(expectedCachedTokensByModality[i], deserialized.CachedTokensByModality[i]);
        }
        Assert.NotNull(deserialized.InputTokensByModality);
        Assert.Equal(expectedInputTokensByModality.Count, deserialized.InputTokensByModality.Count);
        for (int i = 0; i < expectedInputTokensByModality.Count; i++)
        {
            Assert.Equal(expectedInputTokensByModality[i], deserialized.InputTokensByModality[i]);
        }
        Assert.NotNull(deserialized.OutputTokensByModality);
        Assert.Equal(
            expectedOutputTokensByModality.Count,
            deserialized.OutputTokensByModality.Count
        );
        for (int i = 0; i < expectedOutputTokensByModality.Count; i++)
        {
            Assert.Equal(expectedOutputTokensByModality[i], deserialized.OutputTokensByModality[i]);
        }
        Assert.NotNull(deserialized.ToolUseTokensByModality);
        Assert.Equal(
            expectedToolUseTokensByModality.Count,
            deserialized.ToolUseTokensByModality.Count
        );
        for (int i = 0; i < expectedToolUseTokensByModality.Count; i++)
        {
            Assert.Equal(
                expectedToolUseTokensByModality[i],
                deserialized.ToolUseTokensByModality[i]
            );
        }
        Assert.Equal(expectedTotalCachedTokens, deserialized.TotalCachedTokens);
        Assert.Equal(expectedTotalInputTokens, deserialized.TotalInputTokens);
        Assert.Equal(expectedTotalOutputTokens, deserialized.TotalOutputTokens);
        Assert.Equal(expectedTotalThoughtTokens, deserialized.TotalThoughtTokens);
        Assert.Equal(expectedTotalTokens, deserialized.TotalTokens);
        Assert.Equal(expectedTotalToolUseTokens, deserialized.TotalToolUseTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            CachedTokensByModality = new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            },
            InputTokensByModality = new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            OutputTokensByModality = new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            ToolUseTokensByModality = new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            TotalCachedTokens = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage { };

        Assert.Null(model.CachedTokensByModality);
        Assert.False(model.RawData.ContainsKey("cached_tokens_by_modality"));
        Assert.Null(model.InputTokensByModality);
        Assert.False(model.RawData.ContainsKey("input_tokens_by_modality"));
        Assert.Null(model.OutputTokensByModality);
        Assert.False(model.RawData.ContainsKey("output_tokens_by_modality"));
        Assert.Null(model.ToolUseTokensByModality);
        Assert.False(model.RawData.ContainsKey("tool_use_tokens_by_modality"));
        Assert.Null(model.TotalCachedTokens);
        Assert.False(model.RawData.ContainsKey("total_cached_tokens"));
        Assert.Null(model.TotalInputTokens);
        Assert.False(model.RawData.ContainsKey("total_input_tokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.False(model.RawData.ContainsKey("total_output_tokens"));
        Assert.Null(model.TotalThoughtTokens);
        Assert.False(model.RawData.ContainsKey("total_thought_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
        Assert.Null(model.TotalToolUseTokens);
        Assert.False(model.RawData.ContainsKey("total_tool_use_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            CachedTokensByModality = null,
            InputTokensByModality = null,
            OutputTokensByModality = null,
            ToolUseTokensByModality = null,
            TotalCachedTokens = null,
            TotalInputTokens = null,
            TotalOutputTokens = null,
            TotalThoughtTokens = null,
            TotalTokens = null,
            TotalToolUseTokens = null,
        };

        Assert.Null(model.CachedTokensByModality);
        Assert.False(model.RawData.ContainsKey("cached_tokens_by_modality"));
        Assert.Null(model.InputTokensByModality);
        Assert.False(model.RawData.ContainsKey("input_tokens_by_modality"));
        Assert.Null(model.OutputTokensByModality);
        Assert.False(model.RawData.ContainsKey("output_tokens_by_modality"));
        Assert.Null(model.ToolUseTokensByModality);
        Assert.False(model.RawData.ContainsKey("tool_use_tokens_by_modality"));
        Assert.Null(model.TotalCachedTokens);
        Assert.False(model.RawData.ContainsKey("total_cached_tokens"));
        Assert.Null(model.TotalInputTokens);
        Assert.False(model.RawData.ContainsKey("total_input_tokens"));
        Assert.Null(model.TotalOutputTokens);
        Assert.False(model.RawData.ContainsKey("total_output_tokens"));
        Assert.Null(model.TotalThoughtTokens);
        Assert.False(model.RawData.ContainsKey("total_thought_tokens"));
        Assert.Null(model.TotalTokens);
        Assert.False(model.RawData.ContainsKey("total_tokens"));
        Assert.Null(model.TotalToolUseTokens);
        Assert.False(model.RawData.ContainsKey("total_tool_use_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            // Null should be interpreted as omitted for these properties
            CachedTokensByModality = null,
            InputTokensByModality = null,
            OutputTokensByModality = null,
            ToolUseTokensByModality = null,
            TotalCachedTokens = null,
            TotalInputTokens = null,
            TotalOutputTokens = null,
            TotalThoughtTokens = null,
            TotalTokens = null,
            TotalToolUseTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Usage
        {
            CachedTokensByModality = new List<CachedTokensByModality>()
            {
                new CachedTokensByModality() { Modality = Modality.Text, Tokens = 0 },
            },
            InputTokensByModality = new List<InputTokensByModality>()
            {
                new InputTokensByModality()
                {
                    Modality = InputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            OutputTokensByModality = new List<OutputTokensByModality>()
            {
                new OutputTokensByModality()
                {
                    Modality = OutputTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            ToolUseTokensByModality = new List<ToolUseTokensByModality>()
            {
                new ToolUseTokensByModality()
                {
                    Modality = ToolUseTokensByModalityModality.Text,
                    Tokens = 0,
                },
            },
            TotalCachedTokens = 0,
            TotalInputTokens = 0,
            TotalOutputTokens = 0,
            TotalThoughtTokens = 0,
            TotalTokens = 0,
            TotalToolUseTokens = 0,
        };

        Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CachedTokensByModalityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CachedTokensByModality { Modality = Modality.Text, Tokens = 0 };

        ApiEnum<string, Modality> expectedModality = Modality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedTokens, model.Tokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CachedTokensByModality { Modality = Modality.Text, Tokens = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CachedTokensByModality>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CachedTokensByModality { Modality = Modality.Text, Tokens = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CachedTokensByModality>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Modality> expectedModality = Modality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedTokens, deserialized.Tokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CachedTokensByModality { Modality = Modality.Text, Tokens = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CachedTokensByModality { };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CachedTokensByModality { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CachedTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CachedTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CachedTokensByModality { Modality = Modality.Text, Tokens = 0 };

        CachedTokensByModality copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModalityTest : TestBase
{
    [Theory]
    [InlineData(Modality.Text)]
    [InlineData(Modality.Image)]
    [InlineData(Modality.Audio)]
    [InlineData(Modality.Video)]
    [InlineData(Modality.Document)]
    public void Validation_Works(Modality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Modality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Modality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Modality.Text)]
    [InlineData(Modality.Image)]
    [InlineData(Modality.Audio)]
    [InlineData(Modality.Video)]
    [InlineData(Modality.Document)]
    public void SerializationRoundtrip_Works(Modality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Modality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Modality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Modality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Modality>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InputTokensByModalityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InputTokensByModality
        {
            Modality = InputTokensByModalityModality.Text,
            Tokens = 0,
        };

        ApiEnum<string, InputTokensByModalityModality> expectedModality =
            InputTokensByModalityModality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedTokens, model.Tokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InputTokensByModality
        {
            Modality = InputTokensByModalityModality.Text,
            Tokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputTokensByModality>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InputTokensByModality
        {
            Modality = InputTokensByModalityModality.Text,
            Tokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InputTokensByModality>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InputTokensByModalityModality> expectedModality =
            InputTokensByModalityModality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedTokens, deserialized.Tokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InputTokensByModality
        {
            Modality = InputTokensByModalityModality.Text,
            Tokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InputTokensByModality { };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InputTokensByModality { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InputTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InputTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InputTokensByModality
        {
            Modality = InputTokensByModalityModality.Text,
            Tokens = 0,
        };

        InputTokensByModality copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputTokensByModalityModalityTest : TestBase
{
    [Theory]
    [InlineData(InputTokensByModalityModality.Text)]
    [InlineData(InputTokensByModalityModality.Image)]
    [InlineData(InputTokensByModalityModality.Audio)]
    [InlineData(InputTokensByModalityModality.Video)]
    [InlineData(InputTokensByModalityModality.Document)]
    public void Validation_Works(InputTokensByModalityModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputTokensByModalityModality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputTokensByModalityModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InputTokensByModalityModality.Text)]
    [InlineData(InputTokensByModalityModality.Image)]
    [InlineData(InputTokensByModalityModality.Audio)]
    [InlineData(InputTokensByModalityModality.Video)]
    [InlineData(InputTokensByModalityModality.Document)]
    public void SerializationRoundtrip_Works(InputTokensByModalityModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InputTokensByModalityModality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InputTokensByModalityModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InputTokensByModalityModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InputTokensByModalityModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OutputTokensByModalityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OutputTokensByModality
        {
            Modality = OutputTokensByModalityModality.Text,
            Tokens = 0,
        };

        ApiEnum<string, OutputTokensByModalityModality> expectedModality =
            OutputTokensByModalityModality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedTokens, model.Tokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OutputTokensByModality
        {
            Modality = OutputTokensByModalityModality.Text,
            Tokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputTokensByModality>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OutputTokensByModality
        {
            Modality = OutputTokensByModalityModality.Text,
            Tokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OutputTokensByModality>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, OutputTokensByModalityModality> expectedModality =
            OutputTokensByModalityModality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedTokens, deserialized.Tokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OutputTokensByModality
        {
            Modality = OutputTokensByModalityModality.Text,
            Tokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OutputTokensByModality { };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OutputTokensByModality { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OutputTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OutputTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OutputTokensByModality
        {
            Modality = OutputTokensByModalityModality.Text,
            Tokens = 0,
        };

        OutputTokensByModality copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputTokensByModalityModalityTest : TestBase
{
    [Theory]
    [InlineData(OutputTokensByModalityModality.Text)]
    [InlineData(OutputTokensByModalityModality.Image)]
    [InlineData(OutputTokensByModalityModality.Audio)]
    [InlineData(OutputTokensByModalityModality.Video)]
    [InlineData(OutputTokensByModalityModality.Document)]
    public void Validation_Works(OutputTokensByModalityModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputTokensByModalityModality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputTokensByModalityModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OutputTokensByModalityModality.Text)]
    [InlineData(OutputTokensByModalityModality.Image)]
    [InlineData(OutputTokensByModalityModality.Audio)]
    [InlineData(OutputTokensByModalityModality.Video)]
    [InlineData(OutputTokensByModalityModality.Document)]
    public void SerializationRoundtrip_Works(OutputTokensByModalityModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OutputTokensByModalityModality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputTokensByModalityModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OutputTokensByModalityModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OutputTokensByModalityModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ToolUseTokensByModalityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolUseTokensByModality
        {
            Modality = ToolUseTokensByModalityModality.Text,
            Tokens = 0,
        };

        ApiEnum<string, ToolUseTokensByModalityModality> expectedModality =
            ToolUseTokensByModalityModality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, model.Modality);
        Assert.Equal(expectedTokens, model.Tokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolUseTokensByModality
        {
            Modality = ToolUseTokensByModalityModality.Text,
            Tokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseTokensByModality>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolUseTokensByModality
        {
            Modality = ToolUseTokensByModalityModality.Text,
            Tokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseTokensByModality>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ToolUseTokensByModalityModality> expectedModality =
            ToolUseTokensByModalityModality.Text;
        int expectedTokens = 0;

        Assert.Equal(expectedModality, deserialized.Modality);
        Assert.Equal(expectedTokens, deserialized.Tokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolUseTokensByModality
        {
            Modality = ToolUseTokensByModalityModality.Text,
            Tokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolUseTokensByModality { };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolUseTokensByModality { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolUseTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        Assert.Null(model.Modality);
        Assert.False(model.RawData.ContainsKey("modality"));
        Assert.Null(model.Tokens);
        Assert.False(model.RawData.ContainsKey("tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolUseTokensByModality
        {
            // Null should be interpreted as omitted for these properties
            Modality = null,
            Tokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolUseTokensByModality
        {
            Modality = ToolUseTokensByModalityModality.Text,
            Tokens = 0,
        };

        ToolUseTokensByModality copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolUseTokensByModalityModalityTest : TestBase
{
    [Theory]
    [InlineData(ToolUseTokensByModalityModality.Text)]
    [InlineData(ToolUseTokensByModalityModality.Image)]
    [InlineData(ToolUseTokensByModalityModality.Audio)]
    [InlineData(ToolUseTokensByModalityModality.Video)]
    [InlineData(ToolUseTokensByModalityModality.Document)]
    public void Validation_Works(ToolUseTokensByModalityModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseTokensByModalityModality> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseTokensByModalityModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ToolUseTokensByModalityModality.Text)]
    [InlineData(ToolUseTokensByModalityModality.Image)]
    [InlineData(ToolUseTokensByModalityModality.Audio)]
    [InlineData(ToolUseTokensByModalityModality.Video)]
    [InlineData(ToolUseTokensByModalityModality.Document)]
    public void SerializationRoundtrip_Works(ToolUseTokensByModalityModality rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ToolUseTokensByModalityModality> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolUseTokensByModalityModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ToolUseTokensByModalityModality>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ToolUseTokensByModalityModality>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
