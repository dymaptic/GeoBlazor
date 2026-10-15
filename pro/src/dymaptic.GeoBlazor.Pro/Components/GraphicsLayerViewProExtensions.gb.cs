namespace dymaptic.GeoBlazor.Pro.Components;

/// <summary>
///     Pro Extension methods for the GraphicsLayerView class.
/// </summary>
public static partial class GraphicsLayerViewProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.GraphicsLayerView.html#graphicslayerviewquerygraphics-method">GeoBlazor Docs</a>
    ///     Returns all graphics available for drawing in the layer view
    ///     as a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-Collection.html">collection</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-GraphicsLayerView.html#queryGraphics">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="graphicsLayerView">
    ///     The <see cref="GraphicsLayerView"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Graphic[]?> QueryGraphics(this GraphicsLayerView graphicsLayerView)
    {
        if (graphicsLayerView.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            graphicsLayerView.JsComponentReference ??= await graphicsLayerView.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", graphicsLayerView.CancellationTokenSource.Token, graphicsLayerView.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (graphicsLayerView.JsComponentReference is null)
        {
            return null;
        }
        
        return await graphicsLayerView.JsComponentReference!.InvokeAsync<Graphic[]?>(
            "queryGraphics", 
            graphicsLayerView.CancellationTokenSource.Token);
    }
    

}