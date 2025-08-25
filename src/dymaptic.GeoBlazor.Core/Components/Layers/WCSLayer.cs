namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class WCSLayer : Layer
{
    /// <inheritdoc />
    public override LayerType Type => LayerType.WCS;

    // Class Breaks renderer still needs to be added to this layer for a classified pixel render.

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {

            case DimensionalDefinition dimensionalDefinition:
                MultidimensionalDefinition ??= [];
                if (!MultidimensionalDefinition.Contains(dimensionalDefinition))
                {
                    MultidimensionalDefinition = [..MultidimensionalDefinition, dimensionalDefinition];
                    ModifiedParameters[nameof(MultidimensionalDefinition)] = MultidimensionalDefinition;
                    if (MapRendered)
                    {
                        await UpdateLayer();
                    }
                }
                break;
            
            case IImageryRenderer imageryRenderer:
                if (!imageryRenderer.Equals(Renderer))
                {
                    Renderer = imageryRenderer;
                    ModifiedParameters[nameof(Renderer)] = imageryRenderer;
                    
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

            case DimensionalDefinition dimensionalDefinition:
                MultidimensionalDefinition = MultidimensionalDefinition?.Except([dimensionalDefinition]).ToList();
                
                break;
            case IImageryRenderer:
                Renderer = null;

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
        
        if (MultidimensionalDefinition is not null)
        {
            foreach (DimensionalDefinition child in MultidimensionalDefinition)
            {
                child.ValidateRequiredChildren();
            }
        }
        
        if (Renderer is IMapComponent mapComponent)
        {
            mapComponent.ValidateRequiredChildren();
        }
    }

}
