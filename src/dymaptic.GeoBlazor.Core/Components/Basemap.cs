namespace dymaptic.GeoBlazor.Core.Components;

public partial class Basemap : MapComponent, IPortalLayer
{
    /// <summary>
    ///     A collection of tile layers that make of the basemap's features.
    /// </summary>
    [CodeGenerationIgnore]
    [Obsolete("Use BaseLayers and ReferenceLayers instead.")]
    public List<Layer> Layers
    {
        get => BaseLayers?.Concat(ReferenceLayers ?? [])?.ToList() ?? [];
        set
        {
            BaseLayers = value.Where(layer => layer.IsBasemapReferenceLayer != true).ToList();
            ReferenceLayers = value.Where(layer => layer.IsBasemapReferenceLayer == true).ToList();
        }
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Basemap.html#basemapbaselayers-property">GeoBlazor Docs</a>
    ///     A collection of tile layers that make up the basemap's features.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#baseLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    [CodeGenerationIgnore]
    public IReadOnlyList<Layer>? BaseLayers { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Basemap.html#basemapreferencelayers-property">GeoBlazor Docs</a>
    ///     A collection of reference layers which are displayed over the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#baseLayers">base layers</a> and all other layers in the map.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html#referenceLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    [CodeGenerationIgnore]
    public IReadOnlyList<Layer>? ReferenceLayers { get; set; }
    
    /// <summary>
    ///    Asynchronously set the value of the BaseLayers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetBaseLayers(IReadOnlyList<Layer>? value)
    {
        if (value is not null)
        {
            foreach (Layer item in value)
            {
                item.CoreJsModule = CoreJsModule;
                item.Parent = this;
                item.Layer = Layer;
                item.View = View;
            }
        }
        
#pragma warning disable BL0005
        BaseLayers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(BaseLayers)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setBaseLayers", 
            CancellationTokenSource.Token, value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ReferenceLayers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetReferenceLayers(IReadOnlyList<Layer>? value)
    {
        if (value is not null)
        {
            foreach (Layer item in value)
            {
                item.CoreJsModule = CoreJsModule;
                item.Parent = this;
                item.Layer = Layer;
                item.View = View;
            }
        }
        
#pragma warning disable BL0005
        ReferenceLayers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ReferenceLayers)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setReferenceLayers", 
            CancellationTokenSource.Token, value);
    }
    
    /// <summary>  
    ///     Asynchronously retrieve the current value of the BaseLayers property.  
    /// </summary>  
    [CodeGenerationIgnore]
    public Task<IReadOnlyList<Layer>?> GetBaseLayers()
    {  
        return Task.FromResult(BaseLayers);
    }  
  
    /// <summary>  
    ///     Asynchronously retrieve the current value of the ReferenceLayers property.  
    /// </summary>  
    [CodeGenerationIgnore]
    public Task<IReadOnlyList<Layer>?> GetReferenceLayers()  
    {  
        return Task.FromResult(ReferenceLayers);  
    }
    
#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the BaseLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    [CodeGenerationIgnore]
    public async Task AddToBaseLayers(params Layer[] values)
    {
        Layer[] join = BaseLayers is null
            ? values
            : [..BaseLayers, ..values];
        await SetBaseLayers(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the ReferenceLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    [CodeGenerationIgnore]
    public async Task AddToReferenceLayers(params Layer[] values)
    {
        Layer[] join = ReferenceLayers is null
            ? values
            : [..ReferenceLayers, ..values];
        await SetReferenceLayers(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the BaseLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    [CodeGenerationIgnore]
    public async Task RemoveFromBaseLayers(params Layer[] values)
    {
        if (BaseLayers is null)
        {
            return;
        }
        await SetBaseLayers(BaseLayers.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the ReferenceLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    [CodeGenerationIgnore]
    public async Task RemoveFromReferenceLayers(params Layer[] values)
    {
        if (ReferenceLayers is null)
        {
            return;
        }
        await SetReferenceLayers(ReferenceLayers.Except(values).ToArray());
    }
    
#endregion

    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Layer layer:
                // add the new layer first so that it ends up on the bottom
                if (layer.IsBasemapReferenceLayer == true)
                {
                    ReferenceLayers ??= [];
                    ReferenceLayers = [layer, ..ReferenceLayers];
                }
                else
                {
                    BaseLayers ??= [];
                    BaseLayers = [layer, ..BaseLayers];
                }
                ModifiedParameters[nameof(BaseLayers)] = BaseLayers;

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
                // Basemap might be declared outside the view for BasemapToggleWidget
                if (View is not null)
                {
                    await View!.RemoveLayer(layer, layer.IsBasemapReferenceLayer != true, 
                        layer.IsBasemapReferenceLayer == true);
                }
                
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);
        
#pragma warning disable CS0618 // Type or member is obsolete
        if (parameters.TryGetValue(nameof(Layers), out List<Layer>? layers) && layers is not null)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            BaseLayers = layers.Where(layer => layer.IsBasemapReferenceLayer == false).ToList();
            ReferenceLayers = layers.Where(layer => layer.IsBasemapReferenceLayer == true).ToList();
        }
    }

    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override void ValidateRequiredChildren()
    {
        if (BaseLayers is not null)
        {
            foreach (Layer layer in BaseLayers)
            {
                layer.ValidateRequiredChildren();
            }
        }

        if (ReferenceLayers is not null)
        {
            foreach (Layer layer in ReferenceLayers)
            {
                layer.ValidateRequiredChildren();
            }
        }
    }
}