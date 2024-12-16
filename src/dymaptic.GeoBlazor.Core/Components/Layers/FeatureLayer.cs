using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Enums;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Interfaces;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Options;
using dymaptic.GeoBlazor.Core.Results;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A FeatureLayer is a single layer that can be created from a Map Service or Feature Service; ArcGIS Online or ArcGIS
///     Enterprise portal items; or from an array of client-side features. The layer can be either a spatial (has
///     geographic features) or non-spatial (table).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <example>
///     <a target="_blank" href="https://samples.geoblazor.com/feature-layers">Sample - Feature Layers</a>
/// </example>
public class FeatureLayer : Layer, IFeatureReductionLayer, IPopupTemplateLayer, IFeatureLayerBase
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
    /// <param name="popupTemplate">
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </param>
    public FeatureLayer(string? url = null, PortalItem? portalItem = null, IReadOnlyList<Graphic>? source = null,
        string[]? outFields = null, string? definitionExpression = null, int? minScale = null,
        int? maxScale = null, string? objectIdField = null, GeometryType? geometryType = null, string? title = null,
        double? opacity = null, bool? visible = null, ListMode? listMode = null, PopupTemplate? popupTemplate = null)
    {
        if (url is null && portalItem is null && source is null)
        {
            throw new MissingRequiredOptionsChildElementException(nameof(FeatureLayer),
                new[] { nameof(Url), nameof(PortalItem), nameof(Source) });
        }
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
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
        PopupTemplate = popupTemplate;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
    }
    
    /// <summary>
    ///     An authorization string used to access a resource or service. API keys are generated and managed in the ArcGIS Developer dashboard. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage. Setting a fine-grained API key on a specific class overrides the global API key.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKey { get; set; }
    
    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what seems like a new layer. Unlike the method of using transparency which can result in a washed-out top layer, blend modes can create a variety of very vibrant and intriguing results by blending a layer with the layer(s) below it.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }
    
    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Effect? Effect { get; set; }

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
    public int? MinScale { get; set; }

    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxScale { get; set; }

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
    ///     Indicates whether the layer will be included in the legend.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LegendEnabled { get; set; }
    
    /// <summary>
    ///     Indicates whether to display popups when features in the layer are clicked.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }

    /// <summary>
    ///     Determines the order in which features are drawn in the view.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<OrderedLayerOrderBy>? OrderBy { get; set; }

    /// <summary>
    ///     The <see cref="PopupTemplate" /> for the layer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }

    /// <summary>
    ///     The label definition for this layer, specified as an array of <see cref="Label" />.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<Label>? LabelingInfo { get; set; }

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
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [RequiredProperty(nameof(Url), nameof(PortalItem))]
#pragma warning disable BL0007
    public IReadOnlyCollection<Graphic>? Source
