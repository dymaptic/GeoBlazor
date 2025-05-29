namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public partial class Polyline : Geometry
{


    /// <summary>
    ///     An array of <see cref="MapPath" /> paths, or line segments, that make up the polyline.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public IReadOnlyList<MapPath> Paths { get; set; } = [];

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
    
    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new GeometrySerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), 
            Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Paths = Paths.Select(p => p.ToSerializationRecord()).ToArray(),
            HasM = HasM,
            HasZ = HasZ
        };
    }
}