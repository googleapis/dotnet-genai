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

using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Google.GenAI;
using Google.GenAI.Types;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWebSockets();
app.UseDefaultFiles();
app.UseStaticFiles();

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
string model;
string mimeType;
Client client;

if (isVertex) {
  Console.WriteLine("Running in Vertex AI mode.");
  string project = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT") ??
                   throw new ArgumentNullException("GOOGLE_CLOUD_PROJECT not set for Vertex AI.");
  string location = System.Environment.GetEnvironmentVariable("GOOGLE_CLOUD_LOCATION") ?? "us-central1";
  client = new Client(project: project, location: location, vertexAI: true);
  model = "gemini-2.0-flash-live-preview-04-09";
  mimeType = "audio/l16;rate=24000";
} else {
  Console.WriteLine("Running in Gemini API mode.");
  string apiKey = System.Environment.GetEnvironmentVariable("GOOGLE_API_KEY") ??
                  throw new ArgumentNullException("GOOGLE_API_KEY not set for Gemini API.");
  client = new Client(apiKey: apiKey);
  model = "gemini-2.0-flash-live-001";
  mimeType = "audio/pcm";
}

app.Map("/ws", async (HttpContext context) => {
  if (!context.WebSockets.IsWebSocketRequest) {
    context.Response.StatusCode = 400;
    return;
  }

  using var localServerWs = await context.WebSockets.AcceptWebSocketAsync();
  var config = new LiveConnectConfig { ResponseModalities = new List<Modality> { Modality.AUDIO },
                                       SpeechConfig = new SpeechConfig { LanguageCode = "en-US" } };

  var geminiLiveSession = await client.Live.ConnectAsync(model, config);
  var cts = new CancellationTokenSource();

  Console.CancelKeyPress += (sender, e) => {
    e.Cancel = true;
    cts.Cancel();
  };

  // Task: Stream messages from browser to Gemini
  var sendTask = Task.Run(async () => {
    var buffer = new byte[8192];
    while (localServerWs.State == WebSocketState.Open && !cts.Token.IsCancellationRequested) {
      var result = await localServerWs.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

      if (result.MessageType == WebSocketMessageType.Text) {
        var jsonMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
        try {
          var clientMsg = JsonSerializer.Deserialize<ClientMessage>(jsonMessage);
          LiveSendRealtimeInputParameters? realtimeInput = null;

          if (clientMsg?.Media?.Data != null) {
            var mediaDataBytes = Convert.FromBase64String(clientMsg.Media.Data);
            realtimeInput =
                new LiveSendRealtimeInputParameters { Media = new Blob { Data = mediaDataBytes,
                                                                         MimeType = mimeType } };
          } else if (clientMsg?.ClientContent?.TurnComplete == true) {
            realtimeInput =
                new LiveSendRealtimeInputParameters { ActivityEnd = new ActivityEnd {} };
          }

          if (realtimeInput != null) {
            await geminiLiveSession.SendRealtimeInputAsync(realtimeInput);
          }
        } catch (Exception ex) {
          Console.WriteLine($"Error processing client message: {ex.Message}");
        }
      } else if (result.MessageType == WebSocketMessageType.Close) {
        cts.Cancel();
        break;
      }
    }
  }, cts.Token);

  // Task: Stream Gemini responses to browser
  var receiveTask = Task.Run(async () => {
    while (!cts.Token.IsCancellationRequested) {
      var serverMsg = await geminiLiveSession.ReceiveAsync();
      if (serverMsg != null) {
        var jsonResponse = JsonSerializer.Serialize(serverMsg);
        var responseBytes = Encoding.UTF8.GetBytes(jsonResponse);
        await localServerWs.SendAsync(new ArraySegment<byte>(responseBytes),
                                      WebSocketMessageType.Text, true, cts.Token);
      }
    }
  }, cts.Token);

  try {
    await Task.WhenAny(sendTask, receiveTask);
  } catch (OperationCanceledException) {
    // do nothing, expected when the connection closes.
  } finally {
    if (!cts.IsCancellationRequested) {
      cts.Cancel();
    }
    Console.WriteLine("Closing Gemini session...");
    await geminiLiveSession.CloseAsync();
    Console.WriteLine("Gemini session closed.");

    if (localServerWs.State == WebSocketState.Open) {
      await localServerWs.CloseAsync(WebSocketCloseStatus.NormalClosure, "Session ended",
                                     CancellationToken.None);
    }
  }
});

app.Run();

// DTOs for robust deserialization of client messages
public class ClientMessage {
  [JsonPropertyName("media")]
  public ClientMedia? Media { get; set; }

  [JsonPropertyName("clientContent")]
  public LiveClientContent? ClientContent { get; set; }
}

public class ClientMedia {
  [JsonPropertyName("data")]
  public string Data { get; set; }  // Base64 audio data

  [JsonPropertyName("mimeType")]
  public string MimeType { get; set; }
}
