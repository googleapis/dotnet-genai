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

using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// A tool that can be used by the model.
/// </summary>
[JsonConverter(typeof(ToolConverter))]
public record class Tool : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Type
    {
        get
        {
            return Match<JsonElement?>(
                function: (x) => x.Type,
                codeExecution: (_) => null,
                urlContext: (_) => null,
                computerUse: (x) => x.Type,
                mcpServer: (x) => x.Type,
                googleSearch: (x) => x.Type,
                fileSearch: (x) => x.Type,
                googleMaps: (x) => x.Type,
                retrieval: (x) => x.Type
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                function: (x) => x.Name,
                codeExecution: (_) => null,
                urlContext: (_) => null,
                computerUse: (_) => null,
                mcpServer: (x) => x.Name,
                googleSearch: (_) => null,
                fileSearch: (_) => null,
                googleMaps: (_) => null,
                retrieval: (_) => null
            );
        }
    }

    public Tool(Function value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(CodeExecution value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(UrlContext value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(ComputerUse value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(McpServer value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(GoogleSearch value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(FileSearch value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(GoogleMaps value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(Retrieval value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Function"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunction(out var value)) {
    ///     // `value` is of type `Function`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunction([NotNullWhen(true)] out Function? value)
    {
        value = this.Value as Function;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecution"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecution(out var value)) {
    ///     // `value` is of type `CodeExecution`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecution([NotNullWhen(true)] out CodeExecution? value)
    {
        value = this.Value as CodeExecution;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlContext"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlContext(out var value)) {
    ///     // `value` is of type `UrlContext`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlContext([NotNullWhen(true)] out UrlContext? value)
    {
        value = this.Value as UrlContext;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerUse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickComputerUse(out var value)) {
    ///     // `value` is of type `ComputerUse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickComputerUse([NotNullWhen(true)] out ComputerUse? value)
    {
        value = this.Value as ComputerUse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="McpServer"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServer(out var value)) {
    ///     // `value` is of type `McpServer`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServer([NotNullWhen(true)] out McpServer? value)
    {
        value = this.Value as McpServer;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleSearch"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleSearch(out var value)) {
    ///     // `value` is of type `GoogleSearch`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleSearch([NotNullWhen(true)] out GoogleSearch? value)
    {
        value = this.Value as GoogleSearch;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileSearch"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileSearch(out var value)) {
    ///     // `value` is of type `FileSearch`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileSearch([NotNullWhen(true)] out FileSearch? value)
    {
        value = this.Value as FileSearch;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleMaps"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleMaps(out var value)) {
    ///     // `value` is of type `GoogleMaps`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleMaps([NotNullWhen(true)] out GoogleMaps? value)
    {
        value = this.Value as GoogleMaps;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Retrieval"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRetrieval(out var value)) {
    ///     // `value` is of type `Retrieval`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRetrieval([NotNullWhen(true)] out Retrieval? value)
    {
        value = this.Value as Retrieval;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Function value) =&gt; {...},
    ///     (CodeExecution value) =&gt; {...},
    ///     (UrlContext value) =&gt; {...},
    ///     (ComputerUse value) =&gt; {...},
    ///     (McpServer value) =&gt; {...},
    ///     (GoogleSearch value) =&gt; {...},
    ///     (FileSearch value) =&gt; {...},
    ///     (GoogleMaps value) =&gt; {...},
    ///     (Retrieval value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Function> function,
        Action<CodeExecution> codeExecution,
        Action<UrlContext> urlContext,
        Action<ComputerUse> computerUse,
        Action<McpServer> mcpServer,
        Action<GoogleSearch> googleSearch,
        Action<FileSearch> fileSearch,
        Action<GoogleMaps> googleMaps,
        Action<Retrieval> retrieval
    )
    {
        switch (this.Value)
        {
            case Function value:
                function(value);
                break;
            case CodeExecution value:
                codeExecution(value);
                break;
            case UrlContext value:
                urlContext(value);
                break;
            case ComputerUse value:
                computerUse(value);
                break;
            case McpServer value:
                mcpServer(value);
                break;
            case GoogleSearch value:
                googleSearch(value);
                break;
            case FileSearch value:
                fileSearch(value);
                break;
            case GoogleMaps value:
                googleMaps(value);
                break;
            case Retrieval value:
                retrieval(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of Tool"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Function value) =&gt; {...},
    ///     (CodeExecution value) =&gt; {...},
    ///     (UrlContext value) =&gt; {...},
    ///     (ComputerUse value) =&gt; {...},
    ///     (McpServer value) =&gt; {...},
    ///     (GoogleSearch value) =&gt; {...},
    ///     (FileSearch value) =&gt; {...},
    ///     (GoogleMaps value) =&gt; {...},
    ///     (Retrieval value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Function, T> function,
        Func<CodeExecution, T> codeExecution,
        Func<UrlContext, T> urlContext,
        Func<ComputerUse, T> computerUse,
        Func<McpServer, T> mcpServer,
        Func<GoogleSearch, T> googleSearch,
        Func<FileSearch, T> fileSearch,
        Func<GoogleMaps, T> googleMaps,
        Func<Retrieval, T> retrieval
    )
    {
        return this.Value switch
        {
            Function value => function(value),
            CodeExecution value => codeExecution(value),
            UrlContext value => urlContext(value),
            ComputerUse value => computerUse(value),
            McpServer value => mcpServer(value),
            GoogleSearch value => googleSearch(value),
            FileSearch value => fileSearch(value),
            GoogleMaps value => googleMaps(value),
            Retrieval value => retrieval(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of Tool"
            ),
        };
    }

    public static implicit operator Tool(Function value) => new(value);

    public static implicit operator Tool(CodeExecution value) => new(value);

    public static implicit operator Tool(UrlContext value) => new(value);

    public static implicit operator Tool(ComputerUse value) => new(value);

    public static implicit operator Tool(McpServer value) => new(value);

    public static implicit operator Tool(GoogleSearch value) => new(value);

    public static implicit operator Tool(FileSearch value) => new(value);

    public static implicit operator Tool(GoogleMaps value) => new(value);

    public static implicit operator Tool(Retrieval value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of Tool"
            );
        }
        this.Switch(
            (function) => function.Validate(),
            (codeExecution) => codeExecution.Validate(),
            (urlContext) => urlContext.Validate(),
            (computerUse) => computerUse.Validate(),
            (mcpServer) => mcpServer.Validate(),
            (googleSearch) => googleSearch.Validate(),
            (fileSearch) => fileSearch.Validate(),
            (googleMaps) => googleMaps.Validate(),
            (retrieval) => retrieval.Validate()
        );
    }

    public virtual bool Equals(Tool? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Function _ => 0,
            CodeExecution _ => 1,
            UrlContext _ => 2,
            ComputerUse _ => 3,
            McpServer _ => 4,
            GoogleSearch _ => 5,
            FileSearch _ => 6,
            GoogleMaps _ => 7,
            Retrieval _ => 8,
            _ => -1,
        };
    }
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "function":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Function>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeExecution>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "url_context":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UrlContext>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "computer_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ComputerUse>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "mcp_server":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<McpServer>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "google_search":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleSearch>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "file_search":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileSearch>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "google_maps":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleMaps>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "retrieval":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Retrieval>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Tool(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A tool that can be used by the model to execute code.
/// </summary>
[JsonConverter(typeof(CodeExecutionConverter))]
public record class CodeExecution
{
    public JsonElement Element { get; private init; }

    public CodeExecution()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            @"{
              ""type"": ""code_execution""
            }"
        );
    }

    internal CodeExecution(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new CodeExecution())
        {
            throw new GeminiNextGenApiInvalidDataException(
                "Invalid value given for 'CodeExecution'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(CodeExecution? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class CodeExecutionConverter : JsonConverter<CodeExecution>
{
    public override CodeExecution? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        CodeExecution value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// A tool that can be used by the model to fetch URL context.
/// </summary>
[JsonConverter(typeof(UrlContextConverter))]
public record class UrlContext
{
    public JsonElement Element { get; private init; }

    public UrlContext()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            @"{
              ""type"": ""url_context""
            }"
        );
    }

    internal UrlContext(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="GeminiNextGenApiInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new UrlContext())
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for 'UrlContext'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UrlContext? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UrlContextConverter : JsonConverter<UrlContext>
{
    public override UrlContext? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlContext value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// A tool that can be used by the model to interact with the computer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerUse, ComputerUseFromRaw>))]
public sealed record class ComputerUse : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The environment being operated.
    /// </summary>
    public ApiEnum<string, global::Google.GenAI.Interactions.Models.Interactions.Environment>? Environment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Google.GenAI.Interactions.Models.Interactions.Environment>
            >("environment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("environment", value);
        }
    }

    /// <summary>
    /// The list of predefined functions that are excluded from the model call.
    /// </summary>
    public IReadOnlyList<string>? ExcludedPredefinedFunctions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excludedPredefinedFunctions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excludedPredefinedFunctions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("computer_use")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        this.Environment?.Validate();
        _ = this.ExcludedPredefinedFunctions;
    }

    public ComputerUse()
    {
        this.Type = JsonSerializer.SerializeToElement("computer_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerUse(ComputerUse computerUse)
        : base(computerUse) { }
#pragma warning restore CS8618

    public ComputerUse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("computer_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerUse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerUseFromRaw.FromRawUnchecked"/>
    public static ComputerUse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerUseFromRaw : IFromRawJson<ComputerUse>
{
    /// <inheritdoc/>
    public ComputerUse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComputerUse.FromRawUnchecked(rawData);
}

/// <summary>
/// The environment being operated.
/// </summary>
[JsonConverter(typeof(EnvironmentConverter))]
public enum Environment
{
    Browser,
}

sealed class EnvironmentConverter
    : JsonConverter<global::Google.GenAI.Interactions.Models.Interactions.Environment>
{
    public override global::Google.GenAI.Interactions.Models.Interactions.Environment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "browser" => global::Google.GenAI.Interactions.Models.Interactions.Environment.Browser,
            _ => (global::Google.GenAI.Interactions.Models.Interactions.Environment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Google.GenAI.Interactions.Models.Interactions.Environment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Google.GenAI.Interactions.Models.Interactions.Environment.Browser => "browser",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A MCPServer is a server that can be called by the model to perform actions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<McpServer, McpServerFromRaw>))]
public sealed record class McpServer : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The allowed tools.
    /// </summary>
    public IReadOnlyList<AllowedTools>? AllowedTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AllowedTools>>("allowed_tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AllowedTools>?>(
                "allowed_tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional: Fields for authentication headers, timeouts, etc., if needed.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The name of the MCPServer.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The full URL for the MCPServer endpoint. Example: "https://api.example.com/mcp"
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mcp_server")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedTools ?? Enumerable.Empty<AllowedTools>())
        {
            item.Validate();
        }
        _ = this.Headers;
        _ = this.Name;
        _ = this.Url;
    }

    public McpServer()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_server");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServer(McpServer mcpServer)
        : base(mcpServer) { }
#pragma warning restore CS8618

    public McpServer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_server");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpServerFromRaw.FromRawUnchecked"/>
    public static McpServer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class McpServerFromRaw : IFromRawJson<McpServer>
{
    /// <inheritdoc/>
    public McpServer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpServer.FromRawUnchecked(rawData);
}

/// <summary>
/// A tool that can be used by the model to search Google.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GoogleSearch, GoogleSearchFromRaw>))]
public sealed record class GoogleSearch : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The types of search grounding to enable.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, GoogleSearchSearchType>>? SearchTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, GoogleSearchSearchType>>
            >("search_types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, GoogleSearchSearchType>>?>(
                "search_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("google_search")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        foreach (
            var item in this.SearchTypes
                ?? Enumerable.Empty<ApiEnum<string, GoogleSearchSearchType>>()
        )
        {
            item.Validate();
        }
    }

    public GoogleSearch()
    {
        this.Type = JsonSerializer.SerializeToElement("google_search");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleSearch(GoogleSearch googleSearch)
        : base(googleSearch) { }
#pragma warning restore CS8618

    public GoogleSearch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_search");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleSearch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleSearchFromRaw.FromRawUnchecked"/>
    public static GoogleSearch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleSearchFromRaw : IFromRawJson<GoogleSearch>
{
    /// <inheritdoc/>
    public GoogleSearch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleSearch.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(GoogleSearchSearchTypeConverter))]
public enum GoogleSearchSearchType
{
    WebSearch,
    ImageSearch,
    EnterpriseWebSearch,
}

sealed class GoogleSearchSearchTypeConverter : JsonConverter<GoogleSearchSearchType>
{
    public override GoogleSearchSearchType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "web_search" => GoogleSearchSearchType.WebSearch,
            "image_search" => GoogleSearchSearchType.ImageSearch,
            "enterprise_web_search" => GoogleSearchSearchType.EnterpriseWebSearch,
            _ => (GoogleSearchSearchType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GoogleSearchSearchType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GoogleSearchSearchType.WebSearch => "web_search",
                GoogleSearchSearchType.ImageSearch => "image_search",
                GoogleSearchSearchType.EnterpriseWebSearch => "enterprise_web_search",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A tool that can be used by the model to search files.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileSearch, FileSearchFromRaw>))]
public sealed record class FileSearch : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The file search store names to search.
    /// </summary>
    public IReadOnlyList<string>? FileSearchStoreNames
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "file_search_store_names"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "file_search_store_names",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Metadata filter to apply to the semantic retrieval documents and chunks.
    /// </summary>
    public string? MetadataFilter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("metadata_filter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata_filter", value);
        }
    }

    /// <summary>
    /// The number of semantic retrieval chunks to retrieve.
    /// </summary>
    public int? TopK
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("top_k");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("top_k", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file_search")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.FileSearchStoreNames;
        _ = this.MetadataFilter;
        _ = this.TopK;
    }

    public FileSearch()
    {
        this.Type = JsonSerializer.SerializeToElement("file_search");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileSearch(FileSearch fileSearch)
        : base(fileSearch) { }
#pragma warning restore CS8618

    public FileSearch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file_search");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileSearch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileSearchFromRaw.FromRawUnchecked"/>
    public static FileSearch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileSearchFromRaw : IFromRawJson<FileSearch>
{
    /// <inheritdoc/>
    public FileSearch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileSearch.FromRawUnchecked(rawData);
}

/// <summary>
/// A tool that can be used by the model to call Google Maps.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GoogleMaps, GoogleMapsFromRaw>))]
public sealed record class GoogleMaps : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether to return a widget context token in the tool call result of the response.
    /// </summary>
    public bool? EnableWidget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enable_widget");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("enable_widget", value);
        }
    }

    /// <summary>
    /// The latitude of the user's location.
    /// </summary>
    public double? Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("latitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("latitude", value);
        }
    }

    /// <summary>
    /// The longitude of the user's location.
    /// </summary>
    public double? Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("longitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("longitude", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("google_maps")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.EnableWidget;
        _ = this.Latitude;
        _ = this.Longitude;
    }

    public GoogleMaps()
    {
        this.Type = JsonSerializer.SerializeToElement("google_maps");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleMaps(GoogleMaps googleMaps)
        : base(googleMaps) { }
#pragma warning restore CS8618

    public GoogleMaps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_maps");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleMaps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleMapsFromRaw.FromRawUnchecked"/>
    public static GoogleMaps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleMapsFromRaw : IFromRawJson<GoogleMaps>
{
    /// <inheritdoc/>
    public GoogleMaps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleMaps.FromRawUnchecked(rawData);
}

/// <summary>
/// A tool that can be used by the model to retrieve files.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Retrieval, RetrievalFromRaw>))]
public sealed record class Retrieval : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The types of file retrieval to enable.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, RetrievalType>>? RetrievalTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, RetrievalType>>>(
                "retrieval_types"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, RetrievalType>>?>(
                "retrieval_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Used to specify configuration for VertexAISearch.
    /// </summary>
    public VertexAISearchConfig? VertexAISearchConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VertexAISearchConfig>("vertex_ai_search_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vertex_ai_search_config", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("retrieval")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        foreach (
            var item in this.RetrievalTypes ?? Enumerable.Empty<ApiEnum<string, RetrievalType>>()
        )
        {
            item.Validate();
        }
        this.VertexAISearchConfig?.Validate();
    }

    public Retrieval()
    {
        this.Type = JsonSerializer.SerializeToElement("retrieval");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Retrieval(Retrieval retrieval)
        : base(retrieval) { }
#pragma warning restore CS8618

    public Retrieval(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("retrieval");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Retrieval(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalFromRaw.FromRawUnchecked"/>
    public static Retrieval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RetrievalFromRaw : IFromRawJson<Retrieval>
{
    /// <inheritdoc/>
    public Retrieval FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Retrieval.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RetrievalTypeConverter))]
public enum RetrievalType
{
    VertexAISearch,
}

sealed class RetrievalTypeConverter : JsonConverter<RetrievalType>
{
    public override RetrievalType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vertex_ai_search" => RetrievalType.VertexAISearch,
            _ => (RetrievalType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetrievalType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetrievalType.VertexAISearch => "vertex_ai_search",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Used to specify configuration for VertexAISearch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VertexAISearchConfig, VertexAISearchConfigFromRaw>))]
public sealed record class VertexAISearchConfig : JsonModel
{
    /// <summary>
    /// Optional. Used to specify Vertex AI Search datastores.
    /// </summary>
    public IReadOnlyList<string>? Datastores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("datastores");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "datastores",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional. Used to specify Vertex AI Search engine.
    /// </summary>
    public string? Engine
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("engine");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("engine", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Datastores;
        _ = this.Engine;
    }

    public VertexAISearchConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VertexAISearchConfig(VertexAISearchConfig vertexAISearchConfig)
        : base(vertexAISearchConfig) { }
#pragma warning restore CS8618

    public VertexAISearchConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VertexAISearchConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VertexAISearchConfigFromRaw.FromRawUnchecked"/>
    public static VertexAISearchConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VertexAISearchConfigFromRaw : IFromRawJson<VertexAISearchConfig>
{
    /// <inheritdoc/>
    public VertexAISearchConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VertexAISearchConfig.FromRawUnchecked(rawData);
}
