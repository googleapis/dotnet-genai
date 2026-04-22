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
/// The configuration for speech interaction.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpeechConfig, SpeechConfigFromRaw>))]
public sealed record class SpeechConfig : JsonModel
{
    /// <summary>
    /// The language of the speech.
    /// </summary>
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
        }
    }

    /// <summary>
    /// The speaker's name, it should match the speaker name given in the prompt.
    /// </summary>
    public string? Speaker
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("speaker");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("speaker", value);
        }
    }

    /// <summary>
    /// The voice of the speaker.
    /// </summary>
    public string? Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("voice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("voice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Language;
        _ = this.Speaker;
        _ = this.Voice;
    }

    public SpeechConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpeechConfig(SpeechConfig speechConfig)
        : base(speechConfig) { }
#pragma warning restore CS8618

    public SpeechConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpeechConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpeechConfigFromRaw.FromRawUnchecked"/>
    public static SpeechConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpeechConfigFromRaw : IFromRawJson<SpeechConfig>
{
    /// <inheritdoc/>
    public SpeechConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpeechConfig.FromRawUnchecked(rawData);
}
