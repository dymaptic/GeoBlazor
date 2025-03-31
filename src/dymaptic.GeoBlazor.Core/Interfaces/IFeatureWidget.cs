namespace dymaptic.GeoBlazor.Core.Interfaces;


/// <summary>
///     
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IFeatureWidget>))]
public partial interface IFeatureWidget: IMapComponent
{
   // Add custom code to this file to override generated code
}