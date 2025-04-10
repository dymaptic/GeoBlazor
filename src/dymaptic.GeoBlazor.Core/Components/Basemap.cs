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
    ///     Asynchronously retrieve the current value of the BaseLayers property.  
    /// </summary>  
    public Task<IReadOnlyList<Layer>?> GetBaseLayers()
    {  
        return Task.FromResult(BaseLayers);
    }  
  
    /// <summary>  
    ///     Asynchronously retrieve the current value of the ReferenceLayers property.  
    /// </summary>  
    public Task<IReadOnlyList<Layer>?> GetReferenceLayers()  
    {  
        return Task.FromResult(ReferenceLayers);  
    }

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
                await View!.RemoveLayer(layer, layer.IsBasemapReferenceLayer != true, 
                    layer.IsBasemapReferenceLayer == true);
                
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