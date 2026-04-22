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
using System.Net;
using System.Net.Http;

using Google.Apis.Auth.OAuth2;
using Google.GenAI;
using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Google.GenAI.Tests {
  [TestClass]
  public class ClientTests {
    private string? _originalVertexAiEnv;
    private string? _originalEnterpriseEnv;
    private string? _originalProjectEnv;
    private string? _originalLocationEnv;
    private string? _originalApiKeyEnv;
    private string? _originalVertexBaseUrlEnv;
    private string? _originalGeminiBaseUrlEnv;

    [TestInitialize]
    public void TestInitialize() {
      _originalVertexAiEnv = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI");
      _originalEnterpriseEnv = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE");
      _originalProjectEnv = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
      _originalLocationEnv = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION");
      _originalApiKeyEnv = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
      _originalVertexBaseUrlEnv =
          System.Environment.GetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL");
      _originalGeminiBaseUrlEnv =
          System.Environment.GetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL");

      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", null);
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", null);
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", null);
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_LOCATION", null);
      System.Environment.SetEnvironmentVariable("GOOGLE_API_KEY", null);
      System.Environment.SetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL", null);
      System.Environment.SetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL", null);

      Client.setDefaultBaseUrl(null, null);
    }

    [TestCleanup]
    public void TestCleanup() {
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", _originalVertexAiEnv);
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", _originalEnterpriseEnv);
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", _originalProjectEnv);
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_LOCATION", _originalLocationEnv);
      System.Environment.SetEnvironmentVariable("GOOGLE_API_KEY", _originalApiKeyEnv);
      System.Environment.SetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL",
                                                _originalVertexBaseUrlEnv);
      System.Environment.SetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL",
                                                _originalGeminiBaseUrlEnv);

      Client.setDefaultBaseUrl(null, null);
    }

