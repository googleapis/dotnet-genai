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

using System.Collections.Generic;
using System.Text.Json;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class AnnotationTest : TestBase
{
    [Fact]
    public void UrlCitationValidationWorks()
    {
        Annotation value = new UrlCitation()
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void FileCitationValidationWorks()
    {
        Annotation value = new FileCitation()
        {
            DocumentUri = "document_uri",
            EndIndex = 0,
            FileName = "file_name",
            Source = "source",
            StartIndex = 0,
        };
        value.Validate();
    }

    [Fact]
    public void PlaceCitationValidationWorks()
    {
        Annotation value = new PlaceCitation()
        {
            EndIndex = 0,
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            StartIndex = 0,
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void UrlCitationSerializationRoundtripWorks()
    {
        Annotation value = new UrlCitation()
        {
            EndIndex = 0,
            StartIndex = 0,
            Title = "title",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Annotation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileCitationSerializationRoundtripWorks()
    {
        Annotation value = new FileCitation()
        {
            DocumentUri = "document_uri",
            EndIndex = 0,
            FileName = "file_name",
            Source = "source",
            StartIndex = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Annotation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PlaceCitationSerializationRoundtripWorks()
    {
        Annotation value = new PlaceCitation()
        {
            EndIndex = 0,
            Name = "name",
            PlaceID = "place_id",
            ReviewSnippets = new List<PlaceCitationReviewSnippet>()
            {
                new PlaceCitationReviewSnippet()
                {
                    ReviewID = "review_id",
                    Title = "title",
                    Url = "url",
                },
            },
            StartIndex = 0,
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Annotation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
