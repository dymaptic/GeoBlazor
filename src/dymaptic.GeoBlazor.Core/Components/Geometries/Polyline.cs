namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public partial class Polyline : Geometry
{


    /// <summary>
    ///     An array of <see cref="MapPath" /> paths, or line segments, that make up the polyline.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public IReadOnlyList<MapPath> Paths { get; set; } = [];
    
    /// <summary>
    ///     Is Simple based on the ArcGIS simplify operator. Indicates if the given geometry is non-OGC topologically simple. This operation takes into account z-values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-operators-simplifyOperator.html#isSimple">ArcGIS Maps SDK for JavaScript</a>
    ///     Polyline geometries can have self-intersecting paths, however they cannot have degenerate segments. A degenerate segment is a zero-length segment where the start and end points are essentially the same. When the polyline has no z, degenerate segments are those that have a length in the xy plane less than or equal to the tolerance. When the polyline has z, degenerate segments are those that are shorter than the tolerance in the xy plane, and the change in the z-value along the segment is less than or equal to the z-tolerance.
    /// </summary>
    [ArcGISProperty]
    [CodeGenerationIgnore]
    public override bool? IsSimple { get; internal set; }

    /// <inheritdoc />
    public override GeometryType Type => GeometryType.Polyline;

    /// <summary>
    ///     Returns a deep clone of the geometry.
    /// </summary>
    public Polyline Clone()
    {
        return new Polyline(Paths.Select(p => p.Clone()).ToArray(), SpatialReference?.Clone(), 
            HasM, HasZ);
    }
    
    /// <inheritdoc />
    public override GeometrySerializationRecord ToProtobuf()
    {
        return new GeometrySerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), 
            Extent?.ToProtobuf(),
            SpatialReference?.ToProtobuf())
        {
            Paths = Paths.Select(p => p.ToProtobuf()).ToArray(),
            HasM = HasM,
            HasZ = HasZ
        };
    }
}