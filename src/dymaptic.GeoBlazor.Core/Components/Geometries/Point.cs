namespace dymaptic.GeoBlazor.Core.Components.Geometries;

[ProtobufSerializable]
public partial class Point : Geometry
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public Point()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="longitude">
    ///     The longitude of the point.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html#longitude">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="latitude">
    ///     The latitude of the point.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html#latitude">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="x">
    ///     The x-coordinate (easting) of the point in map units.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html#x">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="y">
    ///     The y-coordinate (northing) of the point in map units.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html#y">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="z">
    ///     The z-coordinate (or elevation) of the point in map units.
    ///     default undefined
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html#z">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the geometry.
    ///     default SpatialReference.WGS84 // wkid: 4326
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
    /// <param name="m">
    ///     The m-coordinate of the point in map units.
    ///     default undefined
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html#m">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public Point(double? longitude = null,
        double? latitude = null,
        double? x = null,
        double? y = null,
        double? z = null,
        SpatialReference? spatialReference = null,
        bool? hasM = null,
        bool? hasZ = null,
        double? m = null)
    {
        AllowRender = false;

        if (x is null && longitude is null || y is null && latitude is null)
        {
            throw new ArgumentException("Points must have X and Y coordinates or longitude and latitude.");
        }

        if (x is null && y is null && spatialReference is { Wkid: not 4326 })
        {
        }

#pragma warning disable BL0005
        Longitude = longitude;
        Latitude = latitude;
        X = x;
        Y = y;
        Z = z;
        SpatialReference = spatialReference;
        HasM = hasM;
        HasZ = hasZ;
        M = m;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The latitude of the point.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Latitude { get; set; }

    /// <summary>
    ///     The longitude of the point.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Longitude { get; set; }

    /// <summary>
    ///     The x-coordinate (easting) of the point in map units.
    /// </summary>
    [Parameter]
    public double? X { get; set; }

    /// <summary>
    ///     The y-coordinate (northing) of the point in map units.
    /// </summary>
    [Parameter]
    public double? Y { get; set; }

    /// <summary>
    ///     The z-coordinate (or elevation) of the point in map units.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Z { get; set; }

    /// <summary>
    ///     The m-coordinate of the point in map units.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? M { get; set; }

    /// <summary>
    ///     Is Simple based on the ArcGIS simplify operator. Indicates if the given geometry is non-OGC topologically simple. This operation takes into account z-values.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-operators-simplifyOperator.html#isSimple">ArcGIS Maps SDK for JavaScript</a>
    ///     Point geometries are always simple.
    /// </summary>
    [ArcGISProperty]
    [CodeGenerationIgnore]
    public override bool? IsSimple { get; internal set; } = true;

    /// <inheritdoc />
    public override GeometryType Type => GeometryType.Point;

    /// <summary>
    ///     Returns a deep clone of the geometry.
    /// </summary>
    public Point Clone()
    {
        return new Point(Longitude, Latitude, X, Y, Z, SpatialReference?.Clone(), HasM, HasZ, M);
    }

    /// <inheritdoc />
    public override GeometrySerializationRecord ToProtobuf()
    {
        return new GeometrySerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(),
            Extent?.ToProtobuf(),
            SpatialReference?.ToProtobuf())
        {
            Longitude = Longitude,
            Latitude = Latitude,
            X = X,
            Y = Y,
            Z = Z,
            HasM = HasM,
            HasZ = HasZ,
            M = M
        };
    }
}