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
/// Configuration for dynamic agents.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DynamicAgentConfig, DynamicAgentConfigFromRaw>))]
public sealed record class DynamicAgentConfig : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("dynamic")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
    }

    public DynamicAgentConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("dynamic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DynamicAgentConfig(DynamicAgentConfig dynamicAgentConfig)
        : base(dynamicAgentConfig) { }
#pragma warning restore CS8618

    public DynamicAgentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("dynamic");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DynamicAgentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DynamicAgentConfigFromRaw.FromRawUnchecked"/>
    public static DynamicAgentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DynamicAgentConfigFromRaw : IFromRawJson<DynamicAgentConfig>
{
    /// <inheritdoc/>
    public DynamicAgentConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DynamicAgentConfig.FromRawUnchecked(rawData);
}
