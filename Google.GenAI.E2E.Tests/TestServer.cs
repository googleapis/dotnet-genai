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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.GenAI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestServerSdk;

public class TestServer {
  public static bool IsReplayMode => (System.Environment.GetEnvironmentVariable("TEST_MODE") ?? "replay") == "replay";

  /// <summary>
  /// Directory the test-server reads recordings from and writes them to.
  ///
  /// Defaults to the in-tree "Recordings" directory (resolved relative to the test binary), which is
  /// what replay mode needs. The nightly API-mode job overrides this with
  /// GOOGLE_GENAI_RECORDING_DIR so that a record-mode run against the live API writes its throwaway
  /// recordings to a scratch directory instead of overwriting the checked-in ones.
  /// </summary>
  public static string RecordingDirectory =>
      System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_RECORDING_DIR") is string dir
              && !string.IsNullOrEmpty(dir)
          ? Path.GetFullPath(dir)
          : Path.GetFullPath("../../Recordings");

  public static TestServerProcess StartTestServer() {
    // Checked-in Gemini API recordings were recorded against v1beta.
    if (IsReplayMode) {
      ApiClient.GoogleAiApiDefaultVersion = "v1beta";
    }
    var _project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT");
    string _apiKey = System.Environment.GetEnvironmentVariable("GEMINI_API_KEY");
    var logPath = Path.GetFullPath("../../../test-server.log");
    try {
      File.WriteAllText(logPath, $"=== Test Server Started Mode: {(IsReplayMode ? "replay" : "record")} ===\n");
    } catch {
      // Ignore log write failure if directory doesn't exist yet
    }

    var recordingDir = RecordingDirectory;
    Directory.CreateDirectory(recordingDir);

    // Only pass secrets that are actually set. The agent platform job has no API key,
    // and an empty entry in this comma-separated list risks the redactor treating the
    // empty string as a match-everything token.
    var secrets = string.Join(",", new[] { _project, _apiKey }.Where(s => !string.IsNullOrEmpty(s)));

    var options = new TestServerOptions {
      ConfigPath = Path.GetFullPath("../test-server.yml"),
      RecordingDir = recordingDir,
      Mode = IsReplayMode ? "replay" : "record",
      BinaryPath = Path.GetFullPath("./test-server"),
      TestServerSecrets = secrets,
      OnStdOut = (msg) => {
        try { File.AppendAllText(logPath, $"[STDOUT] {msg}\n"); } catch {}
      },
      OnStdErr = (msg) => {
        try { File.AppendAllText(logPath, $"[STDERR] {msg}\n"); } catch {}
      },
      OnError = (msg) => {
        try { File.AppendAllText(logPath, $"[ERROR] {msg}\n"); } catch {}
      }
    };

    var server = CreateWithRetry(
        () => new TestServerProcess(options), options.BinaryPath, logPath);
    server.StartAsync().GetAwaiter().GetResult();

    return server;
  }

  internal const int MaxServerInitAttempts = 3;

  internal static T CreateWithRetry<T>(
      Func<T> createServer,
      string? binaryPath,
      string logPath,
      Action<TimeSpan>? sleep = null,
      int maxAttempts = MaxServerInitAttempts) {
    if (maxAttempts < 1) {
      throw new ArgumentOutOfRangeException(nameof(maxAttempts));
    }
    var wait = sleep ?? Thread.Sleep;
    bool binaryExistedBeforeInit = !string.IsNullOrEmpty(binaryPath) && File.Exists(binaryPath);

    for (int attempt = 1;; attempt++) {
      try {
        return createServer();
      } catch (Exception ex) when (!binaryExistedBeforeInit
          && attempt < maxAttempts
          && IsTransientInstallFailure(ex)) {
        if (!string.IsNullOrEmpty(binaryPath) && File.Exists(binaryPath)) {
          try {
            File.Delete(binaryPath);
          } catch (Exception) {
            // Best-effort cleanup of a partially downloaded binary before retrying.
          }
        }
        var delay = TimeSpan.FromSeconds(2 * attempt);
        var rootCause = ex.GetBaseException();
        var msg = $"[RETRY {attempt}/{maxAttempts}] TestServerProcess initialization failed "
            + $"({rootCause.GetType().Name}: {rootCause.Message}); "
            + $"retrying in {delay.TotalSeconds}s...";
        Console.Error.WriteLine(msg);
        try {
          File.AppendAllText(logPath, msg + "\n");
        } catch (Exception) {
          // Ignore log write failure if directory doesn't exist yet.
        }
        wait(delay);
      }
    }
  }

  internal static bool IsTransientInstallFailure(Exception ex) {
    for (Exception? current = ex; current != null; current = current.InnerException) {
      if (current is AggregateException agg) {
        return agg.Flatten().InnerExceptions.Any(IsTransientInstallFailure);
      }
      if (current is HttpRequestException httpEx) {
        return httpEx.StatusCode is null
            || httpEx.StatusCode == HttpStatusCode.RequestTimeout
            || httpEx.StatusCode == HttpStatusCode.TooManyRequests
            || (int)httpEx.StatusCode.Value >= 500;
      }
      if (current is SocketException
          || current is AuthenticationException
          || current is TaskCanceledException
          || current is TimeoutException
          || current is EndOfStreamException
          || current.GetType() == typeof(IOException)) {
        return true;
      }
    }
    return false;
  }

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

[TestClass]
public class AssemblyInitializer {
  private static TestServerProcess? _server;

  [AssemblyInitialize]
  public static void AssemblyInit(TestContext context) {
    _server = TestServer.StartTestServer();
  }

  [AssemblyCleanup]
  public static void AssemblyCleanup() {
    TestServer.StopTestServer(_server);
  }
}
