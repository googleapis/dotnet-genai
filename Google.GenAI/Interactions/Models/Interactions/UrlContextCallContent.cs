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
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// URL context content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UrlContextCallContent, UrlContextCallContentFromRaw>))]
public sealed record class UrlContextCallContent : JsonModel
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
    /// Required. The arguments to pass to the URL context.
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

    public UrlContextCallContent()
    {
        this.Type = JsonSerializer.SerializeToElement("url_context_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlContextCallContent(UrlContextCallContent urlContextCallContent)
        : base(urlContextCallContent) { }
#pragma warning restore CS8618

    public UrlContextCallContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("url_context_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlContextCallContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlContextCallContentFromRaw.FromRawUnchecked"/>
    public static UrlContextCallContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlContextCallContentFromRaw : IFromRawJson<UrlContextCallContent>
{
    /// <inheritdoc/>
    public UrlContextCallContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlContextCallContent.FromRawUnchecked(rawData);
}
