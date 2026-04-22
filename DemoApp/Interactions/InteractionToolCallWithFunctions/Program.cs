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
using Newtonsoft.Json;

bool isVertex = args.Contains("--vertex", StringComparer.OrdinalIgnoreCase);
Console.WriteLine(isVertex ? "Running in Vertex AI mode." : "Running in Gemini API mode.");

Client client = new Client(vertexAI: isVertex);

if (isVertex)
{
    Console.WriteLine("Interactions API is not yet supported on Vertex AI");
    return;
}

// 1. Define the function (tool)
var attendeesSchema = new Dictionary<string, object>
{
    ["type"] = "array",
    ["items"] = new Dictionary<string, string> { ["type"] = "string" },
    ["description"] = "List of people attending the meeting."
};

var dateSchema = new Dictionary<string, object>
{
    ["type"] = "string",
    ["description"] = "Date of the meeting (e.g., 2024-07-29)"
};

var timeSchema = new Dictionary<string, object>
{
    ["type"] = "string",
    ["description"] = "Time of the meeting (e.g., 15:00)"
};

var topicSchema = new Dictionary<string, object>
{
    ["type"] = "string",
    ["description"] = "The subject or topic of the meeting."
};

var properties = new Dictionary<string, object>
{
    ["attendees"] = attendeesSchema,
    ["date"] = dateSchema,
    ["time"] = timeSchema,
    ["topic"] = topicSchema
};

var parametersSchema = new Dictionary<string, object>
{
    ["type"] = "object",
    ["properties"] = properties,
    ["required"] = new List<string> { "attendees", "date", "time", "topic" }
};

Function function = new()
{
    Name = "schedule_meeting",
    Description = "Schedules a meeting with specified attendees at a given time and date.",
    Parameters = CreateModelInteractionResponseFormat.CreateResponseFormat(ResponseFormat.CreateMapOfAny(parametersSchema))
};

CreateModelInteraction params1 = new()
{
    Input = InteractionsInput.CreateStr("Schedule a meeting for 10/06/2028 at 10 am with Peter and Amir about the Next Gen API"),
    Model = Model.Gemini25Flash,
    Tools = new List<Tool> { Tool.CreateFunction(function) }
};

var response_interaction = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(params1));
var interaction = response_interaction.Interaction;

Console.WriteLine($"Interaction ID: {interaction.Id}");
Console.WriteLine($"Status: {interaction.Status}");

foreach (var step in interaction?.Steps ?? [])
{
    if (step.Type == StepType.ModelOutput && step.ModelOutputStep?.Content != null)
    {
        foreach (var output in step.ModelOutputStep.Content)
        {
            if (output.TryPickText(out var text))
            {
                Console.WriteLine($"Output Text: {text.Text}");
            }
        }
    }
    if (step.Type == StepType.FunctionCall && step.FunctionCallStep != null)
    {
        var fc = step.FunctionCallStep;
        Console.WriteLine($"Function Call: {fc.Name}");
        Console.WriteLine($"Arguments: {JsonConvert.SerializeObject(fc.Arguments)}");
    }
}
