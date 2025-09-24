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

using Google.GenAI;
using Google.GenAI.Types;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading;
using System;

public class SessionWithQueue {
  private readonly Channel<LiveServerMessage> _messageQueue;
  private AsyncSession? _session;
  private Task? _receiveTask;
  private readonly CancellationTokenSource _receiveTaskCts;

  public Client Client { get; }
  public string Model { get; }
  public LiveConnectConfig? Config { get; }

  public SessionWithQueue(Client client, string model, LiveConnectConfig? config = null) {
    Client = client;
    Model = model;
    Config = config ?? new LiveConnectConfig();
    _messageQueue = Channel.CreateUnbounded<LiveServerMessage>();
    _receiveTaskCts = new CancellationTokenSource();
  }

  public async Task InitializeSessionAsync() {
    _session = await Client.Live.ConnectAsync(Model, Config);
    _receiveTask = Task.Run(async () => {
      Exception? completionException = null;
      try {
        while (!_receiveTaskCts.Token.IsCancellationRequested) {
          var message = await _session.ReceiveAsync(_receiveTaskCts.Token);
          if (message == null) {
            // Server closed the connection.
            break;
          }
          await _messageQueue.Writer.WriteAsync(message, _receiveTaskCts.Token);
        }
      } catch (OperationCanceledException) {
        // Expected when CloseAsync is called.
        completionException = null;
      } catch (Exception e) {
        completionException = e;
      } finally {
        _messageQueue.Writer.Complete(completionException);
      }
    });
  }

  public Task SendClientContentAsync(LiveSendClientContentParameters parameters) {
    if (_session == null)
      throw new InvalidOperationException("Session not initialized.");
    return _session.SendClientContentAsync(parameters);
  }

  public Task SendRealtimeInputAsync(LiveSendRealtimeInputParameters parameters) {
    if (_session == null)
      throw new InvalidOperationException("Session not initialized.");
    return _session.SendRealtimeInputAsync(parameters);
  }

  public Task SendToolResponseAsync(LiveSendToolResponseParameters parameters) {
    if (_session == null)
      throw new InvalidOperationException("Session not initialized.");
    return _session.SendToolResponseAsync(parameters);
  }

  public async Task CloseAsync() {
    if (_session == null)
      throw new InvalidOperationException("Session not initialized.");

    // 1. Signal the background reader task to stop.
    if (!_receiveTaskCts.IsCancellationRequested) {
      _receiveTaskCts.Cancel();
    }

    // 2. Wait for the reader task to complete.
    if (_receiveTask != null) {
      try {
        await _receiveTask;
      } catch (TaskCanceledException) {
        // This is expected and can be ignored.
      }
    }

    // 3. Now that the reader is no longer active, safely close the underlying session.
    await _session.CloseAsync();
    _receiveTaskCts.Dispose();
  }

  public async Task<LiveServerMessage> ReceiveAsync(CancellationToken cancellationToken = default) {
    return await _messageQueue.Reader.ReadAsync(cancellationToken);
  }
}