namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     A polyline contains an array of paths and spatialReference. Each path is represented as an array of points. A
///     polyline also has boolean-valued hasM and hasZ properties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Polyline : Geometry
{
    /// <summary>
    ///     A parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Polyline()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="paths">
    ///     An array of paths, or line segments, that make up the polyline.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html#paths">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the geometry.
    ///     default WGS84 (wkid: 4326)
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="hasM">
    ///     Indicates if the geometry has M values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasM">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="hasZ">
    ///     Indicates if the geometry has z-values (elevation).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasZ">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Polyline(
        IReadOnlyList<MapPath> paths,
        SpatialReference? spatialReference = null,
        bool? hasM = null,
        bool? hasZ = null)
    {
#pragma warning disable BL0005
        Paths = paths;
        SpatialReference = spatialReference;
        HasM = hasM;
        HasZ = hasZ;
#pragma warning restore BL0005    
    }

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
        return new GeometrySerializationRecord(Type.ToString().ToKebabCase(), 
            Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Paths = Paths.Select(p => p.ToSerializationRecord()).ToArray(),
            HasM = HasM,
            HasZ = HasZ
        };
    }
}