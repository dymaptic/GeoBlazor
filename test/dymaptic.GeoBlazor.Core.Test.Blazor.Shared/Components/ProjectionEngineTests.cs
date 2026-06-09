using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

[TestCategory(nameof(LogicComponent))]
[TestClass]
public class ProjectionEngineTests : TestRunnerBase
{
    [Inject]
    public required ProjectionEngine ProjectionEngine { get; set; }

    [TestMethod]
    public async Task TestProjectSinglePointFromWgs84ToWebMercator()
    {
        Point point = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry? projectedGeometry = await ProjectionEngine.Project(point, targetSpatialReference);

        Assert.IsNotNull(projectedGeometry);
        Assert.IsInstanceOfType<Point>(projectedGeometry);
        Assert.IsNotNull(projectedGeometry.SpatialReference);
        Assert.AreEqual(102100, projectedGeometry.SpatialReference.Wkid);
    }

    [TestMethod]
    public async Task TestProjectSinglePointWithNullTransformation()
    {
        Point point = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry? projectedGeometry = await ProjectionEngine.Project(point, targetSpatialReference, null);

        Assert.IsNotNull(projectedGeometry);
        Assert.IsInstanceOfType<Point>(projectedGeometry);
    }

    [TestMethod]
    public async Task TestProjectMultiplePoints()
    {
        Point point1 = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        Point point2 = new Point(x: -118.2437, y: 34.0522, spatialReference: new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry[]? projectedGeometries = await ProjectionEngine.Project([point1, point2], targetSpatialReference);

        Assert.IsNotNull(projectedGeometries);
        Assert.HasCount(2, projectedGeometries);
        Assert.IsInstanceOfType<Point>(projectedGeometries[0]);
        Assert.IsInstanceOfType<Point>(projectedGeometries[1]);
    }

    [TestMethod]
    public async Task TestProjectMultiplePointsWithNullTransformation()
    {
        Point point1 = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        Point point2 = new Point(x: -118.2437, y: 34.0522, spatialReference: new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry[]? projectedGeometries =
            await ProjectionEngine.Project([point1, point2], targetSpatialReference, null);

        Assert.IsNotNull(projectedGeometries);
        Assert.HasCount(2, projectedGeometries);
    }

    [TestMethod]
    public async Task TestProjectPolygon()
    {
        Polygon polygon = new Polygon([
            [
                new MapPoint(-122.5, 37.5),
                new MapPoint(-122.5, 38.0),
                new MapPoint(-122.0, 38.0),
                new MapPoint(-122.0, 37.5),
                new MapPoint(-122.5, 37.5)
            ]
        ], new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry? projectedGeometry = await ProjectionEngine.Project(polygon, targetSpatialReference);

        Assert.IsNotNull(projectedGeometry);
        Assert.IsInstanceOfType<Polygon>(projectedGeometry);
    }

    [TestMethod]
    public async Task TestProjectPolyline()
    {
        Polyline polyline = new Polyline([
            [
                new MapPoint(-122.5, 37.5),
                new MapPoint(-122.0, 38.0),
                new MapPoint(-121.5, 37.5)
            ]
        ], new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry? projectedGeometry = await ProjectionEngine.Project(polyline, targetSpatialReference);

        Assert.IsNotNull(projectedGeometry);
        Assert.IsInstanceOfType<Polyline>(projectedGeometry);
    }

    [TestMethod]
    public async Task TestGetTransformationBetweenSameDatumReturnsNull()
    {
        // WGS84 and Web Mercator share the same datum, so no transformation is needed
        SpatialReference inSpatialReference = new SpatialReference(4326);
        SpatialReference outSpatialReference = new SpatialReference(102100);

        // Extent constructor: (xmax, xmin, ymax, ymin)
        Extent extent = new Extent(-120, -130, 50, 30, spatialReference: new SpatialReference(4326));

        GeographicTransformation? transformation =
            await ProjectionEngine.GetTransformation(inSpatialReference, outSpatialReference, extent);

        Assert.IsNull(transformation);
    }

    [TestMethod]
    public async Task TestGetTransformationsBetweenSameDatumReturnsEmpty()
    {
        // WGS84 and Web Mercator share the same datum, so no transformations are needed
        SpatialReference inSpatialReference = new SpatialReference(4326);
        SpatialReference outSpatialReference = new SpatialReference(102100);
        Extent extent = new Extent(-120, -130, 50, 30, spatialReference: new SpatialReference(4326));

        GeographicTransformation[]? transformations =
            await ProjectionEngine.GetTransformations(inSpatialReference, outSpatialReference, extent);

        Assert.IsNotNull(transformations);
        Assert.HasCount(0, transformations);
    }

    [TestMethod]
    public async Task TestProjectPreservesGeometryType()
    {
        Point point = new Point(x: -100, y: 40, spatialReference: new SpatialReference(4326));

        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ], new SpatialReference(4326));

        Polyline polyline = new Polyline([
            [new MapPoint(0, 0), new MapPoint(10, 10)]
        ], new SpatialReference(4326));

        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry? projectedPoint = await ProjectionEngine.Project(point, targetSpatialReference);
        Geometry? projectedPolygon = await ProjectionEngine.Project(polygon, targetSpatialReference);
        Geometry? projectedPolyline = await ProjectionEngine.Project(polyline, targetSpatialReference);

        Assert.IsInstanceOfType<Point>(projectedPoint);
        Assert.IsInstanceOfType<Polygon>(projectedPolygon);
        Assert.IsInstanceOfType<Polyline>(projectedPolyline);
    }

    [TestMethod]
    public async Task TestProjectMixedGeometryArray()
    {
        Point point = new Point(x: -100, y: 40, spatialReference: new SpatialReference(4326));

        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ], new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry[]? projectedGeometries = await ProjectionEngine.Project([point, polygon], targetSpatialReference);

        Assert.IsNotNull(projectedGeometries);
        Assert.HasCount(2, projectedGeometries);
        Assert.IsInstanceOfType<Point>(projectedGeometries[0]);
        Assert.IsInstanceOfType<Polygon>(projectedGeometries[1]);
    }

    [TestMethod]
    public async Task TestProjectToSameSpatialReferencePreservesCoordinates()
    {
        Point point = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(4326);

        Geometry? projectedGeometry = await ProjectionEngine.Project(point, targetSpatialReference);

        Assert.IsNotNull(projectedGeometry);
        Point projectedPoint = (Point)projectedGeometry;
        Assert.AreEqual(point.X, projectedPoint.X);
        Assert.AreEqual(point.Y, projectedPoint.Y);
    }

    [TestMethod]
    public async Task TestProjectFromWebMercatorToWgs84()
    {
        // Web Mercator coordinates for San Francisco area
        Point point = new Point(x: -13627665.271218, y: 4548388.565049, spatialReference: new SpatialReference(102100));
        SpatialReference targetSpatialReference = new SpatialReference(4326);

        Geometry? projectedGeometry = await ProjectionEngine.Project(point, targetSpatialReference);

        Assert.IsNotNull(projectedGeometry);
        Point projectedPoint = (Point)projectedGeometry;

        // Should be approximately -122.4194, 37.7749 (San Francisco coordinates)
        Assert.IsTrue(projectedPoint.X < -122 && projectedPoint.X > -123);
        Assert.IsTrue(projectedPoint.Y > 37 && projectedPoint.Y < 38);
    }

    [TestMethod]
    public async Task TestProjectExtent()
    {
        // Extent constructor: (xmax, xmin, ymax, ymin)
        Extent extent = new Extent(-122.0, -122.5, 38.0, 37.5, spatialReference: new SpatialReference(4326));
        SpatialReference targetSpatialReference = new SpatialReference(102100);

        Geometry? projectedGeometry = await ProjectionEngine.Project(extent, targetSpatialReference);

        Assert.IsNotNull(projectedGeometry);
        Assert.IsInstanceOfType<Extent>(projectedGeometry);
        Extent projectedExtent = (Extent)projectedGeometry;
        Assert.IsNotNull(projectedExtent.SpatialReference);
        Assert.AreEqual(102100, projectedExtent.SpatialReference.Wkid);
    }

    [TestMethod]
    public async Task TestProjectEmptyArrayReturnsEmpty()
    {
        SpatialReference targetSpatialReference = new(102100);

        Geometry[]? projectedGeometries = await ProjectionEngine.Project([], targetSpatialReference);

        Assert.IsNotNull(projectedGeometries);
        Assert.HasCount(0, projectedGeometries);
    }

    [TestMethod]
    public async Task TestRoundTripWgs84ToWebMercatorAndBack()
    {
        // Original point in WGS84
        Point originalPoint = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference webMercator = new SpatialReference(102100);
        SpatialReference wgs84 = new SpatialReference(4326);

        // Project to Web Mercator
        Geometry? projectedToWebMercator = await ProjectionEngine.Project(originalPoint, webMercator);
        Assert.IsNotNull(projectedToWebMercator);
        Point webMercatorPoint = (Point)projectedToWebMercator;

        // Project back to WGS84
        Geometry? projectedBackToWgs84 = await ProjectionEngine.Project(webMercatorPoint, wgs84);
        Assert.IsNotNull(projectedBackToWgs84);
        Point roundTripPoint = (Point)projectedBackToWgs84;

        // Verify coordinates match within tolerance
        AssertPointsAreApproximatelyEqual(originalPoint, roundTripPoint);
    }

    [TestMethod]
    public async Task TestRoundTripPolygonWgs84ToWebMercatorAndBack()
    {
        // Original polygon in WGS84
        Polygon originalPolygon = new Polygon([
            [
                new MapPoint(-122.5, 37.5),
                new MapPoint(-122.5, 38.0),
                new MapPoint(-122.0, 38.0),
                new MapPoint(-122.0, 37.5),
                new MapPoint(-122.5, 37.5)
            ]
        ], new SpatialReference(4326));
        SpatialReference webMercator = new SpatialReference(102100);
        SpatialReference wgs84 = new SpatialReference(4326);

        // Project to Web Mercator
        Geometry? projectedToWebMercator = await ProjectionEngine.Project(originalPolygon, webMercator);
        Assert.IsNotNull(projectedToWebMercator);
        Polygon webMercatorPolygon = (Polygon)projectedToWebMercator;

        // Project back to WGS84
        Geometry? projectedBackToWgs84 = await ProjectionEngine.Project(webMercatorPolygon, wgs84);
        Assert.IsNotNull(projectedBackToWgs84);
        Polygon roundTripPolygon = (Polygon)projectedBackToWgs84;

        // Verify ring points match within tolerance
        Assert.HasCount(originalPolygon.Rings.Count, roundTripPolygon.Rings);

        for (int i = 0; i < originalPolygon.Rings.Count; i++)
        {
            Assert.HasCount(originalPolygon.Rings[i].Count, roundTripPolygon.Rings[i]);

            for (int j = 0; j < originalPolygon.Rings[i].Count; j++)
            {
                AssertMapPointsAreApproximatelyEqual(originalPolygon.Rings[i][j], roundTripPolygon.Rings[i][j]);
            }
        }
    }

    [TestMethod]
    public async Task TestProjectFromWgs84ToUtmZone10N()
    {
        // San Francisco is in UTM Zone 10N (EPSG:32610)
        Point point = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference utmZone10N = new SpatialReference(32610);

        Geometry? projectedGeometry = await ProjectionEngine.Project(point, utmZone10N);

        Assert.IsNotNull(projectedGeometry);
        Point projectedPoint = (Point)projectedGeometry;
        Assert.IsNotNull(projectedPoint.SpatialReference);
        Assert.AreEqual(32610, projectedPoint.SpatialReference.Wkid);

        // UTM coordinates should be in meters, typically 6-digit easting and 7-digit northing
        Assert.IsTrue(projectedPoint.X > 500000 && projectedPoint.X < 600000); // Easting
        Assert.IsTrue(projectedPoint.Y > 4000000 && projectedPoint.Y < 5000000); // Northing
    }

    [TestMethod]
    public async Task TestRoundTripWgs84ToUtmZone10NAndBack()
    {
        Point originalPoint = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference utmZone10N = new SpatialReference(32610);
        SpatialReference wgs84 = new SpatialReference(4326);

        // Project to UTM
        Geometry? projectedToUtm = await ProjectionEngine.Project(originalPoint, utmZone10N);
        Assert.IsNotNull(projectedToUtm);
        Point utmPoint = (Point)projectedToUtm;

        // Project back to WGS84
        Geometry? projectedBackToWgs84 = await ProjectionEngine.Project(utmPoint, wgs84);
        Assert.IsNotNull(projectedBackToWgs84);
        Point roundTripPoint = (Point)projectedBackToWgs84;

        AssertPointsAreApproximatelyEqual(originalPoint, roundTripPoint);
    }

    [TestMethod]
    public async Task TestProjectFromWebMercatorToUtmZone10N()
    {
        // Web Mercator coordinates for San Francisco
        Point point = new Point(x: -13627665.271218, y: 4548388.565049, spatialReference: new SpatialReference(102100));
        SpatialReference utmZone10N = new SpatialReference(32610);

        Geometry? projectedGeometry = await ProjectionEngine.Project(point, utmZone10N);

        Assert.IsNotNull(projectedGeometry);
        Point projectedPoint = (Point)projectedGeometry;
        Assert.IsNotNull(projectedPoint.SpatialReference);
        Assert.AreEqual(32610, projectedPoint.SpatialReference.Wkid);
    }

    [TestMethod]
    public async Task TestRoundTripWebMercatorToUtmAndBack()
    {
        Point originalPoint = new Point(x: -13627665.271218, y: 4548388.565049,
            spatialReference: new SpatialReference(102100));
        SpatialReference utmZone10N = new SpatialReference(32610);
        SpatialReference webMercator = new SpatialReference(102100);

        // Project to UTM
        Geometry? projectedToUtm = await ProjectionEngine.Project(originalPoint, utmZone10N);
        Assert.IsNotNull(projectedToUtm);
        Point utmPoint = (Point)projectedToUtm;

        // Project back to Web Mercator
        Geometry? projectedBackToWebMercator = await ProjectionEngine.Project(utmPoint, webMercator);
        Assert.IsNotNull(projectedBackToWebMercator);
        Point roundTripPoint = (Point)projectedBackToWebMercator;

        // Web Mercator uses meters, so tolerance should be appropriate
        AssertPointsAreApproximatelyEqual(originalPoint, roundTripPoint, tolerance: 0.01);
    }

    [TestMethod]
    public async Task TestProjectToStatePlaneCaliforniaZone3()
    {
        // California State Plane Zone 3 (EPSG:2227) - uses US Survey Feet
        Point point = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference statePlane = new SpatialReference(2227);

        Geometry? projectedGeometry = await ProjectionEngine.Project(point, statePlane);

        Assert.IsNotNull(projectedGeometry);
        Point projectedPoint = (Point)projectedGeometry;
        Assert.IsNotNull(projectedPoint.SpatialReference);
        Assert.AreEqual(2227, projectedPoint.SpatialReference.Wkid);
    }

    [TestMethod]
    public async Task TestRoundTripWgs84ToStatePlaneAndBack()
    {
        Point originalPoint = new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326));
        SpatialReference statePlane = new SpatialReference(2227);
        SpatialReference wgs84 = new SpatialReference(4326);

