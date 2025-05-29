namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(MediaInfoConverter))]
public abstract partial class MediaInfo : MapComponent
{
    /// <summary>
    ///     Indicates the type of media
    /// </summary>
    public abstract string Type { get; }

    internal abstract MediaInfoSerializationRecord ToSerializationRecord();
}

[ProtoContract(Name = "MediaInfo")]
internal record MediaInfoSerializationRecord : MapComponentSerializationRecord
{
    public MediaInfoSerializationRecord()
    {
    }
    
    public MediaInfoSerializationRecord(string Id, string Type)
    {
        this.Id = Id;
        this.Type = Type;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;
    
    [ProtoMember(2)]
    public string? AltText { get; init; }

    [ProtoMember(3)]
    public string? Caption { get; init; }

    [ProtoMember(4)]
    public string? Title { get; init; }

    [ProtoMember(5)]
    public ChartMediaInfoValueSerializationRecord? Value { get; init; }

    [ProtoMember(6)]
    public double? RefreshInterval { get; init; }
    
    [ProtoMember(7)]
    public string? Id { get; init; }

    public MediaInfo FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();
        if (Guid.TryParse(Id, out Guid guid))
        {
            id = guid;
        }
        return Type switch
        {
            "bar-chart" => new BarChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "column-chart" => new ColumnChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "pie-chart" => new PieChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "line-chart" => new LineChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue) { Id = id },
            "image-media" => new ImageMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ImageMediaInfoValue,
                RefreshInterval) { Id = id },
            _ => throw new NotSupportedException($"MediaInfo type {Type} is not supported.")
        };
    }
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