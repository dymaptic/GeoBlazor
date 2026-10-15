namespace dymaptic.GeoBlazor.Pro.Events;

/// <summary>
///     Returns additional information associated with the operation such as where the user is clicking the view or where the user is moving the cursor to. Value of this parameter changes to null when the event's state changes to complete or cancel.
/// </summary>
[JsonConverter(typeof(ToolEventInfoConverter))]
public abstract record ToolEventInfo
{
    /// <summary>
    ///     The type of the <see cref="ToolEventInfo"/>
    /// </summary>
    [JsonPropertyName("type")]
    public abstract string InfoType { get; }
}

internal class ToolEventInfoConverter : JsonConverter<ToolEventInfo>
{
    public override ToolEventInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.TryGetValue("type", out object? typeValue))
        {
            switch (typeValue?.ToString())
            {
                case "cursor-update":
                    return JsonSerializer.Deserialize<CursorUpdateEventInfo>(ref cloneReader, newOptions);
                
                case "move":
                    return JsonSerializer.Deserialize<MoveEventInfo>(ref cloneReader, newOptions);
                case "move-start":
                    return JsonSerializer.Deserialize<MoveStartEventInfo>(ref cloneReader, newOptions);
                case "move-stop":
                    return JsonSerializer.Deserialize<MoveStopEventInfo>(ref cloneReader, newOptions);
                case "reshape":
                    return JsonSerializer.Deserialize<ReshapeEventInfo>(ref cloneReader, newOptions);
                case "reshape-start":
                    return JsonSerializer.Deserialize<ReshapeStartEventInfo>(ref cloneReader, newOptions);
                case "reshape-stop":
                    return JsonSerializer.Deserialize<ReshapeStopEventInfo>(ref cloneReader, newOptions);
                case "rotate":
                    return JsonSerializer.Deserialize<RotateEventInfo>(ref cloneReader, newOptions);
                case "rotate-start":
                    return JsonSerializer.Deserialize<RotateStartEventInfo>(ref cloneReader, newOptions);
                case "rotate-stop":
                    return JsonSerializer.Deserialize<RotateStopEventInfo>(ref cloneReader, newOptions);
                case "scale":
                    return JsonSerializer.Deserialize<ScaleEventInfo>(ref cloneReader, newOptions);
                case "scale-start":
                    return JsonSerializer.Deserialize<ScaleStartEventInfo>(ref cloneReader, newOptions);
                case "scale-stop":
                    return JsonSerializer.Deserialize<ScaleStopEventInfo>(ref cloneReader, newOptions);
                case "selection-change":
                    return JsonSerializer.Deserialize<SelectionChangeEventInfo>(ref cloneReader, newOptions);
                case "vertex-add":
                    return JsonSerializer.Deserialize<VertexAddEventInfo>(ref cloneReader, newOptions);
                case "vertex-remove":
                    return JsonSerializer.Deserialize<VertexRemoveEventInfo>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, ToolEventInfo value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}