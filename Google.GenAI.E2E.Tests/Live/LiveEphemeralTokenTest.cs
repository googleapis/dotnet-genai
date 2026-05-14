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
using System.Threading.Tasks;

using Google.GenAI;
using GoogleType = Google.GenAI.Types;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestServerSdk;

[TestClass]
public class LiveEphemeralTokenTest {
  private static TestServerProcess? _server;
  private Client geminiClient;
  private string geminiModelName;
  public TestContext TestContext { get; set; }

  [ClassInitialize]
  public static void ClassInit(TestContext _) {
    _server = TestServer.StartTestServer();
  }

  [ClassCleanup]
  public static void ClassCleanup() {
    TestServer.StopTestServer(_server);
  }

  [TestInitialize]
  public void TestInit() {
    if (_server == null) {
      throw new InvalidOperationException("Test server is not initialized.");
    }
    var geminiClientHttpOptions = new GoogleType.HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1453", ApiVersion = "v1alpha"
    };

    string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");

    geminiClient =
        new Client(apiKey: apiKey, vertexAI: false, httpOptions: geminiClientHttpOptions);

    geminiModelName = "gemini-live-2.5-flash-preview";
  }

  [TestMethod]
  public async Task LiveEphemeralTokenGeminiTest() {
    var tokenConfig = new GoogleType.CreateAuthTokenConfig {
      LockAdditionalFields = new List<string>(),
      LiveConnectConstraints = new GoogleType.LiveConnectConstraints { Model = geminiModelName }
    };

    var tokenResponse = await geminiClient.Tokens.CreateAsync(tokenConfig);
    Assert.IsNotNull(tokenResponse);
    Assert.IsNotNull(tokenResponse.Name);
    Assert.IsTrue(tokenResponse.Name.StartsWith("auth_tokens/"));

    // Create a new client using the token
    var geminiClientHttpOptions = new GoogleType.HttpOptions {
      Headers = new Dictionary<string, string> { { "Test-Name",
                                                   $"{GetType().Name}.{TestContext.TestName}" } },
      BaseUrl = "http://localhost:1453", ApiVersion = "v1alpha"
    };

    var tokenClient = new Client(apiKey: tokenResponse.Name, vertexAI: false,
                                 httpOptions: geminiClientHttpOptions);

    // Verify we can connect with this client
    var session = new SessionWithQueue(tokenClient, geminiModelName);
    await session.InitializeSessionAsync();

    // Send a simple message to verify connection works
    await session.SendClientContentAsync(new GoogleType.LiveSendClientContentParameters {
      Turns = new List<GoogleType.Content> { new GoogleType.Content {
        Role = "user", Parts = new List<GoogleType.Part> { new GoogleType.Part { Text = "Hello" } }
      } }
    });

    // Close session
    await session.CloseAsync();
  }
}
