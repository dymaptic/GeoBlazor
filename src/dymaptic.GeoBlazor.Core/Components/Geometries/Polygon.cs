namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public partial class Polygon : Geometry
{
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The centroid of the polygon.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html#centroid">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Point? Centroid { get; set; }
    
    /// <summary>
    ///     Checks to see if polygon rings cross each other and indicates if the polygon is self-intersecting, which means the ring of the polygon crosses itself.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html#isSelfIntersecting">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Obsolete("Deprecated since GeoBlazor 4.2.0. Please use Polygon.IsSimple instead.")]
    [CodeGenerationIgnore]
    public bool? IsSelfIntersecting { get; set; }
    
    /// <summary>
    ///     Is Simple based on the ArcGIS simplify operator. Indicates if the given geometry is non-OGC topologically simple. This operation takes into account z-values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-operators-simplifyOperator.html#isSimple">ArcGIS Maps SDK for JavaScript</a>
    ///     Polygon geometries are considered simple if the following is true:
    ///        - Contains no self-intersecting rings.
    ///        - Exterior rings are clockwise, and interior rings (holes) are counterclockwise.
    ///        - Rings can touch other rings in a finite number of points.
    ///        - Rings can be self-tangent in a finite number of points.
    ///        - Vertices are either exactly coincident, or further than the 2 * sqrt(2) * tolerance from each other.
    ///        - If a vertex is not equal to any boundary point of a segment, it has to be further than sqrt(2) * tolerance from any segment.
    ///        - No segment length is zero.
    ///        - Each path contains at least three non-equal vertices.
    ///        - No empty paths are allowed.
    ///        - Order of rings does not matter.
    ///     The tolerance value is obtained from the geometry's spatial reference. If it is null, then a small tolerance value is calculated from the geometry coordinates using double-precision.
    /// </summary>
    [ArcGISProperty]
    [CodeGenerationIgnore]
    public override bool? IsSimple { get; internal set; }

    /// <summary>
    ///     An array of <see cref="MapPath" /> rings.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public IReadOnlyList<MapPath> Rings { get; set; } = [];

    /// <inheritdoc />
    public override GeometryType Type => GeometryType.Polygon;

#endregion
    
    /// <summary>
    ///     Returns a deep clone of the geometry.
    /// </summary>
    public Polygon Clone()
    {
        return new Polygon(Rings.Select(p => p.Clone()).ToArray(), SpatialReference?.Clone(), 
            Centroid, HasM, HasZ);
    }
    
    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new GeometrySerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), 
            Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Rings = Rings.Select(p => p.ToSerializationRecord()).ToArray(),
            HasM = HasM,
            HasZ = HasZ,
            Centroid = Centroid?.ToSerializationRecord(),
#pragma warning disable CS0618 // Type or member is obsolete
            IsSelfIntersecting = IsSelfIntersecting
#pragma warning restore CS0618 // Type or member is obsolete
        };
    }
}