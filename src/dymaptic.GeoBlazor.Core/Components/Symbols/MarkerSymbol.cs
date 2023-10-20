using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


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
    ///     The offset on the x-axis in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? XOffset { get; set; }

    /// <summary>
    ///     The offset on the y-axis in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? YOffset { get; set; }
}