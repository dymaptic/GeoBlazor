using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Object returned from the nearestCoordinate(), nearestVertex(), and nearestVertices() methods of
///     <see cref="GeometryEngine" />.
/// </summary>
public class NearestPointResult
{
    /// <summary>
    ///     A vertex within the specified distance of the search.
    /// </summary>
    public Point Coordinate { get; set; } = default!;

    /// <summary>
    ///     The distance from the inputPoint in the units of the view's spatial reference.
    /// </summary>
    public double Distance { get; set; }

    /// <summary>
    ///     The index of the vertex within the geometry's rings or paths.
    /// </summary>
    public int VertexIndex { get; set; }

    /// <summary>
    ///     Indicates if it is an empty geometry.
    /// </summary>
    public bool IsEmpty { get; set; }
}