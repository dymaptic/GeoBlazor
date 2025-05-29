namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class WFSLayer
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Layers.WFSLayer.html#wfslayerwfscapabilities-property">GeoBlazor Docs</a>
   ///     WFS service information about the available layers and operations.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WFSLayer.html#wfsCapabilities">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   [ArcGISProperty]
   [CodeGenerationIgnore]
   [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
   public WFSCapabilities? WfsCapabilities { get; set; }
   
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