using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     Abstract base class, PopupContent elements define what should display within the PopupTemplate content.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-Content.html">ArcGIS JS API</a>
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
    public override PopupContent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
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