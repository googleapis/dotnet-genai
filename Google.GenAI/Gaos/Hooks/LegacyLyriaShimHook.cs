// Copyright 2026 Google LLC
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
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Google.GenAI.Gaos.Hooks
{
    public class LegacyLyriaShimHook : IAfterSuccessHook
    {
        public async Task<HttpResponseMessage> AfterSuccessAsync(AfterSuccessContext hookCtx, HttpResponseMessage response)
        {
            if (response.Content == null)
            {
                return response;
            }

            var contentType = response.Content.Headers.ContentType?.MediaType;
            if (string.Equals(contentType, "text/event-stream", StringComparison.OrdinalIgnoreCase))
            {
                var originalStream = await response.Content.ReadAsStreamAsync();
                var shimStream = new LegacyLyriaShimStream(originalStream);
                response.Content = new ShimHttpContent(response.Content, shimStream);
            }
            else if (string.Equals(contentType, "application/json", StringComparison.OrdinalIgnoreCase))
            {
                var json = await response.Content.ReadAsStringAsync();
                try
                {
                    var token = JToken.Parse(json);
                    var rewrittenToken = RewriteInteractionJson(token);
                    var newJson = rewrittenToken.ToString(Formatting.None);
                    response.Content = new StringContent(newJson, Encoding.UTF8, "application/json");
                }
                catch
                {
                    // Ignore JSON parsing errors
                }
            }

            return response;
        }

        private static JToken RewriteInteractionJson(JToken token)
        {
            if (token is JObject obj)
            {
                var model = obj["model"]?.ToString();
                if (model == "lyria-3-pro-preview" || model == "lyria-3-clip-preview")
                {
                    var outputs = obj["outputs"];
                    if (outputs != null && obj["steps"] == null)
                    {
                        if (outputs is JArray arr)
                        {
                            foreach (var item in arr)
                            {
                                if (item is JObject itemObj)
                                {
                                    HoistPartsToText(itemObj);
                                }
                            }
                        }
                        obj.Remove("outputs");
                        obj["steps"] = new JArray(new JObject
                        {
                            ["type"] = "model_output",
                            ["content"] = outputs
                        });
                    }
                }

                foreach (var prop in obj.Properties())
                {
                    RewriteInteractionJson(prop.Value);
                }
            }
            else if (token is JArray arr)
            {
                foreach (var item in arr)
                {
                    RewriteInteractionJson(item);
                }
            }
            return token;
        }

        private static void HoistPartsToText(JObject obj)
        {
            if (obj["type"] == null)
            {
                obj["type"] = "text";
            }
            if (obj["parts"] is JArray parts && parts.Count > 0 && parts[0] is JObject partObj)
            {
                var textVal = partObj["text"];
                if (textVal != null)
                {
                    obj["text"] = textVal;
                    obj.Remove("parts");
                }
            }
        }

        private class ShimHttpContent : HttpContent
        {
            private readonly Stream _shimStream;

            public ShimHttpContent(HttpContent originalContent, Stream shimStream)
            {
                _shimStream = shimStream;
                foreach (var header in originalContent.Headers)
                {
                    Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            protected override Task<Stream> CreateContentReadStreamAsync()
            {
                return Task.FromResult(_shimStream);
            }

            protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
            {
                throw new NotSupportedException();
            }

            protected override bool TryComputeLength(out long length)
            {
                length = -1;
                return false;
            }
        }

        private class LegacyLyriaShimStream : Stream
        {
            private readonly Stream _originalStream;
            private readonly StreamReader _reader;
            private readonly MemoryStream _bufferStream;

            private static readonly Dictionary<string, string> LegacyEventRenames = new Dictionary<string, string>
            {
                { "interaction.start", "interaction.created" },
                { "content.start", "step.start" },
                { "content.delta", "step.delta" },
                { "content.stop", "step.stop" },
                { "interaction.complete", "interaction.completed" }
            };

            public LegacyLyriaShimStream(Stream originalStream)
            {
                _originalStream = originalStream;
                _reader = new StreamReader(originalStream, Encoding.UTF8);
                _bufferStream = new MemoryStream();
            }

            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();
            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public override void Flush() => _originalStream.Flush();
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

            public override int Read(byte[] buffer, int offset, int count)
            {
                return ReadAsync(buffer, offset, count, CancellationToken.None).GetAwaiter().GetResult();
            }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                if (_bufferStream.Position >= _bufferStream.Length)
                {
                    _bufferStream.SetLength(0);
                    _bufferStream.Position = 0;

                    var lines = new List<string>();
                    string? line;
#if NETSTANDARD2_0
                    while ((line = await _reader.ReadLineAsync()) != null)
#else
                    while ((line = await _reader.ReadLineAsync(cancellationToken)) != null)
#endif
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            if (lines.Count > 0)
                            {
                                break;
                            }
                            continue;
                        }
                        lines.Add(line);
                    }

                    if (lines.Count == 0)
                    {
                        return 0; // EOF
                    }

                    var rewrittenLines = ProcessMessageLines(lines);

                    using (var writer = new StreamWriter(_bufferStream, Encoding.UTF8, 1024, leaveOpen: true))
                    {
                        foreach (var rl in rewrittenLines)
                        {
                            await writer.WriteLineAsync(rl);
                        }
                        await writer.WriteLineAsync(); // double newline separator
#if NETSTANDARD2_0
                        await writer.FlushAsync();
#else
                        await writer.FlushAsync(cancellationToken);
#endif
                    }
                    _bufferStream.Position = 0;
                }

                int read = await _bufferStream.ReadAsync(buffer, offset, count, cancellationToken);
                return read;
            }

            private List<string> ProcessMessageLines(List<string> lines)
            {
                string? eventType = null;
                string? dataStr = null;
                var otherLines = new List<string>();

                foreach (var line in lines)
                {
                    if (line.StartsWith("event:"))
                    {
                        eventType = line.Substring(6).Trim();
                    }
                    else if (line.StartsWith("data:"))
                    {
                        dataStr = line.Substring(5).Trim();
                    }
                    else
                    {
                        otherLines.Add(line);
                    }
                }

                if (eventType == null || !LegacyEventRenames.TryGetValue(eventType, out var newEventType))
                {
                    if (dataStr != null)
                    {
                        try
                        {
                            var dataObj = JToken.Parse(dataStr);
                            RewriteInteractionJson(dataObj);
                            dataStr = dataObj.ToString(Formatting.None);
                        }
                        catch { }
                    }
                    
                    var origLines = new List<string>();
                    if (eventType != null) origLines.Add($"event: {eventType}");
                    if (dataStr != null) origLines.Add($"data: {dataStr}");
                    origLines.AddRange(otherLines);
                    return origLines;
                }

                if (eventType == "content.start" && dataStr != null)
                {
                    try
                    {
                        var dataObj = JObject.Parse(dataStr);
                        var content = dataObj["content"];
                        if (content is JObject contentObj)
                        {
                            HoistPartsToText(contentObj);
                        }
                        dataObj.Remove("content");
                        dataObj["step"] = new JObject
                        {
                            ["type"] = "model_output",
                            ["content"] = content != null ? new JArray(content) : new JArray()
                        };
                        dataStr = dataObj.ToString(Formatting.None);
                    }
                    catch
                    {
                        // Ignore JSON parsing errors
                    }
                }

                if (eventType == "content.delta" && dataStr != null)
                {
                    try
                    {
                        var dataObj = JObject.Parse(dataStr);
                        var delta = dataObj["delta"];
                        if (delta is JObject deltaObj)
                        {
                            HoistPartsToText(deltaObj);
                        }
                        dataStr = dataObj.ToString(Formatting.None);
                    }
                    catch { }
                }

                if (dataStr != null)
                {
                    try
                    {
                        var dataObj = JToken.Parse(dataStr);
                        RewriteInteractionJson(dataObj);
                        if (dataObj is JObject jobj && jobj["event_type"] == null)
                        {
                            jobj["event_type"] = newEventType;
                        }
                        dataStr = dataObj.ToString(Formatting.None);
                    }
                    catch { }
                }

                var result = new List<string>();
                result.Add($"event: {newEventType}");
                if (dataStr != null)
                {
                    result.Add($"data: {dataStr}");
                }
                result.AddRange(otherLines);
                return result;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _reader.Dispose();
                    _bufferStream.Dispose();
                    _originalStream.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}
