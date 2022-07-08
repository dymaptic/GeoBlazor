using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Geometries;

public class Point : Geometry
{
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

    [Parameter]
    public double? X { get; set; }

    [Parameter]
    public double? Y { get; set; }

    public override string Type => "point";

    public bool Equals(Point? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return base.Equals(other) && Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((Point)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Latitude, Longitude);
    }

    private double? _latitude;
    private double? _longitude;
}