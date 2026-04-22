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

public class ToolTest : TestBase
{
    [Fact]
    public void FunctionValidationWorks()
    {
        Tool value = new Function()
        {
            Description = "description",
            Name = "name",
            Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        value.Validate();
    }

    [Fact]
    public void CodeExecutionValidationWorks()
    {
        Tool value = new CodeExecution();
        value.Validate();
    }

    [Fact]
    public void UrlContextValidationWorks()
    {
        Tool value = new UrlContext();
        value.Validate();
    }

    [Fact]
    public void ComputerUseValidationWorks()
    {
        Tool value = new ComputerUse()
        {
            Environment = Environment.Browser,
            ExcludedPredefinedFunctions = new List<string>() { "string" },
        };
        value.Validate();
    }

    [Fact]
    public void McpServerValidationWorks()
    {
        Tool value = new McpServer()
        {
            AllowedTools = new List<AllowedTools>()
            {
                new AllowedTools()
                {
                    Mode = ToolChoiceType.Auto,
                    Tools = new List<string>() { "string" },
                },
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void GoogleSearchValidationWorks()
    {
        Tool value = new GoogleSearch()
        {
            SearchTypes = new List<ApiEnum<string, GoogleSearchSearchType>>()
            {
                GoogleSearchSearchType.WebSearch,
            },
        };
        value.Validate();
    }

    [Fact]
    public void FileSearchValidationWorks()
    {
        Tool value = new FileSearch()
        {
            FileSearchStoreNames = new List<string>() { "string" },
            MetadataFilter = "metadata_filter",
            TopK = 0,
        };
        value.Validate();
    }

    [Fact]
    public void GoogleMapsValidationWorks()
    {
        Tool value = new GoogleMaps()
        {
            EnableWidget = true,
            Latitude = 0,
            Longitude = 0,
        };
        value.Validate();
    }

    [Fact]
    public void RetrievalValidationWorks()
    {
        Tool value = new Retrieval()
        {
            RetrievalTypes = new List<ApiEnum<string, RetrievalType>>()
            {
                RetrievalType.VertexAISearch,
            },
            VertexAISearchConfig = new()
            {
                Datastores = new List<string>() { "string" },
                Engine = "engine",
            },
        };
        value.Validate();
    }

    [Fact]
    public void FunctionSerializationRoundtripWorks()
    {
        Tool value = new Function()
        {
            Description = "description",
            Name = "name",
            Parameters = JsonSerializer.Deserialize<JsonElement>("{}"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecutionSerializationRoundtripWorks()
    {
        Tool value = new CodeExecution();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UrlContextSerializationRoundtripWorks()
    {
        Tool value = new UrlContext();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerUseSerializationRoundtripWorks()
    {
        Tool value = new ComputerUse()
        {
            Environment = Environment.Browser,
            ExcludedPredefinedFunctions = new List<string>() { "string" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void McpServerSerializationRoundtripWorks()
    {
        Tool value = new McpServer()
        {
            AllowedTools = new List<AllowedTools>()
            {
                new AllowedTools()
                {
                    Mode = ToolChoiceType.Auto,
                    Tools = new List<string>() { "string" },
                },
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleSearchSerializationRoundtripWorks()
    {
        Tool value = new GoogleSearch()
        {
            SearchTypes = new List<ApiEnum<string, GoogleSearchSearchType>>()
            {
                GoogleSearchSearchType.WebSearch,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileSearchSerializationRoundtripWorks()
    {
        Tool value = new FileSearch()
        {
            FileSearchStoreNames = new List<string>() { "string" },
            MetadataFilter = "metadata_filter",
            TopK = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GoogleMapsSerializationRoundtripWorks()
    {
        Tool value = new GoogleMaps()
        {
            EnableWidget = true,
            Latitude = 0,
            Longitude = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RetrievalSerializationRoundtripWorks()
    {
        Tool value = new Retrieval()
        {
            RetrievalTypes = new List<ApiEnum<string, RetrievalType>>()
            {
                RetrievalType.VertexAISearch,
            },
            VertexAISearchConfig = new()
            {
                Datastores = new List<string>() { "string" },
                Engine = "engine",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tool>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CodeExecutionTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new CodeExecution();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<CodeExecution>(
            JsonSerializer.Deserialize<JsonElement>(
                @"{
              ""type"": ""code_execution""
            }"
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<CodeExecution>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new CodeExecution();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecution>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<CodeExecution>(
            JsonSerializer.Deserialize<JsonElement>(
                @"{
              ""type"": ""code_execution""
            }"
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecution>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<CodeExecution>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CodeExecution>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class UrlContextTest : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UrlContext();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlContext>(
            JsonSerializer.Deserialize<JsonElement>(
                @"{
              ""type"": ""url_context""
            }"
            ),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlContext>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(constant);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UrlContext();
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlContext>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlContext>(
            JsonSerializer.Deserialize<JsonElement>(
                @"{
              ""type"": ""url_context""
            }"
            ),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlContext>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UrlContext>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string element = JsonSerializer.Serialize(constant, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UrlContext>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(constant, deserialized);
    }
}

public class ComputerUseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerUse
        {
            Environment = Environment.Browser,
            ExcludedPredefinedFunctions = new List<string>() { "string" },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("computer_use");
        ApiEnum<string, Environment> expectedEnvironment = Environment.Browser;
        List<string> expectedExcludedPredefinedFunctions = new List<string>() { "string" };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedEnvironment, model.Environment);
        Assert.NotNull(model.ExcludedPredefinedFunctions);
        Assert.Equal(
            expectedExcludedPredefinedFunctions.Count,
            model.ExcludedPredefinedFunctions.Count
        );
        for (int i = 0; i < expectedExcludedPredefinedFunctions.Count; i++)
        {
            Assert.Equal(
                expectedExcludedPredefinedFunctions[i],
                model.ExcludedPredefinedFunctions[i]
            );
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComputerUse
        {
            Environment = Environment.Browser,
            ExcludedPredefinedFunctions = new List<string>() { "string" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerUse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerUse
        {
            Environment = Environment.Browser,
            ExcludedPredefinedFunctions = new List<string>() { "string" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerUse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("computer_use");
        ApiEnum<string, Environment> expectedEnvironment = Environment.Browser;
        List<string> expectedExcludedPredefinedFunctions = new List<string>() { "string" };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedEnvironment, deserialized.Environment);
        Assert.NotNull(deserialized.ExcludedPredefinedFunctions);
        Assert.Equal(
            expectedExcludedPredefinedFunctions.Count,
            deserialized.ExcludedPredefinedFunctions.Count
        );
        for (int i = 0; i < expectedExcludedPredefinedFunctions.Count; i++)
        {
            Assert.Equal(
                expectedExcludedPredefinedFunctions[i],
                deserialized.ExcludedPredefinedFunctions[i]
            );
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComputerUse
        {
            Environment = Environment.Browser,
            ExcludedPredefinedFunctions = new List<string>() { "string" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ComputerUse { };

        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.ExcludedPredefinedFunctions);
        Assert.False(model.RawData.ContainsKey("excludedPredefinedFunctions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ComputerUse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ComputerUse
        {
            // Null should be interpreted as omitted for these properties
            Environment = null,
            ExcludedPredefinedFunctions = null,
        };

        Assert.Null(model.Environment);
        Assert.False(model.RawData.ContainsKey("environment"));
        Assert.Null(model.ExcludedPredefinedFunctions);
        Assert.False(model.RawData.ContainsKey("excludedPredefinedFunctions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ComputerUse
        {
            // Null should be interpreted as omitted for these properties
            Environment = null,
            ExcludedPredefinedFunctions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerUse
        {
            Environment = Environment.Browser,
            ExcludedPredefinedFunctions = new List<string>() { "string" },
        };

        ComputerUse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EnvironmentTest : TestBase
{
    [Theory]
    [InlineData(Environment.Browser)]
    public void Validation_Works(Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Environment> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Environment.Browser)]
    public void SerializationRoundtrip_Works(Environment rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Environment> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Environment>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Environment>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class McpServerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new McpServer
        {
            AllowedTools = new List<AllowedTools>()
            {
                new AllowedTools()
                {
                    Mode = ToolChoiceType.Auto,
                    Tools = new List<string>() { "string" },
                },
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Url = "url",
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_server");
        List<AllowedTools> expectedAllowedTools = new List<AllowedTools>()
        {
            new AllowedTools()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedName = "name";
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.AllowedTools);
        Assert.Equal(expectedAllowedTools.Count, model.AllowedTools.Count);
        for (int i = 0; i < expectedAllowedTools.Count; i++)
        {
            Assert.Equal(expectedAllowedTools[i], model.AllowedTools[i]);
        }
        Assert.NotNull(model.Headers);
        Assert.Equal(expectedHeaders.Count, model.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(model.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Headers[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUrl, model.Url);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new McpServer
        {
            AllowedTools = new List<AllowedTools>()
            {
                new AllowedTools()
                {
                    Mode = ToolChoiceType.Auto,
                    Tools = new List<string>() { "string" },
                },
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Url = "url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new McpServer
        {
            AllowedTools = new List<AllowedTools>()
            {
                new AllowedTools()
                {
                    Mode = ToolChoiceType.Auto,
                    Tools = new List<string>() { "string" },
                },
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Url = "url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<McpServer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_server");
        List<AllowedTools> expectedAllowedTools = new List<AllowedTools>()
        {
            new AllowedTools()
            {
                Mode = ToolChoiceType.Auto,
                Tools = new List<string>() { "string" },
            },
        };
        Dictionary<string, string> expectedHeaders = new() { { "foo", "string" } };
        string expectedName = "name";
        string expectedUrl = "url";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.AllowedTools);
        Assert.Equal(expectedAllowedTools.Count, deserialized.AllowedTools.Count);
        for (int i = 0; i < expectedAllowedTools.Count; i++)
        {
            Assert.Equal(expectedAllowedTools[i], deserialized.AllowedTools[i]);
        }
        Assert.NotNull(deserialized.Headers);
        Assert.Equal(expectedHeaders.Count, deserialized.Headers.Count);
        foreach (var item in expectedHeaders)
        {
            Assert.True(deserialized.Headers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Headers[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUrl, deserialized.Url);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new McpServer
        {
            AllowedTools = new List<AllowedTools>()
            {
                new AllowedTools()
                {
                    Mode = ToolChoiceType.Auto,
                    Tools = new List<string>() { "string" },
                },
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new McpServer { };

        Assert.Null(model.AllowedTools);
        Assert.False(model.RawData.ContainsKey("allowed_tools"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new McpServer { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new McpServer
        {
            // Null should be interpreted as omitted for these properties
            AllowedTools = null,
            Headers = null,
            Name = null,
            Url = null,
        };

        Assert.Null(model.AllowedTools);
        Assert.False(model.RawData.ContainsKey("allowed_tools"));
        Assert.Null(model.Headers);
        Assert.False(model.RawData.ContainsKey("headers"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Url);
        Assert.False(model.RawData.ContainsKey("url"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new McpServer
        {
            // Null should be interpreted as omitted for these properties
            AllowedTools = null,
            Headers = null,
            Name = null,
            Url = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new McpServer
        {
            AllowedTools = new List<AllowedTools>()
            {
                new AllowedTools()
                {
                    Mode = ToolChoiceType.Auto,
                    Tools = new List<string>() { "string" },
                },
            },
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Url = "url",
        };

        McpServer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleSearchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleSearch
        {
            SearchTypes = new List<ApiEnum<string, GoogleSearchSearchType>>()
            {
                GoogleSearchSearchType.WebSearch,
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search");
        List<ApiEnum<string, GoogleSearchSearchType>> expectedSearchTypes = new List<
            ApiEnum<string, GoogleSearchSearchType>
        >()
        {
            GoogleSearchSearchType.WebSearch,
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.SearchTypes);
        Assert.Equal(expectedSearchTypes.Count, model.SearchTypes.Count);
        for (int i = 0; i < expectedSearchTypes.Count; i++)
        {
            Assert.Equal(expectedSearchTypes[i], model.SearchTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleSearch
        {
            SearchTypes = new List<ApiEnum<string, GoogleSearchSearchType>>()
            {
                GoogleSearchSearchType.WebSearch,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleSearch
        {
            SearchTypes = new List<ApiEnum<string, GoogleSearchSearchType>>()
            {
                GoogleSearchSearchType.WebSearch,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleSearch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("google_search");
        List<ApiEnum<string, GoogleSearchSearchType>> expectedSearchTypes = new List<
            ApiEnum<string, GoogleSearchSearchType>
        >()
        {
            GoogleSearchSearchType.WebSearch,
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.SearchTypes);
        Assert.Equal(expectedSearchTypes.Count, deserialized.SearchTypes.Count);
        for (int i = 0; i < expectedSearchTypes.Count; i++)
        {
            Assert.Equal(expectedSearchTypes[i], deserialized.SearchTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleSearch
        {
            SearchTypes = new List<ApiEnum<string, GoogleSearchSearchType>>()
            {
                GoogleSearchSearchType.WebSearch,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleSearch { };

        Assert.Null(model.SearchTypes);
        Assert.False(model.RawData.ContainsKey("search_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleSearch { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleSearch
        {
            // Null should be interpreted as omitted for these properties
            SearchTypes = null,
        };

        Assert.Null(model.SearchTypes);
        Assert.False(model.RawData.ContainsKey("search_types"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleSearch
        {
            // Null should be interpreted as omitted for these properties
            SearchTypes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleSearch
        {
            SearchTypes = new List<ApiEnum<string, GoogleSearchSearchType>>()
            {
                GoogleSearchSearchType.WebSearch,
            },
        };

        GoogleSearch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleSearchSearchTypeTest : TestBase
{
    [Theory]
    [InlineData(GoogleSearchSearchType.WebSearch)]
    [InlineData(GoogleSearchSearchType.ImageSearch)]
    [InlineData(GoogleSearchSearchType.EnterpriseWebSearch)]
    public void Validation_Works(GoogleSearchSearchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GoogleSearchSearchType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GoogleSearchSearchType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GoogleSearchSearchType.WebSearch)]
    [InlineData(GoogleSearchSearchType.ImageSearch)]
    [InlineData(GoogleSearchSearchType.EnterpriseWebSearch)]
    public void SerializationRoundtrip_Works(GoogleSearchSearchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GoogleSearchSearchType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GoogleSearchSearchType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GoogleSearchSearchType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GoogleSearchSearchType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FileSearchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileSearch
        {
            FileSearchStoreNames = new List<string>() { "string" },
            MetadataFilter = "metadata_filter",
            TopK = 0,
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("file_search");
        List<string> expectedFileSearchStoreNames = new List<string>() { "string" };
        string expectedMetadataFilter = "metadata_filter";
        int expectedTopK = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.FileSearchStoreNames);
        Assert.Equal(expectedFileSearchStoreNames.Count, model.FileSearchStoreNames.Count);
        for (int i = 0; i < expectedFileSearchStoreNames.Count; i++)
        {
            Assert.Equal(expectedFileSearchStoreNames[i], model.FileSearchStoreNames[i]);
        }
        Assert.Equal(expectedMetadataFilter, model.MetadataFilter);
        Assert.Equal(expectedTopK, model.TopK);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileSearch
        {
            FileSearchStoreNames = new List<string>() { "string" },
            MetadataFilter = "metadata_filter",
            TopK = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileSearch
        {
            FileSearchStoreNames = new List<string>() { "string" },
            MetadataFilter = "metadata_filter",
            TopK = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileSearch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("file_search");
        List<string> expectedFileSearchStoreNames = new List<string>() { "string" };
        string expectedMetadataFilter = "metadata_filter";
        int expectedTopK = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.FileSearchStoreNames);
        Assert.Equal(expectedFileSearchStoreNames.Count, deserialized.FileSearchStoreNames.Count);
        for (int i = 0; i < expectedFileSearchStoreNames.Count; i++)
        {
            Assert.Equal(expectedFileSearchStoreNames[i], deserialized.FileSearchStoreNames[i]);
        }
        Assert.Equal(expectedMetadataFilter, deserialized.MetadataFilter);
        Assert.Equal(expectedTopK, deserialized.TopK);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileSearch
        {
            FileSearchStoreNames = new List<string>() { "string" },
            MetadataFilter = "metadata_filter",
            TopK = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileSearch { };

        Assert.Null(model.FileSearchStoreNames);
        Assert.False(model.RawData.ContainsKey("file_search_store_names"));
        Assert.Null(model.MetadataFilter);
        Assert.False(model.RawData.ContainsKey("metadata_filter"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileSearch { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileSearch
        {
            // Null should be interpreted as omitted for these properties
            FileSearchStoreNames = null,
            MetadataFilter = null,
            TopK = null,
        };

        Assert.Null(model.FileSearchStoreNames);
        Assert.False(model.RawData.ContainsKey("file_search_store_names"));
        Assert.Null(model.MetadataFilter);
        Assert.False(model.RawData.ContainsKey("metadata_filter"));
        Assert.Null(model.TopK);
        Assert.False(model.RawData.ContainsKey("top_k"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileSearch
        {
            // Null should be interpreted as omitted for these properties
            FileSearchStoreNames = null,
            MetadataFilter = null,
            TopK = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileSearch
        {
            FileSearchStoreNames = new List<string>() { "string" },
            MetadataFilter = "metadata_filter",
            TopK = 0,
        };

        FileSearch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GoogleMapsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GoogleMaps
        {
            EnableWidget = true,
            Latitude = 0,
            Longitude = 0,
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps");
        bool expectedEnableWidget = true;
        double expectedLatitude = 0;
        double expectedLongitude = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedEnableWidget, model.EnableWidget);
        Assert.Equal(expectedLatitude, model.Latitude);
        Assert.Equal(expectedLongitude, model.Longitude);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GoogleMaps
        {
            EnableWidget = true,
            Latitude = 0,
            Longitude = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMaps>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GoogleMaps
        {
            EnableWidget = true,
            Latitude = 0,
            Longitude = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GoogleMaps>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("google_maps");
        bool expectedEnableWidget = true;
        double expectedLatitude = 0;
        double expectedLongitude = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedEnableWidget, deserialized.EnableWidget);
        Assert.Equal(expectedLatitude, deserialized.Latitude);
        Assert.Equal(expectedLongitude, deserialized.Longitude);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GoogleMaps
        {
            EnableWidget = true,
            Latitude = 0,
            Longitude = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GoogleMaps { };

        Assert.Null(model.EnableWidget);
        Assert.False(model.RawData.ContainsKey("enable_widget"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GoogleMaps { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GoogleMaps
        {
            // Null should be interpreted as omitted for these properties
            EnableWidget = null,
            Latitude = null,
            Longitude = null,
        };

        Assert.Null(model.EnableWidget);
        Assert.False(model.RawData.ContainsKey("enable_widget"));
        Assert.Null(model.Latitude);
        Assert.False(model.RawData.ContainsKey("latitude"));
        Assert.Null(model.Longitude);
        Assert.False(model.RawData.ContainsKey("longitude"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GoogleMaps
        {
            // Null should be interpreted as omitted for these properties
            EnableWidget = null,
            Latitude = null,
            Longitude = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GoogleMaps
        {
            EnableWidget = true,
            Latitude = 0,
            Longitude = 0,
        };

        GoogleMaps copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RetrievalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Retrieval
        {
            RetrievalTypes = new List<ApiEnum<string, RetrievalType>>()
            {
                RetrievalType.VertexAISearch,
            },
            VertexAISearchConfig = new()
            {
                Datastores = new List<string>() { "string" },
                Engine = "engine",
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("retrieval");
        List<ApiEnum<string, RetrievalType>> expectedRetrievalTypes = new List<
            ApiEnum<string, RetrievalType>
        >()
        {
            RetrievalType.VertexAISearch,
        };
        VertexAISearchConfig expectedVertexAISearchConfig = new()
        {
            Datastores = new List<string>() { "string" },
            Engine = "engine",
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.RetrievalTypes);
        Assert.Equal(expectedRetrievalTypes.Count, model.RetrievalTypes.Count);
        for (int i = 0; i < expectedRetrievalTypes.Count; i++)
        {
            Assert.Equal(expectedRetrievalTypes[i], model.RetrievalTypes[i]);
        }
        Assert.Equal(expectedVertexAISearchConfig, model.VertexAISearchConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Retrieval
        {
            RetrievalTypes = new List<ApiEnum<string, RetrievalType>>()
            {
                RetrievalType.VertexAISearch,
            },
            VertexAISearchConfig = new()
            {
                Datastores = new List<string>() { "string" },
                Engine = "engine",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Retrieval>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Retrieval
        {
            RetrievalTypes = new List<ApiEnum<string, RetrievalType>>()
            {
                RetrievalType.VertexAISearch,
            },
            VertexAISearchConfig = new()
            {
                Datastores = new List<string>() { "string" },
                Engine = "engine",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Retrieval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("retrieval");
        List<ApiEnum<string, RetrievalType>> expectedRetrievalTypes = new List<
            ApiEnum<string, RetrievalType>
        >()
        {
            RetrievalType.VertexAISearch,
        };
        VertexAISearchConfig expectedVertexAISearchConfig = new()
        {
            Datastores = new List<string>() { "string" },
            Engine = "engine",
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.RetrievalTypes);
        Assert.Equal(expectedRetrievalTypes.Count, deserialized.RetrievalTypes.Count);
        for (int i = 0; i < expectedRetrievalTypes.Count; i++)
        {
            Assert.Equal(expectedRetrievalTypes[i], deserialized.RetrievalTypes[i]);
        }
        Assert.Equal(expectedVertexAISearchConfig, deserialized.VertexAISearchConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Retrieval
        {
            RetrievalTypes = new List<ApiEnum<string, RetrievalType>>()
            {
                RetrievalType.VertexAISearch,
            },
            VertexAISearchConfig = new()
            {
                Datastores = new List<string>() { "string" },
                Engine = "engine",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Retrieval { };

        Assert.Null(model.RetrievalTypes);
        Assert.False(model.RawData.ContainsKey("retrieval_types"));
        Assert.Null(model.VertexAISearchConfig);
        Assert.False(model.RawData.ContainsKey("vertex_ai_search_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Retrieval { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Retrieval
        {
            // Null should be interpreted as omitted for these properties
            RetrievalTypes = null,
            VertexAISearchConfig = null,
        };

        Assert.Null(model.RetrievalTypes);
        Assert.False(model.RawData.ContainsKey("retrieval_types"));
        Assert.Null(model.VertexAISearchConfig);
        Assert.False(model.RawData.ContainsKey("vertex_ai_search_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Retrieval
        {
            // Null should be interpreted as omitted for these properties
            RetrievalTypes = null,
            VertexAISearchConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Retrieval
        {
            RetrievalTypes = new List<ApiEnum<string, RetrievalType>>()
            {
                RetrievalType.VertexAISearch,
            },
            VertexAISearchConfig = new()
            {
                Datastores = new List<string>() { "string" },
                Engine = "engine",
            },
        };

        Retrieval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RetrievalTypeTest : TestBase
{
    [Theory]
    [InlineData(RetrievalType.VertexAISearch)]
    public void Validation_Works(RetrievalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetrievalType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetrievalType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RetrievalType.VertexAISearch)]
    public void SerializationRoundtrip_Works(RetrievalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetrievalType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetrievalType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetrievalType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetrievalType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VertexAISearchConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VertexAISearchConfig
        {
            Datastores = new List<string>() { "string" },
            Engine = "engine",
        };

        List<string> expectedDatastores = new List<string>() { "string" };
        string expectedEngine = "engine";

        Assert.NotNull(model.Datastores);
        Assert.Equal(expectedDatastores.Count, model.Datastores.Count);
        for (int i = 0; i < expectedDatastores.Count; i++)
        {
            Assert.Equal(expectedDatastores[i], model.Datastores[i]);
        }
        Assert.Equal(expectedEngine, model.Engine);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VertexAISearchConfig
        {
            Datastores = new List<string>() { "string" },
            Engine = "engine",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VertexAISearchConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VertexAISearchConfig
        {
            Datastores = new List<string>() { "string" },
            Engine = "engine",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VertexAISearchConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedDatastores = new List<string>() { "string" };
        string expectedEngine = "engine";

        Assert.NotNull(deserialized.Datastores);
        Assert.Equal(expectedDatastores.Count, deserialized.Datastores.Count);
        for (int i = 0; i < expectedDatastores.Count; i++)
        {
            Assert.Equal(expectedDatastores[i], deserialized.Datastores[i]);
        }
        Assert.Equal(expectedEngine, deserialized.Engine);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VertexAISearchConfig
        {
            Datastores = new List<string>() { "string" },
            Engine = "engine",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VertexAISearchConfig { };

        Assert.Null(model.Datastores);
        Assert.False(model.RawData.ContainsKey("datastores"));
        Assert.Null(model.Engine);
        Assert.False(model.RawData.ContainsKey("engine"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VertexAISearchConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VertexAISearchConfig
        {
            // Null should be interpreted as omitted for these properties
            Datastores = null,
            Engine = null,
        };

        Assert.Null(model.Datastores);
        Assert.False(model.RawData.ContainsKey("datastores"));
        Assert.Null(model.Engine);
        Assert.False(model.RawData.ContainsKey("engine"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VertexAISearchConfig
        {
            // Null should be interpreted as omitted for these properties
            Datastores = null,
            Engine = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VertexAISearchConfig
        {
            Datastores = new List<string>() { "string" },
            Engine = "engine",
        };

        VertexAISearchConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
