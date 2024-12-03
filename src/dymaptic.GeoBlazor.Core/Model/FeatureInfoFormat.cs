using System.Text.Json;
using System.Text.Json.Serialization;
// ReSharper disable InconsistentNaming


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The MIME type that will be requested by popups.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMSLayer.html#featureInfoFormat">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public enum FeatureInfoFormat
{
    /// <summary>
    ///     The feature information is returned as HTML.
    /// </summary>
    Text_Html,
    /// <summary>
    ///     The feature information is returned as plain text.
    /// </summary>
    Text_Plain
}

internal class FeatureInfoFormatConverter: JsonConverter<FeatureInfoFormat>
{
    public override FeatureInfoFormat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException();
        }

        return reader.GetString() switch
        {
            "text/html" => FeatureInfoFormat.Text_Html,
            "text/plain" => FeatureInfoFormat.Text_Plain,
            _ => throw new JsonException()
        };
    }

    public override void Write(Utf8JsonWriter writer, FeatureInfoFormat value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value switch
        {
            FeatureInfoFormat.Text_Html => "text/html",
            FeatureInfoFormat.Text_Plain => "text/plain",
            _ => throw new JsonException()
        });
    }
}
