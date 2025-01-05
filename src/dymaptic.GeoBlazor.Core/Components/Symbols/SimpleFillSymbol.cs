namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleFillSymbol is used for rendering 2D polygons in either a MapView or a SceneView. It can be filled with a
///     solid color, or a pattern. In addition, the symbol can have an optional outline, which is defined by a
///     SimpleLineSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleFillSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SimpleFillSymbol : FillSymbol
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SimpleFillSymbol()
    {
    }

    /// <summary>
    ///     Constructs a new SimpleFillSymbol in code with parameters
    /// </summary>
    /// <param name="outline">
    ///     The outline of the polygon.
    /// </param>
    /// <param name="color">
    ///     The color of the polygon.
    /// </param>
    /// <param name="style">
    ///     The fill style.
    /// </param>
    public SimpleFillSymbol(Outline? outline = null, MapColor? color = null, SimpleFillSymbolStyle? style = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Outline = outline;
        Color = color;
        Style = style;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The fill style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public SimpleFillSymbolStyle? Style { get; set; }

    /// <inheritdoc />
    public override SymbolType Type => SymbolType.SimpleFill;

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (!outline.Equals(Outline))
                {
                    Outline = outline;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline _:
                Outline = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Outline?.ValidateRequiredChildren();
    }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type.ToString().ToKebabCase(), Color)
        {
            Outline = Outline?.ToSerializationRecord(), 
            Style = Style?.ToString().ToKebabCase()
        };
    }
}