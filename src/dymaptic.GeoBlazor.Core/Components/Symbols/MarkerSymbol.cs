namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Marker symbols are used to draw Point graphics in a FeatureLayer or individual graphics in a 2D MapView. To create
///     new marker symbols, use either SimpleMarkerSymbol or PictureMarkerSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-MarkerSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public abstract class MarkerSymbol : Symbol
{
    /// <summary>
    ///     The angle of the marker relative to the screen in degrees.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Angle { get; set; }

    /// <summary>
    ///     The offset on the x-axis in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? XOffset { get; set; }

    /// <summary>
    ///     The offset on the y-axis in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? YOffset { get; set; }
}