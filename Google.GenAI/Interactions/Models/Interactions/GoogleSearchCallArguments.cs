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
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The arguments to pass to Google Search.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GoogleSearchCallArguments, GoogleSearchCallArgumentsFromRaw>)
)]
public sealed record class GoogleSearchCallArguments : JsonModel
{
    /// <summary>
    /// Web search queries for the following-up web search.
    /// </summary>
    public IReadOnlyList<string>? Queries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("queries");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "queries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Queries;
    }

    public GoogleSearchCallArguments() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GoogleSearchCallArguments(GoogleSearchCallArguments googleSearchCallArguments)
        : base(googleSearchCallArguments) { }
#pragma warning restore CS8618

    public GoogleSearchCallArguments(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GoogleSearchCallArguments(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GoogleSearchCallArgumentsFromRaw.FromRawUnchecked"/>
    public static GoogleSearchCallArguments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GoogleSearchCallArgumentsFromRaw : IFromRawJson<GoogleSearchCallArguments>
{
    /// <inheritdoc/>
    public GoogleSearchCallArguments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GoogleSearchCallArguments.FromRawUnchecked(rawData);
}
