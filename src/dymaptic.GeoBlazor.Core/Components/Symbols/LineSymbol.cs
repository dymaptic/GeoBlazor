using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Abstract class. Line symbols are used to draw Polyline features in a FeatureLayer in a 2D MapView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbol.html">ArcGIS JS API</a>
/// </summary>
public abstract class LineSymbol : Symbol
{
    /// <summary>
    ///     The width of the symbol in points.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public double? Width { get; set; }
}