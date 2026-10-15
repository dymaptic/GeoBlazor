namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Advanced GeoBlazor Parser for GeoJSON Layers that supports additional properties like in the <a target="_blank" href="https://wiki.openstreetmap.org/wiki/Geojson_CSS">OpenStreetMap GeoJSON CSS</a> spec and the <a target="_blank" href="https://github.com/mapbox/simplestyle-spec/tree/master/1.1.0">Mapbox SimpleStyle</a> spec.
/// </summary>
public class ProGeoJSONLayer: GeoJSONLayer
{
    /// <summary>
    ///     HttpClient for fetching GeoJSON content from a URL.
    /// </summary>
    [Inject]
    [JsonIgnore]
    public HttpClient HttpClient { get; set; } = null!; // can't use `required` with [JsonIgnore]
    
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ProGeoJSONLayer()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="url">
    ///     The URL of the GeoJSON file.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#url">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="sourceJSON">
    ///     The GeoJSON content as a string. Can be set directly or fetched from the <see cref="Url"/> property.
    /// </param>
    /// <param name="copyright">
    ///     Copyright information for the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#copyright">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title of the layer used to identify it in places such as the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="opacity">
    ///     The opacity of the layer.
    ///     default 1
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#opacity">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     Indicates if the layer is visible in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#visible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="listMode">
    ///     Indicates how the layer should display in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget.
    ///     default "show"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#listMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="arcGISLayerId">
    ///     The unique ID assigned to the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="attributeTableTemplate">
    ///     This property is used to configure the associated layer's <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FeatureTable.html">FeatureTable</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#attributeTableTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="blendMode">
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer.
    ///     default normal
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-BlendLayer.html#blendMode">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="customParameters">
    ///     A list of custom parameters appended to the URL of all resources fetched by the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#customParameters">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="definitionExpression">
    ///     The SQL where clause used to filter features on the client.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#definitionExpression">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="displayField">
    ///     The name of the layer's primary display field.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#displayField">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="displayFilterEnabled">
    /// </param>
    /// <param name="displayFilterInfo">
    /// </param>
    /// <param name="editingEnabled">
    ///     Indicates if the layer is editable.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#editingEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="effect">
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to
    ///     how image filters work.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#effect">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="elevationInfo">
    ///     Specifies how features are placed on the vertical axis (z).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#elevationInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="featureEffect">
    ///     The featureEffect can be used to draw attention features of interest.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#featureEffect">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="featureReduction">
    ///     Configures the method for reducing the number of features in the view.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fields">
    ///     An array of fields in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#fields">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="fullExtent">
    ///     The full extent of the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#fullExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometryType">
    ///     The geometry type of features in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#geometryType">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="isBasemapReferenceLayer">
    ///     Indicates whether the layer is a basemap reference layer. Default value: false.
    /// </param>
    /// <param name="labelingInfo">
    ///     The label definition for this layer, specified as an array of
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html">LabelClass</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#labelingInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="labelsVisible">
    ///     Indicates whether to display labels for this layer.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#labelsVisible">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="legendEnabled">
    ///     Indicates whether the layer will be included in the legend.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#legendEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="maxScale">
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ScaleRangeLayer.html#maxScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minScale">
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-ScaleRangeLayer.html#minScale">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="objectIdField">
    ///     The name of a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#fields">field</a> containing a unique value or identifier for each feature in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#objectIdField">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="orderBy">
    ///     Determines the order in which features are drawn in the view.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#orderBy">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="outFields">
    ///     An array of field names from the geoJSON file to include with each feature.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#outFields">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="persistenceEnabled">
    ///     Enable persistence of the layer in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html">WebMap</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html">WebScene</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-OperationalLayer.html#persistenceEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="popupEnabled">
    ///     Indicates whether to display popups when features in the layer are clicked.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#popupEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="popupTemplate">
    ///     The popup template for the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#popupTemplate">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="portalItem">
    ///     The portal item referencing the geojson file from which the GeoJSONLayer is loaded.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#portalItem">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#refreshInterval">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="renderer">
    ///     The renderer assigned to the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#renderer">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="screenSizePerspectiveEnabled">
    ///     Apply perspective scaling to screen-size point symbols in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#screenSizePerspectiveEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the layer.
    ///     default SpatialReference.WGS84
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="templates">
    ///     An array of feature templates defined in the layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#templates">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeExtent">
    ///     The layer's time extent.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#timeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeInfo">
    ///     TimeInfo provides information such as date fields that store <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TimeInfo.html#startField">start</a>
    ///     and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TimeInfo.html#endField">end</a> time
    ///     for each feature and the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-TimeInfo.html#fullTimeExtent">fullTimeExtent</a>
    ///     for the layer.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#timeInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeOffset">
    ///     A temporary offset of the time data based on a certain <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-time-TimeInterval.html">TimeInterval</a>.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#timeOffset">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="trackInfo">
    ///     Allows you to render track data for a layer, including a track line, previous observations, and latest observations.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#trackInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="useViewTime">
    ///     Determines if the layer will update its temporal data based on the view's
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html#timeExtent">timeExtent</a>.
    ///     default true
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#useViewTime">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibilityTimeExtent">
    ///     Specifies a fixed <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-time-TimeExtent.html">time extent</a> during which a layer should be visible.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html#visibilityTimeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="applyStyles">
    ///     If the GeoJSON source contains style information such as in the <a target="_blank" href="https://wiki.openstreetmap.org/wiki/Geojson_CSS">OpenStreetMap GeoJSON CSS</a> spec or the <a target="_blank" href="https://github.com/mapbox/simplestyle-spec/tree/master/1.1.0">Mapbox SimpleStyle</a> spec, this property must be set to determine whether to apply those styles to the features.
    /// </param>
    public ProGeoJSONLayer(
        string url,
        string sourceJSON = "",
        string? copyright = null,
        string? title = null,
        double? opacity = null,
        bool? visible = null,
        ListMode? listMode = null,
        string? arcGISLayerId = null,
        IAttributeTableTemplate? attributeTableTemplate = null,
        BlendMode? blendMode = null,
        Dictionary<string, object>? customParameters = null,
        string? definitionExpression = null,
        string? displayField = null,
        bool? displayFilterEnabled = null,
        DisplayFilterInfo? displayFilterInfo = null,
        bool? editingEnabled = null,
        Effect? effect = null,
        ElevationInfo? elevationInfo = null,
        FeatureEffect? featureEffect = null,
        IFeatureReduction? featureReduction = null,
        IReadOnlyList<Field>? fields = null,
        Extent? fullExtent = null,
        SimpleGeometryType? geometryType = null,
        bool? isBasemapReferenceLayer = null,
        IReadOnlyList<Label>? labelingInfo = null,
        bool? labelsVisible = null,
        bool? legendEnabled = null,
        double? maxScale = null,
        double? minScale = null,
        string? objectIdField = null,
        IReadOnlyList<OrderByInfo>? orderBy = null,
        IReadOnlyList<string>? outFields = null,
        bool? persistenceEnabled = null,
        bool? popupEnabled = null,
        PopupTemplate? popupTemplate = null,
        PortalItem? portalItem = null,
        double? refreshInterval = null,
        Renderer? renderer = null,
        bool? screenSizePerspectiveEnabled = null,
        SpatialReference? spatialReference = null,
        IReadOnlyList<IFeatureTemplate>? templates = null,
        TimeExtent? timeExtent = null,
        TimeInfo? timeInfo = null,
        TimeInterval? timeOffset = null,
        TrackInfo? trackInfo = null,
        bool? useViewTime = null,
        TimeExtent? visibilityTimeExtent = null,
        bool? applyStyles = null):base(url, copyright, title, opacity, visible, listMode, arcGISLayerId, 
        attributeTableTemplate, blendMode, customParameters, definitionExpression, displayField, displayFilterEnabled,
        displayFilterInfo, editingEnabled, effect, elevationInfo, featureEffect, featureReduction, fields, fullExtent,
        geometryType, isBasemapReferenceLayer, labelingInfo, labelsVisible, legendEnabled, maxScale, minScale,
        objectIdField, orderBy, outFields, persistenceEnabled, popupEnabled, popupTemplate, portalItem, refreshInterval,
        renderer, screenSizePerspectiveEnabled, spatialReference, templates, timeExtent, timeInfo, timeOffset, trackInfo,
        useViewTime, visibilityTimeExtent)
    {
        SourceJSON = sourceJSON;
        ApplyStyles = applyStyles;
    }

