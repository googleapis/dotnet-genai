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

// Native AOT smoke test, run by verify_aot.sh: it serves canned responses from a local HTTP
// listener, exercises the client through API key and OAuth credentials, and exits non-zero if any
// check fails.

using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.Extensions.AI;


const string AccessToken = "access-token-from-token-endpoint";
const string CannedResponse = """
    {"candidates":[{"content":{"role":"model","parts":[{"text":"hello"},
    {"functionCall":{"name":"get_weather","args":{"city":"Paris"}}}]},"finishReason":"STOP"}],
    "usageMetadata":{"promptTokenCount":1,"candidatesTokenCount":2,"totalTokenCount":3}}
    """;

var tcp = new TcpListener(IPAddress.Loopback, 0);
tcp.Start();
int port = ((IPEndPoint)tcp.LocalEndpoint).Port;
tcp.Stop();
string baseUrl = $"http://127.0.0.1:{port}";
string tokenUrl = baseUrl + "/token";

var requests = new List<(string Path, string Authorization, string Body)>();
var listener = new HttpListener();
listener.Prefixes.Add(baseUrl + "/");
listener.Start();
_ = Task.Run(async () =>
{
  while (listener.IsListening)
  {
    HttpListenerContext context;
    try
    {
      context = await listener.GetContextAsync();
    }
    catch (Exception) when (!listener.IsListening)
    {
      return;
    }
    // Keep serving if a single request fails, so later checks fail fast instead of hanging.
    try
    {
      string body = await new StreamReader(context.Request.InputStream).ReadToEndAsync();
      string path = context.Request.Url!.AbsolutePath;
      string authorization = context.Request.Headers["Authorization"] ?? context.Request.Headers["x-goog-api-key"] ?? "";
      lock (requests)
      {
        requests.Add((path, authorization, body));
      }
      string response = path switch
      {
        "/token" => $$"""{"access_token":"{{AccessToken}}","expires_in":3600,"token_type":"Bearer"}""",
        _ when path.Contains(":streamGenerateContent") => "data: " + CannedResponse.ReplaceLineEndings("") + "\n\n",
        _ when path.Contains(":generateContent") => CannedResponse,
        _ => "{}",
      };
      context.Response.ContentType = path.Contains(":streamGenerateContent") ? "text/event-stream" : "application/json";
      await context.Response.OutputStream.WriteAsync(Encoding.UTF8.GetBytes(response));
      context.Response.Close();
    }
    catch (Exception e)
    {
      Console.Error.WriteLine($"Local server failed to handle a request: {e}");
      context.Response.Abort();
    }
  }
});

string privateKeyPem = PemEncoding.Write("PRIVATE KEY", RSA.Create(2048).ExportPkcs8PrivateKey()).AsSpan().ToString();
const string ServiceAccountEmail = "test@example.iam.gserviceaccount.com";
const string CloudPlatformScope = "https://www.googleapis.com/auth/cloud-platform";

// Bound every request so a broken code path fails its check instead of hanging the run.
var httpOptions = new HttpOptions { BaseUrl = baseUrl, Timeout = 30_000 };
var userContents = new List<Content> { new() { Role = "user", Parts = new() { new() { Text = "hi" } } } };
int failures = 0;

// Set enterprise explicitly so GOOGLE_GENAI_USE_VERTEXAI/GOOGLE_GENAI_USE_ENTERPRISE in the environment have no effect.
Client ApiKeyClient() => new(enterprise: false, apiKey: "test-api-key", httpOptions: httpOptions);
Client EnterpriseClient(ICredential? credential = null) =>
    new(enterprise: true, project: "test-project", location: "us-central1", credential: credential, httpOptions: httpOptions);

List<(string Path, string Authorization, string Body)> TakeRequests()
{
  lock (requests)
  {
    var taken = requests.ToList();
    requests.Clear();
    return taken;
  }
}

void Require(bool condition, string message)
{
  if (!condition)
  {
    throw new InvalidOperationException(message);
  }
}

