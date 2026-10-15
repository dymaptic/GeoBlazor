namespace dymaptic.GeoBlazor.Pro.Model;

public partial record FeatureFormGroupInput: FeatureFormInputBase
{
   // Add custom code to this file to override generated code

   /// <inheritdoc />
   public override FeatureFormInputType Type => FeatureFormInputType.Group;
}