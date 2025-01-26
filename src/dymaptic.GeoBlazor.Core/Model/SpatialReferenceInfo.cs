namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     The return object of <see cref = "GeometryEngine.ExtendedSpatialReferenceInfo"/>
/// </summary>
public record SpatialReferenceInfo
{
    /// <summary>
    ///     The XY tolerance of the spatial reference.
    /// </summary>
    public double Tolerance { get; set; }
    /// <summary>
    ///     Base factor.
    /// </summary>
    public double UnitBaseFactor { get; set; }
    /// <summary>
    ///     Unit ID.
    /// </summary>
     // ReSharper disable once InconsistentNaming
    public int UnitID { get; set; }
    /// <summary>
    ///     Square derivative.
    /// </summary>
    public double UnitSquareDerivative { get; set; }
    /// <summary>
    ///     Unit type.
    /// </summary>
    public int UnitType { get; set; }
}