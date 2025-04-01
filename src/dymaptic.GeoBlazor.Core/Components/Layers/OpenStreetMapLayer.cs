namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class OpenStreetMapLayer : WebTileLayer
{
    /// <inheritdoc />
    public override LayerType Type => LayerType.OpenStreetMap;
    
    /// <summary>
    ///     SetFullExtent is not supported for OpenStreetMapLayer.
    /// </summary>
    /// <exception cref="NotSupportedException"></exception>
    public override Task SetFullExtent(Extent? extent)
    {
        return Task.FromException(new NotSupportedException("FullExtent is ReadOnly for OpenStreetMapLayer."));
    }
}