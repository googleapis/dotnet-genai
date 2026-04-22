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
/// The arguments to pass to the code execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CodeExecutionCallArguments, CodeExecutionCallArgumentsFromRaw>)
)]
public sealed record class CodeExecutionCallArguments : JsonModel
{
    /// <summary>
    /// The code to be executed.
    /// </summary>
    public string? Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Programming language of the `code`.
    /// </summary>
    public ApiEnum<string, Language>? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Language>>("language");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        this.Language?.Validate();
    }

    public CodeExecutionCallArguments() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionCallArguments(CodeExecutionCallArguments codeExecutionCallArguments)
        : base(codeExecutionCallArguments) { }
#pragma warning restore CS8618

    public CodeExecutionCallArguments(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionCallArguments(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionCallArgumentsFromRaw.FromRawUnchecked"/>
    public static CodeExecutionCallArguments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionCallArgumentsFromRaw : IFromRawJson<CodeExecutionCallArguments>
{
    /// <inheritdoc/>
    public CodeExecutionCallArguments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionCallArguments.FromRawUnchecked(rawData);
}

/// <summary>
/// Programming language of the `code`.
/// </summary>
[JsonConverter(typeof(LanguageConverter))]
public enum Language
{
    Python,
}

sealed class LanguageConverter : JsonConverter<Language>
{
    public override Language Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "python" => Language.Python,
            _ => (Language)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Language value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Language.Python => "python",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
