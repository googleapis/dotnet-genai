/*
 * Copyright 2025 Google LLC
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Google.GenAI;

namespace Google.GenAI.Tests
{
    [TestClass]
    public class CommonTest
    {
        [TestMethod]
        public void SetValueByPath_Basic()
        {
            var data = new JsonObject();
            Common.SetValueByPath(data, new string[] { "a", "b", "c" }, 42);

            Assert.AreEqual(42, (int)data["a"]["b"]["c"]);
        }

        [TestMethod]
        public void SetValueByPath_ParallelList()
        {
            var data = new JsonObject();
            var values = new List<string> { "gs://file1", "gs://file2" };

            // 1:1 Mapping - Each value in the list goes to its own object in the array.
            Common.SetValueByPath(data, new string[] { "request", "uris[]", "uri" }, values);

            var array = data["request"]["uris"] as JsonArray;
            Assert.IsNotNull(array);
            Assert.AreEqual(2, array.Count);
            Assert.AreEqual("gs://file1", array[0]["uri"].GetValue<string>());
            Assert.AreEqual("gs://file2", array[1]["uri"].GetValue<string>());
        }

        [TestMethod]
        public void SetValueByPath_BroadcastValue()
        {
            var data = new JsonObject();

            // 1:N Mapping - A single value is "broadcast" to all objects in the array.
            // First, create an array with 3 objects.
            data["parts"] = new JsonArray { new JsonObject(), new JsonObject(), new JsonObject() };

            Common.SetValueByPath(data, new string[] { "parts[]", "role" }, "user");

            var array = data["parts"] as JsonArray;
            Assert.AreEqual(3, array.Count);
            Assert.AreEqual("user", array[0]["role"].GetValue<string>());
            Assert.AreEqual("user", array[1]["role"].GetValue<string>());
            Assert.AreEqual("user", array[2]["role"].GetValue<string>());
        }

        [TestMethod]
        public void MoveValueByPath_Wildcard()
        {
            var data = new JsonObject
            {
                ["requests"] = new JsonArray
                {
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = new JsonObject
                            {
                                ["parts"] = new JsonArray
                                {
                                    new JsonObject { ["text"] = "1" }
                                }
                            }
                        },
                        ["outputDimensionality"] = 64
                    },
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = new JsonObject
                            {
                                ["parts"] = new JsonArray
                                {
                                    new JsonObject { ["text"] = "2" }
                                }
                            }
                        },
                        ["outputDimensionality"] = 64
                    },
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = new JsonObject
                            {
                                ["parts"] = new JsonArray
                                {
                                    new JsonObject { ["text"] = "3" }
                                }
                            }
                        },
                        ["outputDimensionality"] = 64
                    }
                }
            };

            var paths = new Dictionary<string, string>
            {
                { "requests[].*", "requests[].request.*" }
            };

            Common.MoveValueByPath(data, paths);

            var expected = new JsonObject
            {
                ["requests"] = new JsonArray
                {
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = new JsonObject
                            {
                                ["parts"] = new JsonArray
                                {
                                    new JsonObject { ["text"] = "1" }
                                }
                            },
                            ["outputDimensionality"] = 64
                        }
                    },
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = new JsonObject
                            {
                                ["parts"] = new JsonArray
                                {
                                    new JsonObject { ["text"] = "2" }
                                }
                            },
                            ["outputDimensionality"] = 64
                        }
                    },
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = new JsonObject
                            {
                                ["parts"] = new JsonArray
                                {
                                    new JsonObject { ["text"] = "3" }
                                }
                            },
                            ["outputDimensionality"] = 64
                        }
                    }
                }
            };

            Assert.AreEqual(expected.ToJsonString(), data.ToJsonString());
        }

        [TestMethod]
        public void MoveValueByPath_DocstringExample()
        {
            var data = new JsonObject
            {
                ["requests"] = new JsonArray
                {
                    new JsonObject
                    {
                        ["content"] = "v1"
                    },
                    new JsonObject
                    {
                        ["content"] = "v2"
                    }
                }
            };

            var paths = new Dictionary<string, string>
            {
                { "requests[].*", "requests[].request.*" }
            };

            Common.MoveValueByPath(data, paths);

            var expected = new JsonObject
            {
                ["requests"] = new JsonArray
                {
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = "v1"
                        }
                    },
                    new JsonObject
                    {
                        ["request"] = new JsonObject
                        {
                            ["content"] = "v2"
                        }
                    }
                }
            };
            Assert.AreEqual(expected.ToJsonString(), data.ToJsonString());
        }

        [TestMethod]
        public void SetValueByPath_WithJsonNodeValue_PreservesValueAndIsCloned()
        {
            var data = new JsonObject();
            string largeBase64 = new string('A', 100_000);
            var sourceNode = JsonValue.Create(largeBase64);

            Common.SetValueByPath(data, new string[] { "inlineData", "data" }, sourceNode);

            Assert.AreEqual(largeBase64, data["inlineData"]["data"].GetValue<string>());
            Assert.AreNotSame(sourceNode, data["inlineData"]["data"]);
        }

        [TestMethod]
        public void SetValueByPath_Self_WithLargeJsonNodeProperties_PreservesAllValuesAndIsCloned()
        {
            var target = new JsonObject();
            string largeBase64 = new string('B', 100_000);
            var dataNode = JsonValue.Create(largeBase64);
            var mimeNode = JsonValue.Create("image/png");
            var selfNode = new JsonObject
            {
                ["data"] = dataNode,
                ["mimeType"] = mimeNode
            };

            Common.SetValueByPath(target, new string[] { "_self" }, selfNode);

            Assert.AreEqual(largeBase64, target["data"].GetValue<string>());
            Assert.AreEqual("image/png", target["mimeType"].GetValue<string>());
            Assert.AreNotSame(dataNode, target["data"]);
            Assert.AreNotSame(mimeNode, target["mimeType"]);
        }

        [TestMethod]
        public void SetValueByPath_MergeJsonObject_PreservesBothOriginalAndNewPropertiesAndIsCloned()
        {
            string largeBase64 = new string('C', 100_000);
            var data = new JsonObject
            {
                ["inlineData"] = new JsonObject { ["mimeType"] = "image/png" }
            };
            var dataNode = JsonValue.Create(largeBase64);
            var newNode = new JsonObject { ["data"] = dataNode };

            Common.SetValueByPath(data, new string[] { "inlineData" }, newNode);

            Assert.AreEqual("image/png", data["inlineData"]["mimeType"].GetValue<string>());
            Assert.AreEqual(largeBase64, data["inlineData"]["data"].GetValue<string>());
            Assert.AreNotSame(dataNode, data["inlineData"]["data"]);
        }

        [TestMethod]
        public void GetValueByPath_ArrayCollect_PreservesValuesAcrossAllElementsAndIsCloned()
        {
            string largeBase64 = new string('D', 100_000);
            var element0DataNode = JsonValue.Create(largeBase64);
            var element1DataNode = JsonValue.Create(largeBase64);
            var data = new JsonObject
            {
                ["parts"] = new JsonArray
                {
                    new JsonObject { ["data"] = element0DataNode },
                    new JsonObject { ["data"] = element1DataNode }
                }
            };

            var result = Common.GetValueByPath(data, new string[] { "parts[]", "data" }) as JsonArray;

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(largeBase64, result[0].GetValue<string>());
            Assert.AreEqual(largeBase64, result[1].GetValue<string>());
            Assert.AreNotSame(element0DataNode, result[0]);
            Assert.AreNotSame(element1DataNode, result[1]);
        }

        [TestMethod]
        public void ParseToJsonNode_WithJsonNodeInput_PreservesValueAndIsCloned()
        {
            string largeBase64 = new string('E', 100_000);
            var sourceNode = JsonValue.Create(largeBase64);

            var result = Common.ParseToJsonNode(sourceNode);

            Assert.IsNotNull(result);
            Assert.AreEqual(largeBase64, result.GetValue<string>());
            Assert.AreNotSame(sourceNode, result);
        }

        [TestMethod]
        public void ParseToJsonNode_WithJsonObjectInput_PreservesAllPropertiesAndIsCloned()
        {
            string largeBase64 = new string('F', 100_000);
            var sourceNode = new JsonObject
            {
                ["data"] = largeBase64,
                ["mimeType"] = "image/png"
            };
            var innerDataNode = sourceNode["data"];

            var result = Common.ParseToJsonNode(sourceNode) as JsonObject;

            Assert.IsNotNull(result);
            Assert.AreEqual(largeBase64, result["data"].GetValue<string>());
            Assert.AreEqual("image/png", result["mimeType"].GetValue<string>());
            Assert.AreNotSame(sourceNode, result);
            // Inner nodes must also be cloned, not the same references.
            Assert.AreNotSame(innerDataNode, result["data"]);
        }

        [TestMethod]
        public void ParseToJsonNode_WithNullInput_ReturnsNull()
        {
            var result = Common.ParseToJsonNode(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ParseToJsonNode_WithClrObjectInput_SerializesCorrectly()
        {
            var clrObject = new Dictionary<string, object> { ["mimeType"] = "image/png", ["width"] = 3840 };

            var result = Common.ParseToJsonNode(clrObject) as JsonObject;

            Assert.IsNotNull(result);
            Assert.AreEqual("image/png", result["mimeType"].GetValue<string>());
            Assert.AreEqual(3840, result["width"].GetValue<int>());
        }

        [TestMethod]
        public void ParseToJsonNode_WithContentClrObject_SerializesCorrectly()
        {
            var content = new Types.Content
            {
                Role = "user",
                Parts = new List<Types.Part>
                {
                    new Types.Part { Text = "Why is the sky blue?" }
                }
            };

            var result = Common.ParseToJsonNode(content) as JsonObject;

            Assert.IsNotNull(result);
            Assert.AreEqual("user", result["role"].GetValue<string>());
            var parts = result["parts"] as JsonArray;
            Assert.IsNotNull(parts);
            Assert.AreEqual(1, parts.Count);
            Assert.AreEqual("Why is the sky blue?", parts[0]["text"].GetValue<string>());
        }
    }
}