namespace dymaptic.GeoBlazor.Core.Interfaces;


/// <summary>
///     
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IAttributeTableTemplate>))]
public partial interface IAttributeTableTemplate: IMapComponent
{
   // Add custom code to this file to override generated code
}