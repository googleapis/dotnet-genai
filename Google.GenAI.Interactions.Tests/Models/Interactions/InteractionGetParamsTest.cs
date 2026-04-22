// Copyright 2025 Google LLC
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

using System;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class InteractionGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InteractionGetParams
        {
            ApiVersion = "api_version",
            ID = "id",
            IncludeInput = true,
            LastEventID = "last_event_id",
        };

        string expectedApiVersion = "api_version";
        string expectedID = "id";
        bool expectedIncludeInput = true;
        string expectedLastEventID = "last_event_id";

        Assert.Equal(expectedApiVersion, parameters.ApiVersion);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIncludeInput, parameters.IncludeInput);
        Assert.Equal(expectedLastEventID, parameters.LastEventID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InteractionGetParams { ApiVersion = "api_version", ID = "id" };

        Assert.Null(parameters.IncludeInput);
        Assert.False(parameters.RawQueryData.ContainsKey("include_input"));
        Assert.Null(parameters.LastEventID);
        Assert.False(parameters.RawQueryData.ContainsKey("last_event_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InteractionGetParams
        {
            ApiVersion = "api_version",
            ID = "id",

            // Null should be interpreted as omitted for these properties
            IncludeInput = null,
            LastEventID = null,
        };

        Assert.Null(parameters.IncludeInput);
        Assert.False(parameters.RawQueryData.ContainsKey("include_input"));
        Assert.Null(parameters.LastEventID);
        Assert.False(parameters.RawQueryData.ContainsKey("last_event_id"));
    }

    [Fact]
    public void Url_Works()
    {
        InteractionGetParams parameters = new()
        {
            ApiVersion = "api_version",
            ID = "id",
            IncludeInput = true,
            LastEventID = "last_event_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://generativelanguage.googleapis.com/api_version/interactions/id?include_input=true&last_event_id=last_event_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InteractionGetParams
        {
            ApiVersion = "api_version",
            ID = "id",
            IncludeInput = true,
            LastEventID = "last_event_id",
        };

        InteractionGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
