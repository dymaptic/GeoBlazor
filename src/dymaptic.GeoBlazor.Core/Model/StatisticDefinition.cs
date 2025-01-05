namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     This class defines the parameters for querying a layer or layer view for statistics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-StatisticDefinition.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name = "OnStatisticField">
///     Defines the field for which statistics will be calculated. This can be service field names or SQL expressions. See
///     the snippets below for examples.
/// </param>
/// <param name = "OutStatisticFieldName">
///     Specifies the output field name for the requested statistic. Output field names can only contain alpha-numeric
///     characters and an underscore. If no output field name is specified, the server assigns a field name to the returned
///     statistic field.
/// </param>
/// <param name = "StatisticType">
///     Defines the type of statistic.
/// </param>
/// <param name = "StatisticParameters">
///     The parameters for percentile statistics. This property must be set when the statisticType is set to either
///     percentile-continuous or percentile-discrete.
/// </param>
public record StatisticDefinition(string OnStatisticField, string OutStatisticFieldName, StatisticType StatisticType, StatisticParameters StatisticParameters);

