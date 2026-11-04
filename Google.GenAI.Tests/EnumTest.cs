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

using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Google.GenAI.Tests
{
    [TestClass]
    public class EnumTest
    {

        [TestMethod]
        public void FromString_KnownValue_ReturnsCanonicalInstance()
        {
            var result = PersonGeneration.FromString("ALLOW_ALL");

            Assert.AreEqual(PersonGeneration.AllowAll, result);
            Assert.AreSame(PersonGeneration.AllowAll.Value, result.Value);
            Assert.AreEqual("ALLOW_ALL", result.Value);
        }

        [TestMethod]
        public void FromString_DifferentCasing_DoesNotMatchStaticInstance()
        {
            var result = PersonGeneration.FromString("allow_all");

            Assert.AreNotEqual(PersonGeneration.AllowAll, result);
            // SDK does not do anything to change the string value.
            Assert.AreEqual("allow_all", result.Value);
        }

        [TestMethod]
        public void KnownValue_PreservesValue()
        {
            var original = PersonGeneration.AllowAdult;
            Assert.AreEqual("ALLOW_ADULT", original.Value);

            var json = JsonSerializer.Serialize(original, JsonConfig.TypeInfo<PersonGeneration>());
            var deserialized = JsonSerializer.Deserialize(json, JsonConfig.TypeInfo<PersonGeneration>());

            Assert.AreEqual("\"ALLOW_ADULT\"", json);
            Assert.AreEqual(original, deserialized);
        }

        [TestMethod]
        public void UnknownValue_PreservesValue()
        {
            string unknownValue = "ALLOW_ROBOTS";
            PersonGeneration original = unknownValue;
            Assert.AreEqual(unknownValue, original.Value);

            var json = JsonSerializer.Serialize(original, JsonConfig.TypeInfo<PersonGeneration>());
            var deserialized = JsonSerializer.Deserialize(json, JsonConfig.TypeInfo<PersonGeneration>());

            Assert.AreEqual("\"ALLOW_ROBOTS\"", json);
            Assert.AreEqual(original, deserialized);
        }
    }
}
