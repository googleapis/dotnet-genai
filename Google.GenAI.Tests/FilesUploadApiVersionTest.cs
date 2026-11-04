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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests {
  /// <summary>
  /// Tests that Gemini API file uploads go to <c>upload/{resolved API version}/files</c>.
  /// </summary>
  [TestClass]
  public class FilesUploadApiVersionTest {
    private const string TestApiKey = "test-api-key";
    private const string ApiVersionEnvName = "GOOGLE_GENAI_API_VERSION";
    private const string SessionUrl =
        "https://generativelanguage.googleapis.com/upload/session/abc?upload_id=123";

    private string? _originalApiVersionEnv;

    [TestInitialize]
    public void TestInitialize() {
      _originalApiVersionEnv = System.Environment.GetEnvironmentVariable(ApiVersionEnvName);
      System.Environment.SetEnvironmentVariable(ApiVersionEnvName, null);
    }

    [TestCleanup]
    public void TestCleanup() {
      System.Environment.SetEnvironmentVariable(ApiVersionEnvName, _originalApiVersionEnv);
    }

    /// <summary>
    /// Fake upload server: answers the start request with an upload session URL and the chunk
    /// request with a finalized file. Records every request URL.
    /// </summary>
    private sealed class FakeUploadServer : HttpMessageHandler {
      public List<string> RequestUrls { get; } = new List<string>();

      protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                             CancellationToken cancellationToken) {
        RequestUrls.Add(request.RequestUri!.ToString());
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        if (request.Headers.TryGetValues("X-Goog-Upload-Command", out var commands) &&
            commands.First() == "start") {
          response.Headers.Add("x-goog-upload-url", SessionUrl);
          response.Content = new StringContent("{}", Encoding.UTF8, "application/json");
        } else {
          response.Headers.Add("X-Goog-Upload-Status", "final");
          response.Content = new StringContent("{\"file\": {\"name\": \"files/abc\"}}",
                                               Encoding.UTF8, "application/json");
        }
        return Task.FromResult(response);
      }
    }

    private static Client NewClient(FakeUploadServer server, string? apiVersion = null) {
      return new Client(
          vertexAI: false, apiKey: TestApiKey,
          httpOptions: apiVersion != null ? new HttpOptions { ApiVersion = apiVersion } : null,
          clientOptions: new ClientOptions { HttpClientFactory = () => new HttpClient(server) });
    }

    private static string StartUrl(string version) =>
        $"https://generativelanguage.googleapis.com/upload/{version}/files";

    [TestMethod]
    public async Task UploadBytes_Default_UsesDefaultApiVersion() {
      var server = new FakeUploadServer();
      using var client = NewClient(server);

      var file = await client.Files.UploadAsync(new byte[] { 1, 2, 3 }, "test.txt");

      Assert.AreEqual("files/abc", file.Name);
      Assert.AreEqual(2, server.RequestUrls.Count);
      Assert.AreEqual(StartUrl(ApiClient.GoogleAiApiDefaultVersion), server.RequestUrls[0]);
      // Chunks go to the server-provided session URL unchanged.
      Assert.AreEqual(SessionUrl, server.RequestUrls[1]);
    }

    [TestMethod]
    public async Task UploadBytes_ClientApiVersion_UsesClientApiVersion() {
      var server = new FakeUploadServer();
      using var client = NewClient(server, apiVersion: "v1alpha");

      await client.Files.UploadAsync(new byte[] { 1, 2, 3 }, "test.txt");

      Assert.AreEqual(StartUrl("v1alpha"), server.RequestUrls[0]);
      Assert.AreEqual(SessionUrl, server.RequestUrls[1]);
    }

    [TestMethod]
    public async Task UploadStream_ClientApiVersion_UsesClientApiVersion() {
      var server = new FakeUploadServer();
      using var client = NewClient(server, apiVersion: "v1alpha");
      using var stream = new MemoryStream(new byte[] { 1, 2, 3 });

      await client.Files.UploadAsync(stream, stream.Length, "test.txt", "text/plain");

      Assert.AreEqual(StartUrl("v1alpha"), server.RequestUrls[0]);
    }

    [TestMethod]
    public async Task UploadFilePath_ClientApiVersion_UsesClientApiVersion() {
      var server = new FakeUploadServer();
      using var client = NewClient(server, apiVersion: "v1alpha");
      string path = Path.GetTempFileName();
      try {
        System.IO.File.WriteAllBytes(path, new byte[] { 1, 2, 3 });

        await client.Files.UploadAsync(path, new UploadFileConfig { MimeType = "text/plain" });
      } finally {
        System.IO.File.Delete(path);
      }

      Assert.AreEqual(StartUrl("v1alpha"), server.RequestUrls[0]);
    }

    [TestMethod]
    public async Task UploadBytes_RequestApiVersion_OverridesClientApiVersion() {
      var server = new FakeUploadServer();
      using var client = NewClient(server);

      await client.Files.UploadAsync(
          new byte[] { 1, 2, 3 }, "test.txt",
          new UploadFileConfig { HttpOptions = new HttpOptions { ApiVersion = "v1alpha" } });

      Assert.AreEqual(StartUrl("v1alpha"), server.RequestUrls[0]);
      Assert.AreEqual(SessionUrl, server.RequestUrls[1]);
    }

    [TestMethod]
    public async Task UploadBytes_EnvApiVersion_UsesEnvApiVersion() {
      System.Environment.SetEnvironmentVariable(ApiVersionEnvName, "v1alpha");
      var server = new FakeUploadServer();
      using var client = NewClient(server);

      await client.Files.UploadAsync(new byte[] { 1, 2, 3 }, "test.txt");

      Assert.AreEqual(StartUrl("v1alpha"), server.RequestUrls[0]);
    }

    [TestMethod]
    public async Task UploadBytes_EmptyRequestApiVersion_OmitsVersion() {
      var server = new FakeUploadServer();
      using var client = NewClient(server);

      await client.Files.UploadAsync(
          new byte[] { 1, 2, 3 }, "test.txt",
          new UploadFileConfig { HttpOptions = new HttpOptions { ApiVersion = "" } });

      Assert.AreEqual("https://generativelanguage.googleapis.com/upload/files",
                      server.RequestUrls[0]);
    }

    [TestMethod]
    public void BuildResumableUploadHttpOptions_PassesThroughApiVersion() {
      var options = UploadClient.BuildResumableUploadHttpOptions(
          new HttpOptions { ApiVersion = "v1alpha" }, "text/plain", "test.txt", 3);
      Assert.AreEqual("v1alpha", options.ApiVersion);

      options = UploadClient.BuildResumableUploadHttpOptions(null, "text/plain", "test.txt", 3);
      Assert.IsNull(options.ApiVersion);
    }

    [TestMethod]
    [DataRow("upload/{api_version}/files", "v1", "upload/v1/files")]
    [DataRow("upload/{api_version}/files", "v1alpha", "upload/v1alpha/files")]
    [DataRow("upload/{api_version}/files", "v1beta", "upload/v1beta/files")]
    [DataRow("upload/{api_version}/files", "", "upload/files")]
    [DataRow("upload/{api_version}/fileSearchStores/abc:uploadToFileSearchStore", "v1alpha",
             "upload/v1alpha/fileSearchStores/abc:uploadToFileSearchStore")]
    public void ResolveApiVersionInPath_SubstitutesPlaceholder(string path, string apiVersion,
                                                               string expected) {
      Assert.AreEqual(expected, ApiClient.ResolveApiVersionInPath(path, apiVersion));
    }

    [TestMethod]
    public async Task CreateHttpRequestAsync_UploadPathWithProxy_UsesBaseUrlAndClientVersion() {
      var client = new HttpApiClient(
          apiKey: TestApiKey,
          httpOptions: new HttpOptions { BaseUrl = "https://my-proxy.company.com",
                                         ApiVersion = "v1alpha" });
      var method = typeof(HttpApiClient).GetMethod(
          "CreateHttpRequestAsync",
          System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance, null,
          new[] { typeof(HttpMethod), typeof(string), typeof(string), typeof(HttpOptions) }, null);
      Assert.IsNotNull(method);

      var request = await (Task<HttpRequestMessage>)method!.Invoke(
          client, new object?[] { HttpMethod.Post, "upload/{api_version}/files", "{}", null })!;

      Assert.AreEqual("https://my-proxy.company.com/upload/v1alpha/files",
                      request.RequestUri!.ToString());
    }
  }
}
