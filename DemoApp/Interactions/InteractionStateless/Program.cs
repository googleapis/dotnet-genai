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
using Google.GenAI.Interactions.Models.Interactions;

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
Console.WriteLine(isVertex ? "Running in Vertex AI mode." : "Running in Gemini API mode.");

Client client = new Client(vertexAI: isVertex);

if (isVertex)
{
    Console.WriteLine("Interactions API is not yet supported on Vertex AI");
    return;
}

List<Turn> conversationHistory = new List<Turn>();
conversationHistory.Add(new Turn()
{
    Content = "What are the three largest cities in Spain?",
    Role = "user"
});

Console.WriteLine("User: What are the three largest cities in Spain?");

CreateModelInteractionParams params1 = new()
{
    Input = conversationHistory,
    Model = Model.Gemini2_5Flash,
    Store = false
};

Interaction response1 = await client.Interactions.Create(new() { Body = params1 });

Console.WriteLine("Model: ");
foreach (var output in response1?.Outputs ?? [])
{
    if (output.TryPickText(out var text))
    {
        Console.WriteLine(text.Text);
    }
}

// Add model response to history
if (response1?.Outputs != null)
{
    conversationHistory.Add(new Turn()
    {
        Content = new TurnContent(response1.Outputs),
        Role = "model"
    });
}

// Add next user message
conversationHistory.Add(new Turn()
{
    Content = "What is the most famous landmark in the second one?",
    Role = "user"
});

Console.WriteLine("\nUser: What is the most famous landmark in the second one?");

CreateModelInteractionParams params2 = new()
{
    Input = conversationHistory,
    Model = Model.Gemini2_5Flash,
    Store = false
};

Interaction response2 = await client.Interactions.Create(new() { Body = params2 });

Console.WriteLine("Model: ");
foreach (var output in response2?.Outputs ?? [])
{
    if (output.TryPickText(out var text))
    {
        Console.WriteLine(text.Text);
    }
}
