namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
public class GeographicTransformation
{
    public GeographicTransformationStep[] Steps { get; set; } = Array.Empty<GeographicTransformationStep>();

    public GeographicTransformation GetInverse()
    {
        throw new NotImplementedException();
    }
}