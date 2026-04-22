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
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The content of the response.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
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
                thought: (x) => x.Type,
                functionCall: (x) => x.Type,
                codeExecutionCall: (x) => x.Type,
                urlContextCall: (x) => x.Type,
                mcpServerToolCall: (x) => x.Type,
                googleSearchCall: (x) => x.Type,
                fileSearchCall: (x) => x.Type,
                googleMapsCall: (x) => x.Type,
                functionResult: (x) => x.Type,
                codeExecutionResult: (x) => x.Type,
                urlContextResult: (x) => x.Type,
                googleSearchResult: (x) => x.Type,
                mcpServerToolResult: (x) => x.Type,
                fileSearchResult: (x) => x.Type,
                googleMapsResult: (x) => x.Type
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
                thought: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                mcpServerToolCall: (_) => null,
                googleSearchCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null
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
                thought: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                mcpServerToolCall: (_) => null,
                googleSearchCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null
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
                thought: (x) => x.Signature,
                functionCall: (x) => x.Signature,
                codeExecutionCall: (x) => x.Signature,
                urlContextCall: (x) => x.Signature,
                mcpServerToolCall: (x) => x.Signature,
                googleSearchCall: (x) => x.Signature,
                fileSearchCall: (x) => x.Signature,
                googleMapsCall: (x) => x.Signature,
                functionResult: (x) => x.Signature,
                codeExecutionResult: (x) => x.Signature,
                urlContextResult: (x) => x.Signature,
                googleSearchResult: (x) => x.Signature,
                mcpServerToolResult: (x) => x.Signature,
                fileSearchResult: (x) => x.Signature,
                googleMapsResult: (x) => x.Signature
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
                thought: (_) => null,
                functionCall: (x) => x.ID,
                codeExecutionCall: (x) => x.ID,
                urlContextCall: (x) => x.ID,
                mcpServerToolCall: (x) => x.ID,
                googleSearchCall: (x) => x.ID,
                fileSearchCall: (x) => x.ID,
                googleMapsCall: (x) => x.ID,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null
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
                thought: (_) => null,
                functionCall: (x) => x.Name,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                mcpServerToolCall: (x) => x.Name,
                googleSearchCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (x) => x.Name,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (x) => x.Name,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null
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
                thought: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                mcpServerToolCall: (x) => x.ServerName,
                googleSearchCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (_) => null,
                codeExecutionResult: (_) => null,
                urlContextResult: (_) => null,
                googleSearchResult: (_) => null,
                mcpServerToolResult: (x) => x.ServerName,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null
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
                thought: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                mcpServerToolCall: (_) => null,
                googleSearchCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (x) => x.CallID,
                codeExecutionResult: (x) => x.CallID,
                urlContextResult: (x) => x.CallID,
                googleSearchResult: (x) => x.CallID,
                mcpServerToolResult: (x) => x.CallID,
                fileSearchResult: (x) => x.CallID,
                googleMapsResult: (x) => x.CallID
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
                thought: (_) => null,
                functionCall: (_) => null,
                codeExecutionCall: (_) => null,
                urlContextCall: (_) => null,
                mcpServerToolCall: (_) => null,
                googleSearchCall: (_) => null,
                fileSearchCall: (_) => null,
                googleMapsCall: (_) => null,
                functionResult: (x) => x.IsError,
                codeExecutionResult: (x) => x.IsError,
                urlContextResult: (x) => x.IsError,
                googleSearchResult: (x) => x.IsError,
                mcpServerToolResult: (_) => null,
                fileSearchResult: (_) => null,
                googleMapsResult: (_) => null
            );
        }
    }

    public Content(TextContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(ImageContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(AudioContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(DocumentContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(VideoContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(ThoughtContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(FunctionCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(CodeExecutionCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(UrlContextCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(McpServerToolCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(GoogleSearchCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(FileSearchCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(GoogleMapsCallContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(FunctionResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(CodeExecutionResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(UrlContextResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(GoogleSearchResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(McpServerToolResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(FileSearchResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(GoogleMapsResultContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(JsonElement element)
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
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AudioContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAudio(out var value)) {
    ///     // `value` is of type `AudioContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAudio([NotNullWhen(true)] out AudioContent? value)
    {
        value = this.Value as AudioContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DocumentContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDocument(out var value)) {
    ///     // `value` is of type `DocumentContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDocument([NotNullWhen(true)] out DocumentContent? value)
    {
        value = this.Value as DocumentContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VideoContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVideo(out var value)) {
    ///     // `value` is of type `VideoContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVideo([NotNullWhen(true)] out VideoContent? value)
    {
        value = this.Value as VideoContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThoughtContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThought(out var value)) {
    ///     // `value` is of type `ThoughtContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThought([NotNullWhen(true)] out ThoughtContent? value)
    {
        value = this.Value as ThoughtContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionCall(out var value)) {
    ///     // `value` is of type `FunctionCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionCall([NotNullWhen(true)] out FunctionCallContent? value)
    {
        value = this.Value as FunctionCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionCall(out var value)) {
    ///     // `value` is of type `CodeExecutionCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionCall([NotNullWhen(true)] out CodeExecutionCallContent? value)
    {
        value = this.Value as CodeExecutionCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlContextCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlContextCall(out var value)) {
    ///     // `value` is of type `UrlContextCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlContextCall([NotNullWhen(true)] out UrlContextCallContent? value)
    {
        value = this.Value as UrlContextCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="McpServerToolCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServerToolCall(out var value)) {
    ///     // `value` is of type `McpServerToolCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServerToolCall([NotNullWhen(true)] out McpServerToolCallContent? value)
    {
        value = this.Value as McpServerToolCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleSearchCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleSearchCall(out var value)) {
    ///     // `value` is of type `GoogleSearchCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleSearchCall([NotNullWhen(true)] out GoogleSearchCallContent? value)
    {
        value = this.Value as GoogleSearchCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileSearchCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileSearchCall(out var value)) {
    ///     // `value` is of type `FileSearchCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileSearchCall([NotNullWhen(true)] out FileSearchCallContent? value)
    {
        value = this.Value as FileSearchCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleMapsCallContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleMapsCall(out var value)) {
    ///     // `value` is of type `GoogleMapsCallContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleMapsCall([NotNullWhen(true)] out GoogleMapsCallContent? value)
    {
        value = this.Value as GoogleMapsCallContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FunctionResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFunctionResult(out var value)) {
    ///     // `value` is of type `FunctionResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFunctionResult([NotNullWhen(true)] out FunctionResultContent? value)
    {
        value = this.Value as FunctionResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionResult(out var value)) {
    ///     // `value` is of type `CodeExecutionResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionResult(
        [NotNullWhen(true)] out CodeExecutionResultContent? value
    )
    {
        value = this.Value as CodeExecutionResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlContextResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlContextResult(out var value)) {
    ///     // `value` is of type `UrlContextResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlContextResult([NotNullWhen(true)] out UrlContextResultContent? value)
    {
        value = this.Value as UrlContextResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleSearchResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleSearchResult(out var value)) {
    ///     // `value` is of type `GoogleSearchResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleSearchResult([NotNullWhen(true)] out GoogleSearchResultContent? value)
    {
        value = this.Value as GoogleSearchResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="McpServerToolResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMcpServerToolResult(out var value)) {
    ///     // `value` is of type `McpServerToolResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMcpServerToolResult(
        [NotNullWhen(true)] out McpServerToolResultContent? value
    )
    {
        value = this.Value as McpServerToolResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileSearchResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileSearchResult(out var value)) {
    ///     // `value` is of type `FileSearchResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileSearchResult([NotNullWhen(true)] out FileSearchResultContent? value)
    {
        value = this.Value as FileSearchResultContent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GoogleMapsResultContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGoogleMapsResult(out var value)) {
    ///     // `value` is of type `GoogleMapsResultContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGoogleMapsResult([NotNullWhen(true)] out GoogleMapsResultContent? value)
    {
        value = this.Value as GoogleMapsResultContent;
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
    ///     (ImageContent value) =&gt; {...},
    ///     (AudioContent value) =&gt; {...},
    ///     (DocumentContent value) =&gt; {...},
    ///     (VideoContent value) =&gt; {...},
    ///     (ThoughtContent value) =&gt; {...},
    ///     (FunctionCallContent value) =&gt; {...},
    ///     (CodeExecutionCallContent value) =&gt; {...},
    ///     (UrlContextCallContent value) =&gt; {...},
    ///     (McpServerToolCallContent value) =&gt; {...},
    ///     (GoogleSearchCallContent value) =&gt; {...},
    ///     (FileSearchCallContent value) =&gt; {...},
    ///     (GoogleMapsCallContent value) =&gt; {...},
    ///     (FunctionResultContent value) =&gt; {...},
    ///     (CodeExecutionResultContent value) =&gt; {...},
    ///     (UrlContextResultContent value) =&gt; {...},
    ///     (GoogleSearchResultContent value) =&gt; {...},
    ///     (McpServerToolResultContent value) =&gt; {...},
    ///     (FileSearchResultContent value) =&gt; {...},
    ///     (GoogleMapsResultContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<TextContent> text,
        Action<ImageContent> image,
        Action<AudioContent> audio,
        Action<DocumentContent> document,
        Action<VideoContent> video,
        Action<ThoughtContent> thought,
        Action<FunctionCallContent> functionCall,
        Action<CodeExecutionCallContent> codeExecutionCall,
        Action<UrlContextCallContent> urlContextCall,
        Action<McpServerToolCallContent> mcpServerToolCall,
        Action<GoogleSearchCallContent> googleSearchCall,
        Action<FileSearchCallContent> fileSearchCall,
        Action<GoogleMapsCallContent> googleMapsCall,
        Action<FunctionResultContent> functionResult,
        Action<CodeExecutionResultContent> codeExecutionResult,
        Action<UrlContextResultContent> urlContextResult,
        Action<GoogleSearchResultContent> googleSearchResult,
        Action<McpServerToolResultContent> mcpServerToolResult,
        Action<FileSearchResultContent> fileSearchResult,
        Action<GoogleMapsResultContent> googleMapsResult
    )
    {
        switch (this.Value)
        {
            case TextContent value:
                text(value);
                break;
            case ImageContent value:
                image(value);
                break;
            case AudioContent value:
                audio(value);
                break;
            case DocumentContent value:
                document(value);
                break;
            case VideoContent value:
                video(value);
                break;
            case ThoughtContent value:
                thought(value);
                break;
            case FunctionCallContent value:
                functionCall(value);
                break;
            case CodeExecutionCallContent value:
                codeExecutionCall(value);
                break;
            case UrlContextCallContent value:
                urlContextCall(value);
                break;
            case McpServerToolCallContent value:
                mcpServerToolCall(value);
                break;
            case GoogleSearchCallContent value:
                googleSearchCall(value);
                break;
            case FileSearchCallContent value:
                fileSearchCall(value);
                break;
            case GoogleMapsCallContent value:
                googleMapsCall(value);
                break;
            case FunctionResultContent value:
                functionResult(value);
                break;
            case CodeExecutionResultContent value:
                codeExecutionResult(value);
                break;
            case UrlContextResultContent value:
                urlContextResult(value);
                break;
            case GoogleSearchResultContent value:
                googleSearchResult(value);
                break;
            case McpServerToolResultContent value:
                mcpServerToolResult(value);
                break;
            case FileSearchResultContent value:
                fileSearchResult(value);
                break;
            case GoogleMapsResultContent value:
                googleMapsResult(value);
                break;
            default:
                throw new GeminiNextGenApiInvalidDataException(
                    "Data did not match any variant of Content"
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
    ///     (ImageContent value) =&gt; {...},
    ///     (AudioContent value) =&gt; {...},
    ///     (DocumentContent value) =&gt; {...},
    ///     (VideoContent value) =&gt; {...},
    ///     (ThoughtContent value) =&gt; {...},
    ///     (FunctionCallContent value) =&gt; {...},
    ///     (CodeExecutionCallContent value) =&gt; {...},
    ///     (UrlContextCallContent value) =&gt; {...},
    ///     (McpServerToolCallContent value) =&gt; {...},
    ///     (GoogleSearchCallContent value) =&gt; {...},
    ///     (FileSearchCallContent value) =&gt; {...},
    ///     (GoogleMapsCallContent value) =&gt; {...},
    ///     (FunctionResultContent value) =&gt; {...},
    ///     (CodeExecutionResultContent value) =&gt; {...},
    ///     (UrlContextResultContent value) =&gt; {...},
    ///     (GoogleSearchResultContent value) =&gt; {...},
    ///     (McpServerToolResultContent value) =&gt; {...},
    ///     (FileSearchResultContent value) =&gt; {...},
    ///     (GoogleMapsResultContent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<TextContent, T> text,
        Func<ImageContent, T> image,
        Func<AudioContent, T> audio,
        Func<DocumentContent, T> document,
        Func<VideoContent, T> video,
        Func<ThoughtContent, T> thought,
        Func<FunctionCallContent, T> functionCall,
        Func<CodeExecutionCallContent, T> codeExecutionCall,
        Func<UrlContextCallContent, T> urlContextCall,
        Func<McpServerToolCallContent, T> mcpServerToolCall,
        Func<GoogleSearchCallContent, T> googleSearchCall,
        Func<FileSearchCallContent, T> fileSearchCall,
        Func<GoogleMapsCallContent, T> googleMapsCall,
        Func<FunctionResultContent, T> functionResult,
        Func<CodeExecutionResultContent, T> codeExecutionResult,
        Func<UrlContextResultContent, T> urlContextResult,
        Func<GoogleSearchResultContent, T> googleSearchResult,
        Func<McpServerToolResultContent, T> mcpServerToolResult,
        Func<FileSearchResultContent, T> fileSearchResult,
        Func<GoogleMapsResultContent, T> googleMapsResult
    )
    {
        return this.Value switch
        {
            TextContent value => text(value),
            ImageContent value => image(value),
            AudioContent value => audio(value),
            DocumentContent value => document(value),
            VideoContent value => video(value),
            ThoughtContent value => thought(value),
            FunctionCallContent value => functionCall(value),
            CodeExecutionCallContent value => codeExecutionCall(value),
            UrlContextCallContent value => urlContextCall(value),
            McpServerToolCallContent value => mcpServerToolCall(value),
            GoogleSearchCallContent value => googleSearchCall(value),
            FileSearchCallContent value => fileSearchCall(value),
            GoogleMapsCallContent value => googleMapsCall(value),
            FunctionResultContent value => functionResult(value),
            CodeExecutionResultContent value => codeExecutionResult(value),
            UrlContextResultContent value => urlContextResult(value),
            GoogleSearchResultContent value => googleSearchResult(value),
            McpServerToolResultContent value => mcpServerToolResult(value),
            FileSearchResultContent value => fileSearchResult(value),
            GoogleMapsResultContent value => googleMapsResult(value),
            _ => throw new GeminiNextGenApiInvalidDataException(
                "Data did not match any variant of Content"
            ),
        };
    }

    public static implicit operator Content(TextContent value) => new(value);

    public static implicit operator Content(ImageContent value) => new(value);

    public static implicit operator Content(AudioContent value) => new(value);

    public static implicit operator Content(DocumentContent value) => new(value);

    public static implicit operator Content(VideoContent value) => new(value);

    public static implicit operator Content(ThoughtContent value) => new(value);

    public static implicit operator Content(FunctionCallContent value) => new(value);

    public static implicit operator Content(CodeExecutionCallContent value) => new(value);

    public static implicit operator Content(UrlContextCallContent value) => new(value);

    public static implicit operator Content(McpServerToolCallContent value) => new(value);

    public static implicit operator Content(GoogleSearchCallContent value) => new(value);

    public static implicit operator Content(FileSearchCallContent value) => new(value);

    public static implicit operator Content(GoogleMapsCallContent value) => new(value);

    public static implicit operator Content(FunctionResultContent value) => new(value);

    public static implicit operator Content(CodeExecutionResultContent value) => new(value);

    public static implicit operator Content(UrlContextResultContent value) => new(value);

    public static implicit operator Content(GoogleSearchResultContent value) => new(value);

    public static implicit operator Content(McpServerToolResultContent value) => new(value);

    public static implicit operator Content(FileSearchResultContent value) => new(value);

    public static implicit operator Content(GoogleMapsResultContent value) => new(value);

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
                "Data did not match any variant of Content"
            );
        }
        this.Switch(
            (text) => text.Validate(),
            (image) => image.Validate(),
            (audio) => audio.Validate(),
            (document) => document.Validate(),
            (video) => video.Validate(),
            (thought) => thought.Validate(),
            (functionCall) => functionCall.Validate(),
            (codeExecutionCall) => codeExecutionCall.Validate(),
            (urlContextCall) => urlContextCall.Validate(),
            (mcpServerToolCall) => mcpServerToolCall.Validate(),
            (googleSearchCall) => googleSearchCall.Validate(),
            (fileSearchCall) => fileSearchCall.Validate(),
            (googleMapsCall) => googleMapsCall.Validate(),
            (functionResult) => functionResult.Validate(),
            (codeExecutionResult) => codeExecutionResult.Validate(),
            (urlContextResult) => urlContextResult.Validate(),
            (googleSearchResult) => googleSearchResult.Validate(),
            (mcpServerToolResult) => mcpServerToolResult.Validate(),
            (fileSearchResult) => fileSearchResult.Validate(),
            (googleMapsResult) => googleMapsResult.Validate()
        );
    }

    public virtual bool Equals(Content? other) =>
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
            AudioContent _ => 2,
            DocumentContent _ => 3,
            VideoContent _ => 4,
            ThoughtContent _ => 5,
            FunctionCallContent _ => 6,
            CodeExecutionCallContent _ => 7,
            UrlContextCallContent _ => 8,
            McpServerToolCallContent _ => 9,
            GoogleSearchCallContent _ => 10,
            FileSearchCallContent _ => 11,
            GoogleMapsCallContent _ => 12,
            FunctionResultContent _ => 13,
            CodeExecutionResultContent _ => 14,
            UrlContextResultContent _ => 15,
            GoogleSearchResultContent _ => 16,
            McpServerToolResultContent _ => 17,
            FileSearchResultContent _ => 18,
            GoogleMapsResultContent _ => 19,
            _ => -1,
        };
    }
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
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
            case "audio":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AudioContent>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<DocumentContent>(
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
            case "video":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<VideoContent>(element, options);
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
            case "thought":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThoughtContent>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<FunctionCallContent>(
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
            case "code_execution_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeExecutionCallContent>(
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
                    var deserialized = JsonSerializer.Deserialize<UrlContextCallContent>(
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
                    var deserialized = JsonSerializer.Deserialize<McpServerToolCallContent>(
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
            case "google_search_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleSearchCallContent>(
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
                    var deserialized = JsonSerializer.Deserialize<FileSearchCallContent>(
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
            case "google_maps_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GoogleMapsCallContent>(
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
            case "function_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FunctionResultContent>(
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
            case "code_execution_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeExecutionResultContent>(
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
                    var deserialized = JsonSerializer.Deserialize<UrlContextResultContent>(
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
                    var deserialized = JsonSerializer.Deserialize<GoogleSearchResultContent>(
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
                    var deserialized = JsonSerializer.Deserialize<McpServerToolResultContent>(
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
                    var deserialized = JsonSerializer.Deserialize<FileSearchResultContent>(
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
                    var deserialized = JsonSerializer.Deserialize<GoogleMapsResultContent>(
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
            default:
            {
                return new Content(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
