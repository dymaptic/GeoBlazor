namespace dymaptic.GeoBlazor.Core.Components;

public partial class FeatureLayerView : LayerView
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public FeatureLayerView()
    {
    }
    
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
    
    /// <inheritdoc />
    public override LayerType? Type => LayerType.Feature;

    
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
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");

        if (JsComponentReference is null) return;
        await JsComponentReference.InvokeVoidAsync(
            "setFilter", CancellationTokenSource.Token, filter);

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
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        await JsComponentReference.InvokeVoidAsync(
            "setFeatureEffect", CancellationTokenSource.Token, featureEffect);

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
    public async Task<Handle> Highlight(ObjectId objectId)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        IJSObjectReference objectRef =
            await JsComponentReference.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, objectId);
        return new Handle(objectRef);
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
    /// <exception cref="ArgumentException">
    ///     Throws if no ObjectIDs are provided.
    /// </exception>
    [CodeGenerationIgnore]
    public async Task<Handle> Highlight(IReadOnlyCollection<ObjectId> objectIds)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        if (objectIds.Count == 0)
        {
            throw new ArgumentException("At least one ObjectID must be provided.", nameof(objectIds));
        }
        IJSObjectReference objectRef =
            await JsComponentReference.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, objectIds);

        return new Handle(objectRef);
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
    /// <exception cref="InvalidOperationException">
    ///     Throws if the graphic has no OBJECTID attribute and was not queried via GeoBlazor.
    /// </exception>
    [CodeGenerationIgnore]
    public async Task<Handle> Highlight(Graphic graphic)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        IJSObjectReference? objectRef;
        if (graphic.Attributes.TryGetValue("OBJECTID", out object? objectId))
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference>("highlight",
                    CancellationTokenSource.Token, objectId);
        }
        else
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference?>("highlightByGeoBlazorId",
                CancellationTokenSource.Token, graphic.Id);
            
            if (objectRef is null)
            {
                throw new InvalidOperationException("The graphic does not have an OBJECTID attribute and was not registered with GeoBlazor.");
            }
        }
        
        return new Handle(objectRef);
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
    /// <exception cref="InvalidOperationException">
    ///     Throws if the graphics have no OBJECTID attribute and were not queried via GeoBlazor.
    /// </exception>
    [CodeGenerationIgnore]
    public async Task<Handle> Highlight(IReadOnlyCollection<Graphic> graphics)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        IJSObjectReference? objectRef;

        if (graphics.Count == 0)
        {
            throw new ArgumentException("At least one graphic must be provided.", nameof(graphics));
        }
        if (graphics.First().Attributes.TryGetValue("OBJECTID", out _))
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference>("highlight",
                CancellationTokenSource.Token, graphics.Select(g => g.Attributes["OBJECTID"]).ToArray());
        }
        else
        {
            objectRef = await JsComponentReference.InvokeAsync<IJSObjectReference?>("highlightByGeoBlazorIds",
                CancellationTokenSource.Token, graphics.Select(g => g.Id).ToArray());
            
            if (objectRef is null)
            {
                throw new InvalidOperationException("The graphics do not have the OBJECTID attribute and were not registered with GeoBlazor.");
            }
        }

        return new Handle(objectRef);
    }

    /// <summary>
    ///     Creates query parameter object that can be used to fetch features as they are being displayed. It sets the query parameter's outFields property to ["*"] and returnGeometry to true. The output spatial reference outSpatialReference is set to the spatial reference of the view. Parameters of the filter currently applied to the layerview are also incorporated in the returned query object. The results will include geometries of features and values for availableFields.
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<Query> CreateQuery()
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent");
        return await JsComponentReference.InvokeAsync<Query>("createQuery", CancellationTokenSource.Token);
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
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent", cancellationToken);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult? result = await JsComponentReference.InvokeAsync<ExtentQueryResult?>("queryExtent", cancellationToken, query, new { signal = abortSignal });
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
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent", cancellationToken);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        int? result = await JsComponentReference.InvokeAsync<int?>("queryFeatureCount", cancellationToken, query, new { signal = abortSignal });
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
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent", cancellationToken);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        Guid queryId = Guid.NewGuid();
        FeatureSet result = await JsComponentReference.InvokeAsync<FeatureSet>("queryFeatures", 
            cancellationToken, query, new { signal = abortSignal }, DotNetComponentReference, queryId);
        if (_activeQueries.ContainsKey(queryId))
        {
            result = result with { Features = _activeQueries[queryId]};
            _activeQueries.Remove(queryId);
        }
        
        foreach (Graphic graphic in result.Features!)
        {
            graphic.View = View;
            graphic.Parent = this;
            graphic.Layer = Layer;
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
    public async Task<ObjectId[]?> QueryObjectIds(Query query, CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference>("getJsComponent", cancellationToken);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[]? queryResult = await JsComponentReference.InvokeAsync<ObjectId[]?>("queryObjectIds", cancellationToken, query, new { signal = abortSignal });
        await AbortManager.DisposeAbortController(cancellationToken);
        return queryResult;
    }

    private readonly Dictionary<Guid, Graphic[]> _activeQueries = new();
}