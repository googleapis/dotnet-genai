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

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
Console.WriteLine(isVertex ? "Running in Vertex AI mode." : "Running in Gemini API mode.");

Client client = new Client(vertexAI: isVertex);

if (isVertex)
{
    Console.WriteLine("Interactions API is not yet supported on Vertex AI");
    return;
}

List<Step> conversationHistory = new List<Step>();
conversationHistory.Add(Step.CreateUserInput(new UserInputStep
{
    Content = new List<Content> { Content.CreateText(new TextContent { Text = "What are the three largest cities in Spain?" }) }
}));

Console.WriteLine("User: What are the three largest cities in Spain?");

CreateModelInteraction params1 = new()
{
    Input = InteractionsInput.CreateArrayOfStep(conversationHistory),
    Model = Model.Gemini25Flash,
    Store = false
};

var response_response1 = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(params1));
var response1 = response_response1.Interaction;

Console.WriteLine("Model: ");
Console.WriteLine(response1?.OutputText);

// Add model response to history
if (response1?.Steps != null)
{
    conversationHistory.AddRange(response1.Steps);
}

// Add next user message
conversationHistory.Add(Step.CreateUserInput(new UserInputStep
{
    Content = new List<Content> { Content.CreateText(new TextContent { Text = "What is the most famous landmark in the second one?" }) }
}));

Console.WriteLine("\nUser: What is the most famous landmark in the second one?");

CreateModelInteraction params2 = new()
{
    Input = InteractionsInput.CreateArrayOfStep(conversationHistory),
    Model = Model.Gemini25Flash,
    Store = false
};

var response_response2 = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(params2));
var response2 = response_response2.Interaction;

Console.WriteLine("Model: ");
Console.WriteLine(response2?.OutputText);
