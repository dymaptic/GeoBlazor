namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A polygon contains an array of rings and a spatialReference. Each ring is represented as an array of points. The
///     first and last points of a ring must be the same. A polygon also has boolean-valued hasM and hasZ fields.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Polygon : Geometry
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Polygon()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="rings">
    ///     An array of rings.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html#rings">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the geometry.
    ///     default WGS84 (wkid: 4326)
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="centroid">
    ///     The centroid of the polygon.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html#centroid">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="hasM">
    ///     Indicates if the geometry has M values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasM">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="hasZ">
    ///     Indicates if the geometry has z-values (elevation).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasZ">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="isSelfIntersecting">
    ///     Checks to see if polygon rings cross each other and indicates if the polygon is self-intersecting, which means the ring of the polygon crosses itself.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html#isSelfIntersecting">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Polygon(
        IReadOnlyList<MapPath> rings,
        SpatialReference? spatialReference = null,
        Point? centroid = null,
        bool? hasM = null,
        bool? hasZ = null,
        bool? isSelfIntersecting = null)
    {
#pragma warning disable BL0005
        Rings = rings;
        SpatialReference = spatialReference;
        Centroid = centroid;
        HasM = hasM;
        HasZ = hasZ;
        IsSelfIntersecting = isSelfIntersecting;
#pragma warning restore BL0005    
    }
    
    
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