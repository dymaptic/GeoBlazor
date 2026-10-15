namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the WMSLayer class.
/// </summary>
public static partial class WMSLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WMSLayer.html#wmslayerfindsublayerbyid-method">GeoBlazor Docs</a>
    ///     Returns a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMSSublayer.html">WMSSublayer</a> based on the given sublayer id.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMSLayer.html#findSublayerById">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wMSLayer">
    ///     The <see cref="WMSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="id">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMSSublayer.html#id">id</a> of the WMS sublayer.
    /// </param>
    [ArcGISMethod]
    public static async Task<WMSSublayer?> FindSublayerById(this WMSLayer wMSLayer,
        long id)
    {
        if (wMSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wMSLayer.JsComponentReference ??= await wMSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wMSLayer.CancellationTokenSource.Token, wMSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wMSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wMSLayer.JsComponentReference!.InvokeAsync<WMSSublayer?>(
            "findSublayerById", 
            wMSLayer.CancellationTokenSource.Token,
            id);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WMSLayer.html#wmslayerfindsublayerbyname-method">GeoBlazor Docs</a>
    ///     Returns a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMSSublayer.html">WMSSublayer</a> based on the given sublayer name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMSLayer.html#findSublayerByName">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="wMSLayer">
    ///     The <see cref="WMSLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="name">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMSSublayer.html#name">name</a> of the WMS sublayer.
    /// </param>
    [ArcGISMethod]
    public static async Task<WMSSublayer?> FindSublayerByName(this WMSLayer wMSLayer,
        string name)
    {
        if (wMSLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            wMSLayer.JsComponentReference ??= await wMSLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", wMSLayer.CancellationTokenSource.Token, wMSLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (wMSLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await wMSLayer.JsComponentReference!.InvokeAsync<WMSSublayer?>(
            "findSublayerByName", 
            wMSLayer.CancellationTokenSource.Token,
            name);
    }
    

}