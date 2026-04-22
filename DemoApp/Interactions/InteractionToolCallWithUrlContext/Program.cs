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

URLContext urlContext = new();
Tool tool = Tool.CreateUrlContext(urlContext);

CreateModelInteraction params1 = new()
{
    Input = InteractionsInput.CreateStr("Compare the ingredients and cooking times from the recipes at https://www.foodnetwork.com/recipes/ina-garten/perfect-roast-chicken-recipe-1940592 and https://www.allrecipes.com/recipe/21151/simple-whole-roast-chicken/"),
    Model = Model.Gemini25Flash,
    Tools = new List<Tool> { tool }
};

try
{
    var response_interaction = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(params1));
    var interaction = response_interaction.Interaction;

    Console.WriteLine($"Interaction ID: {interaction.Id}");
    Console.WriteLine($"Status: {interaction.Status}");
    Console.WriteLine(interaction?.OutputText);
}
catch (System.Exception ex)
{
    Console.WriteLine($"Error occurred: {ex.Message}");
}
