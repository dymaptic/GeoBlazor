namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public partial class Point : Geometry
{


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
    public override GeometryType Type => GeometryType.Point;

    /// <summary>
    ///     Returns a deep clone of the geometry.
    /// </summary>
    public Point Clone()
    {
        return new Point(Longitude, Latitude, X, Y, Z, SpatialReference?.Clone(), HasM, HasZ, M);
    }

    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new GeometrySerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), 
            Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Longitude = Longitude,
            Latitude = Latitude,
            X = X,
            Y = Y,
            Z = Z,
            HasM = HasM,
            HasZ = HasZ,
            M = M
        };
    }
}