using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Enums;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

[TestClass]
public class GeometryEngineTests : TestRunnerBase
{
    [Inject]
    public required GeometryEngine GeometryEngine { get; set; }

    [TestMethod]
    public async Task TestBufferWithProjectedPoint()
    {
        Point point = new Point(0, 0, spatialReference: new SpatialReference(103002));
        Polygon buffer = await GeometryEngine.Buffer(point, 10.0, GeometryEngineLinearUnit.Feet);
        Assert.IsNotNull(buffer);
    }

    [TestMethod]
    public async Task TestBufferWithWgs84PointThrowsJavaScriptError()
    {
        Point point = new Point(0, 0, spatialReference: new SpatialReference(4326));

        await Assert.ThrowsAsync<JSException>(() =>
            GeometryEngine.Buffer(point, 10.0, GeometryEngineLinearUnit.Feet));
    }

    [TestMethod]
    public async Task TestBufferWithMultipleProjectedPoints()
    {
        Point point1 = new Point(0, 0, spatialReference: new SpatialReference(103002));
        Point point2 = new Point(10, 10, spatialReference: new SpatialReference(103002));

        Polygon[] buffers =
            await GeometryEngine.Buffer([point1, point2], [10.0, 20.0], GeometryEngineLinearUnit.Feet);
        Assert.IsNotNull(buffers);
        Assert.HasCount(2, buffers);
    }

    [TestMethod]
    public async Task TestBufferWithMultipleProjectedPointsUnioned()
    {
        Point point1 = new Point(0, 0, spatialReference: new SpatialReference(103002));
        Point point2 = new Point(10, 10, spatialReference: new SpatialReference(103002));

        Polygon[] buffers =
            await GeometryEngine.Buffer([point1, point2], [10.0, 20.0], GeometryEngineLinearUnit.Feet, true);
        Assert.IsNotNull(buffers);
        Assert.HasCount(1, buffers);
    }

