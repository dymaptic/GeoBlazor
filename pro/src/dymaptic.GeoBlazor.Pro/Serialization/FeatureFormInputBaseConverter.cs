namespace dymaptic.GeoBlazor.Pro.Serialization;

internal class FeatureFormInputBaseConverter: JsonConverter<FeatureFormInputBase>
{
    public override FeatureFormInputBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            return null;
        
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var type = root.GetProperty("type").GetString();
        return type switch
        {
            "field" => JsonSerializer.Deserialize<FeatureFormFieldInput>(root.GetRawText(), options),
            "group" => JsonSerializer.Deserialize<FeatureFormGroupInput>(root.GetRawText(), options),
            "relationship" => JsonSerializer.Deserialize<RelationshipInput>(root.GetRawText(), options),
            "utility-network-association" => JsonSerializer.Deserialize<UtilityNetworkAssociationInput>(root.GetRawText(), options),
            _ => throw new NotSupportedException($"Type {type} is not supported")
        };
    }

    public override void Write(Utf8JsonWriter writer, FeatureFormInputBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}