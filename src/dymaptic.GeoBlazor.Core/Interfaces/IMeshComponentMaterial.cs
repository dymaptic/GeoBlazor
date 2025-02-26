namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IMeshComponentMaterial>))]
public partial interface IMeshComponentMaterial: IMapComponent
{
   // Add custom code to this file to override generated code
}