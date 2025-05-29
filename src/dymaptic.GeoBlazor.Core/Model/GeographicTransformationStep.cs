namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Represents a step in the process of transforming coordinates from one geographic coordinate system to another. A geographic transformation step can be constructed from a well-known ID (wkid) or a well known text (wkt) that represents a geographic datum transformation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-GeographicTransformationStep.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record GeographicTransformationStep
{
    /// <summary>
    ///     Indicates if the geographic transformation is inverted.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsInverse { get; set; }

    /// <summary>
    ///     The well-known id (wkid) that represents a known geographic transformation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Wkid { get; set; }

    /// <summary>
    ///     The well-known text (wkt) that represents a known geographic transformation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Wkt { get; set; }
}