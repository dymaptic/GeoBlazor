namespace dymaptic.Blazor.GIS.API.Core.Objects;

public class MapRings : List<MapRing>
{
    public MapRings(params MapRing[] p)
    {
        AddRange(p);
    }
}

public class MapRing : List<double>
{
    public MapRing(params double[] p)
    {
        AddRange(p);
    }
}