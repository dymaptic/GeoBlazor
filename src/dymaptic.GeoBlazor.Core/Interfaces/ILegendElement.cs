namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<ILegendElement>))]
public partial interface ILegendElement: IMapComponent
{
   // Add custom code to this file to override generated code
}
