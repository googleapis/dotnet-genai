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

public class InteractionCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InteractionCancelParams { ApiVersion = "api_version", ID = "id" };

        string expectedApiVersion = "api_version";
        string expectedID = "id";

        Assert.Equal(expectedApiVersion, parameters.ApiVersion);
        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        InteractionCancelParams parameters = new() { ApiVersion = "api_version", ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://generativelanguage.googleapis.com/api_version/interactions/id/cancel"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InteractionCancelParams { ApiVersion = "api_version", ID = "id" };

        InteractionCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
