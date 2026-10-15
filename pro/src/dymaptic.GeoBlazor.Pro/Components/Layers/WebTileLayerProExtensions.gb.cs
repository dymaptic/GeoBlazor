namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the WebTileLayer class.
/// </summary>
public static partial class WebTileLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.html#webtilelayerfetchtile-method">GeoBlazor Docs</a>
    ///     This method fetches a tile for the given level, row and column present in the view.
    ///     param row The row(y) position of the tile fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    ///     param options Optional settings for the tile request. The options have the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WebTileLayer.html#fetchTile">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="webTileLayer">
    ///     The <see cref="WebTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     Level of detail of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="row">
    ///     The row(y) position of the tile fetch. This value is provided by <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="col">
    ///     The column(x) position of the tile to fetch. This value is provided by <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-LayerView.html">LayerView</a>.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ElementReference?> FetchTile(this WebTileLayer webTileLayer,
        double level,
        double row,
        double col,
        CancellationToken cancellationToken = default)
    {
        if (webTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            webTileLayer.JsComponentReference ??= await webTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", webTileLayer.CancellationTokenSource.Token, webTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (webTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await webTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ElementReference? result = await webTileLayer.JsComponentReference!.InvokeAsync<ElementReference?>(
            "fetchTile", 
            webTileLayer.CancellationTokenSource.Token,
            level,
            row,
            col,
            abortSignal);
                
        await webTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WebTileLayer.html#webtilelayergettileurl-method">GeoBlazor Docs</a>
    ///     This method returns a URL to a tile for a given level, row and column.
    ///     param row The requested tile's row.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WebTileLayer.html#getTileUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="webTileLayer">
    ///     The <see cref="WebTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     The requested tile's level.
    /// </param>
    /// <param name="row">
    ///     The requested tile's row.
    /// </param>
    /// <param name="col">
    ///     The requested tile's column.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetTileUrl(this WebTileLayer webTileLayer,
        double level,
        double row,
        double col)
    {
        if (webTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            webTileLayer.JsComponentReference ??= await webTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", webTileLayer.CancellationTokenSource.Token, webTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (webTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await webTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getTileUrl", 
            webTileLayer.CancellationTokenSource.Token,
            level,
            row,
            col);
    }
    

}