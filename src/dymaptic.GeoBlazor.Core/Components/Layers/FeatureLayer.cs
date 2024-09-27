using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Renderers;
using dymaptic.GeoBlazor.Core.Components.Widgets;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Interfaces;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ProtoBuf;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;


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
public class FeatureLayer : Layer, IFeatureReductionLayer, IPopupTemplateLayer
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
    public FeatureLayer(string? url = null, PortalItem? portalItem = null, IReadOnlyCollection<Graphic>? source = null,
        string[]? outFields = null, string? definitionExpression = null, double? minScale = null,
        double? maxScale = null, string? objectIdField = null, GeometryType? geometryType = null, string? title = null,
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
    public List<Label>? LabelingInfo { get; set; }

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
        if (JsLayerReference is not null)
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
    public async Task Add(IEnumerable<Graphic> graphics)
    {
        if (JsLayerReference is not null)
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
        if (JsModule is not null && JsLayerReference is null)
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
        AbortManager ??= new AbortManager(JsRuntime);
        
        // return await JsLayerReference!.InvokeAsync<FeatureEditsResult>("applyEdits", edits, options,
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
            attachmentResults = await JsLayerReference!.InvokeAsync<FeatureEditsResult>(
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
            result = await JsLayerReference!.InvokeAsync<FeatureEditsResult>(
                "applyGraphicEditsSynchronously", cancellationToken, ms.ToArray(), editType, options, 
                View!.Id, abortSignal);
            await ms.DisposeAsync();
            await Task.Delay(1, cancellationToken);
        }
        else
        {
            using DotNetStreamReference streamRef = new(ms);
            result = await JsLayerReference!.InvokeAsync<FeatureEditsResult>(
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
        return await JsLayerReference!.InvokeAsync<FeatureType>("getFeatureType", feature);
    }

    /// <summary>
    /// Returns the Field instance for a field name (case-insensitive).
    /// </summary>
    /// <param name="fieldName">the field name (case-insensitive).</param>
    public async Task<Field?> GetField(string fieldName)
    {
        return await JsLayerReference!.InvokeAsync<Field?>("getField", fieldName);
    }

    /// <summary>
    /// Returns the Domain associated with the given field name. The domain can be either a CodedValueDomain or RangeDomain.
    /// </summary>
    public async Task<Domain?> GetFieldDomain(string fieldName, Graphic? feature = null)
    {
        return await JsLayerReference!.InvokeAsync<Domain?>("getFieldDomain", fieldName, feature);
    }

    /// <summary>
    ///    Describes the layer's supported capabilities.
    /// </summary>
    public async Task<FeatureLayerCapabilities> GetCapabilities()
    {
        return await JsLayerReference!.InvokeAsync<FeatureLayerCapabilities>("getCapabilities");
    }

    /// <summary>
    /// Creates a deep clone of the javascript FeatureLayer object.
    /// </summary>
    public async Task<FeatureLayer> Clone()
    {
        return await JsLayerReference!.InvokeAsync<FeatureLayer>("clone");
    }

    /// <summary>
    /// Fetches all the data for the layer. Calls 'refresh' on the layer.
    /// </summary>
    public override void Refresh()
    {
        _refreshRequired = true;
        base.Refresh();
    }
    
    /// <summary>
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    /// <param name="effect">
    ///     The effect to apply to the layer.
    /// </param>
    public async Task SetEffect(Effect effect)
    {
        await JsLayerReference!.InvokeVoidAsync("setEffect", effect);
    }

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (_refreshRequired)
        {
            _refreshRequired = false;
            var newLayer = await JsLayerReference!.InvokeAsync<FeatureLayer>("refresh");
            await this.UpdateFromJavaScript(newLayer);
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
                    graphic.JsModule ??= JsModule;
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
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        Guid queryId = Guid.NewGuid();

        FeatureSet result = (await JsLayerReference!.InvokeAsync<FeatureSet?>("queryFeatures", cancellationToken,
            query, new { signal = abortSignal }, DotNetObjectReference.Create(this), View?.Id, queryId))!;

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
        Guid queryId = Guid.NewGuid();
        Dictionary<int, FeatureSet?> result = (await JsLayerReference!.InvokeAsync<Dictionary<int, FeatureSet?>?>(
            "queryRelatedFeatures", cancellationToken, query, new { signal = abortSignal },
            DotNetObjectReference.Create(this), View?.Id, queryId))!;

        if (_activeRelatedQueries.ContainsKey(queryId))
        {
            Dictionary<int, Graphic[]> relatedGraphics = _activeRelatedQueries[queryId];
            foreach (KeyValuePair<int, FeatureSet?> kvp in result)
            {
                if (kvp.Value is null || !relatedGraphics.ContainsKey(kvp.Key)) continue;

                kvp.Value.Features = relatedGraphics[kvp.Key];

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
                _activeRelatedQueries[queryId] = new Dictionary<int, Graphic[]>();
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
        Guid queryId = Guid.NewGuid();
        FeatureSet result = (await JsLayerReference!.InvokeAsync<FeatureSet?>("queryTopFeatures", cancellationToken,
            query, new { signal = abortSignal }, DotNetObjectReference.Create(this), View?.Id, queryId))!;

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

        if (renderedFeatureLayer.TimeInfo is not null)
        {
            TimeInfo = renderedFeatureLayer.TimeInfo;
        }
    }

    private HashSet<Graphic>? _source;
    private HashSet<Field>? _fields;
    private bool _refreshRequired = false;
    private Dictionary<Guid, Graphic[]> _activeQueries = new();
    private Dictionary<Guid, Dictionary<int, Graphic[]>> _activeRelatedQueries = new();
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

/// <summary>
///     Object containing features and attachments to be added, updated or deleted.
///     For use with <see cref="FeatureLayer.ApplyEdits"/>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#applyEdits">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FeatureEdits
{
    /// <summary>
    ///     An array or a collection of features to be added. Values of non nullable fields must be provided when adding new features. Date fields must have numeric values representing universal time.
    /// </summary>
    public IEnumerable<Graphic>? AddFeatures { get; set; }
    /// <summary>
    ///     An array or a collection of features to be updated. Each feature must have valid objectId. Values of non nullable fields must be provided when updating features. Date fields must have numeric values representing universal time.
    /// </summary>
    public IEnumerable<Graphic>? UpdateFeatures { get; set; }
    /// <summary>
    ///     An array or a collection of features, or an array of objects with objectId or globalId of each feature to be deleted. When an array or collection of features is passed, each feature must have a valid objectId. When an array of objects is used, each object must have a valid value set for objectId or globalId property.
    /// </summary>
    public IEnumerable<Graphic>? DeleteFeatures { get; set; }
    /// <summary>
    ///     An array of attachments to be added. Applies only when the options.globalIdUsed parameter is set to true. User must provide globalIds for all attachments to be added.
    /// </summary>
    public IEnumerable<AttachmentEdit>? AddAttachments { get; set; }
    /// <summary>
    ///     An array of attachments to be updated. Applies only when the options.globalIdUsed parameter is set to true. User must provide globalIds for all attachments to be updated.
    /// </summary>
    public IEnumerable<AttachmentEdit>? UpdateAttachments { get; set; }
    /// <summary>
    ///     An array of globalIds for attachments to be deleted. Applies only when the options.globalIdUsed parameter is set to true.
    /// </summary>
    public IEnumerable<string>? DeleteAttachments { get; set; }
}


/// <summary>
///     AttachmentEdit represents an attachment that can be added, updated or deleted via applyEdits. This object can be either pre-uploaded data or base 64 encoded data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#AttachmentEdit">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class AttachmentEdit
{
    /// <summary>
    ///     Construct an AttachmentEdit from a <see cref="Graphic"/> "Feature" and its <see cref="Attachment"/>.
    /// </summary>
    public AttachmentEdit(Graphic feature, Attachment attachment)
    {
        Feature = feature;
        Attachment = attachment;
    }

    /// <summary>
    ///     Construct an AttachmentEdit from a Feature's `objectId` and its <see cref="Attachment"/>.
    /// </summary>
    public AttachmentEdit(int objectId, Attachment attachment)
    {
        ObjectId = objectId;
        Attachment = attachment;
    }

    /// <summary>
    ///     Construct an AttachmentEdit from a Feature's `globalId` and its <see cref="Attachment"/>.
    /// </summary>
    public AttachmentEdit(string globalId, Attachment attachment)
    {
        GlobalId = globalId;
        Attachment = attachment;
    }
    
    /// <summary>
    ///     The feature of feature associated with the attachment.
    /// </summary>
    [JsonConverter(typeof(GraphicToIdConverter))]
    public Graphic? Feature { get; set; }
    
    /// <summary>
    ///     The `objectId` of the feature associated with the attachment.
    /// </summary>
    public int? ObjectId { get; set; }
    
    /// <summary>
    ///     The `globalId` of the feature associated with the attachment.
    /// </summary>
    public string? GlobalId { get; set; }

    /// <summary>
    ///     The attachment to be added, updated or deleted.
    /// </summary>
    public Attachment Attachment { get; set; } = default!;
}

/// <summary>
///     The attachment to be added, updated or deleted in an <see cref="AttachmentEdit"/>.
/// </summary>
public class Attachment
{
    /// <summary>
    ///     The globalId of the attachment to be added or updated. These Global IDs must be from the Global ID field created by ArcGIS. For more information on ArcGIS generated Global IDs, see the Global IDs and Attachments and relationship classes sections in the <a target="_blank" href="https://enterprise.arcgis.com/en/server/latest/publish-services/windows/prepare-data-for-offline-use.htm#ESRI_SECTION1_CDC34577197B43A980E4B5021DB1C32A">Data Preparation</a> documentation.
    /// </summary>
    public string GlobalId { get; set; } = default!;

    /// <summary>
    ///     The name of the attachment. This parameter must be set if the attachment type is Blob.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    ///     The content type of the attachment. For example, 'image/jpeg'. See the ArcGIS REST API documentation for more information on supported attachment types.
    /// </summary>
    public string? ContentType { get; set; }

    /// <summary>
    ///     The id of pre-loaded attachment.
    /// </summary>
    public string? UploadId { get; set; }

    /// <summary>
    ///     The attachment data.
    /// </summary>
    public string? Data { get; set; }
}

/// <summary>
/// Time info represents the temporal data of a time-aware layer. The time info class provides information such
/// as date fields that store the start and end times for each feature and the total time span for the layer.
/// </summary>
public class TimeInfo
{
    /// <summary>
    ///     Public constructor
    /// </summary>
    /// <param name="startField">
    ///     The name of the field containing the start time information.
    /// </param>
    /// <param name="endField">
    ///     The name of the field containing the end time information.
    /// </param>
    public TimeInfo(string? startField, string? endField)
    {
        StartField = startField;
        EndField = endField;
    }


    /// <summary>
    ///   The name of the field containing the end time information.
    /// </summary>
    public string? EndField { get; set; }

    /// <summary>
    ///  The time extent defines the start time and end time for all data in the layer.
    ///  The fullTimeExtent for timeInfo is automatically calculated based on its startField and endField properties.
    ///  The timeInfo parameters cannot be changed after the layer is loaded.
    /// </summary>
    public TimeExtent? FullTimeExtent { get; set; }

    /// <summary>
    ///   The time interval defines the granularity of the temporal data and allows you to visualize the data at specified intervals using the time slider widget.
    /// </summary>
    public TimeInterval? Interval { get; set; }

    /// <summary>
    ///  The name of the field containing the start time information.
    /// </summary>
    public string? StartField { get; set; }

    /// <summary>
    /// The name of the field used to join or group discrete locations.
    /// </summary>
    public string? TrackIdField { get; set; }
}

/// <summary>
///     The options to use with <see cref="FeatureLayer.ApplyEdits"/>.
/// </summary>
public class FeatureEditOptions
{
    /// <summary>
    ///     The geodatabase version to apply the edits. This parameter applies only if the capabilities.data.isVersioned property of the layer is true. If the gdbVersion parameter is not specified, edits are made to the published map’s version.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }

    /// <summary>
    ///     Indicates whether the edit results should return the time edits were applied. If true, the feature service will return the time edits were applied in the edit result's editMoment property. Only applicable with ArcGIS Server services only.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ReturnEditMoment { get; set; }

    /// <summary>
    ///     If set to original-and-current-features, the EditedFeatureResult parameter will be included in the applyEdits response. It contains all edited features participating in composite relationships in a database as result of editing a feature. Note that even for deletions, the geometry and attributes of the deleted feature are returned. The original-and-current-features option is only valid when rollbackOnFailureEnabled is true. The default value is none, which will not include the EditedFeatureResult parameter in the response. This is only applicable with ArcGIS Server services only.
    /// </summary>
    /// <remarks>
    ///     Possible values: "none" | "original-and-current-features"
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ReturnServiceEditsOption { get; set; }

    /// <summary>
    ///     Indicates whether the edits should be applied only if all submitted edits succeed. If false, the server will apply the edits that succeed even if some of the submitted edits fail. If true, the server will apply the edits only if all edits succeed. The layer's capabilities.editing.supportsRollbackOnFailure property must be true if using this parameter. If supportsRollbackOnFailure is false for a layer, then rollbackOnFailureEnabled will always be true, regardless of how the parameter is set.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RollbackOnFailureEnabled { get; set; }

    /// <summary>
    ///     Indicates whether the edits can be applied using globalIds of features or attachments. This parameter applies only if the layer's capabilities.editing.supportsGlobalId property is true. When false, globalIds submitted with the features are ignored and the service assigns new globalIds to the new features. When true, the globalIds must be submitted with the new features. When updating existing features, if the globalIdUsed is false, the objectIds of the features to be updated must be provided. If the globalIdUsed is true, globalIds of features to be updated must be provided. When deleting existing features, set this property to false as deletes operation only accepts objectIds at the current version of the API.
    ///     When adding, updating or deleting attachments, globalIdUsed parameter must be set to true and the attachment globalId must be set. For new attachments, the user must provide globalIds. In order for an attachment to be updated or deleted, clients must include its globalId. Attachments are not supported in an edit payload when globalIdUsed is false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? GlobalIdUsed { get; set; }
}

/// <summary>
///     The result of <see cref="FeatureLayer.ApplyEdits"/>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditsResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="AddFeatureResults">
///     Result of adding features.     
/// </param>
/// <param name="UpdateFeatureResults">
///     Result of updating features.
/// </param>
/// <param name="DeleteFeatureResults">
///     Result of deleting features.
/// </param>
/// <param name="AddAttachmentResults">
///     Result of adding attachments.
/// </param>
/// <param name="UpdateAttachmentResults">
///     Result of updating attachments.
/// </param>
/// <param name="DeleteAttachmentResults">
///     Result of deleting attachments.
/// </param>
/// <param name="EditedFeatureResults">
///     Edited features as result of editing a feature that participates in composite relationships in a database. This parameter is returned only when the returnServiceEditsOption parameter of the applyEdits() method is set to original-and-current-features.
/// </param>
/// <param name="EditMoment">
///     The time edits were applied to the feature service. This parameter is returned only when the returnEditMoment parameter of the applyEdits() method is set to true.
/// </param>
public record FeatureEditsResult(
    FeatureEditResult[] AddFeatureResults,
    FeatureEditResult[] UpdateFeatureResults,
    FeatureEditResult[] DeleteFeatureResults,
    FeatureEditResult[] AddAttachmentResults,
    FeatureEditResult[] UpdateAttachmentResults,
    FeatureEditResult[] DeleteAttachmentResults,
    EditedFeatureResult[]? EditedFeatureResults,
    long? EditMoment)
{
    /// <summary>
    ///     Concatenates two <see cref="FeatureEditsResult"/>s.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public FeatureEditsResult Concat(FeatureEditsResult? other)
    {
        if (other is null) return this;
        return this with
        {
            AddFeatureResults = AddFeatureResults.Concat(other.AddFeatureResults).ToArray(),
            UpdateFeatureResults = UpdateFeatureResults.Concat(other.UpdateFeatureResults).ToArray(),
            DeleteFeatureResults = DeleteFeatureResults.Concat(other.DeleteFeatureResults).ToArray(),
            AddAttachmentResults = AddAttachmentResults.Concat(other.AddAttachmentResults).ToArray(),
            UpdateAttachmentResults = UpdateAttachmentResults.Concat(other.UpdateAttachmentResults).ToArray(),
            DeleteAttachmentResults = DeleteAttachmentResults.Concat(other.DeleteAttachmentResults).ToArray(),
            EditedFeatureResults = (EditedFeatureResults ?? Array.Empty<EditedFeatureResult>())
                .Concat(other.EditedFeatureResults ?? Array.Empty<EditedFeatureResult>()).ToArray()
        };
    }
}

/// <summary>
///     FeatureEditResult represents the result of adding, updating or deleting a feature or an attachment.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#FeatureEditResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="ObjectId">
///     The objectId of the feature or the attachmentId of the attachment that was edited.
/// </param>
/// <param name="GlobalId">
///     The globalId of the feature or the attachment that was edited.
/// </param>
/// <param name="Error">
///     If the edit failed, the edit result includes an error.
/// </param>
public record FeatureEditResult(long? ObjectId, string? GlobalId, EditError? Error);

/// <summary>
///     The error object in a <see cref="FeatureEditResult"/>
/// </summary>
/// <param name="Name">
///     Error name.
/// </param>
/// <param name="Message">
///     Message describing the error.
/// </param>
public record EditError(string? Name, string? Message);

/// <summary>
///     Results returned from the applyEdits method if the returnServiceEditsOption parameter is set to original-and-current-features. It contains features that were added, deleted or updated in different feature layers of a feature service as a result of editing a single feature that participates in a composite relationship in a database. The results are organized by each layer affected by the edit. For example, if a feature is deleted and it is the origin in a composite relationship, the edited features as a result of this deletion are returned.
///     The editedFeatures object returns full features including newly added features, the original features prior to delete, the original and current features for updates.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#EditedFeatureResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="LayerId">
///     The layerId of the feature layer where features were edited.
/// </param>
/// <param name="EditedFeatures">
///     Object containing all edited features belonging to the specified layer.
/// </param>
public record EditedFeatureResult(long? LayerId, EditedFeatures? EditedFeatures);

/// <summary>
///     The edited features of an <see cref="EditedFeatureResult"/>
/// </summary>
/// <param name="Adds">
///     Newly added features as a result of editing a feature that participates in a composite relationship.
/// </param>
/// <param name="Updates">
///     Object containing original and updated features as a result of editing a feature that participates in a composite relationship.
/// </param>
/// <param name="Deletes">
///     Deleted features as a result of editing a feature that participates in a composite relationship.
/// </param>
/// <param name="SpatialReference">
///     Edited features are returned in the spatial reference of the feature service.
/// </param>
public record EditedFeatures(Graphic[] Adds, EditedFeatureUpdate[] Updates, Graphic[] Deletes,
    SpatialReference SpatialReference);

/// <summary>
///     The update object of a <see cref="EditedFeatures"/>.
/// </summary>
/// <param name="Original">
///     Original feature before the update took place.
/// </param>
/// <param name="Current">
///     Updated feature as a result of editing a feature that participates in a composite relationship.
/// </param>
public record EditedFeatureUpdate(Graphic[] Original, Graphic[] Current);

/// <summary>
///     FeatureType is a subset of features defined in a FeatureLayer that share the same attributes.
///     They are used as a way to categorize your data. For example, the streets in a city streets feature layer
///     could be categorized into three feature types: local streets, collector streets, and arterial streets.
/// </summary>
public record FeatureType(string Id, string Name, FeatureTemplate[] Templates, Dictionary<string, Domain?> Domains);

/// <summary>
///     Feature templates define all the information required to create a new feature in
///     a feature layer. These include information such as the default attribute values with
///     which a feature will be created, and the default tool used to create that feature.
/// </summary>
/// <param name="Name">
///     Name of the feature template.
/// </param>
/// <param name="Description">
///     Description of the feature template.
/// </param>
/// <param name="DrawingTool">
///     Name of the default drawing tool defined for the template to create a feature.
/// </param>
/// <param name="Thumbnail">
///     An object used to create a thumbnail image that represents a feature type in the feature template.
/// </param>
/// <param name="Prototype">    
///     An instance of the prototypical feature described by the feature template. It specifies default values for the attribute fields and does not contain geometry.
/// </param>
public record FeatureTemplate(string Name, string Description, DrawingTool DrawingTool, Thumbnail Thumbnail, Graphic Prototype);

/// <summary>
///     An object used to create a thumbnail image that represents a feature type in the feature template.
/// </summary>
/// <param name="ContentType">
///     The MIME type of the image.
/// </param>
/// <param name="ImageData">
///     The base64EncodedImageData presenting the thumbnail image.
/// </param>
/// <param name="Height">
///     The height of the thumbnail.
/// </param>
/// <param name="Width">
///     The width of the thumbnail.
/// </param>
public record Thumbnail(string ContentType, string ImageData, double Height, double Width);

/// <summary>
///     Name of the default drawing tool defined for the template to create a feature.
/// </summary>
[JsonConverter(typeof(DrawingToolStringConverter))]
public enum DrawingTool
{
#pragma warning disable CS1591
    AutoCompletePolygon,
    Circle,
    Ellipse,
    Freehand,
    Line,
    None,
    Point,
    Polygon,
    Rectangle,
    Arrow,
    Triangle,
    LeftArrow,
    RightArrow,
    UpArrow,
    DownArrow
#pragma warning restore CS1591
}

/// <summary>
///     One-directional converter to just send the component Id to JS
/// </summary>
internal class GraphicToIdConverter: JsonConverter<Graphic>
{
    public override Graphic? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Graphic value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Id.ToString());
    }
}