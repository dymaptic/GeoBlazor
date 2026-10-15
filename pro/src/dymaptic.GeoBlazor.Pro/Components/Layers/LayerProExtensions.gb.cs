namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the Layer class.
/// </summary>
public static partial class LayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.Layer.html#layercancelload-method">GeoBlazor Docs</a>
    ///     Cancels a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#load">load()</a> operation if it is already in progress.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#cancelLoad">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="layer">
    ///     The <see cref="Layer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task CancelLoad(this Layer layer)
    {
        if (layer.CoreJsModule is null)
        {
            return;
        }
        
        try 
        {
            layer.JsComponentReference ??= await layer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", layer.CancellationTokenSource.Token, layer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (layer.JsComponentReference is null)
        {
            return;
        }
        
        await layer.JsComponentReference!.InvokeVoidAsync(
            "cancelLoad", 
            layer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.Layer.html#layercreatelayerview-method">GeoBlazor Docs</a>
    ///     Called by the views, such as <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a> and
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>, when the layer is added to the
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Map.html#layers">Map.layers</a> collection and a layer view must
    ///     be created for it.
    ///     param options An object specifying additional options. See the object specification table below for the required properties of this object.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#createLayerView">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="layer">
    ///     The <see cref="Layer"/> instance to extend with this method.
    /// </param>
    /// <param name="view">
    ///     The parent view.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<LayerView?> CreateLayerView(this Layer layer,
        string view,
        CancellationToken cancellationToken = default)
    {
        if (layer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            layer.JsComponentReference ??= await layer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", layer.CancellationTokenSource.Token, layer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (layer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await layer.AbortManager!.CreateAbortSignal(cancellationToken);
        LayerView? result = await layer.JsComponentReference!.InvokeAsync<LayerView?>(
            "createLayerView", 
            layer.CancellationTokenSource.Token,
            view,
            abortSignal);
                
        await layer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.Layer.html#layerfetchattributiondata-method">GeoBlazor Docs</a>
    ///     Fetches custom attribution data for the layer when it becomes available.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#fetchAttributionData">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="layer">
    ///     The <see cref="Layer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> FetchAttributionData(this Layer layer)
    {
        if (layer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            layer.JsComponentReference ??= await layer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", layer.CancellationTokenSource.Token, layer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (layer.JsComponentReference is null)
        {
            return null;
        }
        
        return await layer.JsComponentReference!.InvokeAsync<string?>(
            "fetchAttributionData", 
            layer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.Layer.html#layerisfulfilled-method">GeoBlazor Docs</a>
    ///     `isFulfilled()` may be used to verify if creating an instance of the class is fulfilled (either resolved or rejected).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#isFulfilled">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="layer">
    ///     The <see cref="Layer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<bool?> IsFulfilled(this Layer layer)
    {
        if (layer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            layer.JsComponentReference ??= await layer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", layer.CancellationTokenSource.Token, layer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (layer.JsComponentReference is null)
        {
            return null;
        }
        
        return await layer.JsComponentReference!.InvokeAsync<bool?>(
            "isFulfilled", 
            layer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.Layer.html#layerisrejected-method">GeoBlazor Docs</a>
    ///     `isRejected()` may be used to verify if creating an instance of the class is rejected.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#isRejected">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="layer">
    ///     The <see cref="Layer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<bool?> IsRejected(this Layer layer)
    {
        if (layer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            layer.JsComponentReference ??= await layer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", layer.CancellationTokenSource.Token, layer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (layer.JsComponentReference is null)
        {
            return null;
        }
        
        return await layer.JsComponentReference!.InvokeAsync<bool?>(
            "isRejected", 
            layer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.Layer.html#layerisresolved-method">GeoBlazor Docs</a>
    ///     `isResolved()` may be used to verify if creating an instance of the class is resolved.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#isResolved">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="layer">
    ///     The <see cref="Layer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<bool?> IsResolved(this Layer layer)
    {
        if (layer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            layer.JsComponentReference ??= await layer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", layer.CancellationTokenSource.Token, layer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (layer.JsComponentReference is null)
        {
            return null;
        }
        
        return await layer.JsComponentReference!.InvokeAsync<bool?>(
            "isResolved", 
            layer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.Layer.html#layerwhen-method">GeoBlazor Docs</a>
    ///     `when()` may be leveraged once an instance of the class is created.
    ///     param onRejected The function to execute when the promise fails.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#when">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="layer">
    ///     The <see cref="Layer"/> instance to extend with this method.
    /// </param>
    /// <param name="onFulfilled">
    ///     The function to call when the promise resolves.
    /// </param>
    /// <param name="onRejected">
    /// </param>
    [ArcGISMethod]
    public static async Task<string?> When(this Layer layer,
        Func<Task> onFulfilled,
        Func<Task> onRejected)
    {
        if (layer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            layer.JsComponentReference ??= await layer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", layer.CancellationTokenSource.Token, layer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (layer.JsComponentReference is null)
        {
            return null;
        }
        
        return await layer.JsComponentReference!.InvokeAsync<string?>(
            "when", 
            layer.CancellationTokenSource.Token,
            onFulfilled,
            onRejected);
    }
    

}