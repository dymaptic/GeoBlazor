namespace dymaptic.GeoBlazor.Core.Serialization;

internal class BasemapGallerySourceConverter: JsonConverter<IBasemapGalleryWidgetSource>
{
    public override IBasemapGalleryWidgetSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        JsonElement root = document.RootElement;

        if (root.TryGetProperty("QueryString", out _) || root.TryGetProperty("QueryParams", out _))
        {
            return JsonSerializer.Deserialize<PortalBasemapsSource>(root.GetRawText(), options);
        }

        return JsonSerializer.Deserialize<LocalBasemapsSource>(root.GetRawText(), options);
    }

    public override void Write(Utf8JsonWriter writer, IBasemapGalleryWidgetSource value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}