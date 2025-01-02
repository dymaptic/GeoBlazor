namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleLineSymbol is used for rendering 2D polyline geometries in a 2D MapView. SimpleLineSymbol is also used for
///     rendering outlines for marker symbols and fill symbols.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SimpleLineSymbol : LineSymbol
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SimpleLineSymbol()
    {
    }

    /// <summary>
    ///     Constructs a new SimpleLineSymbol in code with parameters
    /// </summary>
    /// <param name="color">
    ///     The color of the line symbol.
    /// </param>
    /// <param name="width">
    ///     The width of the line symbol in points.
    /// </param>
    /// <param name="style">
    ///     The line style.
    /// </param>
    public SimpleLineSymbol(MapColor? color = null, double? width = null, SimpleLineSymbolStyle? style = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Color = color;
        Width = width;
        Style = style;
#pragma warning restore BL0005
    }
    
    /// <inheritdoc />
    public override string Type => "simple-line";

    /// <summary>
    ///     Specifies the line style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public SimpleLineSymbolStyle? Style { get; set; }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type, Color)
        {
            Width = Width?.Points, 
            Style = Style?.ToString().ToKebabCase()
        };
    }
}