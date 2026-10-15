namespace dymaptic.GeoBlazor.Pro.Model;

public partial record Column: IInteractiveRecord
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     Width of the column in pixels.
   ///     default 200
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FeatureTable-Grid-Column.html#width">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   [JsonConverter(typeof(DimensionToPixelsConverter))]
   [CodeGenerationIgnore]
   public Dimension? Width { get; set; } = Width;
}