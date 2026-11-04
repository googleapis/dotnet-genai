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
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.GenAI.Types;
using Moq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests
{
  [TestClass]
  public class LiveTest
  {
    private string GetHeaderValue(ClientWebSocketOptions options, string headerName)
    {
      // Extract the internal WebHeaderCollection (for testing only)
      var requestHeadersProp = typeof(ClientWebSocketOptions).GetProperty("RequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);
      WebHeaderCollection headers = null;

      if (requestHeadersProp != null)
      {
        headers = requestHeadersProp.GetValue(options) as WebHeaderCollection;
      }
      else
      {
        var requestHeadersField = typeof(ClientWebSocketOptions).GetField("_requestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);
        headers = requestHeadersField?.GetValue(options) as WebHeaderCollection;
      }

      return headers?[headerName];
    }

    [TestMethod]
    public async Task SetRequestHeadersAsync_ShouldSetApiKeyHeader_ForGeminiApi()
    {
      var httpOptions = new HttpOptions
      {
        Headers = new Dictionary<string, string>
        {
          { "Content-Type", "application/json" },
          { "User-Agent", "test-agent" },
          { "x-custom-header", "custom-value" }
        }
      };

      using var client = new Client(apiKey: "test-api-key", httpOptions: httpOptions);
      using var clientWebSocket = new ClientWebSocket();

      // Should complete without throwing ArgumentException for restricted headers.
      await client.Live.SetRequestHeadersAsync(clientWebSocket);

      // Verify that the authentication header is correctly added
      var apiKeyHeader = GetHeaderValue(clientWebSocket.Options, "x-goog-api-key");
      Assert.AreEqual("test-api-key", apiKeyHeader, "The x-goog-api-key authentication header must be present.");

      // Verify that non-restricted custom headers are correctly added
      var customHeader = GetHeaderValue(clientWebSocket.Options, "x-custom-header");
      Assert.AreEqual("custom-value", customHeader, "Custom headers from HttpOptions should be present.");

      var authHeader = GetHeaderValue(clientWebSocket.Options, "Authorization");
      Assert.IsNull(authHeader, "Authorization header should not be present.");
    }

    [TestMethod]
    public async Task SetRequestHeadersAsync_ShouldSetAuthorizationTokenHeader_ForEphemeralToken()
    {
      using var client = new Client(apiKey: "auth_tokens/fake-ephemeral-token");
      using var clientWebSocket = new ClientWebSocket();

      await client.Live.SetRequestHeadersAsync(clientWebSocket);

      var authHeader = GetHeaderValue(clientWebSocket.Options, "Authorization");
      Assert.AreEqual("Token auth_tokens/fake-ephemeral-token", authHeader, "The Authorization header must be present and prefixed with 'Token '.");

      var apiKeyHeader = GetHeaderValue(clientWebSocket.Options, "x-goog-api-key");
      Assert.IsNull(apiKeyHeader, "The x-goog-api-key header should not be present when using an ephemeral token.");
    }

    [TestMethod]
    public async Task SetRequestHeadersAsync_ShouldSetAuthorizationBearerHeader_ForVertexAi()
    {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");

      using var client = new Client(enterprise: true, project: "test-project", location: "us-central1", credential: mockCredential.Object);
      using var clientWebSocket = new ClientWebSocket();

      await client.Live.SetRequestHeadersAsync(clientWebSocket);

      var authHeader = GetHeaderValue(clientWebSocket.Options, "Authorization");
      Assert.AreEqual("Bearer mock-access-token", authHeader, "The Authorization header must be present and prefixed with 'Bearer '.");

      var apiKeyHeader = GetHeaderValue(clientWebSocket.Options, "x-goog-api-key");
      Assert.IsNull(apiKeyHeader, "The x-goog-api-key header should not be present for Vertex AI.");
    }

    private static Uri InvokeGetServerUri(Live live)
    {
      var method = typeof(Live).GetMethod("GetServerUri", BindingFlags.Instance | BindingFlags.NonPublic);
      Assert.IsNotNull(method, "Live.GetServerUri not found.");
      return (Uri)method.Invoke(live, null)!;
    }

    [TestMethod]
    public void GetServerUri_GeminiDefault_UsesDefaultApiVersion()
    {
      using var client = new Client(vertexAI: false, apiKey: "test-api-key");

      Assert.AreEqual(
          $"wss://generativelanguage.googleapis.com/ws/google.ai.generativelanguage.{ApiClient.GoogleAiApiDefaultVersion}.GenerativeService.BidiGenerateContent",
          InvokeGetServerUri(client.Live).ToString());
    }

    [TestMethod]
    public void GetServerUri_GeminiExplicitApiVersion_UsesApiVersion()
    {
      using var client = new Client(vertexAI: false, apiKey: "test-api-key", httpOptions: new HttpOptions { ApiVersion = "v1alpha" });

      Assert.AreEqual(
          "wss://generativelanguage.googleapis.com/ws/google.ai.generativelanguage.v1alpha.GenerativeService.BidiGenerateContent",
          InvokeGetServerUri(client.Live).ToString());
    }

    [TestMethod]
    public void GetServerUri_VertexDefault_UsesV1beta1()
    {
      var mockCredential = new Mock<ICredential>();
      using var client = new Client(vertexAI: true, project: "test-project", location: "us-central1", credential: mockCredential.Object);

      Assert.AreEqual(
          "wss://us-central1-aiplatform.googleapis.com/ws/google.cloud.aiplatform.v1beta1.LlmBidiService/BidiGenerateContent",
          InvokeGetServerUri(client.Live).ToString());
    }
  }
}