#region setDefaultBaseUrl Tests

    [TestMethod]
    public void SetDefaultBaseUrl_SetsVertexAndGeminiUrls() {
      var vertexUrl = "http://customvertex.com";
      var geminiUrl = "http://customgemini.com";
      Client.setDefaultBaseUrl(vertexUrl, geminiUrl);

      var clientVertex = new Client(vertexAI: true, project: "project", location: "location",
                                    httpOptions: new HttpOptions());
      var clientGemini = new Client(vertexAI: false, apiKey: "key", httpOptions: new HttpOptions());

      Assert.AreEqual(vertexUrl, clientVertex._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(geminiUrl, clientGemini._apiClient.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void SetDefaultBaseUrl_SetsVertexUrlOnly() {
      var vertexUrl = "http://customvertex.com/v";
      Client.setDefaultBaseUrl(vertexUrl, null);

      var clientVertex = new Client(vertexAI: true, project: "project", location: "location",
                                    httpOptions: new HttpOptions());
      var clientGemini = new Client(vertexAI: false, apiKey: "key", httpOptions: new HttpOptions());

      Assert.AreEqual(vertexUrl, clientVertex._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(ApiClient.GetDefaultHttpOptions(false, null).BaseUrl,
                      clientGemini._apiClient.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void SetDefaultBaseUrl_SetsGeminiUrlOnly() {
      var geminiUrl = "http://customgemini.com/g";
      Client.setDefaultBaseUrl(null, geminiUrl);

      var clientGemini = new Client(vertexAI: false, apiKey: "key", httpOptions: new HttpOptions());
      var clientVertex = new Client(vertexAI: true, project: "project", location: "us-central1",
                                    httpOptions: new HttpOptions());

      Assert.AreEqual(geminiUrl, clientGemini._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(ApiClient.GetDefaultHttpOptions(true, "us-central1").BaseUrl,
                      clientVertex._apiClient.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void SetDefaultBaseUrl_SetsBothToNull() {
      Client.setDefaultBaseUrl("http://initial-vertex.com", "http://initial-gemini.com");
      Client.setDefaultBaseUrl(null, null);

      var clientVertex = new Client(vertexAI: true, project: "project", location: "us-central1",
                                    httpOptions: new HttpOptions());
      var clientGemini = new Client(vertexAI: false, apiKey: "key", httpOptions: new HttpOptions());

      Assert.AreEqual(ApiClient.GetDefaultHttpOptions(true, "us-central1").BaseUrl,
                      clientVertex._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(ApiClient.GetDefaultHttpOptions(false, null).BaseUrl,
                      clientGemini._apiClient.HttpOptions.BaseUrl);
    }

#endregion

#region Constructor VertexAI Resolution Tests

    [TestMethod]
    public void Constructor_VertexAI_TrueByParameter() {
      var client = new Client(vertexAI: true, project: "project", location: "location");

      Assert.IsTrue(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_VertexAI_FalseByParameter() {
      var client = new Client(vertexAI: false, apiKey: "key");

      Assert.IsFalse(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_VertexAI_TrueByEnvironment() {
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", "true");

      var client = new Client(project: "project", location: "location");

      Assert.IsTrue(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_VertexAI_FalseByEnvironment() {
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", "false");

      var client = new Client(apiKey: "key");

      Assert.IsFalse(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_VertexAI_FalseByEnvironment_CaseInsensitive() {
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", "FALSE");

      var client = new Client(apiKey: "key");

      Assert.IsFalse(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_VertexAI_DefaultsToFalse_NoParamOrEnv() {
      var client = new Client(apiKey: "key");

      Assert.IsFalse(client._apiClient.VertexAI);
    }

#endregion

#region Constructor Enterprise Resolution Tests
    [TestMethod]
    public void Constructor_Enterprise_TrueByParameter()
    {
        var client = new Client(enterprise: true, project: "project", location: "location");
        Assert.IsTrue(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_Enterprise_FalseByParameter()
    {
        var client = new Client(enterprise: false, apiKey: "key");
        Assert.IsFalse(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_Enterprise_TrueByEnvironment()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", "true");
        var client = new Client(project: "project", location: "location");
        Assert.IsTrue(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_Enterprise_FalseByEnvironment()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", "false");
        var client = new Client(apiKey: "key");
        Assert.IsFalse(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_Enterprise_VertexAi_Params_Conflict_Case1()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => new Client(enterprise: true, vertexAI: false, project: "project", location: "location"));
    }

    [TestMethod]
    public void Constructor_Enterprise_VertexAi_Params_Conflict_Case2()
    {
        var ex = Assert.ThrowsException<ArgumentException>(() => new Client(enterprise: false, vertexAI: true, project: "project", location: "location"));
    }

    [TestMethod]
    public void Constructor_Enterprise_FalseByEnvironment_VertexAI_TrueByParameter() {
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", "false");
      var client = new Client(vertexAI: true, project: "project", location: "location");
      Assert.IsTrue(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_Enterprise_TakesPriorityOverVertexAi_Env()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", "true");
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", "false");
        var client = new Client(project: "project", location: "location");
        Assert.IsTrue(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_Enterprise_FallsbackToVertexAi_Param()
    {
        var client = new Client(enterprise: null, vertexAI: true, project: "project", location: "location");
        Assert.IsTrue(client._apiClient.VertexAI);
    }

    [TestMethod]
    public void Constructor_Enterprise_FallsbackToVertexAi_Env()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", "true");
        var client = new Client(project: "project", location: "location");
        Assert.IsTrue(client._apiClient.VertexAI);
    }

#endregion

#region Constructor Warning Tests
    [TestMethod]
    public void Constructor_Warns_On_EnterpriseEnv_And_VertexEnv()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", "false");
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", "true");
        var sw = new System.IO.StringWriter();
        var listener = new System.Diagnostics.TextWriterTraceListener(sw);
        System.Diagnostics.Trace.Listeners.Add(listener);

        try
        {
            var client = new Client(project: "project", location: "location");
            listener.Flush();
            var output = sw.ToString();
            StringAssert.Contains(output, "Warning: Both GOOGLE_GENAI_USE_ENTERPRISE and GOOGLE_GENAI_USE_VERTEXAI are set. The value of GOOGLE_GENAI_USE_ENTERPRISE will be used.");
            Assert.IsTrue(client._apiClient.VertexAI);
        }
        finally
        {
            System.Diagnostics.Trace.Listeners.Remove(listener);
        }
    }

    [TestMethod]
    public void Constructor_NoWarning_On_EnterpriseParam_Only()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI", "false");
        var sw = new System.IO.StringWriter();
        var listener = new System.Diagnostics.TextWriterTraceListener(sw);
        System.Diagnostics.Trace.Listeners.Add(listener);

        try
        {
            var client = new Client(enterprise: true, project: "project", location: "location");
            listener.Flush();
            var output = sw.ToString();
            Assert.AreEqual(string.Empty, output.Trim());
            Assert.IsTrue(client._apiClient.VertexAI);
        }
        finally
        {
            System.Diagnostics.Trace.Listeners.Remove(listener);
        }
    }

    [TestMethod]
    public void Constructor_NoWarning_On_VertexParam_Only()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_ENTERPRISE", "false");
        var sw = new System.IO.StringWriter();
        var listener = new System.Diagnostics.TextWriterTraceListener(sw);
        System.Diagnostics.Trace.Listeners.Add(listener);

        try
        {
            var client = new Client(vertexAI: true, project: "project", location: "location");
            listener.Flush();
            var output = sw.ToString();
            Assert.AreEqual(string.Empty, output.Trim());
        }
        finally
        {
            System.Diagnostics.Trace.Listeners.Remove(listener);
        }
    }
#endregion

#region Constructor Credential / Parameter Source Tests(Vertex AI)

    [TestMethod]
    public void Constructor_VertexAI_ProjectLocationFromParams() {
      var project = "param-project";
      var location = "param-location";

      var client = new Client(vertexAI: true, project: project, location: location);

      Assert.IsTrue(client._apiClient.VertexAI);
      Assert.AreEqual(project, client._apiClient.Project);
      Assert.AreEqual(location, client._apiClient.Location);
      Assert.IsNull(client._apiClient.ApiKey);
    }

    [TestMethod]
    public void Constructor_VertexAI_ProjectLocationFromEnv() {
      var projectEnv = "env-project";
      var locationEnv = "env-location";
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", projectEnv);
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_LOCATION", locationEnv);

      var client = new Client(vertexAI: true);

      Assert.IsTrue(client._apiClient.VertexAI);
      Assert.AreEqual(projectEnv, client._apiClient.Project);
      Assert.AreEqual(locationEnv, client._apiClient.Location);
    }

    [TestMethod]
    public void Constructor_VertexAI_ParamsOverrideEnv_ProjectLocation() {
      var projectParam = "param-project";
      var locationParam = "param-location";
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "env-project");
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_LOCATION", "env-location");

      var client = new Client(vertexAI: true, project: projectParam, location: locationParam);

      Assert.AreEqual(projectParam, client._apiClient.Project);
      Assert.AreEqual(locationParam, client._apiClient.Location);
    }

    [TestMethod]
    public void Constructor_VertexAI_CredentialFromParam() {
      var mockCredential = new Mock<ICredential>();

      var client = new Client(vertexAI: true, project: "project", location: "location",
                              credential: mockCredential.Object);

      Assert.IsTrue(client._apiClient.VertexAI);
      Assert.AreEqual("project", client._apiClient.Project);
      Assert.AreEqual("location", client._apiClient.Location);
      Assert.AreSame(mockCredential.Object, client._apiClient.Credentials);
    }

    [TestMethod]
    // this is to test that Client delegates credential resolution to the ApiClient
    public void Constructor_VertexAI_CredentialNull_DoesNotThrowImmediately() {
      try {
        var client =
            new Client(vertexAI: true, project: "project", location: "location", credential: null);
        Assert.IsNotNull(client._apiClient);
      } catch (ArgumentException ex)
          when (ex.Message.Contains("Failed to get application default credentials")) {
        // This is an expected outcome if ADC is not configured
        Assert.IsTrue(true, "Caught expected ArgumentException for missing ADC.");
      }
    }

#endregion

#region Constructor Credential / Parameter Source Tests(Gemini AI)

    [TestMethod]
    public void Constructor_GeminiAI_ApiKeyFromParam() {
      var apiKey = "param-apikey";
      var client = new Client(vertexAI: false, apiKey: apiKey);
      Assert.IsFalse(client._apiClient.VertexAI);
      Assert.AreEqual(apiKey, client._apiClient.ApiKey);
      Assert.IsNull(client._apiClient.Project);
      Assert.IsNull(client._apiClient.Location);
    }

    [TestMethod]
    public void Constructor_GeminiAI_ApiKeyFromEnv() {
      var apiKeyEnv = "env-apikey";
      System.Environment.SetEnvironmentVariable("GOOGLE_API_KEY", apiKeyEnv);

      var client = new Client(vertexAI: false);
      Assert.IsFalse(client._apiClient.VertexAI);
      Assert.AreEqual(apiKeyEnv, client._apiClient.ApiKey);
    }

    [TestMethod]
    public void Constructor_GeminiAI_ParamOverridesEnv_ApiKey() {
      var apiKeyParam = "param-apikey";
      System.Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "env-apikey");

      var client = new Client(vertexAI: false, apiKey: apiKeyParam);
      Assert.AreEqual(apiKeyParam, client._apiClient.ApiKey);
    }
#endregion

#region Constructor Validation Error Tests

    [TestMethod]
    public void Constructor_Error_ProjectAndApiKeySet_Params() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(project: "project", apiKey: "key"));
      Assert.AreEqual("Project/location and API key are mutually exclusive in the client initializer.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_ProjectEnvAndApiKeyParam_UsesApiKeyMode() {
      System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "env-project");
      var client = new Client(apiKey: "key");
      Assert.IsFalse(client._apiClient.VertexAI);
      Assert.AreEqual("key", client._apiClient.ApiKey);
      Assert.IsNull(client._apiClient.Project);
    }

    [TestMethod]
    public void Constructor_ProjectParamAndApiKeyEnv_UsesApiKeyModeIfVertexFalse() {
      var apiKeyParam = "env-key";
      System.Environment.SetEnvironmentVariable("GOOGLE_API_KEY", apiKeyParam);
      var client = new Client(project: "project", vertexAI: false); // VertexAI false overrides project parameter in Python sdk
      Assert.IsFalse(client._apiClient.VertexAI);
      Assert.AreEqual(apiKeyParam, client._apiClient.ApiKey);
    }

    [TestMethod]
    public void Constructor_Error_LocationAndApiKeySet_Params() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(location: "location", apiKey: "key"));
      Assert.AreEqual("Project/location and API key are mutually exclusive in the client initializer.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_Error_ProjectSet_VertexAIFalse_Param() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(vertexAI: false, project: "project", location: "location"));
      Assert.AreEqual("project/location is present, but neither enterprise nor vertexAI is set to true. project/location can only be used for a cloud platform. Please set enterprise to be true.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_Error_ProjectSet_EnterpriseFalse_Param() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(enterprise: false, project: "project", location: "location"));
      Assert.AreEqual("project/location is present, but neither enterprise nor vertexAI is set to true. project/location can only be used for a cloud platform. Please set enterprise to be true.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_Error_ProjectSet_VertexAIDefaultsToFalse_Env() {
      System.Environment.SetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI",
                                                "false");  // Explicitly false
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(project: "project", location: "location"));
      Assert.AreEqual("project/location is present, but neither enterprise nor vertexAI is set to true. project/location can only be used for a cloud platform. Please set enterprise to be true.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_Error_ProjectSet_VertexAINotSet_Env() {
      // GOOGLE_GENAI_USE_VERTEXAI is null (cleared in TestInitialize), defaults to false
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(project: "project", location: "location"));
      Assert.AreEqual("project/location is present, but neither enterprise nor vertexAI is set to true. project/location can only be used for a cloud platform. Please set enterprise to be true.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_Error_LocationSet_VertexAIFalse_Param() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(vertexAI: false, location: "location", project: "project"));
      Assert.AreEqual("project/location is present, but neither enterprise nor vertexAI is set to true. project/location can only be used for a cloud platform. Please set enterprise to be true.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_Error_ApiKeySet_VertexAITrue_Param() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(vertexAI: true, apiKey: "key", project: "project", location: "location"));
      Assert.AreEqual("Project/location and API key are mutually exclusive in the client initializer.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_VertexAI_MissingProject_ThrowsArgumentException() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(vertexAI: true, location: "location"));
      Assert.AreEqual("Project or API key must be set when using the Vertex AI API.",
                      ex.Message);
    }

    [TestMethod]
    public void Constructor_VertexAI_MissingLocation_DefaultsToGlobal() {
      var client = new Client(vertexAI: true, project: "project");
      Assert.AreEqual("global", client._apiClient.Location);
    }

    [TestMethod]
    public void Constructor_VertexAI_WithCredentials_MissingLocation_DefaultsToGlobal()
    {
      var mockCredential = new Mock<ICredential>();
      var client = new Client(vertexAI: true, project: "project", credential: mockCredential.Object);
      Assert.AreEqual("global", client._apiClient.Location);
      Assert.AreEqual("project", client._apiClient.Project);
    }

    [TestMethod]
    public void Constructor_VertexAI_ExplicitProjectAndEnvApiKey_MissingLocation_DefaultsToGlobal()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "env_api_key");
        var client = new Client(vertexAI: true, project: "project");
        Assert.AreEqual("global", client._apiClient.Location);
        Assert.AreEqual("project", client._apiClient.Project);
        Assert.IsNull(client._apiClient.ApiKey);
    }

    [TestMethod]
    public void Constructor_VertexAI_EnvProjectAndGoodBaseUrl_MissingLocation_DefaultsToGlobal()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "project");
        var client = new Client(vertexAI: true, httpOptions: new HttpOptions { BaseUrl = "https://fake-url.googleapis.com" });
        Assert.AreEqual("global", client._apiClient.Location);
        Assert.AreEqual("project", client._apiClient.Project);
    }

    [TestMethod]
    public void Constructor_VertexAI_EnvProjectAndBadBaseUrl_MissingLocation_LocationIsNull()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "project");
        var client = new Client(vertexAI: true, httpOptions: new HttpOptions { BaseUrl = "https://fake-url.com" });
        Assert.IsNull(client._apiClient.Location);
        Assert.IsNull(client._apiClient.Project);
    }

    [TestMethod]
    public void Constructor_VertexAI_EnvProjectAndEnvApiKey_MissingLocation_DefaultsToGlobal()
    {
        System.Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "project");
        System.Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "env_api_key");
        var client = new Client(vertexAI: true);
        Assert.AreEqual("global", client._apiClient.Location);
        Assert.AreEqual("project", client._apiClient.Project);
        Assert.IsNull(client._apiClient.ApiKey);
    }

    [TestMethod]
    public void Constructor_VertexAI_ApiKeyOnly_LocationIsNull()
    {
        var client = new Client(vertexAI: true, apiKey: "api_key");
        Assert.IsNull(client._apiClient.Location);
        Assert.IsNull(client._apiClient.Project);
        Assert.AreEqual("api_key", client._apiClient.ApiKey);
    }

    [TestMethod]
    public void Constructor_GeminiAI_MissingApiKey_ThrowsArgumentException() {
      var ex = Assert.ThrowsException<ArgumentException>(
          () => new Client(vertexAI: false));
      Assert.AreEqual("API key must either be provided or set in the environment variable GOOGLE_API_KEY.",
                      ex.Message);
    }

#endregion

#region HttpOptions and BaseUrl Inference Tests

    // Case 1: httpOptions parameter to Client is null
    [TestMethod]
    public void Constructor_HttpOptionsNull_Vertex_UsesApiClientDefaultBaseUrl() {
      var expectedBaseUrl = ApiClient.GetDefaultHttpOptions(true, "us-central1").BaseUrl;

      var client = new Client(vertexAI: true, project: "project", location: "us-central1",
                              httpOptions: null);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void Constructor_HttpOptionsNull_Gemini_UsesApiClientDefaultBaseUrl() {
      var expectedBaseUrl = ApiClient.GetDefaultHttpOptions(false, null).BaseUrl;

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: null);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl);
    }

    [TestMethod]
    public void Constructor_HttpOptionsNull_WithStaticVertexUrlSet_UsesStaticVertexUrl() {
      Client.setDefaultBaseUrl("http://static-vertex.com/s", null);
      var expectedBaseUrl = "http://static-vertex.com/s";

      var client = new Client(vertexAI: true, project: "project", location: "us-central1",
                              httpOptions: null);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl,
                      "Static URL should be used even when httpOptions is null.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsNull_WithEnvVertexUrlSet_UsesEnvVertexUrl() {
      System.Environment.SetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL",
                                                "http://env-vertex.com/e");
      var expectedBaseUrl = "http://env-vertex.com/e";

      var client = new Client(vertexAI: true, project: "project", location: "us-central1",
                              httpOptions: null);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl,
                      "Env URL should be used even when httpOptions is null.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsNull_WithStaticGeminiUrlSet_UsesStaticGeminiUrl() {
      Client.setDefaultBaseUrl(null, "http://static-gemini.com/s");
      var expectedBaseUrl = "http://static-gemini.com/s";

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: null);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl,
                      "Static URL should be used even when httpOptions is null.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsNull_WithEnvGeminiUrlSet_UsesEnvGeminiUrl() {
      System.Environment.SetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL",
                                                "http://env-gemini.com/e");
      var expectedBaseUrl = "http://env-gemini.com/e";

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: null);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl,
                      "Env URL should be used even when httpOptions is null.");
    }

    // Case 2: httpOptions parameter to Client is NOT null
    [TestMethod]
    public void Constructor_HttpOptionsProvided_WithBaseUrl_UsesProvidedBaseUrl_Vertex() {
      var providedUrl = "http://provided.com/v";
      var options = new HttpOptions { BaseUrl = providedUrl };

      var client = new Client(vertexAI: true, project: "project", location: "location",
                              httpOptions: options);

      Assert.AreEqual(providedUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(
          providedUrl, options.BaseUrl,
          "Original HttpOptions object's BaseUrl should remain unchanged if it was initially set.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_WithBaseUrl_UsesProvidedBaseUrl_Gemini() {
      var providedUrl = "http://provided-gemini.com/g";
      var options = new HttpOptions { BaseUrl = providedUrl };

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: options);

      Assert.AreEqual(providedUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(
          providedUrl, options.BaseUrl,
          "Original HttpOptions object's BaseUrl should remain unchanged if it was initially set.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_NullBaseUrl_UsesStaticVertexUrl() {
      var staticVertexUrl = "http://static-vertex.com/s";
      Client.setDefaultBaseUrl(staticVertexUrl, null);
      var options = new HttpOptions { BaseUrl = null };

      var client = new Client(vertexAI: true, project: "project", location: "location",
                              httpOptions: options);

      Assert.AreEqual(staticVertexUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(staticVertexUrl, options.BaseUrl,
                      "Original HttpOptions object should be updated by Client constructor.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_NullBaseUrl_UsesEnvVertexUrl() {
      var envVertexUrl = "http://env-vertex.com/e";
      System.Environment.SetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL", envVertexUrl);
      var options = new HttpOptions { BaseUrl = null };

      var client = new Client(vertexAI: true, project: "project", location: "location",
                              httpOptions: options);

      Assert.AreEqual(envVertexUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(envVertexUrl, options.BaseUrl,
                      "Original HttpOptions object should be updated by Client constructor.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_NullBaseUrl_StaticOverridesEnvVertexUrl() {
      var staticVertexUrl = "http://static-vertex.com/s";
      var envVertexUrl = "http://env-vertex.com/e";
      Client.setDefaultBaseUrl(staticVertexUrl, null);
      System.Environment.SetEnvironmentVariable("GOOGLE_VERTEX_BASE_URL", envVertexUrl);
      var options = new HttpOptions { BaseUrl = null };

      var client = new Client(vertexAI: true, project: "project", location: "location",
                              httpOptions: options);

      Assert.AreEqual(staticVertexUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(staticVertexUrl, options.BaseUrl,
                      "Original HttpOptions object should be updated by Client constructor.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_NullBaseUrl_UsesStaticGeminiUrl() {
      var staticGeminiUrl = "http://static-gemini.com/s";
      Client.setDefaultBaseUrl(null, staticGeminiUrl);
      var options = new HttpOptions { BaseUrl = null };

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: options);

      Assert.AreEqual(staticGeminiUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(staticGeminiUrl, options.BaseUrl,
                      "Original HttpOptions object should be updated by Client constructor.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_NullBaseUrl_UsesEnvGeminiUrl() {
      var envGeminiUrl = "http://env-gemini.com/e";
      System.Environment.SetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL", envGeminiUrl);
      var options = new HttpOptions { BaseUrl = null };

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: options);

      Assert.AreEqual(envGeminiUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(envGeminiUrl, options.BaseUrl,
                      "Original HttpOptions object should be updated by Client constructor.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_NullBaseUrl_StaticOverridesEnvGeminiUrl() {
      var staticGeminiUrl = "http://static-gemini.com/s";
      var envGeminiUrl = "http://env-gemini.com/e";
      Client.setDefaultBaseUrl(null, staticGeminiUrl);
      System.Environment.SetEnvironmentVariable("GOOGLE_GEMINI_BASE_URL", envGeminiUrl);
      var options = new HttpOptions { BaseUrl = null };

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: options);

      Assert.AreEqual(staticGeminiUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.AreEqual(staticGeminiUrl, options.BaseUrl,
                      "Original HttpOptions object should be updated by Client constructor.");
    }

    [TestMethod]
    public void
    Constructor_HttpOptionsProvided_NullBaseUrl_NoStaticOrEnv_UsesApiClientDefault_Vertex() {
      var options = new HttpOptions { BaseUrl = null };
      var expectedBaseUrl = ApiClient.GetDefaultHttpOptions(true, "us-central1").BaseUrl;

      var client = new Client(vertexAI: true, project: "project", location: "us-central1",
                              httpOptions: options);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.IsNull(
          options.BaseUrl,
          "Original HttpOptions.BaseUrl should remain null if inferBaseUrl also returns null.");
    }

    [TestMethod]
    public void
    Constructor_HttpOptionsProvided_NullBaseUrl_NoStaticOrEnv_UsesApiClientDefault_Gemini() {
      var options = new HttpOptions { BaseUrl = null };
      var expectedBaseUrl = ApiClient.GetDefaultHttpOptions(false, null).BaseUrl;

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: options);

      Assert.AreEqual(expectedBaseUrl, client._apiClient.HttpOptions.BaseUrl);
      Assert.IsNull(
          options.BaseUrl,
          "Original HttpOptions.BaseUrl should remain null if inferBaseUrl also returns null.");
    }

    [TestMethod]
    public void Constructor_HttpOptionsProvided_Timeout() {
      var options = new HttpOptions { Timeout = 1000 };

      var client = new Client(vertexAI: false, apiKey: "key", httpOptions: options);

      Assert.AreEqual(1000, client._apiClient.HttpOptions.Timeout);
    }

    [TestMethod]
    public void Constructor_ClientOptionsProvided_HttpClientFactory() {
      var proxyAddress = "http://your-proxy-address:port";
      var options =
          new ClientOptions { HttpClientFactory = () => new HttpClient(
                                  new HttpClientHandler { Proxy = new WebProxy(proxyAddress) }) };

      var client = new Client(vertexAI: true, project: "project", location: "location",
                              clientOptions: options);

      Assert.AreSame(options.HttpClientFactory, client._apiClient.ClientOptions.HttpClientFactory);
    }
#endregion

#region Successful Instantiation(all modules)

    [TestMethod]
    public void Constructor_InitializesModules_Vertex() {
      var client = new Client(vertexAI: true, project: "project", location: "location");

      Assert.IsNotNull(client.Live);
      Assert.IsNotNull(client.Models);
    }

    [TestMethod]
    public void Constructor_InitializesModules_Gemini() {
      var client = new Client(vertexAI: false, apiKey: "key");

      Assert.IsNotNull(client.Live);
      Assert.IsNotNull(client.Models);
    }

#endregion

#region Headers Tests

    [TestMethod]
    public void Constructor_HttpOptions_Null_Uses_Default_Headers() {
      var geminiClient = new Client(vertexAI: false, apiKey: "key");
      var geminiHeaders = geminiClient._apiClient.HttpOptions.Headers;
      var vertexClient = new Client(vertexAI: true, project: "project", location: "location");
      var vertexHeaders = vertexClient._apiClient.HttpOptions.Headers;

      Assert.AreEqual("application/json", geminiHeaders["Content-Type"]);
      Assert.AreEqual("application/json", vertexHeaders["Content-Type"]);
      StringAssert.Contains(geminiHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "gl-dotnet");
    }

    [TestMethod]
    public void Constructor_HttpOptions_Empty_Headers_Uses_Default_Headers() {
      var options =
          new HttpOptions { Headers = new System.Collections.Generic.Dictionary<string, string>() };
      var geminiClient = new Client(vertexAI: false, apiKey: "key", httpOptions: options);
      var geminiHeaders = geminiClient._apiClient.HttpOptions.Headers;
      var vertexClient = new Client(vertexAI: true, project: "project", location: "location",
                                    httpOptions: options);
      var vertexHeaders = vertexClient._apiClient.HttpOptions.Headers;

      Assert.AreEqual("application/json", geminiHeaders["Content-Type"]);
      Assert.AreEqual("application/json", vertexHeaders["Content-Type"]);
      StringAssert.Contains(geminiHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "gl-dotnet");
    }

    [TestMethod]
    public void Constructor_HttpOptions_Custom_Headers_Overrides_Default() {
      var options =
          new HttpOptions { Headers = new System.Collections.Generic.Dictionary<string, string> {
            { "custom-header", "custom-value" }, { "Content-Type", "application/xml" }
          } };
      var geminiClient = new Client(vertexAI: false, apiKey: "key", httpOptions: options);
      var geminiHeaders = geminiClient._apiClient.HttpOptions.Headers;
      var vertexClient = new Client(vertexAI: true, project: "project", location: "location",
                                    httpOptions: options);
      var vertexHeaders = vertexClient._apiClient.HttpOptions.Headers;

      Assert.AreEqual("custom-value", geminiHeaders["custom-header"]);
      Assert.AreEqual("application/xml", geminiHeaders["Content-Type"]);
      Assert.AreEqual("custom-value", vertexHeaders["custom-header"]);
      Assert.AreEqual("application/xml", vertexHeaders["Content-Type"]);
      StringAssert.Contains(geminiHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "gl-dotnet");
    }

    [TestMethod]
    public void Constructor_HttpOptions_Custom_User_Agent_Appends_To_Default() {
      var options =
          new HttpOptions { Headers = new System.Collections.Generic.Dictionary<string, string> {
            { "User-Agent", "custom-user-agent" }
          } };
      var geminiClient = new Client(vertexAI: false, apiKey: "key", httpOptions: options);
      var geminiHeaders = geminiClient._apiClient.HttpOptions.Headers;
      var vertexClient = new Client(vertexAI: true, project: "project", location: "location",
                                    httpOptions: options);
      var vertexHeaders = vertexClient._apiClient.HttpOptions.Headers;

      Assert.AreEqual("application/json", geminiHeaders["Content-Type"]);
      Assert.AreEqual("application/json", vertexHeaders["Content-Type"]);
      StringAssert.Contains(geminiHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(geminiHeaders["User-Agent"], "custom-user-agent");
      StringAssert.Contains(vertexHeaders["User-Agent"], "custom-user-agent");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "gl-dotnet");
    }

    [TestMethod]
    public void Constructor_HttpOptions_Custom_Goog_Api_Client_Appends_To_Default() {
      var options =
          new HttpOptions { Headers = new System.Collections.Generic.Dictionary<string, string> {
            { "x-goog-api-client", "custom-api-client" }
          } };
      var geminiClient = new Client(vertexAI: false, apiKey: "key", httpOptions: options);
      var geminiHeaders = geminiClient._apiClient.HttpOptions.Headers;
      var vertexClient = new Client(vertexAI: true, project: "project", location: "location",
                                    httpOptions: options);
      var vertexHeaders = vertexClient._apiClient.HttpOptions.Headers;

      Assert.AreEqual("application/json", geminiHeaders["Content-Type"]);
      Assert.AreEqual("application/json", vertexHeaders["Content-Type"]);
      StringAssert.Contains(geminiHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["User-Agent"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["User-Agent"], "gl-dotnet");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "google-genai-sdk");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "gl-dotnet");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "gl-dotnet");
      StringAssert.Contains(geminiHeaders["x-goog-api-client"], "custom-api-client");
      StringAssert.Contains(vertexHeaders["x-goog-api-client"], "custom-api-client");
    }

#endregion
  }
}
