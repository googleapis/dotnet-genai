using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.GenAI.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests;

[TestClass]
public class InteractionsClientTest
{
    private const string ACCESS_TOKEN = "test-access-token";

    private class UncallableCredentials : ICredential
    {
        void IConfigurableHttpClientInitializer.Initialize(ConfigurableHttpClient _client)
        {
        }

        Task<string> ITokenAccess.GetAccessTokenForRequestAsync(string authUri, CancellationToken _token)
        {
            Assert.Fail("GetCredential should not have been called");
            throw new Exception("GetCredential should not have been called");
        }
    }

    private class HardcodedCredentials : ICredential
    {
        void IConfigurableHttpClientInitializer.Initialize(ConfigurableHttpClient _client)
        {
        }

        Task<string> ITokenAccess.GetAccessTokenForRequestAsync(string? authUri, CancellationToken _token)
        {
            return Task.FromResult(ACCESS_TOKEN);
        }
    }

    [TestMethod]
    public void PrepareUrl_WithVertexInfo_TransformsPath()
    {
        var client = new GeminiNextGenApiClient();
        var url = ((GeminiNextGenApiClientWithRawResponse)client
                   .WithOptions((options) => options with { VertexInfo = new() { Location = "foo", Project = "bar" } })
                   .WithRawResponse)
            .PrepareUrl(new("https://example.com/v1/interactions/baz"));
        Assert.AreEqual(new("https://example.com/v1/projects/bar/locations/foo/interactions/baz"), url);
    }

    [TestMethod]
    public void PrepareUrl_WithNoVertexInfoOrApiKey_DoesNotModify()
    {
        var client = new GeminiNextGenApiClient();
        var url = ((GeminiNextGenApiClientWithRawResponse)client
                   .WithRawResponse)
            .PrepareUrl(new("https://example.com/v1/interactions/baz"));
        Assert.AreEqual(new("https://example.com/v1/interactions/baz"), url);
    }

    [TestMethod]
    public async Task PrepareRequestMessage_AddsAuthorizationHeader()
    {
        var message = new HttpRequestMessage();

        var client = new GeminiNextGenApiClient();
        await ((GeminiNextGenApiClientWithRawResponse)client
               .WithOptions((options) => options with { VertexInfo = new() { Location = "foo", Project = "bar", Credentials = new HardcodedCredentials() } })
               .WithRawResponse)
            .PrepareRequestMessage(message);

        CollectionAssert.AreEqual(new[] { $"Bearer {ACCESS_TOKEN}" }, message.Headers.GetValues("Authorization").ToArray());
    }

    [TestMethod]
    public async Task PrepareRequestMessage_WithApiKeyAndVertexInfo_UsesApiKey()
    {
        var message = new HttpRequestMessage();

        var client = new GeminiNextGenApiClient();
        await ((GeminiNextGenApiClientWithRawResponse)client
               .WithOptions((options) => options with { VertexInfo = new() { Location = "foo", Project = "bar", Credentials = new UncallableCredentials() }, ApiKey = "baz-bar-foo" })
               .WithRawResponse)
            .PrepareRequestMessage(message);

        CollectionAssert.AreEqual(new[] { "baz-bar-foo" }, message.Headers.GetValues("x-goog-api-key").ToArray());
    }

    [TestMethod]
    public async Task PrepareRequestMessage_WithoutVertexInfo_DoesNotModify()
    {
        var message = new HttpRequestMessage();
        message.Headers.Add("x-goog-api-key", "my-custom-api-key");

        var client = new GeminiNextGenApiClient();
        await ((GeminiNextGenApiClientWithRawResponse)client
               .WithRawResponse)
            .PrepareRequestMessage(message);

        Assert.IsFalse(message.Headers.Contains("Authorization"));
    }

    [TestMethod]
    public async Task PrepareRequestMessage_WithExistingAuthorizationHeader_DoesNotModify()
    {
        var message = new HttpRequestMessage();
        message.Headers.Add("Authorization", "Bearer my-custom-token");

        var client = new GeminiNextGenApiClient();
        await ((GeminiNextGenApiClientWithRawResponse)client
               .WithOptions((options) => options with { VertexInfo = new() { Location = "foo", Project = "bar", Credentials = new HardcodedCredentials() } })
               .WithRawResponse)
            .PrepareRequestMessage(message);

        CollectionAssert.AreEqual(new[] { "Bearer my-custom-token" }, message.Headers.GetValues("Authorization").ToArray());
    }

    public async Task PrepareRequestMessage_WithExistingApiKeyHeader_DoesNotModify()
    {
        var message = new HttpRequestMessage();

        var client = new GeminiNextGenApiClient();
        await ((GeminiNextGenApiClientWithRawResponse)client
               .WithOptions((options) => options with { VertexInfo = new() { Location = "foo", Project = "bar", Credentials = new UncallableCredentials() }, ApiKey = "baz-bar-foo" })
               .WithRawResponse)
            .PrepareRequestMessage(message);

        CollectionAssert.AreEqual(new[] { "my-custom-api-key" }, message.Headers.GetValues("x-goog-api-key").ToArray());
    }
}
