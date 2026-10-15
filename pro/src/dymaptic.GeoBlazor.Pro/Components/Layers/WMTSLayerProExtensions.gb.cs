namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the WMTSLayer class.
/// </summary>
public static partial class WMTSLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WMTSLayer.html#wmtslayerfetchtile-method">GeoBlazor Docs</a>
    ///     Requests a tile from the WMTS service.
    ///     param row The tile row.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMTSLayer.html#fetchTile">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wMTSLayer">
    ///     The <see cref="WMTSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="level">
    ///     The tile level.
    /// </param>
    /// <param name="row">
    ///     The tile row.
    /// </param>
    /// <param name="col">
    ///     The tile column.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ElementReference?> FetchTile(this WMTSLayer wMTSLayer,
        double level,
        double row,
        double col,
        CancellationToken cancellationToken = default)
    {
        if (wMTSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            wMTSLayer.JsComponentReference ??= await wMTSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wMTSLayer.CancellationTokenSource.Token, wMTSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wMTSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await wMTSLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ElementReference? result = await wMTSLayer.JsComponentReference!.InvokeAsync<ElementReference?>(
            "fetchTile", 
            wMTSLayer.CancellationTokenSource.Token,
            level,
            row,
            col,
            abortSignal);
                
        await wMTSLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WMTSLayer.html#wmtslayerfindsublayerbyid-method">GeoBlazor Docs</a>
    ///     Returns a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMTSSublayer.html">WMTSSublayer</a> based on the given sublayer id.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMTSLayer.html#findSublayerById">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wMTSLayer">
    ///     The <see cref="WMTSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="id">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMTSSublayer.html#id">id</a> of the WMTS sublayer.
    /// </param>
    [ArcGISMethod]
    public static async Task<WMTSSublayer?> FindSublayerById(this WMTSLayer wMTSLayer,
        string id)
    {
        if (wMTSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wMTSLayer.JsComponentReference ??= await wMTSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wMTSLayer.CancellationTokenSource.Token, wMTSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wMTSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wMTSLayer.JsComponentReference!.InvokeAsync<WMTSSublayer?>(
            "findSublayerById", 
            wMTSLayer.CancellationTokenSource.Token,
            id);
    }
    

}