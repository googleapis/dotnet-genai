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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests {
  /// <summary>Tests for the HTTP retry behaviour of <see cref="HttpApiClient"/>.</summary>
  [TestClass]
  public class HttpApiClientRetryTests {
    private const string TestApiKey = "test-api-key";

    /// <summary>Replays a scripted sequence of status codes, one per request.</summary>
    private sealed class ScriptedHandler : HttpMessageHandler {
      private readonly IReadOnlyList<HttpStatusCode> _statuses;
      private int _calls;

      public ScriptedHandler(params HttpStatusCode[] statuses) {
        _statuses = statuses;
      }

      public int Calls => Volatile.Read(ref _calls);

      /// <summary>Bodies observed per attempt, to prove the payload is resent.</summary>
      public List<string> Bodies { get; } = new List<string>();

      protected override async Task<HttpResponseMessage> SendAsync(
          HttpRequestMessage request, CancellationToken cancellationToken) {
        int index = Interlocked.Increment(ref _calls) - 1;
        if (request.Content != null) {
          string body = await request.Content.ReadAsStringAsync();
          lock (Bodies) {
            Bodies.Add(body);
          }
        }
        HttpStatusCode status =
            index < _statuses.Count ? _statuses[index] : _statuses[_statuses.Count - 1];
        return new HttpResponseMessage(status) {
          Content = new StringContent(
              "{\"error\": {\"code\": " + (int)status + ", \"message\": \"scripted\"}}"),
        };
      }
    }

    /// <summary>Always throws, to exercise the transport-failure path.</summary>
    private sealed class ThrowingHandler : HttpMessageHandler {
      private int _calls;
      public int Calls => Volatile.Read(ref _calls);

      protected override Task<HttpResponseMessage> SendAsync(
          HttpRequestMessage request, CancellationToken cancellationToken) {
        Interlocked.Increment(ref _calls);
        throw new HttpRequestException("simulated connection failure");
      }
    }

    /// <summary>Retry options with the backoff zeroed, so tests do not sleep.</summary>
    private static HttpRetryOptions NoBackoff(int attempts, params int[] statusCodes) {
      return new HttpRetryOptions {
        Attempts = attempts,
        InitialDelay = 0.0,
        MaxDelay = 0.0,
        Jitter = 0.0,
        HttpStatusCodes = statusCodes.Length > 0 ? statusCodes.ToList() : null,
      };
    }

    private static HttpApiClient NewClient(HttpMessageHandler handler,
                                           HttpRetryOptions? clientRetryOptions = null) {
      return new HttpApiClient(
          vertexAI: false, apiKey: TestApiKey,
          httpOptions: new HttpOptions { RetryOptions = clientRetryOptions },
          clientOptions: new ClientOptions { HttpClientFactory = () => new HttpClient(handler) });
    }

    private static Task<ApiResponse> PostAsync(HttpApiClient client,
                                               HttpOptions? requestHttpOptions = null) {
      return client.RequestAsync(HttpMethod.Post, "test-path", "{\"key\": \"value\"}",
                                 requestHttpOptions);
    }

    [TestMethod]
    public async Task NoRetryOptions_MakesASingleAttempt() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
      var client = NewClient(handler);

      await Assert.ThrowsExceptionAsync<ServerError>(() => PostAsync(client));

      Assert.AreEqual(1, handler.Calls);
    }

    [TestMethod]
    public async Task RetryOptions_RetriesUntilSuccess() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable,
                                        HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
      var client = NewClient(handler, NoBackoff(attempts: 5));

      ApiResponse response = await PostAsync(client);

      Assert.IsNotNull(response);
      Assert.AreEqual(3, handler.Calls);
    }

    [TestMethod]
    public async Task RetryOptions_StopsAfterConfiguredAttempts() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable);
      var client = NewClient(handler, NoBackoff(attempts: 2));

      var ex = await Assert.ThrowsExceptionAsync<ServerError>(() => PostAsync(client));

      Assert.AreEqual(2, handler.Calls);
      // The typed error must survive the retry loop.
      Assert.AreEqual(503, ex.StatusCode);
    }

    [TestMethod]
    public async Task Attempts0Or1_MakeASingleAttempt() {
      foreach (int attempts in new[] { 0, 1 }) {
        var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
        var client = NewClient(handler, NoBackoff(attempts: attempts));

        await Assert.ThrowsExceptionAsync<ServerError>(() => PostAsync(client));

        Assert.AreEqual(1, handler.Calls, $"attempts={attempts} should make one call");
      }
    }

    [TestMethod]
    public async Task NonRetryableStatus_IsNotRetried() {
      var handler = new ScriptedHandler(HttpStatusCode.BadRequest, HttpStatusCode.OK);
      var client = NewClient(handler, NoBackoff(attempts: 5));

      var ex = await Assert.ThrowsExceptionAsync<ClientError>(() => PostAsync(client));

      Assert.AreEqual(1, handler.Calls);
      Assert.AreEqual(400, ex.StatusCode);
    }

    [TestMethod]
    public async Task TooManyRequests_IsRetryableByDefault() {
      var handler = new ScriptedHandler((HttpStatusCode)429, HttpStatusCode.OK);
      var client = NewClient(handler, NoBackoff(attempts: 3));

      ApiResponse response = await PostAsync(client);

      Assert.IsNotNull(response);
      Assert.AreEqual(2, handler.Calls);
    }

    [TestMethod]
    public async Task ExplicitStatusCodes_ReplaceTheDefaultSet() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
      var client = NewClient(handler, NoBackoff(attempts: 5, statusCodes: 429));

      await Assert.ThrowsExceptionAsync<ServerError>(() => PostAsync(client));

      Assert.AreEqual(1, handler.Calls);
    }

    [TestMethod]
    public async Task ExplicitStatusCodes_CanAddANonDefaultCode() {
      var handler = new ScriptedHandler(HttpStatusCode.BadRequest, HttpStatusCode.OK);
      var client = NewClient(handler, NoBackoff(attempts: 3, statusCodes: 400));

      ApiResponse response = await PostAsync(client);

      Assert.IsNotNull(response);
      Assert.AreEqual(2, handler.Calls);
    }

    [TestMethod]
    public async Task RequestRetryOptions_OverrideClientRetryOptions() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable);
      var client = NewClient(handler, NoBackoff(attempts: 5));

      await Assert.ThrowsExceptionAsync<ServerError>(
          () => PostAsync(client, new HttpOptions { RetryOptions = NoBackoff(attempts: 2) }));

      Assert.AreEqual(2, handler.Calls);
    }

    [TestMethod]
    public async Task RequestRetryOptions_ApplyWhenTheClientSetsNone() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable);
      var client = NewClient(handler);

      await Assert.ThrowsExceptionAsync<ServerError>(
          () => PostAsync(client, new HttpOptions { RetryOptions = NoBackoff(attempts: 3) }));

      Assert.AreEqual(3, handler.Calls);
    }

    [TestMethod]
    public async Task RetriedRequest_ResendsTheBody() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable, HttpStatusCode.OK);
      var client = NewClient(handler, NoBackoff(attempts: 3));

      await PostAsync(client);

      Assert.AreEqual(2, handler.Bodies.Count);
      // An HttpRequestMessage cannot be resent, so the retry must rebuild it.
      Assert.AreEqual(handler.Bodies[0], handler.Bodies[1]);
      StringAssert.Contains(handler.Bodies[0], "\"key\"");
    }

    [TestMethod]
    public async Task TransportFailure_IsRetried() {
      var handler = new ThrowingHandler();
      var client = NewClient(handler, NoBackoff(attempts: 3));

      await Assert.ThrowsExceptionAsync<HttpRequestException>(() => PostAsync(client));

      Assert.AreEqual(3, handler.Calls);
    }

    [TestMethod]
    public async Task CancellationDuringBackoff_StopsRetrying() {
      var handler = new ScriptedHandler(HttpStatusCode.ServiceUnavailable);
      var client = NewClient(handler, new HttpRetryOptions {
        Attempts = 5,
        InitialDelay = 30.0,
        MaxDelay = 30.0,
        Jitter = 0.0,
      });
      using var cts = new CancellationTokenSource();
      cts.CancelAfter(TimeSpan.FromMilliseconds(50));

      await Assert.ThrowsExceptionAsync<TaskCanceledException>(
          () => client.RequestAsync(HttpMethod.Post, "test-path", "{}", null, cts.Token));

      Assert.AreEqual(1, handler.Calls);
    }

    [TestMethod]
    public void ComputeRetryDelay_MatchesThePythonFormula() {
      // min(initialDelay * expBase^(attempt-1) + U(0, jitter), maxDelay)
      var deterministic = new HttpRetryOptions {
        InitialDelay = 0.5, ExpBase = 3.0, Jitter = 0.0, MaxDelay = 60.0,
      };
      Assert.AreEqual(0.5, ApiClient.ComputeRetryDelay(1, deterministic).TotalSeconds, 1e-9);
      Assert.AreEqual(1.5, ApiClient.ComputeRetryDelay(2, deterministic).TotalSeconds, 1e-9);
      Assert.AreEqual(4.5, ApiClient.ComputeRetryDelay(3, deterministic).TotalSeconds, 1e-9);

      var capped = new HttpRetryOptions { MaxDelay = 2.5 };
      Assert.AreEqual(2.5, ApiClient.ComputeRetryDelay(10, capped).TotalSeconds, 1e-9);

      var zeroed =
          new HttpRetryOptions { InitialDelay = 0.0, MaxDelay = 0.0, Jitter = 0.0 };
      Assert.AreEqual(0.0, ApiClient.ComputeRetryDelay(4, zeroed).TotalSeconds, 1e-9);

      var defaults = new HttpRetryOptions();
      for (int i = 0; i < 50; i++) {
        double first = ApiClient.ComputeRetryDelay(1, defaults).TotalSeconds;
        Assert.IsTrue(first >= 1.0 && first < 2.0, $"first retry delay out of range: {first}");
        double third = ApiClient.ComputeRetryDelay(3, defaults).TotalSeconds;
        Assert.IsTrue(third >= 4.0 && third < 5.0, $"third retry delay out of range: {third}");
      }
    }
  }
}
