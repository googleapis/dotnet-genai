// Copyright 2026 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using Google.GenAI.Gaos.Models.Interactions;
using Google.GenAI.Gaos.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Google.GenAI.Tests;

[TestClass]
public class InteractionsGaosImplicitConversionsTest
{
    [TestMethod]
    public void CreateInteractionRequestBody_ImplicitConversions()
    {
        var modelInteraction = new CreateModelInteraction();
        CreateInteractionRequestBody bodyFromModel = modelInteraction;
        Assert.IsNotNull(bodyFromModel.CreateModelInteraction);
        Assert.AreSame(modelInteraction, bodyFromModel.CreateModelInteraction);
        Assert.AreEqual(CreateInteractionRequestBodyType.CreateModelInteraction, bodyFromModel.Type);

        var agentInteraction = new CreateAgentInteraction();
        CreateInteractionRequestBody bodyFromAgent = agentInteraction;
        Assert.IsNotNull(bodyFromAgent.CreateAgentInteraction);
        Assert.AreSame(agentInteraction, bodyFromAgent.CreateAgentInteraction);
        Assert.AreEqual(CreateInteractionRequestBodyType.CreateAgentInteraction, bodyFromAgent.Type);
    }

    [TestMethod]
    public void InteractionsInput_ImplicitConversions()
    {
        InteractionsInput inputFromString = "What is 1+1?";
        Assert.AreEqual("What is 1+1?", inputFromString.Str);
        Assert.AreEqual(InteractionsInputType.Str, inputFromString.Type);

        var content = Content.CreateText(new TextContent { Text = "hello" });
        InteractionsInput inputFromContent = content;
        Assert.AreSame(content, inputFromContent.Content);
        Assert.AreEqual(InteractionsInputType.Content, inputFromContent.Type);

        var contentList = new List<Content> { content };
        InteractionsInput inputFromContentList = contentList;
        Assert.AreSame(contentList, inputFromContentList.ArrayOfContent);
        Assert.AreEqual(InteractionsInputType.ArrayOfContent, inputFromContentList.Type);

        var stepList = new List<Step>();
        InteractionsInput inputFromStepList = stepList;
        Assert.AreSame(stepList, inputFromStepList.ArrayOfStep);
        Assert.AreEqual(InteractionsInputType.ArrayOfStep, inputFromStepList.Type);
    }

    [TestMethod]
    public void ResponseFormat_ImplicitConversions()
    {
        var dict = new Dictionary<string, object> { ["type"] = "json_object" };
        ResponseFormat rfFromDict = dict;
        Assert.AreSame(dict, rfFromDict.MapOfAny);
        Assert.AreEqual(ResponseFormatType.MapOfAny, rfFromDict.Type);

        var textRf = new TextResponseFormat();
        ResponseFormat rfFromText = textRf;
        Assert.AreSame(textRf, rfFromText.TextResponseFormat);
        Assert.AreEqual(ResponseFormatType.TextResponseFormat, rfFromText.Type);
    }

    [TestMethod]
    public void CreateModelInteractionResponseFormat_ImplicitConversions()
    {
        var dict = new Dictionary<string, object> { ["type"] = "json_object" };
        CreateModelInteractionResponseFormat rfFromDict = dict;
        Assert.IsNotNull(rfFromDict.ResponseFormat?.MapOfAny);
        Assert.AreSame(dict, rfFromDict.ResponseFormat.MapOfAny);
        Assert.AreEqual(CreateModelInteractionResponseFormatType.ResponseFormat, rfFromDict.Type);

        ResponseFormat rf = dict;
        CreateModelInteractionResponseFormat rfFromRf = rf;
        Assert.AreSame(rf, rfFromRf.ResponseFormat);
        Assert.AreEqual(CreateModelInteractionResponseFormatType.ResponseFormat, rfFromRf.Type);

        var rfList = new List<ResponseFormat> { rf };
        CreateModelInteractionResponseFormat rfFromList = rfList;
        Assert.AreSame(rfList, rfFromList.ArrayOfResponseFormat);
        Assert.AreEqual(CreateModelInteractionResponseFormatType.ArrayOfResponseFormat, rfFromList.Type);
    }

    [TestMethod]
    public void CreateAgentInteractionResponseFormat_ImplicitConversions()
    {
        var dict = new Dictionary<string, object> { ["type"] = "json_object" };
        CreateAgentInteractionResponseFormat rfFromDict = dict;
        Assert.IsNotNull(rfFromDict.ResponseFormat?.MapOfAny);
        Assert.AreSame(dict, rfFromDict.ResponseFormat.MapOfAny);
        Assert.AreEqual(CreateAgentInteractionResponseFormatType.ResponseFormat, rfFromDict.Type);

        ResponseFormat rf = dict;
        CreateAgentInteractionResponseFormat rfFromRf = rf;
        Assert.AreSame(rf, rfFromRf.ResponseFormat);
        Assert.AreEqual(CreateAgentInteractionResponseFormatType.ResponseFormat, rfFromRf.Type);
    }

    [TestMethod]
    public void Content_ImplicitConversions()
    {
        Content contentFromString = "hello world";
        Assert.IsNotNull(contentFromString.TextContent);
        Assert.AreEqual("hello world", contentFromString.TextContent.Text);
        Assert.AreEqual(ContentType.Text, contentFromString.Type);

        var textContent = new TextContent { Text = "test" };
        Content contentFromText = textContent;
        Assert.AreSame(textContent, contentFromText.TextContent);
        Assert.AreEqual(ContentType.Text, contentFromText.Type);

        var imgContent = new ImageContent();
        Content contentFromImage = imgContent;
        Assert.AreSame(imgContent, contentFromImage.ImageContent);
        Assert.AreEqual(ContentType.Image, contentFromImage.Type);
    }

    [TestMethod]
    public void EndToEnd_ErgonomicInteractionCreation()
    {
        // Tests the exact scenario from Matthew Tang's feedback doc:
        CreateInteractionRequestBody body = new CreateModelInteraction
        {
            Input = "What is 1+1?",
            ResponseFormat = new Dictionary<string, object>
            {
                ["type"] = "json_object"
            }
        };

        Assert.IsNotNull(body.CreateModelInteraction);
        Assert.AreEqual(CreateInteractionRequestBodyType.CreateModelInteraction, body.Type);
        Assert.IsNotNull(body.CreateModelInteraction.Input);
        Assert.AreEqual("What is 1+1?", body.CreateModelInteraction.Input.Str);
        Assert.IsNotNull(body.CreateModelInteraction.ResponseFormat?.ResponseFormat?.MapOfAny);
        Assert.AreEqual("json_object", body.CreateModelInteraction.ResponseFormat.ResponseFormat.MapOfAny["type"]);
    }
}
