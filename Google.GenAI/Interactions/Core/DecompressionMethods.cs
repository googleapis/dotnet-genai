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
using System.IO.Compression;
using Net = System.Net;

namespace Google.GenAI.Interactions.Core;

static class DecompressionMethods
{
    internal static readonly Net::DecompressionMethods Available;

    static DecompressionMethods()
    {
        try
        {
            // Minimal valid GZip payload (empty body).
            var gzipPayload = new byte[]
            {
                0x1f,
                0x8b,
                0x08,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x03,
                0x03,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
            };
            using var memoryStream = new MemoryStream(gzipPayload);
            using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
            gzipStream.CopyTo(Stream.Null);
            Available = Net::DecompressionMethods.GZip;
        }
        catch
        {
            Available = Net::DecompressionMethods.None;
        }
    }
}
