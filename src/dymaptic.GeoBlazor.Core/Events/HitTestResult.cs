using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Views;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
#pragma warning disable CS1574
///     Object specification for the result of the <see cref="MapView.HitTest"/> method.
#pragma warning restore CS1574
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#HitTestResult">ArcGIS JS API</a>
/// </summary>
/// <param name="Results">
///     An array of result objects returned from the hitTest(). Results are returned when the location of the input screen coordinates intersects a Graphic or media element in the view.
/// </param>
/// <param name="ScreenPoint">
///     The screen coordinates (or native mouse event) of the click on the view.
/// </param>
public record HitTestResult(ViewHit[] Results, ScreenPoint ScreenPoint);

/// <summary>
///     Object specification for the <see cref="HitTestResult.Results"/>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#ViewHit">ArcGIS JS API</a>
/// </summary>
/// <param name="Type">
///     The type of hit result. Currently only supporting "graphic".
/// </param>
/// <param name="MapPoint">
///     The point geometry in the spatial reference of the view corresponding with the input screen coordinates.
/// </param>
[JsonConverter(typeof(ViewHitConverter))]
public record ViewHit(string Type, Point MapPoint);

/// <summary>
///     Object specification for the graphic hit result returned in HitTestResult of the hitTest() method.
/// </summary>
/// <param name="Graphic">
///     A graphic representing a feature in the view that intersects the input screen coordinates. If the graphic comes from a layer with an applied Renderer, then the symbol property will be empty. Other properties may be empty based on the context in which the graphic is fetched. If the result comes from a VectorTileLayer then a static graphic is returned with two attributes: layerId and layerName. These correspond to the name and id of the style-layer in the vector tile style.
/// </param>
/// <param name="Layer">
///     The layer that contains the feature/graphic.
/// </param>
/// <param name="MapPoint">
///     The point geometry in the spatial reference of the view corresponding with the input screen coordinates.
/// </param>
public record GraphicHit(Graphic Graphic, Layer Layer, Point MapPoint) : ViewHit("graphic", MapPoint);

/// <summary>
///     The screen coordinates (or native mouse event) of the click on the view.
/// </summary>
/// <param name="X">
///     The X coordinate.
/// </param>
/// <param name="Y">
///     The Y coordinate.
/// </param>
public record ScreenPoint(double X, double Y);

internal class ViewHitConverter : JsonConverter<ViewHit>
{
    public override ViewHit? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Utf8JsonReader cloneReader = reader;
        JsonElement json = JsonDocument.ParseValue(ref reader).RootElement;
        string? type = json.GetProperty("type").GetString();
        JsonElement mapPointJson = json.GetProperty("mapPoint");
        Point? mapPoint = mapPointJson.Deserialize<Point>(options);

        if (type is null || mapPoint is null)
        {
            return null;
        }
        
        return type switch
        {
            "graphic" => JsonSerializer.Deserialize<GraphicHit>(ref cloneReader, options),
            _ => new ViewHit(type, mapPoint)
        };
    }

    public override void Write(Utf8JsonWriter writer, ViewHit value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}