namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the GeoJSONLayer class.
/// </summary>
public static partial class GeoJSONLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerapplyedits-method">GeoBlazor Docs</a>
    ///     Applies edits to features in a layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#applyEdits">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="edits">
    ///     Object containing features to be added, updated or deleted.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureEditsResult?> ApplyEdits(this GeoJSONLayer geoJSONLayer,
        GeoJSONLayerApplyEditsEdits edits)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await geoJSONLayer.JsComponentReference!.InvokeAsync<FeatureEditsResult?>(
            "applyEdits", 
            geoJSONLayer.CancellationTokenSource.Token,
            edits);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayercreatepopuptemplate-method">GeoBlazor Docs</a>
    ///     Creates a popup template for the layer, populated with all the fields of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#createPopupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    [ArcGISMethod]
    public static async Task<PopupTemplate?> CreatePopupTemplate(this GeoJSONLayer geoJSONLayer,
        CreatePopupTemplateOptions options)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await geoJSONLayer.JsComponentReference!.InvokeAsync<PopupTemplate?>(
            "createPopupTemplate", 
            geoJSONLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayercreatequery-method">GeoBlazor Docs</a>
    ///     Creates query parameter object that can be used to fetch features that
    ///     satisfy the layer's configurations such as <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#definitionExpression">definitionExpression</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#createQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateQuery(this GeoJSONLayer geoJSONLayer)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await geoJSONLayer.JsComponentReference!.InvokeAsync<Query?>(
            "createQuery", 
            geoJSONLayer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayergetfield-method">GeoBlazor Docs</a>
    ///     Returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Field.html">Field</a> instance for a field name (case-insensitive).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#getField">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="fieldName">
    ///     Name of the field.
    /// </param>
    [ArcGISMethod]
    public static async Task<Field?> GetField(this GeoJSONLayer geoJSONLayer,
        string fieldName)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await geoJSONLayer.JsComponentReference!.InvokeAsync<Field?>(
            "getField", 
            geoJSONLayer.CancellationTokenSource.Token,
            fieldName);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayergetfielddomain-method">GeoBlazor Docs</a>
    ///     Returns the Domain associated with the given field name.
    ///     param options An object specifying additional options. See the object specification table below for the required properties of this object.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#getFieldDomain">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="fieldName">
    ///     Name of the field.
    /// </param>
    /// <param name="options">
    ///     An object specifying additional options. See the
    ///     object specification table below for the required properties of this object.
    /// </param>
    [ArcGISMethod]
    public static async Task<Domain?> GetFieldDomain(this GeoJSONLayer geoJSONLayer,
        string fieldName,
        GeoJSONLayerGetFieldDomainOptions options)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await geoJSONLayer.JsComponentReference!.InvokeAsync<Domain?>(
            "getFieldDomain", 
            geoJSONLayer.CancellationTokenSource.Token,
            fieldName,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against a GeoJSONLayer, which groups features into bins based on ranges in numeric or date fields, and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this GeoJSONLayer geoJSONLayer,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await geoJSONLayer.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            geoJSONLayer.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await geoJSONLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerqueryextent-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and
    ///     returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#queryExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ExtentQueryResult?> QueryExtent(this GeoJSONLayer geoJSONLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await geoJSONLayer.JsComponentReference!.InvokeAsync<ExtentQueryResult?>(
            "queryExtent", 
            geoJSONLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerqueryfeaturecount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and
    ///     returns the number of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#queryFeatureCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> QueryFeatureCount(this GeoJSONLayer geoJSONLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await geoJSONLayer.JsComponentReference!.InvokeAsync<int?>(
            "queryFeatureCount", 
            geoJSONLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerqueryobjectids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer and returns an
    ///     array of Object IDs for features that satisfy the input query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#queryObjectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="geoJSONLayer">
    ///     The <see cref="GeoJSONLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the Object IDs of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ObjectId[]?> QueryObjectIds(this GeoJSONLayer geoJSONLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (geoJSONLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            geoJSONLayer.JsComponentReference ??= await geoJSONLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", geoJSONLayer.CancellationTokenSource.Token, geoJSONLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (geoJSONLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await geoJSONLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[]? result = await geoJSONLayer.JsComponentReference!.InvokeAsync<ObjectId[]?>(
            "queryObjectIds", 
            geoJSONLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await geoJSONLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    

}