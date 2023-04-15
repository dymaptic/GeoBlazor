using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using ProtoBuf;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A polygon contains an array of rings and a spatialReference. Each ring is represented as an array of points. The
///     first and last points of a ring must be the same. A polygon also has boolean-valued hasM and hasZ fields.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class Polygon : Geometry, IEquatable<Polygon>
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public Polygon()
    {
    }

    /// <summary>
    ///     Creates a new polygon in code with parameters
    /// </summary>
    /// <param name="rings">
    ///     An array of <see cref="MapPath" /> rings.
    /// </param>
    /// <param name="spatialReference">
    ///     The <see cref="SpatialReference" /> of the geometry.
    /// </param>
    /// <param name="extent">
    ///     The <see cref="Extent" /> of the geometry.
    /// </param>
    public Polygon(MapPath[] rings, SpatialReference? spatialReference = null, Extent? extent = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Rings = rings;
        SpatialReference = spatialReference;
        Extent = extent;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     Override equality operator
    /// </summary>
    public static bool operator ==(Polygon? left, Polygon? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    ///     Override inequality operator
    /// </summary>
    public static bool operator !=(Polygon? left, Polygon? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    ///     An array of <see cref="MapPath" /> rings.
    /// </summary>
    [Parameter]
    public MapPath[] Rings { get; set; } = Array.Empty<MapPath>();

    /// <inheritdoc />
    public override string Type => "polygon";

    /// <inheritdoc />
    public bool Equals(Polygon? other)
    {
        if (ReferenceEquals(null, other)) return false;

        return Rings.Equals(other.Rings);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (obj.GetType() != GetType()) return false;

        return Equals((Polygon)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Rings.GetHashCode();
    }

    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new GeometrySerializationRecord(Type, Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Rings = Rings.Select(p => p.ToSerializationRecord()).ToArray()
        };
    }
}