void RequireGeneratedContent(GenerateContentResponse response)
{
  Require(response.Text == "hello", $"unexpected text '{response.Text}'");
  var functionCall = response.Candidates?[0].Content?.Parts?.FirstOrDefault(p => p.FunctionCall != null)?.FunctionCall;
  Require(functionCall?.Args?["city"]?.ToString() == "Paris", "function call arguments were not deserialized");
}

void RequireBearer(List<(string Path, string Authorization, string Body)> taken, string token)
{
  var call = taken.LastOrDefault(r => r.Path.Contains(":generateContent"));
  Require(call.Authorization == "Bearer " + token, $"unexpected Authorization header '{call.Authorization}'");
}

JsonObject DecodeJwtSegment(string segment)
{
  string base64 = segment.Replace('-', '+').Replace('_', '/');
  base64 = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
  return JsonNode.Parse(Convert.FromBase64String(base64))!.AsObject();
}

void RequireSignedJwt(string jwt)
{
  string[] segments = jwt.Split('.');
  Require(segments.Length == 3, "token is not a JWT");
  Require(DecodeJwtSegment(segments[0])["alg"]?.GetValue<string>() == "RS256", "JWT header is missing 'alg'");
  Require(DecodeJwtSegment(segments[1])["iss"]?.GetValue<string>() == ServiceAccountEmail, "JWT payload is missing 'iss'");
}

async Task Check(string name, Func<Task> check)
{
  TakeRequests();
  try
  {
    await check();
    Console.WriteLine($"PASS {name}");
  }
  catch (Exception e)
  {
    failures++;
    Console.WriteLine($"FAIL {name}: {e}");
  }
}

await Check("API key: generate content", async () =>
{
  RequireGeneratedContent(await ApiKeyClient().Models.GenerateContentAsync("test-model", "hi"));
});

await Check("API key: generate content stream", async () =>
{
  int chunks = 0;
  await foreach (var chunk in ApiKeyClient().Models.GenerateContentStreamAsync("test-model", userContents))
  {
    RequireGeneratedContent(chunk);
    chunks++;
  }
  Require(chunks == 1, $"expected 1 chunk, got {chunks}");
});

await Check("API key: function response with object values", async () =>
{
  var contents = new List<Content>(userContents)
  {
    new()
    {
      Role = "user",
      Parts = new()
      {
        new()
        {
          FunctionResponse = new FunctionResponse
          {
            Name = "get_weather",
            Response = new Dictionary<string, object>
            {
              ["text"] = "sunny",
              ["temperature"] = 21,
              ["humidity"] = 0.5,
              ["windy"] = false,
              ["forecast"] = new List<object> { "rain", 3 },
              ["details"] = new Dictionary<string, object> { ["uv"] = 4 },
              ["raw"] = JsonDocument.Parse("""{"source":"station"}""").RootElement,
            },
          },
        },
      },
    },
  };
  await ApiKeyClient().Models.GenerateContentAsync("test-model", contents);
  string body = TakeRequests().Single().Body;
  const string expected = """
      "response":{"text":"sunny","temperature":21,"humidity":0.5,"windy":false,"forecast":["rain",3],"details":{"uv":4},"raw":{"source":"station"}}
      """;
  Require(body.Contains(expected), $"unexpected request body {body}");
});

await Check("API key: IChatClient with function declaration", async () =>
{
  IChatClient chatClient = ApiKeyClient().AsIChatClient("test-model");
  var declaration = AIFunctionFactory.CreateDeclaration(
      "get_weather", "Gets the weather", JsonDocument.Parse("""{"type":"object","properties":{"city":{"type":"string"}}}""").RootElement);
  var response = await chatClient.GetResponseAsync("hi", new ChatOptions { Tools = new List<AITool> { declaration } });
  var functionCall = response.Messages.SelectMany(m => m.Contents).OfType<FunctionCallContent>().Single();
  Require(functionCall.Name == "get_weather", $"unexpected function call '{functionCall.Name}'");
  Require(TakeRequests().Single().Body.Contains("\"parametersJsonSchema\":{\"type\":\"object\""), "function declaration was not serialized");
});

