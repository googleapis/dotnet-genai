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
/// Code execution result content.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CodeExecutionResultContent, CodeExecutionResultContentFromRaw>)
)]
public sealed record class CodeExecutionResultContent : JsonModel
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
    /// Required. The output of the code execution.
    /// </summary>
    public string Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("result");
        }
        init { this._rawData.Set("result", value); }
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
    /// Whether the code execution resulted in an error.
    /// </summary>
    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
        }
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
        _ = this.Result;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_result")
            )
        )
        {
            throw new GeminiNextGenApiInvalidDataException("Invalid value given for constant");
        }
        _ = this.IsError;
        _ = this.Signature;
    }

    public CodeExecutionResultContent()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionResultContent(CodeExecutionResultContent codeExecutionResultContent)
        : base(codeExecutionResultContent) { }
#pragma warning restore CS8618

    public CodeExecutionResultContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionResultContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionResultContentFromRaw.FromRawUnchecked"/>
    public static CodeExecutionResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionResultContentFromRaw : IFromRawJson<CodeExecutionResultContent>
{
    /// <inheritdoc/>
    public CodeExecutionResultContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionResultContent.FromRawUnchecked(rawData);
}
