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
/// A file citation annotation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileCitation, FileCitationFromRaw>))]
public sealed record class FileCitation : JsonModel
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
    /// The URI of the file.
    /// </summary>
    public string? DocumentUri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("document_uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("document_uri", value);
        }
    }

    /// <summary>
    /// End of the attributed segment, exclusive.
    /// </summary>
    public int? EndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("end_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("end_index", value);
        }
    }

    /// <summary>
    /// The name of the file.
    /// </summary>
    public string? FileName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("file_name", value);
        }
    }

    /// <summary>
    /// Source attributed for a portion of the text.
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <summary>
    /// Start of segment of the response that is attributed to this source.
    ///
    /// <para>Index indicates the start of the segment, measured in bytes.</para>
    /// </summary>
    public int? StartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("start_index");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start_index", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file_citation")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.DocumentUri;
        _ = this.EndIndex;
        _ = this.FileName;
        _ = this.Source;
        _ = this.StartIndex;
    }

    public FileCitation()
    {
        this.Type = JsonSerializer.SerializeToElement("file_citation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileCitation(FileCitation fileCitation)
        : base(fileCitation) { }
#pragma warning restore CS8618

    public FileCitation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file_citation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCitation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileCitationFromRaw.FromRawUnchecked"/>
    public static FileCitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileCitationFromRaw : IFromRawJson<FileCitation>
{
    /// <inheritdoc/>
    public FileCitation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileCitation.FromRawUnchecked(rawData);
}
