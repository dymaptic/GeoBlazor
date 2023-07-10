using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A FeatureLayer is a single layer that can be created from a Map Service or Feature Service; ArcGIS Online or ArcGIS
///     Enterprise portal items; or from an array of client-side features. The layer can be either a spatial (has
///     geographic features) or non-spatial (table).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/feature-layers">Sample - Feature Layers</a>
/// </example>
public class FeatureLayer : Layer
{
    /// <summary>
    ///     Constructor for use as a razor component
    /// </summary>
    public FeatureLayer()
    {
    }

    /// <summary>
    ///     Constructor for creating a new FeatureLayer in code. Either the url, portalItem, or source parameter must be
    ///     specified.
    /// </summary>
    /// <param name="url">
    ///     The absolute URL of the REST endpoint of the layer, non-spatial table or service
    /// </param>
    /// <param name="portalItem">
    ///     The <see cref="PortalItem" /> from which the layer is loaded.
    /// </param>
    /// <param name="source">
    ///     A collection of Graphic objects used to create a FeatureLayer.
    /// </param>
    /// <param name="outFields">
    ///     An array of field names from the service to include with each feature.
    /// </param>
    /// <param name="definitionExpression">
    ///     The SQL where clause used to filter features on the client.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </param>
    /// <param name="objectIdField">
    ///     The name of an oidfield containing a unique value or identifier for each feature in the layer.
    /// </param>
    /// <param name="geometryType">
    ///     The geometry type of the feature layer. All features must be of the same type.
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the Legend and LayerList widgets.
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the View. When false, the layer may still be added to a Map instance that is
    ///     referenced in a view, but its features will not be visible in the view.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    public FeatureLayer(string? url = null, PortalItem? portalItem = null, IReadOnlyCollection<Graphic>? source = null,
        string[]? outFields = null, string? definitionExpression = null, double? minScale = null,
        double? maxScale = null, string? objectIdField = null, GeometryType? geometryType = null, string? title = null,
        double? opacity = null, bool? visible = null, ListMode? listMode = null)
    {
        if (url is null && portalItem is null && source is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(FeatureLayer),
                new[] { nameof(Url), nameof(PortalItem), nameof(Source) });
        }

        Url = url;
        Source = source;
        PortalItem = portalItem;
        OutFields = outFields;
        DefinitionExpression = definitionExpression;
        MinScale = minScale;
        MaxScale = maxScale;
        ObjectIdField = objectIdField;
        GeometryType = geometryType;
        Title = title;
        Opacity = opacity;
        Visible = visible;
        ListMode = listMode;
    }

    /// <summary>
    ///     The absolute URL of the REST endpoint of the layer, non-spatial table or service
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem), nameof(Source))]
    public string? Url { get; set; }

    /// <summary>
    ///     The SQL where clause used to filter features on the client.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression { get; set; }

    /// <summary>
    ///     An array of field names from the service to include with each feature.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string[]? OutFields { get; set; }

    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     The name of an oidfield containing a unique value or identifier for each feature in the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ObjectIdField { get; set; }

    /// <summary>
    ///     The geometry type of the feature layer. All features must be of the same type.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GeometryType? GeometryType { get; set; }

    /// <summary>
    ///     Determines the order in which features are drawn in the view.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<OrderedLayerOrderBy>? OrderBy { get; set; }

    /// <summary>
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    /// <summary>
    ///     The label definition for this layer, specified as an array of <see cref="Label" />.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<Label>? LabelingInfo { get; set; }

    /// <summary>
    ///     The <see cref="Renderer" /> assigned to the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }

    /// <summary>
    ///     The <see cref="PortalItem" /> from which the layer is loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(Url), nameof(Source))]
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     The spatial reference for the feature layer
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <summary>
    ///     A collection of Graphic objects used to create a FeatureLayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(Url), nameof(PortalItem))]
    public IReadOnlyCollection<Graphic>? Source
    {
        get => _source;
        set
        {
            if (value is not null)
            {
                _source = new HashSet<Graphic>(value);
            }
        }
    }

    /// <summary>
    ///     An array of fields in the layer.
    /// </summary>
    public IReadOnlyCollection<Field>? Fields
    {
        get => _fields;
        set
        {
            if (value is not null)
            {
                _fields = new HashSet<Field>(value);
            }
        }
    }

    /// <summary>
    ///     Array of relationships set up for the layer. Each object in the array describes the layer's relationship with
    ///     another layer or table.
    /// </summary>
    public Relationship[]? Relationships { get; set; }

    /// <inheritdoc />
    public override string LayerType => "feature";

    /// <summary>
    ///     Add a graphic to the current layer's source
    /// </summary>
    /// <param name="graphic">
    ///     The graphic to add
    /// </param>
    public Task Add(Graphic graphic)
    {
        return RegisterChildComponent(graphic);
    }

    /// <summary>
    ///     Adds a collection of graphics to the feature layer
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to add
    /// </param>
    public async Task Add(IEnumerable<Graphic> graphics)
    {
        foreach (Graphic graphic in graphics)
        {
            await RegisterChildComponent(graphic);
        }
    }

    /// <summary>
    ///     Remove a graphic from the current layer
    /// </summary>
    /// <param name="graphic">
    ///     The graphic to remove
    /// </param>
    public Task Remove(Graphic graphic)
    {
        return UnregisterChildComponent(graphic);
    }

    /// <summary>
    ///     Add a field to the current layer's source
    /// </summary>
    /// <param name="field">
    ///     The field to add
    /// </param>
    public Task Add(Field field)
    {
        return RegisterChildComponent(field);
    }

    /// <summary>
    ///     Remove a field from the current layer
    /// </summary>
    /// <param name="field">
    ///     The field to remove
    /// </param>
    public Task Remove(Field field)
    {
        return UnregisterChildComponent(field);
    }

    /// <summary>
    ///     Updates the <see cref="PopupTemplate"/> for this layer.
    /// </summary>
    /// <param name="template">
    ///     The new template to use.
    /// </param>
    public async Task SetPopupTemplate(PopupTemplate template)
    {
        await RegisterChildComponent(template);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                    LayerChanged = true;
                }

                break;
            case Label label:
                LabelingInfo ??= new HashSet<Label>();

                if (!LabelingInfo.Contains(label))
                {
                    LabelingInfo.Add(label);
                    LayerChanged = true;
                }

                break;
            case Renderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                    LayerChanged = true;
                }

                break;
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                    LayerChanged = true;
                }

                break;
            case SpatialReference spatialRef:
                if (!spatialRef.Equals(SpatialReference))
                {
                    SpatialReference = spatialRef;
                    LayerChanged = true;
                }

                break;
            case OrderedLayerOrderBy orderBy:
                OrderBy ??= new HashSet<OrderedLayerOrderBy>();

                if (!OrderBy.Contains(orderBy))
                {
                    OrderBy.Add(orderBy);
                    LayerChanged = true;
                }

                break;
            case Graphic graphic:
                _source ??= new HashSet<Graphic>();

                if (!_source.Contains(graphic))
                {
                    graphic.View ??= View;
                    graphic.JsModule ??= JsModule;
                    graphic.Parent ??= this;
                    graphic.LayerId ??= Id;
                    _source.Add(graphic);

                    LayerChanged = true;
                }

                break;
            case Field field:
                _fields ??= new HashSet<Field>();

                if (!_fields.Contains(field))
                {
                    _fields.Add(field);
                    LayerChanged = true;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupTemplate _:
                PopupTemplate = null;
                LayerChanged = true;

                break;
            case Label label:
                LabelingInfo?.Remove(label);
                LayerChanged = true;

                break;
            case Renderer _:
                Renderer = null;
                LayerChanged = true;

                break;
            case PortalItem _:
                PortalItem = null;
                LayerChanged = true;

                break;
            case SpatialReference _:
                SpatialReference = null;
                LayerChanged = true;

                break;
            case OrderedLayerOrderBy orderBy:
                OrderBy?.Remove(orderBy);
                LayerChanged = true;

                break;
            case Graphic graphic:
                if (_source?.Contains(graphic) ?? false)
                {
                    _source.Remove(graphic);
                    LayerChanged = true;
                }

                break;
            case Field field:
                if (_fields?.Contains(field) ?? false)
                {
                    _fields.Remove(field);
                    LayerChanged = true;
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <summary>
    ///     Creates a popup template for the layer, populated with all the fields of the layer.
    /// </summary>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    public async Task<PopupTemplate> CreatePopupTemplate(CreatePopupTemplateOptions? options = null)
    {
        return await JsLayerReference!.InvokeAsync<PopupTemplate>("createPopupTemplate",
            CancellationTokenSource.Token, options);
    }

    /// <summary>
    ///     Creates query parameter object that can be used to fetch features that satisfy the layer's configurations such as
    ///     definitionExpression, gdbVersion, and historicMoment. It will return Z and M values based on the layer's data
    ///     capabilities. It sets the query parameter's outFields property to ["*"]. The results will include geometries of
    ///     features and values for all available fields for client-side queries or all fields in the layer for server side
    ///     queries.
    /// </summary>
    public async Task<Query> CreateQuery()
    {
        return await JsLayerReference!.InvokeAsync<Query>("createQuery", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns the Extent of features that satisfy the query. If no
    ///     parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters
    ///     are returned.
    ///     To query for the extent of features/graphics available to or visible in the View on the client rather than making a
    ///     server-side query, you must use the <see cref="FeatureLayerView.QueryExtent" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the extent and count
    ///     of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<ExtentQueryResult> QueryExtent(Query? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        ExtentQueryResult result = await JsLayerReference!.InvokeAsync<ExtentQueryResult>("queryExtent",
            cancellationToken, query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns the number of features that satisfy the query. If no
    ///     parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    ///     To query for the count of features/graphics available to or visible in the View on the client rather than making a
    ///     server-side query, you must use the <see cref="FeatureLayerView.QueryFeatureCount" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of
    ///     features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns></returns>
    public async Task<int> QueryFeatureCount(Query? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        int result = await JsLayerReference!.InvokeAsync<int>("queryFeatureCount", cancellationToken,
            query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns the number of features that satisfy the query. If no
    ///     parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    ///     To query for the count of features/graphics available to or visible in the View on the client rather than making a
    ///     server-side query, you must use the <see cref="FeatureLayerView.QueryFeatureCount" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of
    ///     features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns></returns>
    public async Task<FeatureSet?> QueryFeatures(Query? query = null, CancellationToken cancellationToken = default)
    {
        query ??= new Query();
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        FeatureSet? result = await JsLayerReference!.InvokeAsync<FeatureSet?>("queryFeatures", cancellationToken,
            query, new { signal = abortSignal }, DotNetObjectReference.Create(this), View?.Id);

        if (View!.IsServer && result is null)
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            result = JsonSerializer.Deserialize<FeatureSet>(_queryFeatureData!.ToString(), options)!;
            _queryFeatureData = null;
        }

        if (result?.Features is not null)
        {
            foreach (Graphic graphic in result.Features)
            {
                graphic.LayerId = Id;
            }
        }

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     partial query result return for Blazor Server, to avoid SignalR size limits
    /// </summary>
    [JSInvokable]
    public void OnQueryFeaturesCreateChunk(string chunk, int chunkIndex)
    {
        if (chunkIndex == 0)
        {
            _queryFeatureData = new StringBuilder(chunk);
        }
        else
        {
            _queryFeatureData!.Append(chunk);
        }
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns an array of Object IDs for features that satisfy the input
    ///     query. If no parameters are specified, then the Object IDs of all features satisfying the layer's
    ///     configuration/filters are returned.
    ///     To query for ObjectIDs of features/graphics available to or visible in the View on the client rather than making a
    ///     server-side query, you must use the <see cref="FeatureLayerView.QueryObjectIds" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the Object IDs of
    ///     all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<int[]> QueryObjectIds(Query query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        int[] queryResult = await JsLayerReference!.InvokeAsync<int[]>("queryObjectIds", cancellationToken,
            query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return queryResult;
    }

    /// <summary>
    ///     Executes a RelationshipQuery against the feature service and returns FeatureSets grouped by source layer or table
    ///     objectIds.
    /// </summary>
    /// <param name="query">
    ///     Specifies relationship parameters for querying related features or records from a layer or a table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<Dictionary<int, FeatureSet?>?> QueryRelatedFeatures(RelationshipQuery query,
        CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        Dictionary<int, FeatureSet?>? result = await JsLayerReference!.InvokeAsync<Dictionary<int, FeatureSet?>?>(
            "queryRelatedFeatures", cancellationToken, query, new { signal = abortSignal },
            DotNetObjectReference.Create(this), View?.Id);

        if (View!.IsServer && result is null)
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            result = JsonSerializer.Deserialize<Dictionary<int, FeatureSet?>>(_queryFeatureData!.ToString(), options)!;
            _queryFeatureData = null;
        }

        if (result is not null)
        {
            foreach (FeatureSet? set in result.Values)
            {
                if (set?.Features is null) continue;

                foreach (Graphic graphic in set.Features)
                {
                    graphic.LayerId = Id;
                }
            }
        }

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a RelationshipQuery against the feature service and when resolved, it returns an object containing key
    ///     value pairs. Key in this case is the objectId of the feature and value is the number of related features associated
    ///     with the feature.
    /// </summary>
    /// <param name="query">
    ///     Specifies relationship parameters for querying related features or records from a layer or a table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<Dictionary<int, int>> QueryRelatedFeaturesCount(RelationshipQuery query,
        CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        Dictionary<int, int> result = await JsLayerReference!.InvokeAsync<Dictionary<int, int>>(
            "queryRelatedFeaturesCount", cancellationToken, query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns the count of features or records that satisfy the
    ///     query.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeatureCount" /> is only supported with server-side
    ///     <see cref="FeatureLayer" />s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<int> QueryTopFeatureCount(TopFeaturesQuery query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        int result = await JsLayerReference!.InvokeAsync<int>("queryTopFeatureCount", cancellationToken,
            query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns a FeatureSet once the promise resolves. The
    ///     FeatureSet contains an array of top features grouped and ordered by specified fields. For example, you can call
    ///     this method to query top three counties grouped by state names while ordering them based on their populations in a
    ///     descending order.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeatures" /> is only supported with server-side
    ///     <see cref="FeatureLayer" />s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<FeatureSet?> QueryTopFeatures(TopFeaturesQuery query,
        CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        FeatureSet? result = await JsLayerReference!.InvokeAsync<FeatureSet?>("queryTopFeatures", cancellationToken,
            query, new { signal = abortSignal }, DotNetObjectReference.Create(this), View?.Id);

        if (View!.IsServer && result is null)
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            result = JsonSerializer.Deserialize<FeatureSet>(_queryFeatureData!.ToString(), options)!;
            _queryFeatureData = null;
        }

        if (result?.Features is not null)
        {
            foreach (Graphic graphic in result.Features)
            {
                graphic.LayerId = Id;
            }
        }

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int[]> QueryTopObjectIds(TopFeaturesQuery query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        int[] queryResult = await JsLayerReference!.InvokeAsync<int[]>("queryTopObjectIds", cancellationToken,
            query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return queryResult;
    }

    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns the Extent of features that satisfy the query.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeaturesExtent" /> is only supported with server-side
    ///     <see cref="FeatureLayer" />s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<ExtentQueryResult> QueryTopFeaturesExtent(TopFeaturesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        ExtentQueryResult result = await JsLayerReference!.InvokeAsync<ExtentQueryResult>("queryExtent",
            cancellationToken, query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
        Renderer?.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();

        if (LabelingInfo is not null)
        {
            foreach (Label label in LabelingInfo)
            {
                label.ValidateRequiredChildren();
            }
        }

        if (Source is not null)
        {
            foreach (Graphic graphic in Source)
            {
                graphic.ValidateRequiredChildren();
            }
        }

        if (Fields is not null)
        {
            foreach (Field field in Fields)
            {
                field.ValidateRequiredChildren();
            }
        }
    }

    /// <inheritdoc />
    internal override async Task UpdateFromJavaScript(Layer renderedLayer)
    {
        await base.UpdateFromJavaScript(renderedLayer);
        var renderedFeatureLayer = (FeatureLayer)renderedLayer;
        Url = renderedFeatureLayer.Url;

        if (renderedFeatureLayer.Source is not null && renderedFeatureLayer.Source.Any() &&
            Source is null)
        {
            Source = renderedFeatureLayer.Source;
        }

        if (renderedFeatureLayer.Fields is not null && renderedFeatureLayer.Fields.Any())
        {
            if (Fields is null)
            {
                Fields = renderedFeatureLayer.Fields;
            }
            else
            {
                foreach (Field field in renderedFeatureLayer.Fields)
                {
                    Field? existingField = Fields.FirstOrDefault(f => f.Name == field.Name);

                    if (existingField is null)
                    {
                        _fields!.Add(field);
                    }
                }
            }
        }

        if (renderedFeatureLayer.DefinitionExpression is not null)
        {
            DefinitionExpression = renderedFeatureLayer.DefinitionExpression;
        }

        if (renderedFeatureLayer.OutFields is not null && renderedFeatureLayer.OutFields.Any())
        {
            OutFields = renderedFeatureLayer.OutFields;
        }

        if (renderedFeatureLayer.MinScale is not null)
        {
            MinScale = renderedFeatureLayer.MinScale;
        }

        if (renderedFeatureLayer.MaxScale is not null)
        {
            MaxScale = renderedFeatureLayer.MaxScale;
        }

        if (renderedFeatureLayer.ObjectIdField is not null)
        {
            ObjectIdField = renderedFeatureLayer.ObjectIdField;
        }

        if (renderedFeatureLayer.GeometryType is not null)
        {
            GeometryType = renderedFeatureLayer.GeometryType;
        }

        if (renderedFeatureLayer.OrderBy is not null && renderedFeatureLayer.OrderBy.Any())
        {
            OrderBy = renderedFeatureLayer.OrderBy;
        }

        if (renderedFeatureLayer.PopupTemplate is not null && PopupTemplate is null)
        {
            PopupTemplate = renderedFeatureLayer.PopupTemplate;
        }

        if (renderedFeatureLayer.LabelingInfo is not null && renderedFeatureLayer.LabelingInfo.Any())
        {
            if (LabelingInfo is null || !LabelingInfo.Any())
            {
                LabelingInfo = renderedFeatureLayer.LabelingInfo;
            }
            else
            {
                LabelingInfo ??= new HashSet<Label>();

                foreach (Label label in renderedFeatureLayer.LabelingInfo)
                {
                    LabelingInfo.Add(label);
                }
            }
        }

        if (renderedFeatureLayer.Renderer is not null && Renderer is null)
        {
            Renderer = renderedFeatureLayer.Renderer;
        }

        if (renderedFeatureLayer.PortalItem is not null && PortalItem is null)
        {
            PortalItem = renderedFeatureLayer.PortalItem;
        }

        if (renderedFeatureLayer.SpatialReference is not null && SpatialReference is null)
        {
            SpatialReference = renderedFeatureLayer.SpatialReference;
        }

        if (renderedFeatureLayer.Relationships is not null && Relationships is null)
        {
            Relationships = renderedFeatureLayer.Relationships;
        }
    }

    private HashSet<Graphic>? _source;
    private HashSet<Field>? _fields;
    private StringBuilder? _queryFeatureData;
}

/// <summary>
///     The return type for <see cref="FeatureLayer.QueryExtent" />.
/// </summary>
/// <param name="Count">
///     The number of features that satisfy the input query.
/// </param>
/// <param name="Extent">
///     The extent of features that satisfy the query.
/// </param>
public record ExtentQueryResult(int Count, Extent Extent);

/// <summary>
///     Options for creating the <see cref="PopupTemplate" />.
/// </summary>
public class CreatePopupTemplateOptions
{
    /// <summary>
    ///     An array of field types to ignore when creating the popup. System fields such as Shape_Area and Shape_length, in
    ///     addition to geometry, blob, raster, guid and xml field types are automatically ignored.
    /// </summary>
    public string[]? IgnoreFieldTypes { get; set; }

    /// <summary>
    ///     An array of field names set to be visible within the PopupTemplate.
    /// </summary>
    public HashSet<string>? VisibleFieldNames { get; set; }
}