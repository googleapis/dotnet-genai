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
/// Configuration for the Deep Research agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeepResearchAgentConfig, DeepResearchAgentConfigFromRaw>))]
public sealed record class DeepResearchAgentConfig : JsonModel
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
    /// Enables human-in-the-loop planning for the Deep Research agent. If set to
    /// true, the Deep Research agent will provide a research plan in its response.
    /// The agent will then proceed only if the user confirms the plan in the next
    /// turn. Relevant issue: b/482352502.
    /// </summary>
    public bool? CollaborativePlanning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("collaborative_planning");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collaborative_planning", value);
        }
    }

    /// <summary>
    /// Whether to include thought summaries in the response.
    /// </summary>
    public ApiEnum<string, ThinkingSummaries>? ThinkingSummaries
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ThinkingSummaries>>(
                "thinking_summaries"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thinking_summaries", value);
        }
    }

    /// <summary>
    /// Whether to include visualizations in the response.
    /// </summary>
    public ApiEnum<string, Visualization>? Visualization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Visualization>>("visualization");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("visualization", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("deep-research")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.CollaborativePlanning;
        this.ThinkingSummaries?.Validate();
        this.Visualization?.Validate();
    }

    public DeepResearchAgentConfig()
    {
        this.Type = JsonSerializer.SerializeToElement("deep-research");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeepResearchAgentConfig(DeepResearchAgentConfig deepResearchAgentConfig)
        : base(deepResearchAgentConfig) { }
#pragma warning restore CS8618

    public DeepResearchAgentConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("deep-research");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeepResearchAgentConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeepResearchAgentConfigFromRaw.FromRawUnchecked"/>
    public static DeepResearchAgentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeepResearchAgentConfigFromRaw : IFromRawJson<DeepResearchAgentConfig>
{
    /// <inheritdoc/>
    public DeepResearchAgentConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeepResearchAgentConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether to include thought summaries in the response.
/// </summary>
[JsonConverter(typeof(ThinkingSummariesConverter))]
public enum ThinkingSummaries
{
    Auto,
    None,
}

sealed class ThinkingSummariesConverter : JsonConverter<ThinkingSummaries>
{
    public override ThinkingSummaries Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ThinkingSummaries.Auto,
            "none" => ThinkingSummaries.None,
            _ => (ThinkingSummaries)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThinkingSummaries value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThinkingSummaries.Auto => "auto",
                ThinkingSummaries.None => "none",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether to include visualizations in the response.
/// </summary>
[JsonConverter(typeof(VisualizationConverter))]
public enum Visualization
{
    Off,
    Auto,
}

sealed class VisualizationConverter : JsonConverter<Visualization>
{
    public override Visualization Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "off" => Visualization.Off,
            "auto" => Visualization.Auto,
            _ => (Visualization)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Visualization value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Visualization.Off => "off",
                Visualization.Auto => "auto",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
