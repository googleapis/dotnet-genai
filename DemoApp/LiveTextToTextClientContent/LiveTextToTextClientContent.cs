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

using Types = Google.GenAI.Types;

public static class LiveTextToTextClientContent {
  private static Task? textInputTask;
  private static Task? responseProcessingTask;

  private static AsyncSession? session;

  private static CancellationTokenSource? textCaptureCts;

  public static async Task RunConversation(string systemInstructionString, bool vertexAI = false) {
    Types.LiveConnectConfig config = new Types.LiveConnectConfig {
      ResponseModalities = new List<Types.Modality> { Types.Modality.TEXT },
      SystemInstruction =
          new Types.Content {
            Parts = new List<Types.Part> { new Types.Part { Text = systemInstructionString } },
            Role = "user"
          },
    };
    string model;
    Client client;
    if (vertexAI) {
      string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT") ?? string.Empty;
      if (string.IsNullOrEmpty(project))
        throw new InvalidOperationException(
            "Project ID is not set in the environment variable GOOGLE_CLOUD_PROJECT.");
      string location =
          System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";

      client = new Client(project: project, location: location, vertexAI: true);
      model = "gemini-2.0-flash-live-preview-04-09";
    } else {
      string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
      if (string.IsNullOrEmpty(apiKey))
        throw new InvalidOperationException(
            "API key is not set in the environment variable GOOGLE_API_KEY.");
      client = new Client(apiKey: apiKey, vertexAI: false);
      model = "gemini-2.0-flash-live-001";
    }
    textCaptureCts = new CancellationTokenSource();

    try {
      session = await client.Live.ConnectAsync(model, config);
      Console.WriteLine("Live session connected.");
      textInputTask = Task.Run(() => StreamInputTextFromQueueAsync(session, textCaptureCts.Token));
      responseProcessingTask = Task.Run(() => ProcessResponseAsync(session, textCaptureCts.Token));

      await Task.Delay(Timeout.Infinite, textCaptureCts.Token);
    } catch (OperationCanceledException) {
      Console.WriteLine("Operation cancelled.");
    } catch (Exception ex) {
      Console.WriteLine($"An error occurred: {ex}");
    } finally {
      Console.WriteLine("Shutting down...");
      if (textCaptureCts != null && !textCaptureCts.IsCancellationRequested)
        textCaptureCts.Cancel();
      textCaptureCts?.Dispose();
      Console.WriteLine("Shutdown complete.");
      if (session != null) {
        await session.CloseAsync();
        Console.WriteLine("Live API session closed.");
      }
    }
  }

  private static async Task StreamInputTextFromQueueAsync(AsyncSession session,
                                                          CancellationToken cancellationToken) {
    Console.WriteLine("Type your message and press Enter to send. Press Ctrl+C to exit.");
    while (!cancellationToken.IsCancellationRequested) {
      string? input = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(input))
        continue;

      var clientContent = new Types.LiveSendClientContentParameters {
        Turns = new List<Types.Content> { new Types.Content {
          Role = "user", Parts = new List<Types.Part> { new Types.Part { Text = input } }
        } },
        TurnComplete = true,
      };
      await session.SendClientContentAsync(clientContent);
    }
  }
  private static async Task ProcessResponseAsync(AsyncSession activeSession,
                                                 CancellationToken cancellationToken) {
    try {
      while (!cancellationToken.IsCancellationRequested) {
        var serverMessage = await activeSession.ReceiveAsync();

        if (cancellationToken.IsCancellationRequested)
          break;

        if (serverMessage?.ServerContent?.ModelTurn?.Parts != null) {
          foreach (var part in serverMessage.ServerContent.ModelTurn.Parts) {
            if (part.Text != null) {
              Console.WriteLine("model: " + part.Text);
            }
          }
        } else if (serverMessage?.ServerContent?.TurnComplete == true) {
          Console.WriteLine("[Server turn completed, your turn to type input]");
        }
      }
    } catch (OperationCanceledException) {
      Console.WriteLine("Response processing task cancelled.");
    } catch (Exception ex) {
      Console.WriteLine($"Error processing responses: {ex}");
    } finally {
      Console.WriteLine("Response processing task finished.");
    }
  }
}
