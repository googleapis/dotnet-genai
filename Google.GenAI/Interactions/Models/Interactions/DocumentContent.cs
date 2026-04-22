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
/// A document content block.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DocumentContent, DocumentContentFromRaw>))]
public sealed record class DocumentContent : JsonModel
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
    /// The document content.
    /// </summary>
    public string? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <summary>
    /// The mime type of the document.
    /// </summary>
    public ApiEnum<string, DocumentContentMimeType>? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DocumentContentMimeType>>(
                "mime_type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime_type", value);
        }
    }

    /// <summary>
    /// The URI of the document.
    /// </summary>
    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("document")))
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.Data;
        this.MimeType?.Validate();
        _ = this.Uri;
    }

    public DocumentContent()
    {
        this.Type = JsonSerializer.SerializeToElement("document");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentContent(DocumentContent documentContent)
        : base(documentContent) { }
#pragma warning restore CS8618

    public DocumentContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("document");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentContentFromRaw.FromRawUnchecked"/>
    public static DocumentContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DocumentContentFromRaw : IFromRawJson<DocumentContent>
{
    /// <inheritdoc/>
    public DocumentContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocumentContent.FromRawUnchecked(rawData);
}

/// <summary>
/// The mime type of the document.
/// </summary>
[JsonConverter(typeof(DocumentContentMimeTypeConverter))]
public enum DocumentContentMimeType
{
    ApplicationPdf,
}

sealed class DocumentContentMimeTypeConverter : JsonConverter<DocumentContentMimeType>
{
    public override DocumentContentMimeType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "application/pdf" => DocumentContentMimeType.ApplicationPdf,
            _ => (DocumentContentMimeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DocumentContentMimeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DocumentContentMimeType.ApplicationPdf => "application/pdf",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
