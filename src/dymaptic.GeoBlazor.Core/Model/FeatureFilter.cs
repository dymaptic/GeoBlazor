namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FeatureFilter: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public FeatureFilter()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="distance">
    ///     Specifies a search distance from a given [geometry](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#geometry) in a spatial filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#distance">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     The geometry to apply to the spatial filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#geometry">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="objectIds">
    ///     An array of objectIds of the features to be filtered.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#objectIds">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialRelationship">
    ///     For spatial filters, this parameter defines the spatial relationship to filter features in the layer view against the filter [geometry](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#geometry).
    ///     default intersects
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#spatialRelationship">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="timeExtent">
    ///     A range of time with start and end date.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#timeExtent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="units">
    ///     The unit for calculating the buffer distance when [distance](https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#distance) is specified in a spatial filter.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#units">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="where">
    ///     A where clause for the feature filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-FeatureFilter.html#where">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public FeatureFilter(
        double? distance = null,
        Geometry? geometry = null,
        IReadOnlyList<long>? objectIds = null,
        SpatialRelationship? spatialRelationship = null,
        TimeExtent? timeExtent = null,
        LinearUnit? units = null,
        string? where = null)
    {
#pragma warning disable BL0005
        Distance = distance;
        Geometry = geometry;
        ObjectIds = objectIds;
        SpatialRelationship = spatialRelationship;
        TimeExtent = timeExtent;
        Units = units;
        Where = where;
#pragma warning restore BL0005    
    }
    
    /// <summary>
    ///     Specifies a search distance from a given geometry in a spatial filter. The units property indicates the unit of measurement. In essence, setting this property creates a buffer at the specified size around the input geometry. The filter will use that buffer to display features in the layer or layer view that adhere to the to the indicated spatial relationship.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Distance { get; set; }

    /// <summary>
    ///     The geometry to apply to the spatial filter. The spatial relationship as specified by spatialRelationship will indicate how the geometry should be used to filter features.
    /// </summary>
    /// <remarks>
    ///     Known Limitations: Mesh geometry types are currently not supported.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }

    /// <summary>
    ///     An array of objectIds of the features to be filtered.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<long>? ObjectIds { get; set; }

    /// <summary>
    ///     For spatial filters, this parameter defines the spatial relationship to filter features in the layer view against the filter geometry. The spatial relationships discover how features are spatially related to each other. For example, you may want to know if a polygon representing a county completely contains points representing settlements.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialRelationship? SpatialRelationship { get; set; }

    /// <summary>
    ///     A range of time with start and end date. Only the features that fall within this time extent will be displayed. The Date field to be used for timeExtent should be added to outFields list when the layer is initialized. This ensures the best user experience when switching or updating fields for time filters.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public TimeExtent? TimeExtent { get; set; }

    /// <summary>
    ///     The unit for calculating the buffer distance when distance is specified in a spatial filter. If units is not specified, the unit is derived from the filter geometry's spatial reference.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LinearUnit? Units { get; set; }

    /// <summary>
    ///     A where clause for the feature filter. Any legal SQL92 where clause operating on the fields in the layer is allowed. Be sure to have the correct sequence of single and double quotes when writing the where clause in JavaScript. For apps where users can interactively change fields used for attribute filter, we suggest you include all possible fields in the outFields of the layer. This ensures the best user experience when switching or updating fields for attribute filters.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
}