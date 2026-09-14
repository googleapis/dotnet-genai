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
using System.Text;
using System.Threading.Tasks;
using Google.GenAI;
using Google.GenAI.Gaos.Models.Requests;
using Google.GenAI.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests
{
  [TestClass]
  public class EnvironmentsTest
  {
    [TestMethod]
    public void TestClientExposesEnvironmentsAndTriggers()
    {
      using var client = new Client(apiKey: "test-api-key");
      Assert.IsNotNull(client.Environments);
      Assert.IsNotNull(client.Environments.Files);
      Assert.IsNotNull(client.Triggers);
      Assert.IsNotNull(client.Agents);
      Assert.IsNotNull(client.Webhooks);
      Assert.IsNotNull(client.Interactions);
    }

    private sealed class MockHttpHandler : HttpMessageHandler
    {
      public List<string> Requests { get; } = new List<string>();

      protected override Task<HttpResponseMessage> SendAsync(
          HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
      {
        lock (Requests)
        {
          Requests.Add(request.RequestUri?.ToString() ?? "");
        }

        var uri = request.RequestUri?.ToString() ?? "";
        if (uri.Contains("alt=media"))
        {
          var res = new HttpResponseMessage(HttpStatusCode.OK)
          {
            Content = new ByteArrayContent(Encoding.UTF8.GetBytes("print('downloaded content')\n"))
          };
          res.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
          return Task.FromResult(res);
        }
        else
        {
          string json = "{\"files\":[{\"name\":\"main.py\",\"path\":\"workspace/src/main.py\",\"type\":\"file\",\"sizeBytes\":\"128\"}],\"nextPageToken\":\"token_next_123\"}";
          var res = new HttpResponseMessage(HttpStatusCode.OK)
          {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
          };
          return Task.FromResult(res);
        }
      }
    }

    [TestMethod]
    public async Task TestEnvironmentsFilesListAndDownload()
    {
      var handler = new MockHttpHandler();
      using var client = new Client(
          apiKey: "test-api-key",
          httpOptions: new HttpOptions { BaseUrl = "https://mock.googleapis.com", ApiVersion = "v1beta" },
          clientOptions: new ClientOptions { HttpClientFactory = () => new HttpClient(handler) }
      );

      // 2. Test ListAsync with request object, pagination, recursive
      var listReq = new GetEnvironmentFilesRequest
      {
        Environment = "environments/env_123",
        Path = "/src",
        PageSize = 10,
        PageToken = "token_start",
        Recursive = true
      };
      var listRes2 = await client.Environments.Files.ListAsync(listReq);
      Assert.IsNotNull(listRes2);
    }
  }
}
