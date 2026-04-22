// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.GenAI.Interactions;
using Google.GenAI.Interactions.Core;
using Moq;
using Moq.Protected;

namespace Google.GenAI.Interactions.Tests;

public class RetriesTest : TestBase
{
    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    record class ParamsWithOverwrittenRetryHeader : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions _options
        )
        {
            request.Headers.TryAddWithoutValidation("x-stainless-retry-count", "42");
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    [Fact]
    public async Task ImmediateSuccess_Works()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        GeminiNextGenApiClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryAfterHeader_Works()
    {
        var ResponseWithRetryDate = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        ResponseWithRetryDate.Headers.Add("Retry-After", "Wed, 21 Oct 2015 07:28:00 GMT");

        var ResponseWithRetryDelay = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        // decimals are technically out of spec, but we want to ensure we can parse them regardless
        ResponseWithRetryDelay.Headers.TryAddWithoutValidation("Retry-After", "1.234");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(ResponseWithRetryDate)
            .ReturnsAsync(ResponseWithRetryDelay)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        GeminiNextGenApiClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(3),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task OverwrittenRetryCountHeader_Works()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Content = new StringContent("foo"),
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        GeminiNextGenApiClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<ParamsWithOverwrittenRetryHeader>
            {
                Method = HttpMethod.Get,
                Params = new(),
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                        && Enumerable.Single(req.Headers.GetValues("x-stainless-retry-count"))
                            == "42"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryAfterMsHeader_Works()
    {
        var failResponse = new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.ServiceUnavailable,
            Content = new StringContent("foo"),
        };
        failResponse.Headers.TryAddWithoutValidation("Retry-After-Ms", "10");

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(failResponse)
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("foo"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        GeminiNextGenApiClient client = new() { HttpClient = httpClient, MaxRetries = 1 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }

    [Fact]
    public async Task RetryableException_Works()
    {
        var callCount = 0;

        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns<HttpRequestMessage, CancellationToken>(
                (_, ct) =>
                {
                    callCount++;
                    if (callCount == 1)
                        throw new HttpRequestException("Simulated retryable failure");

                    return Task.FromResult(
                        new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK,
                            Content = new StringContent("foo"),
                        }
                    );
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        GeminiNextGenApiClient client = new() { HttpClient = httpClient, MaxRetries = 2 };

        var resp = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        handlerMock
            .Protected()
            .Verify(
                "SendAsync",
                Times.Exactly(2),
                ItExpr.Is<HttpRequestMessage>(
                    (req) =>
                        req.Method == HttpMethod.Get
                        && req.RequestUri == new Uri("http://localhost/something")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
    }
}
