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
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// Statistics on the interaction request's token usage.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    /// <summary>
    /// A breakdown of cached token usage by modality.
    /// </summary>
    public IReadOnlyList<CachedTokensByModality>? CachedTokensByModality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CachedTokensByModality>>(
                "cached_tokens_by_modality"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CachedTokensByModality>?>(
                "cached_tokens_by_modality",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A breakdown of input token usage by modality.
    /// </summary>
    public IReadOnlyList<InputTokensByModality>? InputTokensByModality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InputTokensByModality>>(
                "input_tokens_by_modality"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<InputTokensByModality>?>(
                "input_tokens_by_modality",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A breakdown of output token usage by modality.
    /// </summary>
    public IReadOnlyList<OutputTokensByModality>? OutputTokensByModality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OutputTokensByModality>>(
                "output_tokens_by_modality"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<OutputTokensByModality>?>(
                "output_tokens_by_modality",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A breakdown of tool-use token usage by modality.
    /// </summary>
    public IReadOnlyList<ToolUseTokensByModality>? ToolUseTokensByModality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ToolUseTokensByModality>>(
                "tool_use_tokens_by_modality"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ToolUseTokensByModality>?>(
                "tool_use_tokens_by_modality",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Number of tokens in the cached part of the prompt (the cached content).
    /// </summary>
    public int? TotalCachedTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_cached_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_cached_tokens", value);
        }
    }

    /// <summary>
    /// Number of tokens in the prompt (context).
    /// </summary>
    public int? TotalInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_input_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_input_tokens", value);
        }
    }

    /// <summary>
    /// Total number of tokens across all the generated responses.
    /// </summary>
    public int? TotalOutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_output_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_output_tokens", value);
        }
    }

    /// <summary>
    /// Number of tokens of thoughts for thinking models.
    /// </summary>
    public int? TotalThoughtTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_thought_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_thought_tokens", value);
        }
    }

    /// <summary>
    /// Total token count for the interaction request (prompt + responses + other
    /// internal tokens).
    /// </summary>
    public int? TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_tokens", value);
        }
    }

    /// <summary>
    /// Number of tokens present in tool-use prompt(s).
    /// </summary>
    public int? TotalToolUseTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("total_tool_use_tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_tool_use_tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (
            var item in this.CachedTokensByModality ?? Enumerable.Empty<CachedTokensByModality>()
        )
        {
            item.Validate();
        }
        foreach (
            var item in this.InputTokensByModality ?? Enumerable.Empty<InputTokensByModality>()
        )
        {
            item.Validate();
        }
        foreach (
            var item in this.OutputTokensByModality ?? Enumerable.Empty<OutputTokensByModality>()
        )
        {
            item.Validate();
        }
        foreach (
            var item in this.ToolUseTokensByModality ?? Enumerable.Empty<ToolUseTokensByModality>()
        )
        {
            item.Validate();
        }
        _ = this.TotalCachedTokens;
        _ = this.TotalInputTokens;
        _ = this.TotalOutputTokens;
        _ = this.TotalThoughtTokens;
        _ = this.TotalTokens;
        _ = this.TotalToolUseTokens;
    }

    public Usage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage(Usage usage)
        : base(usage) { }
#pragma warning restore CS8618

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}

/// <summary>
/// The token count for a single response modality.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CachedTokensByModality, CachedTokensByModalityFromRaw>))]
public sealed record class CachedTokensByModality : JsonModel
{
    /// <summary>
    /// The modality associated with the token count.
    /// </summary>
    public ApiEnum<string, Modality>? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Modality>>("modality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("modality", value);
        }
    }

    /// <summary>
    /// Number of tokens for the modality.
    /// </summary>
    public int? Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Modality?.Validate();
        _ = this.Tokens;
    }

    public CachedTokensByModality() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CachedTokensByModality(CachedTokensByModality cachedTokensByModality)
        : base(cachedTokensByModality) { }
#pragma warning restore CS8618

    public CachedTokensByModality(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CachedTokensByModality(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CachedTokensByModalityFromRaw.FromRawUnchecked"/>
    public static CachedTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CachedTokensByModalityFromRaw : IFromRawJson<CachedTokensByModality>
{
    /// <inheritdoc/>
    public CachedTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CachedTokensByModality.FromRawUnchecked(rawData);
}

/// <summary>
/// The modality associated with the token count.
/// </summary>
[JsonConverter(typeof(ModalityConverter))]
public enum Modality
{
    Text,
    Image,
    Audio,
    Video,
    Document,
}

sealed class ModalityConverter : JsonConverter<Modality>
{
    public override Modality Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => Modality.Text,
            "image" => Modality.Image,
            "audio" => Modality.Audio,
            "video" => Modality.Video,
            "document" => Modality.Document,
            _ => (Modality)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Modality value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Modality.Text => "text",
                Modality.Image => "image",
                Modality.Audio => "audio",
                Modality.Video => "video",
                Modality.Document => "document",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The token count for a single response modality.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InputTokensByModality, InputTokensByModalityFromRaw>))]
public sealed record class InputTokensByModality : JsonModel
{
    /// <summary>
    /// The modality associated with the token count.
    /// </summary>
    public ApiEnum<string, InputTokensByModalityModality>? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InputTokensByModalityModality>>(
                "modality"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("modality", value);
        }
    }

    /// <summary>
    /// Number of tokens for the modality.
    /// </summary>
    public int? Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Modality?.Validate();
        _ = this.Tokens;
    }

    public InputTokensByModality() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InputTokensByModality(InputTokensByModality inputTokensByModality)
        : base(inputTokensByModality) { }
