namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     The return object of <see cref = "GeometryEngine.ExtendedSpatialReferenceInfo"/>
/// </summary>
[Obsolete("Deprecated since version 4.32.")]
public record SpatialReferenceInfo
{
    /// <summary>
    ///     The XY tolerance of the spatial reference.
    /// </summary>
    [Obsolete("Deprecated since version 4.32.")]
    public double Tolerance { get; set; }
    /// <summary>
    ///     Base factor.
    /// </summary>
    [Obsolete("Deprecated since version 4.32.")]
    public double UnitBaseFactor { get; set; }
    /// <summary>
    ///     Unit ID.
    /// </summary>
     // ReSharper disable once InconsistentNaming
    [Obsolete("Deprecated since version 4.32.")]
    public int UnitID { get; set; }
    /// <summary>
    ///     Square derivative.
    /// </summary>
    [Obsolete("Deprecated since version 4.32.")]
    public double UnitSquareDerivative { get; set; }
    /// <summary>
    ///     Unit type.
    /// </summary>
    [Obsolete("Deprecated since version 4.32.")]
    public int UnitType { get; set; }
}