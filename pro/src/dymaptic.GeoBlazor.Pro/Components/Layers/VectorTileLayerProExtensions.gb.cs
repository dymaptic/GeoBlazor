namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the VectorTileLayer class.
/// </summary>
public static partial class VectorTileLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayerdeletestylelayer-method">GeoBlazor Docs</a>
    ///     Deletes the specified <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a> from the
    ///     VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#deleteStyleLayer">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> as specified in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task DeleteStyleLayer(this VectorTileLayer vectorTileLayer,
        string layerId)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return;
        }
        
        await vectorTileLayer.JsComponentReference!.InvokeVoidAsync(
            "deleteStyleLayer", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayergetlayoutproperties-method">GeoBlazor Docs</a>
    ///     Returns an instance of <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#layout-property">layout</a>
    ///     properties for the specified <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#getLayoutProperties">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetLayoutProperties(this VectorTileLayer vectorTileLayer,
        string layerId)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await vectorTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getLayoutProperties", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayergetpaintproperties-method">GeoBlazor Docs</a>
    ///     Returns an instance of <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#paint">paint</a> properties for the specified
    ///     <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#getPaintProperties">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetPaintProperties(this VectorTileLayer vectorTileLayer,
        string layerId)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await vectorTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getPaintProperties", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayergetstylelayer-method">GeoBlazor Docs</a>
    ///     Returns an instance of a <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers">style layer</a>
    ///     from the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#getStyleLayer">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> specified in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetStyleLayer(this VectorTileLayer vectorTileLayer,
        string layerId)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await vectorTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getStyleLayer", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayergetstylelayerid-method">GeoBlazor Docs</a>
    ///     Returns the layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a>
    ///     of the <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers">style layer</a>
    ///     based on its index.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#getStyleLayerId">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="index">
    ///     Index of the style layer in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetStyleLayerId(this VectorTileLayer vectorTileLayer,
        int index)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await vectorTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getStyleLayerId", 
            vectorTileLayer.CancellationTokenSource.Token,
            index);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayergetstylelayerindex-method">GeoBlazor Docs</a>
    ///     Returns the index of the <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers">style layer</a> from the VectorTileLayer's
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#getStyleLayerIndex">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">style layer id</a> as specified in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> GetStyleLayerIndex(this VectorTileLayer vectorTileLayer,
        string layerId)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await vectorTileLayer.JsComponentReference!.InvokeAsync<int?>(
            "getStyleLayerIndex", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayergetstylelayervisibility-method">GeoBlazor Docs</a>
    ///     Gets the visibility of the specified <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a> from the
    ///     VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#getStyleLayerVisibility">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> as specified in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> GetStyleLayerVisibility(this VectorTileLayer vectorTileLayer,
        string layerId)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await vectorTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "getStyleLayerVisibility", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayerloadstyle-method">GeoBlazor Docs</a>
    ///     Loads a style to render a layer from the specified URL to a style resource or style JSON object.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#loadStyle">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="style">
    ///     The URL to a style of vector tiles or style JSON object.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> LoadStyle(this VectorTileLayer vectorTileLayer,
        string style,
        CancellationToken cancellationToken = default)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await vectorTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        string? result = await vectorTileLayer.JsComponentReference!.InvokeAsync<string?>(
            "loadStyle", 
            vectorTileLayer.CancellationTokenSource.Token,
            style,
            abortSignal);
                
        await vectorTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayersetlayoutproperties-method">GeoBlazor Docs</a>
    ///     Updates the <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#layout-property">layout</a> properties to the specified
    ///     <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a>.
    ///     param layout An instance of layout properties to assign to the style layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#setLayoutProperties">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    /// <param name="layout">
    ///     An instance of layout properties to assign to the style layer.
    /// </param>
    [ArcGISMethod]
    public static async Task SetLayoutProperties(this VectorTileLayer vectorTileLayer,
        string layerId,
        string layout)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return;
        }
        
        await vectorTileLayer.JsComponentReference!.InvokeVoidAsync(
            "setLayoutProperties", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId,
            layout);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayersetpaintproperties-method">GeoBlazor Docs</a>
    ///     Updates the <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#paint">paint</a> properties to the specified
    ///     <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers">style layer</a>.
    ///     param painter An instance of paint properties to assign to the specified style layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#setPaintProperties">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    /// <param name="painter">
    ///     An instance of paint properties to assign to the specified style layer.
    /// </param>
    [ArcGISMethod]
    public static async Task SetPaintProperties(this VectorTileLayer vectorTileLayer,
        string layerId,
        string painter)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return;
        }
        
        await vectorTileLayer.JsComponentReference!.InvokeVoidAsync(
            "setPaintProperties", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId,
            painter);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayersetspritesource-method">GeoBlazor Docs</a>
    ///     Changes the sprite source associated with the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">current style</a>.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#setSpriteSource">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="spriteSourceInfo">
    ///     The sprite source info is used to set the sprites in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>. The user can set the sprite source from a URL to fetch the sprite resources or from the image info to set the sprite resources directly on the layer.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<SpriteSource?> SetSpriteSource(this VectorTileLayer vectorTileLayer,
        Object spriteSourceInfo,
        CancellationToken cancellationToken = default)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await vectorTileLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        SpriteSource? result = await vectorTileLayer.JsComponentReference!.InvokeAsync<SpriteSource?>(
            "setSpriteSource", 
            vectorTileLayer.CancellationTokenSource.Token,
            spriteSourceInfo,
            abortSignal);
                
        await vectorTileLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayersetstylelayer-method">GeoBlazor Docs</a>
    ///     Changes the layer properties of the specified <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a>.
    ///     param index Index of the style layer in the style. Set this parameter when adding a new style layer or re-ordering a style layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#setStyleLayer">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layer">
    ///     The <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a> specified in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>. Get an instance of a style layer from a loaded style using <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#getStyleLayer">getStyleLayer</a> method.
    /// </param>
    /// <param name="index">
    ///     Index of the style layer in the style. Set this parameter when adding a new style layer or re-ordering a style layer.
    /// </param>
    [ArcGISMethod]
    public static async Task SetStyleLayer(this VectorTileLayer vectorTileLayer,
        string layer,
        int index)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return;
        }
        
        await vectorTileLayer.JsComponentReference!.InvokeVoidAsync(
            "setStyleLayer", 
            vectorTileLayer.CancellationTokenSource.Token,
            layer,
            index);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.VectorTileLayer.html#vectortilelayersetstylelayervisibility-method">GeoBlazor Docs</a>
    ///     Toggles the visibility of the specified <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/">style layer</a> in the
    ///     VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    ///     param visibility Set this parameter to `"none"` to hide the style layer or to `"visible"` to show the style layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#setStyleLayerVisibility">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="vectorTileLayer">
    ///     The <see cref="VectorTileLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="layerId">
    ///     The style layer <a target="_blank" href="https://maplibre.org/maplibre-style-spec/layers/#id">id</a> as specified in the VectorTileLayer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-VectorTileLayer.html#currentStyleInfo">currentStyleInfo.style</a>.
    /// </param>
    /// <param name="visibility">
    ///     Set this parameter to <code>"none"</code> to hide the style layer or to <code>"visible"</code> to show the style layer.
    /// </param>
    [ArcGISMethod]
    public static async Task SetStyleLayerVisibility(this VectorTileLayer vectorTileLayer,
        string layerId,
        Visibility visibility)
    {
        if (vectorTileLayer.CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            vectorTileLayer.JsComponentReference ??= await vectorTileLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", vectorTileLayer.CancellationTokenSource.Token, vectorTileLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (vectorTileLayer.JsComponentReference is null)
        {
            return;
        }
        
        await vectorTileLayer.JsComponentReference!.InvokeVoidAsync(
            "setStyleLayerVisibility", 
            vectorTileLayer.CancellationTokenSource.Token,
            layerId,
            visibility);
    }
    

}