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
using System.IO;
using System.Reflection;
using System.Text.Json.Nodes;

using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests {
  [TestClass]
  public class GenerateContentParametersTest {
    [TestMethod]
    public void TestExerciseGenerateContentParameters() {
      ApiClient client = new HttpApiClient(project: "test-project-id", location: "us-central1",
                                           credentials: null, httpOptions: null);
      Models models = new Models(client);
      string body = "{\"contents\":[{\"parts\":[{\"text\":\"Explain how AI works\"}]}]}";
      GenerateContentParameters? contentParams = GenerateContentParameters.FromJson(body);
      Assert.IsNotNull(contentParams);

      var result = models.GenerateContentParametersToVertex(client, JsonObject.Parse(body), null, null);
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void IsGemini36OrNewer_MatchesExpectedModels() {
      Assert.IsTrue(Models.IsGemini36OrNewer("gemini-3.6-flash"));
      Assert.IsTrue(Models.IsGemini36OrNewer("publishers/google/models/gemini-3.6-pro"));
      Assert.IsTrue(Models.IsGemini36OrNewer("models/gemini-3.6-flash-001"));
      Assert.IsTrue(Models.IsGemini36OrNewer("gemini-3.8-flash"));
      Assert.IsTrue(Models.IsGemini36OrNewer("GEMINI-3.6-FLASH"));

      Assert.IsFalse(Models.IsGemini36OrNewer("gemini-3.1-pro"));
      Assert.IsFalse(Models.IsGemini36OrNewer("gemini-3-flash"));
      Assert.IsFalse(Models.IsGemini36OrNewer("gemini-2.5-flash"));
      Assert.IsFalse(Models.IsGemini36OrNewer("gemini-flash-latest"));
      Assert.IsFalse(Models.IsGemini36OrNewer(null));
      Assert.IsFalse(Models.IsGemini36OrNewer(""));
    }

    [TestMethod]
    public void WarnUnsupportedParameters_LogsOnceForGemini36AndNewer() {
      var warnMethod = typeof(Models).GetMethod(
          "WarnUnsupportedParameters", BindingFlags.NonPublic | BindingFlags.Static);
      Assert.IsNotNull(warnMethod);

      void ResetFlags() {
        foreach (var fieldName in new[] {
          "_loggedTemperatureWarning",
          "_loggedTopPWarning",
          "_loggedTopKWarning",
          "_loggedThinkingBudgetWarning",
        }) {
          var field = typeof(Models).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);
          Assert.IsNotNull(field, $"Expected field {fieldName}");
          field.SetValue(null, 0);
        }
      }

      var originalOut = Console.Out;
      using var sw = new StringWriter();
      Console.SetOut(sw);
      try {
        ResetFlags();

        var config = new GenerateContentConfig {
          Temperature = 0.7f,
          TopP = 0.9f,
          TopK = 40f,
          ThinkingConfig = new ThinkingConfig { ThinkingBudget = 1024 },
        };

        // Older models or null config should not log warnings.
        warnMethod.Invoke(null, new object?[] { "gemini-3.1-pro", config });
        warnMethod.Invoke(null, new object?[] { "gemini-2.5-flash", config });
        warnMethod.Invoke(null, new object?[] { "gemini-3.6-flash", null });
        Assert.AreEqual("", sw.ToString());

        // Gemini 3.6+ should log each warning once.
        warnMethod.Invoke(null, new object?[] { "gemini-3.6-flash", config });
        string output = sw.ToString();
        StringAssert.Contains(
            output, "temperature is not supported on Gemini 3.6 and newer models and is ignored.");
        StringAssert.Contains(
            output, "top_p is not supported on Gemini 3.6 and newer models and is ignored.");
        StringAssert.Contains(
            output, "top_k is not supported on Gemini 3.6 and newer models and is ignored.");
        StringAssert.Contains(
            output,
            "thinking_budget is not supported on Gemini 3.6 and newer models and is ignored. Please use thinking_level instead.");

        // Second call should not log again.
        sw.GetStringBuilder().Clear();
        warnMethod.Invoke(null, new object?[] { "gemini-3.6-pro", config });
        Assert.AreEqual("", sw.ToString());
      } finally {
        Console.SetOut(originalOut);
        ResetFlags();
      }
    }
  }
}
