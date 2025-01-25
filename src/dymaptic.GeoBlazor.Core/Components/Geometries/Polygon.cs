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
    public bool? IsSelfIntersecting { get; set; }

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
            Centroid, HasM, HasZ, IsSelfIntersecting);
    }
    
    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new GeometrySerializationRecord(Type.ToString().ToKebabCase(), 
            Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Rings = Rings.Select(p => p.ToSerializationRecord()).ToArray(),
            HasM = HasM,
            HasZ = HasZ,
            Centroid = Centroid?.ToSerializationRecord(),
            IsSelfIntersecting = IsSelfIntersecting
        };
    }
}