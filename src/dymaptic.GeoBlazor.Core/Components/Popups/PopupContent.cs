namespace dymaptic.GeoBlazor.Core.Components.Popups;

[JsonConverter(typeof(PopupContentConverter))]
public abstract partial class PopupContent : MapComponent
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
    
    public PopupContentSerializationRecord(string Id, string Type)
    {
        this.Type = Type;
        this.Id = Id;
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
    public ElementExpressionInfoSerializationRecord? ExpressionInfo { get; init; }

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
    
    [ProtoMember(13)]
    public string? Id { get; set; }
    
    [ProtoMember(14)]
    public string[]? OutFields { get; init; }

    public PopupContent FromSerializationRecord()
    {
        Guid id = Guid.NewGuid();

        if (Guid.TryParse(Id, out Guid guidId))
        {
            id = guidId;
        }

        if (Type == "custom")
        {
            // CustomPopupContent is in GeoBlazor Pro assembly, so we need to use reflection to get the type
            Type? customType = System.Type.GetType("dymaptic.GeoBlazor.Pro.Components.Popups.CustomPopupContent, dymaptic.GeoBlazor.Pro");

            if (customType is not null && customType.IsSubclassOf(typeof(PopupContent)))
            {
                PopupContent? customContent = Activator.CreateInstance(customType, args: [null, OutFields]) as PopupContent;

                if (customContent is null)
                {
                    throw new InvalidOperationException("CustomPopupContent could not be created. Ensure the type is correct and the assembly is loaded.");
                }
                customContent.Id = id;

                return customContent;
            }
        }
        
        return Type switch
        {
            "fields" => new FieldsPopupContent(FieldInfos?.Select(i => 
                    i.FromSerializationRecord()).ToArray() ?? [],
                Description, Title) { Id = id },
            "text" => new TextPopupContent(Text){ Id = id },
            "attachments" => new AttachmentsPopupContent(Title, Description, 
                DisplayType is null ? null : Enum.Parse<AttachmentsPopupContentDisplayType>(DisplayType))
            {
                Id = id
            },
            "expression" => new ExpressionPopupContent(ExpressionInfo?.FromSerializationRecord()) { Id = id },
            "media" => new MediaPopupContent(Title, Description,
                MediaInfos?.Select(i => i.FromSerializationRecord()).ToArray(),
                ActiveMediaInfoIndex) { Id = id },
            "relationship" => new RelationshipPopupContent(Title, Description, DisplayCount,
                DisplayType, OrderByFields?.Select(x => x.FromSerializationRecord()).ToList(),
                RelationshipId) { Id = id },
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
            case "custom":
                // CustomPopupContent is in GeoBlazor Pro assembly, so we need to use reflection to get the type
                Type? customType = Type.GetType("dymaptic.GeoBlazor.Pro.Components.Popups.CustomPopupContent, dymaptic.GeoBlazor.Pro");

                if (customType is not null && customType.IsSubclassOf(typeof(PopupContent)))
                {
                    content =
                        JsonSerializer.Deserialize(jsonDoc.RootElement.GetRawText(), customType, options) as PopupContent;
                }

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