using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A location defined by X, Y, and Z coordinates.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Point : Geometry
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
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
        AllowRender = false;
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
    ///     Returns a deep clone of the geometry.
    /// </summary>
    public Point Clone()
    {
        return new Point(Longitude, Latitude, X, Y, Z, SpatialReference?.Clone(), Extent?.Clone());
    }

    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new GeometrySerializationRecord(Type, Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Longitude = Longitude,
            Latitude = Latitude,
            X = X,
            Y = Y,
            Z = Z
        };
    }
}