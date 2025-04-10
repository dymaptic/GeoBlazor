namespace dymaptic.GeoBlazor.Core.Components.Layers;

[Experimental("GeoBlazor_Untested", UrlFormat = "https://docs.geoblazor.com/pages/untested.html")]
public partial class WFSLayer
{
   // Add custom code to this file to override generated code
   
   /// <inheritdoc />
   public override async Task RegisterChildComponent(MapComponent child)
   {
      switch (child)
      {
         case IFeatureReduction reduction:
            if (!reduction.Equals(FeatureReduction))
            {
               FeatureReduction = reduction;
               if (MapRendered)
               {
                  await UpdateLayer();
               }
            }

            break;
         default:
            await base.RegisterChildComponent(child);

            break;
      }
   }

   /// <inheritdoc />
   public override async Task UnregisterChildComponent(MapComponent child)
   {
      switch (child)
      {
         case IFeatureReduction _:
            FeatureReduction = null;

            

            break;

         default:
            await base.UnregisterChildComponent(child);

            break;
      }
   }
   
   /// <inheritdoc />
   public override void ValidateRequiredChildren()
   {
      base.ValidateRequiredChildren();
      FeatureReduction?.ValidateRequiredChildren();
   }
}