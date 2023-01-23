using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A polyline contains an array of paths and spatialReference. Each path is represented as an array of points. A polyline also has boolean-valued hasM and hasZ properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">ArcGIS JS API</a>
/// </summary>
public class PolyLine : Geometry, IEquatable<PolyLine>
{
    /// <summary>
    ///     A parameterless constructor for using as a razor component
    /// </summary>
    public PolyLine()
    {
    }

    /// <summary>
    ///     Creates a new PolyLine in code with parameters
    /// </summary>
    /// <param name="paths">
    ///     An array of <see cref="MapPath"/> paths, or line segments, that make up the polyline.
    /// </param>
    /// <param name="spatialReference">
    ///     The <see cref="SpatialReference"/> of the geometry.
    /// </param>
    /// <param name="extent">
    ///     The <see cref="Extent"/> of the geometry.
    /// </param>
    public PolyLine(MapPath[] paths, SpatialReference? spatialReference = null,
        Extent? extent = null)
    {
#pragma warning disable BL0005
        Paths = paths;
        SpatialReference = spatialReference;
        Extent = extent;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     An array of <see cref="MapPath"/> paths, or line segments, that make up the polyline.
    /// </summary>
    [Parameter]
    public MapPath[] Paths
    {
        get => _paths;
        set
        {
            if (!_paths.SequenceEqual(value, MapPathEqualityComparer.Instance))
            {
                _paths = value.Select(p => p.DeepCopy()).ToArray();
                Task.Run(UpdateComponent);
            }
        }
    }

    /// <inheritdoc />
    public override string Type => "polyline";
    private MapPath[] _paths = Array.Empty<MapPath>();

    public bool Equals(PolyLine? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return _paths.Equals(other._paths);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        return Equals((PolyLine)obj);
    }

    public override int GetHashCode()
    {
        return _paths.GetHashCode();
    }

    public static bool operator ==(PolyLine? left, PolyLine? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(PolyLine? left, PolyLine? right)
    {
        return !Equals(left, right);
    }
}