#pragma warning restore BL0007
    {
        get => _source;
        set
        {
            if (value is not null && (_source is null || !_source!.Any()))
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

    /// <summary>
    ///     The template used in an associated layer's FeatureForm Widget (Available in GeoBlazor Pro). All of the properties and field configurations set on the layer's FeatureForm are handled via the FormTemplate.
    /// </summary>
    public FormTemplate? FormTemplate { get; set; }

    /// <inheritdoc />
    public override string LayerType => "feature";

    /// <summary>
    /// TimeInfo provides information such as date fields that store start and end time for each feature and the fullTimeExtent for the layer.
    /// </summary>
    public TimeInfo? TimeInfo { get; set; }
    
    /// <summary>  
    ///     Configures the method for reducing the number of point features in the view.  
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureReductionLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>  
    /// </summary>  
    [Parameter]  
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  
    [CodeGenerationIgnore]
    public IFeatureReduction? FeatureReduction { get; set; }

    /// <summary>
    ///     Add a graphic to the current layer's source
    /// </summary>
    /// <param name="graphic">
    ///     The graphic to add
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///     If the layer is already loaded, you must use <see cref="ApplyEdits"/> to add graphics.
    /// </exception>
    public async Task Add(Graphic graphic)
    {
        if (JsComponentReference is not null)
        {
            await ApplyEdits(new FeatureEdits
            {
                AddFeatures = new []{graphic}
            });

            return;
        }
        await RegisterChildComponent(graphic);
    }

    /// <summary>
    ///     Adds a collection of graphics to the feature layer
    /// </summary>
    /// <param name="graphics">
    ///     The graphics to add
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///     If the layer is already loaded, you must use <see cref="ApplyEdits"/> to add graphics.
    /// </exception>
    public async Task Add(IReadOnlyList<Graphic> graphics)
    {
        if (JsComponentReference is not null)
        {
            await ApplyEdits(new FeatureEdits
            {
                AddFeatures = graphics
            });

            return;
        }
        foreach (Graphic graphic in graphics)
        {
            await RegisterChildComponent(graphic);
        }
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

    /// <summary>
    ///     Applies edits to features in a layer. New features can be created and existing features can be updated or deleted. Feature geometries and/or attributes may be modified. Only applicable to layers in a feature service and client-side features set through the FeatureLayer's source property. Attachments can also be added, updated or deleted.
    ///     If client-side features are added, removed or updated at runtime using applyEdits() then use FeatureLayer's queryFeatures() method to return updated features.
    /// </summary>
    public async Task<FeatureEditsResult> ApplyEdits(FeatureEdits edits, FeatureEditOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Verify that the layer is loaded. Layers with no graphics are not rendered and therefore not loaded
        // as far as GeoBlazor is concerned
        if (CoreJsModule is not null && JsComponentReference is null)
        {
            await Load(cancellationToken);
        }
        
        FeatureEditsResult emptyResult = new FeatureEditsResult(Array.Empty<FeatureEditResult>(), 
            Array.Empty<FeatureEditResult>(),
            Array.Empty<FeatureEditResult>(),
            Array.Empty<FeatureEditResult>(),
            Array.Empty<FeatureEditResult>(),
            Array.Empty<FeatureEditResult>(),
            Array.Empty<EditedFeatureResult>(),
            null);

        if (cancellationToken.IsCancellationRequested ||
            CancellationTokenSource.Token.IsCancellationRequested)
        {
            return emptyResult;
        }

        Graphic[] addedFeatures = edits.AddFeatures?.ToArray() ?? Array.Empty<Graphic>();
        Graphic[] updatedFeatures = edits.UpdateFeatures?.ToArray() ?? Array.Empty<Graphic>();
        Graphic[] deletedFeatures = edits.DeleteFeatures?.ToArray() ?? Array.Empty<Graphic>();
        long? editMoment = null;
        int chunkSize = View!.GraphicSerializationChunkSize ?? (View.IsMaui ? 100 : 200);
        ProJsModule ??= await JsModuleManager.GetArcGisJsPro(JsRuntime, cancellationToken);
        CoreJsModule ??= await JsModuleManager.GetArcGisJsCore(JsRuntime, ProJsModule, cancellationToken);
        AbortManager ??= new AbortManager(CoreJsModule);
        
        // return await JsComponentReference!.InvokeAsync<FeatureEditsResult>("applyEdits", edits, options,
        //     View!.Id);
        FeatureEditsResult? addFeatureResults = null;
        FeatureEditsResult? updateFeatureResults = null;
        FeatureEditsResult? deleteFeatureResults = null;
        List<EditedFeatureResult> editedFeatureResults = new();
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        for (var index = 0; index < addedFeatures.Length; index += chunkSize)
        {
            int skip = index;

            addFeatureResults = 
                await SendEdits(addedFeatures.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToSerializationRecord(true)).ToArray(), "add", 
                    options, addFeatureResults, abortSignal, cancellationToken);
            editMoment ??= addFeatureResults?.EditMoment;
        }
        for (var index = 0; index < updatedFeatures.Length; index += chunkSize)
        {
            int skip = index;

            updateFeatureResults = 
                await SendEdits(updatedFeatures.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToSerializationRecord(true)).ToArray(), "update", 
                    options, updateFeatureResults, abortSignal, cancellationToken);
            editMoment ??= updateFeatureResults?.EditMoment;
        }
        for (var index = 0; index < deletedFeatures.Length; index += chunkSize)
        {
            int skip = index;

            deleteFeatureResults = 
                await SendEdits(deletedFeatures.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToSerializationRecord(true)).ToArray(), "delete", 
                    options, deleteFeatureResults, abortSignal, cancellationToken);
            editMoment ??= deleteFeatureResults?.EditMoment;
        }
        
        if (addFeatureResults?.EditedFeatureResults is not null)
        {
            editedFeatureResults.AddRange(addFeatureResults.EditedFeatureResults);
        }
        if (updateFeatureResults?.EditedFeatureResults is not null)
        {
            editedFeatureResults.AddRange(updateFeatureResults.EditedFeatureResults);
        }
        if (deleteFeatureResults?.EditedFeatureResults is not null)
        {
            editedFeatureResults.AddRange(deleteFeatureResults.EditedFeatureResults);
        }

        FeatureEditsResult? attachmentResults = null;
        if (edits.AddAttachments?.Any() == true ||
            edits.UpdateAttachments?.Any() == true ||
            edits.DeleteAttachments?.Any() == true)
        {
            FeatureEdits attachmentEdits = new()
            {
                AddAttachments = edits.AddAttachments,
                UpdateAttachments = edits.UpdateAttachments,
                DeleteAttachments = edits.DeleteAttachments
            };
            attachmentResults = await JsComponentReference!.InvokeAsync<FeatureEditsResult>(
                "applyAttachmentEdits", cancellationToken, attachmentEdits, options, View!.Id,
                abortSignal);
            editMoment ??= attachmentResults.EditMoment;
            if (attachmentResults.EditedFeatureResults is not null)
            {
                editedFeatureResults.AddRange(attachmentResults.EditedFeatureResults);
            }
        }
        
        if (_source is not null)
        {
            // update the in-memory collections:
            foreach (Graphic addedGraphic in addedFeatures)
            {
                _source!.Add(addedGraphic);
            }
            foreach (Graphic updatedGraphic in updatedFeatures)
            {
                _source!.Remove(updatedGraphic);
                _source!.Add(updatedGraphic);
            }
            foreach (Graphic deletedGraphic in deletedFeatures)
            {
                _source!.Remove(deletedGraphic);
            }
        }

        return new FeatureEditsResult
        (
            addFeatureResults?.AddFeatureResults ?? Array.Empty<FeatureEditResult>(), 
            updateFeatureResults?.UpdateFeatureResults ?? Array.Empty<FeatureEditResult>(), 
            deleteFeatureResults?.DeleteFeatureResults ?? Array.Empty<FeatureEditResult>(), 
            attachmentResults?.AddAttachmentResults ?? Array.Empty<FeatureEditResult>(),
            attachmentResults?.UpdateAttachmentResults ?? Array.Empty<FeatureEditResult>(),
            attachmentResults?.DeleteAttachmentResults ?? Array.Empty<FeatureEditResult>(),
            editedFeatureResults.ToArray(),
            editMoment
        );
    }

    private async Task<FeatureEditsResult?> SendEdits(GraphicSerializationRecord[] graphics, 
        string editType, FeatureEditOptions? options, FeatureEditsResult? currentResults, 
        IJSObjectReference abortSignal, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested ||
            CancellationTokenSource.Token.IsCancellationRequested)
        {
            return null;
        }
        
        ProtoGraphicCollection collection = new(graphics);
        MemoryStream ms = new();
        Serializer.Serialize(ms, collection);

        if (cancellationToken.IsCancellationRequested ||
            CancellationTokenSource.Token.IsCancellationRequested)
        {
            await ms.DisposeAsync();
            return null;
        }
        
        ms.Seek(0, SeekOrigin.Begin);

        FeatureEditsResult result;
        if (View!.IsWebAssembly)
        {
            result = await JsComponentReference!.InvokeAsync<FeatureEditsResult>(
                "applyGraphicEditsSynchronously", cancellationToken, ms.ToArray(), editType, options, 
                View!.Id, abortSignal);
            await ms.DisposeAsync();
            await Task.Delay(1, cancellationToken);
        }
        else
        {
            using DotNetStreamReference streamRef = new(ms);
            result = await JsComponentReference!.InvokeAsync<FeatureEditsResult>(
                "applyGraphicEditsFromStream", cancellationToken, streamRef, editType, options, 
                View!.Id, abortSignal);
        }

        return result.Concat(currentResults);
    }

    /// <summary>
    /// Returns a FeatureType describing the feature's type. This is applicable if the layer containing the feature has a typeIdField.
    /// </summary>
    /// <param name="feature"></param>
    /// <returns></returns>
    public async Task<FeatureType?> GetFeatureType(Graphic feature)
    {
        return await JsComponentReference!.InvokeAsync<FeatureType>("getFeatureType", feature);
    }

    /// <summary>
    /// Returns the Field instance for a field name (case-insensitive).
    /// </summary>
    /// <param name="fieldName">the field name (case-insensitive).</param>
    public async Task<Field?> GetField(string fieldName)
    {
        return await JsComponentReference!.InvokeAsync<Field?>("getField", fieldName);
    }

    /// <summary>
    /// Returns the Domain associated with the given field name. The domain can be either a CodedValueDomain or RangeDomain.
    /// </summary>
    public async Task<Domain?> GetFieldDomain(string fieldName, Graphic? feature = null)
    {
        return await JsComponentReference!.InvokeAsync<Domain?>("getFieldDomain", fieldName, feature);
    }

    /// <summary>
    ///    Describes the layer's supported capabilities.
    /// </summary>
    public async Task<FeatureLayerCapabilities?> GetCapabilities()
    {
        return await JsComponentReference!.InvokeAsync<FeatureLayerCapabilities>("getCapabilities");
    }

    /// <summary>
    /// Creates a deep clone of the javascript FeatureLayer object.
    /// </summary>
    public async Task<FeatureLayer> Clone()
    {
        return await JsComponentReference!.InvokeAsync<FeatureLayer>("clone");
    }

    /// <summary>
    /// Fetches all the data for the layer. Calls 'refresh' on the layer.
    /// </summary>
    public override ValueTask Refresh()
    {
        _refreshRequired = true;
        return base.Refresh();
    }
    
    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    /// <param name="effect">
    ///     The effect to apply to the layer.
    /// </param>
    public async Task SetEffect(Effect effect)
    {
        await JsComponentReference!.InvokeVoidAsync("setEffect", effect);
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (_refreshRequired)
        {
            _refreshRequired = false;
            var newLayer = await JsComponentReference!.InvokeAsync<FeatureLayer>("refresh");
            await UpdateFromJavaScript(newLayer);
        }

        await base.OnAfterRenderAsync(firstRender);
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
                LabelingInfo ??= new List<Label>();

                if (!LabelingInfo.Contains(label))
                {
                    LabelingInfo = LabelingInfo.Append(label).ToList();
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
                OrderBy ??= new List<OrderedLayerOrderBy>();

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
                    graphic.Parent ??= this;
                    graphic.LayerId ??= Id;
                    _source.Add(graphic);

                    LayerChanged = true;
                }

                break;
            case Field field:
                _fields ??= new HashSet<Field>();

                if (_fields.Add(field))
                {
                    LayerChanged = true;
                }

                break;
            case FormTemplate formTemplate:
                if (!formTemplate.Equals(FormTemplate))
                {
                    FormTemplate = formTemplate;
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
                LabelingInfo = LabelingInfo?.Where(l => !l.Equals(label)).ToList();
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
            case FormTemplate _:
                FormTemplate = null;
                LayerChanged = true;

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
        return await JsComponentReference!.InvokeAsync<PopupTemplate>("createPopupTemplate",
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
        return await JsComponentReference!.InvokeAsync<Query>("createQuery", CancellationTokenSource.Token);
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

        ExtentQueryResult result = await JsComponentReference!.InvokeAsync<ExtentQueryResult>("queryExtent",
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

        int result = await JsComponentReference!.InvokeAsync<int>("queryFeatureCount", cancellationToken,
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
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        Guid queryId = Guid.NewGuid();

        FeatureSet result = (await JsComponentReference!.InvokeAsync<FeatureSet?>("queryFeatures", cancellationToken,
            query, new { signal = abortSignal }, DotNetComponentReference, View?.Id, queryId))!;

        if (_activeQueries.ContainsKey(queryId))
        {
            result.Features = _activeQueries[queryId];
            _activeQueries.Remove(queryId);
        }
        
        foreach (Graphic graphic in result.Features!)
        {
            graphic.LayerId = Id;
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
            await using Stream stream = await streamReference
                .OpenReadStreamAsync(View?.QueryResultsMaxSizeLimit ?? 1_000_000_000L);
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

        int[] queryResult = await JsComponentReference!.InvokeAsync<int[]>("queryObjectIds", cancellationToken,
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
    public async Task<RelatedFeaturesQueryResult?> QueryRelatedFeatures(RelationshipQuery query,
        CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        Guid queryId = Guid.NewGuid();
        RelatedFeaturesQueryResult result = (await JsComponentReference!.InvokeAsync<RelatedFeaturesQueryResult?>(
            "queryRelatedFeatures", cancellationToken, query, new { signal = abortSignal },
            DotNetComponentReference, View?.Id, queryId))!;

        if (_activeRelatedQueries.ContainsKey(queryId))
        {
            Dictionary<long, Graphic[]> relatedGraphics = _activeRelatedQueries[queryId];
            foreach (KeyValuePair<long, FeatureSet?> kvp in result)
            {
                if (kvp.Value is null || !relatedGraphics.TryGetValue(kvp.Key, out Graphic[]? relatedGraphic)) continue;

                kvp.Value.Features = relatedGraphic;

                foreach (Graphic graphic in kvp.Value.Features)
                {
                    graphic.LayerId = Id;
                }
            }
            _activeRelatedQueries.Remove(queryId);
        }

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
    
    /// <summary>
    ///     Internal use callback from JavaScript
    /// </summary>
    [JSInvokable]
    public async Task OnQueryRelatedFeaturesStreamCallback(IJSStreamReference streamReference, Guid queryId, string objectId)
    {
        try
        {
            await using Stream stream = await streamReference
                .OpenReadStreamAsync(View?.QueryResultsMaxSizeLimit ?? 1_000_000_000L);
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ProtoGraphicCollection collection = Serializer.Deserialize<ProtoGraphicCollection>(ms);
            Graphic[] graphics = collection?.Graphics.Select(g => g.FromSerializationRecord()).ToArray()!;

            if (!_activeRelatedQueries.ContainsKey(queryId))
            {
                _activeRelatedQueries[queryId] = new Dictionary<long, Graphic[]>();
            }

            _activeRelatedQueries[queryId][int.Parse(objectId)] = graphics;
        }
        catch (Exception ex)
        {
            throw new SerializationException("Error deserializing graphics from stream.", ex);   
        }
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
    public async Task<RelatedFeaturesCountQueryResult> QueryRelatedFeaturesCount(RelationshipQuery query,
        CancellationToken cancellationToken = default)
    {
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        RelatedFeaturesCountQueryResult result = await JsComponentReference!.InvokeAsync<RelatedFeaturesCountQueryResult>(
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

        int result = await JsComponentReference!.InvokeAsync<int>("queryTopFeatureCount", cancellationToken,
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
        Guid queryId = Guid.NewGuid();
        FeatureSet result = (await JsComponentReference!.InvokeAsync<FeatureSet?>("queryTopFeatures", cancellationToken,
            query, new { signal = abortSignal }, DotNetComponentReference, View?.Id, queryId))!;

        if (_activeQueries.ContainsKey(queryId))
        {
            result.Features = _activeQueries[queryId];
            _activeQueries.Remove(queryId);
        }
        
        foreach (Graphic graphic in result.Features!)
        {
            graphic.LayerId = Id;
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

        int[] queryResult = await JsComponentReference!.InvokeAsync<int[]>("queryTopObjectIds", cancellationToken,
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

        ExtentQueryResult result = await JsComponentReference!.InvokeAsync<ExtentQueryResult>("queryExtent",
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
        Url ??= renderedFeatureLayer.Url;
        Title ??= renderedFeatureLayer.Title;

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
                LabelingInfo ??= new List<Label>();

                foreach (Label label in renderedFeatureLayer.LabelingInfo)
                {
                    LabelingInfo = LabelingInfo.Append(label).ToList();
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

        if (renderedFeatureLayer.TimeInfo is not null)
        {
            TimeInfo = renderedFeatureLayer.TimeInfo;
        }
    }

    private HashSet<Graphic>? _source;
    private HashSet<Field>? _fields;
    private bool _refreshRequired = false;
    private Dictionary<Guid, Graphic[]> _activeQueries = new();
    private Dictionary<Guid, Dictionary<long, Graphic[]>> _activeRelatedQueries = new();
}

/// <summary>
///     One-directional converter to just send the component Id to JS
/// </summary>
internal class GraphicToIdConverter: JsonConverter<Graphic>
{
    public override Graphic Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Graphic value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Id.ToString());
    }
}