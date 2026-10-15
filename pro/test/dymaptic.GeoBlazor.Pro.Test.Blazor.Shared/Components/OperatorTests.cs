using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Pro.Components.Geometries;
using dymaptic.GeoBlazor.Pro.Components.Operators;
using dymaptic.GeoBlazor.Pro.Model;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;

[TestClass]
[TestCategory(nameof(ProLogicComponent))]
[TestCategory(nameof(LogicComponent))]
public class OperatorTests : ProTestRunnerBase
{
    [Inject]
    public required MultiPartToSinglePartOperator MultiPartToSinglePartOperator { get; set; }

    [TestMethod]
    public async Task TestMultiPartPolygonToSinglePartPolygons()
    {
        Polygon multipartPolygon = new([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(20, 30),
                new MapPoint(30, 30),
                new MapPoint(30, 20),
                new MapPoint(20, 20)
            ],
            [
                new MapPoint(40, 40),
                new MapPoint(40, 50),
                new MapPoint(50, 50),
                new MapPoint(50, 40),
                new MapPoint(40, 40)
            ]
        ], new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([multipartPolygon]);

        Assert.IsNotNull(result);
        Assert.HasCount(3, result);
        Assert.IsTrue(result.All(g => g is Polygon));

        foreach (Polygon polygon in result.Cast<Polygon>())
        {
            Assert.HasCount(1, polygon.Rings);
        }
    }

