using dymaptic.GeoBlazor.Core.Components.Geometries;
using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A FeatureLayer is a single layer that can be created from a Map Service or Feature Service; ArcGIS Online or ArcGIS Enterprise portal items; or from an array of client-side features. The layer can be either a spatial (has geographic features) or non-spatial (table).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">ArcGIS JS API</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/feature-layers">Sample - Feature Layers</a>
/// </example>
public class FeatureLayer : Layer
{
    /// <summary>
    ///     The absolute URL of the REST endpoint of the layer, non-spatial table or service
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(PortalItem), nameof(Source))]
    public string Url { get; set; } = default!;

    /// <summary>
    ///     The SQL where clause used to filter features on the client.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression
    {
        get => _definitionExpression;
        set
        {
            _definitionExpression = value;

            if (MapRendered)
            {
                Task.Run(UpdateComponent);
            }
        }
    }

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
    ///     The geometry type of the feature layer. All featuers must be of the same type.
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
    ///     The <see cref="PopupTemplate"/> for the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    /// <summary>
    ///     The label definition for this layer, specified as an array of <see cref="Label"/>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<Label> LabelingInfo { get; set; } = new();

    /// <summary>
    ///     The <see cref="Renderer"/> assigned to the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Renderer? Renderer { get; set; }
    
    /// <summary>
    ///     The <see cref="PortalItem"/> from which the layer is loaded.
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
                _source = new(value);
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
                _fields = new(value);
            }
        }
    }
    
    /// <summary>
    ///     Array of relationships set up for the layer. Each object in the array describes the layer's relationship with another layer or table.
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

    /// <inheritdoc />
    public override void UpdateFromJavaScript(Layer renderedLayer)
    {
        base.UpdateFromJavaScript(renderedLayer);
        FeatureLayer renderedFeatureLayer = (FeatureLayer)renderedLayer;
        Url = renderedFeatureLayer.Url;
        if (renderedFeatureLayer.Source is not null && renderedFeatureLayer.Source.Any())
        {
            Source = renderedFeatureLayer.Source;
        }
        
        if (renderedFeatureLayer.Fields is not null && renderedFeatureLayer.Fields.Any())
        {
            Fields = renderedFeatureLayer.Fields;
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
        
        if (renderedFeatureLayer.PopupTemplate is not null)
        {
            PopupTemplate = renderedFeatureLayer.PopupTemplate;
        }
        
        if (renderedFeatureLayer.LabelingInfo.Any())
        {
            LabelingInfo = renderedFeatureLayer.LabelingInfo;
        }
        
        if (renderedFeatureLayer.Renderer is not null)
        {
            Renderer = renderedFeatureLayer.Renderer;
        }
        
        if (renderedFeatureLayer.PortalItem is not null)
        {
            PortalItem = renderedFeatureLayer.PortalItem;
        }
        
        if (renderedFeatureLayer.SpatialReference is not null)
        {
            SpatialReference = renderedFeatureLayer.SpatialReference;
        }

        if (renderedFeatureLayer.Relationships is not null)
        {
            Relationships = renderedFeatureLayer.Relationships;
        }
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
                    await UpdateComponent();
                }

                break;
            case Label label:
                if (!LabelingInfo.Contains(label))
                {
                    LabelingInfo.Add(label);
                    await UpdateComponent();
                }

                break;
            case Renderer renderer:
                if (!renderer.Equals(Renderer))
                {
                    Renderer = renderer;
                    await UpdateComponent();
                }

                break;
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                    await UpdateComponent();
                }

                break;
            case SpatialReference spatialRef:
                if (!spatialRef.Equals(SpatialReference))
                {
                    SpatialReference = spatialRef;
                    await UpdateComponent();
                }

                break;
            case OrderedLayerOrderBy orderBy:
                OrderBy ??= new HashSet<OrderedLayerOrderBy>();
                if (!OrderBy.Contains(orderBy))
                {
                    OrderBy.Add(orderBy);
                    await UpdateComponent();
                }

                break;
            case Graphic graphic:
                _source ??= new HashSet<Graphic>();
                if (!_source.Contains(graphic))
                {
                    graphic.GraphicIndex = _source.Count;
                    graphic.View ??= View;
                    graphic.JsModule ??= JsModule;
                    graphic.Parent ??= this;
                    graphic.LayerId ??= Id;
                    _source.Add(graphic);
                    await UpdateComponent();
                }

                break;
            case Field field:
                _fields ??= new HashSet<Field>();

                if (!_fields.Contains(field))
                {
                    _fields.Add(field);
                    await UpdateComponent();
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

                break;
            case Label label:
                LabelingInfo.Remove(label);

                break;
            case Renderer _:
                Renderer = null;

                break;
            case PortalItem _:
                PortalItem = null;

                break;
            case SpatialReference _:
                SpatialReference = null;

                break;
            case OrderedLayerOrderBy orderBy:
                OrderBy?.Remove(orderBy);

                break;
            case Graphic graphic:
                if (_source?.Contains(graphic) ?? false)
                {
                    _source.Remove(graphic);
                }

                break;
            case Field field:
                if (_fields?.Contains(field) ?? false)
                {
                    _fields.Remove(field);
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
        Renderer?.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
        foreach (Label label in LabelingInfo)
        {
            label.ValidateRequiredChildren();
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
    public override async Task UpdateComponent()
    {
        if ((!MapRendered && JsObjectReference is null) || JsModule is null) return;

        await InvokeAsync(async () =>
        {
            // ReSharper disable once RedundantCast
            await JsModule!.InvokeVoidAsync("updateFeatureLayer", (object)this, View!.Id);
        });
    }

    /// <summary>
    ///     Creates a popup template for the layer, populated with all the fields of the layer.
    /// </summary>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    public async Task<PopupTemplate> CreatePopupTemplate(CreatePopupTemplateOptions? options = null)
    {
        return await JsObjectReference!.InvokeAsync<PopupTemplate>("createPopupTemplate", options);
    }

    /// <summary>
    ///     Creates query parameter object that can be used to fetch features that satisfy the layer's configurations such as definitionExpression, gdbVersion, and historicMoment. It will return Z and M values based on the layer's data capabilities. It sets the query parameter's outFields property to ["*"]. The results will include geometries of features and values for all available fields for client-side queries or all fields in the layer for server side queries.
    /// </summary>
    public async Task<Query> CreateQuery()
    {
        return await JsObjectReference!.InvokeAsync<Query>("createQuery");
    }
    
    /// <summary>
    ///     Executes a Query against the feature service and returns the Extent of features that satisfy the query. If no parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters are returned.
    ///     To query for the extent of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryExtent"/> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<ExtentQueryResult> QueryExtent(Query? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult result = await JsObjectReference!.InvokeAsync<ExtentQueryResult>("queryExtent", 
            cancellationToken, query, new {signal = abortSignal});

        await AbortManager.DisposeAbortController(cancellationToken);
        return result;
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns the number of features that satisfy the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    ///     To query for the count of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryFeatureCount"/> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns></returns>
    public async Task<int> QueryFeatureCount(Query? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        int result = await JsObjectReference!.InvokeAsync<int>("queryFeatureCount", cancellationToken, 
            query, new {signal = abortSignal});
        
        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
    
    /// <summary>
    ///     Executes a Query against the feature service and returns the number of features that satisfy the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    ///     To query for the count of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryFeatureCount"/> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns></returns>
    public async Task<FeatureSet> QueryFeatures(Query? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet result = await JsObjectReference!.InvokeAsync<FeatureSet>("queryFeatures", cancellationToken, 
            query, new {signal = abortSignal});

        if (result.Features is not null)
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
    ///     Executes a Query against the feature service and returns an array of Object IDs for features that satisfy the input query. If no parameters are specified, then the Object IDs of all features satisfying the layer's configuration/filters are returned.
    ///     To query for ObjectIDs of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryObjectIds"/> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the Object IDs of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<int[]> QueryObjectIds(Query query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        
        int[] queryResult = await JsObjectReference!.InvokeAsync<int[]>("queryObjectIds", cancellationToken,
            query, new {signal = abortSignal});

        await AbortManager.DisposeAbortController(cancellationToken);

        return queryResult;
    }
    
    /// <summary>
    ///     Executes a RelationshipQuery against the feature service and returns FeatureSets grouped by source layer or table objectIds.
    /// </summary>
    /// <param name="query">
    ///     Specifies relationship parameters for querying related features or records from a layer or a table.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<Dictionary<int, FeatureSet?>> QueryRelatedFeatures(RelationshipQuery query, 
        CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        Dictionary<int, FeatureSet?> result = await JsObjectReference!.InvokeAsync<Dictionary<int, FeatureSet?>>(
            "queryRelatedFeatures", cancellationToken, query, new {signal = abortSignal});

        foreach (FeatureSet? set in result.Values)
        {
            if (set?.Features is null) continue;
            foreach (Graphic graphic in set.Features)
            {
                graphic.LayerId = Id;
            }
        }

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
    
    /// <summary>
    ///     Executes a RelationshipQuery against the feature service and when resolved, it returns an object containing key value pairs. Key in this case is the objectId of the feature and value is the number of related features associated with the feature.
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
        Dictionary<int, int> result = await JsObjectReference!.InvokeAsync<Dictionary<int, int>>(
            "queryRelatedFeaturesCount", cancellationToken, query, new {signal = abortSignal});

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
    
    
    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns the count of features or records that satisfy the query.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeatureCount"/> is only supported with server-side <see cref="FeatureLayer"/>s.
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
        int result = await JsObjectReference!.InvokeAsync<int>("queryTopFeatureCount", cancellationToken, 
            query, new {signal = abortSignal});
        
        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
    
    
    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns a FeatureSet once the promise resolves. The FeatureSet contains an array of top features grouped and ordered by specified fields. For example, you can call this method to query top three counties grouped by state names while ordering them based on their populations in a descending order.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeatures"/> is only supported with server-side <see cref="FeatureLayer"/>s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<FeatureSet> QueryTopFeatures(TopFeaturesQuery query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        FeatureSet result = await JsObjectReference!.InvokeAsync<FeatureSet>("queryTopFeatures", cancellationToken, 
            query, new {signal = abortSignal});

        if (result.Features is not null)
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
    ///     
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int[]> QueryTopObjectIds(TopFeaturesQuery query, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        
        int[] queryResult = await JsObjectReference!.InvokeAsync<int[]>("queryTopObjectIds", cancellationToken,
            query, new {signal = abortSignal});

        await AbortManager.DisposeAbortController(cancellationToken);

        return queryResult;
    }
    
    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns the Extent of features that satisfy the query.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeaturesExtent"/> is only supported with server-side <see cref="FeatureLayer"/>s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    public async Task<ExtentQueryResult> QueryTopFeaturesExtent(TopFeaturesQuery? query = null, CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        ExtentQueryResult result = await JsObjectReference!.InvokeAsync<ExtentQueryResult>("queryExtent", 
            cancellationToken, query, new {signal = abortSignal});

        await AbortManager.DisposeAbortController(cancellationToken);
        return result;
    }

    private string? _definitionExpression;
    private HashSet<Graphic>? _source;
    private HashSet<Field>? _fields;
}

/// <summary>
///    The return type for <see cref="FeatureLayer.QueryExtent"/>.
/// </summary>
/// <param name="Count">
///     The number of features that satisfy the input query.
/// </param>
/// <param name="Extent">
///     The extent of features that satisfy the query.
/// </param>
public record ExtentQueryResult(int Count, Extent Extent);

/// <summary>
///     Options for creating the <see cref="PopupTemplate"/>.
/// </summary>
public class CreatePopupTemplateOptions
{
    /// <summary>
    ///     An array of field types to ignore when creating the popup. System fields such as Shape_Area and Shape_length, in addition to geometry, blob, raster, guid and xml field types are automatically ignored.
    /// </summary>
    public string[]? IgnoreFieldTypes { get; set; }
    
    /// <summary>
    ///     An array of field names set to be visible within the PopupTemplate.
    /// </summary>
    public HashSet<string>? VisibleFieldNames { get; set; }
}