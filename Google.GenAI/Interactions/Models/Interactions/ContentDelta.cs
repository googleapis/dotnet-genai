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

[JsonConverter(typeof(JsonModelConverter<ContentDelta, ContentDeltaFromRaw>))]
public sealed record class ContentDelta : JsonModel
{
    /// <summary>
    /// The delta content data for a content block.
    /// </summary>
    public Delta Delta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Delta>("delta");
        }
        init { this._rawData.Set("delta", value); }
    }

    public JsonElement EventType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("event_type");
        }
        init { this._rawData.Set("event_type", value); }
    }

    public int Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("index");
        }
        init { this._rawData.Set("index", value); }
    }

    /// <summary>
    /// The event_id token to be used to resume the interaction stream, from this event.
    /// </summary>
    public string? EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Delta.Validate();
        if (
            !JsonElement.DeepEquals(
                this.EventType,
                JsonSerializer.SerializeToElement("content.delta")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Index;
        _ = this.EventID;
    }

    public ContentDelta()
    {
        this.EventType = JsonSerializer.SerializeToElement("content.delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContentDelta(ContentDelta contentDelta)
        : base(contentDelta) { }
#pragma warning restore CS8618

    public ContentDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.EventType = JsonSerializer.SerializeToElement("content.delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContentDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContentDeltaFromRaw.FromRawUnchecked"/>
    public static ContentDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentDeltaFromRaw : IFromRawJson<ContentDelta>
{
    /// <inheritdoc/>
    public ContentDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContentDelta.FromRawUnchecked(rawData);
}

/// <summary>
/// The delta content data for a content block.
/// </summary>
[JsonConverter(typeof(DeltaConverter))]
public record class Delta : ModelBase
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
        get
        {
            return Match(
                text: (x) => x.Type,
                image: (x) => x.Type,
                audio: (x) => x.Type,
                document: (x) => x.Type,
                video: (x) => x.Type,
                thoughtSummary: (x) => x.Type,
                thoughtSignature: (x) => x.Type,
                functionCall: (x) => x.Type,
                codeExecutionCall: (x) => x.Type,
                urlContextCall: (x) => x.Type,
                googleSearchCall: (x) => x.Type,
                mcpServerToolCall: (x) => x.Type,
                fileSearchCall: (x) => x.Type,
                googleMapsCall: (x) => x.Type,
                functionResult: (x) => x.Type,
                codeExecutionResult: (x) => x.Type,
                urlContextResult: (x) => x.Type,
                googleSearchResult: (x) => x.Type,
                mcpServerToolResult: (x) => x.Type,
                fileSearchResult: (x) => x.Type,
                googleMapsResult: (x) => x.Type,
                textAnnotation: (x) => x.Type
            );
        }
    }

    public string? Data
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (x) => x.Data,
                audio: (x) => x.Data,
                document: (x) => x.Data,
                video: (x) => x.Data,
                thoughtSummary: (_) => null,
                thoughtSignature: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                googleSearchCall: (_) => null,
                mcpServerToolCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null,
                textAnnotation: (_) => null
            );
        }
    }

    public string? Uri
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (x) => x.Uri,
                audio: (x) => x.Uri,
                document: (x) => x.Uri,
                video: (x) => x.Uri,
                thoughtSummary: (_) => null,
                thoughtSignature: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                googleSearchCall: (_) => null,
                mcpServerToolCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null,
                textAnnotation: (_) => null
            );
        }
    }

    public string? Signature
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                audio: (_) => null,
                document: (_) => null,
                video: (_) => null,
                thoughtSummary: (_) => null,
                thoughtSignature: (x) => x.Signature,
                functionCall: (x) => x.Signature,
                codeExecutionCall: (x) => x.Signature,
                urlContextCall: (x) => x.Signature,
                googleSearchCall: (x) => x.Signature,
                mcpServerToolCall: (x) => x.Signature,
                fileSearchCall: (x) => x.Signature,
                googleMapsCall: (x) => x.Signature,
                functionResult: (x) => x.Signature,
                codeExecutionResult: (x) => x.Signature,
                urlContextResult: (x) => x.Signature,
                googleSearchResult: (x) => x.Signature,
                mcpServerToolResult: (x) => x.Signature,
                fileSearchResult: (x) => x.Signature,
                googleMapsResult: (x) => x.Signature,
                textAnnotation: (_) => null
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                audio: (_) => null,
                document: (_) => null,
                video: (_) => null,
                thoughtSummary: (_) => null,
                thoughtSignature: (_) => null,
                functionCall: (x) => x.ID,
                codeExecutionCall: (x) => x.ID,
                urlContextCall: (x) => x.ID,
                googleSearchCall: (x) => x.ID,
                mcpServerToolCall: (x) => x.ID,
                fileSearchCall: (x) => x.ID,
                googleMapsCall: (x) => x.ID,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null,
                textAnnotation: (_) => null
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                audio: (_) => null,
                document: (_) => null,
                video: (_) => null,
                thoughtSummary: (_) => null,
                thoughtSignature: (_) => null,
                functionCall: (x) => x.Name,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                googleSearchCall: (_) => null,
                mcpServerToolCall: (x) => x.Name,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (x) => x.Name,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (x) => x.Name,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null,
                textAnnotation: (_) => null
            );
        }
    }

    public string? ServerName
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                audio: (_) => null,
                document: (_) => null,
                video: (_) => null,
                thoughtSummary: (_) => null,
                thoughtSignature: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                googleSearchCall: (_) => null,
                mcpServerToolCall: (x) => x.ServerName,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (x) => x.ServerName,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null,
                textAnnotation: (_) => null
            );
        }
    }

    public string? CallID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (_) => null,
                audio: (_) => null,
                document: (_) => null,
                video: (_) => null,
                thoughtSummary: (_) => null,
                thoughtSignature: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                googleSearchCall: (_) => null,
                mcpServerToolCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (x) => x.CallID,
                codeExecutionResult: (x) => x.CallID,
                urlContextResult: (x) => x.CallID,
                googleSearchResult: (x) => x.CallID,
                mcpServerToolResult: (x) => x.CallID,
                fileSearchResult: (x) => x.CallID,
                googleMapsResult: (x) => x.CallID,
                textAnnotation: (_) => null
            );
        }
    }

    public bool? IsError
    {
        get
        {
            return Match<bool?>(
                text: (_) => null,
                image: (_) => null,
                audio: (_) => null,
                document: (_) => null,
                video: (_) => null,
                thoughtSummary: (_) => null,
                thoughtSignature: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                googleSearchCall: (_) => null,
                mcpServerToolCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (x) => x.IsError,
                codeExecutionResult: (x) => x.IsError,
                urlContextResult: (x) => x.IsError,
                googleSearchResult: (x) => x.IsError,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null,
                textAnnotation: (_) => null
            );
        }
    }

    public Delta(Text value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(Image value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(Audio value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(Document value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(Video value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(ThoughtSummary value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(ThoughtSignature value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(FunctionCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(CodeExecutionCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(UrlContextCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(GoogleSearchCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(McpServerToolCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(FileSearchCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(GoogleMapsCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(FunctionResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(CodeExecutionResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(UrlContextResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(GoogleSearchResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(McpServerToolResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(FileSearchResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(GoogleMapsResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(TextAnnotation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Delta(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Text"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `Text`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out Text? value)
    {
        value = this.Value as Text;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Image"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImage(out var value)) {
    ///     // `value` is of type `Image`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImage([NotNullWhen(true)] out Image? value)
    {
        value = this.Value as Image;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Audio"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAudio(out var value)) {
    ///     // `value` is of type `Audio`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAudio([NotNullWhen(true)] out Audio? value)
    {
        value = this.Value as Audio;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Document"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDocument(out var value)) {
    ///     // `value` is of type `Document`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDocument([NotNullWhen(true)] out Document? value)
    {
        value = this.Value as Document;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Video"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVideo(out var value)) {
    ///     // `value` is of type `Video`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVideo([NotNullWhen(true)] out Video? value)
    {
        value = this.Value as Video;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThoughtSummary"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThoughtSummary(out var value)) {
    ///     // `value` is of type `ThoughtSummary`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThoughtSummary([NotNullWhen(true)] out ThoughtSummary? value)
    {
        value = this.Value as ThoughtSummary;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThoughtSignature"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThoughtSignature(out var value)) {
    ///     // `value` is of type `ThoughtSignature`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThoughtSignature([NotNullWhen(true)] out ThoughtSignature? value)
    {
        value = this.Value as ThoughtSignature;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionCall(out var value)) {
    ///     // `value` is of type `FunctionCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionCall([NotNullWhen(true)] out FunctionCall? value)
    {
        value = this.Value as FunctionCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionCall(out var value)) {
    ///     // `value` is of type `CodeExecutionCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionCall([NotNullWhen(true)] out CodeExecutionCall? value)
    {
        value = this.Value as CodeExecutionCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlContextCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlContextCall(out var value)) {
    ///     // `value` is of type `UrlContextCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlContextCall([NotNullWhen(true)] out UrlContextCall? value)
    {
        value = this.Value as UrlContextCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleSearchCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleSearchCall(out var value)) {
    ///     // `value` is of type `GoogleSearchCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleSearchCall([NotNullWhen(true)] out GoogleSearchCall? value)
    {
        value = this.Value as GoogleSearchCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="McpServerToolCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServerToolCall(out var value)) {
    ///     // `value` is of type `McpServerToolCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServerToolCall([NotNullWhen(true)] out McpServerToolCall? value)
    {
        value = this.Value as McpServerToolCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileSearchCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileSearchCall(out var value)) {
    ///     // `value` is of type `FileSearchCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileSearchCall([NotNullWhen(true)] out FileSearchCall? value)
    {
        value = this.Value as FileSearchCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleMapsCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleMapsCall(out var value)) {
    ///     // `value` is of type `GoogleMapsCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleMapsCall([NotNullWhen(true)] out GoogleMapsCall? value)
    {
        value = this.Value as GoogleMapsCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionResult(out var value)) {
    ///     // `value` is of type `FunctionResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionResult([NotNullWhen(true)] out FunctionResult? value)
    {
        value = this.Value as FunctionResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionResult(out var value)) {
    ///     // `value` is of type `CodeExecutionResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionResult([NotNullWhen(true)] out CodeExecutionResult? value)
    {
        value = this.Value as CodeExecutionResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlContextResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlContextResult(out var value)) {
    ///     // `value` is of type `UrlContextResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlContextResult([NotNullWhen(true)] out UrlContextResult? value)
    {
        value = this.Value as UrlContextResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleSearchResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleSearchResult(out var value)) {
    ///     // `value` is of type `GoogleSearchResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleSearchResult([NotNullWhen(true)] out GoogleSearchResult? value)
    {
        value = this.Value as GoogleSearchResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="McpServerToolResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServerToolResult(out var value)) {
    ///     // `value` is of type `McpServerToolResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServerToolResult([NotNullWhen(true)] out McpServerToolResult? value)
    {
        value = this.Value as McpServerToolResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileSearchResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileSearchResult(out var value)) {
    ///     // `value` is of type `FileSearchResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileSearchResult([NotNullWhen(true)] out FileSearchResult? value)
    {
        value = this.Value as FileSearchResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleMapsResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleMapsResult(out var value)) {
    ///     // `value` is of type `GoogleMapsResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleMapsResult([NotNullWhen(true)] out GoogleMapsResult? value)
    {
        value = this.Value as GoogleMapsResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextAnnotation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextAnnotation(out var value)) {
    ///     // `value` is of type `TextAnnotation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextAnnotation([NotNullWhen(true)] out TextAnnotation? value)
    {
        value = this.Value as TextAnnotation;
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
    ///     (Text value) =&gt; {...},
    ///     (Image value) =&gt; {...},
    ///     (Audio value) =&gt; {...},
    ///     (Document value) =&gt; {...},
    ///     (Video value) =&gt; {...},
    ///     (ThoughtSummary value) =&gt; {...},
    ///     (ThoughtSignature value) =&gt; {...},
    ///     (FunctionCall value) =&gt; {...},
    ///     (CodeExecutionCall value) =&gt; {...},
    ///     (UrlContextCall value) =&gt; {...},
    ///     (GoogleSearchCall value) =&gt; {...},
    ///     (McpServerToolCall value) =&gt; {...},
    ///     (FileSearchCall value) =&gt; {...},
    ///     (GoogleMapsCall value) =&gt; {...},
    ///     (FunctionResult value) =&gt; {...},
    ///     (CodeExecutionResult value) =&gt; {...},
    ///     (UrlContextResult value) =&gt; {...},
    ///     (GoogleSearchResult value) =&gt; {...},
    ///     (McpServerToolResult value) =&gt; {...},
    ///     (FileSearchResult value) =&gt; {...},
    ///     (GoogleMapsResult value) =&gt; {...},
    ///     (TextAnnotation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Text> text,
        Action<Image> image,
        Action<Audio> audio,
        Action<Document> document,
        Action<Video> video,
        Action<ThoughtSummary> thoughtSummary,
        Action<ThoughtSignature> thoughtSignature,
        Action<FunctionCall> functionCall,
        Action<CodeExecutionCall> codeExecutionCall,
        Action<UrlContextCall> urlContextCall,
        Action<GoogleSearchCall> googleSearchCall,
        Action<McpServerToolCall> mcpServerToolCall,
        Action<FileSearchCall> fileSearchCall,
        Action<GoogleMapsCall> googleMapsCall,
        Action<FunctionResult> functionResult,
        Action<CodeExecutionResult> codeExecutionResult,
        Action<UrlContextResult> urlContextResult,
        Action<GoogleSearchResult> googleSearchResult,
        Action<McpServerToolResult> mcpServerToolResult,
        Action<FileSearchResult> fileSearchResult,
        Action<GoogleMapsResult> googleMapsResult,
        Action<TextAnnotation> textAnnotation
    )
    {
        switch (this.Value)
        {
            case Text value:
                text(value);
                break;
            case Image value:
                image(value);
                break;
            case Audio value:
                audio(value);
                break;
            case Document value:
                document(value);
                break;
            case Video value:
                video(value);
                break;
            case ThoughtSummary value:
                thoughtSummary(value);
                break;
            case ThoughtSignature value:
                thoughtSignature(value);
                break;
            case FunctionCall value:
                functionCall(value);
                break;
            case CodeExecutionCall value:
                codeExecutionCall(value);
                break;
            case UrlContextCall value:
                urlContextCall(value);
                break;
            case GoogleSearchCall value:
                googleSearchCall(value);
                break;
            case McpServerToolCall value:
                mcpServerToolCall(value);
                break;
            case FileSearchCall value:
                fileSearchCall(value);
                break;
            case GoogleMapsCall value:
                googleMapsCall(value);
                break;
            case FunctionResult value:
                functionResult(value);
                break;
            case CodeExecutionResult value:
                codeExecutionResult(value);
                break;
            case UrlContextResult value:
                urlContextResult(value);
                break;
            case GoogleSearchResult value:
                googleSearchResult(value);
                break;
            case McpServerToolResult value:
                mcpServerToolResult(value);
                break;
            case FileSearchResult value:
                fileSearchResult(value);
                break;
            case GoogleMapsResult value:
                googleMapsResult(value);
                break;
            case TextAnnotation value:
                textAnnotation(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of Delta"
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
    ///     (Text value) =&gt; {...},
    ///     (Image value) =&gt; {...},
    ///     (Audio value) =&gt; {...},
    ///     (Document value) =&gt; {...},
    ///     (Video value) =&gt; {...},
    ///     (ThoughtSummary value) =&gt; {...},
    ///     (ThoughtSignature value) =&gt; {...},
    ///     (FunctionCall value) =&gt; {...},
    ///     (CodeExecutionCall value) =&gt; {...},
    ///     (UrlContextCall value) =&gt; {...},
    ///     (GoogleSearchCall value) =&gt; {...},
    ///     (McpServerToolCall value) =&gt; {...},
    ///     (FileSearchCall value) =&gt; {...},
    ///     (GoogleMapsCall value) =&gt; {...},
    ///     (FunctionResult value) =&gt; {...},
    ///     (CodeExecutionResult value) =&gt; {...},
    ///     (UrlContextResult value) =&gt; {...},
    ///     (GoogleSearchResult value) =&gt; {...},
    ///     (McpServerToolResult value) =&gt; {...},
    ///     (FileSearchResult value) =&gt; {...},
    ///     (GoogleMapsResult value) =&gt; {...},
    ///     (TextAnnotation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Text, T> text,
        Func<Image, T> image,
        Func<Audio, T> audio,
        Func<Document, T> document,
        Func<Video, T> video,
        Func<ThoughtSummary, T> thoughtSummary,
        Func<ThoughtSignature, T> thoughtSignature,
        Func<FunctionCall, T> functionCall,
        Func<CodeExecutionCall, T> codeExecutionCall,
        Func<UrlContextCall, T> urlContextCall,
        Func<GoogleSearchCall, T> googleSearchCall,
        Func<McpServerToolCall, T> mcpServerToolCall,
        Func<FileSearchCall, T> fileSearchCall,
        Func<GoogleMapsCall, T> googleMapsCall,
        Func<FunctionResult, T> functionResult,
        Func<CodeExecutionResult, T> codeExecutionResult,
        Func<UrlContextResult, T> urlContextResult,
        Func<GoogleSearchResult, T> googleSearchResult,
        Func<McpServerToolResult, T> mcpServerToolResult,
        Func<FileSearchResult, T> fileSearchResult,
        Func<GoogleMapsResult, T> googleMapsResult,
        Func<TextAnnotation, T> textAnnotation
    )
    {
        return this.Value switch
        {
            Text value => text(value),
            Image value => image(value),
            Audio value => audio(value),
            Document value => document(value),
            Video value => video(value),
            ThoughtSummary value => thoughtSummary(value),
            ThoughtSignature value => thoughtSignature(value),
            FunctionCall value => functionCall(value),
            CodeExecutionCall value => codeExecutionCall(value),
            UrlContextCall value => urlContextCall(value),
            GoogleSearchCall value => googleSearchCall(value),
            McpServerToolCall value => mcpServerToolCall(value),
            FileSearchCall value => fileSearchCall(value),
            GoogleMapsCall value => googleMapsCall(value),
            FunctionResult value => functionResult(value),
            CodeExecutionResult value => codeExecutionResult(value),
            UrlContextResult value => urlContextResult(value),
            GoogleSearchResult value => googleSearchResult(value),
            McpServerToolResult value => mcpServerToolResult(value),
            FileSearchResult value => fileSearchResult(value),
            GoogleMapsResult value => googleMapsResult(value),
            TextAnnotation value => textAnnotation(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of Delta"
            ),
        };
    }

    public static implicit operator Delta(Text value) => new(value);

    public static implicit operator Delta(Image value) => new(value);

    public static implicit operator Delta(Audio value) => new(value);

    public static implicit operator Delta(Document value) => new(value);

    public static implicit operator Delta(Video value) => new(value);

    public static implicit operator Delta(ThoughtSummary value) => new(value);

    public static implicit operator Delta(ThoughtSignature value) => new(value);

    public static implicit operator Delta(FunctionCall value) => new(value);

    public static implicit operator Delta(CodeExecutionCall value) => new(value);

    public static implicit operator Delta(UrlContextCall value) => new(value);

    public static implicit operator Delta(GoogleSearchCall value) => new(value);

    public static implicit operator Delta(McpServerToolCall value) => new(value);

    public static implicit operator Delta(FileSearchCall value) => new(value);

    public static implicit operator Delta(GoogleMapsCall value) => new(value);

    public static implicit operator Delta(FunctionResult value) => new(value);

    public static implicit operator Delta(CodeExecutionResult value) => new(value);

    public static implicit operator Delta(UrlContextResult value) => new(value);

    public static implicit operator Delta(GoogleSearchResult value) => new(value);

    public static implicit operator Delta(McpServerToolResult value) => new(value);

    public static implicit operator Delta(FileSearchResult value) => new(value);

    public static implicit operator Delta(GoogleMapsResult value) => new(value);

    public static implicit operator Delta(TextAnnotation value) => new(value);

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
                "Data did not match any variant of Delta"
            );
        }
        this.Switch(
            (text) => text.Validate(),
            (image) => image.Validate(),
            (audio) => audio.Validate(),
            (document) => document.Validate(),
            (video) => video.Validate(),
            (thoughtSummary) => thoughtSummary.Validate(),
            (thoughtSignature) => thoughtSignature.Validate(),
            (functionCall) => functionCall.Validate(),
            (codeExecutionCall) => codeExecutionCall.Validate(),
            (urlContextCall) => urlContextCall.Validate(),
            (googleSearchCall) => googleSearchCall.Validate(),
            (mcpServerToolCall) => mcpServerToolCall.Validate(),
            (fileSearchCall) => fileSearchCall.Validate(),
            (googleMapsCall) => googleMapsCall.Validate(),
            (functionResult) => functionResult.Validate(),
            (codeExecutionResult) => codeExecutionResult.Validate(),
            (urlContextResult) => urlContextResult.Validate(),
            (googleSearchResult) => googleSearchResult.Validate(),
            (mcpServerToolResult) => mcpServerToolResult.Validate(),
            (fileSearchResult) => fileSearchResult.Validate(),
            (googleMapsResult) => googleMapsResult.Validate(),
            (textAnnotation) => textAnnotation.Validate()
        );
    }

    public virtual bool Equals(Delta? other) =>
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
            Text _ => 0,
            Image _ => 1,
            Audio _ => 2,
            Document _ => 3,
            Video _ => 4,
            ThoughtSummary _ => 5,
            ThoughtSignature _ => 6,
            FunctionCall _ => 7,
            CodeExecutionCall _ => 8,
            UrlContextCall _ => 9,
            GoogleSearchCall _ => 10,
            McpServerToolCall _ => 11,
            FileSearchCall _ => 12,
            GoogleMapsCall _ => 13,
            FunctionResult _ => 14,
            CodeExecutionResult _ => 15,
            UrlContextResult _ => 16,
            GoogleSearchResult _ => 17,
            McpServerToolResult _ => 18,
            FileSearchResult _ => 19,
            GoogleMapsResult _ => 20,
            TextAnnotation _ => 21,
            _ => -1,
        };
    }
}

sealed class DeltaConverter : JsonConverter<Delta>
{
    public override Delta? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Text>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Image>(element, options);
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
            case "audio":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Audio>(element, options);
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
            case "document":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Document>(element, options);
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
            case "video":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Video>(element, options);
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
            case "thought_summary":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThoughtSummary>(element, options);
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
            case "thought_signature":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThoughtSignature>(
                        element,
                        options
                    );
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
            case "function_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FunctionCall>(element, options);
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
            case "code_execution_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeExecutionCall>(
                        element,
                        options
                    );
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
            case "url_context_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UrlContextCall>(element, options);
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
            case "google_search_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleSearchCall>(
                        element,
                        options
                    );
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
            case "mcp_server_tool_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<McpServerToolCall>(
                        element,
                        options
                    );
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
            case "file_search_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileSearchCall>(element, options);
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
            case "google_maps_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleMapsCall>(element, options);
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
            case "function_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FunctionResult>(element, options);
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
            case "code_execution_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeExecutionResult>(
                        element,
                        options
                    );
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
            case "url_context_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UrlContextResult>(
                        element,
                        options
                    );
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
            case "google_search_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleSearchResult>(
                        element,
                        options
                    );
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
            case "mcp_server_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<McpServerToolResult>(
                        element,
                        options
                    );
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
            case "file_search_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileSearchResult>(
                        element,
                        options
                    );
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
            case "google_maps_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleMapsResult>(
                        element,
                        options
                    );
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
            case "text_annotation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextAnnotation>(element, options);
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
                return new Delta(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Delta value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Text, TextFromRaw>))]
public sealed record class Text : JsonModel
{
    public string TextValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TextValue;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
    }

    public Text()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Text(Text text)
        : base(text) { }
#pragma warning restore CS8618

    public Text(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Text(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextFromRaw.FromRawUnchecked"/>
    public static Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Text(string textValue)
        : this()
    {
        this.TextValue = textValue;
    }
}

class TextFromRaw : IFromRawJson<Text>
{
    /// <inheritdoc/>
    public Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Text.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Image, ImageFromRaw>))]
public sealed record class Image : JsonModel
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

    public string? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    public ApiEnum<string, ImageMimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ImageMimeType>>("mime_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    /// <summary>
    /// The resolution of the media.
    /// </summary>
    public ApiEnum<string, Resolution>? Resolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Resolution>>("resolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resolution", value);
        }
    }

    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("image")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Data;
        this.MimeType?.Validate();
        this.Resolution?.Validate();
        _ = this.Uri;
    }

    public Image()
    {
        this.Type = JsonSerializer.SerializeToElement("image");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Image(Image image)
        : base(image) { }
#pragma warning restore CS8618

    public Image(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("image");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Image(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageFromRaw.FromRawUnchecked"/>
    public static Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageFromRaw : IFromRawJson<Image>
{
    /// <inheritdoc/>
    public Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Image.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ImageMimeTypeConverter))]
public enum ImageMimeType
{
    ImagePng,
    ImageJpeg,
    ImageWebp,
    ImageHeic,
    ImageHeif,
    ImageGif,
    ImageBmp,
    ImageTiff,
}

sealed class ImageMimeTypeConverter : JsonConverter<ImageMimeType>
{
    public override ImageMimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image/png" => ImageMimeType.ImagePng,
            "image/jpeg" => ImageMimeType.ImageJpeg,
            "image/webp" => ImageMimeType.ImageWebp,
            "image/heic" => ImageMimeType.ImageHeic,
            "image/heif" => ImageMimeType.ImageHeif,
            "image/gif" => ImageMimeType.ImageGif,
            "image/bmp" => ImageMimeType.ImageBmp,
            "image/tiff" => ImageMimeType.ImageTiff,
            _ => (ImageMimeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageMimeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImageMimeType.ImagePng => "image/png",
                ImageMimeType.ImageJpeg => "image/jpeg",
                ImageMimeType.ImageWebp => "image/webp",
                ImageMimeType.ImageHeic => "image/heic",
                ImageMimeType.ImageHeif => "image/heif",
                ImageMimeType.ImageGif => "image/gif",
                ImageMimeType.ImageBmp => "image/bmp",
                ImageMimeType.ImageTiff => "image/tiff",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The resolution of the media.
/// </summary>
[JsonConverter(typeof(ResolutionConverter))]
public enum Resolution
{
    Low,
    Medium,
    High,
    UltraHigh,
}

sealed class ResolutionConverter : JsonConverter<Resolution>
{
    public override Resolution Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => Resolution.Low,
            "medium" => Resolution.Medium,
            "high" => Resolution.High,
            "ultra_high" => Resolution.UltraHigh,
            _ => (Resolution)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Resolution value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Resolution.Low => "low",
                Resolution.Medium => "medium",
                Resolution.High => "high",
                Resolution.UltraHigh => "ultra_high",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Audio, AudioFromRaw>))]
public sealed record class Audio : JsonModel
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
    /// The number of audio channels.
    /// </summary>
    public int? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channels", value);
        }
    }

    public string? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    public ApiEnum<string, AudioMimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AudioMimeType>>("mime_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    /// <summary>
    /// The sample rate of the audio.
    /// </summary>
    public int? Rate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("audio")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Channels;
        _ = this.Data;
        this.MimeType?.Validate();
        _ = this.Rate;
        _ = this.Uri;
    }

    public Audio()
    {
        this.Type = JsonSerializer.SerializeToElement("audio");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Audio(Audio audio)
        : base(audio) { }
#pragma warning restore CS8618

    public Audio(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("audio");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Audio(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudioFromRaw.FromRawUnchecked"/>
    public static Audio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudioFromRaw : IFromRawJson<Audio>
{
    /// <inheritdoc/>
    public Audio FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Audio.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AudioMimeTypeConverter))]
public enum AudioMimeType
{
    AudioWav,
    AudioMp3,
    AudioAiff,
    AudioAac,
    AudioOgg,
    AudioFlac,
    AudioMpeg,
    AudioM4a,
    AudioL16,
    AudioOpus,
    AudioAlaw,
    AudioMulaw,
}

sealed class AudioMimeTypeConverter : JsonConverter<AudioMimeType>
{
    public override AudioMimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "audio/wav" => AudioMimeType.AudioWav,
            "audio/mp3" => AudioMimeType.AudioMp3,
            "audio/aiff" => AudioMimeType.AudioAiff,
            "audio/aac" => AudioMimeType.AudioAac,
            "audio/ogg" => AudioMimeType.AudioOgg,
            "audio/flac" => AudioMimeType.AudioFlac,
            "audio/mpeg" => AudioMimeType.AudioMpeg,
            "audio/m4a" => AudioMimeType.AudioM4a,
            "audio/l16" => AudioMimeType.AudioL16,
            "audio/opus" => AudioMimeType.AudioOpus,
            "audio/alaw" => AudioMimeType.AudioAlaw,
            "audio/mulaw" => AudioMimeType.AudioMulaw,
            _ => (AudioMimeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AudioMimeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AudioMimeType.AudioWav => "audio/wav",
                AudioMimeType.AudioMp3 => "audio/mp3",
                AudioMimeType.AudioAiff => "audio/aiff",
                AudioMimeType.AudioAac => "audio/aac",
                AudioMimeType.AudioOgg => "audio/ogg",
                AudioMimeType.AudioFlac => "audio/flac",
                AudioMimeType.AudioMpeg => "audio/mpeg",
                AudioMimeType.AudioM4a => "audio/m4a",
                AudioMimeType.AudioL16 => "audio/l16",
                AudioMimeType.AudioOpus => "audio/opus",
                AudioMimeType.AudioAlaw => "audio/alaw",
                AudioMimeType.AudioMulaw => "audio/mulaw",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Document, DocumentFromRaw>))]
public sealed record class Document : JsonModel
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

    public string? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    public ApiEnum<string, DocumentMimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DocumentMimeType>>("mime_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("document")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Data;
        this.MimeType?.Validate();
        _ = this.Uri;
    }

    public Document()
    {
        this.Type = JsonSerializer.SerializeToElement("document");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Document(Document document)
        : base(document) { }
#pragma warning restore CS8618

    public Document(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("document");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Document(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentFromRaw.FromRawUnchecked"/>
    public static Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentFromRaw : IFromRawJson<Document>
{
    /// <inheritdoc/>
    public Document FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Document.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(DocumentMimeTypeConverter))]
public enum DocumentMimeType
{
    ApplicationPdf,
}

sealed class DocumentMimeTypeConverter : JsonConverter<DocumentMimeType>
{
    public override DocumentMimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "application/pdf" => DocumentMimeType.ApplicationPdf,
            _ => (DocumentMimeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocumentMimeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DocumentMimeType.ApplicationPdf => "application/pdf",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Video, VideoFromRaw>))]
public sealed record class Video : JsonModel
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

    public string? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    public ApiEnum<string, VideoMimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VideoMimeType>>("mime_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    /// <summary>
    /// The resolution of the media.
    /// </summary>
    public ApiEnum<string, VideoResolution>? Resolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VideoResolution>>("resolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resolution", value);
        }
    }

    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("video")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Data;
        this.MimeType?.Validate();
        this.Resolution?.Validate();
        _ = this.Uri;
    }

    public Video()
    {
        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Video(Video video)
        : base(video) { }
#pragma warning restore CS8618

    public Video(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Video(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoFromRaw.FromRawUnchecked"/>
    public static Video FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoFromRaw : IFromRawJson<Video>
{
    /// <inheritdoc/>
    public Video FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Video.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(VideoMimeTypeConverter))]
public enum VideoMimeType
{
    VideoMp4,
    VideoMpeg,
    VideoMpg,
    VideoMov,
    VideoAvi,
    VideoXFlv,
    VideoWebm,
    VideoWmv,
    Video3gpp,
}

sealed class VideoMimeTypeConverter : JsonConverter<VideoMimeType>
{
    public override VideoMimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video/mp4" => VideoMimeType.VideoMp4,
            "video/mpeg" => VideoMimeType.VideoMpeg,
            "video/mpg" => VideoMimeType.VideoMpg,
            "video/mov" => VideoMimeType.VideoMov,
            "video/avi" => VideoMimeType.VideoAvi,
            "video/x-flv" => VideoMimeType.VideoXFlv,
            "video/webm" => VideoMimeType.VideoWebm,
            "video/wmv" => VideoMimeType.VideoWmv,
            "video/3gpp" => VideoMimeType.Video3gpp,
            _ => (VideoMimeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoMimeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoMimeType.VideoMp4 => "video/mp4",
                VideoMimeType.VideoMpeg => "video/mpeg",
                VideoMimeType.VideoMpg => "video/mpg",
                VideoMimeType.VideoMov => "video/mov",
                VideoMimeType.VideoAvi => "video/avi",
                VideoMimeType.VideoXFlv => "video/x-flv",
                VideoMimeType.VideoWebm => "video/webm",
                VideoMimeType.VideoWmv => "video/wmv",
                VideoMimeType.Video3gpp => "video/3gpp",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The resolution of the media.
/// </summary>
[JsonConverter(typeof(VideoResolutionConverter))]
public enum VideoResolution
{
    Low,
    Medium,
    High,
    UltraHigh,
}

sealed class VideoResolutionConverter : JsonConverter<VideoResolution>
{
    public override VideoResolution Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => VideoResolution.Low,
            "medium" => VideoResolution.Medium,
            "high" => VideoResolution.High,
            "ultra_high" => VideoResolution.UltraHigh,
            _ => (VideoResolution)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoResolution value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoResolution.Low => "low",
                VideoResolution.Medium => "medium",
                VideoResolution.High => "high",
                VideoResolution.UltraHigh => "ultra_high",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ThoughtSummary, ThoughtSummaryFromRaw>))]
public sealed record class ThoughtSummary : JsonModel
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
    /// A new summary item to be added to the thought.
    /// </summary>
    public ThoughtSummaryContent? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ThoughtSummaryContent>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thought_summary"))
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        this.Content?.Validate();
    }

    public ThoughtSummary()
    {
        this.Type = JsonSerializer.SerializeToElement("thought_summary");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThoughtSummary(ThoughtSummary thoughtSummary)
        : base(thoughtSummary) { }
#pragma warning restore CS8618

    public ThoughtSummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thought_summary");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThoughtSummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThoughtSummaryFromRaw.FromRawUnchecked"/>
    public static ThoughtSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThoughtSummaryFromRaw : IFromRawJson<ThoughtSummary>
{
    /// <inheritdoc/>
    public ThoughtSummary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThoughtSummary.FromRawUnchecked(rawData);
}

/// <summary>
/// A text content block.
/// </summary>
[JsonConverter(typeof(ThoughtSummaryContentConverter))]
public record class ThoughtSummaryContent : ModelBase
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
        get { return Match(text: (x) => x.Type, image: (x) => x.Type); }
    }

    public ThoughtSummaryContent(TextContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ThoughtSummaryContent(ImageContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ThoughtSummaryContent(JsonElement element)
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
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `TextContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out TextContent? value)
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
    /// if (instance.TryPickImage(out var value)) {
    ///     // `value` is of type `ImageContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImage([NotNullWhen(true)] out ImageContent? value)
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
    public void Switch(Action<TextContent> text, Action<ImageContent> image)
    {
        switch (this.Value)
        {
            case TextContent value:
                text(value);
                break;
            case ImageContent value:
                image(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of ThoughtSummaryContent"
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
    public T Match<T>(Func<TextContent, T> text, Func<ImageContent, T> image)
    {
        return this.Value switch
        {
            TextContent value => text(value),
            ImageContent value => image(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of ThoughtSummaryContent"
            ),
        };
    }

    public static implicit operator ThoughtSummaryContent(TextContent value) => new(value);

    public static implicit operator ThoughtSummaryContent(ImageContent value) => new(value);

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
                "Data did not match any variant of ThoughtSummaryContent"
            );
        }
        this.Switch((text) => text.Validate(), (image) => image.Validate());
    }

    public virtual bool Equals(ThoughtSummaryContent? other) =>
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

sealed class ThoughtSummaryContentConverter : JsonConverter<ThoughtSummaryContent>
{
    public override ThoughtSummaryContent? Read(
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
                return new ThoughtSummaryContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThoughtSummaryContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ThoughtSignature, ThoughtSignatureFromRaw>))]
public sealed record class ThoughtSignature : JsonModel
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
    /// Signature to match the backend source to be part of the generation.
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("thought_signature")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public ThoughtSignature()
    {
        this.Type = JsonSerializer.SerializeToElement("thought_signature");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThoughtSignature(ThoughtSignature thoughtSignature)
        : base(thoughtSignature) { }
#pragma warning restore CS8618

    public ThoughtSignature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thought_signature");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThoughtSignature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThoughtSignatureFromRaw.FromRawUnchecked"/>
    public static ThoughtSignature FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThoughtSignatureFromRaw : IFromRawJson<ThoughtSignature>
{
    /// <inheritdoc/>
    public ThoughtSignature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThoughtSignature.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FunctionCall, FunctionCallFromRaw>))]
public sealed record class FunctionCall : JsonModel
{
    /// <summary>
    /// Required. A unique ID for this specific tool call.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public IReadOnlyDictionary<string, JsonElement> Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "arguments"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "arguments",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.ID;
        _ = this.Arguments;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("function_call")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public FunctionCall()
    {
        this.Type = JsonSerializer.SerializeToElement("function_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionCall(FunctionCall functionCall)
        : base(functionCall) { }
#pragma warning restore CS8618

    public FunctionCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("function_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionCallFromRaw.FromRawUnchecked"/>
    public static FunctionCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionCallFromRaw : IFromRawJson<FunctionCall>
{
    /// <inheritdoc/>
    public FunctionCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CodeExecutionCall, CodeExecutionCallFromRaw>))]
public sealed record class CodeExecutionCall : JsonModel
{
    /// <summary>
    /// Required. A unique ID for this specific tool call.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The arguments to pass to the code execution.
    /// </summary>
    public CodeExecutionCallArguments Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CodeExecutionCallArguments>("arguments");
        }
        init { this._rawData.Set("arguments", value); }
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
        _ = this.ID;
        this.Arguments.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_call")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public CodeExecutionCall()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionCall(CodeExecutionCall codeExecutionCall)
        : base(codeExecutionCall) { }
#pragma warning restore CS8618

    public CodeExecutionCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionCallFromRaw.FromRawUnchecked"/>
    public static CodeExecutionCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionCallFromRaw : IFromRawJson<CodeExecutionCall>
{
    /// <inheritdoc/>
    public CodeExecutionCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CodeExecutionCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UrlContextCall, UrlContextCallFromRaw>))]
public sealed record class UrlContextCall : JsonModel
{
    /// <summary>
    /// Required. A unique ID for this specific tool call.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The arguments to pass to the URL context.
    /// </summary>
    public UrlContextCallArguments Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UrlContextCallArguments>("arguments");
        }
        init { this._rawData.Set("arguments", value); }
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
        _ = this.ID;
        this.Arguments.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("url_context_call")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public UrlContextCall()
    {
        this.Type = JsonSerializer.SerializeToElement("url_context_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlContextCall(UrlContextCall urlContextCall)
        : base(urlContextCall) { }
#pragma warning restore CS8618

    public UrlContextCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url_context_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlContextCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlContextCallFromRaw.FromRawUnchecked"/>
    public static UrlContextCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlContextCallFromRaw : IFromRawJson<UrlContextCall>
{
    /// <inheritdoc/>
    public UrlContextCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UrlContextCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GoogleSearchCall, GoogleSearchCallFromRaw>))]
public sealed record class GoogleSearchCall : JsonModel
{
    /// <summary>
    /// Required. A unique ID for this specific tool call.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The arguments to pass to Google Search.
    /// </summary>
    public GoogleSearchCallArguments Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GoogleSearchCallArguments>("arguments");
        }
        init { this._rawData.Set("arguments", value); }
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
        _ = this.ID;
        this.Arguments.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("google_search_call")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public GoogleSearchCall()
    {
        this.Type = JsonSerializer.SerializeToElement("google_search_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleSearchCall(GoogleSearchCall googleSearchCall)
        : base(googleSearchCall) { }
#pragma warning restore CS8618

    public GoogleSearchCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_search_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleSearchCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleSearchCallFromRaw.FromRawUnchecked"/>
    public static GoogleSearchCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleSearchCallFromRaw : IFromRawJson<GoogleSearchCall>
{
    /// <inheritdoc/>
    public GoogleSearchCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleSearchCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<McpServerToolCall, McpServerToolCallFromRaw>))]
public sealed record class McpServerToolCall : JsonModel
{
    /// <summary>
    /// Required. A unique ID for this specific tool call.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public IReadOnlyDictionary<string, JsonElement> Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "arguments"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "arguments",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string ServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("server_name");
        }
        init { this._rawData.Set("server_name", value); }
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
        _ = this.ID;
        _ = this.Arguments;
        _ = this.Name;
        _ = this.ServerName;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("mcp_server_tool_call")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public McpServerToolCall()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_server_tool_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServerToolCall(McpServerToolCall mcpServerToolCall)
        : base(mcpServerToolCall) { }
#pragma warning restore CS8618

    public McpServerToolCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_server_tool_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServerToolCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpServerToolCallFromRaw.FromRawUnchecked"/>
    public static McpServerToolCall FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class McpServerToolCallFromRaw : IFromRawJson<McpServerToolCall>
{
    /// <inheritdoc/>
    public McpServerToolCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpServerToolCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FileSearchCall, FileSearchCallFromRaw>))]
public sealed record class FileSearchCall : JsonModel
{
    /// <summary>
    /// Required. A unique ID for this specific tool call.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("file_search_call")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public FileSearchCall()
    {
        this.Type = JsonSerializer.SerializeToElement("file_search_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileSearchCall(FileSearchCall fileSearchCall)
        : base(fileSearchCall) { }
#pragma warning restore CS8618

    public FileSearchCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file_search_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileSearchCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileSearchCallFromRaw.FromRawUnchecked"/>
    public static FileSearchCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FileSearchCall(string id)
        : this()
    {
        this.ID = id;
    }
}

class FileSearchCallFromRaw : IFromRawJson<FileSearchCall>
{
    /// <inheritdoc/>
    public FileSearchCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileSearchCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GoogleMapsCall, GoogleMapsCallFromRaw>))]
public sealed record class GoogleMapsCall : JsonModel
{
    /// <summary>
    /// Required. A unique ID for this specific tool call.
    /// </summary>
    public string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
    /// The arguments to pass to the Google Maps tool.
    /// </summary>
    public GoogleMapsCallArguments? Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GoogleMapsCallArguments>("arguments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("arguments", value);
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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("google_maps_call")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        this.Arguments?.Validate();
        _ = this.Signature;
    }

    public GoogleMapsCall()
    {
        this.Type = JsonSerializer.SerializeToElement("google_maps_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleMapsCall(GoogleMapsCall googleMapsCall)
        : base(googleMapsCall) { }
#pragma warning restore CS8618

    public GoogleMapsCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_maps_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleMapsCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleMapsCallFromRaw.FromRawUnchecked"/>
    public static GoogleMapsCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GoogleMapsCall(string id)
        : this()
    {
        this.ID = id;
    }
}

class GoogleMapsCallFromRaw : IFromRawJson<GoogleMapsCall>
{
    /// <inheritdoc/>
    public GoogleMapsCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleMapsCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FunctionResult, FunctionResultFromRaw>))]
public sealed record class FunctionResult : JsonModel
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

    public Result Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Result>("result");
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

    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
        }
    }

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
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("function_result"))
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.IsError;
        _ = this.Name;
        _ = this.Signature;
    }

    public FunctionResult()
    {
        this.Type = JsonSerializer.SerializeToElement("function_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FunctionResult(FunctionResult functionResult)
        : base(functionResult) { }
#pragma warning restore CS8618

    public FunctionResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("function_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FunctionResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FunctionResultFromRaw.FromRawUnchecked"/>
    public static FunctionResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FunctionResultFromRaw : IFromRawJson<FunctionResult>
{
    /// <inheritdoc/>
    public FunctionResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FunctionResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ResultConverter))]
public record class Result : ModelBase
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

    public Result(IReadOnlyList<FunctionResultSubcontent> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Result(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Result(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>FunctionResultSubcontent</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionResultSubcontentList(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;FunctionResultSubcontent&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionResultSubcontentList(
        [NotNullWhen(true)] out IReadOnlyList<FunctionResultSubcontent>? value
    )
    {
        value = this.Value as IReadOnlyList<FunctionResultSubcontent>;
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
    ///     (IReadOnlyList&lt;FunctionResultSubcontent&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<JsonElement> jsonElement,
        Action<IReadOnlyList<FunctionResultSubcontent>> functionResultSubcontentList,
        Action<string> @string
    )
    {
        switch (this.Value)
        {
            case JsonElement value:
                jsonElement(value);
                break;
            case IReadOnlyList<FunctionResultSubcontent> value:
                functionResultSubcontentList(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of Result"
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
    ///     (IReadOnlyList&lt;FunctionResultSubcontent&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<JsonElement, T> jsonElement,
        Func<IReadOnlyList<FunctionResultSubcontent>, T> functionResultSubcontentList,
        Func<string, T> @string
    )
    {
        return this.Value switch
        {
            JsonElement value => jsonElement(value),
            IReadOnlyList<FunctionResultSubcontent> value => functionResultSubcontentList(value),
            string value => @string(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of Result"
            ),
        };
    }

    public static implicit operator Result(JsonElement value) => new(value);

    public static implicit operator Result(List<FunctionResultSubcontent> value) =>
        new((IReadOnlyList<FunctionResultSubcontent>)value);

    public static implicit operator Result(string value) => new(value);

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
                "Data did not match any variant of Result"
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

    public virtual bool Equals(Result? other) =>
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
            IReadOnlyList<FunctionResultSubcontent> _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class ResultConverter : JsonConverter<Result>
{
    public override Result? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<List<FunctionResultSubcontent>>(
                element,
                options
            );
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

    public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A text content block.
/// </summary>
[JsonConverter(typeof(FunctionResultSubcontentConverter))]
public record class FunctionResultSubcontent : ModelBase
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

    public FunctionResultSubcontent(TextContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionResultSubcontent(ImageContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FunctionResultSubcontent(JsonElement element)
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
                    "Data did not match any variant of FunctionResultSubcontent"
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
                "Data did not match any variant of FunctionResultSubcontent"
            ),
        };
    }

    public static implicit operator FunctionResultSubcontent(TextContent value) => new(value);

    public static implicit operator FunctionResultSubcontent(ImageContent value) => new(value);

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
                "Data did not match any variant of FunctionResultSubcontent"
            );
        }
        this.Switch(
            (textContent) => textContent.Validate(),
            (imageContent) => imageContent.Validate()
        );
    }

    public virtual bool Equals(FunctionResultSubcontent? other) =>
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

sealed class FunctionResultSubcontentConverter : JsonConverter<FunctionResultSubcontent>
{
    public override FunctionResultSubcontent? Read(
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
                return new FunctionResultSubcontent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        FunctionResultSubcontent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<CodeExecutionResult, CodeExecutionResultFromRaw>))]
public sealed record class CodeExecutionResult : JsonModel
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

    public string Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("result");
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

    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
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
        _ = this.Result;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.IsError;
        _ = this.Signature;
    }

    public CodeExecutionResult()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionResult(CodeExecutionResult codeExecutionResult)
        : base(codeExecutionResult) { }
#pragma warning restore CS8618

    public CodeExecutionResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionResultFromRaw.FromRawUnchecked"/>
    public static CodeExecutionResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionResultFromRaw : IFromRawJson<CodeExecutionResult>
{
    /// <inheritdoc/>
    public CodeExecutionResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CodeExecutionResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UrlContextResult, UrlContextResultFromRaw>))]
public sealed record class UrlContextResult : JsonModel
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

    public IReadOnlyList<InteractionUrlContextResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InteractionUrlContextResult>>(
                "result"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<InteractionUrlContextResult>>(
                "result",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
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
        foreach (var item in this.Result)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("url_context_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.IsError;
        _ = this.Signature;
    }

    public UrlContextResult()
    {
        this.Type = JsonSerializer.SerializeToElement("url_context_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlContextResult(UrlContextResult urlContextResult)
        : base(urlContextResult) { }
#pragma warning restore CS8618

    public UrlContextResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url_context_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlContextResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlContextResultFromRaw.FromRawUnchecked"/>
    public static UrlContextResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlContextResultFromRaw : IFromRawJson<UrlContextResult>
{
    /// <inheritdoc/>
    public UrlContextResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UrlContextResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GoogleSearchResult, GoogleSearchResultFromRaw>))]
public sealed record class GoogleSearchResult : JsonModel
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

    public IReadOnlyList<InteractionGoogleSearchResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<InteractionGoogleSearchResult>>(
                "result"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<InteractionGoogleSearchResult>>(
                "result",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
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
        foreach (var item in this.Result)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("google_search_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.IsError;
        _ = this.Signature;
    }

    public GoogleSearchResult()
    {
        this.Type = JsonSerializer.SerializeToElement("google_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleSearchResult(GoogleSearchResult googleSearchResult)
        : base(googleSearchResult) { }
#pragma warning restore CS8618

    public GoogleSearchResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleSearchResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleSearchResultFromRaw.FromRawUnchecked"/>
    public static GoogleSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleSearchResultFromRaw : IFromRawJson<GoogleSearchResult>
{
    /// <inheritdoc/>
    public GoogleSearchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleSearchResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<McpServerToolResult, McpServerToolResultFromRaw>))]
public sealed record class McpServerToolResult : JsonModel
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

    public McpServerToolResultResult Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<McpServerToolResultResult>("result");
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

    public McpServerToolResult()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_server_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public McpServerToolResult(McpServerToolResult mcpServerToolResult)
        : base(mcpServerToolResult) { }
#pragma warning restore CS8618

    public McpServerToolResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mcp_server_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    McpServerToolResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="McpServerToolResultFromRaw.FromRawUnchecked"/>
    public static McpServerToolResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class McpServerToolResultFromRaw : IFromRawJson<McpServerToolResult>
{
    /// <inheritdoc/>
    public McpServerToolResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        McpServerToolResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(McpServerToolResultResultConverter))]
public record class McpServerToolResultResult : ModelBase
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

    public McpServerToolResultResult(
        IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public McpServerToolResultResult(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public McpServerToolResultResult(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>McpServerToolResultResultFunctionResultSubcontent</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionResultSubcontentList(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;McpServerToolResultResultFunctionResultSubcontent&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionResultSubcontentList(
        [NotNullWhen(true)]
            out IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent>? value
    )
    {
        value = this.Value as IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent>;
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
    ///     (IReadOnlyList&lt;McpServerToolResultResultFunctionResultSubcontent&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<JsonElement> jsonElement,
        Action<
            IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent>
        > functionResultSubcontentList,
        Action<string> @string
    )
    {
        switch (this.Value)
        {
            case JsonElement value:
                jsonElement(value);
                break;
            case IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent> value:
                functionResultSubcontentList(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of McpServerToolResultResult"
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
    ///     (IReadOnlyList&lt;McpServerToolResultResultFunctionResultSubcontent&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<JsonElement, T> jsonElement,
        Func<
            IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent>,
            T
        > functionResultSubcontentList,
        Func<string, T> @string
    )
    {
        return this.Value switch
        {
            JsonElement value => jsonElement(value),
            IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent> value =>
                functionResultSubcontentList(value),
            string value => @string(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of McpServerToolResultResult"
            ),
        };
    }

    public static implicit operator McpServerToolResultResult(JsonElement value) => new(value);

    public static implicit operator McpServerToolResultResult(
        List<McpServerToolResultResultFunctionResultSubcontent> value
    ) => new((IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent>)value);

    public static implicit operator McpServerToolResultResult(string value) => new(value);

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
                "Data did not match any variant of McpServerToolResultResult"
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

    public virtual bool Equals(McpServerToolResultResult? other) =>
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
            IReadOnlyList<McpServerToolResultResultFunctionResultSubcontent> _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class McpServerToolResultResultConverter : JsonConverter<McpServerToolResultResult>
{
    public override McpServerToolResultResult? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<McpServerToolResultResultFunctionResultSubcontent>
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
        McpServerToolResultResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// A text content block.
/// </summary>
[JsonConverter(typeof(McpServerToolResultResultFunctionResultSubcontentConverter))]
public record class McpServerToolResultResultFunctionResultSubcontent : ModelBase
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

    public McpServerToolResultResultFunctionResultSubcontent(
        TextContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public McpServerToolResultResultFunctionResultSubcontent(
        ImageContent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public McpServerToolResultResultFunctionResultSubcontent(JsonElement element)
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
                    "Data did not match any variant of McpServerToolResultResultFunctionResultSubcontent"
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
                "Data did not match any variant of McpServerToolResultResultFunctionResultSubcontent"
            ),
        };
    }

    public static implicit operator McpServerToolResultResultFunctionResultSubcontent(
        TextContent value
    ) => new(value);

    public static implicit operator McpServerToolResultResultFunctionResultSubcontent(
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
                "Data did not match any variant of McpServerToolResultResultFunctionResultSubcontent"
            );
        }
        this.Switch(
            (textContent) => textContent.Validate(),
            (imageContent) => imageContent.Validate()
        );
    }

    public virtual bool Equals(McpServerToolResultResultFunctionResultSubcontent? other) =>
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

sealed class McpServerToolResultResultFunctionResultSubcontentConverter
    : JsonConverter<McpServerToolResultResultFunctionResultSubcontent>
{
    public override McpServerToolResultResultFunctionResultSubcontent? Read(
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
                return new McpServerToolResultResultFunctionResultSubcontent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        McpServerToolResultResultFunctionResultSubcontent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<FileSearchResult, FileSearchResultFromRaw>))]
public sealed record class FileSearchResult : JsonModel
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

    public IReadOnlyList<FileSearchResultResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FileSearchResultResult>>("result");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FileSearchResultResult>>(
                "result",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        foreach (var item in this.Result)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("file_search_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public FileSearchResult()
    {
        this.Type = JsonSerializer.SerializeToElement("file_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileSearchResult(FileSearchResult fileSearchResult)
        : base(fileSearchResult) { }
#pragma warning restore CS8618

    public FileSearchResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileSearchResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileSearchResultFromRaw.FromRawUnchecked"/>
    public static FileSearchResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileSearchResultFromRaw : IFromRawJson<FileSearchResult>
{
    /// <inheritdoc/>
    public FileSearchResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileSearchResult.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of the File Search.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileSearchResultResult, FileSearchResultResultFromRaw>))]
public sealed record class FileSearchResultResult : JsonModel
{
    /// <summary>
    /// User provided metadata about the FileSearchResult.
    /// </summary>
    public IReadOnlyList<JsonElement>? CustomMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("custom_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "custom_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomMetadata;
    }

    public FileSearchResultResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileSearchResultResult(FileSearchResultResult fileSearchResultResult)
        : base(fileSearchResultResult) { }
#pragma warning restore CS8618

    public FileSearchResultResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileSearchResultResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileSearchResultResultFromRaw.FromRawUnchecked"/>
    public static FileSearchResultResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileSearchResultResultFromRaw : IFromRawJson<FileSearchResultResult>
{
    /// <inheritdoc/>
    public FileSearchResultResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileSearchResultResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GoogleMapsResult, GoogleMapsResultFromRaw>))]
public sealed record class GoogleMapsResult : JsonModel
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
    /// The results of the Google Maps.
    /// </summary>
    public IReadOnlyList<InteractionGoogleMapsResult>? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InteractionGoogleMapsResult>>(
                "result"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<InteractionGoogleMapsResult>?>(
                "result",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("google_maps_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Result ?? Enumerable.Empty<InteractionGoogleMapsResult>())
        {
            item.Validate();
        }
        _ = this.Signature;
    }

    public GoogleMapsResult()
    {
        this.Type = JsonSerializer.SerializeToElement("google_maps_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleMapsResult(GoogleMapsResult googleMapsResult)
        : base(googleMapsResult) { }
#pragma warning restore CS8618

    public GoogleMapsResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_maps_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleMapsResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleMapsResultFromRaw.FromRawUnchecked"/>
    public static GoogleMapsResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GoogleMapsResult(string callID)
        : this()
    {
        this.CallID = callID;
    }
}

class GoogleMapsResultFromRaw : IFromRawJson<GoogleMapsResult>
{
    /// <inheritdoc/>
    public GoogleMapsResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GoogleMapsResult.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TextAnnotation, TextAnnotationFromRaw>))]
public sealed record class TextAnnotation : JsonModel
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
    /// Citation information for model-generated content.
    /// </summary>
    public IReadOnlyList<Annotation>? Annotations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Annotation>>("annotations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Annotation>?>(
                "annotations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text_annotation"))
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Annotations ?? Enumerable.Empty<Annotation>())
        {
            item.Validate();
        }
    }

    public TextAnnotation()
    {
        this.Type = JsonSerializer.SerializeToElement("text_annotation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextAnnotation(TextAnnotation textAnnotation)
        : base(textAnnotation) { }
#pragma warning restore CS8618

    public TextAnnotation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text_annotation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextAnnotation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextAnnotationFromRaw.FromRawUnchecked"/>
    public static TextAnnotation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextAnnotationFromRaw : IFromRawJson<TextAnnotation>
{
    /// <inheritdoc/>
    public TextAnnotation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextAnnotation.FromRawUnchecked(rawData);
}
