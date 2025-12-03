namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Model.GeographicTransformation.html">GeoBlazor Docs</a>
///     Create a geographic transformation that can be used to project 2D geometries between different geographic coordinate systems to ensure that data is properly aligned within a map.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-operators-support-GeographicTransformation.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Steps">
///     An ordered list of geographic transformation steps that represent the process of transforming coordinates from one geographic coordinate system to another.
///     default []
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-operators-support-GeographicTransformation.html#steps">ArcGIS Maps SDK for JavaScript</a>
/// </param>
[CodeGenerationIgnore]
public record GeographicTransformation(
    IReadOnlyList<GeographicTransformationStep> Steps)
{
    public GeographicTransformation(): this([])
    {
        
    }

    public IReadOnlyList<GeographicTransformationStep> Steps { get; set; } = Steps;

    /// <summary>
    ///     Returns the inverse of the geographic transformation calling this method or null if the transformation is not invertible.
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