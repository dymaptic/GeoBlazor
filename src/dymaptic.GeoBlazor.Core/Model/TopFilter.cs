namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     This class defines the top filter parameters for executing top features queries for features from a FeatureLayer.
///     This parameter must be set on the TopFeaturesQuery object when calling any of top query methods on a FeatureLayer.
///     It is used to set the groupByFields, orderByFields, and count criteria used the top features query. For example,
///     you can use FeatureLayer's queryTopFeatures() method to query the most populous three counties in each state of the
///     United States.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-TopFilter.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record TopFilter(IReadOnlyList<string>? GroupByFields, IReadOnlyList<string>? OrderByFields, int? TopCount)
{
    /// <summary>
    ///     When one or more field names are provided in this property, the output result will be grouped based on unique
    ///     values from those fields.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? GroupByFields { get; set; } = GroupByFields;

    /// <summary>
    ///     One or more field names used to order the query results. Specify ASC (ascending) or DESC (descending) after the
    ///     field name to control the order. The default order is ASC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? OrderByFields { get; set; } = OrderByFields;

    /// <summary>
    ///     Defines the number of features to be returned from the top features query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TopCount { get; set; } = TopCount;
}