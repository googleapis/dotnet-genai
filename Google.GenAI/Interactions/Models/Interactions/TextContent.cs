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
/// A text content block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TextContent, TextContentFromRaw>))]
public sealed record class TextContent : JsonModel
{
    /// <summary>
    /// Required. The text content.
    /// </summary>
    public string Text
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
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Annotations ?? Enumerable.Empty<Annotation>())
        {
            item.Validate();
        }
    }

    public TextContent()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextContent(TextContent textContent)
        : base(textContent) { }
#pragma warning restore CS8618

    public TextContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextContentFromRaw.FromRawUnchecked"/>
    public static TextContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextContent(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextContentFromRaw : IFromRawJson<TextContent>
{
    /// <inheritdoc/>
    public TextContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextContent.FromRawUnchecked(rawData);
}
