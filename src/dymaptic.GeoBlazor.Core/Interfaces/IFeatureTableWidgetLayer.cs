namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IFeatureTableWidgetLayer>))]
public partial interface IFeatureTableWidgetLayer
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     Identifies the type of feature table layer.
   /// </summary>
   string FeatureTableLayerType { get; }
}
