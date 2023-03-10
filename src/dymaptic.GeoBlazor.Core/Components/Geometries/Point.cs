using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A location defined by X, Y, and Z coordinates.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class Point : Geometry, IEquatable<Point>
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public Point()
    {
    }

    /// <summary>
    ///     Creates a new Point programmatically with parameters
    /// </summary>
    /// <param name="longitude">
    ///     The longitude of the point.
    /// </param>
    /// <param name="latitude">
    ///     The latitude of the point.
    /// </param>
    /// <param name="x">
    ///     The x-coordinate (easting) of the point in map units.
    /// </param>
    /// <param name="y">
    ///     The y-coordinate (northing) of the point in map units.
    /// </param>
    /// <param name="z">
    ///     The z-coordinate (or elevation) of the point in map units.
    /// </param>
    /// <param name="spatialReference">
    ///     The <see cref="SpatialReference" /> of the geometry.
    /// </param>
    /// <param name="extent">
    ///     The <see cref="Extent" /> of the geometry.
    /// </param>
    public Point(double? longitude = null, double? latitude = null, double? x = null, double? y = null,
        double? z = null,
        SpatialReference? spatialReference = null, Extent? extent = null)
    {
#pragma warning disable BL0005
        Latitude = latitude;
        Longitude = longitude;
        X = x;
        Y = y;
        Z = z;
        SpatialReference = spatialReference;
        Extent = extent;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The latitude of the point.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Latitude { get; set; }

    /// <summary>
    ///     The longitude of the point.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Longitude { get; set; }

    /// <summary>
    ///     The x-coordinate (easting) of the point in map units.
    /// </summary>
    [Parameter]
    public double? X { get; set; }

    /// <summary>
    ///     The y-coordinate (northing) of the point in map units.
    /// </summary>
    [Parameter]
    public double? Y { get; set; }

    /// <summary>
    ///     The z-coordinate (or elevation) of the point in map units.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Z { get; set; }

    /// <summary>
    ///     The m-coordinate of the point in map units.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? M { get; set; }

    /// <inheritdoc />
    public override string Type => "point";

    /// <summary>
    ///     Implements custom equality checks
    /// </summary>
    public bool Equals(Point? other)
    {
        if (ReferenceEquals(null, other)) return false;
        
        return (Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude)) ||
            (X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z));
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != GetType()) return false;

        return Equals((Point)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Latitude, Longitude, X, Y, Z);
    }

    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new PointSerializationRecord(Longitude, Latitude, X, Y, Z, SpatialReference?.ToSerializationRecord(),
            Extent?.ToSerializationRecord() as ExtentSerializationRecord);
    }
}

internal record PointSerializationRecord(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? Longitude = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? Latitude = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? X = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? Y = null, 
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]double? Z = null, 
    SpatialReferenceSerializationRecord? SpatialReference = null, 
    ExtentSerializationRecord? Extent = null) 
    : GeometrySerializationRecord("point", Extent, SpatialReference);