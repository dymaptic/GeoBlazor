namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Represents a form template that can be used to create new features in a feature layer. Available only in GeoBlazor Pro.
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IFormTemplate>))]
public interface IFormTemplate: IMapComponent
{
    
}