using dymaptic.GeoBlazor.Core.Objects;


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
    public Polyline()
    {
    }

    /// <summary>
    ///     Creates a new PolyLine in code with parameters
    /// </summary>
    /// <param name="paths">
    ///     An array of <see cref="MapPath" /> paths, or line segments, that make up the polyline.
    /// </param>
    /// <param name="spatialReference">
    ///     The <see cref="SpatialReference" /> of the geometry.
    /// </param>
    /// <param name="extent">
    ///     The <see cref="Extent" /> of the geometry.
    /// </param>
    public Polyline(IReadOnlyList<MapPath> paths, SpatialReference? spatialReference = null,
        Extent? extent = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Paths = paths;
        SpatialReference = spatialReference;
        Extent = extent;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     An array of <see cref="MapPath" /> paths, or line segments, that make up the polyline.
    /// </summary>
    [Parameter]
    public IReadOnlyList<MapPath> Paths { get; set; } = [];

    /// <inheritdoc />
    public override string Type => "polyline";

    /// <summary>
    ///     Returns a deep clone of the geometry.
    /// </summary>
    public Polyline Clone()
    {
        return new Polyline(Paths.Select(p => p.Clone()).ToArray(), SpatialReference?.Clone(), Extent?.Clone());
    }
    
    internal override GeometrySerializationRecord ToSerializationRecord()
    {
        return new GeometrySerializationRecord(Type, Extent?.ToSerializationRecord(),
            SpatialReference?.ToSerializationRecord())
        {
            Paths = Paths.Select(p => p.ToSerializationRecord()).ToArray()
        };
    }
}