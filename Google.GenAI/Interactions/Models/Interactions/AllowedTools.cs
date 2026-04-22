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
/// The configuration for allowed tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AllowedTools, AllowedToolsFromRaw>))]
public sealed record class AllowedTools : JsonModel
{
    /// <summary>
    /// The mode of the tool choice.
    /// </summary>
    public ApiEnum<string, ToolChoiceType>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToolChoiceType>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// The names of the allowed tools.
    /// </summary>
    public IReadOnlyList<string>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Mode?.Validate();
        _ = this.Tools;
    }

    public AllowedTools() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AllowedTools(AllowedTools allowedTools)
        : base(allowedTools) { }
#pragma warning restore CS8618

    public AllowedTools(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AllowedTools(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AllowedToolsFromRaw.FromRawUnchecked"/>
    public static AllowedTools FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AllowedToolsFromRaw : IFromRawJson<AllowedTools>
{
    /// <inheritdoc/>
    public AllowedTools FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AllowedTools.FromRawUnchecked(rawData);
}
