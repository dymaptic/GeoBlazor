namespace dymaptic.GeoBlazor.Pro.Model;

using System.Text.Json;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html">GeoBlazor Docs</a>
///     Executes different types of query operations on a layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class QueryService : ProLogicComponent
{

    /// <summary>
    ///      Constructor for use by Dependency Injection. Use <see cref="DependencyExtension.AddGeoBlazorPro"/> in your startup code.
    /// </summary>
    public QueryService(AuthenticationManager authenticationManager, JsModuleManager jsModuleManager, 
        IAppValidator appValidator, IJSRuntime jsRuntime): base(authenticationManager, jsModuleManager, appValidator, 
        jsRuntime)
    {
    }
    
    /// <inheritdoc />
    protected override string ComponentName => nameof(QueryService);
    /// <inheritdoc/>
    protected override string Library => "Pro";
    
    /// <summary>
    ///     The maximum size of query results that will be returned in a stream. Note that setting this to a smaller value might create errors in query returns.
    /// </summary>
    public long QueryResultsMaxSizeLimit { get; set; } = 1_000_000_000L;

#region Public Methods

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecuteattachmentquery-method">GeoBlazor Docs</a>
    ///     Query information about attachments associated with features from a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">feature layer</a> specified in the url parameter.
    ///     param attachmentQuery Specifies the attachment parameters for query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeAttachmentQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="attachmentQuery">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<AttachmentsQueryResult?> ExecuteAttachmentQuery(string url,
        AttachmentQuery attachmentQuery,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<AttachmentsQueryResult?>("executeAttachmentQuery", cancellationToken, url, 
            attachmentQuery, requestOptions);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecuteforcount-method">GeoBlazor Docs</a>
    ///     Gets a count of the number of features that satisfy the input query.
    ///     param query Specifies the attributes and spatial filter of the query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeForCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="query">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<int?> ExecuteForCount(string url,
        Query query,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<int?>("executeForCount", cancellationToken, url, query, requestOptions);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecuteforextent-method">GeoBlazor Docs</a>
    ///     Gets the extent of the features that satisfy the input query.
    ///     param query Specifies the attributes and spatial filter of the query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeForExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="query">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<ExtentQueryResult?> ExecuteForExtent(string url,
        Query query,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        _extentQueryResult = null;
        await InvokeAsync<ExtentQueryResult?>("executeForExtent", cancellationToken, url, query, requestOptions);
        return _extentQueryResult;
    }
    
    /// <summary>
    ///     JS-Invoked response handler for the ExecuteForExtent request.
    /// </summary>
    [JSInvokable]
    public async Task OnExecuteForExtent(IJSStreamReference jsStreamReference)
    {
        _extentQueryResult = await jsStreamReference.ReadJsStreamReference<ExtentQueryResult>(QueryResultsMaxSizeLimit);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecuteforids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer specified in the url parameter.
    ///     param query Specifies the attributes and spatial filter of the query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeForIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="query">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<long[]?> ExecuteForIds(string url,
        Query query,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<long[]?>("executeForIds", cancellationToken, url, query, requestOptions);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecutefortopcount-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html">TopFeaturesQuery</a> against a feature service and returns
    ///     the count of features or records that satisfy the query.
    ///     param topFeaturesQuery Specifies the attributes, spatial, temporal, and top filter of the query. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html#topFilter">topFilter</a> parameter must be set.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeForTopCount">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="topFeaturesQuery">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<int?> ExecuteForTopCount(string url,
        TopFeaturesQuery topFeaturesQuery,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<int?>("executeForTopCount", cancellationToken, url, topFeaturesQuery, 
            requestOptions);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecutefortopextents-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html">TopFeaturesQuery</a> against a feature service and returns
    ///     the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of features that satisfy the query.
    ///     param topFeaturesQuery Specifies the attributes, spatial, temporal, and top filter of the query. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html#topFilter">topFilter</a> parameter must be set.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeForTopExtents">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="topFeaturesQuery">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<ExtentQueryResult?> ExecuteForTopExtents(string url,
        TopFeaturesQuery topFeaturesQuery,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        _topExtentQueryResult = null;
        await InvokeAsync<ExtentQueryResult?>("executeForTopExtents", cancellationToken, url, topFeaturesQuery, requestOptions);
        return _topExtentQueryResult;
    }
    
    /// <summary>
    ///     JS-Invoked response handler for the ExecuteForTopExtents request.
    /// </summary>
    [JSInvokable]
    public async Task OnExecuteForTopExtents(IJSStreamReference jsStreamReference)
    {
        _topExtentQueryResult = await jsStreamReference.ReadJsStreamReference<ExtentQueryResult>(QueryResultsMaxSizeLimit);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecutefortopids-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html">TopFeaturesQuery</a> against a feature service and returns an
    ///     array of Object IDs of features that satisfy the query.
    ///     param topFeaturesQuery Specifies the attributes, spatial, temporal, and top filter of the query. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html#topFilter">topFilter</a> parameter must be set.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeForTopIds">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="topFeaturesQuery">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<long[]?> ExecuteForTopIds(string url,
        TopFeaturesQuery topFeaturesQuery,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        return await InvokeAsync<long[]?>("executeForTopIds", cancellationToken, url, topFeaturesQuery, requestOptions);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecutequeryjson-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer specified in the url parameter.
    ///     param query Specifies the attributes and spatial filter of the query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeQueryJSON">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="query">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<FeatureSet?> ExecuteQueryJSON(string url,
        Query query,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        _featureSetJson = null;
        await InvokeAsync<FeatureSet?>("executeQueryJSON", cancellationToken, url, query, requestOptions);
        return _featureSetJson;
    }
    
    /// <summary>
    ///     JS-Invoked response handler for the ExecuteQueryJSON request.
    /// </summary>
    [JSInvokable]
    public async Task OnExecuteQueryJSON(IJSStreamReference jsStreamReference)
    {
        _featureSetJson = await jsStreamReference.ReadJsStreamReference<FeatureSet>(QueryResultsMaxSizeLimit);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecutequerypbf-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html">Query</a> against the layer specified in the url parameter.
    ///     param query Specifies the attributes and spatial filter of the query.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeQueryPBF">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="query">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<FeatureSet?> ExecuteQueryPBF(string url,
        Query query,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        _featureSetPbf = null;
        await InvokeAsync<FeatureSet?>("executeQueryPBF", cancellationToken, url, query, requestOptions);
        return _featureSetPbf;
    }
    
    /// <summary>
    ///     JS-Invoked response handler for the ExecuteQueryPBF request.
    /// </summary>
    [JSInvokable]
    public async Task OnExecuteQueryPBF(IJSStreamReference jsStreamReference)
    {
        _featureSetPbf = await jsStreamReference.ReadJsStreamReference<FeatureSet>(QueryResultsMaxSizeLimit);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecuterelationshipquery-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-RelationshipQuery.html">RelationshipQuery</a> against the layer or table specified in the url parameter.
    ///     param relationshipQuery Specifies relationship parameters for querying related features or records from a layer or a table.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeRelationshipQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="relationshipQuery">
    /// </param>
    /// <param name="requestOptions">
    ///     Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<RelatedFeaturesQueryResult?> ExecuteRelationshipQuery(string url,
        RelationshipQuery relationshipQuery,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        _relatedFeaturesQueryResult = null;
        await InvokeAsync<RelatedFeaturesQueryResult?>("executeRelationshipQuery", cancellationToken, url, 
            relationshipQuery, requestOptions);
        return _relatedFeaturesQueryResult;
    }
    
    /// <summary>
    ///     JS-Invoked response handler for the ExecuteRelationshipQuery request.
    /// </summary>
    [JSInvokable]
    public async Task OnExecuteRelationshipQuery(IJSStreamReference jsStreamReference)
    {
        _relatedFeaturesQueryResult = await jsStreamReference.ReadJsStreamReference<RelatedFeaturesQueryResult>(QueryResultsMaxSizeLimit);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.QueryService.html#queryserviceexecutetopfeaturesquery-method">GeoBlazor Docs</a>
    ///     Executes a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html">TopFeaturesQuery</a> against a feature service and returns a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">FeatureSet</a> once the promise resolves.
    ///     param topFeaturesQuery Specifies the attributes, spatial, temporal, and top filter of the query. The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFeaturesQuery.html#topFilter">topFilter</a> parameter must be set.
    ///     param requestOptions Additional <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#request">options</a> to be used for the data request.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-query.html#executeTopFeaturesQuery">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="url">
    ///     URL to the ArcGIS Server REST resource that represents a feature layer (usually of a Feature Service Layer or Map Service Layer).
    /// </param>
    /// <param name="topFeaturesQuery">
    /// </param>
    /// <param name="outSpatialReference">
    ///     The desired output spatial reference.
    /// </param>
    /// <param name="requestOptions">
    /// </param>
    /// <param name="cancellationToken">
    ///     The CancellationToken to cancel an asynchronous operation.
    /// </param>
    [ArcGISMethod]
    public async Task<FeatureSet?> ExecuteTopFeaturesQuery(string url,
        TopFeaturesQuery topFeaturesQuery,
        SpatialReference outSpatialReference,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
    {
        _featureSetTopFeatures = null;
        await InvokeAsync<FeatureSet?>("executeTopFeaturesQuery", cancellationToken, url, topFeaturesQuery, 
            outSpatialReference, requestOptions);
        return _featureSetTopFeatures;
    }
    
    /// <summary>
    ///     JS-Invoked response handler for the ExecuteTopFeaturesQuery request.
    /// </summary>
    [JSInvokable]
    public async Task OnExecuteTopFeaturesQuery(IJSStreamReference jsStreamReference)
    {
        _featureSetTopFeatures = await jsStreamReference.ReadJsStreamReference<FeatureSet>(QueryResultsMaxSizeLimit);
    }
    
#endregion

    private ExtentQueryResult? _extentQueryResult;
    private ExtentQueryResult? _topExtentQueryResult;
    private FeatureSet? _featureSetJson;
    private FeatureSet? _featureSetPbf;
    private RelatedFeaturesQueryResult? _relatedFeaturesQueryResult;
    private FeatureSet? _featureSetTopFeatures;
}
