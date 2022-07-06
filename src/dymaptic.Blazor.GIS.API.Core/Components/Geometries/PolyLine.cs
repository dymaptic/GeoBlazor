using dymaptic.Blazor.GIS.API.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Geometries;

public class PolyLine : Geometry, IEquatable<PolyLine>
{
    [Parameter]
    public MapPath[] Paths
    {
        get => _paths;
        set
        {
            if (!_paths.SequenceEqual(value, MapPathEqualityComparer.Instance))
            {
                _paths = value.Select(p => p.DeepCopy()).ToArray();
                Task.Run(UpdateComponent);
            }
        }
    }

    public override string Type => "polyline";

    public bool Equals(PolyLine? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && Paths.Equals(other.Paths);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((PolyLine)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Paths);
    }

    private MapPath[] _paths = Array.Empty<MapPath>();
}