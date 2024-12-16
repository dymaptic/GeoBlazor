using dymaptic.GeoBlazor.Core.Objects;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Abstract class. Line symbols are used to draw Polyline features in a FeatureLayer in a 2D MapView.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public abstract class LineSymbol : Symbol
{
    /// <summary>
    ///     The width of the symbol in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public Dimension? Width { get; set; }
}