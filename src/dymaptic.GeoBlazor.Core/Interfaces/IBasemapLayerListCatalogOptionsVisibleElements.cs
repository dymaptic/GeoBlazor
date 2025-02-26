namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     The visible elements of the basemap layer list catalog options.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IBasemapLayerListCatalogOptionsVisibleElements>))]
public interface IBasemapLayerListCatalogOptionsVisibleElements: IMapComponent
{
    
}