await Check("Content.FromJson with caller options without a resolver", () =>
{
  var content = Content.FromJson("{\"parts\":[{\"text\":\"hello\"}]}", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
  Require(content?.Parts?[0].Text == "hello", "content was not deserialized");
  return Task.CompletedTask;
});

await Check("Content.FromJson with read-only caller options", () =>
{
  var options = new JsonSerializerOptions
  {
    PropertyNameCaseInsensitive = true,
    TypeInfoResolver = System.Text.Json.Serialization.Metadata.JsonTypeInfoResolver.Combine(),
  };
  options.MakeReadOnly();
  var content = Content.FromJson("{\"parts\":[{\"text\":\"hello\"}]}", options);
  Require(content?.Parts?[0].Text == "hello", "content was not deserialized");
  return Task.CompletedTask;
});

await Check("OAuth: application default credentials from a service account key file", async () =>
{
  string keyFile = Path.Combine(Path.GetTempPath(), $"genai-aot-{Guid.NewGuid():N}.json");
  System.IO.File.WriteAllText(keyFile, new JsonObject
  {
    ["type"] = "service_account",
    ["project_id"] = "test-project",
    ["private_key_id"] = "test-key-id",
    ["private_key"] = privateKeyPem,
    ["client_email"] = ServiceAccountEmail,
    ["client_id"] = "1",
    ["token_uri"] = tokenUrl,
  }.ToJsonString());
  string? previousCredentials = System.Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
  System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", keyFile);
  try
  {
    RequireGeneratedContent(await EnterpriseClient().Models.GenerateContentAsync("test-model", "hi"));
  }
  finally
  {
    System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", previousCredentials);
    System.IO.File.Delete(keyFile);
  }
  var taken = TakeRequests();
  var form = taken.Single(r => r.Path == "/token").Body.Split('&').Select(p => p.Split('=', 2)).ToDictionary(p => p[0], p => Uri.UnescapeDataString(p[1]));
  Require(form.GetValueOrDefault("grant_type") == "urn:ietf:params:oauth:grant-type:jwt-bearer", "token request is missing grant_type");
  RequireSignedJwt(form.GetValueOrDefault("assertion") ?? "");
  RequireBearer(taken, AccessToken);
});

await Check("OAuth: service account self-signed JWT", async () =>
{
  var serviceAccount = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(ServiceAccountEmail, tokenUrl)
  {
    Scopes = new[] { CloudPlatformScope },
    UseJwtAccessWithScopes = true,
  }.FromPrivateKey(privateKeyPem));
  RequireGeneratedContent(await EnterpriseClient(serviceAccount).Models.GenerateContentAsync("test-model", "hi"));
  var call = TakeRequests().Single(r => r.Path.Contains(":generateContent"));
  RequireSignedJwt(call.Authorization["Bearer ".Length..]);
});

await Check("OAuth: user credential refresh", async () =>
{
  var flow = new AuthorizationCodeFlow(new AuthorizationCodeFlow.Initializer(baseUrl + "/auth", tokenUrl)
  {
    ClientSecrets = new ClientSecrets { ClientId = "test-client-id", ClientSecret = "test-client-secret" },
  });
  var credential = new UserCredential(flow, "user", new TokenResponse { RefreshToken = "test-refresh-token" });
  RequireGeneratedContent(await EnterpriseClient(credential).Models.GenerateContentAsync("test-model", "hi"));
  var taken = TakeRequests();
  string tokenRequest = taken.Single(r => r.Path == "/token").Body;
  Require(tokenRequest.Contains("grant_type=refresh_token") && tokenRequest.Contains("refresh_token=test-refresh-token"),
      $"unexpected token request {tokenRequest}");
  RequireBearer(taken, AccessToken);
});

await Check("OAuth: access token", async () =>
{
  RequireGeneratedContent(await EnterpriseClient(GoogleCredential.FromAccessToken("static-access-token")).Models.GenerateContentAsync("test-model", "hi"));
  RequireBearer(TakeRequests(), "static-access-token");
});

listener.Stop();
Console.WriteLine(failures == 0 ? "All checks passed." : $"{failures} check(s) failed.");
return failures == 0 ? 0 : 1;
