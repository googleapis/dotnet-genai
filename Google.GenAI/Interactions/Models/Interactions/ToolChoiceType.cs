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
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.GenAI.Interactions.Exceptions;

namespace Google.GenAI.Interactions.Models.Interactions;

[JsonConverter(typeof(ToolChoiceTypeConverter))]
public enum ToolChoiceType
{
    Auto,
    Any,
    None,
    Validated,
}

sealed class ToolChoiceTypeConverter : JsonConverter<ToolChoiceType>
{
    public override ToolChoiceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => ToolChoiceType.Auto,
            "any" => ToolChoiceType.Any,
            "none" => ToolChoiceType.None,
            "validated" => ToolChoiceType.Validated,
            _ => (ToolChoiceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolChoiceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolChoiceType.Auto => "auto",
                ToolChoiceType.Any => "any",
                ToolChoiceType.None => "none",
                ToolChoiceType.Validated => "validated",
                _ => throw new GeminiNextGenApiInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
