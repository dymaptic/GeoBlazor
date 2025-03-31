namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     Projecting your data between coordinate systems sometimes requires transforming between geographic coordinate
///     systems. Geographic transformations are used to transform coordinates between spatial references that have
///     different geographic coordinate systems, and thus different datums. Using the most suitable transformation ensures
///     the best possible accuracy when converting geometries from one spatial reference to another.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-GeographicTransformation.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record GeographicTransformation
{
    /// <summary>
    ///     Geographic transformation steps.
    /// </summary>
    public GeographicTransformationStep[] Steps { get; set; } = [];

    /// <summary>
    ///     Returns the inverse of the geographic transformation calling this method or null if the transformation is not
    ///     invertible.
    /// </summary>
    [ArcGISMethod]
    public GeographicTransformation GetInverse()
    {
        return new GeographicTransformation
        {
            Steps = Steps.Select(s => s with { IsInverse = !s.IsInverse }).Reverse().ToArray()
        };
    }
}