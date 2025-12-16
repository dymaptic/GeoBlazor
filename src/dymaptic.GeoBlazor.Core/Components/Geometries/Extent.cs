namespace dymaptic.GeoBlazor.Core.Components.Geometries;

[ProtobufSerializable]
public partial class Extent : Geometry
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Extent()
    {
    }

    /// <summary>
    ///     Creates a new Extent in code with parameters
    /// </summary>
    /// <param name="xmax">
    ///     The maximum X-coordinate of an extent envelope.
    /// </param>
    /// <param name="xmin">
    ///     The minimum X-coordinate of an extent envelope.
    /// </param>
    /// <param name="ymax">
    ///     The maximum Y-coordinate of an extent envelope.
    /// </param>
    /// <param name="ymin">
    ///     The minimum Y-coordinate of an extent envelope.
    /// </param>
    /// <param name="zmax">
    ///     The maximum possible z, or elevation, value in an extent envelope.
    /// </param>
    /// <param name="zmin">
    ///     The minimum possible z, or elevation, value in an extent envelope.
    /// </param>
    /// <param name="mmax">
    ///     The maximum possible m value in an extent envelope.
    /// </param>
    /// <param name="mmin">
    ///     The minimum possible m value in an extent envelope.
    /// </param>
    /// <param name="spatialReference">
    ///     The <see cref="SpatialReference" /> of the geometry.
    /// </param>
    /// <param name="hasM">
    ///     Indicates if the geometry has M values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasM">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="hasZ">
    ///     Indicates if the geometry has z-values (elevation).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasZ">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Extent(double xmax, double xmin, double ymax, double ymin, double? zmax = null, double? zmin = null,
        double? mmax = null, double? mmin = null, SpatialReference? spatialReference = null, bool? hasM = null,
        bool? hasZ = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Xmax = xmax;
        Xmin = xmin;
        Ymax = ymax;
        Ymin = ymin;
        Zmax = zmax;
        Zmin = zmin;
        Mmax = mmax;
        Mmin = mmin;
        SpatialReference = spatialReference;
        HasM = hasM;
        HasZ = hasZ;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The maximum X-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public double Xmax { get; set; }

    /// <summary>
    ///     The minimum X-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public double Xmin { get; set; }

    /// <summary>
    ///     The maximum Y-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public double Ymax { get; set; }

    /// <summary>
    ///     The minimum Y-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public double Ymin { get; set; }

    /// <summary>
    ///     The maximum possible z, or elevation, value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Zmax { get; set; }

    /// <summary>
    ///     The minimum possible z, or elevation, value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Zmin { get; set; }

    /// <summary>
    ///     The maximum possible m value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Mmax { get; set; }

    /// <summary>
    ///     The minimum possible m value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Mmin { get; set; }

    /// <inheritdoc />
    public override GeometryType Type => GeometryType.Extent;

    /// <summary>
    ///     Returns a deep clone of the geometry.
    /// </summary>
    public Extent Clone()
    {
        return new Extent(Xmax, Xmin, Ymax, Ymin, Zmax, Zmin, Mmax, Mmin, SpatialReference?.Clone());
    }

    /// <inheritdoc />
    public override GeometrySerializationRecord ToProtobuf()
    {
        return new GeometrySerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), null, 
            SpatialReference?.ToProtobuf())
        {
            Xmax = Xmax,
            Xmin = Xmin,
            Ymax = Ymax,
            Ymin = Ymin,
            Zmax = Zmax,
            Zmin = Zmin,
            Mmax = Mmax,
            Mmin = Mmin,
            HasM = HasM,
            HasZ = HasZ
        };
    }
}