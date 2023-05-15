using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


// ReSharper disable RedundantEnumerableCastCall

namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A client-side geometry engine for testing, measuring, and analyzing the spatial relationship between two or more 2D
///     geometries. If more than one geometry is required for any of the methods below, all geometries must have the same
///     spatial reference for the methods to work as expected.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-geometryEngine.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class GeometryEngine : LogicComponent
{
    /// <summary>
    ///     Default Constructor
    /// </summary>
    /// <param name="jsRuntime">
    ///     Injected JavaScript Runtime reference
    /// </param>
    /// <param name="authenticationManager">
    ///     Injected Identity Manager reference
    /// </param>
    public GeometryEngine(IJSRuntime jsRuntime, AuthenticationManager authenticationManager) : base(jsRuntime, authenticationManager)
    {
    }

    /// <inheritdoc />
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
    public async Task<Polygon[]> Buffer(IEnumerable<Geometry> geometries, IEnumerable<double> distances,
        LinearUnit? unit = null, bool? unionResults = null)
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
    public async Task<Polygon> Buffer(Geometry geometry, double distance, LinearUnit? unit = null)
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
    public async Task<Geometry[]> Cut(Geometry geometry, PolyLine cutter)
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
    public async Task<Geometry> Densify(Geometry geometry, double maxSegmentLength,
        LinearUnit? maxSegmentLengthUnit = null)
    {
        return await InvokeAsync<Geometry>("densify", geometry, maxSegmentLength,
            maxSegmentLengthUnit);
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
    public async Task<bool> Disjoint(Geometry geometry1, Geometry geometry2)
    {
        return await InvokeAsync<bool>("disjoint",
            geometry1, geometry2);
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
    public async Task<double> Distance(Geometry geometry1, Geometry geometry2, LinearUnit? distanceUnit = null)
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
    ///     Resolves to a <see cref="SpatialReferenceInfo" /> object.
    /// </returns>
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
    public async Task<Geometry> Generalize(Geometry geometry, double maxDeviation, bool? removeDegenerateParts = null,
        LinearUnit? maxDeviationUnit = null)
    {
        return await InvokeAsync<Geometry>("generalize", geometry, maxDeviation,
            removeDegenerateParts, maxDeviationUnit);
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
    public async Task<double> GeodesicArea(Polygon geometry, ArealUnit? unit = null)
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
    public async Task<Polygon[]> GeodesicBuffer(IEnumerable<Geometry> geometries, IEnumerable<double> distances,
        LinearUnit? unit = null, bool? unionResults = null)
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
    public async Task<Polygon> GeodesicBuffer(Geometry geometry, double distance, LinearUnit? unit = null)
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
    public async Task<Geometry> GeodesicDensify(Geometry geometry, double maxSegmentLength,
        LinearUnit? maxSegmentLengthUnit = null)
    {
        return await InvokeAsync<Geometry>("geodesicDensify", geometry, maxSegmentLength,
            maxSegmentLengthUnit);
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
    public async Task<double> GeodesicLength(Geometry geometry, LinearUnit? unit = null)
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
    public async Task<NearestPointResult[]> NearestVertices(Geometry geometry, Point inputPoint, double searchRadius,
        int maxVertexCountToReturn)
    {
        return await InvokeAsync<NearestPointResult[]>("nearestVertices", geometry, inputPoint,
            searchRadius, maxVertexCountToReturn);
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
    ///     The <see cref="JoinType" />
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
    public async Task<Geometry[]> Offset(IEnumerable<Geometry> geometries, double offsetDistance,
        LinearUnit? offsetUnit = null, JoinType? joinType = null, double? bevelRatio = null,
        double? flattenError = null)
    {
        return await InvokeAsync<Geometry[]>("offset", geometries, offsetDistance,
            offsetUnit, joinType, bevelRatio, flattenError);
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
    ///     The <see cref="JoinType" />
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
    public async Task<Geometry> Offset(Geometry geometry, double offsetDistance,
        LinearUnit? offsetUnit = null, JoinType? joinType = null, double? bevelRatio = null,
        double? flattenError = null)
    {
        return await InvokeAsync<Geometry>("offset", geometry, offsetDistance,
            offsetUnit, joinType, bevelRatio, flattenError);
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
    public async Task<double> PlanarArea(Polygon geometry, ArealUnit? unit = null)
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
    public async Task<double> PlanarLength(Geometry geometry, LinearUnit? unit = null)
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
    public async Task<bool> Within(Geometry innerGeometry, Geometry outerGeometry)
    {
        return await InvokeAsync<bool>("within", innerGeometry, outerGeometry);
    }
}

/// <summary>
///     Join types for creating an offset geometry in <see cref="GeometryEngine" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<JoinType>))]
public enum JoinType
{
#pragma warning disable CS1591
    Round,
    Bevel,
    Miter,
    Square
#pragma warning restore CS1591
}