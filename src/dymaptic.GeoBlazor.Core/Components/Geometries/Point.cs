using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A location defined by X, Y, and Z coordinates.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">ArcGIS JS API</a>
/// </summary>
public class Point : Geometry
{
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

    /// <inheritdoc />
    public override string Type => "point";

    /// <summary>
    ///     Implements custom equality checks
    /// </summary>
    public bool Equals(Point? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
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