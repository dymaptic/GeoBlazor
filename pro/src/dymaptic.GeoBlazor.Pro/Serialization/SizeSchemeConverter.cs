namespace dymaptic.GeoBlazor.Pro.Serialization;

internal class SizeSchemeConverter : JsonConverter<SizeScheme>
{
    public override SizeScheme? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        if (root.TryGetProperty("marker", out JsonElement _) || root.TryGetProperty("background", out JsonElement _))
        {
            return JsonSerializer.Deserialize<SizeSchemeForPolygon>(root.GetRawText(), options);
        }

        if (root.TryGetProperty("size", out JsonElement _) || root.TryGetProperty("outline", out JsonElement _))
        {
            return JsonSerializer.Deserialize<SizeSchemeForPoint>(root.GetRawText(), options);
        }

        return JsonSerializer.Deserialize<SizeSchemeForPolyline>(root.GetRawText(), options);
    }

    public override void Write(Utf8JsonWriter writer, SizeScheme value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, typeof(object), options);
    }
}