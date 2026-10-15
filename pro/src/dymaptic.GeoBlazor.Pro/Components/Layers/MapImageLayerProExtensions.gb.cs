namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the MapImageLayer class.
/// </summary>
public static partial class MapImageLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayercreateexportimageparameters-method">GeoBlazor Docs</a>
    ///     Gets the parameters of the exported image to use when calling the
    ///     <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/export-map.htm">export REST operation</a>.
    ///     param width The width of the exported image
    ///     param options The parameter options is an object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#createExportImageParameters">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="extent">
    ///     The extent of the exported image
    /// </param>
    /// <param name="width">
    ///     The width of the exported image
    /// </param>
    /// <param name="height">
    ///     The height of the exported image
    /// </param>
    /// <param name="options">
    ///     The parameter options is an object with the following properties.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> CreateExportImageParameters(this MapImageLayer mapImageLayer,
        Extent extent,
        int width,
        int height,
        MapImageLayerCreateExportImageParametersOptions options)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await mapImageLayer.JsComponentReference!.InvokeAsync<string?>(
            "createExportImageParameters", 
            mapImageLayer.CancellationTokenSource.Token,
            extent,
            width,
            height,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayercreateservicesublayers-method">GeoBlazor Docs</a>
    ///     Returns a deep clone of a map service's
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html">sublayers</a> as defined by the service.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#createServiceSublayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Sublayer[]?> CreateServiceSublayers(this MapImageLayer mapImageLayer)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await mapImageLayer.JsComponentReference!.InvokeAsync<Sublayer[]?>(
            "createServiceSublayers", 
            mapImageLayer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayerfindsublayerbyid-method">GeoBlazor Docs</a>
    ///     Returns the sublayer with the given layerId.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#findSublayerById">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="id">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#id">id</a> of the sublayer.
    /// </param>
    [ArcGISMethod]
    public static async Task<Sublayer?> FindSublayerById(this MapImageLayer mapImageLayer,
        long id)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await mapImageLayer.JsComponentReference!.InvokeAsync<Sublayer?>(
            "findSublayerById", 
            mapImageLayer.CancellationTokenSource.Token,
            id);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayerloadall-method">GeoBlazor Docs</a>
    ///     Loads all of the sublayers and subtables.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#loadAll">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<MapImageLayer?> LoadAll(this MapImageLayer mapImageLayer)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await mapImageLayer.JsComponentReference!.InvokeAsync<MapImageLayer?>(
            "loadAll", 
            mapImageLayer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayersave-method">GeoBlazor Docs</a>
    ///     Saves the layer to its existing portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a>
    ///     authenticated within the user's current session.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#save">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Various options for saving the layer.
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> Save(this MapImageLayer mapImageLayer,
        MapImageLayerSaveOptions options)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await mapImageLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "save", 
            mapImageLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.MapImageLayer.html#mapimagelayersaveas-method">GeoBlazor Docs</a>
    ///     Saves the layer to a new portal item in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html">Portal</a>
    ///     authenticated within the user's current session.
    ///     param options Various options for saving the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html#saveAs">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="mapImageLayer">
    ///     The <see cref="MapImageLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="portalItem">
    ///     The portal item to which the layer will be saved.
    /// </param>
    /// <param name="options">
    /// </param>
    [ArcGISMethod]
    public static async Task<PortalItem?> SaveAs(this MapImageLayer mapImageLayer,
        PortalItem portalItem,
        MapImageLayerSaveAsOptions options)
    {
        if (mapImageLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            mapImageLayer.JsComponentReference ??= await mapImageLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", mapImageLayer.CancellationTokenSource.Token, mapImageLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (mapImageLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await mapImageLayer.JsComponentReference!.InvokeAsync<PortalItem?>(
            "saveAs", 
            mapImageLayer.CancellationTokenSource.Token,
            portalItem,
            options);
    }
    

}