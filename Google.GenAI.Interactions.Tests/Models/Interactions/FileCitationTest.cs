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

using System.Text.Json;
using Google.GenAI.Interactions.Core;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class FileCitationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileCitation
        {
            DocumentUri = "document_uri",
            EndIndex = 0,
            FileName = "file_name",
            Source = "source",
            StartIndex = 0,
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("file_citation");
        string expectedDocumentUri = "document_uri";
        int expectedEndIndex = 0;
        string expectedFileName = "file_name";
        string expectedSource = "source";
        int expectedStartIndex = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedDocumentUri, model.DocumentUri);
        Assert.Equal(expectedEndIndex, model.EndIndex);
        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStartIndex, model.StartIndex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileCitation
        {
            DocumentUri = "document_uri",
            EndIndex = 0,
            FileName = "file_name",
            Source = "source",
            StartIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileCitation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileCitation
        {
            DocumentUri = "document_uri",
            EndIndex = 0,
            FileName = "file_name",
            Source = "source",
            StartIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileCitation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("file_citation");
        string expectedDocumentUri = "document_uri";
        int expectedEndIndex = 0;
        string expectedFileName = "file_name";
        string expectedSource = "source";
        int expectedStartIndex = 0;

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedDocumentUri, deserialized.DocumentUri);
        Assert.Equal(expectedEndIndex, deserialized.EndIndex);
        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedStartIndex, deserialized.StartIndex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileCitation
        {
            DocumentUri = "document_uri",
            EndIndex = 0,
            FileName = "file_name",
            Source = "source",
            StartIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileCitation { };

        Assert.Null(model.DocumentUri);
        Assert.False(model.RawData.ContainsKey("document_uri"));
        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("file_name"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileCitation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileCitation
        {
            // Null should be interpreted as omitted for these properties
            DocumentUri = null,
            EndIndex = null,
            FileName = null,
            Source = null,
            StartIndex = null,
        };

        Assert.Null(model.DocumentUri);
        Assert.False(model.RawData.ContainsKey("document_uri"));
        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("file_name"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileCitation
        {
            // Null should be interpreted as omitted for these properties
            DocumentUri = null,
            EndIndex = null,
            FileName = null,
            Source = null,
            StartIndex = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileCitation
        {
            DocumentUri = "document_uri",
            EndIndex = 0,
            FileName = "file_name",
            Source = "source",
            StartIndex = 0,
        };

        FileCitation copied = new(model);

        Assert.Equal(model, copied);
    }
}
