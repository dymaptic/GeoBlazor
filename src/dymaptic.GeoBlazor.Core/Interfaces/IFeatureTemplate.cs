namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IFeatureTemplate>))]
public partial interface IFeatureTemplate: IMapComponent
{
   // Add custom code to this file to override generated code
}