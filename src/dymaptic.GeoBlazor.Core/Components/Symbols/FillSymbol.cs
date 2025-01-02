namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     Fill symbols are used to draw Polygon graphics in a GraphicsLayer or a FeatureLayer in a 2D MapView. To create new
///     fill symbols, use either SimpleFillSymbol or PictureFillSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-FillSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public abstract class FillSymbol : Symbol
{
        
    /// <summary>
    ///     The outline of the polygon.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-FillSymbol.html#outline">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(OutlineConverter))]
    [CodeGenerationIgnore]
    public Outline? Outline { get; set; }
    
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
}