namespace dymaptic.GeoBlazor.Pro.Components.Layers;

public partial class GroupLayer : IGroupLayer
{
    // Add custom code to this file to override generated code

    /// <summary>
    ///     <a target="_blank"
    ///        href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Layers.GroupLayer.html#grouplayeralllayers-property">
    ///         GeoBlazor
    ///         Docs
    ///     </a>
    ///     A flattened collection of all
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">layers</a>
    ///     in the group layer.
    ///     <a target="_blank"
    ///        href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GroupLayer.html#allLayers">
    ///         ArcGIS
    ///         Maps SDK for JavaScript
    ///     </a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    [CodeGenerationIgnore]
    public IReadOnlyList<Layer>? AllLayers { get; protected set; }

    /// <summary>
    ///     <a target="_blank"
    ///        href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Layers.GroupLayer.html#grouplayeralltables-property">
    ///         GeoBlazor
    ///         Docs
    ///     </a>
    ///     A flattened collection of tables anywhere in the group layer's hierarchy.
    ///     <a target="_blank"
    ///        href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GroupLayer.html#allTables">
    ///         ArcGIS
    ///         Maps SDK for JavaScript
    ///     </a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonInclude]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    [CodeGenerationIgnore]
    public IReadOnlyList<Layer>? AllTables { get; protected set; }

    /// <summary>
    ///     <a target="_blank"
    ///        href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Layers.GroupLayer.html#grouplayerlayers-property">
    ///         GeoBlazor
    ///         Docs
    ///     </a>
    ///     A collection of operational
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">layers</a>
    ///     .
    ///     <a target="_blank"
    ///        href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GroupLayer.html#layers">
    ///         ArcGIS
    ///         Maps SDK for JavaScript
    ///     </a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    [CodeGenerationIgnore]
    public IReadOnlyList<Layer>? Layers { get; set; }

    /// <summary>
    ///     <a target="_blank"
    ///        href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Layers.GroupLayer.html#grouplayertables-property">
    ///         GeoBlazor
    ///         Docs
    ///     </a>
    ///     A collection of
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">layer</a>
    ///     instances that are tables
    ///     saved in a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Map.html">Map</a>
    ///     and/or a
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html">WebMap</a>
    ///     .
    ///     <a target="_blank"
    ///        href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-GroupLayer.html#tables">
    ///         ArcGIS
    ///         Maps SDK for JavaScript
    ///     </a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    public IReadOnlyList<Layer>? Tables { get; set; }

    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override void ValidateRequiredChildren()
    {
        if (Layers is not null)
        {
            foreach (Layer layer in Layers)
            {
                layer.ValidateRequiredChildren();
            }
        }

        base.ValidateRequiredChildren();
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the AllLayers property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<Layer>?> GetAllLayers()
    {
        if (CoreJsModule is null)
        {
            return AllLayers;
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
            return AllLayers;
        }

        IReadOnlyList<Layer>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<Layer>?>(
            "getAllLayers", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            AllLayers = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(AllLayers)] = AllLayers;
        }
        
        return AllLayers;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the AllTables property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<Layer>?> GetAllTables()
    {
        if (CoreJsModule is null)
        {
            return AllTables;
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
            return AllTables;
        }

        IReadOnlyList<Layer>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<Layer>?>(
            "getAllTables", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            AllTables = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(AllTables)] = AllTables;
        }
        
        return AllTables;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Layers property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<Layer>?> GetLayers()
    {
        if (CoreJsModule is null)
        {
            return Layers;
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
            return Layers;
        }

        IReadOnlyList<Layer>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<Layer>?>(
            "getLayers", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Layers = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Layers)] = Layers;
        }
        
        return Layers;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Tables property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<Layer>?> GetTables()
    {
        if (CoreJsModule is null)
        {
            return Tables;
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
            return Tables;
        }

        IReadOnlyList<Layer>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<Layer>?>(
            "getTables", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Tables = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Tables)] = Tables;
        }
        
        return Tables;
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Layers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetLayers(IReadOnlyList<Layer>? value)
    {
        if (value is not null)
        {
            foreach (Layer item in value)
            {
                item.UpdateGeoBlazorReferences(CoreJsModule!, ProJsModule, View, this, Layer);
            }
        }
        
#pragma warning disable BL0005
        Layers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Layers)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setLayers", 
            CancellationTokenSource.Token, value);
    }

    /// <summary>
    ///    Asynchronously set the value of the Tables property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetTables(IReadOnlyList<Layer>? value)
    {
        if (value is not null)
        {
            foreach (Layer item in value)
            {
                item.UpdateGeoBlazorReferences(CoreJsModule!, ProJsModule, View, this, Layer);
            }
        }
        
#pragma warning disable BL0005
        Tables = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Tables)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setTables", 
            CancellationTokenSource.Token, value);
    }
    
#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the Layers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToLayers(params Layer[] values)
    {
        Layer[] join = Layers is null
            ? values
            : [..Layers, ..values];
        await SetLayers(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the Tables property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToTables(params Layer[] values)
    {
        Layer[] join = Tables is null
            ? values
            : [..Tables, ..values];
        await SetTables(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the Layers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromLayers(params Layer[] values)
    {
        if (Layers is null)
        {
            return;
        }
        await SetLayers(Layers.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the Tables property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromTables(params Layer[] values)
    {
        if (Tables is null)
        {
            return;
        }
        await SetTables(Tables.Except(values).ToArray());
    }
    
#endregion
    
    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Layer layer:
                Layers ??= [];

                if (!Layers.Contains(layer))
                {
                    Layers = [..Layers, layer];
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Layer layer:
                Layers = Layers?.Except([layer]).ToArray();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}