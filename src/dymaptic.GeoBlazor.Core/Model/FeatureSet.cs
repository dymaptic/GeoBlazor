namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.FeatureSet.html">GeoBlazor Docs</a>
///     A collection of features returned from ArcGIS Server or used as input to methods.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="DisplayFieldName">
///     The name of the layer's primary display field.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html#displayFieldName">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ExceededTransferLimit">
///     Typically, a layer has a limit on the number of features (i.e., records) returned by the query operation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html#exceededTransferLimit">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Features">
///     The array of graphics returned from a task.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html#features">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Fields">
///     Information about each field.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html#fields">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="GeometryType">
///     The geometry type of features in the FeatureSet.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html#geometryType">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="QueryGeometry">
///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-Query.html#geometry">geometry</a> used to query the features.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html#queryGeometry">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SpatialReference">
///     When a FeatureSet is used as input to Geoprocessor, the spatial reference is set to the map's spatial reference by default.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-FeatureSet.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
/// </param>
[CodeGenerationIgnore]
public record FeatureSet(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? DisplayFieldName = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    bool? ExceededTransferLimit = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyList<Field>? Fields = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    GeometryType? GeometryType = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    Geometry? QueryGeometry = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    SpatialReference? SpatialReference = null) : IClosestFacilityParametersFacilities, IClosestFacilityParametersIncidents, IServiceAreaParametersFacilities
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual Graphic[]? Features { get; init; }
}