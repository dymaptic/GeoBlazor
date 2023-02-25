using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     Abstract base class, PopupContent elements define what should display within the PopupTemplate content.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-Content.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
[JsonConverter(typeof(PopupContentConverter))]
public abstract class PopupContent : MapComponent
{
    /// <summary>
    ///     The type of Popup Content
    /// </summary>
    [JsonPropertyName("type")]
    public abstract string Type { get; }
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