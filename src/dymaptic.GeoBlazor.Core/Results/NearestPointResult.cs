namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Object returned from the nearestCoordinate(), nearestVertex(), and nearestVertices() methods of
///     <see cref="GeometryEngine" />.
/// </summary>
[Obsolete("Deprecated since version 4.32. Use {link module:esri/geometry/operators/proximityOperator~ProximityResult proximityOperator's ProximityResult} instead.")]
public record NearestPointResult
{
    /// <summary>
    ///     A vertex within the specified distance of the search.
    /// </summary>
    [Obsolete("Deprecated since version 4.32. Use {link module:esri/geometry/operators/proximityOperator~ProximityResult proximityOperator's ProximityResult} instead.")]
    public Point Coordinate { get; set; } = default!;

    /// <summary>
    ///     The distance from the inputPoint in the units of the view's spatial reference.
    /// </summary>
    [Obsolete("Deprecated since version 4.32. Use {link module:esri/geometry/operators/proximityOperator~ProximityResult proximityOperator's ProximityResult} instead.")]
    public double Distance { get; set; }

    /// <summary>
    ///     The index of the vertex within the geometry's rings or paths.
    /// </summary>
    [Obsolete("Deprecated since version 4.32. Use {link module:esri/geometry/operators/proximityOperator~ProximityResult proximityOperator's ProximityResult} instead.")]
    public int VertexIndex { get; set; }

    /// <summary>
    ///     Indicates if it is an empty geometry.
    /// </summary>
    [Obsolete("Deprecated since version 4.32. Use {link module:esri/geometry/operators/proximityOperator~ProximityResult proximityOperator's ProximityResult} instead.")]
    public bool IsEmpty { get; set; }
}