    [TestMethod]
    public async Task TestBufferCallAfterDensified()
    {
        MapPath[] mapPaths = new MapPath[]
        {
            [
                new MapPoint(-10424520.3945, 5095465.361299999),
                new MapPoint(-10424520.3945, 5095465.2124999985),
                new MapPoint(-10424522.5096, 5095507.017999999),
                new MapPoint(-10424522.6209, 5095507.017999999),
                new MapPoint(-10424522.6209, 5095521.895400003),
                new MapPoint(-10424525.9605, 5095691.499700002),
                new MapPoint(-10424587.1862, 5095691.499700002),
                new MapPoint(-10424717.43, 5095698.938500002),
                new MapPoint(-10424786.448099999, 5095697.450800002),
                new MapPoint(-10424835.4287, 5095697.450800002),
                new MapPoint(-10424865.4849, 5095697.450800002),
                new MapPoint(-10424916.6919, 5095698.938500002),
                new MapPoint(-10424935.6162, 5095698.938500002),
                new MapPoint(-10424951.2009, 5095698.938500002),
                new MapPoint(-10425091.463499999, 5095698.938500002),
                new MapPoint(-10425149.3496, 5095698.938500002),
                new MapPoint(-10425168.2739, 5095700.426300004),
                new MapPoint(-10425189.4246, 5095698.938500002),
                new MapPoint(-10425233.952399999, 5095700.426300004),
                new MapPoint(-10425259.5559, 5095698.938500002),
                new MapPoint(-10425326.3476, 5095700.426300004),
                new MapPoint(-10425392.0261, 5095698.938500002),
                new MapPoint(-10425457.704599999, 5095698.938500002),
                new MapPoint(-10425476.628899999, 5095698.938500002),
                new MapPoint(-10425489.9873, 5095698.938500002),
                new MapPoint(-10425495.553199999, 5095698.938500002),
                new MapPoint(-10425518.9303, 5095700.426300004),
                new MapPoint(-10425547.873399999, 5095701.914099999),
                new MapPoint(-10425585.722, 5095700.426300004),
                new MapPoint(-10425724.871399999, 5095690.0119),
                new MapPoint(-10425756.0409, 5095688.524099998),
                new MapPoint(-10425941.9444, 5095673.646499999),
                new MapPoint(-10425939.718, 5095260.056100003),
                new MapPoint(-10425939.718, 5095209.474300005),
                new MapPoint(-10425941.9444, 5095184.183600001),
                new MapPoint(-10425944.1708, 5095096.4102),
                new MapPoint(-10425936.3784, 5095030.952600002),
                new MapPoint(-10425937.4916, 5094956.569499999),
                new MapPoint(-10425936.3784, 5094766.1514),
                new MapPoint(-10425936.3784, 5094718.547499999),
                new MapPoint(-10425935.2652, 5094623.340300001),
                new MapPoint(-10425736.0033, 5094623.340300001),
                new MapPoint(-10425709.2867, 5094623.340300001),
                new MapPoint(-10425668.0985, 5094623.340300001),
                new MapPoint(-10425546.7602, 5094621.8527000025),
                new MapPoint(-10425521.1567, 5094621.8527000025)
            ],
            [
                new MapPoint(-10424520.3945, 5095465.2124999985),
                new MapPoint(-10424520.3945, 5095451.971700005),
                new MapPoint(-10424519.281299999, 5095405.8521),
                new MapPoint(-10424519.281299999, 5095382.048500001),
                new MapPoint(-10424519.281299999, 5095381.899800003),
                new MapPoint(-10424519.281299999, 5095338.904700004),
                new MapPoint(-10424519.281299999, 5095251.129900001),
                new MapPoint(-10424519.281299999, 5095250.9811),
                new MapPoint(-10424519.281299999, 5095087.484099999),
                new MapPoint(-10424518.1681, 5094889.625200003),
                new MapPoint(-10424518.1681, 5094844.995900005),
                new MapPoint(-10424518.0568, 5094844.847199999),
                new MapPoint(-10424518.0568, 5094810.780299999),
                new MapPoint(-10424518.1681, 5094810.780299999),
                new MapPoint(-10424518.1681, 5094712.597000003),
                new MapPoint(-10424518.1681, 5094673.919),
                new MapPoint(-10424518.1681, 5094666.4809000045),
                new MapPoint(-10424518.1681, 5094617.389899999),
                new MapPoint(-10424518.1681, 5094435.903999999),
                new MapPoint(-10424518.1681, 5094307.9733000025),
                new MapPoint(-10424519.281299999, 5094133.9309),
                new MapPoint(-10424519.281299999, 5094098.081500001),
                new MapPoint(-10424519.281299999, 5093947.991599999)
            ],
            [
                new MapPoint(-10424519.281299999, 5093947.842799999),
                new MapPoint(-10424519.281299999, 5093947.991599999),
                new MapPoint(-10424520.3945, 5093875.1043),
                new MapPoint(-10424520.3945, 5093809.655100003),
                new MapPoint(-10424520.3945, 5093793.292800002),
                new MapPoint(-10424521.5077, 5093660.908399999),
                new MapPoint(-10424521.5077, 5093646.033799998),
                new MapPoint(-10424521.5077, 5093635.621600002),
                new MapPoint(-10424521.5077, 5093620.747100003),
                new MapPoint(-10424521.5077, 5093608.847500004),
                new MapPoint(-10424521.5077, 5093538.937800005),
                new MapPoint(-10424505.923, 5093538.937800005),
                new MapPoint(-10424448.036799999, 5093538.937800005),
                new MapPoint(-10424441.3577, 5093538.937800005),
                new MapPoint(-10424345.6229, 5093538.937800005),
                new MapPoint(-10424227.6242, 5093540.4252),
                new MapPoint(-10424138.568699999, 5093540.4252),
                new MapPoint(-10423718.894199999, 5093544.887500003),
                new MapPoint(-10423445.0482, 5093543.4001),
                new MapPoint(-10423445.0482, 5093364.909200005),
                new MapPoint(-10423447.2746, 5093207.245099999),
                new MapPoint(-10423447.2746, 5093074.868700005),
                new MapPoint(-10423448.387799999, 5092943.9815),
                new MapPoint(-10423449.501, 5092796.7355),
                new MapPoint(-10423450.6142, 5092659.902800001),
                new MapPoint(-10423450.6142, 5092631.644100003),
                new MapPoint(-10423450.6142, 5092471.017499998),
                new MapPoint(-10423450.502899999, 5092471.017499998),
                new MapPoint(-10423446.050099999, 5092049.980099998),
                new MapPoint(-10423446.050099999, 5091939.9274),
                new MapPoint(-10423446.1614, 5091940.076200001),
                new MapPoint(-10423446.1614, 5091840.435000002),
                new MapPoint(-10423447.2746, 5091660.488600001),
                new MapPoint(-10423447.2746, 5091660.339900002),
                new MapPoint(-10423447.2746, 5091537.056299999),
                new MapPoint(-10423446.050099999, 5091391.170200005),
                new MapPoint(-10423444.9369, 5091214.355099998),
                new MapPoint(-10423442.8218, 5091028.472199999)
            ]
        };
        Polyline polyline = new Polyline(mapPaths, new SpatialReference(102100));
        Polygon buffer = await GeometryEngine.Buffer(polyline, 20, GeometryEngineLinearUnit.Yards);
        Assert.IsNotNull(buffer);
    }
    
    [TestMethod]
    public async Task TestClip()
    {
        Polygon boundaryPolygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Extent envelope = new Extent(-5, 5, -15, 15, spatialReference: new SpatialReference(103002));

        Polygon clippedPolygon = (Polygon)(await GeometryEngine.Clip(boundaryPolygon, envelope))!;
        Assert.IsNotNull(clippedPolygon);
    }

    [TestMethod]
    public async Task TestClipNoOverlapReturnsNull()
    {
        Polygon boundaryPolygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Extent envelope = new Extent(5, 5, 15, 15, spatialReference: new SpatialReference(103002));

        Polygon? clippedPolygon = await GeometryEngine.Clip(boundaryPolygon, envelope) as Polygon;
        Assert.IsNull(clippedPolygon);
    }
    
