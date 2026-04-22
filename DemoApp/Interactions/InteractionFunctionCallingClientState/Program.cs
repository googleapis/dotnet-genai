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
using System.Text.Json;
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

// 2. Initialize conversation history
List<Step> conversationHistory = new List<Step>();
conversationHistory.Add(Step.CreateUserInput(new UserInputStep
{
    Content = new List<Content> { Content.CreateText(new TextContent { Text = "Schedule a meeting for 2025-11-01 at 10 am with Peter and Amir about the Next Gen API" }) }
}));

// 3. First turn: Model decides to call the function
CreateModelInteraction params1 = new()
{
    Input = InteractionsInput.CreateArrayOfStep(conversationHistory),
    Model = Model.Gemini25Flash,
    Tools = new List<Tool> { Tool.CreateFunction(function) }
};

var response_response = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(params1));
var response = response_response.Interaction;

string? functionCallId = null;
string? functionName = null;

foreach (var step in response?.Steps ?? [])
{
    if (step.Type == StepType.FunctionCall && step.FunctionCallStep != null)
    {
        var functionCall = step.FunctionCallStep;
        functionCallId = functionCall.Id;
        functionName = functionCall.Name;
        Console.WriteLine($"Model requested function call: {functionName}");
        Console.WriteLine($"Arguments: {JsonConvert.SerializeObject(functionCall.Arguments)}");
    }
    else if (step.Type == StepType.ModelOutput && step.ModelOutputStep?.Content != null)
    {
        foreach (var output in step.ModelOutputStep.Content)
        {
            if (output.TryPickText(out var text))
            {
                Console.WriteLine($"Output Text: {text.Text}");
            }
        }
    }
}

// Add model response back to history
if (response?.Steps != null)
{
    conversationHistory.AddRange(response.Steps);
}

// 4. Second turn: Send the function result back to the model
if (functionCallId != null)
{
    Console.WriteLine("Sending function result back...");

    FunctionResultStep functionResult = new()
    {
        CallId = functionCallId,
        Name = functionName,
        Result = FunctionResultStepResultUnion.CreateStr("Meeting scheduled successfully.")
    };

    // Create a turn with function result
    conversationHistory.Add(Step.CreateFunctionResult(functionResult));

    CreateModelInteraction followUpParams = new()
    {
        Model = Model.Gemini25Flash,
        Input = InteractionsInput.CreateArrayOfStep(conversationHistory)
    };

    var response_followUpResponse = await client.Interactions.CreateAsync(CreateInteractionRequestBody.CreateCreateModelInteraction(followUpParams));
    var followUpResponse = response_followUpResponse.Interaction;

    Console.WriteLine($"Final response status: {followUpResponse.Status}");
    Console.WriteLine(followUpResponse?.OutputText);
}
else
{
    Console.WriteLine("No function call requested by the model.");
}
