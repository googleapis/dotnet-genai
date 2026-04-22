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
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// Google Search content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GoogleSearchCallContent, GoogleSearchCallContentFromRaw>))]
public sealed record class GoogleSearchCallContent : JsonModel
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
    /// Required. The arguments to pass to Google Search.
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
    /// The type of search grounding enabled.
    /// </summary>
    public ApiEnum<string, SearchType>? SearchType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SearchType>>("search_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("search_type", value);
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
        this.SearchType?.Validate();
        _ = this.Signature;
    }

    public GoogleSearchCallContent()
    {
        this.Type = JsonSerializer.SerializeToElement("google_search_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleSearchCallContent(GoogleSearchCallContent googleSearchCallContent)
        : base(googleSearchCallContent) { }
#pragma warning restore CS8618

    public GoogleSearchCallContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_search_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleSearchCallContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleSearchCallContentFromRaw.FromRawUnchecked"/>
    public static GoogleSearchCallContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleSearchCallContentFromRaw : IFromRawJson<GoogleSearchCallContent>
{
    /// <inheritdoc/>
    public GoogleSearchCallContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GoogleSearchCallContent.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of search grounding enabled.
/// </summary>
[JsonConverter(typeof(SearchTypeConverter))]
public enum SearchType
{
    WebSearch,
    ImageSearch,
    EnterpriseWebSearch,
}

sealed class SearchTypeConverter : JsonConverter<SearchType>
{
    public override SearchType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "web_search" => SearchType.WebSearch,
            "image_search" => SearchType.ImageSearch,
            "enterprise_web_search" => SearchType.EnterpriseWebSearch,
            _ => (SearchType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SearchType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SearchType.WebSearch => "web_search",
                SearchType.ImageSearch => "image_search",
                SearchType.EnterpriseWebSearch => "enterprise_web_search",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
