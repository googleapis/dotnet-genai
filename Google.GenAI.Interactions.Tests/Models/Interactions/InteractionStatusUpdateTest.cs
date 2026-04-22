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
using Google.GenAI.Interactions.Exceptions;
using Google.GenAI.Interactions.Models.Interactions;

namespace Google.GenAI.Interactions.Tests.Models.Interactions;

public class InteractionStatusUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,
            EventID = "event_id",
        };

        JsonElement expectedEventType = JsonSerializer.SerializeToElement(
            "interaction.status_update"
        );
        string expectedInteractionID = "interaction_id";
        ApiEnum<string, InteractionStatusUpdateStatus> expectedStatus =
            InteractionStatusUpdateStatus.InProgress;
        string expectedEventID = "event_id";

        Assert.True(JsonElement.DeepEquals(expectedEventType, model.EventType));
        Assert.Equal(expectedInteractionID, model.InteractionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,
            EventID = "event_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionStatusUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,
            EventID = "event_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InteractionStatusUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedEventType = JsonSerializer.SerializeToElement(
            "interaction.status_update"
        );
        string expectedInteractionID = "interaction_id";
        ApiEnum<string, InteractionStatusUpdateStatus> expectedStatus =
            InteractionStatusUpdateStatus.InProgress;
        string expectedEventID = "event_id";

        Assert.True(JsonElement.DeepEquals(expectedEventType, deserialized.EventType));
        Assert.Equal(expectedInteractionID, deserialized.InteractionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,
            EventID = "event_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,
        };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,

            // Null should be interpreted as omitted for these properties
            EventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InteractionStatusUpdate
        {
            InteractionID = "interaction_id",
            Status = InteractionStatusUpdateStatus.InProgress,
            EventID = "event_id",
        };

        InteractionStatusUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InteractionStatusUpdateStatusTest : TestBase
{
    [Theory]
    [InlineData(InteractionStatusUpdateStatus.InProgress)]
    [InlineData(InteractionStatusUpdateStatus.RequiresAction)]
    [InlineData(InteractionStatusUpdateStatus.Completed)]
    [InlineData(InteractionStatusUpdateStatus.Failed)]
    [InlineData(InteractionStatusUpdateStatus.Cancelled)]
    [InlineData(InteractionStatusUpdateStatus.Incomplete)]
    public void Validation_Works(InteractionStatusUpdateStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionStatusUpdateStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionStatusUpdateStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<GeminiNextGenApiInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InteractionStatusUpdateStatus.InProgress)]
    [InlineData(InteractionStatusUpdateStatus.RequiresAction)]
    [InlineData(InteractionStatusUpdateStatus.Completed)]
    [InlineData(InteractionStatusUpdateStatus.Failed)]
    [InlineData(InteractionStatusUpdateStatus.Cancelled)]
    [InlineData(InteractionStatusUpdateStatus.Incomplete)]
    public void SerializationRoundtrip_Works(InteractionStatusUpdateStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InteractionStatusUpdateStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InteractionStatusUpdateStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InteractionStatusUpdateStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InteractionStatusUpdateStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
