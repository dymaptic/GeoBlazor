namespace dymaptic.GeoBlazor.Core.Components;

public partial class LegendLayerInfos
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     Parameterless constructor for use as a Razor Component.
   /// </summary>
   [ActivatorUtilitiesConstructor]
   [CodeGenerationIgnore]
   public LegendLayerInfos()
   {
   }
   
   /// <summary>
   ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
   /// </summary>
   /// <param name="layerId">
   ///     A layer to display in the legend.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#layerInfos">ArcGIS Maps SDK for JavaScript</a>
   /// </param>
   /// <param name="sublayerIds">
   ///     Only applicable if the `layer` is a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-MapImageLayer.html">MapImageLayer</a>, <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-SubtypeGroupLayer.html">SubtypeGroupLayer</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WMSLayer.html">WMSLayer</a>.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#layerInfos">ArcGIS Maps SDK for JavaScript</a>
   /// </param>
   /// <param name="title">
   ///     Specifies a title for the layer to display above its symbols and descriptions.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#layerInfos">ArcGIS Maps SDK for JavaScript</a>
   /// </param>
   [CodeGenerationIgnore]
   public LegendLayerInfos(
      Guid? layerId = null,
      IReadOnlyList<long>? sublayerIds = null,
      string? title = null)
   {
      AllowRender = false;
#pragma warning disable BL0005
      LayerId = layerId;
      SublayerIds = sublayerIds;
      Title = title;
#pragma warning restore BL0005    
   }
}