        // Project to State Plane
        Geometry? projectedToStatePlane = await ProjectionEngine.Project(originalPoint, statePlane);
        Assert.IsNotNull(projectedToStatePlane);
        Point statePlanePoint = (Point)projectedToStatePlane;

        // Project back to WGS84
        Geometry? projectedBackToWgs84 = await ProjectionEngine.Project(statePlanePoint, wgs84);
        Assert.IsNotNull(projectedBackToWgs84);
        Point roundTripPoint = (Point)projectedBackToWgs84;

        AssertPointsAreApproximatelyEqual(originalPoint, roundTripPoint);
    }

    [TestMethod]
    public async Task TestProjectMultiplePointsRoundTrip()
    {
        Point[] originalPoints =
        [
            new Point(x: -122.4194, y: 37.7749, spatialReference: new SpatialReference(4326)), // San Francisco
            new Point(x: -118.2437, y: 34.0522, spatialReference: new SpatialReference(4326)), // Los Angeles
            new Point(x: -73.9857, y: 40.7484, spatialReference: new SpatialReference(4326)) // New York
        ];
        SpatialReference webMercator = new SpatialReference(102100);
        SpatialReference wgs84 = new SpatialReference(4326);

        // Project to Web Mercator
        Geometry[]? projectedToWebMercator = await ProjectionEngine.Project(originalPoints, webMercator);
        Assert.IsNotNull(projectedToWebMercator);
        Assert.HasCount(3, projectedToWebMercator);

        // Project back to WGS84
        Geometry[]? projectedBackToWgs84 = await ProjectionEngine.Project(projectedToWebMercator, wgs84);
        Assert.IsNotNull(projectedBackToWgs84);
        Assert.HasCount(3, projectedBackToWgs84);

        // Verify each point matches
        for (int i = 0; i < originalPoints.Length; i++)
        {
            AssertPointsAreApproximatelyEqual(originalPoints[i], (Point)projectedBackToWgs84[i]);
        }
    }

    private static void AssertPointsAreApproximatelyEqual(Point expected, Point actual, double tolerance = 0.0001)
    {
        Assert.IsNotNull(expected.X);
        Assert.IsNotNull(expected.Y);
        Assert.IsNotNull(actual.X);
        Assert.IsNotNull(actual.Y);

        double xDiff = Math.Abs(expected.X.Value - actual.X.Value);
        double yDiff = Math.Abs(expected.Y.Value - actual.Y.Value);

        Assert.IsLessThan(tolerance, xDiff,
            $"X coordinates differ: expected {expected.X}, actual {actual.X}, difference {xDiff}");

        Assert.IsLessThan(tolerance, yDiff,
            $"Y coordinates differ: expected {expected.Y}, actual {actual.Y}, difference {yDiff}");
    }

    private static void AssertMapPointsAreApproximatelyEqual(MapPoint expected, MapPoint actual,
        double tolerance = 0.0001)
    {
        // MapPoint is a List<double> where [0] = X and [1] = Y
        double xDiff = Math.Abs(expected[0] - actual[0]);
        double yDiff = Math.Abs(expected[1] - actual[1]);

        Assert.IsLessThan(tolerance, xDiff,
            $"X coordinates differ: expected {expected[0]}, actual {actual[0]}, difference {xDiff}");

        Assert.IsLessThan(tolerance, yDiff,
            $"Y coordinates differ: expected {expected[1]}, actual {actual[1]}, difference {yDiff}");
    }
}