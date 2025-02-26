namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for the CatalogLayerListWidget component, only available in GeoBlazor Pro.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<ICatalogLayerListWidget>))]
public interface ICatalogLayerListWidget: IMapComponent
{
}