namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(MediaInfoConverter))]
public abstract partial class MediaInfo : MapComponent, IProtobufSerializable<MediaInfoSerializationRecord>
{
    /// <summary>
    ///     Indicates the type of media
    /// </summary>
    public abstract string Type { get; }

    public abstract MediaInfoSerializationRecord ToProtobuf();
}

internal class MediaInfoConverter : JsonConverter<MediaInfo>
{
    public override MediaInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // check the type property and deserialize to the correct type
        var jsonDoc = JsonDocument.ParseValue(ref reader);
        string? type = jsonDoc.RootElement.GetProperty("type").GetString();

        switch (type)
        {
            case "bar-chart":
                return JsonSerializer.Deserialize<BarChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "column-chart":
                return JsonSerializer.Deserialize<ColumnChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "pie-chart":
                return JsonSerializer.Deserialize<PieChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "line-chart":
                return JsonSerializer.Deserialize<LineChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "image-media":
                return JsonSerializer.Deserialize<ImageMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, MediaInfo value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}