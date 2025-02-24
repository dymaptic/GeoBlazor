namespace dymaptic.GeoBlazor.Core.Components;

public partial class Circle
{
   // Add custom code to this file to override generated code
   
   /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="rings">
    ///     An array of rings.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html#rings">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="center">
    ///     The center point of the circle.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Circle.html#center">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="centroid">
    ///     The centroid of the polygon.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polygon.html#centroid">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geodesic">
    ///     Applicable when the spatial reference of the center point is either set to Web Mercator (wkid: 3857) or geographic/geodesic (wkid: 4326).
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Circle.html#geodesic">ArcGIS Maps SDK for JavaScript</a>
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
    /// <param name="numberOfPoints">
    ///     This value defines the number of points along the curve of the circle.
    ///     default 60
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Circle.html#numberOfPoints">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="radius">
    ///     The radius of the circle.
    ///     default 1000
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Circle.html#radius">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="radiusUnit">
    ///     Unit of the radius.
    ///     default meters
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Circle.html#radiusUnit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the geometry.
    ///     default WGS84 (wkid: 4326)
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Geometry.html#spatialReference">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
   [CodeGenerationIgnore] 
   public Circle(
        IReadOnlyList<MapPath> rings,
        Point? center = null,
        Point? centroid = null,
        bool? geodesic = null,
        bool? hasM = null,
        bool? hasZ = null,
        bool? isSelfIntersecting = null,
        double? numberOfPoints = null,
        double? radius = null,
        RadiusUnit? radiusUnit = null,
        SpatialReference? spatialReference = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Rings = rings;
        Center = center;
        Centroid = centroid;
        Geodesic = geodesic;
        HasM = hasM;
        HasZ = hasZ;
        IsSelfIntersecting = isSelfIntersecting;
        NumberOfPoints = numberOfPoints;
        Radius = radius;
        RadiusUnit = radiusUnit;
        SpatialReference = spatialReference;
#pragma warning restore BL0005    
    }
}