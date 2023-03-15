using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Object specification for the result of the MapView.HitTest method.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#HitTestResult">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// <param name="Results">
///     An array of result objects returned from the hitTest(). Results are returned when the location of the input screen
///     coordinates intersects a Graphic or media element in the view.
/// </param>
/// <param name="ScreenPoint">
///     The screen coordinates (or native mouse event) of the click on the view.
/// </param>
public record HitTestResult(ViewHit[] Results, ScreenPoint ScreenPoint)
{
    /// <summary>
    ///     Ground intersection result, only applies to SceneViews. The ground hit result will always be returned, even if the
    ///     ground was excluded from the hitTest.
    /// </summary>
    public GroundIntersectionResult? Ground { get; init; }
}

/// <summary>
///     Ground intersection result, only applies to SceneViews. The ground hit result will always be returned, even if the
///     ground was excluded from the hitTest.
/// </summary>
public record GroundIntersectionResult(Point MapPoint, double Distance);

/// <summary>
///     Object specification for the <see cref="HitTestResult.Results" />.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#ViewHit">
///         ArcGIS
///         JS API
///     </a>
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
///     A graphic representing a feature in the view that intersects the input screen coordinates. If the graphic comes
///     from a layer with an applied Renderer, then the symbol property will be empty. Other properties may be empty based
///     on the context in which the graphic is fetched. If the result comes from a VectorTileLayer then a static graphic is
///     returned with two attributes: layerId and layerName. These correspond to the name and id of the style-layer in the
///     vector tile style.
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

/// <summary>
///     Options to specify what is included in or excluded from the hitTest.
/// </summary>
public record HitTestOptions
{
    /// <summary>
    ///     A list of layers and/or graphics GeoBlazor Ids (Guid) to include in the hitTest. All layers and graphics will be
    ///     included if include is not specified.
    /// </summary>
    public IEnumerable<Guid>? IncludeByGeoBlazorId { get; set; }

    /// <summary>
    ///     A list of layer ArcGIS Ids (aka FIELDID or OBJECTID) to include in the hitTest. All layers and graphics will be
    ///     included if include is not specified.
    /// </summary>
    public IEnumerable<string>? IncludeLayersByArcGISId { get; set; }

    /// <summary>
    ///     A list of graphic ArcGIS OBJECTID attributes to include in the hitTest. All layers and graphics will be included if
    ///     include is not specified.
    /// </summary>
    public IEnumerable<string>? IncludeGraphicsByArcGISId { get; set; }

    /// <summary>
    ///     A list of layers and/or graphics GeoBlazor Ids (Guid) to exclude from the hitTest. No layers or graphics will be
    ///     excluded if exclude is not specified.
    /// </summary>
    public IEnumerable<Guid>? ExcludeByGeoBlazorId { get; set; }

    /// <summary>
    ///     A list of layer ArcGIS Ids (aka FIELDID or OBJECTID) to exclude in the hitTest. No layers and graphics will be
    ///     excluded if exclude is not specified.
    /// </summary>
    public IEnumerable<string>? ExcludeLayersByArcGISId { get; set; }

    /// <summary>
    ///     A list of graphic ArcGIS OBJECTID attributes to exclude in the hitTest. No layers and graphics will be excluded if
    ///     exclude is not specified.
    /// </summary>
    public IEnumerable<string>? ExcludeGraphicsByArcGISId { get; set; }
}

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