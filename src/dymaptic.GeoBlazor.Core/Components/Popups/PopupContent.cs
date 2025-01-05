namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     Abstract base class, PopupContent elements define what should display within the PopupTemplate content.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-Content.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(PopupContentConverter))]
public abstract class PopupContent : MapComponent
{
    /// <summary>
    ///     The type of Popup Content
    /// </summary>
    public abstract PopupContentType Type { get; }

    internal abstract PopupContentSerializationRecord ToSerializationRecord();
}

[ProtoContract(Name = "PopupContent")]
internal record PopupContentSerializationRecord : MapComponentSerializationRecord
{
    public PopupContentSerializationRecord()
    {
    }
    
    public PopupContentSerializationRecord(string Type)
    {
        this.Type = Type;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;
    
    [ProtoMember(2)]
    public string? Description { get; init; }

    [ProtoMember(3)]
    public string? DisplayType { get; init; }

    [ProtoMember(4)]
    public string? Title { get; init; }

    [ProtoMember(5)]
    public ElementExpressionInfo? ExpressionInfo { get; init; }

    [ProtoMember(6)]
    public FieldInfoSerializationRecord[]? FieldInfos { get; init; }

    [ProtoMember(7)]
    public int? ActiveMediaInfoIndex { get; init; }

    [ProtoMember(8)]
    public MediaInfoSerializationRecord[]? MediaInfos { get; init; }

    [ProtoMember(9)]
    public int? DisplayCount { get; init; }

    [ProtoMember(10)]
    public RelatedRecordsInfoFieldOrderSerializationRecord[]? OrderByFields { get; init; }

    [ProtoMember(11)]
    public long? RelationshipId { get; init; }

    [ProtoMember(12)]
    public string? Text { get; init; }

    public PopupContent FromSerializationRecord()
    {
        return Type switch
        {
            "fields" => new FieldsPopupContent(FieldInfos?.Select(i => 
                    i.FromSerializationRecord()).ToArray() ?? [],
                Description, Title),
            "text" => new TextPopupContent(Text),
            "attachments" => new AttachmentsPopupContent(Title, Description, 
                DisplayType is null ? null : Enum.Parse<AttachmentsPopupContentDisplayType>(DisplayType)),
            "expression" => new ExpressionPopupContent(ExpressionInfo),
            "media" => new MediaPopupContent(Title, Description,
                MediaInfos?.Select(i => i.FromSerializationRecord()).ToArray(),
                ActiveMediaInfoIndex),
            "relationship" => new RelationshipPopupContent(Title, Description, DisplayCount,
                DisplayType, OrderByFields?.Select(x => x.FromSerializationRecord()).ToList(),
                RelationshipId),
            _ => throw new NotSupportedException($"PopupContent type {Type} is not supported")
        };
    }
}

internal class PopupContentConverter : JsonConverter<PopupContent>
{
    public override PopupContent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // check the type property and deserialize to the correct type
        var jsonDoc = JsonDocument.ParseValue(ref reader);
        string? type = jsonDoc.RootElement.GetProperty("type").GetString();

        PopupContent? content = null;

        switch (type)
        {
            case "fields":
                content = JsonSerializer.Deserialize<FieldsPopupContent>(jsonDoc.RootElement.GetRawText(), options);

                break;
            case "text":
                content = JsonSerializer.Deserialize<TextPopupContent>(jsonDoc.RootElement.GetRawText(), options);

                break;
            case "attachments":
                content = JsonSerializer.Deserialize<AttachmentsPopupContent>(jsonDoc.RootElement.GetRawText(),
                    options);

                break;

            case "expression":
                content = JsonSerializer.Deserialize<ExpressionPopupContent>(jsonDoc.RootElement.GetRawText(), options);

                break;

            case "media":
                content = JsonSerializer.Deserialize<MediaPopupContent>(jsonDoc.RootElement.GetRawText(), options);

                break;

            case "relationship":
                content = JsonSerializer.Deserialize<RelationshipPopupContent>(jsonDoc.RootElement.GetRawText(),
                    options);

                break;
        }

        return content;
    }

    public override void Write(Utf8JsonWriter writer, PopupContent value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}