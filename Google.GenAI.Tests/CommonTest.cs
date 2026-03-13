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
    }
}
