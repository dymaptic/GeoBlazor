namespace dymaptic.GeoBlazor.Core.Interfaces;


/// <summary>
///     
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IFeatureViewModel>))]
public partial interface IFeatureViewModel: IMapComponent
{
   // Add custom code to this file to override generated code
}