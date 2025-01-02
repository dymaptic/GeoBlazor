namespace dymaptic.GeoBlazor.Core.Components.Geometries;

[Obsolete("Renamed to Polyline (lowercase 'l') to match the JavaScript API")]
public class PolyLine : Polyline
{
    public PolyLine()
    {
    }

    public PolyLine(MapPath[] paths, SpatialReference? spatialReference = null,
        Extent? extent = null): base(paths, spatialReference)
    {
    }
}