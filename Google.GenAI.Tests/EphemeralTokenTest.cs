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

using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests
{
  [TestClass]
  public class EphemeralTokenTest
  {
    [TestMethod]
    public void GetFieldMasks_FlatObject_ReturnsKeys()
    {
      var setup = new JsonObject { ["model"] = "gemini-2.5-flash" };
      string result = Tokens.GetFieldMasks(setup);
      Assert.AreEqual("model", result);
    }

    [TestMethod]
    public void GetFieldMasks_NestedObject_ReturnsPathMasks()
    {
      var setup = new JsonObject
      {
        ["generationConfig"] = new JsonObject { ["temperature"] = 0.5 }
      };
      string result = Tokens.GetFieldMasks(setup);
      Assert.AreEqual("generationConfig.temperature", result);
    }

    [TestMethod]
    public void GetFieldMasks_MixedObject_ReturnsCombinedMasks()
    {
      var setup = new JsonObject
      {
        ["model"] = "gemini-2.5-flash",
        ["generationConfig"] = new JsonObject { ["temperature"] = 0.5 }
      };
      string result = Tokens.GetFieldMasks(setup);
      Assert.AreEqual("model,generationConfig.temperature", result);
    }

    [TestMethod]
    public void ConvertBidiSetupToTokenSetup_ExtractsSetup()
    {
      var body = new JsonObject
      {
        ["bidiGenerateContentSetup"] = new JsonObject
        {
          ["setup"] = new JsonObject { ["model"] = "gemini-2.5-flash" }
        }
      };

      var tokens = new Tokens(null); // ApiClient not needed for this method
      var result = tokens.ConvertBidiSetupToTokenSetup(body, null);

      Assert.IsTrue(result.TryGetPropertyValue("bidiGenerateContentSetup", out JsonNode? bidiSetup));
      Assert.IsNotNull(bidiSetup);
      Assert.AreEqual("gemini-2.5-flash", bidiSetup["model"]?.ToString());
    }

    [TestMethod]
    public void ConvertBidiSetupToTokenSetup_Case1_LockOnlyBidiFields()
    {
      var body = new JsonObject
      {
        ["bidiGenerateContentSetup"] = new JsonObject
        {
          ["setup"] = new JsonObject { ["model"] = "gemini-2.5-flash" }
        }
      };
      var config = new CreateAuthTokenConfig
      {
        LockAdditionalFields = new List<string>()
      };

      var tokens = new Tokens(null);
      var result = tokens.ConvertBidiSetupToTokenSetup(body, config);

      Assert.IsTrue(result.TryGetPropertyValue("fieldMask", out JsonNode? fieldMask));
      Assert.AreEqual("model", fieldMask?.ToString());
    }

    [TestMethod]
    public void ConvertBidiSetupToTokenSetup_Case2_LockBidiAndAdditionalFields()
    {
      var body = new JsonObject
      {
        ["bidiGenerateContentSetup"] = new JsonObject
        {
          ["setup"] = new JsonObject { ["model"] = "gemini-2.5-flash" }
        },
        ["fieldMask"] = new JsonArray { "temperature" }
      };
      var config = new CreateAuthTokenConfig
      {
        LockAdditionalFields = new List<string> { "temperature" }
      };

      var tokens = new Tokens(null);
      var result = tokens.ConvertBidiSetupToTokenSetup(body, config);

      Assert.IsTrue(result.TryGetPropertyValue("fieldMask", out JsonNode? fieldMask));
      // "temperature" is in generationConfigFields list in Tokens.cs, so it maps to "generationConfig.temperature"
      Assert.AreEqual("model,generationConfig.temperature", fieldMask?.ToString());
    }

    [TestMethod]
    public void ConvertBidiSetupToTokenSetup_Case3_LockAllFields()
    {
      var body = new JsonObject
      {
        ["bidiGenerateContentSetup"] = new JsonObject
        {
          ["setup"] = new JsonObject { ["model"] = "gemini-2.5-flash" }
        }
      };
      // config.LockAdditionalFields is null (default)
      var config = new CreateAuthTokenConfig();

      var tokens = new Tokens(null);
      var result = tokens.ConvertBidiSetupToTokenSetup(body, config);

      Assert.IsFalse(result.TryGetPropertyValue("fieldMask", out _));
    }

    [TestMethod]
    public void ConvertBidiSetupToTokenSetup_NoBidiSetup_PreservesFieldMask()
    {
      var body = new JsonObject
      {
        ["fieldMask"] = new JsonArray { "model" }
      };

      var tokens = new Tokens(null);
      var result = tokens.ConvertBidiSetupToTokenSetup(body, null);

      Assert.IsTrue(result.TryGetPropertyValue("fieldMask", out JsonNode? fieldMask));
      Assert.AreEqual("model", fieldMask?.ToString());
    }
  }
}
