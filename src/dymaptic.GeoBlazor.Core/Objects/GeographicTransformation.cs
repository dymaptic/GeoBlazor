namespace dymaptic.GeoBlazor.Core.Objects;

public class GeographicTransformation
{
    public GeographicTransformationStep[] Steps { get; set; } = Array.Empty<GeographicTransformationStep>();

    public GeographicTransformation GetInverse()
    {
        throw new NotImplementedException();
    }
}