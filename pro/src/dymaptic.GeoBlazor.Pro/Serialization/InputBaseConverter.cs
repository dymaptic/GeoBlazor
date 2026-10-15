namespace dymaptic.GeoBlazor.Pro.Serialization;

internal class InputBaseConverter: JsonConverter<InputBase>
{
    public override InputBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            return null;
        
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var type = root.GetProperty("type").GetString();
        return type switch
        {
            "field" => JsonSerializer.Deserialize<FieldInput>(root.GetRawText(), options),
            "group" => JsonSerializer.Deserialize<GroupInput>(root.GetRawText(), options),
            _ => throw new NotSupportedException($"Type {type} is not supported")
        };
    }

    public override void Write(Utf8JsonWriter writer, InputBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}