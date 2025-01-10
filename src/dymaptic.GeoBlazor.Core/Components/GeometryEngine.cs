// ReSharper disable RedundantEnumerableCastCall
namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     A client-side geometry engine for testing, measuring, and analyzing the spatial relationship between two or more 2D
///     geometries. If more than one geometry is required for any of the methods below, all geometries must have the same
///     spatial reference for the methods to work as expected.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class GeometryEngine : LogicComponent
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    /// <param name="authenticationManager">
    ///     Injected Identity Manager reference
    /// </param>
    public GeometryEngine(AuthenticationManager authenticationManager) : base(authenticationManager)
    {
    }

    /// <inheritdoc/>
    protected override string ComponentName => nameof(GeometryEngine);

    /// <summary>
    ///     Creates planar (or Euclidean) buffer polygons at a specified distance around the input geometries.
    /// </summary>
    /// <remarks>
    ///     The GeometryEngine has two methods for buffering geometries client-side: buffer and geodesicBuffer. Use caution
    ///     when deciding which method to use. As a general rule, use geodesicBuffer if the input geometries have a spatial
    ///     reference of either WGS84 (wkid: 4326) or Web Mercator. Only use buffer (this method) when attempting to buffer
    ///     geometries with a projected coordinate system other than Web Mercator. If you need to buffer geometries with a
    ///     geographic coordinate system other than WGS84 (wkid: 4326), use geometryService.buffer().
    /// </remarks>
    /// <param name="geometries">
    ///     The buffer input geometries.
    /// </param>
    /// <param name="distances">
    ///     The specified distance(s) for buffering. The length of the geometry array does not have to equal the length of the
    ///     distance array. For example, if you pass an array of four geometries: [g1, g2, g3, g4] and an array with one
    ///     distance: [d1], all four geometries will be buffered by the single distance value. If instead you use an array of
    ///     three distances: [d1, d2, d3], g1 will be buffered by d1, g2 by d2, and g3 and g4 will both be buffered by d3. The
    ///     value of the geometry array will be matched one to one with those in the distance array until the final value of
    ///     the distance array is reached, in which case that value will be applied to the remaining geometries.
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the distance(s). Defaults to the units of the input geometries.
    /// </param>
    /// <param name="unionResults">
    ///     Determines whether the output geometries should be unioned into a single polygon.
    /// </param>
    /// <returns>
    ///     The resulting buffers.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Polygon[]> Buffer(IEnumerable<Geometry> geometries, IEnumerable<double> distances, GeometryEngineLinearUnit? unit = null, bool? unionResults = null)
    {
        return await InvokeAsync<Polygon[]>("buffer", geometries, distances, unit, unionResults);
    }

    /// <summary>
    ///     Creates planar (or Euclidean) buffer polygons at a specified distance around the input geometries.
    /// </summary>
    /// <remarks>
    ///     The GeometryEngine has two methods for buffering geometries client-side: buffer and geodesicBuffer. Use caution
    ///     when deciding which method to use. As a general rule, use geodesicBuffer if the input geometries have a spatial
    ///     reference of either WGS84 (wkid: 4326) or Web Mercator. Only use buffer (this method) when attempting to buffer
    ///     geometries with a projected coordinate system other than Web Mercator. If you need to buffer geometries with a
    ///     geographic coordinate system other than WGS84 (wkid: 4326), use geometryService.buffer().
    /// </remarks>
    /// <param name="geometry">
    ///     The buffer input geometries.
    /// </param>
    /// <param name="distance">
    ///     The specified distance(s) for buffering.
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the distance(s). Defaults to the units of the input geometries.
    /// </param>
    /// <returns>
    ///     The resulting buffer.
    /// </returns>
    public async Task<Polygon> Buffer(Geometry geometry, double distance, GeometryEngineLinearUnit? unit = null)
    {
        return await InvokeAsync<Polygon>("buffer", geometry, distance, unit);
    }

    /// <summary>
    ///     Calculates the clipped geometry from a target geometry by an envelope.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to be clipped.
    /// </param>
    /// <param name="extent">
    ///     The envelope used to clip.
    /// </param>
    /// <returns>
    ///     Clipped geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry?> Clip(Geometry geometry, Extent extent)
    {
        return await InvokeAsync<Geometry?>("clip", geometry, extent);
    }

    /// <summary>
    ///     Indicates if one geometry contains another geometry.
    /// </summary>
    /// <param name="containerGeometry">
    ///     The geometry that is tested for the "contains" relationship to the other geometry. Think of this geometry as the
    ///     potential "container" of the insideGeometry.
    /// </param>
    /// <param name="insideGeometry">
    ///     The geometry that is tested for the "within" relationship to the containerGeometry.
    /// </param>
    /// <returns>
    ///     Returns true if the containerGeometry contains the insideGeometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Contains(Geometry containerGeometry, Geometry insideGeometry)
    {
        return await InvokeAsync<bool>("contains", containerGeometry, insideGeometry);
    }

    /// <summary>
    ///     Calculates the convex hull of one or more geometries. A convex hull is the smallest convex polygon that encloses a
    ///     group of geometries or vertices. The input can be a single geometry (such as a polyline) or an array of any
    ///     geometry type. The hull is typically a polygon but can also be a polyline or a point in degenerate cases.
    /// </summary>
    /// <param name="geometries">
    ///     The input geometries used to calculate the convex hull. The input array can include various geometry types.
    /// </param>
    /// <param name="merge">
    ///     Indicates whether to merge the output into a single geometry (usually a polygon).
    /// </param>
    /// <returns>
    ///     Returns the convex hull of the input geometries. This is usually a polygon, but can also be a polyline (if the
    ///     input is a set of points or polylines forming a straight line), or a point (in degenerate cases).
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Geometry[]> ConvexHull(IEnumerable<Geometry> geometries, bool? merge = null)
    {
        return await InvokeAsync<Geometry[]>("convexHull", geometries, merge);
    }

    /// <summary>
    ///     Calculates the convex hull of one or more geometries. A convex hull is the smallest convex polygon that encloses a
    ///     group of geometries or vertices. The input can be a single geometry (such as a polyline) or an array of any
    ///     geometry type. The hull is typically a polygon but can also be a polyline or a point in degenerate cases.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry used to calculate the convex hull.
    /// </param>
    /// <returns>
    ///     Returns the convex hull of the input geometries. This is usually a polygon, but can also be a polyline (if the
    ///     input is a set of points or polylines forming a straight line), or a point (in degenerate cases).
    /// </returns>
    public async Task<Geometry> ConvexHull(Geometry geometry)
    {
        return await InvokeAsync<Geometry>("convexHull", geometry);
    }

    /// <summary>
    ///     Indicates if one geometry crosses another geometry.
    /// </summary>
    /// <param name="geometry1">
    ///     The geometry to cross.
    /// </param>
    /// <param name="geometry2">
    ///     The geometry being crossed.
    /// </param>
    /// <returns>
    ///     Returns true if geometry1 crosses geometry2.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Crosses(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<bool>("crosses", geometry1, geometry2);
    }

    /// <summary>
    ///     Splits the input Polyline or Polygon where it crosses a cutting Polyline. For Polylines, all left cuts are grouped
    ///     together in the first Geometry. Right cuts and coincident cuts are grouped in the second Geometry and each
    ///     undefined cut, along with any uncut parts, are output as separate Polylines. For Polygons, all left cuts are
    ///     grouped in the first Polygon, all right cuts are grouped in the second Polygon, and each undefined cut, along with
    ///     any leftover parts after cutting, are output as a separate Polygon. If no cuts are returned then the array will be
    ///     empty. An undefined cut will only be produced if a left cut or right cut was produced and there was a part left
    ///     over after cutting, or a cut is bounded to the left and right of the cutter.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to be cut.
    /// </param>
    /// <param name="cutter">
    ///     The polyline to cut the geometry.
    /// </param>
    /// <returns>
    ///     Returns an array of geometries created by cutting the input geometry with the cutter.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry[]> Cut(Geometry geometry, Polyline cutter)
    {
        return await InvokeAsync<Geometry[]>("cut", geometry, cutter);
    }

    /// <summary>
    ///     Densify geometries by plotting points between existing vertices.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to be densified.
    /// </param>
    /// <param name="maxSegmentLength">
    ///     The maximum segment length allowed. Must be a positive value.
    /// </param>
    /// <param name="maxSegmentLengthUnit">
    ///     Measurement unit for maxSegmentLength. Defaults to the units of the input geometry.
    /// </param>
    /// <returns>
    ///     The densified geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry> Densify(Geometry geometry, double maxSegmentLength, GeometryEngineLinearUnit? maxSegmentLengthUnit = null)
    {
        return await InvokeAsync<Geometry>("densify", geometry, maxSegmentLength, maxSegmentLengthUnit);
    }

    /// <summary>
    ///     Creates the difference of two geometries. The resultant geometry is the portion of inputGeometry not in the
    ///     subtractor. The dimension of the subtractor has to be equal to or greater than that of the inputGeometry.
    /// </summary>
    /// <param name="geometries">
    ///     The input geometries to subtract from.
    /// </param>
    /// <param name="subtractor">
    ///     The geometry being subtracted from inputGeometry.
    /// </param>
    /// <returns>
    ///     Returns the geometry of inputGeometry minus the subtractor geometry.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Geometry[]> Difference(IEnumerable<Geometry> geometries, Geometry subtractor)
    {
        return await InvokeAsync<Geometry[]>("difference", geometries, subtractor);
    }

    /// <summary>
    ///     Creates the difference of two geometries. The resultant geometry is the portion of inputGeometry not in the
    ///     subtractor. The dimension of the subtractor has to be equal to or greater than that of the inputGeometry.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry to subtract from.
    /// </param>
    /// <param name="subtractor">
    ///     The geometry being subtracted from inputGeometry.
    /// </param>
    /// <returns>
    ///     Returns the geometry of inputGeometry minus the subtractor geometry.
    /// </returns>
    public async Task<Geometry> Difference(Geometry geometry, Geometry subtractor)
    {
        return await InvokeAsync<Geometry>("difference", geometry, subtractor);
    }

    /// <summary>
    ///     Indicates if one geometry is disjoint (doesn't intersect in any way) with another geometry.
    /// </summary>
    /// <param name="geometry1">
    ///     The base geometry that is tested for the "disjoint" relationship to the other geometry.
    /// </param>
    /// <param name="geometry2">
    ///     The comparison geometry that is tested for the "disjoint" relationship to the other geometry.
    /// </param>
    /// <returns>
    ///     Returns true if geometry1 and geometry2 are disjoint (don't intersect in any way).
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Disjoint(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<bool>("disjoint", geometry1, geometry2);
    }

    /// <summary>
    ///     Calculates the shortest planar distance between two geometries. Distance is reported in the linear units specified
    ///     by distanceUnit or, if distanceUnit is null, the units of the spatialReference of input geometry.
    /// </summary>
    /// <param name="geometry1">
    ///     First input geometry.
    /// </param>
    /// <param name="geometry2">
    ///     Second input geometry.
    /// </param>
    /// <param name="distanceUnit">
    ///     Measurement unit of the return value. Defaults to the units of the input geometries.
    /// </param>
    /// <returns>
    ///     Distance between the two input geometries.
    /// </returns>
    [ArcGISMethod]
    public async Task<double> Distance(Geometry geometry1, Geometry geometry2, GeometryEngineLinearUnit? distanceUnit = null)
    {
        return await InvokeAsync<double>("distance", geometry1, geometry2, distanceUnit);
    }

    /// <summary>
    ///     Indicates if two geometries are equal.
    /// </summary>
    /// <remarks>
    ///     In ArcGIS for JS, this method is called `Equals`. However, this term has special meaning in .NET, so we have
    ///     renamed here.
    /// </remarks>
    /// <param name="geometry1">
    ///     First input geometry.
    /// </param>
    /// <param name="geometry2">
    ///     Second input geometry.
    /// </param>
    /// <returns>
    ///     Returns true if the two input geometries are equal.
    /// </returns>
    public async Task<bool> AreEqual(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<bool>("equals", geometry1, geometry2);
    }

    /// <summary>
    ///     Returns an object containing additional information about the input spatial reference.
    /// </summary>
    /// <param name="spatialReference">
    ///     The input spatial reference.
    /// </param>
    /// <returns>
    ///     Resolves to a <see cref = "SpatialReferenceInfo"/> object.
    /// </returns>
    [ArcGISMethod]
    public async Task<SpatialReferenceInfo> ExtendedSpatialReferenceInfo(SpatialReference spatialReference)
    {
        return await InvokeAsync<SpatialReferenceInfo>("extendedSpatialReferenceInfo", spatialReference);
    }

    /// <summary>
    ///     Flips a geometry on the horizontal axis. Can optionally be flipped around a point.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry to be flipped.
    /// </param>
    /// <param name="flipOrigin">
    ///     Point to flip the geometry around. Defaults to the centroid of the geometry.
    /// </param>
    /// <returns>
    ///     The flipped geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry> FlipHorizontal(Geometry geometry, Point? flipOrigin = null)
    {
        return await InvokeAsync<Geometry>("flipHorizontal", geometry, flipOrigin);
    }

    /// <summary>
    ///     Flips a geometry on the vertical axis. Can optionally be flipped around a point.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry to be flipped.
    /// </param>
    /// <param name="flipOrigin">
    ///     Point to flip the geometry around. Defaults to the centroid of the geometry.
    /// </param>
    /// <returns>
    ///     The flipped geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry> FlipVertical(Geometry geometry, Point? flipOrigin = null)
    {
        return await InvokeAsync<Geometry>("flipVertical", geometry, flipOrigin);
    }

    /// <summary>
    ///     Performs the generalize operation on the geometries in the cursor. Point and Multipoint geometries are left
    ///     unchanged. Envelope is converted to a Polygon and then generalized.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry to be generalized.
    /// </param>
    /// <param name="maxDeviation">
    ///     The maximum allowed deviation from the generalized geometry to the original geometry.
    /// </param>
    /// <param name="removeDegenerateParts">
    ///     When true the degenerate parts of the geometry will be removed from the output (may be undesired for drawing).
    /// </param>
    /// <param name="maxDeviationUnit">
    ///     Measurement unit for maxDeviation. Defaults to the units of the input geometry.
    /// </param>
    /// <returns>
    ///     The generalized geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry> Generalize(Geometry geometry, double maxDeviation, bool? removeDegenerateParts = null, GeometryEngineLinearUnit? maxDeviationUnit = null)
    {
        return await InvokeAsync<Geometry>("generalize", geometry, maxDeviation, removeDegenerateParts, maxDeviationUnit);
    }

    /// <summary>
    ///     Calculates the area of the input geometry. As opposed to planarArea(), geodesicArea takes into account the
    ///     curvature of the earth when performing this calculation. Therefore, when using input geometries with a spatial
    ///     reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to calculate areas using
    ///     geodesicArea(). If the input geometries have a projected coordinate system other than Web Mercator, use
    ///     planarArea() instead.
    /// </summary>
    /// <remarks>
    ///     This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references.
    /// </remarks>
    /// <param name="geometry">
    ///     The input polygon
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the return value. Defaults to the units of the input geometries.
    /// </param>
    /// <returns>
    ///     Area of the input geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<double> GeodesicArea(Polygon geometry, GeometryEngineAreaUnit? unit = null)
    {
        return await InvokeAsync<double>("geodesicArea", geometry, unit);
    }

    /// <summary>
    ///     Creates geodesic buffer polygons at a specified distance around the input geometries. When calculating distances,
    ///     this method takes the curvature of the earth into account, which provides highly accurate results when dealing with
    ///     very large geometries and/or geometries that spatially vary on a global scale where one projected coordinate system
    ///     could not accurately plot coordinates and measure distances for all the geometries.
    /// </summary>
    /// <remarks>
    ///     This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references. In general, if your input
    ///     geometries are assigned one of those two spatial references, you should always use geodesicBuffer() to obtain the
    ///     most accurate results for those geometries. If needing to buffer points assigned a projected coordinate system
    ///     other than Web Mercator, use buffer() instead. If the input geometries have a geographic coordinate system other
    ///     than WGS84 (wkid: 4326), use geometryService.buffer().
    /// </remarks>
    /// <param name="geometries">
    ///     The buffer input geometries
    /// </param>
    /// <param name="distances">
    ///     The specified distance(s) for buffering. The length of the geometry array does not have to equal the length of the
    ///     distance array. For example, if you pass an array of four geometries: [g1, g2, g3, g4] and an array with one
    ///     distance: [d1], all four geometries will be buffered by the single distance value. If instead you use an array of
    ///     three distances: [d1, d2, d3], g1 will be buffered by d1, g2 by d2, and g3 and g4 will both be buffered by d3. The
    ///     value of the geometry array will be matched one to one with those in the distance array until the final value of
    ///     the distance array is reached, in which case that value will be applied to the remaining geometries.
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the distance(s). Defaults to the units of the input geometries.
    /// </param>
    /// <param name="unionResults">
    ///     Determines whether the output geometries should be unioned into a single polygon.
    /// </param>
    /// <returns>
    ///     The resulting buffers
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Polygon[]> GeodesicBuffer(IEnumerable<Geometry> geometries, IEnumerable<double> distances, GeometryEngineLinearUnit? unit = null, bool? unionResults = null)
    {
        return await InvokeAsync<Polygon[]>("geodesicBuffer", geometries, distances, unit, unionResults);
    }

    /// <summary>
    ///     Creates geodesic buffer polygons at a specified distance around the input geometries. When calculating distances,
    ///     this method takes the curvature of the earth into account, which provides highly accurate results when dealing with
    ///     very large geometries and/or geometries that spatially vary on a global scale where one projected coordinate system
    ///     could not accurately plot coordinates and measure distances for all the geometries.
    /// </summary>
    /// <remarks>
    ///     This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references. In general, if your input
    ///     geometries are assigned one of those two spatial references, you should always use geodesicBuffer() to obtain the
    ///     most accurate results for those geometries. If needing to buffer points assigned a projected coordinate system
    ///     other than Web Mercator, use buffer() instead. If the input geometries have a geographic coordinate system other
    ///     than WGS84 (wkid: 4326), use geometryService.buffer().
    /// </remarks>
    /// <param name="geometry">
    ///     The buffer input geometru
    /// </param>
    /// <param name="distance">
    ///     The specified distance for buffering.
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the distance. Defaults to the units of the input geometry.
    /// </param>
    /// <returns>
    ///     The resulting buffers
    /// </returns>
    public async Task<Polygon> GeodesicBuffer(Geometry geometry, double distance, GeometryEngineLinearUnit? unit = null)
    {
        return await InvokeAsync<Polygon>("geodesicBuffer", geometry, distance, unit);
    }

    /// <summary>
    ///     Returns a geodesically densified version of the input geometry. Use this function to draw the line(s) of the
    ///     geometry along great circles.
    /// </summary>
    /// <param name="geometry">
    ///     A polyline or polygon to densify.
    /// </param>
    /// <param name="maxSegmentLength">
    ///     The maximum segment length allowed (in meters if a maxSegmentLengthUnit is not provided). This must be a positive
    ///     value.
    /// </param>
    /// <param name="maxSegmentLengthUnit">
    ///     Measurement unit for maxSegmentLength. If not provided, the unit will default to meters.
    /// </param>
    /// <returns>
    ///     Returns the densified geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry> GeodesicDensify(Geometry geometry, double maxSegmentLength, GeometryEngineLinearUnit? maxSegmentLengthUnit = null)
    {
        return await InvokeAsync<Geometry>("geodesicDensify", geometry, maxSegmentLength, maxSegmentLengthUnit);
    }

    /// <summary>
    ///     Calculates the length of the input geometry. As opposed to planarLength(), geodesicLength() takes into account the
    ///     curvature of the earth when performing this calculation. Therefore, when using input geometries with a spatial
    ///     reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to calculate lengths using
    ///     geodesicLength(). If the input geometries have a projected coordinate system other than Web Mercator, use
    ///     planarLength() instead.
    /// </summary>
    /// <remarks>
    ///     This method only works with WGS84 (wkid: 4326) and Web Mercator spatial references.
    /// </remarks>
    /// <param name="geometry">
    ///     The input geometry.
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the return value. Defaults to the units of the input geometry.
    /// </param>
    /// <returns>
    ///     Length of the input geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<double> GeodesicLength(Geometry geometry, GeometryEngineLinearUnit? unit = null)
    {
        return await InvokeAsync<double>("geodesicLength", geometry, unit);
    }

    /// <summary>
    ///     Creates new geometries from the intersections between two geometries. If the input geometries have different
    ///     dimensions (i.e. point = 0; polyline = 1; polygon = 2), then the result's dimension will be equal to the lowest
    ///     dimension of the inputs. The table below describes the expected output for various combinations of geometry types.
    /// </summary>
    /// <param name="geometries1">
    ///     The input array of geometries.
    /// </param>
    /// <param name="geometry2">
    ///     The geometry to intersect with geometries1.
    /// </param>
    /// <returns>
    ///     The intersections of the geometries.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Geometry[]> Intersect(IEnumerable<Geometry> geometries1, Geometry geometry2)
    {
        return await InvokeAsync<Geometry[]>("intersect", geometries1, geometry2);
    }

    /// <summary>
    ///     Creates new geometries from the intersections between two geometries. If the input geometries have different
    ///     dimensions (i.e. point = 0; polyline = 1; polygon = 2), then the result's dimension will be equal to the lowest
    ///     dimension of the inputs.
    /// </summary>
    /// <param name="geometry1">
    ///     The input geometry.
    /// </param>
    /// <param name="geometry2">
    ///     The geometry to intersect with geometry1.
    /// </param>
    /// <returns>
    ///     The intersections of the geometries.
    /// </returns>
    public async Task<Geometry> Intersect(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<Geometry>("intersect", geometry1, geometry2);
    }

    /// <summary>
    ///     Indicates if one geometry intersects another geometry.
    /// </summary>
    /// <param name="geometry1">
    ///     The geometry that is tested for the intersects relationship to the other geometry.
    /// </param>
    /// <param name="geometry2">
    ///     The geometry being intersected.
    /// </param>
    /// <returns>
    ///     Returns true if the input geometries intersect each other.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Intersects(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<bool>("intersects", geometry1, geometry2);
    }

    /// <summary>
    ///     Indicates if the given geometry is topologically simple. In a simplified geometry, no polygon rings or polyline
    ///     paths will overlap, and no self-intersection will occur.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry.
    /// </param>
    /// <returns>
    ///     Returns true if the geometry is topologically simple.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> IsSimple(Geometry geometry)
    {
        return await InvokeAsync<bool>("isSimple", geometry);
    }

    /// <summary>
    ///     Finds the coordinate of the geometry that is closest to the specified point.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to consider.
    /// </param>
    /// <param name="inputPoint">
    ///     The point used to search the nearest coordinate in the geometry.
    /// </param>
    /// <returns>
    ///     Returns an object containing the nearest coordinate.
    /// </returns>
    [ArcGISMethod]
    public async Task<NearestPointResult> NearestCoordinate(Geometry geometry, Point inputPoint)
    {
        return await InvokeAsync<NearestPointResult>("nearestCoordinate", geometry, inputPoint);
    }

    /// <summary>
    ///     Finds the vertex on the geometry nearest to the specified point.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to consider.
    /// </param>
    /// <param name="inputPoint">
    ///     The point used to search the nearest vertex in the geometry.
    /// </param>
    /// <returns>
    ///     Returns an object containing the nearest vertex.
    /// </returns>
    [ArcGISMethod]
    public async Task<NearestPointResult> NearestVertex(Geometry geometry, Point inputPoint)
    {
        return await InvokeAsync<NearestPointResult>("nearestVertex", geometry, inputPoint);
    }

    /// <summary>
    ///     Finds all vertices in the given distance from the specified point, sorted from the closest to the furthest and
    ///     returns them as an array of Objects.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to consider.
    /// </param>
    /// <param name="inputPoint">
    ///     The point from which to measure.
    /// </param>
    /// <param name="searchRadius">
    ///     The distance to search from the inputPoint in the units of the view's spatial reference.
    /// </param>
    /// <param name="maxVertexCountToReturn">
    ///     The maximum number of vertices to return.
    /// </param>
    /// <returns>
    ///     An array of objects containing the nearest vertices within the given searchRadius.
    /// </returns>
    [ArcGISMethod]
    public async Task<NearestPointResult[]> NearestVertices(Geometry geometry, Point inputPoint, double searchRadius, int maxVertexCountToReturn)
    {
        return await InvokeAsync<NearestPointResult[]>("nearestVertices", geometry, inputPoint, searchRadius, maxVertexCountToReturn);
    }

    /// <summary>
    ///     The offset operation creates a geometry that is a constant planar distance from an input polyline or polygon. It is
    ///     similar to buffering, but produces a one-sided result.
    /// </summary>
    /// <param name="geometries">
    ///     The geometries to offset.
    /// </param>
    /// <param name="offsetDistance">
    ///     The planar distance to offset from the input geometry. If offsetDistance > 0, then the offset geometry is
    ///     constructed to the right of the oriented input geometry, if offsetDistance = 0, then there is no change in the
    ///     geometries, otherwise it is constructed to the left. For a simple polygon, the orientation of outer rings is
    ///     clockwise and for inner rings it is counter clockwise. So the "right side" of a simple polygon is always its
    ///     inside.
    /// </param>
    /// <param name="offsetUnit">
    ///     Measurement unit of the offset distance. Defaults to the units of the input geometries.
    /// </param>
    /// <param name="joinType">
    ///     The <see cref = "JoinType"/>
    /// </param>
    /// <param name="bevelRatio">
    ///     Applicable when joinType = 'miter'; bevelRatio is multiplied by the offset distance and the result determines how
    ///     far a mitered offset intersection can be located before it is beveled.
    /// </param>
    /// <param name="flattenError">
    ///     Applicable when joinType = 'round'; flattenError determines the maximum distance of the resulting segments compared
    ///     to the true circular arc. The algorithm never produces more than around 180 vertices for each round join.
    /// </param>
    /// <returns>
    ///     The offset geometries.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Geometry[]> Offset(IEnumerable<Geometry> geometries, double offsetDistance, GeometryEngineLinearUnit? offsetUnit = null, JoinType? joinType = null, double? bevelRatio = null, double? flattenError = null)
    {
        return await InvokeAsync<Geometry[]>("offset", geometries, offsetDistance, offsetUnit, joinType, bevelRatio, flattenError);
    }

    /// <summary>
    ///     The offset operation creates a geometry that is a constant planar distance from an input polyline or polygon. It is
    ///     similar to buffering, but produces a one-sided result.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to offset.
    /// </param>
    /// <param name="offsetDistance">
    ///     The planar distance to offset from the input geometry. If offsetDistance > 0, then the offset geometry is
    ///     constructed to the right of the oriented input geometry, if offsetDistance = 0, then there is no change in the
    ///     geometries, otherwise it is constructed to the left. For a simple polygon, the orientation of outer rings is
    ///     clockwise and for inner rings it is counter clockwise. So the "right side" of a simple polygon is always its
    ///     inside.
    /// </param>
    /// <param name="offsetUnit">
    ///     Measurement unit of the offset distance. Defaults to the units of the input geometries.
    /// </param>
    /// <param name="joinType">
    ///     The <see cref = "JoinType"/>
    /// </param>
    /// <param name="bevelRatio">
    ///     Applicable when joinType = 'miter'; bevelRatio is multiplied by the offset distance and the result determines how
    ///     far a mitered offset intersection can be located before it is beveled.
    /// </param>
    /// <param name="flattenError">
    ///     Applicable when joinType = 'round'; flattenError determines the maximum distance of the resulting segments compared
    ///     to the true circular arc. The algorithm never produces more than around 180 vertices for each round join.
    /// </param>
    /// <returns>
    ///     The offset geometry.
    /// </returns>
    public async Task<Geometry> Offset(Geometry geometry, double offsetDistance, GeometryEngineLinearUnit? offsetUnit = null, JoinType? joinType = null, double? bevelRatio = null, double? flattenError = null)
    {
        return await InvokeAsync<Geometry>("offset", geometry, offsetDistance, offsetUnit, joinType, bevelRatio, flattenError);
    }

    /// <summary>
    ///     Indicates if one geometry overlaps another geometry.
    /// </summary>
    /// <param name="geometry1">
    ///     The base geometry that is tested for the "overlaps" relationship with the other geometry.
    /// </param>
    /// <param name="geometry2">
    ///     The comparison geometry that is tested for the "overlaps" relationship with the other geometry.
    /// </param>
    /// <returns>
    ///     Returns true if the two geometries overlap.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Overlaps(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<bool>("overlaps", geometry1, geometry2);
    }

    /// <summary>
    ///     Calculates the area of the input geometry. As opposed to geodesicArea(), planarArea() performs this calculation
    ///     using projected coordinates and does not take into account the earth's curvature. When using input geometries with
    ///     a spatial reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to calculate areas using
    ///     geodesicArea(). If the input geometries have a projected coordinate system other than Web Mercator, use
    ///     planarArea() instead.
    /// </summary>
    /// <param name="geometry">
    ///     The input polygon.
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the return value. Defaults to the units of the input geometries.
    /// </param>
    /// <returns>
    ///     The area of the input geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<double> PlanarArea(Polygon geometry, GeometryEngineAreaUnit? unit = null)
    {
        return await InvokeAsync<double>("planarArea", geometry, unit);
    }

    /// <summary>
    ///     Calculates the length of the input geometry. As opposed to geodesicLength(), planarLength() uses projected
    ///     coordinates and does not take into account the curvature of the earth when performing this calculation. When using
    ///     input geometries with a spatial reference of either WGS84 (wkid: 4326) or Web Mercator, it is best practice to
    ///     calculate lengths using geodesicLength(). If the input geometries have a projected coordinate system other than Web
    ///     Mercator, use planarLength() instead.
    /// </summary>
    /// <param name="geometry">
    ///     The input geometry.
    /// </param>
    /// <param name="unit">
    ///     Measurement unit of the return value. Defaults to the units of the input geometries.
    /// </param>
    /// <returns>
    ///     The length of the input geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<double> PlanarLength(Geometry geometry, GeometryEngineLinearUnit? unit = null)
    {
        return await InvokeAsync<double>("planarLength", geometry, unit);
    }

    /// <summary>
    ///     Indicates if the given DE-9IM relation is true for the two geometries.
    /// </summary>
    /// <param name="geometry1">
    ///     The first geometry for the relation.
    /// </param>
    /// <param name="geometry2">
    ///     The second geometry for the relation.
    /// </param>
    /// <param name="relation">
    ///     The Dimensionally Extended 9 Intersection Model (DE-9IM) matrix relation (encoded as a string) to test against the
    ///     relationship of the two geometries. This string contains the test result of each intersection represented in the
    ///     DE-9IM matrix. Each result is one character of the string and may be represented as either a number (maximum
    ///     dimension returned: 0,1,2), a Boolean value (T or F), or a mask character (for ignoring results: '*'). For example,
    ///     each of the following DE-9IM string codes are valid for testing whether a polygon geometry completely contains a
    ///     line geometry: TTTFFTFFT (Boolean), 'T******FF*' (ignore irrelevant intersections), or '102FF*FF*' (dimension
    ///     form). Each returns the same result. See
    ///     <a target="_blank" href="https://en.wikipedia.org/wiki/DE-9IM">this article</a> and
    ///     <a target="_blank" href="https://desktop.arcgis.com/en/arcmap/latest/manage-data/using-sql-with-gdbs/relational-functions-for-st-geometry.htm">
    ///         this
    ///         ArcGIS help page
    ///     </a>
    ///     for more information about the DE-9IM model and how string codes are constructed.
    /// </param>
    /// <returns>
    ///     Returns true if the relation of the input geometries is accurate.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Relate(Geometry geometry1, Geometry geometry2, string relation)
    {
        return await InvokeAsync<bool>("relate", geometry1, geometry2, relation);
    }

    /// <summary>
    ///     Rotates a geometry counterclockwise by the specified number of degrees. Rotation is around the centroid, or a given
    ///     rotation point.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to rotate.
    /// </param>
    /// <param name="angle">
    ///     The rotation angle in degrees.
    /// </param>
    /// <param name="rotationOrigin">
    ///     Point to rotate the geometry around. Defaults to the centroid of the geometry.
    /// </param>
    /// <returns>
    ///     The rotated geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry> Rotate(Geometry geometry, double angle, Point rotationOrigin)
    {
        return await InvokeAsync<Geometry>("rotate", geometry, angle, rotationOrigin);
    }

    /// <summary>
    ///     Performs the simplify operation on the geometry, which alters the given geometries to make their definitions
    ///     topologically legal with respect to their geometry type. At the end of a simplify operation, no polygon rings or
    ///     polyline paths will overlap, and no self-intersection will occur.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to be simplified.
    /// </param>
    /// <returns>
    ///     The simplified geometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<Geometry> Simplify(Geometry geometry)
    {
        return await InvokeAsync<Geometry>("simplify", geometry);
    }

    /// <summary>
    ///     Creates the symmetric difference of two geometries. The symmetric difference includes the parts that are in either
    ///     of the sets, but not in both.
    /// </summary>
    /// <param name="leftGeometries">
    ///     One of the Geometry instances in the XOR operation.
    /// </param>
    /// <param name="rightGeometry">
    ///     One of the Geometry instances in the XOR operation.
    /// </param>
    /// <returns>
    ///     The symmetric differences of the two geometries.
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Geometry[]> SymmetricDifference(IEnumerable<Geometry> leftGeometries, Geometry rightGeometry)
    {
        return await InvokeAsync<Geometry[]>("symmetricDifference", leftGeometries, rightGeometry);
    }

    /// <summary>
    ///     Creates the symmetric difference of two geometries. The symmetric difference includes the parts that are in either
    ///     of the sets, but not in both.
    /// </summary>
    /// <param name="leftGeometry">
    ///     One of the Geometry instances in the XOR operation.
    /// </param>
    /// <param name="rightGeometry">
    ///     One of the Geometry instances in the XOR operation.
    /// </param>
    /// <returns>
    ///     The symmetric differences of the two geometries.
    /// </returns>
    public async Task<Geometry> SymmetricDifference(Geometry leftGeometry, Geometry rightGeometry)
    {
        return await InvokeAsync<Geometry>("symmetricDifference", leftGeometry, rightGeometry);
    }

    /// <summary>
    ///     Indicates if one geometry touches another geometry.
    /// </summary>
    /// <param name="geometry1">
    ///     The geometry to test the "touches" relationship with the other geometry.
    /// </param>
    /// <param name="geometry2">
    ///     The geometry to be touched.
    /// </param>
    /// <returns>
    ///     When true, geometry1 touches geometry2.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Touches(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<bool>("touches", geometry1, geometry2);
    }

    /// <summary>
    ///     All inputs must be of the same type of geometries and share one spatial reference.
    /// </summary>
    /// <param name="geometries">
    ///     An array of Geometries to union.
    /// </param>
    /// <returns>
    ///     The union of the geometries
    /// </returns>
    [CodeGenerationIgnore]
    public async Task<Geometry> Union(params Geometry[] geometries)
    {
        return await InvokeAsync<Geometry>("union", geometries.Cast<object>());
    }

    /// <summary>
    ///     All inputs must be of the same type of geometries and share one spatial reference.
    /// </summary>
    /// <param name="geometries">
    ///     An array of Geometries to union.
    /// </param>
    /// <returns>
    ///     The union of the geometries
    /// </returns>
    public async Task<Geometry> Union(IEnumerable<Geometry> geometries)
    {
        return await InvokeAsync<Geometry>("union", geometries.Cast<object>());
    }

    /// <summary>
    ///     Indicates if one geometry is within another geometry.
    /// </summary>
    /// <param name="innerGeometry">
    ///     The base geometry that is tested for the "within" relationship to the other geometry.
    /// </param>
    /// <param name="outerGeometry">
    ///     The comparison geometry that is tested for the "contains" relationship to the other geometry.
    /// </param>
    /// <returns>
    ///     Returns true if innerGeometry is within outerGeometry.
    /// </returns>
    [ArcGISMethod]
    public async Task<bool> Within(Geometry innerGeometry, Geometry outerGeometry)
    {
        return await InvokeAsync<bool>("within", innerGeometry, outerGeometry);
    }

    /// <summary>
    ///     Creates a new instance of this class and initializes it with values from a JSON object generated from an ArcGIS product. The object passed into the input json parameter often comes from a response to a query operation in the REST API or a toJSON() method from another ArcGIS product. See the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/programming-patterns/#using-fromjson">Using fromJSON()</a> topic in the Guide for details and examples of when and how to use this function.
    /// </summary>
    /// <param name="json">
    ///     A JSON representation of the instance in the ArcGIS format. See the <a target="_blank" href="https://developers.arcgis.com/documentation/common-data-types/overview-of-common-data-types.htm">ArcGIS REST API documentation</a> for examples of the structure of various input JSON objects.
    /// </param>
    /// <returns>
    ///     Returns a new geometry instance.
    /// </returns>
    public async Task<T> FromArcGisJson<T>(string json)
        where T : Geometry
    {
        return await InvokeAsync<T>("fromJSON", json, typeof(T).Name);
    }

    /// <summary>
    ///     Converts an instance of this class to its ArcGIS portal JSON representation. See the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/programming-patterns/#using-fromjson">Using fromJSON()</a> guide topic for more information.
    /// </summary>
    /// <param name="geometry">
    ///     The geometry to convert.
    /// </param>
    /// <returns>
    ///     The <a target="_blank" href="https://developers.arcgis.com/documentation/common-data-types/geometry-objects.htm">ArcGIS portal JSON</a> representation of an instance of this class.
    /// </returns>
    public async Task<string> ToArcGisJson<T>(T geometry)
        where T : Geometry
    {
        return await InvokeAsync<string>("toJSON", geometry);
    }

    /// <summary>
    ///     Creates a deep clone of the geometry.
    /// </summary>
    /// <remarks>
    ///     Unlike the Clone methods in the Geometry classes, this method does a loop through the ArcGIS JS SDK. Therefore, if you are having issues with unpopulated fields in the geometry, try using this method instead.
    /// </remarks>
    public async Task<T> Clone<T>(T geometry)
        where T : Geometry
    {
        return await InvokeAsync<T>("clone", geometry);
    }

    /// <summary>
    ///     Centers the given extent to the given point, and returns a new extent.
    /// </summary>
    /// <param name="extent">
    ///     The input extent.
    /// </param>
    /// <param name="point">
    ///     The point to center the extent on.
    /// </param>
    /// <returns>
    ///     The centered extent.
    /// </returns>
    public async Task<Extent> CenterExtentAt(Extent extent, Point point)
    {
        return await InvokeAsync<Extent>("centerExtentAt", extent, point);
    }

    /// <summary>
    ///     Expands the extent by the given factor. For example, a value of 1.5 will expand the extent to be 50 percent larger than the original extent.
    /// </summary>
    /// <param name="extent">
    ///     The input extent.
    /// </param>
    /// <param name="factor">
    ///     The factor by which to expand the extent.
    /// </param>
    /// <returns>
    ///     The expanded extent.
    /// </returns>
    public async Task<Extent> Expand(Extent extent, double factor)
    {
        return await InvokeAsync<Extent>("expand", extent, factor);
    }

    /// <summary>
    ///     Returns an array with either one Extent that's been shifted to within +/- 180 or two Extents if the original extent intersects the International Dateline.
    /// </summary>
    /// <param name="extent">
    ///     The input extent.
    /// </param>
    /// <returns>
    ///     An array with either one Extent that's been shifted to within +/- 180 or two Extents if the original extent intersects the International Dateline.
    /// </returns>
    public async Task<Extent[]> NormalizeExtent(Extent extent)
    {
        return await InvokeAsync<Extent[]>("normalizeExtent", extent);
    }

    /// <summary>
    ///     Modifies the extent geometry in-place with X and Y offsets in map units.
    /// </summary>
    /// <param name="extent">
    ///     The input extent.
    /// </param>
    /// <param name="dx">
    ///     The offset distance in map units for the X-coordinate.
    /// </param>
    /// <param name="dy">
    ///     The offset distance in map units for the Y-coordinate.
    /// </param>
    /// <param name="dz">
    ///     The offset distance in map units for the Z-coordinate.
    /// </param>
    /// <returns></returns>
    public async Task<Extent> OffsetExtent(Extent extent, double dx, double dy, double dz = 0)
    {
        return await InvokeAsync<Extent>("offsetExtent", extent, dx, dy, dz);
    }

    /// <summary>
    ///     Modifies the point geometry in-place by shifting the X-coordinate to within +/- 180 span in map units.
    /// </summary>
    /// <param name="point">
    ///     The input point.
    /// </param>
    /// <returns>
    ///     Returns a point with a normalized x-value.
    /// </returns>
    public async Task<Point> NormalizePoint(Point point)
    {
        return await InvokeAsync<Point>("normalizePoint", point);
    }

    /// <summary>
    ///     Adds a path, or line segment, to the polyline. When added, the index of the path is incremented by one.
    /// </summary>
    /// <param name="polyline">
    ///     The polyline to add the path to. Will return a new modified copy.
    /// </param>
    /// <param name="points">
    ///     The polyline path to add as a <see cref = "MapPath"/>.
    /// </param>
    /// <returns>
    ///     Returns a new polyline with the added path.
    /// </returns>
    public async Task<Polyline> AddPath(Polyline polyline, MapPath points)
    {
        return await InvokeAsync<Polyline>("addPath", polyline, points);
    }

    /// <summary>
    ///     Adds a path, or line segment, to the polyline. When added, the index of the path is incremented by one.
    /// </summary>
    /// <param name="polyline">
    ///     The polyline to add the path to. Will return a new modified copy.
    /// </param>
    /// <param name="points">
    ///     The polyline path to add as an array of <see cref = "Point"/>s.
    /// </param>
    /// <returns>
    ///     Returns a new polyline with the added path.
    /// </returns>
    public async Task<Polyline> AddPath(Polyline polyline, Point[] points)
    {
        var mapPoints = new List<MapPoint>();
        foreach (Point p in points)
        {
            mapPoints.Add(new MapPoint(p.X!.Value, p.Y!.Value));
        }

        return await AddPath(polyline, new MapPath(mapPoints));
    }

    /// <summary>
    ///     Returns a point specified by a path and point in the path.
    /// </summary>
    /// <param name="polyline">
    ///     The polyline to get the point from.
    /// </param>
    /// <param name="pathIndex">
    ///     The index of the path in the polyline.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the point in the path.
    /// </param>
    /// <returns>
    ///     Returns the point along the Polyline located in the given path and point indices.
    /// </returns>
    public async Task<Point> GetPoint(Polyline polyline, int pathIndex, int pointIndex)
    {
        return await InvokeAsync<Point>("getPointOnPolyline", polyline, pathIndex, pointIndex);
    }

    /// <summary>
    ///     Inserts a new point into a polyline and returns the modified line.
    /// </summary>
    /// <param name="polyline">
    ///     The polyline to insert the point into.
    /// </param>
    /// <param name="pathIndex">
    ///     The index of the path in which to insert a point.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the inserted point in the path.
    /// </param>
    /// <param name="point">
    ///     The point to insert into the polyline.
    /// </param>
    /// <returns>
    ///     Returns a new polyline with the inserted point.
    /// </returns>
    public async Task<Polyline> InsertPoint(Polyline polyline, int pathIndex, int pointIndex, Point point)
    {
        return await InvokeAsync<Polyline>("insertPointOnPolyline", polyline, pathIndex, pointIndex, point);
    }

    /// <summary>
    ///     Removes a path from the Polyline. The index specifies which path to remove.
    /// </summary>
    /// <param name="polyline">
    ///     The polyline to remove the path from.
    /// </param>
    /// <param name="index">
    ///     The index of the path to remove.
    /// </param>
    /// <returns>
    ///     Returns an object with the modified polyline and the removed path.
    /// </returns>
    public async Task<(Polyline PolyLine, Point[] Path)> RemovePath(Polyline polyline, int index)
    {
        return await InvokeAsync<(Polyline PolyLine, Point[] Path)>("removePath", polyline, index);
    }

    /// <summary>
    ///     Removes a point from the polyline at the given pointIndex within the path identified by the given pathIndex.
    /// </summary>
    /// <param name="polyline">
    ///     The polyline to remove the point from.
    /// </param>
    /// <param name="pathIndex">
    ///     The index of the path in which to remove a point.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the point in the path to remove.
    /// </param>
    /// <returns>
    ///     Returns an object with the modified polyline and the removed point.
    /// </returns>
    public async Task<(Polyline PolyLine, Point Point)> RemovePoint(Polyline polyline, int pathIndex, int pointIndex)
    {
        return await InvokeAsync<(Polyline PolyLine, Point Point)>("removePointOnPolyline", polyline, pathIndex, pointIndex);
    }

    /// <summary>
    ///     Updates a point in a polyline and returns the modified polyline.
    /// </summary>
    /// <param name="polyline">
    ///     The polyline to update the point in.
    /// </param>
    /// <param name="pathIndex">
    ///     The index of the path in which to update a point.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the point in the path to update.
    /// </param>
    /// <param name="point">
    ///     The new point to update the polyline with.
    /// </param>
    /// <returns>
    ///     Returns a new polyline with the updated point.
    /// </returns>
    public async Task<Polyline> SetPoint(Polyline polyline, int pathIndex, int pointIndex, Point point)
    {
        return await InvokeAsync<Polyline>("setPointOnPolyline", polyline, pathIndex, pointIndex, point);
    }

    /// <summary>
    ///     Adds a ring to the Polygon. The ring can be one of the following: an array of numbers or an array of points. When added the index of the ring is incremented by one.
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to add the ring to.
    /// </param>
    /// <param name="points">
    ///     A polygon ring. The first and last coordinates/points in the ring must be the same.
    /// </param>
    /// <returns>
    ///     Returns a new polygon with the added ring.
    /// </returns>
    public async Task<Polygon> AddRing(Polygon polygon, MapPath points)
    {
        return await InvokeAsync<Polygon>("addRing", polygon, points);
    }

    /// <summary>
    ///     Adds a ring to the Polygon. The ring can be one of the following: an array of numbers or an array of points. When added the index of the ring is incremented by one.
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to add the ring to.
    /// </param>
    /// <param name="points">
    ///     A polygon ring. The first and last coordinates/points in the ring must be the same.
    /// </param>
    /// <returns>
    ///     Returns a new polygon with the added ring.
    /// </returns>
    public async Task<Polygon> AddRing(Polygon polygon, Point[] points)
    {
        var mapPoints = new List<MapPoint>();
        foreach (Point p in points)
        {
            mapPoints.Add(new MapPoint(p.X!.Value, p.Y!.Value));
        }

        return await AddRing(polygon, new MapPath(mapPoints));
    }

    /// <summary>
    ///     Converts the given Extent to a Polygon instance. This is useful for scenarios in which you would like to display an area of interest, which is typically defined by an Extent or bounding box, as a polygon with a fill symbol in the view. Some geoprocessing tools require input geometries to be of a Polygon type and not an Extent.
    /// </summary>
    /// <param name="extent">
    ///     An extent object to convert to a polygon.
    /// </param>
    /// <returns>
    ///     A polygon instance representing the given extent.
    /// </returns>
    public async Task<Polygon> PolygonFromExtent(Extent extent)
    {
        return await InvokeAsync<Polygon>("fromExtent", extent);
    }

    /// <summary>
    ///     Returns a point specified by a ring and point in the ring.
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to get the point from.
    /// </param>
    /// <param name="ringIndex">
    ///     The index of the ring containing the desired point.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the desired point within the ring.
    /// </param>
    /// <returns>
    ///     Returns the point at the specified ring index and point index.
    /// </returns>
    public async Task<Point> GetPoint(Polygon polygon, int ringIndex, int pointIndex)
    {
        return await InvokeAsync<Point>("getPointOnPolygon", polygon, ringIndex, pointIndex);
    }

    /// <summary>
    ///     Inserts a new point into the polygon.
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to insert the point into.
    /// </param>
    /// <param name="ringIndex">
    ///     The index of the ring in which to insert the point.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the point to insert within the ring.
    /// </param>
    /// <param name="point">
    ///     The point to insert into the polygon.
    /// </param>
    /// <returns>
    ///     Returns a new polygon with the inserted point.
    /// </returns>
    public async Task<Polygon> InsertPoint(Polygon polygon, int ringIndex, int pointIndex, Point point)
    {
        return await InvokeAsync<Polygon>("insertPointOnPolygon", polygon, ringIndex, pointIndex, point);
    }

    /// <summary>
    ///     Checks if a Polygon ring is clockwise
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to check the ring on.
    /// </param>
    /// <param name="ring">
    ///     A polygon ring defined as a <see cref = "MapPath"/>. The first and last coordinates/points in the ring must be the same.
    /// </param>
    /// <returns>
    ///     Returns true if the ring is clockwise and false for counterclockwise.
    /// </returns>
    public async Task<bool> IsClockwise(Polygon polygon, MapPath ring)
    {
        return await InvokeAsync<bool>("isClockwise", polygon, ring);
    }

    /// <summary>
    ///     Checks if a Polygon ring is clockwise
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to check the ring on.
    /// </param>
    /// <param name="ring">
    ///     A polygon ring defined as an array of <see cref = "Point"/>s. The first and last coordinates/points in the ring must be the same.
    /// </param>
    /// <returns>
    ///     Returns true if the ring is clockwise and false for counterclockwise.
    /// </returns>
    public async Task<bool> IsClockwise(Polygon polygon, Point[] ring)
    {
        var mapPoints = new List<MapPoint>();
        foreach (Point p in ring)
        {
            mapPoints.Add(new MapPoint(p.X!.Value, p.Y!.Value));
        }

        return await IsClockwise(polygon, new MapPath(mapPoints));
    }

    /// <summary>
    ///     Removes a point from the polygon at the given pointIndex within the ring identified by the given ringIndex.
    /// </summary>
    /// <param name="polygon">
    ///     The polyline to remove the point from.
    /// </param>
    /// <param name="ringIndex">
    ///     The index of the ring containing the point to remove.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the point to remove within the ring.
    /// </param>
    /// <returns>
    ///     Returns an object with the modified polygon and the removed point.
    /// </returns>
    public async Task<(Polygon Polygon, Point Point)> RemovePoint(Polygon polygon, int ringIndex, int pointIndex)
    {
        return await InvokeAsync<(Polygon Polygon, Point Point)>("removePointOnPolygon", polygon, ringIndex, pointIndex);
    }

    /// <summary>
    ///     Removes a ring from the Polygon. The index specifies which ring to remove.
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to remove the ring from.
    /// </param>
    /// <param name="index">
    ///     The index of the ring to remove.
    /// </param>
    /// <returns>
    ///     Returns an object with the modified polygon and the removed ring.
    /// </returns>
    public async Task<(Polygon Polygon, Point[] Ring)> RemoveRing(Polygon polygon, int index)
    {
        return await InvokeAsync<(Polygon Polygon, Point[] Ring)>("removeRing", polygon, index);
    }

    /// <summary>
    ///     Updates a point in a polygon and returns the modified polygon.
    /// </summary>
    /// <param name="polygon">
    ///     The polygon to update the point in.
    /// </param>
    /// <param name="ringIndex">
    ///     The index of the ring containing the point to update.
    /// </param>
    /// <param name="pointIndex">
    ///     The index of the point to update within the ring.
    /// </param>
    /// <param name="point">
    ///     The new point to update the polygon with.
    /// </param>
    /// <returns>
    ///     Returns a new polygon with the updated point.
    /// </returns>
    public async Task<Polygon> SetPoint(Polygon polygon, int ringIndex, int pointIndex, Point point)
    {
        return await InvokeAsync<Polygon>("setPointOnPolygon", polygon, ringIndex, pointIndex, point);
    }

    /// <summary>
    ///     Retrieves the center point of the extent in map units.
    /// </summary>
    public async Task<Point?> GetExtentCenter(Extent extent)
    {
        return await InvokeAsync<Point?>("getExtentCenter", extent);
    }

    /// <summary>
    ///     Retrieves the height of the extent in map units (the distance between ymin and ymax).
    /// </summary>
    public async Task<double?> GetExtentHeight(Extent extent)
    {
        return await InvokeAsync<double?>("getExtentHeight", extent);
    }

    /// <summary>
    ///     Retrieves the width of the extent in map units (the distance between xmin and xmax).
    /// </summary>
    public async Task<double?> GetExtentWidth(Extent extent)
    {
        return await InvokeAsync<double?>("getExtentWidth", extent);
    }
}