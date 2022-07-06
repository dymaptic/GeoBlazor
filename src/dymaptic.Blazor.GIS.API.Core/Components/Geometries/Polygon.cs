using dymaptic.Blazor.GIS.API.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Geometries;

public class Polygon : Geometry, IEquatable<Polygon>
{
    [Parameter]
    public MapPath[] Rings
    {
        get => _rings;
        set
        {
            if (!_rings.SequenceEqual(value, MapPathEqualityComparer.Instance))
            {
                _rings = value.Select(p => p.DeepCopy()).ToArray();
                Task.Run(UpdateComponent);
            }
        }
    }

    public override string Type => "polygon";

    public bool Equals(Polygon? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && Rings.Equals(other.Rings);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((Polygon)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Rings);
    }

    private MapPath[] _rings = Array.Empty<MapPath>();
}