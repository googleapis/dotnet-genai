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
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using Google.Apis.Auth.OAuth2;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Google.GenAI.Tests {
  [TestClass]
  public class HttpApiClientTests {
    private const string TestApiKey = "test-api-key";
    private const string EnvApiKeyName = "GOOGLE_API_KEY";
    private const string TestProject = "test-project";
    private const string TestLocation = "us-central1";
    private const string EnvProjectName = "GOOGLE_CLOUD_PROJECT";
    private const string EnvLocationName = "GOOGLE_CLOUD_LOCATION";

    [TestCleanup]
    public void Cleanup() {
      System.Environment.SetEnvironmentVariable(EnvApiKeyName, null);
      System.Environment.SetEnvironmentVariable(EnvProjectName, null);
      System.Environment.SetEnvironmentVariable(EnvLocationName, null);
    }

    [TestMethod]
    public void GeminiConstructor_WithApiKey_SetsPropertiesCorrectly() {
      var client = new HttpApiClient(vertexAI: false, apiKey: TestApiKey);

      Assert.AreEqual(TestApiKey, client.ApiKey);
      Assert.IsFalse(client.VertexAI);
      Assert.IsNull(client.Project);
      Assert.IsNull(client.Location);
      Assert.IsNull(client.Credentials);
      Assert.AreEqual("https://generativelanguage.googleapis.com", client.HttpOptions.BaseUrl);
      Assert.AreEqual("v1beta", client.HttpOptions.ApiVersion);
      Assert.IsNull(client.HttpOptions.Timeout);
    }

    [TestMethod]
    public void GeminiConstructor_WithApiKeyFromEnvironment_SetsPropertiesCorrectly() {
      System.Environment.SetEnvironmentVariable(EnvApiKeyName, TestApiKey);

      var client = new HttpApiClient(vertexAI: false);

      Assert.AreEqual(TestApiKey, client.ApiKey);
      Assert.IsFalse(client.VertexAI);
      Assert.IsNull(client.Project);
      Assert.IsNull(client.Location);
      Assert.IsNull(client.Credentials);
      Assert.AreEqual("https://generativelanguage.googleapis.com", client.HttpOptions.BaseUrl);
      Assert.AreEqual("v1beta", client.HttpOptions.ApiVersion);
      Assert.IsNull(client.HttpOptions.Timeout);
    }

    [TestMethod]
    public void GeminiConstructor_WithHttpOptionsProvided_SetsPropertiesCorrectly() {
      System.Environment.SetEnvironmentVariable(EnvApiKeyName, TestApiKey);
      var customHttpOptions = new Types.HttpOptions { BaseUrl = "https://custom-url.com",
                                                      ApiVersion = "v2", Timeout = 6000 };

      var client = new HttpApiClient(vertexAI: false, httpOptions: customHttpOptions);

      Assert.AreEqual(TestApiKey, client.ApiKey);
      Assert.IsFalse(client.VertexAI);
      Assert.IsNull(client.Project);
      Assert.IsNull(client.Location);
      Assert.IsNull(client.Credentials);
      Assert.AreEqual("https://custom-url.com", client.HttpOptions.BaseUrl);
      Assert.AreEqual("v2", client.HttpOptions.ApiVersion);
      Assert.AreEqual(6000, client.HttpOptions.Timeout);
    }

    [TestMethod]
    public void GeminiConstructor_NullApiKey_ThrowsArgumentException() {
      System.Environment.SetEnvironmentVariable(EnvApiKeyName, null);

      var ex = Assert.ThrowsException<ArgumentException>(() => new HttpApiClient(vertexAI: false));
      Assert.IsTrue(ex.Message.Contains(
          "API key must either be provided or set in the environment variable GOOGLE_API_KEY."));
    }

    [TestMethod]
    public void GeminiConstructor_EmptyApiKey_ThrowsArgumentException() {
      System.Environment.SetEnvironmentVariable(EnvApiKeyName, null);

      var ex = Assert.ThrowsException<ArgumentException>(() => new HttpApiClient(vertexAI: false, apiKey: ""));
      Assert.IsTrue(ex.Message.Contains(
          "API key must either be provided or set in the environment variable GOOGLE_API_KEY."));
    }

    [TestMethod]
    public void VertexConstructor_WithProjectLocationCredentials_SetsPropertiesCorrectly() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");

      var client = new HttpApiClient(vertexAI: true, project: TestProject, location: TestLocation, credentials: mockCredential.Object);

      Assert.AreEqual(TestProject, client.Project);
      Assert.AreEqual(TestLocation, client.Location);
      Assert.AreEqual(mockCredential.Object, client.Credentials);
      Assert.IsTrue(client.VertexAI);
      Assert.IsNull(client.ApiKey);
      Assert.AreEqual($"https://{TestLocation}-aiplatform.googleapis.com",
                      client.HttpOptions.BaseUrl);
      Assert.AreEqual("v1beta1", client.HttpOptions.ApiVersion);
      Assert.IsNull(client.HttpOptions.Timeout);
    }

    [TestMethod]
    public void VertexConstructor_WithProjectLocationFromEnvironment_SetsPropertiesCorrectly() {
      System.Environment.SetEnvironmentVariable(EnvProjectName, TestProject);
      System.Environment.SetEnvironmentVariable(EnvLocationName, TestLocation);
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");

      var client = new HttpApiClient(vertexAI: true, credentials: mockCredential.Object);

      Assert.AreEqual(TestProject, client.Project);
      Assert.AreEqual(TestLocation, client.Location);
      Assert.AreEqual(mockCredential.Object, client.Credentials);
      Assert.IsTrue(client.VertexAI);
      Assert.IsNull(client.ApiKey);
      Assert.AreEqual($"https://{TestLocation}-aiplatform.googleapis.com",
                      client.HttpOptions.BaseUrl);
      Assert.AreEqual("v1beta1", client.HttpOptions.ApiVersion);
      Assert.IsNull(client.HttpOptions.Timeout);
    }

    [TestMethod]
    public void VertexConstructor_NullProject_ThrowsArgumentException() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");
      System.Environment.SetEnvironmentVariable(EnvProjectName, null);

      var ex = Assert.ThrowsException<ArgumentException>(
          () => new HttpApiClient(vertexAI: true, location: TestLocation, credentials: mockCredential.Object));
      Assert.IsTrue(ex.Message.Contains(
          "Project or API key must be set when using the Vertex AI API."));
    }

    [TestMethod]
    public void VertexConstructor_NullLocation_DefaultsToGlobal() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");
      System.Environment.SetEnvironmentVariable(EnvLocationName, null);

      var client = new HttpApiClient(vertexAI: true, project: TestProject, credentials: mockCredential.Object);
      Assert.AreEqual("global", client.Location);
    }

    [TestMethod]
    public void VertexConstructor_EmptyProject_ThrowsArgumentException() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");

      var ex = Assert.ThrowsException<ArgumentException>(
          () => new HttpApiClient(vertexAI: true, project: "", location: TestLocation, credentials: mockCredential.Object));
      Assert.IsTrue(ex.Message.Contains(
          "Project or API key must be set when using the Vertex AI API."));
    }

    [TestMethod]
    public void VertexConstructor_EmptyLocation_DefaultsToGlobal() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");

      var client = new HttpApiClient(vertexAI: true, project: TestProject, location: "", credentials: mockCredential.Object);
      Assert.AreEqual("global", client.Location);
    }

    [TestMethod]
    public void VertexConstructor_WithCustomHttpOptions_OverridesDefaults() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");
      var customOptions = new Types.HttpOptions { BaseUrl = "https://custom.vertex.ai",
                                                  ApiVersion = "v2alpha", Timeout = 8000 };

      var client =
          new HttpApiClient(vertexAI: true, project: TestProject, location: TestLocation, credentials: mockCredential.Object, httpOptions: customOptions);

      Assert.AreEqual(TestProject, client.Project);
      Assert.AreEqual(TestLocation, client.Location);
      Assert.AreEqual(mockCredential.Object, client.Credentials);
      Assert.IsTrue(client.VertexAI);
      Assert.IsNull(client.ApiKey);
      Assert.AreEqual("https://custom.vertex.ai", client.HttpOptions.BaseUrl);
      Assert.AreEqual("v2alpha", client.HttpOptions.ApiVersion);
      Assert.AreEqual(8000, client.HttpOptions.Timeout);
    }

    [TestMethod]
    public void VertexConstructor_WithCustomHttpOptions_NoGoogleApisEnv_ClearsAuthIfInsufficient() {
      var customOptions = new Types.HttpOptions { BaseUrl = "https://my-proxy.company.internal" };

      var client =
          new HttpApiClient(vertexAI: true, httpOptions: customOptions);

      Assert.IsNull(client.Project);
      Assert.IsNull(client.Location);
      Assert.IsNull(client.ApiKey);
      Assert.IsNull(client.Credentials);
      Assert.IsTrue(client.VertexAI);
      Assert.AreEqual("https://my-proxy.company.internal", client.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void VertexConstructor_WithApiKey_VertexExpress_ClearsProjectEnvVar() {
      System.Environment.SetEnvironmentVariable(EnvProjectName, "ignored-project");
      System.Environment.SetEnvironmentVariable(EnvLocationName, "ignored-location");

      var client = new HttpApiClient(vertexAI: true, apiKey: "express-key");

      Assert.AreEqual("express-key", client.ApiKey);
      Assert.IsNull(client.Project);
      Assert.IsNull(client.Location);
      Assert.IsNull(client.Credentials);
      Assert.IsTrue(client.VertexAI);
      Assert.AreEqual("https://aiplatform.googleapis.com", client.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void VertexConstructor_LocationGlobal_SetsCorrectBaseUrl() {
      var mockCredential = new Mock<ICredential>();
      var client = new HttpApiClient(vertexAI: true, project: "my-project", location: "global", credentials: mockCredential.Object);

      Assert.AreEqual("my-project", client.Project);
      Assert.AreEqual("global", client.Location);
      Assert.IsTrue(client.VertexAI);
      Assert.AreEqual("https://aiplatform.googleapis.com", client.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void VertexConstructor_LocationUs_SetsCorrectBaseUrl() {
      var mockCredential = new Mock<ICredential>();
      var client = new HttpApiClient(vertexAI: true, project: "my-project", location: "us", credentials: mockCredential.Object);

      Assert.AreEqual("my-project", client.Project);
      Assert.AreEqual("us", client.Location);
      Assert.IsTrue(client.VertexAI);
      Assert.AreEqual("https://aiplatform.us.rep.googleapis.com", client.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void VertexConstructor_LocationEu_SetsCorrectBaseUrl() {
      var mockCredential = new Mock<ICredential>();
      var client = new HttpApiClient(vertexAI: true, project: "my-project", location: "eu", credentials: mockCredential.Object);

      Assert.AreEqual("my-project", client.Project);
      Assert.AreEqual("eu", client.Location);
      Assert.IsTrue(client.VertexAI);
      Assert.AreEqual("https://aiplatform.eu.rep.googleapis.com", client.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void VertexConstructor_LocationUsAndCustomHttpOptions_SetsCorrectBaseUrl() {
      var mockCredential = new Mock<ICredential>();
      var customOptions = new Types.HttpOptions { BaseUrl = "https://my-custom-url.com/" };
      var client = new HttpApiClient(vertexAI: true, project: "my-project", location: "us", credentials: mockCredential.Object, httpOptions: customOptions);

      Assert.AreEqual("my-project", client.Project);
      Assert.AreEqual("us", client.Location);
      Assert.IsTrue(client.VertexAI);
      Assert.AreEqual("https://my-custom-url.com/", client.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void Constructor_HttpOptions_BaseUrlResourceScopeWithoutBaseUrl_ThrowsArgumentException() {
      var customOptions = new Types.HttpOptions { BaseUrlResourceScope = Types.ResourceScope.Collection, BaseUrl = null };
      var ex = Assert.ThrowsException<ArgumentException>(() => new HttpApiClient(vertexAI: false, apiKey: "key", httpOptions: customOptions));
      Assert.IsTrue(ex.Message.Contains("base_url must be set when base_url_resource_scope is set."));
    }

    private async System.Threading.Tasks.Task<System.Net.Http.HttpRequestMessage> InvokeCreateHttpRequestAsync(
        HttpApiClient client, System.Net.Http.HttpMethod method, string path, string content, Types.HttpOptions? options)
    {
      var methodInfo = typeof(HttpApiClient).GetMethod("CreateHttpRequestAsync",
          System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
          null,
          new[] { typeof(System.Net.Http.HttpMethod), typeof(string), typeof(string), typeof(Types.HttpOptions) },
          null);

      var task = (System.Threading.Tasks.Task<System.Net.Http.HttpRequestMessage>)methodInfo!.Invoke(client, new object?[] { method, path, content, options })!;
      return await task;
    }

    [TestMethod]
    public async System.Threading.Tasks.Task CreateHttpRequestAsync_Vertex_ResourceScopeCollection_OmitsApiVersion() {
      var customOptions = new Types.HttpOptions { BaseUrl = "https://custom.vertex.ai", BaseUrlResourceScope = Types.ResourceScope.Collection };
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");
      var client = new HttpApiClient(vertexAI: true, httpOptions: customOptions, credentials: mockCredential.Object);

      var request = await InvokeCreateHttpRequestAsync(client, System.Net.Http.HttpMethod.Post, "some/path", "{}", null);

      Assert.AreEqual("https://custom.vertex.ai/some/path", request.RequestUri!.ToString());
    }

    [TestMethod]
    public async System.Threading.Tasks.Task CreateHttpRequestAsync_Vertex_NullProjectLocation_DoesNotPrependPath() {
      // Use an explicit base URL and custom options to avoid default location/project requirement.
      var customOptions = new Types.HttpOptions { BaseUrl = "https://my-proxy.company.internal" };
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");
      var client = new HttpApiClient(vertexAI: true, httpOptions: customOptions, credentials: mockCredential.Object);

      var request = await InvokeCreateHttpRequestAsync(client, System.Net.Http.HttpMethod.Post, "some/path", "{}", null);

      // Should not prepend projects/{project}/locations/{location} because they are null/empty.
      Assert.AreEqual("https://my-proxy.company.internal/v1beta1/some/path", request.RequestUri!.ToString());
    }

    [TestMethod]
    public async System.Threading.Tasks.Task CreateHttpRequestAsync_Vertex_WithProjectLocation_PrependsPath() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");
      var client = new HttpApiClient(vertexAI: true, project: "my-project", location: "my-location", credentials: mockCredential.Object);

      var request = await InvokeCreateHttpRequestAsync(client, System.Net.Http.HttpMethod.Post, "some/path", "{}", null);

      Assert.AreEqual("https://my-location-aiplatform.googleapis.com/v1beta1/projects/my-project/locations/my-location/some/path", request.RequestUri!.ToString());
    }

    [TestMethod]
    public async Task CreateHttpRequestAsync_RewritesAbsoluteUrlWithBaseUrl() {
        var customHttpOptions = new Types.HttpOptions { BaseUrl = "https://my-proxy.company.com" };
        var client = new HttpApiClient(apiKey: TestApiKey, httpOptions: customHttpOptions);

        var method = typeof(HttpApiClient).GetMethod("CreateHttpRequestAsync", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, 
            null, 
            new[] { typeof(System.Net.Http.HttpMethod), typeof(string), typeof(byte[]), typeof(Types.HttpOptions) }, 
            null);
        Assert.IsNotNull(method, "Could not find CreateHttpRequestAsync method via reflection.");

        var absoluteUrl = "https://generativelanguage.googleapis.com/upload/v1beta/files?uploadType=resumable";
        var bytes = new byte[] { 1, 2, 3 };

        var task = (Task<System.Net.Http.HttpRequestMessage>)method.Invoke(client, new object[] { System.Net.Http.HttpMethod.Post, absoluteUrl, bytes, null });
        var request = await task;

        Assert.AreEqual("https://my-proxy.company.com/upload/v1beta/files?uploadType=resumable", request.RequestUri.ToString());
    }

    [TestMethod]
    public async Task CreateHttpRequestAsync_RewritesAbsoluteUrlInPathWithBaseUrl() {
        var customHttpOptions = new Types.HttpOptions { BaseUrl = "https://my-proxy.company.com" };
        var client = new HttpApiClient(apiKey: TestApiKey, httpOptions: customHttpOptions);

        var method = typeof(HttpApiClient).GetMethod("CreateHttpRequestAsync", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, 
            null, 
            new[] { typeof(System.Net.Http.HttpMethod), typeof(string), typeof(string), typeof(Types.HttpOptions) }, 
            null);
        Assert.IsNotNull(method, "Could not find CreateHttpRequestAsync method via reflection.");

        var absoluteUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.0-flash:generateContent";
        var json = "{}";

        var task = (Task<System.Net.Http.HttpRequestMessage>)method.Invoke(client, new object[] { System.Net.Http.HttpMethod.Post, absoluteUrl, json, null });
        var request = await task;

        Assert.AreEqual("https://my-proxy.company.com/v1beta/models/gemini-3.0-flash:generateContent", request.RequestUri.ToString());
    }

    [TestMethod]
    public async Task ProcessStreamResponse_MultilineData_StripsPrefixes() {
        var client = new HttpApiClient(apiKey: TestApiKey);

        var sseData = "data: {\ndata:   \"foo\": \"bar\"\ndata: }\n\n";
        var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(sseData));

        var methodInfo = typeof(HttpApiClient).GetMethod("ProcessStreamResponse",
            BindingFlags.NonPublic | BindingFlags.Instance);

        var enumerable = (IAsyncEnumerable<string>)methodInfo.Invoke(client, new object[] { stream, System.Threading.CancellationToken.None });

        var results = new System.Collections.Generic.List<string>();
        await foreach (var item in enumerable)
        {
            results.Add(item);
        }

        Assert.AreEqual(1, results.Count);
        Assert.AreEqual("{\n  \"foo\": \"bar\"\n}", results[0]);
    }
  }
}
