namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for the TableListWidget, only available in GeoBlazor Pro.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<ITableListWidget>))]
public interface ITableListWidget: IMapComponent
{
}