    [TestMethod]
    public async Task TestMultiPartPolylineToSinglePartPolylines()
    {
        Polyline multipartPolyline = new([
            [
                new MapPoint(0, 0),
                new MapPoint(10, 10)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(30, 30)
            ],
            [
                new MapPoint(40, 40),
                new MapPoint(50, 50)
            ]
        ], new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([multipartPolyline]);

        Assert.IsNotNull(result);
        Assert.HasCount(3, result);
        Assert.IsTrue(result.All(g => g is Polyline));

        foreach (Polyline polyline in result.Cast<Polyline>())
        {
            Assert.HasCount(1, polyline.Paths);
        }
    }

    [TestMethod]
    public async Task TestMultiPointToSinglePoints()
    {
        Multipoint multipoint = new(points: [
            new Point(x: 0, y: 0),
            new Point(x: 10, y: 10),
            new Point(x: 20, y: 20),
            new Point(x: 30, y: 30),
            new Point(x: 40, y: 40)
        ], spatialReference: new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([multipoint]);

        Assert.IsNotNull(result);
        Assert.HasCount(5, result);
        Assert.IsTrue(result.All(g => g is Point));

        Point[] points = result.Cast<Point>().ToArray();
        Assert.AreEqual(0, points[0].X);
        Assert.AreEqual(0, points[0].Y);
        Assert.AreEqual(40, points[4].X);
        Assert.AreEqual(40, points[4].Y);
    }

    [TestMethod]
    public async Task TestSinglePartGeometriesPassThrough()
    {
        Polygon singlePartPolygon = new([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ], new SpatialReference(102100));

        Polyline singlePartPolyline = new([
            [
                new MapPoint(0, 0),
                new MapPoint(10, 10)
            ]
        ], new SpatialReference(102100));

        Point singlePoint = new(5, 5, spatialReference: new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany(
            [singlePartPolygon, singlePartPolyline, singlePoint]);

        Assert.IsNotNull(result);
        Assert.HasCount(3, result);
        Assert.IsInstanceOfType<Polygon>(result[0]);
        Assert.IsInstanceOfType<Polyline>(result[1]);
        Assert.IsInstanceOfType<Point>(result[2]);

        Assert.HasCount(1, ((Polygon)result[0]).Rings);
        Assert.HasCount(1, ((Polyline)result[1]).Paths);
    }

    [TestMethod]
    public async Task TestMixedGeometryTypes()
    {
        Polygon multipartPolygon = new([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(20, 30),
                new MapPoint(30, 30),
                new MapPoint(30, 20),
                new MapPoint(20, 20)
            ]
        ], new SpatialReference(102100));

        Polyline singlePartPolyline = new([
            [
                new MapPoint(0, 0),
                new MapPoint(10, 10)
            ]
        ], new SpatialReference(102100));

        Multipoint multipoint = new(points: [
            new Point(x: 0, y: 0),
            new Point(x: 10, y: 10)
        ], spatialReference: new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany(
            [multipartPolygon, singlePartPolyline, multipoint]);

        Assert.IsNotNull(result);
        // 2 polygons from multipart, 1 polyline, 2 points from multipoint = 5 total
        Assert.HasCount(5, result);
    }

    [TestMethod]
    public async Task TestSimplifyPolygonsTrue()
    {
        Polygon complexPolygon = new([
            [
                new MapPoint(0, 0),
                new MapPoint(10, 0),
                new MapPoint(10, 10),
                new MapPoint(0, 10),
                new MapPoint(0, 0)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(30, 20),
                new MapPoint(30, 30),
                new MapPoint(20, 30),
                new MapPoint(20, 20)
            ]
        ], new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany(
            [complexPolygon], simplifyPolygons: true);

        Assert.IsNotNull(result);
        Assert.HasCount(2, result);
        Assert.IsTrue(result.All(g => g is Polygon));
    }

    [TestMethod]
    public async Task TestSimplifyPolygonsFalse()
    {
        Polygon polygon = new([
            [
                new MapPoint(0, 0),
                new MapPoint(10, 0),
                new MapPoint(10, 10),
                new MapPoint(0, 10),
                new MapPoint(0, 0)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(30, 20),
                new MapPoint(30, 30),
                new MapPoint(20, 30),
                new MapPoint(20, 20)
            ]
        ], new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany(
            [polygon], simplifyPolygons: false);

        Assert.IsNotNull(result);
        Assert.HasCount(2, result);
        Assert.IsTrue(result.All(g => g is Polygon));
    }

    [TestMethod]
    public async Task TestEmptyGeometryCollection()
    {
        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([]);

        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [TestMethod]
    public async Task TestComplexMultiPartPolygonWithHoles()
    {
        Polygon complexPolygon = new([
            // Outer ring of first part
            [
                new MapPoint(0, 0),
                new MapPoint(0, 20),
                new MapPoint(20, 20),
                new MapPoint(20, 0),
                new MapPoint(0, 0)
            ],
            // Hole in first part
            [
                new MapPoint(5, 5),
                new MapPoint(5, 15),
                new MapPoint(15, 15),
                new MapPoint(15, 5),
                new MapPoint(5, 5)
            ],
            // Second separate part
            [
                new MapPoint(30, 30),
                new MapPoint(30, 40),
                new MapPoint(40, 40),
                new MapPoint(40, 30),
                new MapPoint(30, 30)
            ]
        ], new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([complexPolygon]);

        Assert.IsNotNull(result);
        Assert.IsGreaterThanOrEqualTo(1, result.Length);
        Assert.IsTrue(result.All(g => g is Polygon));
    }

    [TestMethod]
    public async Task TestMultipleMultiPartGeometries()
    {
        Polygon multipartPolygon1 = new([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(20, 30),
                new MapPoint(30, 30),
                new MapPoint(30, 20),
                new MapPoint(20, 20)
            ]
        ], new SpatialReference(102100));

        Polygon multipartPolygon2 = new([
            [
                new MapPoint(100, 100),
                new MapPoint(100, 110),
                new MapPoint(110, 110),
                new MapPoint(110, 100),
                new MapPoint(100, 100)
            ],
            [
                new MapPoint(120, 120),
                new MapPoint(120, 130),
                new MapPoint(130, 130),
                new MapPoint(130, 120),
                new MapPoint(120, 120)
            ]
        ], new SpatialReference(102100));

        Polyline multipartPolyline = new([
            [
                new MapPoint(0, 0),
                new MapPoint(10, 10)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(30, 30)
            ]
        ], new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany(
            [multipartPolygon1, multipartPolygon2, multipartPolyline]);

        Assert.IsNotNull(result);
        // 2 + 2 + 2 = 6 single part geometries
        Assert.HasCount(6, result);
    }

    [TestMethod]
    public async Task TestLargeMultipointGeometry()
    {
        List<Point> points = [];
        for (int i = 0; i < 100; i++)
        {
            points.Add(new Point(x: i, y: i));
        }

        Multipoint multipoint = new(points: points, spatialReference: new SpatialReference(102100));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([multipoint]);

        Assert.IsNotNull(result);
        Assert.HasCount(100, result);
        Assert.IsTrue(result.All(g => g is Point));
    }

    [TestMethod]
    public async Task TestGeographicCoordinateSystem()
    {
        Polygon multipartPolygon = new([
            [
                new MapPoint(-122.5, 37.7),
                new MapPoint(-122.4, 37.7),
                new MapPoint(-122.4, 37.8),
                new MapPoint(-122.5, 37.8),
                new MapPoint(-122.5, 37.7)
            ],
            [
                new MapPoint(-122.3, 37.9),
                new MapPoint(-122.2, 37.9),
                new MapPoint(-122.2, 38.0),
                new MapPoint(-122.3, 38.0),
                new MapPoint(-122.3, 37.9)
            ]
        ], new SpatialReference(4326));

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([multipartPolygon]);

        Assert.IsNotNull(result);
        Assert.HasCount(2, result);
        Assert.IsTrue(result.All(g => g is Polygon));

        foreach (Polygon polygon in result.Cast<Polygon>())
        {
            Assert.IsNotNull(polygon.SpatialReference);
            Assert.AreEqual(4326, polygon.SpatialReference.Wkid);
        }
    }

    [TestMethod]
    public async Task TestPreserveSpatialReference()
    {
        SpatialReference sr = new(102100);

        Polygon multipartPolygon = new([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ],
            [
                new MapPoint(20, 20),
                new MapPoint(20, 30),
                new MapPoint(30, 30),
                new MapPoint(30, 20),
                new MapPoint(20, 20)
            ]
        ], sr);

        Geometry[] result = await MultiPartToSinglePartOperator.ExecuteMany([multipartPolygon]);

        Assert.IsNotNull(result);
        foreach (Geometry geometry in result)
        {
            Assert.IsNotNull(geometry.SpatialReference);
            Assert.AreEqual(102100, geometry.SpatialReference.Wkid);
        }
    }
}
