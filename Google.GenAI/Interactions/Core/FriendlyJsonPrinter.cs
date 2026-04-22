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
using System.Collections.Generic;
using System.Text.Json;

namespace Google.GenAI.Interactions.Core;

static class FriendlyJsonPrinter
{
    public static JsonElement PrintValue(JsonElement value) => value;

    public static JsonElement PrintValue(IReadOnlyDictionary<string, JsonElement> value) =>
        JsonSerializer.SerializeToElement(value);

    public static JsonElement PrintValue(IReadOnlyList<JsonElement> value) =>
        JsonSerializer.SerializeToElement(value);

    public static JsonElement PrintValue(IReadOnlyDictionary<string, MultipartJsonElement> value)
    {
        int binaryContentCount = 0;
        var ret = new Dictionary<string, JsonElement>();
        foreach (var item in value)
        {
            ret[item.Key] = PrintValue(
                item.Value.Json,
                item.Value.BinaryContents,
                ref binaryContentCount
            );
        }
        return PrintValue(ret);
    }

    public static JsonElement PrintValue(MultipartJsonElement value)
    {
        int binaryContentCount = 0;
        return PrintValue(value.Json, value.BinaryContents, ref binaryContentCount);
    }

    static JsonElement PrintValue(
        JsonElement json,
        IReadOnlyDictionary<Guid, BinaryContent> binaryContent,
        ref int binaryContentCount
    )
    {
        switch (json.ValueKind)
        {
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
                return json;
            case JsonValueKind.String:
                return json.TryGetGuid(out var guid) && binaryContent.ContainsKey(guid)
                    ? JsonSerializer.SerializeToElement($"[Binary Content {binaryContentCount++}]")
                    : json;
            case JsonValueKind.Object:
            {
                var ret = new Dictionary<string, JsonElement>();
                foreach (var item in json.EnumerateObject())
                {
                    ret[item.Name] = PrintValue(item.Value, binaryContent, ref binaryContentCount);
                }
                return PrintValue(ret);
            }
            case JsonValueKind.Array:
            {
                var ret = new List<JsonElement>();
                foreach (var item in json.EnumerateArray())
                {
                    ret.Add(PrintValue(item, binaryContent, ref binaryContentCount));
                }
                return PrintValue(ret);
            }
            default:
                throw new InvalidOperationException("Unreachable");
        }
    }
}
