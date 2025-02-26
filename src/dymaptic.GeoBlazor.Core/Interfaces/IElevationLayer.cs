namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IElevationLayer>))]
public partial interface IElevationLayer: IMapComponent
{
   // Add custom code to this file to override generated code
}