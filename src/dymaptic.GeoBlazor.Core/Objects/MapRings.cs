namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
public class MapRings : List<MapRing>
{
    public MapRings(params MapRing[] p)
    {
        AddRange(p);
    }
}

/// <summary>
///
///     <a target="_blank" href="">ArcGIS JS API</a>
/// </summary>
public class MapRing : List<double>
{
    public MapRing(params double[] p)
    {
        AddRange(p);
    }
}