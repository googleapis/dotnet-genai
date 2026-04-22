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

using Google.GenAI;
using Google.GenAI.Gaos.Models.Interactions;
using Google.GenAI.Gaos.Models.Requests;

namespace InteractionDeepResearch;

class Program
{
    static async Task Main(string[] args)
    {
        string? vertexAIEnv = System.Environment.GetEnvironmentVariable("GOOGLE_GENAI_USE_VERTEXAI");
        bool isVertexAI = vertexAIEnv != null && vertexAIEnv.ToLower() == "true";

        if (!isVertexAI)
        {
            Console.Error.WriteLine("Deep Research is only supported on Vertex AI. Please set GOOGLE_GENAI_USE_VERTEXAI=true.");
            return;
        }

        Client client = new Client(vertexAI: true);

        Console.WriteLine("--- Starting Deep Research Interaction ---");

        CreateAgentInteraction agentParams = new()
        {
            Agent = "deep-research-pro-preview-12-2025",
            Input = InteractionsInput.CreateStr("I want to learn more about the history of Hadrian's Wall"),
            Background = true,
            Stream = true
        };

        string? interactionId = null;

        Console.WriteLine("--- Sending Create Request ---");

        var response = await client.Interactions.CreateAsync(
            CreateInteractionRequestBody.CreateCreateAgentInteraction(agentParams),
            apiVersion: "v1beta1"
        );

        var stream = response.InteractionSSEStreamEvent;
        if (stream != null)
        {
            while (true)
            {
                var sseEvent = await stream.Next();
                if (sseEvent == null) break;

                var createdEvent = sseEvent.GetDataInteractionCreated();
                if (createdEvent != null)
                {
                    interactionId = createdEvent.Interaction.Id;
                    Console.WriteLine($"Started Interaction ID: {interactionId}");
                }

                var statusUpdate = sseEvent.GetDataInteractionStatusUpdate();
                if (statusUpdate != null)
                {
                    Console.WriteLine($"Event: StatusUpdate - {statusUpdate.Status}");
                }

                var stepDelta = sseEvent.GetDataStepDelta();
                if (stepDelta != null)
                {
                    var textDelta = stepDelta.GetDeltaText();
                    if (textDelta != null)
                    {
                        Console.Write(textDelta.Text);
                    }
                    else
                    {
                        Console.WriteLine("\n[Agent Activity]");
                    }
                }

                var completedEvent = sseEvent.GetDataInteractionCompleted();
                if (completedEvent != null)
                {
                    Console.WriteLine("\nEvent: Complete");
                    break;
                }

                if (interactionId != null)
                {
                    break;
                }
            }
        }

        if (interactionId == null)
        {
            Console.Error.WriteLine("Failed to capture interaction ID.");
            return;
        }

        Console.WriteLine($"\n--- Resuming Interaction: {interactionId} ---");

        // Resume the stream
        var getResponse = await client.Interactions.GetAsync(new GetInteractionByIdRequest
        {
            Id = interactionId,
            Stream = true,
            ApiVersion = "v1beta1"
        });

        var getStream = getResponse.InteractionSSEStreamEvent;
        if (getStream != null)
        {
            while (true)
            {
                var sseEvent = await getStream.Next();
                if (sseEvent == null) break;

                var statusUpdate = sseEvent.GetDataInteractionStatusUpdate();
                if (statusUpdate != null)
                {
                    Console.WriteLine($"\n[Status update: {statusUpdate.Status}]");
                }

                var stepDelta = sseEvent.GetDataStepDelta();
                if (stepDelta != null)
                {
                    var textDelta = stepDelta.GetDeltaText();
                    if (textDelta != null)
                    {
                        Console.Write(textDelta.Text);
                    }
                    else
                    {
                        Console.WriteLine("\n[Agent Activity]");
                    }
                }
            }
        }

        Console.WriteLine();
    }
}