#pragma warning restore CS8618

    public InputTokensByModality(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InputTokensByModality(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InputTokensByModalityFromRaw.FromRawUnchecked"/>
    public static InputTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InputTokensByModalityFromRaw : IFromRawJson<InputTokensByModality>
{
    /// <inheritdoc/>
    public InputTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InputTokensByModality.FromRawUnchecked(rawData);
}

/// <summary>
/// The modality associated with the token count.
/// </summary>
[JsonConverter(typeof(InputTokensByModalityModalityConverter))]
public enum InputTokensByModalityModality
{
    Text,
    Image,
    Audio,
    Video,
    Document,
}

sealed class InputTokensByModalityModalityConverter : JsonConverter<InputTokensByModalityModality>
{
    public override InputTokensByModalityModality Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => InputTokensByModalityModality.Text,
            "image" => InputTokensByModalityModality.Image,
            "audio" => InputTokensByModalityModality.Audio,
            "video" => InputTokensByModalityModality.Video,
            "document" => InputTokensByModalityModality.Document,
            _ => (InputTokensByModalityModality)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InputTokensByModalityModality value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InputTokensByModalityModality.Text => "text",
                InputTokensByModalityModality.Image => "image",
                InputTokensByModalityModality.Audio => "audio",
                InputTokensByModalityModality.Video => "video",
                InputTokensByModalityModality.Document => "document",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The token count for a single response modality.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OutputTokensByModality, OutputTokensByModalityFromRaw>))]
public sealed record class OutputTokensByModality : JsonModel
{
    /// <summary>
    /// The modality associated with the token count.
    /// </summary>
    public ApiEnum<string, OutputTokensByModalityModality>? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OutputTokensByModalityModality>>(
                "modality"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("modality", value);
        }
    }

    /// <summary>
    /// Number of tokens for the modality.
    /// </summary>
    public int? Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Modality?.Validate();
        _ = this.Tokens;
    }

    public OutputTokensByModality() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutputTokensByModality(OutputTokensByModality outputTokensByModality)
        : base(outputTokensByModality) { }
#pragma warning restore CS8618

    public OutputTokensByModality(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OutputTokensByModality(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputTokensByModalityFromRaw.FromRawUnchecked"/>
    public static OutputTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OutputTokensByModalityFromRaw : IFromRawJson<OutputTokensByModality>
{
    /// <inheritdoc/>
    public OutputTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OutputTokensByModality.FromRawUnchecked(rawData);
}

/// <summary>
/// The modality associated with the token count.
/// </summary>
[JsonConverter(typeof(OutputTokensByModalityModalityConverter))]
public enum OutputTokensByModalityModality
{
    Text,
    Image,
    Audio,
    Video,
    Document,
}

sealed class OutputTokensByModalityModalityConverter : JsonConverter<OutputTokensByModalityModality>
{
    public override OutputTokensByModalityModality Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => OutputTokensByModalityModality.Text,
            "image" => OutputTokensByModalityModality.Image,
            "audio" => OutputTokensByModalityModality.Audio,
            "video" => OutputTokensByModalityModality.Video,
            "document" => OutputTokensByModalityModality.Document,
            _ => (OutputTokensByModalityModality)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OutputTokensByModalityModality value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OutputTokensByModalityModality.Text => "text",
                OutputTokensByModalityModality.Image => "image",
                OutputTokensByModalityModality.Audio => "audio",
                OutputTokensByModalityModality.Video => "video",
                OutputTokensByModalityModality.Document => "document",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The token count for a single response modality.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolUseTokensByModality, ToolUseTokensByModalityFromRaw>))]
public sealed record class ToolUseTokensByModality : JsonModel
{
    /// <summary>
    /// The modality associated with the token count.
    /// </summary>
    public ApiEnum<string, ToolUseTokensByModalityModality>? Modality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToolUseTokensByModalityModality>>(
                "modality"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("modality", value);
        }
    }

    /// <summary>
    /// Number of tokens for the modality.
    /// </summary>
    public int? Tokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("tokens");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tokens", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Modality?.Validate();
        _ = this.Tokens;
    }

    public ToolUseTokensByModality() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUseTokensByModality(ToolUseTokensByModality toolUseTokensByModality)
        : base(toolUseTokensByModality) { }
#pragma warning restore CS8618

    public ToolUseTokensByModality(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUseTokensByModality(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUseTokensByModalityFromRaw.FromRawUnchecked"/>
    public static ToolUseTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolUseTokensByModalityFromRaw : IFromRawJson<ToolUseTokensByModality>
{
    /// <inheritdoc/>
    public ToolUseTokensByModality FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolUseTokensByModality.FromRawUnchecked(rawData);
}

/// <summary>
/// The modality associated with the token count.
/// </summary>
[JsonConverter(typeof(ToolUseTokensByModalityModalityConverter))]
public enum ToolUseTokensByModalityModality
{
    Text,
    Image,
    Audio,
    Video,
    Document,
}

sealed class ToolUseTokensByModalityModalityConverter
    : JsonConverter<ToolUseTokensByModalityModality>
{
    public override ToolUseTokensByModalityModality Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => ToolUseTokensByModalityModality.Text,
            "image" => ToolUseTokensByModalityModality.Image,
            "audio" => ToolUseTokensByModalityModality.Audio,
            "video" => ToolUseTokensByModalityModality.Video,
            "document" => ToolUseTokensByModalityModality.Document,
            _ => (ToolUseTokensByModalityModality)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolUseTokensByModalityModality value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolUseTokensByModalityModality.Text => "text",
                ToolUseTokensByModalityModality.Image => "image",
                ToolUseTokensByModalityModality.Audio => "audio",
                ToolUseTokensByModalityModality.Video => "video",
                ToolUseTokensByModalityModality.Document => "document",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
