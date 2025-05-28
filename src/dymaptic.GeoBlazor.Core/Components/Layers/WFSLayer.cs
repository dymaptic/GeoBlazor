namespace dymaptic.GeoBlazor.Core.Components.Layers;

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
   
   public static WFSLayer FromWFSLayerInfo(WFSLayerInfo wfsLayerInfo)
   {
      return new WFSLayer
      {
         Url = wfsLayerInfo.Url,
         Name = wfsLayerInfo.Name,
         NamespaceUri = wfsLayerInfo.NamespaceUri,
         SpatialReference = wfsLayerInfo.SpatialReference,
         CustomParameters = wfsLayerInfo.CustomParameters,
         Fields = wfsLayerInfo.Fields?.ToList(),
         GeometryType = wfsLayerInfo.GeometryType,
         ObjectIdField = wfsLayerInfo.ObjectIdField,
         WfsCapabilities = wfsLayerInfo.WfsCapabilities
      };
   }
}