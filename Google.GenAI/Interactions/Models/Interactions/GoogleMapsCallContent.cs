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
/// Google Maps content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GoogleMapsCallContent, GoogleMapsCallContentFromRaw>))]
public sealed record class GoogleMapsCallContent : JsonModel
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

    public GoogleMapsCallContent()
    {
        this.Type = JsonSerializer.SerializeToElement("google_maps_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleMapsCallContent(GoogleMapsCallContent googleMapsCallContent)
        : base(googleMapsCallContent) { }
#pragma warning restore CS8618

    public GoogleMapsCallContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("google_maps_call");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleMapsCallContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleMapsCallContentFromRaw.FromRawUnchecked"/>
    public static GoogleMapsCallContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GoogleMapsCallContent(string id)
        : this()
    {
        this.ID = id;
    }
}

class GoogleMapsCallContentFromRaw : IFromRawJson<GoogleMapsCallContent>
{
    /// <inheritdoc/>
    public GoogleMapsCallContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GoogleMapsCallContent.FromRawUnchecked(rawData);
}
