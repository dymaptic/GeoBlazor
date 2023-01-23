using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A location defined by X, Y, and Z coordinates.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">ArcGIS JS API</a>
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
    /// <param name="latitude">
    ///     The latitude of the point.
    /// </param>
    /// <param name="longitude">
    ///     The longitude of the point.
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
    ///     The <see cref="SpatialReference"/> of the geometry.
    /// </param>
    /// <param name="extent">
    ///     The <see cref="Extent"/> of the geometry.
    /// </param>
    public Point(double? latitude = null, double? longitude = null, double? x = null, double? y = null, double? z = null,
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
    public double? Latitude
    {
        get => _latitude;
        set
        {
            if (_latitude is null || value is null ||
                (Math.Abs(_latitude.Value - value.Value) > 0.0000000000001))
            {
                _latitude = value;
                Task.Run(UpdateComponent);
            }
        }
    }

    /// <summary>
    ///     The longitude of the point.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Longitude
    {
        get => _longitude;
        set
        {
            if (_longitude is null || value is null ||
                (Math.Abs(_longitude.Value - value.Value) > 0.0000000000001))
            {
                _longitude = value;
                Task.Run(UpdateComponent);
            }
        }
    }

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
        if (ReferenceEquals(this, other)) return true;

        return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude) &&
               X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((Point)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Latitude, Longitude);
    }

    private double? _latitude;
    private double? _longitude;
}