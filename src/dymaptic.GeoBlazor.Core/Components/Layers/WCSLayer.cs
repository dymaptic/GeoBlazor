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

            case DimensionalDefinition dimensionalDefinition:
                MultidimensionalDefinition = MultidimensionalDefinition?.Except([dimensionalDefinition]).ToList();
                LayerChanged = true;
                break;

            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }



}
