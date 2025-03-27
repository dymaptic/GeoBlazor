namespace dymaptic.GeoBlazor.Core.Interfaces;


/// <summary>
///     
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IElevationSampler>))]
public partial interface IElevationSampler: IMapComponent
{
   // Add custom code to this file to override generated code
}