    /// <inheritdoc />
    public override LayerType Type => LayerType.ProGeoJSON;
    
    /// <summary>
    ///     If the GeoJSON source contains style information such as in the <a target="_blank" href="https://wiki.openstreetmap.org/wiki/Geojson_CSS">OpenStreetMap GeoJSON CSS</a> spec or the <a target="_blank" href="https://github.com/mapbox/simplestyle-spec/tree/master/1.1.0">Mapbox SimpleStyle</a> spec, this property must be set to determine whether to apply those styles to the features.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public bool? ApplyStyles { get; set; }

    /// <summary>
    ///     The deserialized collection of <see cref="Graphic"/> features parsed from the GeoJSON content.
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore]
    public IReadOnlyList<Graphic> Features { get; private set; } = [];

    /// <summary>
    ///     The GeoJSON content as a string. Can be set directly or fetched from the <see cref="Url"/> property.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(Url))]
    public string? SourceJSON { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.GeoJSONLayer.html#geojsonlayerurl-property">GeoBlazor Docs</a>
    ///     The URL of the GeoJSON file.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GeoJSONLayer.html#url">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [RequiredProperty(nameof(SourceJSON))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public override string Url { get; set; } = null!;
    
    /// <inheritdoc />
    public override async Task Load(IJSRuntime jsRuntime, JsModuleManager jsModuleManager,
        CancellationToken cancellationToken)
    {
        await ParseJSON();
        await base.Load(jsRuntime, jsModuleManager, cancellationToken);
    }
    
    /// <inheritdoc />
    public override async Task Load(CancellationToken cancellationToken)
    {
        await ParseJSON();
        await base.Load(cancellationToken);
    }

    /// <inheritdoc />
    public override async Task Load()
    {
        await ParseJSON();
        await base.Load();
    }

    /// <summary>
    ///     Method for pre-parsing the GeoJSON content from the <see cref="Url"/> or <see cref="SourceJSON"/> properties before sending to ArcGIS. This is called automatically when the <see cref="ProGeoJSONLayer"/> is added in markup or when layer.Load() is called. If the layer is added to the map in code, this method or load should be called first.
    /// </summary>
    public async Task ParseJSON()
    {
        if (_parsed || (string.IsNullOrEmpty(Url) && string.IsNullOrEmpty(SourceJSON)))
        {
            return;
        }

        try
        {
            _parsed = true;
            if (string.IsNullOrEmpty(SourceJSON))
            {
                // Fetch GeoJSON content from URL
                HttpResponseMessage response = await HttpClient.GetAsync(Url);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                SourceJSON = content;
            }

            // Deserialize GeoJSON
            GeoJSONFeatureCollection? geoJsonFeatureCollection = 
                JsonSerializer.Deserialize<GeoJSONFeatureCollection>(SourceJSON, 
                    GeoBlazorSerialization.JsonSerializerOptions);

            if (geoJsonFeatureCollection?.Features == null || geoJsonFeatureCollection.Features.Count == 0)
            {
                return;
            }
            
            // Check for styles and ApplyStyles property
            if (geoJsonFeatureCollection.Style is not null
                || geoJsonFeatureCollection.Features.Any(f =>
                    f.Style is not null || f.Properties is not null
                    && f.Properties.Keys.Any(k => GeoJSONStyle.StyleProperties.Contains(k))))
            {
                // styles found in the collection or features
                if (ApplyStyles is null)
                {
                    throw new ProGeoJSONLayerException(
                        "The GeoJSON source contains style information, but the ApplyStyles property is not set. Please set ApplyStyles parameter/property to true or false.");
                }
            }

            List<Graphic> graphics = [];
            List<UniqueValueInfo> uniqueValueInfos = [];
            bool hasObjectIdField = !string.IsNullOrEmpty(ObjectIdField);
            GeoJSONFeature first = geoJsonFeatureCollection.Features[0];
            hasObjectIdField = hasObjectIdField && first.Properties is not null 
                && first.Properties!.ContainsKey(ObjectIdField!);

            if (!hasObjectIdField)
            {
                ObjectIdField = "__ObjectID";
            }
            int index = 1;
            
            GeoJSONStyle? collectionStyle = geoJsonFeatureCollection.Style;

            foreach (GeoJSONFeature feature in geoJsonFeatureCollection.Features)
            {
                // Create geometry from GeoJSON geometry
                Geometry? geometry = CreateGeometryFromGeoJson(feature.Geometry);
                if (geometry == null) continue;

                Symbol symbol;

                string? name = feature.Properties?.GetValueOrDefault("name")?.ToString()
                    ?? feature.Properties?.GetValueOrDefault("title")?.ToString();

                if (ApplyStyles == true)
                {
                    // Extract GeoJSON CSS styling from properties if it is not in the "Style" property
                    GeoJSONStyle geoJsonStyle = feature.Style ?? ExtractGeoJsonStyle(feature.Properties);
    
                    // Create symbol based on geometry type and style
                    symbol = CreateSymbolFromStyle(geometry, geoJsonStyle, collectionStyle) 
                        ?? GetDefaultSymbolForGeometry(feature.Geometry!.Type.ToLowerInvariant());
                }
                else
                {
                    symbol = GetDefaultSymbolForGeometry(feature.Geometry!.Type.ToLowerInvariant());
                }
                
                // Set attributes for the graphic
                AttributesDictionary attributes = feature.Properties != null
                    ? new AttributesDictionary(feature.Properties)
                    : new AttributesDictionary();

                int objectId;

                if (hasObjectIdField)
                {
                    int.TryParse(feature.Properties![ObjectIdField!]!.ToString(), out objectId);
                }
                else
                {
                    objectId = index++;
                    await attributes.AddOrUpdate(ObjectIdField ?? "__ObjectID", objectId);
                }

                // Create graphic
                var graphic = new Graphic(geometry, symbol, attributes: attributes);

                graphics.Add(graphic);
                
                // create unique value info for the symbol
                if (ApplyStyles == true)
                {
                    UniqueValueInfo uniqueValueInfo = 
                        new UniqueValueInfo(name ?? objectId.ToString(), symbol, objectId.ToString());
                    uniqueValueInfos.Add(uniqueValueInfo);
                }
            }

            if (uniqueValueInfos.Count > 0)
            {
                Renderer = new UniqueValueRenderer(uniqueValueInfos: uniqueValueInfos, field: ObjectIdField!,
                    defaultLabel: Title);
            }
            
            // set the Features so that the layer is rendered when the map is rendered
            Features = graphics;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing GeoJSON: {ex.Message}");

            throw;
        }
    }

    private Geometry? CreateGeometryFromGeoJson(GeoJSONGeometry? geoJsonGeometry)
    {
        if (geoJsonGeometry == null) return null;

        try
        {
            return geoJsonGeometry.Type.ToLower() switch
            {
                "point" => CreatePoint(geoJsonGeometry.Coordinates),
                "linestring" => CreatePolyline(geoJsonGeometry.Coordinates),
                "polygon" => CreatePolygon(geoJsonGeometry.Coordinates),
                "multipoint" => CreateMultipoint(geoJsonGeometry.Coordinates),
                _ => null
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating geometry: {ex.Message}");
            return null;
        }
    }

    private Point CreatePoint(JsonElement coordinates)
    {
        double[] coords = coordinates.EnumerateArray().Select(c => c.GetDouble()).ToArray();
        return new Point(coords[0], coords[1]);
    }

    private Polyline CreatePolyline(JsonElement coordinates)
    {
        List<MapPath> paths = [];
        MapPath path = [];

        foreach (JsonElement coord in coordinates.EnumerateArray())
        {
            double[] coords = coord.EnumerateArray().Select(c => c.GetDouble()).ToArray();
            path.Add(new MapPoint(coords[0], coords[1]));
        }

        paths.Add(path);
        return new Polyline(paths);
    }

    private Polygon CreatePolygon(JsonElement coordinates)
    {
        List<MapPath> rings = [];
        
        foreach (JsonElement ring in coordinates.EnumerateArray())
        {
            MapPath ringPath = [];
            foreach (JsonElement coord in ring.EnumerateArray())
            {
                double[] coords = coord.EnumerateArray().Select(c => c.GetDouble()).ToArray();
                ringPath.Add(new MapPoint(coords[0], coords[1]));
            }
            rings.Add(ringPath);
        }

        return new Polygon(rings);
    }

    private Multipoint CreateMultipoint(JsonElement coordinates)
    {
        var points = new List<Point>();

        foreach (JsonElement coord in coordinates.EnumerateArray())
        {
            double[] coords = coord.EnumerateArray().Select(c => c.GetDouble()).ToArray();
            points.Add(new Point(coords[0], coords[1]));
        }

        return new Multipoint(points: points);
    }
    
    private Symbol GetDefaultSymbolForGeometry(string geometryType)
    {
        return geometryType switch
        {
            "point" => new SimpleMarkerSymbol(),
            "multipoint" => new SimpleMarkerSymbol(),
            "linestring" => new SimpleLineSymbol(),
            "polygon" => new SimpleFillSymbol(new Outline()),
            _ => throw new NotImplementedException($"Geometry type {geometryType} is not supported.")
        };
    }

    private GeoJSONStyle ExtractGeoJsonStyle(Dictionary<string, object?>? properties)
    {
        if (properties == null) return new GeoJSONStyle();

        return new GeoJSONStyle
        {
            Title = GetPropertyAsString(properties, "title"),
            Description = GetPropertyAsString(properties, "description"),
            MarkerSize = GetPropertyAsString(properties, "marker-size"),
            MarkerSymbol = GetPropertyAsString(properties, "marker-symbol"),
            MarkerColor = GetPropertyAsString(properties, "marker-color"),
            Stroke = GetPropertyAsString(properties, "stroke"),
            StrokeOpacity = GetPropertyAsDouble(properties, "stroke-opacity"),
            StrokeWidth = GetPropertyAsDouble(properties, "stroke-width"),
            StrokeLinecap = GetPropertyAsString(properties, "stroke-linecap"),
            StrokeLinejoin = GetPropertyAsString(properties, "stroke-linejoin"),
            StrokeDasharray = GetPropertyAsString(properties, "stroke-dasharray"),
            Fill = GetPropertyAsString(properties, "fill"),
            FillOpacity = GetPropertyAsDouble(properties, "fill-opacity"),
            Text = GetPropertyAsString(properties, "text"),
            FontSize = GetPropertyAsString(properties, "font-size"),
            FontWeight = GetPropertyAsString(properties, "font-weight"),
            FontStyle = GetPropertyAsString(properties, "font-style")
        };
    }

    private string? GetPropertyAsString(Dictionary<string, object?> properties, string key)
    {
        return properties.TryGetValue(key, out object? value) ? value?.ToString() : null;
    }

    private double? GetPropertyAsDouble(Dictionary<string, object?> properties, string key)
    {
        if (properties.TryGetValue(key, out object? value) && double.TryParse(value?.ToString(), out double doubleValue))
        {
            return doubleValue;
        }
        return null;
    }

    private Symbol? CreateSymbolFromStyle(Geometry geometry, GeoJSONStyle style, GeoJSONStyle? collectionStyle)
    {
        return geometry switch
        {
            Point => CreatePointSymbol(style, collectionStyle),
            Multipoint => CreatePointSymbol(style, collectionStyle),
            Polyline => CreateLineSymbol(style, collectionStyle),
            Polygon => CreateFillSymbol(style, collectionStyle),
            _ => null
        };
    }

    private SimpleMarkerSymbol CreatePointSymbol(GeoJSONStyle style, GeoJSONStyle? collectionStyle)
    {
        string? markerSize = style.MarkerSize ?? collectionStyle?.MarkerSize;
        Dimension? markerSizeDimension = markerSize switch
        {
            "small" => new Dimension(8),
            "medium" => new Dimension(12),
            "large" => new Dimension(16),
            null => null,
            _ => new  Dimension(markerSize)
        };
            
        MapColor markerColor = new MapColor(style.MarkerColor ?? style.Fill 
            ?? collectionStyle?.MarkerColor ?? collectionStyle?.Fill ?? "#7e7e7e");
        double? opacity = style.FillOpacity ?? collectionStyle?.FillOpacity;
        if (opacity is < 1)
        {
            markerColor = new MapColor(markerColor.RgbaValues![0], markerColor.RgbaValues![1], 
                markerColor.RgbaValues![2], opacity.Value);
        }
        
        Outline outline = new Outline(CreateLineSymbol(style, collectionStyle));
        
        return new SimpleMarkerSymbol(outline, markerColor, markerSizeDimension);
    }

    private SimpleLineSymbol CreateLineSymbol(GeoJSONStyle style, GeoJSONStyle? collectionStyle)
    {
        MapColor strokeColor = new MapColor(style.Stroke ?? collectionStyle?.Stroke ?? "#555555");
        double strokeWidth = style.StrokeWidth ?? collectionStyle?.StrokeWidth ?? 0.75;
        Cap strokeCap = style.StrokeLinecap switch
        {
            "round" => Cap.Round,
            "square" => Cap.Square,
            _ => Cap.Butt
        };
        Join strokeJoin = style.StrokeLinejoin switch
        {
            "round" => Join.Round,
            "bevel" => Join.Bevel,
            _ => Join.Miter
        };
        string? strokeDasharray = style.StrokeDasharray ?? collectionStyle?.StrokeDasharray;
        SimpleLineSymbolStyle strokeLineStyle = SimpleLineSymbolStyle.Solid;

        if (strokeDasharray is not null)
        {
            strokeDasharray = strokeDasharray.Replace(",", "").Replace(" ", "");
            strokeLineStyle = strokeDasharray switch
            {
                "4" => SimpleLineSymbolStyle.Dash,
                "4313" => SimpleLineSymbolStyle.DashDot,
                "12" => SimpleLineSymbolStyle.Dot,
                "83" => SimpleLineSymbolStyle.LongDash,
                "8313" => SimpleLineSymbolStyle.LongDashDot,
                "831313" => SimpleLineSymbolStyle.LongDashDotDot,
                "41" => SimpleLineSymbolStyle.ShortDash,
                "4111" => SimpleLineSymbolStyle.ShortDashDot,
                "411111" => SimpleLineSymbolStyle.ShortDashDotDot,
                "1" => SimpleLineSymbolStyle.ShortDot,
                _ => SimpleLineSymbolStyle.Solid
            };
        }

        return new SimpleLineSymbol(strokeColor, strokeWidth, strokeLineStyle, strokeCap, strokeJoin);
    }

    private SimpleFillSymbol CreateFillSymbol(GeoJSONStyle style, GeoJSONStyle? collectionStyle)
    {
        MapColor fillColor = new MapColor(style.Fill ?? collectionStyle?.Fill ?? "#ffffff");
        double? fillOpacity = style.FillOpacity ?? collectionStyle?.FillOpacity;
        if (fillOpacity is < 1)
        {
            fillColor = new MapColor(fillColor.RgbaValues![0], fillColor.RgbaValues![1], fillColor.RgbaValues![2], 
                fillOpacity.Value);
        }
        Outline outline = new Outline(CreateLineSymbol(style, collectionStyle));
        return new SimpleFillSymbol(outline, fillColor);
    }

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await ParseJSON();
        await base.OnInitializedAsync();
    }
    private bool _parsed;
}

/// <summary>
///     Exception thrown when there is an issue with the ProGeoJSONLayer.
/// </summary>
public class ProGeoJSONLayerException(string s) : Exception(s);