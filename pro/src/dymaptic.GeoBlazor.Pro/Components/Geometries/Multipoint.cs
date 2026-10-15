namespace dymaptic.GeoBlazor.Pro.Components.Geometries;

public partial class Multipoint
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     Parameterless constructor for use as a Razor Component.
   /// </summary>
   [ActivatorUtilitiesConstructor]
   [CodeGenerationIgnore]
   public Multipoint()
   {
   }

   /// <summary>
   ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
   /// </summary>
   /// <param name="hasM">
   ///     Indicates if the geometry has M values.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasM">ArcGIS Maps SDK for JavaScript</a>
   /// </param>
   /// <param name="hasZ">
   ///     Indicates if the geometry has z-values (elevation).
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#hasZ">ArcGIS Maps SDK for JavaScript</a>
   /// </param>
   /// <param name="points">
   ///     An array of points.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Multipoint.html#points">ArcGIS Maps SDK for JavaScript</a>
   /// </param>
   /// <param name="spatialReference">
   ///     The spatial reference of the geometry.
   ///     default SpatialReference.WGS84 // wkid: 4326
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
   /// </param>
   [CodeGenerationIgnore]
   public Multipoint(
       bool? hasM = null,
       bool? hasZ = null,
       IReadOnlyList<Point>? points = null,
       SpatialReference? spatialReference = null)
   {
       AllowRender = false;
#pragma warning disable BL0005
       HasM = hasM;
       HasZ = hasZ;
       Points = points;
       SpatialReference = spatialReference;
#pragma warning restore BL0005
   }
   
   /// <summary>
   ///     Is Simple based on the ArcGIS simplify operator. Indicates if the given geometry is non-OGC topologically simple. This operation takes into account z-values.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-operators-simplifyOperator.html#isSimple">ArcGIS Maps SDK for JavaScript</a>
   ///     Multipoint geometries cannot have any points with exactly equal x and y. The tolerance is not taken into account.
   /// </summary>
   [ArcGISProperty]
   [CodeGenerationIgnore]
   public override bool? IsSimple { get; internal set; }
   
   internal override GeometrySerializationRecord ToSerializationRecord()
   {
       return new GeometrySerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(),
           Extent?.ToSerializationRecord(), SpatialReference?.ToSerializationRecord())
       {
           Points = Points?
               .Select(p => new MapPointSerializationRecord(
                   [p.X ?? p.Longitude!.Value, p.Y ?? p.Latitude!.Value]))
               .ToArray(),
       };
   }
}