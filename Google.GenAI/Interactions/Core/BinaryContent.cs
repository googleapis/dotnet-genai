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

using System.IO;
using System.Net.Http.Headers;

namespace Google.GenAI.Interactions.Core;

/// <summary>
/// A class representing a binary stream of data with its associated (optional) file
/// name and content type.
/// </summary>
public sealed record class BinaryContent
{
    public Stream Stream { get; init; } = null!;
    public string? FileName { get; init; }
    public MediaTypeHeaderValue ContentType { get; set; } = new("application/octet-stream");

    public static implicit operator BinaryContent(Stream stream) =>
        new()
        {
            Stream = stream,
            FileName = stream is FileStream fileStream ? Path.GetFileName(fileStream.Name) : null,
        };

    public static implicit operator BinaryContent(byte[] bytes) =>
        new() { Stream = new MemoryStream(bytes) };
}
