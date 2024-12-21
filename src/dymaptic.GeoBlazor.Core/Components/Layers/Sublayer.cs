namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Represents a Sublayer in a MapImageLayer or a TileLayer. MapImageLayer allows you to display, query, and analyze layers from data defined in a map service. Map services contain Sublayers with properties such as renderer, labelingInfo, and definitionExpression, and others that are defined on the server. The properties of each MapImageLayer Sublayer on the map service may be dynamically changed by the user or developer. The properties of each TileLayer Sublayer are read-only, and cannot be modified.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Sublayer: MapComponent, IPopupTemplateLayer
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public Sublayer()
    {
    }

    /// <summary>
    ///     Creates a new Sublayer in code with parameters.
    /// </summary>
    /// <param name="sublayerId">
    ///     The sublayer's layer ID. When a source is not defined on the layer, this value represents the id of the sublayer defined by the map service. If creating a DynamicDataLayer or a MapDataLayer and adding it to the source property of the sublayer, the value of this property can be anything set by the developer.
    /// </param>
    /// <param name="labelsVisible">
    ///     Indicates if labels for the sublayer will be visible in the view.
    /// </param>
    /// <param name="legendEnabled">
    ///     Indicates whether the layer will be included in the legend. When false, the layer will be excluded from the legend.
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </param>
    /// <param name="opacity">
    ///     The level of opacity to set on the sublayer on a scale from 0.0 - 1.0 where 0 is fully transparent and 1.0 is fully opaque. If the MapImageLayer.Opacity is set, the actual opacity value of the sublayer will be the value of MapImageLayer.Opacity multiplied by the sublayer's opacity.
    /// </param>
    /// <param name="popupEnabled">
    ///     Indicates whether to display popups when features in the layer are clicked. The layer's popupTemplate is used to define the content of the popup. If popupEnabled is false, then the popupTemplate is ignored.
    /// </param>
    /// <param name="title">
    ///     The title of the sublayer. This is the name that is displayed to the user in places such as the LayerList widget.
    /// </param>
    /// <param name="visible">
    ///     Indicates whether the layer is visible in the view.
    /// </param>
    /// <param name="definitionExpression">
    ///     A SQL where clause used to filter features in the image. Only the features that satisfy the definition expression are displayed in the View. Definition expressions may be set when a Sublayer is constructed prior to it loading in the view or after it has been added to the MapImageLayer. To see if you can use this property, check the supportsSublayerDefinitionExpression property of MapImageLayer.capabilities.
    /// </param>
    /// <param name="floorInfo">
    ///     If a map image layer contains a sublayer which is meant to be floor-aware, then that sublayer must have a floorInfo property, containing a LayerFloorInfo object which has a string property to represent the floorField.
    /// </param>
    /// <param name="labelingInfo">
    ///     The label definition for this layer, specified as an array of LabelClass objects. Use this property to specify labeling properties for the layer such as label expression, placement, and size.
    /// </param>
    /// <param name="popupTemplate">
    ///     The popup template for the sublayer. When set, the popupTemplate allows users to access attributes and display their values in the view's popup when the user clicks the image.
    /// </param>
    /// <param name="renderer">
    ///     The renderer to apply to the sublayer. This value overrides the renderer read from the map service. To see if you can use this property, check the supportsDynamicLayers property of MapImageLayer.capabilities.
    /// </param>
    /// <param name="source">
    ///     An object that allows you to create a dynamic layer with data either from the map service sublayers or data from a registered workspace. See DynamicMapLayer for creating dynamic layers from map service layers for on the fly rendering, labeling, and filtering (definition expressions). To create dynamic layers from other sources in registered workspaces such as tables and table joins, see DynamicDataLayer.
    /// </param>
    /// <param name="sublayers">
    ///     An array of sublayers. This property is only available after the sublayer has been loaded.
    /// </param>
    public Sublayer(int? sublayerId = null, bool? labelsVisible = null, bool? legendEnabled = null, 
        ListMode? listMode = null, int? maxScale = null, int? minScale = null, double? opacity = null, 
        bool? popupEnabled = null, string? title = null, bool? visible = null, string? definitionExpression = null, 
        LayerFloorInfo? floorInfo = null, IEnumerable<Label>? labelingInfo = null, PopupTemplate? popupTemplate = null,
        Renderer? renderer = null, DynamicLayer? source = null, IEnumerable<Sublayer>? sublayers = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.
        SublayerId = sublayerId;
        LabelsVisible = labelsVisible;
        LegendEnabled = legendEnabled;
        ListMode = listMode;
        MaxScale = maxScale;
        MinScale = minScale;
        Opacity = opacity;
        PopupEnabled = popupEnabled;
        Title = title;
        Visible = visible;
        DefinitionExpression = definitionExpression;
        FloorInfo = floorInfo;

        if (labelingInfo is not null)
        {
            LabelingInfo = new HashSet<Label>(labelingInfo);
        }
        PopupTemplate = popupTemplate;
        Renderer = renderer;
        Source = source;

        if (sublayers is not null)
        {
            Sublayers = new List<Sublayer>(sublayers);
        }
#pragma warning restore BL0005 // Set parameter or member default value.
    }
    
    /// <summary>
    ///     A SQL where clause used to filter features in the image. Only the features that satisfy the definition expression are displayed in the View. Definition expressions may be set when a Sublayer is constructed prior to it loading in the view or after it has been added to the MapImageLayer. To see if you can use this property, check the supportsSublayerDefinitionExpression property of MapImageLayer.capabilities.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression { get; set; }
    
    /// <summary>
    ///     If a map image layer contains a sublayer which is meant to be floor-aware, then that sublayer must have a floorInfo property, containing a LayerFloorInfo object which has a string property to represent the floorField.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LayerFloorInfo? FloorInfo { get; set; }
    
    /// <summary>
    ///     The sublayer's layer ID. When a source is not defined on the layer, this value represents the id of the sublayer defined by the map service. If creating a DynamicDataLayer or a MapDataLayer and adding it to the source property of the sublayer, the value of this property can be anything set by the developer.
    /// </summary>
    /// <remarks>
    ///     This maps to the ArcGIS sublayer.id property.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? SublayerId { get; set; }
    
    /// <summary>
    ///     Indicates if labels for the sublayer will be visible in the view.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LabelsVisible { get; set; }
    
    /// <summary>
    ///     Indicates whether the layer will be included in the legend. When false, the layer will be excluded from the legend.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LegendEnabled { get; set; }
    
    /// <summary>
    ///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ListMode? ListMode { get; set; }
    
    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view. If the map is zoomed in beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a maximum scale. The maxScale value should always be smaller than the minScale value, and greater than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxScale { get; set; }
    
    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view. If the map is zoomed out beyond this scale, the layer will not be visible. A value of 0 means the layer does not have a minimum scale. The minScale value should always be larger than the maxScale value, and less than or equal to the service specification.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinScale { get; set; }
    
    /// <summary>
    ///     The level of opacity to set on the sublayer on a scale from 0.0 - 1.0 where 0 is fully transparent and 1.0 is fully opaque. If the MapImageLayer.opacity is set, the actual opacity value of the sublayer will be the value of MapImageLayer.opacity multiplied by the sublayer's opacity.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }
    
    /// <summary>
    ///     Indicates whether to display popups when features in the layer are clicked. The layer needs to have a popupTemplate to define what information should be displayed in the popup. Alternatively, a default popup template may be automatically used if Popup.defaultPopupTemplateEnabled is set to true.
    ///     Default Value: true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }
    
    /// <summary>
    ///     The title of the sublayer used to identify it in places such as the LayerList and Legend widgets. This value can be defined in the map service or programmatically by the developer. It can also be useful for finding a specific sublayer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Title { get; set; }
    
    /// <summary>
    ///     The label definition for this layer, specified as an array of LabelClass objects. Use this property to specify labeling properties for the layer such as label expression, placement, and size.
    /// </summary>
    public IReadOnlyCollection<Label> LabelingInfo
    {
        get => _labelingInfo;
        set => _labelingInfo = new HashSet<Label>(value);
    }
    
    /// <summary>
    ///     The popup template for the sublayer. When set, the popupTemplate allows users to access attributes and display their values in the view's popup when the user clicks the image.
    ///     Sublayers with a RasterDataSource cannot be queried and therefore do not support PopupTemplate.
    ///     Alternatively, a default popup template may be automatically used if Popup.defaultPopupTemplateEnabled is set to true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public PopupTemplate? PopupTemplate { get; set; }
    
    /// <summary>
    ///     The renderer to apply to the sublayer. This value overrides the renderer read from the map service. To see if you can use this property, check the supportsDynamicLayers property of MapImageLayer.capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Renderer? Renderer { get; set; }
    
    /// <summary>
    ///     An object that allows you to create a dynamic layer with data either from the map service sublayers or data from a registered workspace. See DynamicMapLayer for creating dynamic layers from map service layers for on the fly rendering, labeling, and filtering (definition expressions). To create dynamic layers from other sources in registered workspaces such as tables and table joins, see DynamicDataLayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DynamicLayer? Source { get; set; }

    /// <summary>
    ///     If a sublayer contains sublayers, this property is a Collection of Sublayer objects belonging to the given sublayer with sublayers.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public IReadOnlyList<Sublayer> Sublayers
    {
        get => _sublayers;
        set => _sublayers = new List<Sublayer>(value);
    }

    /// <summary>
    ///     The MapImageLayer or TileLayer to which the sublayer belongs.
    /// </summary>
    [JsonIgnore]
    public Layer? Layer => Parent is Sublayer sublayer
        ? sublayer.Layer
        : Parent as Layer;

    /// <summary>
    ///     Returns a flattened list of sublayers
    /// </summary>
    public IReadOnlyList<Sublayer> GetAllSublayers()
    {
        return Sublayers?
            .SelectMany(s => new[] { s }.Concat(s.GetAllSublayers()))
            .ToList() ?? [];
    }

    /// <inheritdoc />
    public override ValueTask Refresh()
    {
        if (Layer is not null)
        {
            Layer.LayerChanged = true;
        }
        return base.Refresh();
    }

    /// <summary>
    ///     Copies values when returning from ArcGIS JavaScript. For internal use only.
    /// </summary>
    public async Task UpdateFromJavaScript(Sublayer renderedSublayer)
    {
        DefinitionExpression ??= renderedSublayer.DefinitionExpression;
        FloorInfo ??= renderedSublayer.FloorInfo;
        SublayerId ??= renderedSublayer.SublayerId;
        LabelsVisible ??= renderedSublayer.LabelsVisible;
        LegendEnabled ??= renderedSublayer.LegendEnabled;
        ListMode ??= renderedSublayer.ListMode;
        MaxScale ??= renderedSublayer.MaxScale;
        MinScale ??= renderedSublayer.MinScale;
        Opacity ??= renderedSublayer.Opacity;
        PopupEnabled ??= renderedSublayer.PopupEnabled;
        Title ??= renderedSublayer.Title;
        Visible ??= renderedSublayer.Visible;
        PopupTemplate ??= renderedSublayer.PopupTemplate;
        Renderer ??= renderedSublayer.Renderer;
        Source ??= renderedSublayer.Source;
        Capabilities ??= renderedSublayer.Capabilities;
        Fields ??= renderedSublayer.Fields;
        FieldsIndex ??= renderedSublayer.FieldsIndex;
        FullExtent ??= renderedSublayer.FullExtent;
        ObjectIdField ??= renderedSublayer.ObjectIdField;
        SourceJSON ??= renderedSublayer.SourceJSON;
        TypeIdField ??= renderedSublayer.TypeIdField;
        Types ??= renderedSublayer.Types;
        Url ??= renderedSublayer.Url;
        
        await CoreJsModule!.InvokeVoidAsync("registerGeoBlazorSublayer", Layer!.Id,
            renderedSublayer.SublayerId, renderedSublayer.Id);

        if (renderedSublayer.Sublayers is null)
        {
            return;
        }
        foreach (Sublayer childSublayer in renderedSublayer.Sublayers)
        {
            Sublayer? matchingLayer = _sublayers.FirstOrDefault(l => l.Id == childSublayer.Id);

            if (matchingLayer is not null)
            {
                await matchingLayer.UpdateFromJavaScript(childSublayer);
            }
            else
            {
                _sublayers.Add(childSublayer);
            }
        }
    }
    
    /// <summary>
    ///     Describes the layer's supported capabilities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public SublayerCapabilities? Capabilities { get; set; }
    
    /// <summary>
    ///     An array of fields in the Sublayer. Each field represents an attribute that may contain a value for each feature in the Sublayer. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Field[]? Fields { get; set; }

    /// <summary>
    ///     A convenient property that can be used to make case-insensitive lookups for a field by name. It can also provide a list of the date fields in a Sublayer. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public FieldsIndex? FieldsIndex { get; set; }
    
    /// <summary>
    ///     Rhe full extent of the Sublayer. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Extent? FullExtent { get; set; }

    /// <summary>
    ///     The name of an oid field containing a unique value or identifier for each feature in the Sublayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? ObjectIdField { get; set; }

    /// <summary>
    ///     The map service's metadata JSON exposed by the ArcGIS REST API. While most commonly used properties are exposed on the Sublayer class directly, this property gives access to all information returned by the map service. This property is useful if working in an application built using an older version of the API which requires access to map service properties from a more recent version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? SourceJSON { get; set; }

    /// <summary>
    ///     The name of the field holding the type ID or subtypes for the features. See ArcGIS Pro subtypes document. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? TypeIdField { get; set; }

    /// <summary>
    ///     An array of types defined in the feature service exposed by ArcGIS REST API. Each item includes information about the type, such as the type ID, name, and definition expression. This property is only available after the Sublayer has been loaded.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public FeatureType[]? Types { get; set; }

    /// <summary>
    ///     The URL to the REST endpoint of the sublayer. This allows you to view the schema of fields and query tables located in registered workspaces.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Url { get; set; }

    /// <summary>
    ///     Sets any property to a new value after initial render. Supports all basic types (strings, numbers, booleans, dictionaries) and properties.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to set.
    /// </param>
    /// <param name="value">
    ///     The new value.
    /// </param>
    public async Task SetProperty(string propertyName, object? value)
    {
        if (CoreJsModule is null) return;
        ModifiedParameters[propertyName] = value;
        await CoreJsModule!.InvokeVoidAsync("setSublayerProperty", Layer?.JsComponentReference, 
            SublayerId, propertyName.ToLowerFirstChar(), value);
    }
    
    /// <summary>
    ///     Update LegendEnabled after render.
    /// </summary>
    public async Task SetLegendEnabled(bool enabled)
    {
        await SetProperty(nameof(LegendEnabled).ToLowerFirstChar(), enabled);
    }

    /// <summary>
    ///     Update PopupEnabled after render.
    /// </summary>
    public async Task SetPopupEnabled(bool enabled)
    {
        await SetProperty(nameof(PopupEnabled).ToLowerFirstChar(), enabled);
    }
    
    /// <summary>
    ///     Update PopupTemplate after render.
    /// </summary>
    public async Task SetPopupTemplate(PopupTemplate popupTemplate)
    {
        if (CoreJsModule is null) return;
        ModifiedParameters[nameof(PopupTemplate)] = popupTemplate;
        await CoreJsModule!.InvokeVoidAsync("setSublayerPopupTemplate", Layer?.JsComponentReference, 
            SublayerId, popupTemplate, View?.Id);
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerFloorInfo floorInfo:
                FloorInfo = floorInfo;
                
                break;
            case Label label:
                _labelingInfo.Add(label);

                break;
            case PopupTemplate popupTemplate:
                PopupTemplate = popupTemplate;
                
                break;
            case Renderer renderer:
                Renderer = renderer;

                break;
            case Sublayer sublayer:
                _sublayers.Add(sublayer);

                break;
            case DynamicLayer dynamicLayer:
                Source = dynamicLayer;

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
            case LayerFloorInfo:
                FloorInfo = null;
                
                break;
            case Label label:
                _labelingInfo.Remove(label);

                break;
            case PopupTemplate _:
                PopupTemplate = null;

                break;
            case DynamicLayer:
                Source = null;

                break;
            case Sublayer sublayer:
                _sublayers.Remove(sublayer);

                break;
            case Renderer _:
                Renderer = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        FloorInfo?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
        Source?.ValidateRequiredChildren();

        foreach (Label label in _labelingInfo)
        {
            label.ValidateRequiredChildren();
        }

        foreach (Sublayer sublayer in _sublayers)
        {
            sublayer.ValidateRequiredChildren();
        }
        base.ValidateRequiredChildren();
    }
    
    private HashSet<Label> _labelingInfo = new();
    private List<Sublayer> _sublayers = new();
}