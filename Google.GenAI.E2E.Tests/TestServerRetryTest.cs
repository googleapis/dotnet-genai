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
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.E2E.Tests {
  [TestClass]
  public class TestServerRetryTest {
    [TestMethod]
    public void CreateWithRetry_SucceedsOnFirstAttemptWithoutSleep() {
      var delays = new List<TimeSpan>();
      int attempts = 0;

      string result = TestServer.CreateWithRetry(
          () => {
            attempts++;
            return "ok";
          },
          binaryPath: null,
          logPath: "",
          sleep: delays.Add);

      Assert.AreEqual("ok", result);
      Assert.AreEqual(1, attempts);
      Assert.AreEqual(0, delays.Count);
    }

    [TestMethod]
    public void CreateWithRetry_RetriesTransientDownloadChainAndCleansPartialBinary() {
      string tempDir = Path.Combine(Path.GetTempPath(), $"test-server-retry-{Guid.NewGuid():N}");
      Directory.CreateDirectory(tempDir);
      string binaryPath = Path.Combine(tempDir, "test-server");
      string logPath = Path.Combine(tempDir, "test-server.log");
      try {
        var delays = new List<TimeSpan>();
        int attempts = 0;

        string result = TestServer.CreateWithRetry(
            () => {
              attempts++;
              if (attempts == 1) {
                File.WriteAllText(binaryPath, "partial-download");
                var socketEx = new SocketException((int)SocketError.ConnectionReset);
                var ioEx = new IOException("Unable to read data from the transport connection.", socketEx);
                var httpEx = new HttpRequestException("Response ended prematurely.", ioEx);
                throw new FileNotFoundException("installer failed", httpEx);
              }
              Assert.IsFalse(File.Exists(binaryPath), "Partial binary should be deleted before retry.");
              return "recovered";
            },
            binaryPath,
            logPath,
            sleep: delays.Add);

        Assert.AreEqual("recovered", result);
        Assert.AreEqual(2, attempts);
        CollectionAssert.AreEqual(new[] { TimeSpan.FromSeconds(2) }, delays);
        Assert.IsTrue(File.ReadAllText(logPath).Contains("SocketException"));
      } finally {
        Directory.Delete(tempDir, recursive: true);
      }
    }

    [TestMethod]
    public void CreateWithRetry_StopsAfterMaxAttemptsAndRethrowsLastException() {
      var delays = new List<TimeSpan>();
      int attempts = 0;

      Assert.ThrowsException<AggregateException>(() => TestServer.CreateWithRetry<string>(
          () => {
            attempts++;
            throw new AggregateException(new TaskCanceledException("request timed out"));
          },
          binaryPath: null,
          logPath: "",
          sleep: delays.Add));

      Assert.AreEqual(TestServer.MaxServerInitAttempts, attempts);
      CollectionAssert.AreEqual(
          new[] { TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(4) },
          delays);
    }

    [TestMethod]
    public void CreateWithRetry_DoesNotRetryNonTransientFailures() {
      var delays = new List<TimeSpan>();
      int attempts = 0;

      Assert.ThrowsException<FileNotFoundException>(() => TestServer.CreateWithRetry<string>(
          () => {
            attempts++;
            throw new FileNotFoundException("missing local binary");
          },
          binaryPath: null,
          logPath: "",
          sleep: delays.Add));

      Assert.AreEqual(1, attempts);
      Assert.AreEqual(0, delays.Count);
    }

    [TestMethod]
    public void CreateWithRetry_DoesNotRetryOrDeleteWhenBinaryExistedBeforeInit() {
      string tempDir = Path.Combine(Path.GetTempPath(), $"test-server-preexisting-{Guid.NewGuid():N}");
      Directory.CreateDirectory(tempDir);
      string binaryPath = Path.Combine(tempDir, "test-server");
      File.WriteAllText(binaryPath, "prebuilt-binary");
      try {
        var delays = new List<TimeSpan>();
        int attempts = 0;

        Assert.ThrowsException<IOException>(() => TestServer.CreateWithRetry<string>(
            () => {
              attempts++;
              throw new IOException("transient-looking IO error");
            },
            binaryPath,
            logPath: "",
            sleep: delays.Add));

        Assert.AreEqual(1, attempts);
        Assert.AreEqual(0, delays.Count);
        Assert.IsTrue(File.Exists(binaryPath), "Pre-existing binary must not be deleted.");
        Assert.AreEqual("prebuilt-binary", File.ReadAllText(binaryPath));
      } finally {
        Directory.Delete(tempDir, recursive: true);
      }
    }

    [TestMethod]
    public void CreateWithRetry_RejectsNonPositiveMaxAttempts() {
      Assert.ThrowsException<ArgumentOutOfRangeException>(() => TestServer.CreateWithRetry(
          () => "ok",
          binaryPath: null,
          logPath: "",
          sleep: _ => {},
          maxAttempts: 0));
    }

    [TestMethod]
    public void IsTransientInstallFailure_ClassifiesExceptionsAccurately() {
      Assert.IsTrue(TestServer.IsTransientInstallFailure(new HttpRequestException("transport error")));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(
          new HttpRequestException("timeout", null, HttpStatusCode.RequestTimeout)));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(
          new HttpRequestException("rate limited", null, HttpStatusCode.TooManyRequests)));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(
          new HttpRequestException("server error", null, HttpStatusCode.ServiceUnavailable)));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(
          new SocketException((int)SocketError.ConnectionReset)));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(new AuthenticationException("tls reset")));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(new TaskCanceledException("timeout")));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(new TimeoutException("timeout")));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(new EndOfStreamException("truncated")));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(new IOException("transport read failed")));
      Assert.IsTrue(TestServer.IsTransientInstallFailure(
          new AggregateException(new InvalidOperationException("noise"), new TimeoutException("timeout"))));

      Assert.IsFalse(TestServer.IsTransientInstallFailure(
          new HttpRequestException("not found", null, HttpStatusCode.NotFound)));
      Assert.IsFalse(TestServer.IsTransientInstallFailure(
          new HttpRequestException("forbidden", null, HttpStatusCode.Forbidden)));
      Assert.IsFalse(TestServer.IsTransientInstallFailure(new FileNotFoundException("missing")));
      Assert.IsFalse(TestServer.IsTransientInstallFailure(new DirectoryNotFoundException("missing dir")));
      Assert.IsFalse(TestServer.IsTransientInstallFailure(new InvalidOperationException("bad config")));
      Assert.IsFalse(TestServer.IsTransientInstallFailure(new AggregateException()));
    }
  }
}
