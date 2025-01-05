namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The FeatureLayerView is responsible for rendering a FeatureLayer's features as graphics in the View. The methods in the FeatureLayerView provide developers with the ability to query and highlight graphics in the view. See the code snippets in the methods below for examples of how to access client-side graphics from the view.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#whenLayerView">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FeatureLayerView : LayerView
{
    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="layerView">
    /// </param>
    /// <param name="abortManager">
    /// </param>
    /// <param name="featureEffect">
    ///     The featureEffect can be used to draw attention features of interest.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerViewMixin.html#featureEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="filter">
    ///     The [attribute](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#where), [geometry](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#geometry), and [time extent](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#timeExtent) filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerViewMixin.html#filter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="highlightOptions">
    ///     Options for configuring the highlight.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-HighlightLayerViewMixin.html#highlightOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maximumNumberOfFeatures">
    ///     The maximum number of features that can be displayed at a time.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerViewMixin.html#maximumNumberOfFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maximumNumberOfFeaturesExceeded">
    ///     Signifies whether the maximum number of features has been exceeded.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerViewMixin.html#maximumNumberOfFeaturesExceeded">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    internal FeatureLayerView(
        LayerView layerView,
        AbortManager abortManager,
        FeatureEffect? featureEffect = null,
        FeatureFilter? filter = null,
        HighlightOptions? highlightOptions = null,
        double? maximumNumberOfFeatures = null,
        bool? maximumNumberOfFeaturesExceeded = null)
    {
#pragma warning disable BL0005
        JsObjectReference = layerView.JsObjectReference;
        SpatialReferenceSupported = layerView.SpatialReferenceSupported;
        Suspended = layerView.Suspended;
        Updating = layerView.Updating;
        Visible = layerView.Visible;
        AbortManager = abortManager;
        FeatureEffect = featureEffect;
        Filter = filter;
        HighlightOptions = highlightOptions;
        MaximumNumberOfFeatures = maximumNumberOfFeatures;
        MaximumNumberOfFeaturesExceeded = maximumNumberOfFeaturesExceeded;
#pragma warning restore BL0005    
    }

    /// <summary>
    ///     The attribute, geometry, and time extent filter. Only the features that satisfy the filter are displayed on the view.
    /// </summary>
    public FeatureFilter? Filter { get; private set; }


    /// <summary>
    ///     The featureEffect can be used to draw attention features of interest.
    /// </summary>
    public FeatureEffect? FeatureEffect { get; private set; }
    
    /// <summary>
    ///     Options for configuring the highlight.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-HighlightLayerViewMixin.html#highlightOptions">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HighlightOptions? HighlightOptions { get; set; }
    
    /// <summary>
    ///     The maximum number of features that can be displayed at a time.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerViewMixin.html#maximumNumberOfFeatures">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaximumNumberOfFeatures { get; set; }
    
    /// <summary>
    ///     Signifies whether the maximum number of features has been exceeded.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-layers-FeatureLayerViewMixin.html#maximumNumberOfFeaturesExceeded">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? MaximumNumberOfFeaturesExceeded { get; set; }

    /// <summary>
    ///     Sets the <see cref="FeatureFilter" /> for this view.
    /// </summary>
    /// <param name="filter">
    ///     The new filter (or null to clear) to apply to this view.
    /// </param>
    public async Task SetFilter(FeatureFilter? filter)
    {
        IJSObjectReference? filterRef = await JsObjectReference!.InvokeAsync<IJSObjectReference?>(
            "setFilter", CancellationTokenSource.Token, filter);

        if (filter is not null)
        {
            filter.JsComponentReference = filterRef;
        }
        Filter = filter;
    }


    /// <summary>
    ///  Sets the <see cref="FeatureEffect" /> for this view.
    /// </summary>
    /// <param name="featureEffect">
    /// The new effect (or null to clear) to apply to this view.
    /// </param>

    public async Task SetFeatureEffect(FeatureEffect? featureEffect)
    {
        IJSObjectReference? effectRef = await JsObjectReference!.InvokeAsync<IJSObjectReference?>(
            "setFeatureEffect", CancellationTokenSource.Token, featureEffect);

        if (featureEffect is not null)
        {
            featureEffect.JsComponentReference = effectRef;
        }
        FeatureEffect = featureEffect;
    }

    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="objectId">
    ///     The ObjectID of the graphic to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<HighlightHandle> Highlight(long objectId)
    {
        IJSObjectReference objectRef =
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, objectId);
        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="target">
    ///     The ObjectID of the graphic to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<HighlightHandle> Highlight(string target)
    {
        IJSObjectReference objectRef = await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight", 
            CancellationTokenSource.Token, target);
        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="objectIds">
    ///     The ObjectIDs of the graphics to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    public async Task<HighlightHandle> Highlight(IEnumerable<long> objectIds)
    {
        IJSObjectReference objectRef =
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, objectIds);

        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="graphic">
    ///     The <see cref="Graphic" /> to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    public async Task<HighlightHandle> Highlight(Graphic graphic)
    {
        IJSObjectReference objectRef =
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, graphic);

        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///     Highlights the given feature(s).
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to highlight.
    /// </param>
    /// <returns>
    ///     A handle that allows the highlight to be removed later.
    /// </returns>
    public async Task<HighlightHandle> Highlight(IEnumerable<Graphic> graphics)
    {
        IJSObjectReference objectRef =
            await JsObjectReference!.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, graphics);

        return new HighlightHandle(objectRef);
    }

    /// <summary>
    ///     Creates query parameter object that can be used to fetch features as they are being displayed. It sets the query parameter's outFields property to ["*"] and returnGeometry to true. The output spatial reference outSpatialReference is set to the spatial reference of the view. Parameters of the filter currently applied to the layerview are also incorporated in the returned query object. The results will include geometries of features and values for availableFields.
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<Query> CreateQuery()
    {
        return await JsObjectReference!.InvokeAsync<Query>("createQuery", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Executes a Query against features available for drawing in the layerView and returns the Extent of features that satisfy the query. Valid only for hosted feature services on arcgis.com and for ArcGIS Server 10.3.1 and later. If query parameters are not provided, the extent and count of all features available for drawing are returned. To query for the extent of features directly from a Feature Service rather than those visible in the view, you must use the <see cref="FeatureLayer.QueryExtent" /> method.
    /// </summary>
    /// <remarks>
    ///     Spatial queries are executed against quantized geometries in the layerView. The resolution of layerView geometries, is only as precise as the scale resolution of the view. Therefore, the results of the same query could be different when executed at different scales. This also means that geometries returned from any layerView query will likewise be at the same scale resolution of the view. Spatial queries have the same limitations as those listed in the projection engine documentation. Spatial queries are not currently supported if the FeatureLayerView has any of the following SpatialReferences:
    ///     GDM 2000 (4742) – Malaysia,
    ///     Gusterberg (Ferro) (8042) – Austria/Czech Republic,
    ///     ISN2016 (8086) - Iceland,
    ///     SVY21 (4757) - Singapore
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<ExtentQueryResult?> QueryExtent(Query query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await JsObjectReference!.InvokeAsync<ExtentQueryResult?>("queryExtent", cancellationToken, query, new { signal = abortSignal });
        await AbortManager.DisposeAbortController(cancellationToken);
        return result;
    }

    /// <summary>
    ///     Executes a Query against features available for drawing in the layerView and returns the number of features that satisfy the query. If query parameters are not provided, the count of all features available for drawing is returned. To query for the count of features directly from a Feature Service rather than those visible in the view, you must use the <see cref="FeatureLayer.QueryFeatureCount" /> method.
    /// </summary>
    /// <remarks>
    ///     Spatial queries are executed against quantized geometries in the layerView. The resolution of layerView geometries, is only as precise as the scale resolution of the view. Therefore, the results of the same query could be different when executed at different scales. This also means that geometries returned from any layerView query will likewise be at the same scale resolution of the view. Spatial queries have the same limitations as those listed in the projection engine documentation. Spatial queries are not currently supported if the FeatureLayerView has any of the following SpatialReferences:
    ///     GDM 2000 (4742) – Malaysia,
    ///     Gusterberg (Ferro) (8042) – Austria/Czech Republic,
    ///     ISN2016 (8086) - Iceland,
    ///     SVY21 (4757) - Singapore
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns>
    ///     The number of features that satisfy the query.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<int?> QueryFeatureCount(Query? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await JsObjectReference!.InvokeAsync<int?>("queryFeatureCount", cancellationToken, query, new { signal = abortSignal });
        await AbortManager.DisposeAbortController(cancellationToken);
        return result;
    }

    /// <summary>
    ///     Executes a Query against features available for drawing in the layerView and returns a FeatureSet. If query parameters are not provided, all features available for drawing are returned along with their attributes that are available on the client. For client-side attribute queries, relevant fields should exist in availableFields list for the query to be successful. To execute a query against all the features in a feature service rather than only those in the client, you must use the <see cref="FeatureLayer.QueryFeatures" /> method.
    /// </summary>
    /// <remarks>
    ///     Attribute values used in attribute queries executed against layerViews are case sensitive. Spatial queries are executed against quantized geometries in the layerView. The resolution of layerView geometries, is only as precise as the scale resolution of the view. Therefore, the results of the same query could be different when executed at different scales. This also means that geometries returned from any layerView query will likewise be at the same scale resolution of the view. Spatial queries have the same limitations as those listed in the projection engine documentation. Spatial queries are not currently supported if the FeatureLayerView has any of the following SpatialReferences:
    ///     GDM 2000 (4742) – Malaysia,
    ///     Gsterberg (Ferro) (8042) – Austria/Czech Republic,
    ///     ISN2016 (8086) - Iceland,
    ///     SVY21 (4757) - Singapore
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When this parameter is not passed to queryFeatures() method, all features available for drawing are returned along with their attributes that are available on the client. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns>
    ///     A FeatureSet containing the features that satisfy the query.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<FeatureSet?> QueryFeatures(Query? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        Guid queryId = Guid.NewGuid();
        FeatureSet result = await JsObjectReference!.InvokeAsync<FeatureSet>("queryFeatures", 
            cancellationToken, query, new { signal = abortSignal }, DotNetObjectReference.Create(this), 
            Layer?.View?.Id, queryId);
        if (_activeQueries.ContainsKey(queryId))
        {
            result = result with { Features = _activeQueries[queryId]};
            _activeQueries.Remove(queryId);
        }
        
        foreach (Graphic graphic in result.Features!)
        {
            graphic.LayerId = Layer?.Id;
        }

        await AbortManager.DisposeAbortController(cancellationToken);
        return result;
    }

    /// <summary>
    ///     Internal use callback from JavaScript
    /// </summary>
    [JSInvokable]
    public async Task OnQueryFeaturesStreamCallback(IJSStreamReference streamReference, Guid queryId)
    {
        try
        {
            await using Stream stream = await streamReference.OpenReadStreamAsync(
                Layer?.View?.QueryResultsMaxSizeLimit ?? 1_000_000_000L);
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ProtoGraphicCollection collection = Serializer.Deserialize<ProtoGraphicCollection>(ms);
            Graphic[] graphics = collection?.Graphics.Select(g => g.FromSerializationRecord()).ToArray()!;

            _activeQueries[queryId] = graphics;
        }
        catch (Exception ex)
        {
            throw new SerializationException("Error deserializing graphics from stream.", ex);   
        }
    }

    /// <summary>
    ///     Executes a Query against features available for drawing in the layerView and returns array of the ObjectIDs of features that satisfy the input query. If query parameters are not provided, the ObjectIDs of all features available for drawing are returned. To query for ObjectIDs of features directly from a Feature Service rather than those visible in the view, you must use the <see cref="FeatureLayer.QueryObjectIds" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. When no parameters are passed to this method, all features in the client are returned. To only return features visible in the view, set the geometry parameter in the query object to the view's extent.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<long[]?> QueryObjectIds(Query query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        long[]? queryResult = await JsObjectReference!.InvokeAsync<long[]?>("queryObjectIds", cancellationToken, query, new { signal = abortSignal });
        await AbortManager.DisposeAbortController(cancellationToken);
        return queryResult;
    }

    private readonly Dictionary<Guid, Graphic[]> _activeQueries = new();
}