namespace dymaptic.GeoBlazor.Core.Components.Popups;

[JsonConverter(typeof(PopupContentConverter))]
public abstract partial class PopupContent : MapComponent, IProtobufSerializable
{
    /// <summary>
    ///     The type of Popup Content
    /// </summary>
    public abstract PopupContentType Type { get; }

    internal abstract PopupContentSerializationRecord ToSerializationRecord();
    
    public MapComponentSerializationRecord ToProtobuf()
    {
        return ToSerializationRecord();
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