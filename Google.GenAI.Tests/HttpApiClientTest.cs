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
      var client = new HttpApiClient(TestApiKey, null);

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

      var client = new HttpApiClient(null, null);

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

      var client = new HttpApiClient(null, customHttpOptions);

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

      var ex = Assert.ThrowsException<ArgumentException>(() => new HttpApiClient(null, null));
      Assert.IsTrue(ex.Message.Contains(
          "API key must either be provided or set in the environment variable GOOGLE_API_KEY."));
    }

    [TestMethod]
    public void GeminiConstructor_EmptyApiKey_ThrowsArgumentException() {
      System.Environment.SetEnvironmentVariable(EnvApiKeyName, null);

      var ex = Assert.ThrowsException<ArgumentException>(() => new HttpApiClient("", null));
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

      var client = new HttpApiClient(TestProject, TestLocation, mockCredential.Object, null);

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

      var client = new HttpApiClient(null, null, mockCredential.Object, null);

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
          () => new HttpApiClient(null, TestLocation, mockCredential.Object, null));
      Assert.IsTrue(ex.Message.Contains(
          "Project must either be provided or set in the environment variable GOOGLE_CLOUD_PROJECT."));
    }

    [TestMethod]
    public void VertexConstructor_NullLocation_ThrowsArgumentException() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");
      System.Environment.SetEnvironmentVariable(EnvLocationName, null);

      var ex = Assert.ThrowsException<ArgumentException>(
          () => new HttpApiClient(TestProject, null, mockCredential.Object, null));
      Assert.IsTrue(ex.Message.Contains(
          "Location must either be provided or set in the environment variable GOOGLE_CLOUD_LOCATION."));
    }

    [TestMethod]
    public void VertexConstructor_EmptyProject_ThrowsArgumentException() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");

      var ex = Assert.ThrowsException<ArgumentException>(
          () => new HttpApiClient("", TestLocation, mockCredential.Object, null));
      Assert.IsTrue(ex.Message.Contains(
          "Project must either be provided or set in the environment variable GOOGLE_CLOUD_PROJECT."));
    }

    [TestMethod]
    public void VertexConstructor_EmptyLocation_ThrowsArgumentException() {
      var mockCredential = new Mock<ICredential>();
      mockCredential
          .Setup(c => c.GetAccessTokenForRequestAsync(
                     It.IsAny<string?>(), It.IsAny<System.Threading.CancellationToken>()))
          .ReturnsAsync("mock-access-token");

      var ex = Assert.ThrowsException<ArgumentException>(
          () => new HttpApiClient(TestProject, "", mockCredential.Object, null));
      Assert.IsTrue(ex.Message.Contains(
          "Location must either be provided or set in the environment variable GOOGLE_CLOUD_LOCATION."));
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
          new HttpApiClient(TestProject, TestLocation, mockCredential.Object, customOptions);

      Assert.AreEqual(TestProject, client.Project);
      Assert.AreEqual(TestLocation, client.Location);
      Assert.AreEqual(mockCredential.Object, client.Credentials);
      Assert.IsTrue(client.VertexAI);
      Assert.IsNull(client.ApiKey);
      Assert.AreEqual("https://custom.vertex.ai", client.HttpOptions.BaseUrl);
      Assert.AreEqual("v2alpha", client.HttpOptions.ApiVersion);
      Assert.AreEqual(8000, client.HttpOptions.Timeout);
    }
  }
}
