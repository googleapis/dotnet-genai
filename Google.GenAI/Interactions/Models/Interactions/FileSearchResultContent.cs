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
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

/// <summary>
/// File Search result content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileSearchResultContent, FileSearchResultContentFromRaw>))]
public sealed record class FileSearchResultContent : JsonModel
{
    /// <summary>
    /// Required. ID to match the ID from the function call block.
    /// </summary>
    public string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("call_id");
        }
        init { this._rawData.Set("call_id", value); }
    }

    /// <summary>
    /// Required. The results of the File Search.
    /// </summary>
    public IReadOnlyList<FileSearchResultContentResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FileSearchResultContentResult>>(
                "result"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FileSearchResultContentResult>>(
                "result",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.CallID;
        foreach (var item in this.Result)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("file_search_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
    }

    public FileSearchResultContent()
    {
        this.Type = JsonSerializer.SerializeToElement("file_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileSearchResultContent(FileSearchResultContent fileSearchResultContent)
        : base(fileSearchResultContent) { }
#pragma warning restore CS8618

    public FileSearchResultContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file_search_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileSearchResultContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileSearchResultContentFromRaw.FromRawUnchecked"/>
    public static FileSearchResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileSearchResultContentFromRaw : IFromRawJson<FileSearchResultContent>
{
    /// <inheritdoc/>
    public FileSearchResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileSearchResultContent.FromRawUnchecked(rawData);
}

/// <summary>
/// The result of the File Search.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FileSearchResultContentResult, FileSearchResultContentResultFromRaw>)
)]
public sealed record class FileSearchResultContentResult : JsonModel
{
    /// <summary>
    /// User provided metadata about the FileSearchResult.
    /// </summary>
    public IReadOnlyList<JsonElement>? CustomMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<JsonElement>>("custom_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<JsonElement>?>(
                "custom_metadata",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomMetadata;
    }

    public FileSearchResultContentResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileSearchResultContentResult(
        FileSearchResultContentResult fileSearchResultContentResult
    )
        : base(fileSearchResultContentResult) { }
#pragma warning restore CS8618

    public FileSearchResultContentResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileSearchResultContentResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileSearchResultContentResultFromRaw.FromRawUnchecked"/>
    public static FileSearchResultContentResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileSearchResultContentResultFromRaw : IFromRawJson<FileSearchResultContentResult>
{
    /// <inheritdoc/>
    public FileSearchResultContentResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileSearchResultContentResult.FromRawUnchecked(rawData);
}
