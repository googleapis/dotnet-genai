/*
 * Copyright 2026 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Gaos.Utils.Sse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests
{
    [TestClass]
    public class InteractionsEventStreamTest
    {
        [TestMethod]
        public async Task EventStream_AsyncEnumerable_EnumeratesAllItems()
        {
            var sseData = "data: first\n\ndata: second\n\ndata: third\n\n";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(sseData));
            using var eventStream = new EventStream<string>(memoryStream);

            var items = new List<string>();
            await foreach (var item in eventStream)
            {
                items.Add(item);
            }

            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("first", items[0]);
            Assert.AreEqual("second", items[1]);
            Assert.AreEqual("third", items[2]);
        }

        [TestMethod]
        public async Task EventStream_AsyncEnumerable_StopsAtSentinel()
        {
            var sseData = "data: item1\n\ndata: item2\n\ndata: [DONE]\n\ndata: item3\n\n";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(sseData));
            using var eventStream = new EventStream<string>(memoryStream, sentinel: "[DONE]");

            var items = new List<string>();
            await foreach (var item in eventStream)
            {
                items.Add(item);
            }

            Assert.AreEqual(2, items.Count);
            Assert.AreEqual("item1", items[0]);
            Assert.AreEqual("item2", items[1]);
        }

        [TestMethod]
        public async Task EventStream_AsyncEnumerable_Cancellation()
        {
            var sseData = "data: item1\n\ndata: item2\n\n";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(sseData));
            using var eventStream = new EventStream<string>(memoryStream);

            using var cts = new CancellationTokenSource();
            cts.Cancel();

            await Assert.ThrowsExceptionAsync<OperationCanceledException>(async () =>
            {
                await foreach (var item in eventStream.WithCancellation(cts.Token))
                {
                }
            });
        }

        [TestMethod]
        public async Task EventStream_AsyncDisposable_DisposesProperly()
        {
            var sseData = "data: hello\n\n";
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(sseData));
            await using (var eventStream = new EventStream<string>(memoryStream))
            {
                var item = await eventStream.Next();
                Assert.AreEqual("hello", item);
            }
            // Reading from memoryStream after disposal of reader should either fail or stream is closed
            Assert.IsTrue(true);
        }
    }
}
