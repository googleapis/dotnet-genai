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

using System.IO;

using Google.Apis.Auth.OAuth2;
using TestServerSdk;

public class TestServer {
  public static bool IsReplayMode => (System.Environment.GetEnvironmentVariable("TEST_MODE") ?? "replay") == "replay";
  public static TestServerProcess StartTestServer() {
    var _project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string _apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
    var options = new TestServerOptions {
      ConfigPath = Path.GetFullPath("../test-server.yml"),
      RecordingDir = Path.GetFullPath("../../Recordings"),
      Mode = IsReplayMode ? "replay" : "record",
      BinaryPath = Path.GetFullPath("./test-server"),
      TestServerSecrets = $"{_project},{_apiKey}"
    };

    var server = new TestServerProcess(options);
    server.StartAsync().GetAwaiter().GetResult();

    return server;
  }

  // new comment
  public static void StopTestServer(TestServerProcess? server) {
    if (server != null) {
      server.StopAsync().GetAwaiter().GetResult();
    }
    server = null;
  }

  /// <summary>
  /// Returns a mock credential for replay mode, or null for record mode.
  /// In replay mode, returns a MockCredential that provides a fake access token without network calls.
  /// In record mode, returns null so the Client will use real credentials (ADC or GCE metadata).
  /// </summary>
  public static ICredential? GetCredentialForTestMode() {
    return IsReplayMode ? new MockCredential() : null;
  }
}