    [TestMethod]
    public async Task TestContainsTrue()
    {
        Polygon boundaryPolygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));
        Point point = new Point(5, 5, spatialReference: new SpatialReference(103002));

        bool contains = await GeometryEngine.Contains(boundaryPolygon, point);
        Assert.IsTrue(contains);
    }

    [TestMethod]
    public async Task TestContainsFalse()
    {
        Polygon boundaryPolygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));
        Point point = new Point(15, 15, spatialReference: new SpatialReference(103002));

        bool contains = await GeometryEngine.Contains(boundaryPolygon, point);
        Assert.IsFalse(contains);
    }

    [TestMethod]
    public async Task TestConvexHull()
    {
        Point point = new Point(0, 0, spatialReference: new SpatialReference(103002));

        Geometry convexHull = await GeometryEngine.ConvexHull(point);
        Assert.IsInstanceOfType<Point>(convexHull);
    }

    [TestMethod]
    public async Task TestConvexHullMultiplePoints()
    {
        List<Point> points = [];

        for (int i = 0; i < 10; i++)
        {
            points.Add(new Point(i, i, spatialReference: new SpatialReference(103002)));
        }

        Geometry[] convexHull = await GeometryEngine.ConvexHull(points);
        Assert.IsInstanceOfType<Point>(convexHull[0]);
        Assert.HasCount(10, convexHull);
    }

    [TestMethod]
    public async Task TestConvexHullMerged()
    {
        List<Point> points = [];

        for (int i = 0; i < 10; i++)
        {
            points.Add(new Point(i, i, spatialReference: new SpatialReference(103002)));
        }

        Geometry[] convexHull = await GeometryEngine.ConvexHull(points, true);
        Assert.IsInstanceOfType<Polygon>(convexHull[0]);
        Assert.HasCount(1, convexHull);
    }

    [TestMethod]
    public async Task TestCrossesTrue()
    {
        Polyline polyline1 = new Polyline([[new MapPoint(0, 0), new MapPoint(10, 10)]],
            new SpatialReference(103002));

        Polyline polyline2 = new Polyline([[new MapPoint(0, 10), new MapPoint(10, 0)]],
            new SpatialReference(103002));

        bool crosses = await GeometryEngine.Crosses(polyline1, polyline2);

        Assert.IsTrue(crosses);
    }

    [TestMethod]
    public async Task TestCrossesFalse()
    {
        Polyline polyline1 = new Polyline([[new MapPoint(0, 0), new MapPoint(10, 10)]],
            new SpatialReference(103002));

        Polyline polyline2 = new Polyline([[new MapPoint(10, 0), new MapPoint(20, 0)]],
            new SpatialReference(103002));

        bool crosses = await GeometryEngine.Crosses(polyline1, polyline2);

        Assert.IsFalse(crosses);
    }

    [TestMethod]
    public async Task TestCut()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(10, 0),
                    new MapPoint(10, 10),
                    new MapPoint(0, 10),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polyline cutter = new Polyline([[new MapPoint(5, -5), new MapPoint(5, 15)]],
            new SpatialReference(103002));

        Geometry[] cut = await GeometryEngine.Cut(polygon, cutter);

        Assert.HasCount(2, cut);
    }

    [TestMethod]
    public async Task TestCutNotIntersectedReturnsEmpty()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(10, 0),
                    new MapPoint(10, 10),
                    new MapPoint(0, 10),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polyline cutter = new Polyline([[new MapPoint(-5, -5), new MapPoint(-5, -15)]],
            new SpatialReference(103002));

        Geometry[] cut = await GeometryEngine.Cut(polygon, cutter);

        Assert.HasCount(0, cut);
    }

    [TestMethod]
    public async Task TestDensify()
    {
        Polygon boundaryPolygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Geometry densifiedPolygon = await GeometryEngine.Densify(boundaryPolygon, 1, GeometryEngineLinearUnit.Feet);

        Assert.AreNotEqual(boundaryPolygon, densifiedPolygon);
    }

    [TestMethod]
    public async Task TestDifference()
    {
        Polygon boundaryPolygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polygon subtractor =
            new Polygon([
                [
                    new MapPoint(5, 5),
                    new MapPoint(5, 15),
                    new MapPoint(15, 15),
                    new MapPoint(15, 5),
                    new MapPoint(5, 5)
                ]
            ], new SpatialReference(103002));

        Geometry difference = await GeometryEngine.Difference(boundaryPolygon, subtractor);
        Assert.AreNotEqual(boundaryPolygon, difference);
    }

    [TestMethod]
    public async Task TestDifferenceMultipleInputs()
    {
        Polygon boundaryPolygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polygon boundaryPolygon2 =
            new Polygon([
                [
                    new MapPoint(2, 2),
                    new MapPoint(2, 12),
                    new MapPoint(12, 12),
                    new MapPoint(12, 2),
                    new MapPoint(2, 2)
                ]
            ], new SpatialReference(103002));

        Polygon subtractor =
            new Polygon([
                [
                    new MapPoint(5, 5),
                    new MapPoint(5, 15),
                    new MapPoint(15, 15),
                    new MapPoint(15, 5),
                    new MapPoint(5, 5)
                ]
            ], new SpatialReference(103002));

        Geometry[] differences =
            await GeometryEngine.Difference([boundaryPolygon1, boundaryPolygon2], subtractor);
        Assert.HasCount(2, differences);
    }

    [TestMethod]
    public async Task TestDisjointTrue()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(20, 20),
                    new MapPoint(20, 30),
                    new MapPoint(30, 30),
                    new MapPoint(30, 20),
                    new MapPoint(20, 20)
                ]
            ], new SpatialReference(103002));

        bool disjoint = await GeometryEngine.Disjoint(polygon1, polygon2);

        Assert.IsTrue(disjoint);
    }

    [TestMethod]
    public async Task TestDisjointFalse()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(5, 5),
                    new MapPoint(5, 15),
                    new MapPoint(15, 15),
                    new MapPoint(15, 5),
                    new MapPoint(5, 5)
                ]
            ], new SpatialReference(103002));

        bool disjoint = await GeometryEngine.Disjoint(polygon1, polygon2);

        Assert.IsFalse(disjoint);
    }

    [TestMethod]
    public async Task TestDistance()
    {
        Point point1 = new Point(0, 0, spatialReference: new SpatialReference(103002));
        Point point2 = new Point(10, 10, spatialReference: new SpatialReference(103002));

        double distance = await GeometryEngine.Distance(point1, point2, GeometryEngineLinearUnit.Feet);

        Assert.AreNotEqual(0, distance);
    }

    [TestMethod]
    public async Task TestAreEqualTrue()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        bool areEqual = await GeometryEngine.AreEqual(polygon1, polygon2);

        Assert.IsTrue(areEqual);
    }

    [TestMethod]
    public async Task TestAreEqualFalse()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(5, 0),
                    new MapPoint(5, 10),
                    new MapPoint(15, 10),
                    new MapPoint(15, 0),
                    new MapPoint(5, 0)
                ]
            ], new SpatialReference(103002));

        bool areEqual = await GeometryEngine.AreEqual(polygon1, polygon2);

        Assert.IsFalse(areEqual);
    }

    [TestMethod]
    public async Task TestExtendedSpatialReferenceInfo()
    {
        SpatialReference spatialReference = new SpatialReference(103002);

        SpatialReferenceInfo spatialReferenceInfo = await GeometryEngine.ExtendedSpatialReferenceInfo(spatialReference);

        Assert.IsNotNull(spatialReferenceInfo);
    }

    [TestMethod]
    public async Task TestFlipHorizontal()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));
        Point flipPoint = new Point(5, 5, spatialReference: new SpatialReference(103002));
        Polygon? flippedPolygon = await GeometryEngine.FlipHorizontal(polygon, flipPoint) as Polygon;
        Assert.IsNotNull(flippedPolygon);
        Assert.AreNotEqual(polygon, flippedPolygon);
    }

    [TestMethod]
    public async Task TestFlipVertical()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(103002));
        Point flipPoint = new Point(5, 5, spatialReference: new SpatialReference(103002));
        Polygon? flippedPolygon = await GeometryEngine.FlipVertical(polygon, flipPoint) as Polygon;
        Assert.IsNotNull(flippedPolygon);
        Assert.AreNotEqual(polygon, flippedPolygon);
    }

    [TestMethod]
    public async Task TestGeneralize()
    {
        Polygon complexPolygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(0, 0)
            ],
            [
                new MapPoint(2, 2),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(2, 2)
            ],
            [
                new MapPoint(4, 4),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(4, 4)
            ]
        ], new SpatialReference(103002));

        Polygon? generalizedPolygon =
            await GeometryEngine.Generalize(complexPolygon, 1, true,
                GeometryEngineLinearUnit.Feet) as Polygon;
        Assert.IsNotNull(generalizedPolygon);
        Assert.AreNotEqual(complexPolygon, generalizedPolygon);
        Assert.IsGreaterThan(generalizedPolygon.Rings.Select(r => r.Count).Sum(),
            complexPolygon.Rings.Select(r => r.Count).Sum());
    }

    [TestMethod]
    public async Task TestGeodesicArealUnit()
    {
        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ]);

        double area = await GeometryEngine.GeodesicArea(polygon, GeometryEngineAreaUnit.SquareFeet);

        Assert.AreNotEqual(0, area);
    }

    [TestMethod]
    public async Task TestGeodesicAreaUnit()
    {
        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ]);

        double area = await GeometryEngine.GeodesicArea(polygon, GeometryEngineAreaUnit.SquareFeet);

        Assert.AreNotEqual(0, area);
    }

    [TestMethod]
    public async Task TestGeodesicBuffer()
    {
        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ]);

        Polygon bufferedPolygon = await GeometryEngine.GeodesicBuffer(polygon, 10, GeometryEngineLinearUnit.Feet);

        Assert.IsNotNull(bufferedPolygon);

        Assert.AreNotEqual(polygon, bufferedPolygon);
    }

    [TestMethod]
    public async Task TestGeodesicBufferMultiplePolygons()
    {
        Polygon polygon1 = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ]);

        Polygon polygon2 = new Polygon([
            [
                new MapPoint(5, 0),
                new MapPoint(5, 10),
                new MapPoint(15, 10),
                new MapPoint(15, 0),
                new MapPoint(5, 0)
            ]
        ]);

        Geometry[] bufferedGeometries =
            await GeometryEngine.GeodesicBuffer([polygon1, polygon2], [10, 15],
                GeometryEngineLinearUnit.Feet);

        Assert.IsNotNull(bufferedGeometries);
        Assert.HasCount(2, bufferedGeometries);
        Assert.AreNotEqual(bufferedGeometries[0], bufferedGeometries[1]);
    }

    [TestMethod]
    public async Task TestGeodesicDensify()
    {
        Polygon polygon =
            new Polygon([
                [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
            ], new SpatialReference(102100));

        Polygon? densifiedPolygon =
            await GeometryEngine.GeodesicDensify(polygon, 100, GeometryEngineLinearUnit.Feet) as Polygon;

        Assert.IsNotNull(densifiedPolygon);
        Assert.AreNotEqual(densifiedPolygon, polygon);
    }

    [TestMethod]
    public async Task TestGeodesicLength()
    {
        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            ]
        ]);

        double length = await GeometryEngine.GeodesicLength(polygon, GeometryEngineLinearUnit.Feet);

        Assert.IsGreaterThan(0, length);
    }

    [TestMethod]
    public async Task TestIntersectTrue()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Polygon intersectingPolygon = new Polygon([
            [new MapPoint(5, 5), new MapPoint(5, 15), new MapPoint(15, 15), new MapPoint(15, 5)]
        ]);

        Polygon? intersect = await GeometryEngine.Intersect(polygon, intersectingPolygon) as Polygon;

        Assert.IsNotNull(intersect);
    }

    [TestMethod]
    public async Task TestIntersectFalse()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Polygon intersectingPolygon = new Polygon([
            [new MapPoint(15, 15), new MapPoint(15, 25), new MapPoint(25, 25), new MapPoint(25, 15)]
        ]);

        Polygon? intersect = await GeometryEngine.Intersect(polygon, intersectingPolygon) as Polygon;

        Assert.IsNull(intersect);
    }

    [TestMethod]
    public async Task TestIntersectMultipleGeometries()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Polyline polyline = new Polyline([
            [new MapPoint(5, 5), new MapPoint(5, 15), new MapPoint(15, 15), new MapPoint(15, 5)]
        ]);

        Polygon intersectingPolygon = new Polygon([
            [new MapPoint(5, 5), new MapPoint(5, 15), new MapPoint(15, 15), new MapPoint(15, 5)]
        ]);

        Geometry[] intersect =
            await GeometryEngine.Intersect([polygon, polyline], intersectingPolygon);

        Assert.IsNotNull(intersect);
        Assert.HasCount(2, intersect);
        Assert.IsInstanceOfType<Polygon>(intersect[0]);
        Assert.IsInstanceOfType<Polyline>(intersect[1]);
    }

    [TestMethod]
    public async Task TestIntersectsTrue()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Polygon intersectingPolygon = new Polygon([
            [new MapPoint(5, 5), new MapPoint(5, 15), new MapPoint(15, 15), new MapPoint(15, 5)]
        ]);

        bool intersects = await GeometryEngine.Intersects(polygon, intersectingPolygon);

        Assert.IsTrue(intersects);
    }

    [TestMethod]
    public async Task TestIntersectsFalse()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Polygon intersectingPolygon = new Polygon([
            [new MapPoint(15, 15), new MapPoint(15, 25), new MapPoint(25, 25), new MapPoint(25, 15)]
        ]);

        bool intersects = await GeometryEngine.Intersects(polygon, intersectingPolygon);

        Assert.IsFalse(intersects);
    }

    [TestMethod]
    public async Task TestIsSimpleTrue()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        bool isSimple = await GeometryEngine.IsSimple(polygon);

        Assert.IsTrue(isSimple);
    }

    [TestMethod]
    public async Task TestIsSimpleFalse()
    {
        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(-10, 10),
                new MapPoint(10, 10),
                new MapPoint(5, 5),
                new MapPoint(-10, 5),
                new MapPoint(10, 0)
            ]
        ]);

        bool isSimple = await GeometryEngine.IsSimple(polygon);

        Assert.IsFalse(isSimple);
    }

    [TestMethod]
    public async Task TestNearestCoordinate()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Point point = new Point(15, 15);

        NearestPointResult result = await GeometryEngine.NearestCoordinate(polygon, point);

        Assert.AreEqual(10, result.Coordinate.X);
        Assert.AreEqual(10, result.Coordinate.Y);
        Assert.AreNotEqual(4, result.VertexIndex);
    }

    [TestMethod]
    public async Task TestNearestVertex()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Point point = new Point(15, 5);

        NearestPointResult result = await GeometryEngine.NearestVertex(polygon, point);

        Assert.AreEqual(10, result.Coordinate.X);
        Assert.AreEqual(10, result.Coordinate.Y);
        Assert.AreEqual(2, result.VertexIndex);
    }

    [TestMethod]
    public async Task TestNearestVertices()
    {
        Polygon polygon = new Polygon([
            [
                new MapPoint(0, 0),
                new MapPoint(-10, 10),
                new MapPoint(10, 10),
                new MapPoint(5, 5),
                new MapPoint(-10, 5),
                new MapPoint(10, 0)
            ]
        ]);

        Point point = new Point(15, 5);

        NearestPointResult[] result = await GeometryEngine.NearestVertices(polygon, point, 200, 100);

        Assert.HasCount(6, result);
    }

    [TestMethod]
    public async Task TestOffset()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        Geometry offset = await GeometryEngine.Offset(polygon, 10, GeometryEngineLinearUnit.Feet, JoinType.Bevel);

        Assert.IsNotNull(offset);
        Assert.AreNotEqual(polygon, offset);
    }

    [TestMethod]
    public async Task TestOffsetMultipleGeometries()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Geometry[] geometries = [polygon1, polygon2];

        Geometry[] offset = await GeometryEngine.Offset(geometries, 10, GeometryEngineLinearUnit.Feet, JoinType.Bevel);

        Assert.IsNotNull(offset);

        foreach (Geometry geometry in offset)
        {
            Assert.AreNotEqual(polygon1, geometry);
            Assert.AreNotEqual(polygon2, geometry);
        }
    }

    [TestMethod]
    public async Task TestOverlapsTrue()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Polygon overlappingPolygon = new Polygon([
            [new MapPoint(5, 5), new MapPoint(5, 15), new MapPoint(15, 15), new MapPoint(15, 5)]
        ]);

        bool overlaps = await GeometryEngine.Overlaps(polygon, overlappingPolygon);

        Assert.IsTrue(overlaps);
    }

    [TestMethod]
    public async Task TestOverlapsFalse()
    {
        Polygon polygon = new Polygon([
            [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
        ]);

        Polygon overlappingPolygon = new Polygon([
            [new MapPoint(15, 15), new MapPoint(15, 25), new MapPoint(25, 25), new MapPoint(25, 15)]
        ]);

        bool overlaps = await GeometryEngine.Overlaps(polygon, overlappingPolygon);

        Assert.IsFalse(overlaps);
    }

    [TestMethod]
    public async Task TestPlanarAreal()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        double area = await GeometryEngine.PlanarArea(polygon, GeometryEngineAreaUnit.SquareKilometers);

        Assert.IsGreaterThan(0, area);
    }

    [TestMethod]
    public async Task TestPlanarAreaUnit()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        double area = await GeometryEngine.PlanarArea(polygon, GeometryEngineAreaUnit.SquareKilometers);

        Assert.IsGreaterThan(0, area);
    }

    [TestMethod]
    public async Task TestPlanarLength()
    {
        Polyline polyline =
            new Polyline([
                [new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0)]
            ], new SpatialReference(102100));

        double length = await GeometryEngine.PlanarLength(polyline, GeometryEngineLinearUnit.Kilometers);

        Assert.IsGreaterThan(0, length);
    }

    [TestMethod]
    public async Task TestRelateTrue()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        bool relate = await GeometryEngine.Relate(polygon1, polygon2, "T*F**F***");

        Assert.IsTrue(relate);
    }

    [TestMethod]
    public async Task TestRelateFalse()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(100, 100),
                    new MapPoint(200, 100),
                    new MapPoint(200, 200),
                    new MapPoint(100, 100)
                ]
            ], new SpatialReference(102100));

        bool relate = await GeometryEngine.Relate(polygon1, polygon2, "T*F**F***");

        Assert.IsFalse(relate);
    }

    [TestMethod]
    public async Task TestRotate()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Point origin = new Point(0, 0, spatialReference: new SpatialReference(102100));

        Polygon? rotatedPolygon = await GeometryEngine.Rotate(polygon, 45, origin) as Polygon;

        Assert.IsNotNull(rotatedPolygon);
        Assert.AreNotEqual(polygon, rotatedPolygon);
    }

    [TestMethod]
    public async Task TestSimplify()
    {
        Polygon polygon =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Geometry simplifiedGeometry = await GeometryEngine.Simplify(polygon);

        Assert.IsNotNull(simplifiedGeometry);
        Assert.AreNotEqual(polygon, simplifiedGeometry);
    }

    [TestMethod]
    public async Task TestSymmetricDifference()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(100, 100),
                    new MapPoint(200, 100),
                    new MapPoint(200, 200),
                    new MapPoint(100, 100)
                ]
            ], new SpatialReference(102100));

        Geometry symmetricDifference = await GeometryEngine.SymmetricDifference(polygon1, polygon2);

        Assert.IsNotNull(symmetricDifference);
        Assert.AreNotEqual(polygon1, symmetricDifference);
        Assert.AreNotEqual(polygon2, symmetricDifference);
    }

    [TestMethod]
    public async Task TestSymmetricDifferences()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(-10, 10),
                    new MapPoint(10, 10),
                    new MapPoint(5, 5),
                    new MapPoint(-10, 5),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(100, 100),
                    new MapPoint(200, 100),
                    new MapPoint(200, 200),
                    new MapPoint(100, 100)
                ]
            ], new SpatialReference(102100));

        Polygon polygon3 =
            new Polygon([
                [
                    new MapPoint(100, 100),
                    new MapPoint(200, 100),
                    new MapPoint(200, 200),
                    new MapPoint(100, 100)
                ]
            ], new SpatialReference(102100));

        Geometry[] symmetricDifferences =
            await GeometryEngine.SymmetricDifference([polygon1, polygon2], polygon3);

        Assert.IsNotNull(symmetricDifferences);

        foreach (Geometry symmetricDifference in symmetricDifferences)
        {
            Assert.AreNotEqual(polygon1, symmetricDifference);
            Assert.AreNotEqual(polygon2, symmetricDifference);
            Assert.AreNotEqual(polygon3, symmetricDifference);
        }
    }

    [TestMethod]
    public async Task TestTouchesTrue()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(10, 0),
                    new MapPoint(20, 0),
                    new MapPoint(20, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        bool touches = await GeometryEngine.Touches(polygon1, polygon2);

        Assert.IsTrue(touches);
    }

    [TestMethod]
    public async Task TestTouchesFalse()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(20, 20),
                    new MapPoint(30, 20),
                    new MapPoint(30, 30),
                    new MapPoint(20, 30),
                    new MapPoint(20, 20)
                ]
            ], new SpatialReference(102100));

        bool touches = await GeometryEngine.Touches(polygon2, polygon1);

        Assert.IsFalse(touches);
    }

    [TestMethod]
    public async Task TestUnion()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(10, 0),
                    new MapPoint(20, 0),
                    new MapPoint(20, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0)
                ]
            ], new SpatialReference(102100));

        Geometry union = await GeometryEngine.Union(polygon1, polygon2);

        Assert.IsNotNull(union);
        Assert.AreNotEqual(polygon1, union);
        Assert.AreNotEqual(polygon2, union);
    }

    [TestMethod]
    public async Task TestWithinTrue()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(1, 1),
                    new MapPoint(1, 9),
                    new MapPoint(9, 9),
                    new MapPoint(9, 1),
                    new MapPoint(1, 1)
                ]
            ], new SpatialReference(102100));

        bool within = await GeometryEngine.Within(polygon2, polygon1);

        Assert.IsTrue(within);
    }

    [TestMethod]
    public async Task TestWithinFalse()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));

        Polygon polygon2 =
            new Polygon([
                [
                    new MapPoint(1, 1),
                    new MapPoint(1, 9),
                    new MapPoint(9, 9),
                    new MapPoint(9, 1),
                    new MapPoint(1, 1)
                ]
            ], new SpatialReference(102100));

        bool within = await GeometryEngine.Within(polygon1, polygon2);

        Assert.IsFalse(within);
    }

    [TestMethod]
    public async Task TestToAndFromArcGisJson()
    {
        Polygon polygon1 =
            new Polygon([
                [
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(10, 10),
                    new MapPoint(10, 0),
                    new MapPoint(0, 0)
                ]
            ], new SpatialReference(102100));
        
        string json = await GeometryEngine.ToArcGisJson(polygon1);
        Geometry fromJson = await GeometryEngine.FromArcGisJson<Polygon>(json);
        Assert.IsNotNull(fromJson);
        Assert.AreEqual(polygon1.Type, fromJson.Type);
        Assert.AreEqual(polygon1.Rings[0], ((Polygon)fromJson).Rings[0]);
    }
        
    [TestMethod]
    public async Task TestClone_ToFromJson()
    {
        Polygon polygon = new Polygon([new MapPath(new MapPoint(0, 0), new MapPoint(0, 1), new MapPoint(1, 1), new MapPoint(1, 0), new MapPoint(0, 0))
        ], new SpatialReference(102100));

        // Clone
        Polygon clone = await GeometryEngine.Clone(polygon);
        Assert.IsNotNull(clone);
        Assert.AreEqual(polygon.Type, clone.Type);

        // To/From ArcGIS JSON
        string json = await GeometryEngine.ToArcGisJson(polygon);
        Assert.IsFalse(string.IsNullOrWhiteSpace(json));

        Polygon from = await GeometryEngine.FromArcGisJson<Polygon>(json);
        Assert.IsNotNull(from);
        Assert.AreEqual(polygon.Type, from.Type);
    }

    [TestMethod]
    public async Task TestExtentHelpers_And_NormalizePoint()
    {
        Extent extent = new Extent(10, 0, 10, 0); // xmax, xmin, ymax, ymin (constructor used in codebase)
        Point center = new Point(2, 3);

        Extent centered = await GeometryEngine.CenterExtentAt(extent, center);
        Assert.IsNotNull(centered);

        Extent expanded = await GeometryEngine.Expand(extent, 2.0);
        Assert.IsNotNull(expanded);

        Extent[] normalizedExtents = await GeometryEngine.NormalizeExtent(new Extent(200, -200, 10, 0));
        Assert.IsNotNull(normalizedExtents);
        Assert.IsGreaterThanOrEqualTo(1, normalizedExtents.Length);

        Extent offsetExtent = await GeometryEngine.OffsetExtent(extent, 1, 2, 3);
        Assert.IsNotNull(offsetExtent);

        Point p = new Point(190, 10);
        Point normalizedPoint = await GeometryEngine.NormalizePoint(p);
        Assert.IsNotNull(normalizedPoint);
        Assert.IsTrue(normalizedPoint.X is <= 180 and >= -180);

        // get extent properties
        Point? maybeCenter = await GeometryEngine.GetExtentCenter(extent);
        double? maybeHeight = await GeometryEngine.GetExtentHeight(extent);
        double? maybeWidth = await GeometryEngine.GetExtentWidth(extent);

        Assert.IsNotNull(maybeCenter);
        Assert.IsNotNull(maybeHeight);
        Assert.IsNotNull(maybeWidth);
    }

    [TestMethod]
    public async Task TestPolyline_PathAndPoint_Mutations()
    {
        Polyline polyline = new Polyline([[[0,0],[1,1]]], new SpatialReference(102100));

        // AddPath using Point[] overload
        Polyline added = await GeometryEngine.AddPath(polyline, [new Point(1, 2), new Point(3, 3)]);
        Assert.IsNotNull(added);
        Assert.IsGreaterThanOrEqualTo(2, added.Paths.Count);

        // GetPoint for newly added path
        Point pt = await GeometryEngine.GetPoint(added, 1, 0);
        Assert.AreEqual(1, pt.X);
        Assert.AreEqual(2, pt.Y);

        // InsertPoint
        Polyline inserted = await GeometryEngine.InsertPoint(added, 1, 1, new Point(2.5, 2.5));
        Point got = await GeometryEngine.GetPoint(inserted, 1, 1);
        Assert.AreEqual(2.5, got.X);

        // SetPoint
        Polyline set = await GeometryEngine.SetPoint(inserted, 1, 1, new Point(5, 5));
        Point gotSet = await GeometryEngine.GetPoint(set, 1, 1);
        Assert.AreEqual(5, gotSet.X);

        // RemovePoint
        (Polyline Polyline, Point Point) removeResult = await GeometryEngine.RemovePoint(set, 1, 1);
#pragma warning disable MSTEST0032
        Assert.IsNotNull(removeResult);
        Assert.IsInstanceOfType(removeResult.Point, typeof(Point));

        // RemovePath
        (Polyline PolyLine, Point[] Path) removePathResult = await GeometryEngine.RemovePath(removeResult.Polyline, 1);
        Assert.IsNotNull(removePathResult);
        Assert.IsGreaterThanOrEqualTo(1, removePathResult.Path.Length);
    }

    [TestMethod]
    public async Task TestPolygon_RingAndPoint_Mutations()
    {
        Polygon polygon = new Polygon([new MapPath(new MapPoint(0, 0), new MapPoint(0, 5), new MapPoint(5, 5), new MapPoint(5, 0), new MapPoint(0, 0))
        ], new SpatialReference(102100));
        int beforeRings = polygon.Rings.Count;

        // AddRing with Point[]
        Polygon withRing = await GeometryEngine.AddRing(polygon, [new Point(10, 10), new Point(10, 20), new Point(20, 20), new Point(10, 10)
        ]);
        Assert.IsNotNull(withRing);
        Assert.HasCount(beforeRings + 1, withRing.Rings);

        // GetPoint from newly added ring
        Point ringPoint = await GeometryEngine.GetPoint(withRing, beforeRings, 0);
        Assert.AreEqual(10, ringPoint.X);

        // InsertPoint
        Polygon inserted = await GeometryEngine.InsertPoint(withRing, beforeRings, 1, new Point(11, 11));
        Point got = await GeometryEngine.GetPoint(inserted, beforeRings, 1);
        Assert.AreEqual(11, got.X);

        // SetPoint
        Polygon set = await GeometryEngine.SetPoint(inserted, beforeRings, 1, new Point(12, 12));
        Point gotSet = await GeometryEngine.GetPoint(set, beforeRings, 1);
        Assert.AreEqual(12, gotSet.X);

        // RemovePoint
        (Polygon Polygon, Point Point) removed = await GeometryEngine.RemovePoint(set, beforeRings, 1);
        Assert.IsNotNull(removed);
        Assert.IsInstanceOfType(removed.Point, typeof(Point));

        // RemoveRing
        (Polygon Polygon, Point[] Ring) removedRing = await GeometryEngine.RemoveRing(removed.Polygon, beforeRings);
        Assert.IsNotNull(removedRing);
#pragma warning restore MSTEST0032
        Assert.HasCount(beforeRings, removedRing.Polygon.Rings);
    }

    [TestMethod]
    public async Task TestIsClockwise()
    {
        MapPath ring = new MapPath(new MapPoint(0, 0), new MapPoint(0, 10), new MapPoint(10, 10), new MapPoint(10, 0), new MapPoint(0, 0));
        Polygon polygon = new Polygon([ring], new SpatialReference(102100));

        bool result = await GeometryEngine.IsClockwise(polygon, ring);
        Assert.IsInstanceOfType(result, typeof(bool));
    }
    
    private readonly Random _random = new();
}