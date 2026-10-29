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
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests {
  [TestClass]
  [DoNotParallelize]
  public class AgentMessageTests {
    /// <summary>
    /// Captures <see cref="Console.Error"/> while active. <see cref="Warnings"/> returns the
    /// Agent-Message warnings written, with <see cref="HttpApiClient.AgentMessageWarningPrefix"/>
    /// stripped; lines without the prefix are not counted.
    /// </summary>
    internal sealed class ConsoleErrorCapture : IDisposable {
      private readonly TextWriter _original = Console.Error;
      private readonly StringWriter _writer = new StringWriter();

      public ConsoleErrorCapture() {
        Console.SetError(_writer);
      }

      public List<string> Warnings {
        get {
          var warnings = new List<string>();
          foreach (var line in _writer.ToString().Split(
                       new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) {
            if (line.StartsWith(HttpApiClient.AgentMessageWarningPrefix, StringComparison.Ordinal)) {
              warnings.Add(line.Substring(HttpApiClient.AgentMessageWarningPrefix.Length));
            }
          }
          return warnings;
        }
      }

      public void Dispose() {
        Console.SetError(_original);
      }
    }

    [TestInitialize]
    public void Setup() {
      HttpApiClient.ClearSeenAgentMessages();
    }

    [TestCleanup]
    public void Cleanup() {
      HttpApiClient.ClearSeenAgentMessages();
    }

    [TestMethod]
    public void ParseSingleStructuredItem() {
      var header =
          "field_ignored;field=\"temperature\";" +
          "msg=%\"temperature is ignored by Gemini 3.6+ models and will be removed in a future release.\"";
      CollectionAssert.AreEqual(
          new[] {
            "temperature is ignored by Gemini 3.6+ models and will be removed in a future release."
          },
          new List<string>(HttpApiClient.ParseAgentMessageHeader(header)));
    }

    [TestMethod]
    public void ParseMultipleCommaSeparatedItems() {
      var header =
          "field_ignored;field=\"temperature\";msg=%\"temperature is ignored, using default.\", " +
          "field_ignored;field=\"top_k\";msg=%\"top_k is ignored; see docs.\"";
      CollectionAssert.AreEqual(
          new[] {
            "temperature is ignored, using default.",
            "top_k is ignored; see docs."
          },
          new List<string>(HttpApiClient.ParseAgentMessageHeader(header)));
    }

    [TestMethod]
    public void ParseItemWithoutFieldAndUnknownParams() {
      var header =
          "legacy_usage;severity=\"warn\";experimental;" +
          "msg=%\"generateContent is a legacy endpoint. Use the Interactions API for new development.\"";
      CollectionAssert.AreEqual(
          new[] {
            "generateContent is a legacy endpoint. Use the Interactions API for new development."
          },
          new List<string>(HttpApiClient.ParseAgentMessageHeader(header)));
    }

    [TestMethod]
    public void ParsePercentEncodedUtf8AndQuotedString() {
      var header =
          "field_ignored;msg=%\"use %22max_output_tokens%22 %E2%80%94 100%25\", " +
          "other_code;msg=\"plain \\\"quoted\\\" \\\\ string\"";
      CollectionAssert.AreEqual(
          new[] {
            "use \"max_output_tokens\" \u2014 100%",
            "plain \"quoted\" \\ string"
          },
          new List<string>(HttpApiClient.ParseAgentMessageHeader(header)));
    }

    [TestMethod]
    public void ParseMalformedHeadersGracefullyIgnored() {
      Assert.AreEqual(0, HttpApiClient.ParseAgentMessageHeader(null).Count);
      Assert.AreEqual(0, HttpApiClient.ParseAgentMessageHeader("").Count);
      Assert.AreEqual(0, HttpApiClient.ParseAgentMessageHeader("   ").Count);
      Assert.AreEqual(0, HttpApiClient.ParseAgentMessageHeader(";;;").Count);
      Assert.AreEqual(0, HttpApiClient.ParseAgentMessageHeader("field_ignored").Count);
      Assert.AreEqual(
          0, HttpApiClient.ParseAgentMessageHeader("field_ignored;field=\"temperature\"").Count);
      Assert.AreEqual(
          0, HttpApiClient.ParseAgentMessageHeader("field_ignored;msg=unquoted").Count);
      Assert.AreEqual(
          0, HttpApiClient.ParseAgentMessageHeader("field_ignored;msg=%\"unterminated").Count);
      Assert.AreEqual(
          0, HttpApiClient.ParseAgentMessageHeader("bad code;msg=%\"not a token\"").Count);
    }

    [TestMethod]
    public void ParseSkipsMalformedSiblingItem() {
      var header =
          "field_ignored;field=\"temperature\", " +
          "field_ignored;field=\"top_k\";msg=%\"top_k is ignored.\"";
      CollectionAssert.AreEqual(
          new[] { "top_k is ignored." },
          new List<string>(HttpApiClient.ParseAgentMessageHeader(header)));
    }

    [TestMethod]
    public void ParsePlainStringFallback() {
      var header = "generation_config.temperature is ignored, using default value.";
      CollectionAssert.AreEqual(
          new[] { "generation_config.temperature is ignored, using default value." },
          new List<string>(HttpApiClient.ParseAgentMessageHeader(header)));
    }

    [TestMethod]
    public void WarnFromAgentMessageHeaders_EmitsAndDeduplicates() {
      var listener = new ConsoleErrorCapture();
      try {
        var header =
            "field_ignored;field=\"temperature\";msg=%\"temperature is ignored by Gemini 3.6+ models.\"";

        using var resp1 = new HttpResponseMessage(HttpStatusCode.OK);
        resp1.Headers.TryAddWithoutValidation("Agent-Message", header);
        HttpApiClient.WarnFromAgentMessageHeaders(resp1.Headers);

        using var resp2 = new HttpResponseMessage(HttpStatusCode.OK);
        resp2.Headers.TryAddWithoutValidation("agent-message", header);
        HttpApiClient.WarnFromAgentMessageHeaders(resp2.Headers);

        using var resp3 = new HttpResponseMessage(HttpStatusCode.OK);
        resp3.Headers.TryAddWithoutValidation(
            "AGENT-MESSAGE",
            "field_ignored;field=\"top_k\";msg=%\"top_k is ignored by Gemini 3.6+ models.\"");
        HttpApiClient.WarnFromAgentMessageHeaders(resp3.Headers);

        CollectionAssert.AreEqual(
            new[] {
              "temperature is ignored by Gemini 3.6+ models.",
              "top_k is ignored by Gemini 3.6+ models."
            },
            listener.Warnings);
      } finally {
        listener.Dispose();
      }
    }

    internal static HttpResponseMessage ErrorResponse(HttpStatusCode status, string warning) {
      var resp = new HttpResponseMessage(status) {
        Content = new StringContent(
            "{\"error\": {\"code\": " + (int)status + ", \"message\": \"boom\"}}",
            System.Text.Encoding.UTF8,
            "application/json")
      };
      resp.Headers.TryAddWithoutValidation(
          "Agent-Message", "field_ignored;msg=%\"" + warning + "\"");
      return resp;
    }
  }
}
