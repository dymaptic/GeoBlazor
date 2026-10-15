namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Pro Extension methods for the CSVLayer class.
/// </summary>
public static partial class CSVLayerProExtensions
{
        /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayercreatepopuptemplate-method">GeoBlazor Docs</a>
    ///     Creates a popup template for the layer, populated with all the fields of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#createPopupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    [ArcGISMethod]
    public static async Task<PopupTemplate?> CreatePopupTemplate(this CSVLayer cSVLayer,
        CreatePopupTemplateOptions options)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await cSVLayer.JsComponentReference!.InvokeAsync<PopupTemplate?>(
            "createPopupTemplate", 
            cSVLayer.CancellationTokenSource.Token,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayercreatequery-method">GeoBlazor Docs</a>
    ///     Creates query parameters that can be used to fetch features that
    ///     satisfy the layer's current filters, and definitions.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#createQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    [ArcGISMethod]
    public static async Task<Query?> CreateQuery(this CSVLayer cSVLayer)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await cSVLayer.JsComponentReference!.InvokeAsync<Query?>(
            "createQuery", 
            cSVLayer.CancellationTokenSource.Token);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayergetfield-method">GeoBlazor Docs</a>
    ///     Returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Field.html">Field</a> instance for a field name (case-insensitive).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#getField">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="fieldName">
    ///     Name of the field.
    /// </param>
    [ArcGISMethod]
    public static async Task<Field?> GetField(this CSVLayer cSVLayer,
        string fieldName)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await cSVLayer.JsComponentReference!.InvokeAsync<Field?>(
            "getField", 
            cSVLayer.CancellationTokenSource.Token,
            fieldName);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayergetfielddomain-method">GeoBlazor Docs</a>
    ///     Returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html">Domain</a> associated with the given field name.
    ///     param options An object specifying additional options. See the object specification table below for the required properties of this object.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#getFieldDomain">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="fieldName">
    ///     Name of the field.
    /// </param>
    /// <param name="options">
    ///     An object specifying additional options. See the
    ///     object specification table below for the required properties of this object.
    /// </param>
    [ArcGISMethod]
    public static async Task<Domain?> GetFieldDomain(this CSVLayer cSVLayer,
        string fieldName,
        CSVLayerGetFieldDomainOptions options)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        return await cSVLayer.JsComponentReference!.InvokeAsync<Domain?>(
            "getFieldDomain", 
            cSVLayer.CancellationTokenSource.Token,
            fieldName,
            options);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayerqueryattributebins-method">GeoBlazor Docs</a>
    ///     Executes an <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html">AttributeBinsQuery</a> against a CSVLayer, which groups features into bins based on ranges in numeric or date fields, and returns an
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsFeatureSet.html">AttributeBinsFeatureSet</a> containing the series of bins.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#queryAttributeBins">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="binsQuery">
    ///     Specifies the parameters of the `queryAttributeBins()` operation. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-AttributeBinsQuery.html#binParameters">binParameters</a> property must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<AttributeBinsFeatureSet?> QueryAttributeBins(this CSVLayer cSVLayer,
        AttributeBinsQuery binsQuery,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        AttributeBinsFeatureSet? result = await cSVLayer.JsComponentReference!.InvokeAsync<AttributeBinsFeatureSet?>(
            "queryAttributeBins", 
            cSVLayer.CancellationTokenSource.Token,
            binsQuery,
            abortSignal);
                
        await cSVLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayerqueryextent-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the CSV data and
    ///     returns the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#queryExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ExtentQueryResult?> QueryExtent(this CSVLayer cSVLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await cSVLayer.JsComponentReference!.InvokeAsync<ExtentQueryResult?>(
            "queryExtent", 
            cSVLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayerqueryfeaturecount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the CSV data and
    ///     returns the number of features that satisfy the query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#queryFeatureCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<int?> QueryFeatureCount(this CSVLayer cSVLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await cSVLayer.JsComponentReference!.InvokeAsync<int?>(
            "queryFeatureCount", 
            cSVLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayerqueryfeatures-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the CSV data and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a> once the promise resolves.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#queryFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<FeatureSet?> QueryFeatures(this CSVLayer cSVLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet? result = await cSVLayer.JsComponentReference!.InvokeAsync<FeatureSet?>(
            "queryFeatures", 
            cSVLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.CSVLayer.html#csvlayerqueryobjectids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the CSV data and returns an
    ///     array of Object IDs for features that satisfy the input query.
    ///     param options An object with the following properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-CSVLayer.html#queryObjectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="cSVLayer">
    ///     The <see cref="CSVLayer"/> instance to extend with this method.
    /// </param>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the `geometry` parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public static async Task<ObjectId[]?> QueryObjectIds(this CSVLayer cSVLayer,
        Query query,
        CancellationToken cancellationToken = default)
    {
        if (cSVLayer.CoreJsModule is null)
        {
            return null;
        }
        
        try 
        {
            cSVLayer.JsComponentReference ??= await cSVLayer.CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", cSVLayer.CancellationTokenSource.Token, cSVLayer.Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (cSVLayer.JsComponentReference is null)
        {
            return null;
        }
        
        IJSObjectReference abortSignal = await cSVLayer.AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[]? result = await cSVLayer.JsComponentReference!.InvokeAsync<ObjectId[]?>(
            "queryObjectIds", 
            cSVLayer.CancellationTokenSource.Token,
            query,
            abortSignal);
                
        await cSVLayer.AbortManager.DisposeAbortController(cancellationToken);
        
        return result;
    }
    

}