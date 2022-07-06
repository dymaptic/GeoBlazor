using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Geometries;

public class Extent : Geometry, IEquatable<Extent>
{
    [Parameter]
    public double Xmax { get; set; }

    [Parameter]
    public double Xmin { get; set; }

    [Parameter]
    public double Ymax { get; set; }

    [Parameter]
    public double Ymin { get; set; }

    [Parameter]
    public double Zmax { get; set; }

    [Parameter]
    public double Zmin { get; set; }

    [Parameter]
    public double? Mmax { get; set; }

    [Parameter]
    public double? Mmin { get; set; }

    public override string Type => "extent";

    public bool Equals(Extent? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && Xmax.Equals(other.Xmax) && Xmin.Equals(other.Xmin) && Ymax.Equals(other.Ymax) &&
            Ymin.Equals(other.Ymin) && Zmax.Equals(other.Zmax) && Zmin.Equals(other.Zmin) &&
            Nullable.Equals(Mmax, other.Mmax) && Nullable.Equals(Mmin, other.Mmin);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((Extent)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(base.GetHashCode());
        hashCode.Add(Xmax);
        hashCode.Add(Xmin);
        hashCode.Add(Ymax);
        hashCode.Add(Ymin);
        hashCode.Add(Zmax);
        hashCode.Add(Zmin);
        hashCode.Add(Mmax);
        hashCode.Add(Mmin);

        return hashCode.ToHashCode();
    }
}