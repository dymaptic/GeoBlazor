namespace dymaptic.GeoBlazor.Core.Components;

public partial class TimeExtent: MapComponent, IEquatable<TimeExtent>
{
    public bool Equals(TimeExtent? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Nullable.Equals(End, other.End) && Nullable.Equals(Start, other.Start);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((TimeExtent)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(End, Start);
    }

    public static bool operator ==(TimeExtent? left, TimeExtent? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(TimeExtent? left, TimeExtent? right)
    {
        return !Equals(left, right);
    }
}