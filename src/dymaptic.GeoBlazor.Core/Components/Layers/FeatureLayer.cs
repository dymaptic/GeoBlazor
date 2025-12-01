namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class FeatureLayer : Layer, IFeatureReductionLayer, IPopupTemplateLayer, IFeatureLayerBase
{
    /// <summary>
    ///     An authorization string used to access a resource or service. API keys are generated and managed in the ArcGIS Developer Portal. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage. Setting a fine-grained API key on a specific class overrides the global API key.
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
    ///     The SQL where clause used to filter features on the client.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefinitionExpression { get; set; }


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
    [ConditionallyRequiredProperty(nameof(Source))]
    [CodeGenerationIgnore]
    public string? ObjectIdField { get; set; }

    /// <summary>
    ///     The geometry type of the feature layer. All features must be of the same type.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ConditionallyRequiredProperty(nameof(Source))]
    [CodeGenerationIgnore]
    public FeatureGeometryType? GeometryType { get; set; }
    
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

    /// <inheritdoc />
    public override LayerType Type => LayerType.Feature;

    
    /// <summary>  
    ///     Configures the method for reducing the number of point features in the view.  
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-mixins-FeatureReductionLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>  
    /// </summary>  
    [Parameter]  
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]  
    public IFeatureReduction? FeatureReduction { get; set; }
    
    /// <summary>
    ///    Asynchronously set the value of the FeatureReduction property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetFeatureReduction(IFeatureReduction? value)
    {
        if (FeatureReduction is not null)
        {
            await FeatureReduction.DisposeAsync();
        }
        
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        FeatureReduction = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(FeatureReduction)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference.InvokeVoidAsync("setFeatureReduction", 
            CancellationTokenSource.Token, value);
    }

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
                AddFeatures = [graphic]
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
    ///     Applies edits to features in a layer. New features can be created and existing features can be updated or deleted. Feature geometries and/or attributes may be modified. Only applicable to layers in a feature service and client-side features set through the FeatureLayer's source property. Attachments can also be added, updated or deleted.
    ///     If client-side features are added, removed or updated at runtime using applyEdits() then use FeatureLayer's queryFeatures() method to return updated features.
    /// </summary>
        [CodeGenerationIgnore]
        public async Task<FeatureEditsResult> ApplyEdits(FeatureEdits edits, FeatureEditOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Verify that the layer is loaded. Layers with no graphics are not rendered and therefore not loaded
        // as far as GeoBlazor is concerned
        if (CoreJsModule is not null && JsComponentReference is null)
        {
            await Load(cancellationToken);
        }
        
        FeatureEditsResult emptyResult = new FeatureEditsResult([], 
            [],
            [],
            [],
            [],
            [],
            []);

        if (cancellationToken.IsCancellationRequested ||
            CancellationTokenSource.Token.IsCancellationRequested)
        {
            return emptyResult;
        }

        Graphic[] addedFeatures = edits.AddFeatures?.ToArray() ?? [];
        Graphic[] updatedFeatures = edits.UpdateFeatures?.ToArray() ?? [];
        Graphic[] deletedFeatures = edits.DeleteFeatures?.ToArray() ?? [];
        long? editMoment = null;
        int chunkSize = View!.GraphicSerializationChunkSize ?? (IsMaui ? 100 : 200);
        AbortManager ??= new AbortManager(CoreJsModule!);
        
        FeatureEditsResult? addFeatureResults = null;
        FeatureEditsResult? updateFeatureResults = null;
        FeatureEditsResult? deleteFeatureResults = null;
        List<EditedFeatureResult> editedFeatureResults = [];
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
        
        if (Source is not null)
        {
            // update the in-memory collections:
            Source = Source
                .Except(deletedFeatures)
                .Except(updatedFeatures)
                .Concat(addedFeatures)
                .Concat(updatedFeatures)
                .ToList();
        }

        return new FeatureEditsResult
        (
            addFeatureResults?.AddFeatureResults ?? [], 
            updateFeatureResults?.UpdateFeatureResults ?? [], 
            deleteFeatureResults?.DeleteFeatureResults ?? [], 
            attachmentResults?.AddAttachmentResults ?? [],
            attachmentResults?.UpdateAttachmentResults ?? [],
            attachmentResults?.DeleteAttachmentResults ?? [],
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
        
        GraphicCollectionSerializationRecord collection = new(graphics);
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

        if (IsWebAssembly)
        {
            result = await JsComponentReference!.InvokeAsync<FeatureEditsResult>("applyGraphicEditsSynchronously",
                cancellationToken, ms.ToArray(), editType, options, abortSignal);
            await ms.DisposeAsync();
            await Task.Delay(1, cancellationToken);
        }
        else
        {
            using DotNetStreamReference streamRef = new(ms);

            result = await JsComponentReference!.InvokeAsync<FeatureEditsResult>("applyGraphicEditsFromStream",
                cancellationToken, streamRef, editType, options,
                View!.Id, abortSignal);
        }

        return result.Concat(currentResults);
    }

    /// <summary>
    /// Returns a FeatureType describing the feature's type. This is applicable if the layer containing the feature has a typeIdField.
    /// </summary>
    /// <param name="feature"></param>
    /// <returns></returns>
    [ArcGISMethod]
    public async Task<FeatureType?> GetFeatureType(Graphic feature)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return null;
        return await JsComponentReference!.InvokeAsync<FeatureType>("getFeatureType", feature);
    }

    /// <summary>
    /// Returns the Field instance for a field name (case-insensitive).
    /// </summary>
    /// <param name="fieldName">the field name (case-insensitive).</param>
    [ArcGISMethod]
    public async Task<Field?> GetField(string fieldName)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return null;
        return await JsComponentReference!.InvokeAsync<Field?>("getField", fieldName);
    }

    /// <summary>
    /// Returns the Domain associated with the given field name. The domain can be either a CodedValueDomain or RangeDomain.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<Domain?> GetFieldDomain(string fieldName, Graphic? feature = null)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return null;
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
    ///     Effect provides various filter functions that can be performed on the layer to achieve different visual effects similar to how image filters work. This powerful capability allows you to apply css filter-like functions to layers to create custom visual effects to enhance the cartographic quality of your maps. This is done by applying the desired effect to the layer's effect property as a string or an array of objects to set scale dependent effects.
    /// </summary>
    /// <param name="effect">
    ///     The effect to apply to the layer.
    /// </param>
    public async Task SetEffect(Effect? effect)
    {
        await JsComponentReference!.InvokeVoidAsync("setEffect", effect);
    }
    
    /// <summary>
    ///     Fetches all the data for the layer. Calls 'refresh' on the layer.
    /// </summary>
    [CodeGenerationIgnore]
    public override async ValueTask Refresh()
    {
        if (MapRendered)
        {
            await UpdateLayer();
        }
        await base.Refresh();
        if (JsComponentReference is null) return;
        
        FeatureLayer newLayer = await JsComponentReference!.InvokeAsync<FeatureLayer>("refresh");
        await UpdateFromJavaScript(newLayer);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {

            case Label label:
                LabelingInfo ??= [];

                if (!LabelingInfo.Contains(label))
                {
                    LabelingInfo = [..LabelingInfo, label];
                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
                }

                break;

            case Graphic graphic:
                Source ??= [];

                if (!Source.Contains(graphic))
                {
                    graphic.View ??= View;
                    graphic.Parent ??= this;
                    graphic.Layer ??= this;
                    Source = [..Source, graphic];

                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
                }

                break;
            case Field field:
                Fields ??= [];

                if (!Fields.Contains(field))
                {
                    Fields = [..Fields, field];
                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
                }

                break;

            case IFeatureReduction reduction:
                if (!reduction.Equals(FeatureReduction))
                {
                    FeatureReduction = reduction;
                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
                }

                break;
            case IFormTemplate formTemplate:
                if (!formTemplate.Equals(FormTemplate))
                {
                    FormTemplate = formTemplate;
                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
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

            case Label label:
                LabelingInfo = LabelingInfo?.Where(l => !l.Equals(label)).ToList();
                

                break;

            case Graphic graphic:
                if (Source?.Contains(graphic) ?? false)
                {
                    Source = Source?.Except([graphic]).ToList();
                }

                break;
            case Field field:
                if (Fields?.Contains(field) ?? false)
                {
                    Fields = Fields?.Except([field]).ToList();
                }

                break;
            case IFeatureReduction _:
                FeatureReduction = null;

                break;
            
            case IFormTemplate _:
                FormTemplate = null;

                break;

            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
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

            if (ObjectIdField is null)
            {
                throw new MissingConditionallyRequiredChildElementException(nameof(FeatureLayer),
                    nameof(Source), nameof(ObjectIdField));
            }

            if (GeometryType is null)
            {
                if (Source.Count > 0 
                    && Source.Select(g => g.Geometry?.Type)
                            .Where(t => t != null)
                            .Distinct()
                            .ToList() is { Count: 1 } geometryTypes)
                {
                    GeometryType = geometryTypes[0] switch
                    {
                        Enums.GeometryType.Point => FeatureGeometryType.Point,
                        Enums.GeometryType.Multipoint => FeatureGeometryType.Multipoint,
                        Enums.GeometryType.Polyline => FeatureGeometryType.Polyline,
                        Enums.GeometryType.Polygon => FeatureGeometryType.Polygon,
                        Enums.GeometryType.Mesh => FeatureGeometryType.Mesh,
                        _ => null
                    };
                }

                if (GeometryType is null)
                {
                    throw new MissingConditionallyRequiredChildElementException(nameof(FeatureLayer),
                        nameof(Source), nameof(GeometryType));
                }
            }
        }
        
        if (Fields is not null)
        {
            foreach (Field field in Fields)
            {
                field.ValidateRequiredChildren();
            }
        }
        
        FeatureReduction?.ValidateRequiredChildren();
        FormTemplate?.ValidateRequiredChildren();
        
        // do last because we add GeometryType above if possible
        base.ValidateRequiredChildren();
    }

    /// <summary>
    ///     Creates a popup template for the layer, populated with all the fields of the layer.
    /// </summary>
    /// <param name="options">
    ///     Options for creating the popup template.
    /// </param>
    [ArcGISMethod]
    public async Task<PopupTemplate> CreatePopupTemplate(CreatePopupTemplateOptions? options = null)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return new PopupTemplate();
        return await JsComponentReference!.InvokeAsync<PopupTemplate>("createPopupTemplate",
            CancellationTokenSource.Token, options);
    }

    /// <summary>
    ///     Creates query parameter object that can be used to fetch features that satisfy the layer's configurations such as definitionExpression, gdbVersion, and historicMoment. It will return Z and M values based on the layer's data capabilities. It sets the query parameter's outFields property to ["*"]. The results will include geometries of features and values for all available fields for client-side queries or all fields in the layer for server side queries.
    /// </summary>
    [ArcGISMethod]
    public async Task<Query> CreateQuery()
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return new Query();
        return await JsComponentReference!.InvokeAsync<Query>("createQuery", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns the Extent of features that satisfy the query. If no parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters are returned. To query for the extent of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryExtent" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the extent and count of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<ExtentQueryResult> QueryExtent(Query? query = null, CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        ExtentQueryResult result = await JsComponentReference!.InvokeAsync<ExtentQueryResult>("queryExtent",
            cancellationToken, query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns the number of features that satisfy the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned. To query for the count of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryFeatureCount" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns></returns>
    [CodeGenerationIgnore]
    public async Task<int> QueryFeatureCount(Query? query = null, CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return 0;
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        int result = await JsComponentReference!.InvokeAsync<int>("queryFeatureCount", cancellationToken,
            query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns the number of features that satisfy the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned. To query for the count of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryFeatureCount" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, the total number of features satisfying the layer's configuration/filters is returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns></returns>
    [CodeGenerationIgnore]
    public async Task<FeatureSet?> QueryFeatures(Query? query = null, CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return null;
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        
        FeatureSet result = await JsSyncManager.InvokeJsMethod<FeatureSet>(
            JsComponentReference, IsServer, nameof(QueryFeatures), nameof(FeatureLayer),
            cancellationToken, query, abortSignal);
        
        foreach (Graphic graphic in result.Features!)
        {
            graphic.View = View;
            graphic.Parent = this;
            graphic.Layer = this;
            graphic.CoreJsModule = CoreJsModule;
        }

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a Query against the feature service and returns an array of Object IDs for features that satisfy the input query. If no parameters are specified, then the Object IDs of all features satisfying the layer's configuration/filters are returned. To query for ObjectIDs of features/graphics available to or visible in the View on the client rather than making a server-side query, you must use the <see cref="FeatureLayerView.QueryObjectIds" /> method.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes and spatial filter of the query. If no parameters are specified, then the Object IDs of all features satisfying the layer's configuration/filters are returned.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<ObjectId[]> QueryObjectIds(Query query, CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return [];
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        ObjectId[] queryResult = await JsComponentReference!.InvokeAsync<ObjectId[]>("queryObjectIds", cancellationToken, query, new { signal = abortSignal });
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
    [CodeGenerationIgnore]
    public async Task<RelatedFeaturesQueryResult?> QueryRelatedFeatures(RelationshipQuery query,
        CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return null;
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        RelatedFeaturesQueryResult result = await JsSyncManager.InvokeJsMethod<RelatedFeaturesQueryResult>(
            JsComponentReference, IsServer, nameof(QueryRelatedFeatures), nameof(FeatureLayer),
            cancellationToken, query, abortSignal);

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
    [CodeGenerationIgnore]
    public async Task<RelatedFeaturesCountQueryResult?> QueryRelatedFeaturesCount(RelationshipQuery query,
        CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return null;
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        RelatedFeaturesCountQueryResult? result = await JsComponentReference!.InvokeAsync<RelatedFeaturesCountQueryResult?>(
            "queryRelatedFeaturesCount", cancellationToken, query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns the count of features or records that satisfy the query.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeatureCount" /> is only supported with server-side <see cref="FeatureLayer" />s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<int> QueryTopFeatureCount(TopFeaturesQuery query, CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        int result = await JsComponentReference!.InvokeAsync<int>("queryTopFeatureCount", cancellationToken,
            query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns a FeatureSet once the promise resolves. The FeatureSet contains an array of top features grouped and ordered by specified fields. For example, you can call this method to query top three counties grouped by state names while ordering them based on their populations in descending order.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeatures" /> is only supported with server-side <see cref="FeatureLayer" />s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<FeatureSet?> QueryTopFeatures(TopFeaturesQuery query,
        CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return null;
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        Guid queryId = Guid.NewGuid();
        FeatureSet result = await JsSyncManager.InvokeJsMethod<FeatureSet>(JsComponentReference,
            IsServer, nameof(QueryTopFeatures), nameof(FeatureLayer), cancellationToken, queryId, abortSignal);
        
        foreach (Graphic graphic in result.Features!)
        {
            graphic.View = View;
            graphic.Parent = this;
            graphic.Layer = this;
        }

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }

    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns an array of Object IDs for features that satisfy the input query. If no parameters are specified, then the Object IDs of all features satisfying the layer's configuration/filters are returned.
    /// </summary>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    /// <returns>
    ///     An array of Object IDs for features that satisfy the input query.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<ObjectId[]> QueryTopObjectIds(TopFeaturesQuery query, CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null) return [];
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        ObjectId[] queryResult = await JsComponentReference!.InvokeAsync<ObjectId[]>("queryTopObjectIds", cancellationToken,
            query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return queryResult;
    }

    /// <summary>
    ///     Executes a TopFeaturesQuery against a feature service and returns the Extent of features that satisfy the query.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Currently, the <see cref="QueryTopFeaturesExtent" /> is only supported with server-side <see cref="FeatureLayer" />s.
    /// </remarks>
    /// <param name="query">
    ///     Specifies the attributes, spatial, temporal, and top filter of the query. The topFilter parameter must be set.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used to cancel the query operation.
    /// </param>
    [CodeGenerationIgnore]
    public async Task<ExtentQueryResult> QueryTopFeaturesExtent(TopFeaturesQuery? query = null,
        CancellationToken cancellationToken = default)
    {
        JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        AbortManager ??= new AbortManager(CoreJsModule!);
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);

        ExtentQueryResult result = await JsComponentReference!.InvokeAsync<ExtentQueryResult>("queryExtent",
            cancellationToken, query, new { signal = abortSignal });

        await AbortManager.DisposeAbortController(cancellationToken);

        return result;
    }
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