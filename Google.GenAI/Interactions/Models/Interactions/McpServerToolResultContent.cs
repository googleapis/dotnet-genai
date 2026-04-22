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
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// MCPServer tool result content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<McpServerToolResultContent, McpServerToolResultContentFromRaw>)
)]
public sealed record class McpServerToolResultContent : JsonModel
{
    /// <summary>
    /// Required. ID to match the ID from the function call block.
    /// </summary>
    public string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("call_id");
        }
        init { this._rawData.Set("call_id", value); }
    }

    /// <summary>
    /// The output from the MCP server call. Can be simple text or rich content.
    /// </summary>
    public McpServerToolResultContentResult Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<McpServerToolResultContentResult>("result");
        }
        init { this._rawData.Set("result", value); }
    }

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
    /// Name of the tool which is called for this specific tool call.
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
    /// The name of the used MCP server.
    /// </summary>
    public string? ServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("server_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("server_name", value);
        }
    }

    /// <summary>
    /// A signature hash for backend validation.
    /// </summary>
    public string? Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signature", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallID;
        this.Result.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("mcp_server_tool_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Name;
        _ = this.ServerName;
        _ = this.Signature;
    }

    public McpServerToolResultContent()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_server_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServerToolResultContent(McpServerToolResultContent mcpServerToolResultContent)
        : base(mcpServerToolResultContent) { }
#pragma warning restore CS8618

    public McpServerToolResultContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_server_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServerToolResultContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpServerToolResultContentFromRaw.FromRawUnchecked"/>
    public static McpServerToolResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class McpServerToolResultContentFromRaw : IFromRawJson<McpServerToolResultContent>
{
    /// <inheritdoc/>
    public McpServerToolResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => McpServerToolResultContent.FromRawUnchecked(rawData);
}

/// <summary>
/// The output from the MCP server call. Can be simple text or rich content.
/// </summary>
[JsonConverter(typeof(McpServerToolResultContentResultConverter))]
public record class McpServerToolResultContentResult : ModelBase
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

    public McpServerToolResultContentResult(
        IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public McpServerToolResultContentResult(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public McpServerToolResultContentResult(JsonElement element)
    {
        this._element = element;
        this.Value = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JsonElement"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElement(out var value)) {
    ///     // `value` is of type `JsonElement`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElement([NotNullWhen(true)] out JsonElement? value)
    {
        value = this.Value as JsonElement?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>McpServerToolResultContentResultFunctionResultSubcontent</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionResultSubcontentList(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;McpServerToolResultContentResultFunctionResultSubcontent&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionResultSubcontentList(
        [NotNullWhen(true)]
            out IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent>? value
    )
    {
        value =
            this.Value as IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
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
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;McpServerToolResultContentResultFunctionResultSubcontent&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<JsonElement> jsonElement,
        Action<
            IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent>
        > functionResultSubcontentList,
        Action<string> @string
    )
    {
        switch (this.Value)
        {
            case JsonElement value:
                jsonElement(value);
                break;
            case IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent> value:
                functionResultSubcontentList(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of McpServerToolResultContentResult"
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
    ///     (JsonElement value) =&gt; {...},
    ///     (IReadOnlyList&lt;McpServerToolResultContentResultFunctionResultSubcontent&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<JsonElement, T> jsonElement,
        Func<
            IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent>,
            T
        > functionResultSubcontentList,
        Func<string, T> @string
    )
    {
        return this.Value switch
        {
            JsonElement value => jsonElement(value),
            IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent> value =>
                functionResultSubcontentList(value),
            string value => @string(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of McpServerToolResultContentResult"
            ),
        };
    }

    public static implicit operator McpServerToolResultContentResult(JsonElement value) =>
        new(value);

    public static implicit operator McpServerToolResultContentResult(
        List<McpServerToolResultContentResultFunctionResultSubcontent> value
    ) => new((IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent>)value);

    public static implicit operator McpServerToolResultContentResult(string value) => new(value);

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
                "Data did not match any variant of McpServerToolResultContentResult"
            );
        }
        this.Switch(
            (_) => { },
            (functionResultSubcontentList) =>
            {
                foreach (var item in functionResultSubcontentList)
                {
                    item.Validate();
                }
            },
            (_) => { }
        );
    }

    public virtual bool Equals(McpServerToolResultContentResult? other) =>
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
            JsonElement _ => 0,
            IReadOnlyList<McpServerToolResultContentResultFunctionResultSubcontent> _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class McpServerToolResultContentResultConverter
    : JsonConverter<McpServerToolResultContentResult>
{
    public override McpServerToolResultContentResult? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<McpServerToolResultContentResultFunctionResultSubcontent>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<JsonElement>(element, options));
        }
        catch (Exception e) when (e is JsonException || e is GeminiNextGenApiInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        McpServerToolResultContentResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A text content block.
/// </summary>
[JsonConverter(typeof(McpServerToolResultContentResultFunctionResultSubcontentConverter))]
public record class McpServerToolResultContentResultFunctionResultSubcontent : ModelBase
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

    public JsonElement Type
    {
        get { return Match(textContent: (x) => x.Type, imageContent: (x) => x.Type); }
    }

    public McpServerToolResultContentResultFunctionResultSubcontent(
        TextContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public McpServerToolResultContentResultFunctionResultSubcontent(
        ImageContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public McpServerToolResultContentResultFunctionResultSubcontent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextContent(out var value)) {
    ///     // `value` is of type `TextContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextContent([NotNullWhen(true)] out TextContent? value)
    {
        value = this.Value as TextContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ImageContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImageContent(out var value)) {
    ///     // `value` is of type `ImageContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImageContent([NotNullWhen(true)] out ImageContent? value)
    {
        value = this.Value as ImageContent;
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
    ///     (TextContent value) =&gt; {...},
    ///     (ImageContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<TextContent> textContent, Action<ImageContent> imageContent)
    {
        switch (this.Value)
        {
            case TextContent value:
                textContent(value);
                break;
            case ImageContent value:
                imageContent(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of McpServerToolResultContentResultFunctionResultSubcontent"
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
    ///     (TextContent value) =&gt; {...},
    ///     (ImageContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<TextContent, T> textContent, Func<ImageContent, T> imageContent)
    {
        return this.Value switch
        {
            TextContent value => textContent(value),
            ImageContent value => imageContent(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of McpServerToolResultContentResultFunctionResultSubcontent"
            ),
        };
    }

    public static implicit operator McpServerToolResultContentResultFunctionResultSubcontent(
        TextContent value
    ) => new(value);

    public static implicit operator McpServerToolResultContentResultFunctionResultSubcontent(
        ImageContent value
    ) => new(value);

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
                "Data did not match any variant of McpServerToolResultContentResultFunctionResultSubcontent"
            );
        }
        this.Switch(
            (textContent) => textContent.Validate(),
            (imageContent) => imageContent.Validate()
        );
    }

    public virtual bool Equals(McpServerToolResultContentResultFunctionResultSubcontent? other) =>
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
            TextContent _ => 0,
            ImageContent _ => 1,
            _ => -1,
        };
    }
}

sealed class McpServerToolResultContentResultFunctionResultSubcontentConverter
    : JsonConverter<McpServerToolResultContentResultFunctionResultSubcontent>
{
    public override McpServerToolResultContentResultFunctionResultSubcontent? Read(
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
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextContent>(element, options);
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
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageContent>(element, options);
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
                return new McpServerToolResultContentResultFunctionResultSubcontent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        McpServerToolResultContentResultFunctionResultSubcontent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
