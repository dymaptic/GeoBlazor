using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.Blazor.GIS.API.Core.Objects;

[JsonConverter(typeof(MapPathConverter))]
public class MapPath : List<MapPoint>, IEquatable<MapPath>
{
    public MapPath(params MapPoint[] p)
    {
        AddRange(p);
    }

    public MapPath(IEnumerable<MapPoint> p)
    {
        AddRange(p);
    }

    public bool Equals(MapPath? other)
    {
        return other is not null && this.SequenceEqual(other, MapPointEqualityComparer.Instance);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((MapPath)obj);
    }

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();

        for (var i = 0; i < Count; i++)
        {
            hash += this[i].GetHashCode();
        }

        return hash;
    }

    public MapPath DeepCopy()
    {
        var newPath = new MapPath();

        for (var i = 0; i < Count; i++)
        {
            MapPoint point = this[i];
            newPath.Add(point.Copy());
        }

        return newPath;
    }
}

public class MapPathEqualityComparer : EqualityComparer<MapPath>
{
    public static MapPathEqualityComparer Instance => _instance ??= new MapPathEqualityComparer();

    public override bool Equals(MapPath? x, MapPath? y)
    {
        if (x is null && y is null) return true;
        if (x is null) return false;
        if (y is null) return false;

        return x.Equals(y);
    }

    public override int GetHashCode(MapPath obj)
    {
        return obj.GetHashCode();
    }

    private static MapPathEqualityComparer? _instance;
}

[JsonConverter(typeof(MapPointConverter))]
public class MapPoint : List<double>, IEquatable<MapPoint>
{
    public MapPoint(params double[] p)
    {
        AddRange(p);
    }

    public MapPoint(IEnumerable<double> p)
    {
        AddRange(p);
    }

    public bool Equals(MapPoint? other)
    {
        return other is not null && this.SequenceEqual(other);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((MapPoint)obj);
    }

    public override int GetHashCode()
    {
        int hash = base.GetHashCode();

        for (var i = 0; i < Count; i++)
        {
            hash += this[i].GetHashCode();
        }

        return hash;
    }

    public MapPoint Copy()
    {
        return new MapPoint(this);
    }
}

public class MapPointEqualityComparer : EqualityComparer<MapPoint>
{
    public static MapPointEqualityComparer Instance => _instance ??= new MapPointEqualityComparer();

    public override bool Equals(MapPoint? x, MapPoint? y)
    {
        if (x is null && y is null) return true;
        if (x is null) return false;
        if (y is null) return false;

        return x.Equals(y);
    }

    public override int GetHashCode(MapPoint obj)
    {
        return obj.GetHashCode();
    }

    private static MapPointEqualityComparer? _instance;
}

public class MapPathConverter : JsonConverter<MapPath>
{
    public override MapPath? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        List<MapPoint>? list = JsonSerializer.Deserialize<List<MapPoint>>(ref reader, options);

        if (list is null) return null;

        return new MapPath(list);
    }

    public override void Write(Utf8JsonWriter writer, MapPath value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(List<MapPoint>), options);
    }
}

public class MapPointConverter : JsonConverter<MapPoint>
{
    public override MapPoint? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        List<double>? list = JsonSerializer.Deserialize<List<double>>(ref reader, options);

        if (list is null) return null;

        return new MapPoint(list);
    }

    public override void Write(Utf8JsonWriter writer, MapPoint value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(List<double>), options);
    }
}