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

using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Google.GenAI.Interactions.Core;

namespace Google.GenAI.Interactions.Tests.Core;

public class MultipartJsonElementTest
{
    [Fact]
    public void NumberAndNumberEqual_Works()
    {
        MultipartJsonElement a = JsonSerializer.SerializeToElement(3);
        MultipartJsonElement b = JsonSerializer.SerializeToElement(3);
        Assert.True(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void NumberAndNumberNotEqual_Works()
    {
        MultipartJsonElement a = JsonSerializer.SerializeToElement(3);
        MultipartJsonElement b = JsonSerializer.SerializeToElement(4);
        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void StringAndStringEqual_Works()
    {
        MultipartJsonElement a = JsonSerializer.SerializeToElement("text");
        MultipartJsonElement b = JsonSerializer.SerializeToElement("text");
        Assert.True(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void StringAndStringNotEqual_Works()
    {
        MultipartJsonElement a = JsonSerializer.SerializeToElement("text");
        MultipartJsonElement b = JsonSerializer.SerializeToElement("test");
        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void StringAndNumberNotEqual1_Works()
    {
        MultipartJsonElement a = JsonSerializer.SerializeToElement("text");
        MultipartJsonElement b = JsonSerializer.SerializeToElement(3);
        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void StringAndNumberNotEqual1_Works1()
    {
        MultipartJsonElement a = JsonSerializer.SerializeToElement("text");
        MultipartJsonElement b = JsonSerializer.SerializeToElement(3);
        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void StringAndNumberNotEqual2_Works()
    {
        MultipartJsonElement a = JsonSerializer.SerializeToElement("3");
        MultipartJsonElement b = JsonSerializer.SerializeToElement(3);
        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void BinaryContentEqual_Works()
    {
        BinaryContent content = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(content);
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(content);

        Assert.True(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void BinaryContentDifferentReferencesNotEqual_Works()
    {
        BinaryContent contentA = Encoding.UTF8.GetBytes("text");
        BinaryContent contentB = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(contentA);
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(contentB);

        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void ArraysEqual_Works()
    {
        BinaryContent content1 = Encoding.UTF8.GetBytes("text");
        BinaryContent content2 = Encoding.UTF8.GetBytes("text");
        BinaryContent content3 = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(
            new List<BinaryContent> { content1, content2, content3 }
        );
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(
            new List<BinaryContent> { content1, content2, content3 }
        );

        Assert.True(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void ArrayMissingElementNotEqual_Works()
    {
        BinaryContent content1 = Encoding.UTF8.GetBytes("text");
        BinaryContent content2 = Encoding.UTF8.GetBytes("text");
        BinaryContent content3 = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(
            new List<BinaryContent> { content1, content2, content3 }
        );
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(
            new List<BinaryContent> { content1, content2 }
        );

        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void ArrayOutOfOrderNotEqual_Works()
    {
        BinaryContent content1 = Encoding.UTF8.GetBytes("text");
        BinaryContent content2 = Encoding.UTF8.GetBytes("text");
        BinaryContent content3 = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(
            new List<BinaryContent> { content1, content2, content3 }
        );
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(
            new List<BinaryContent> { content1, content3, content2 }
        );

        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void ObjectsEqual_Works()
    {
        BinaryContent content = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(
            new Dictionary<string, object>
            {
                { "string", "text" },
                { "number", -5 },
                { "binary", content },
            }
        );
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(
            new Dictionary<string, object>
            {
                { "string", "text" },
                { "number", -5 },
                { "binary", content },
            }
        );

        Assert.True(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void ObjectExtraKeyNotEqual_Works()
    {
        BinaryContent content = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(
            new Dictionary<string, object>
            {
                { "string", "text" },
                { "number", -5 },
                { "binary", content },
            }
        );
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(
            new Dictionary<string, object>
            {
                { "string", "text" },
                { "number", -5 },
                { "binary", content },
                { "extra", "test" },
            }
        );

        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }

    [Fact]
    public void ObjectExtraKeyNotEqual_Works1()
    {
        BinaryContent content = Encoding.UTF8.GetBytes("text");

        MultipartJsonElement a = MultipartJsonSerializer.SerializeToElement(
            new Dictionary<string, object>
            {
                { "string", "text" },
                { "number", -5 },
                { "binary", content },
            }
        );
        MultipartJsonElement b = MultipartJsonSerializer.SerializeToElement(
            new Dictionary<string, object> { { "string", "text" }, { "binary", content } }
        );

        Assert.False(MultipartJsonElement.DeepEquals(a, b));
    }
}
