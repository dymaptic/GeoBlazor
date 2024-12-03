using dymaptic.GeoBlazor.Core.Components.Geometries;
using ProtoBuf;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Represents both <see cref="Polyline.Paths" /> and <see cref="Polygon.Rings" />, as a two-dimensional array of
///     number coordinates.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html#paths">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(MapPathConverter))]
public class MapPath : List<MapPoint>, IEquatable<MapPath>
{
    public static implicit operator MapPath(MapPoint[] p) => new(p);
    public static implicit operator MapPath(List<List<double>> p) => new(p.Select(x => new MapPoint(x)));
    public static implicit operator MapPath(double[][] p) => new(p.Select(x => new MapPoint(x)));
    
    /// <summary>
    ///     Generate a new path or ring from a parameter list of points.
    /// </summary>
    public MapPath(params MapPoint[] p)
    {
        AddRange(p);
    }

    /// <summary>
    ///     Generate a new path or ring from a collection of points.
    /// </summary>
    public MapPath(IEnumerable<MapPoint> p)
    {
        AddRange(p);
    }

    /// <summary>
    ///     Custom equality check.
    /// </summary>
    public bool Equals(MapPath? other)
    {
        return other is not null && this.SequenceEqual(other, MapPointEqualityComparer.Instance);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((MapPath)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();

        for (var i = 0; i < Count; i++)
        {
            hash += this[i].GetHashCode();
        }

        return hash;
    }

    /// <summary>
    ///     Clones a path and returns the new copy.
    /// </summary>
    public MapPath Clone()
    {
        var newPath = new MapPath();

        for (var i = 0; i < Count; i++)
        {
            MapPoint point = this[i];
            newPath.Add(point.Copy());
        }

        return newPath;
    }

    internal MapPathSerializationRecord ToSerializationRecord()
    {
        return new MapPathSerializationRecord(this.Select(p => p.ToSerializationRecord()).ToArray());
    }
}

internal class MapPathEqualityComparer : EqualityComparer<MapPath>
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

/// <summary>
///     This is another representation of <see cref="Point" /> that should be used to create <see cref="MapPath" />s.
/// </summary>
[JsonConverter(typeof(MapPointConverter))]
public class MapPoint : List<double>, IEquatable<MapPoint>
{
    public static implicit operator MapPoint(double[] p) => new(p);
    
    /// <summary>
    ///     Create a new point from a parameter list of numbers.
    /// </summary>
    public MapPoint(params double[] p)
    {
        AddRange(p);
    }

    /// <summary>
    ///     Create a new point from a collection of numbers.
    /// </summary>
    public MapPoint(IEnumerable<double> p)
    {
        AddRange(p);
    }

    /// <summary>
    ///     Custom equality check.
    /// </summary>
    public bool Equals(MapPoint? other)
    {
        return other is not null && this.SequenceEqual(other);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((MapPoint)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();

        for (var i = 0; i < Count; i++)
        {
            hash += this[i].GetHashCode();
        }

        return hash;
    }

    /// <summary>
    ///     Clones and returns the copy.
    /// </summary>
    public MapPoint Copy()
    {
        return new MapPoint(this);
    }

    internal MapPointSerializationRecord ToSerializationRecord()
    {
        return new MapPointSerializationRecord(ToArray());
    }
}

[ProtoContract(Name = "MapPath")]
internal record MapPathSerializationRecord
{
    public MapPathSerializationRecord()
    {
    }
    
    public MapPathSerializationRecord(MapPointSerializationRecord[] Points)
    {
        this.Points = Points;
    }

    public MapPath FromSerializationRecord()
    {
        return new MapPath(Points.Select(p => p.FromSerializationRecord()));
    }

    [ProtoMember(1)]
    public MapPointSerializationRecord[] Points { get; init; } = Array.Empty<MapPointSerializationRecord>(); 
}

[ProtoContract(Name = "MapPoint")]
internal record MapPointSerializationRecord
{
    public MapPointSerializationRecord()
    {
    }
    
    public MapPointSerializationRecord(double[] Coordinates)
    {
        this.Coordinates = Coordinates;
    }

    public MapPoint FromSerializationRecord()
    {
        return new MapPoint(Coordinates);
    }

    [ProtoMember(1)]
    public double[] Coordinates { get; init; } = Array.Empty<double>();
}

internal class MapPointEqualityComparer : EqualityComparer<MapPoint>
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

internal class MapPathConverter : JsonConverter<MapPath>
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

internal class MapPointConverter : JsonConverter<MapPoint>
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