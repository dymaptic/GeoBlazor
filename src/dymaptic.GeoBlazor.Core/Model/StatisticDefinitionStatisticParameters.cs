namespace dymaptic.GeoBlazor.Core.Model;

public partial record StatisticDefinitionStatisticParameters
{
   // Add custom code to this file to override generated code

   /// <summary>
   ///     Specify `ASC` (ascending) or `DESC` (descending) to control the order of the data.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-StatisticDefinition.html#statisticParameters">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   [JsonConverter(typeof(EnumToUpperCaseStringConverter<OrderBy>))]
   [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
   public OrderBy? OrderBy { get; init; } = OrderBy;
}