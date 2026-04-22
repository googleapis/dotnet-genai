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

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// The tool choice configuration containing allowed tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolChoiceConfig, ToolChoiceConfigFromRaw>))]
public sealed record class ToolChoiceConfig : JsonModel
{
    /// <summary>
    /// The allowed tools.
    /// </summary>
    public AllowedTools? AllowedTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AllowedTools>("allowed_tools");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allowed_tools", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllowedTools?.Validate();
    }

    public ToolChoiceConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolChoiceConfig(ToolChoiceConfig toolChoiceConfig)
        : base(toolChoiceConfig) { }
#pragma warning restore CS8618

    public ToolChoiceConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolChoiceConfigFromRaw.FromRawUnchecked"/>
    public static ToolChoiceConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolChoiceConfigFromRaw : IFromRawJson<ToolChoiceConfig>
{
    /// <inheritdoc/>
    public ToolChoiceConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolChoiceConfig.FromRawUnchecked(rawData);
}
