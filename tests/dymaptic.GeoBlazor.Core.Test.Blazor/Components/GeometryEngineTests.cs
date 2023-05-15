using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Exceptions;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Components;

public class GeometryEngineTests: TestRunnerBase
{
    [Inject]
    public GeometryEngine GeometryEngine { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }

    [TestMethod]
    public async Task TestBufferWithProjectedPoint()
    {
        Point point = new Point(0, 0, spatialReference: new SpatialReference(103002));
        Polygon buffer = await GeometryEngine.Buffer(point, 10.0, LinearUnit.Feet);
        Assert.IsNotNull(buffer);
    }

    [TestMethod]
    public async Task TestBufferWithWgs84PointThrowsJavaScriptError()
    {
        Point point = new Point(0, 0, spatialReference: new SpatialReference(4326));
        await Assert.ThrowsExceptionAsync<JSException>(() => GeometryEngine.Buffer(point, 10.0, LinearUnit.Feet));
    }
    
    [TestMethod]
    public async Task TestBufferWithMultipleProjectedPoints()
    {
        Point point1 = new Point(0, 0, spatialReference: new SpatialReference(103002));
        Point point2 = new Point(10, 10, spatialReference: new SpatialReference(103002));
        Polygon[] buffers = await GeometryEngine.Buffer(new[] {point1, point2}, new[] {10.0, 20.0}, LinearUnit.Feet);
        Assert.IsNotNull(buffers);
        Assert.AreEqual(2, buffers.Length);
    }
    
    [TestMethod]
    public async Task TestBufferWithMultipleProjectedPointsUnioned()
    {
        Point point1 = new Point(0, 0, spatialReference: new SpatialReference(103002));
        Point point2 = new Point(10, 10, spatialReference: new SpatialReference(103002));
        Polygon[] buffers = await GeometryEngine.Buffer(new[] {point1, point2}, new[] {10.0, 20.0}, LinearUnit.Feet, true);
        Assert.IsNotNull(buffers);
        Assert.AreEqual(1, buffers.Length);
    }

    [TestMethod]
    public async Task TestClip()
    {
        Polygon boundaryPolygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        Extent envelope = new Extent(-5, 5, -15, 15, spatialReference: new SpatialReference(103002));
        
        Polygon clippedPolygon = (Polygon)(await GeometryEngine.Clip(boundaryPolygon, envelope))!;
        Assert.IsNotNull(clippedPolygon);
    }
    
    [TestMethod]
    public async Task TestClipNoOverlapReturnsNull()
    {
        Polygon boundaryPolygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        Extent envelope = new Extent(5, 5, 15, 15, spatialReference: new SpatialReference(103002));
        
        Polygon? clippedPolygon = (await GeometryEngine.Clip(boundaryPolygon, envelope)) as Polygon;
        Assert.IsNull(clippedPolygon);
    }

    [TestMethod]
    public async Task TestContainsTrue()
    {
        Polygon boundaryPolygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Point point = new Point(5, 5, spatialReference: new SpatialReference(103002));
        
        bool contains = await GeometryEngine.Contains(boundaryPolygon, point);
        Assert.IsTrue(contains);
    }

    [TestMethod]
    public async Task TestContainsFalse()
    {
        Polygon boundaryPolygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
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
        List<Point> points = new();
        for (int i = 0; i < 10; i++)
        {
            points.Add(new Point(i, i, spatialReference: new SpatialReference(103002)));
        }
        
        Geometry[] convexHull = await GeometryEngine.ConvexHull(points);
        Assert.IsInstanceOfType<Point>(convexHull[0]);
        Assert.AreEqual(10, convexHull.Length);
    }

    [TestMethod]
    public async Task TestConvexHullMerged()
    {
        List<Point> points = new();
        for (int i = 0; i < 10; i++)
        {
            points.Add(new Point(i, i, spatialReference: new SpatialReference(103002)));
        }
        
        Geometry[] convexHull = await GeometryEngine.ConvexHull(points, true);
        Assert.IsInstanceOfType<Polygon>(convexHull[0]);
        Assert.AreEqual(1, convexHull.Length);
    }

    [TestMethod]
    public async Task TestCrossesTrue()
    {
        PolyLine polyline1 = new PolyLine(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(10, 10)
            }
        }, spatialReference: new SpatialReference(103002));
        
        PolyLine polyline2 = new PolyLine(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 10),
                new MapPoint(10, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        bool crosses = await GeometryEngine.Crosses(polyline1, polyline2);
        
        Assert.IsTrue(crosses);
    }

    [TestMethod]
    public async Task TestCrossesFalse()
    {
        PolyLine polyline1 = new PolyLine(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(10, 10)
            }
        }, spatialReference: new SpatialReference(103002));
        
        PolyLine polyline2 = new PolyLine(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(10, 0),
                new MapPoint(20, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        bool crosses = await GeometryEngine.Crosses(polyline1, polyline2);
        
        Assert.IsFalse(crosses);
    }

    [TestMethod]
    public async Task TestCut()
    {
        Polygon polygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(10, 0),
                new MapPoint(10, 10),
                new MapPoint(0, 10),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        PolyLine cutter = new PolyLine(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(5, -5),
                new MapPoint(5, 15)
            }
        }, spatialReference: new SpatialReference(103002));
        
        Geometry[] cut = await GeometryEngine.Cut(polygon, cutter);
        
        Assert.AreEqual(2, cut.Length);
    }

    [TestMethod]
    public async Task TestCutNotIntersectedReturnsEmpty()
    {
        Polygon polygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(10, 0),
                new MapPoint(10, 10),
                new MapPoint(0, 10),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        PolyLine cutter = new PolyLine(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(-5, -5),
                new MapPoint(-5, -15)
            }
        }, spatialReference: new SpatialReference(103002));
        
        Geometry[] cut = await GeometryEngine.Cut(polygon, cutter);
        
        Assert.AreEqual(0, cut.Length);
    }

    [TestMethod]
    public async Task TestDensify()
    {
        Polygon boundaryPolygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        Geometry densifiedPolygon = await GeometryEngine.Densify(boundaryPolygon, 1, LinearUnit.Feet);
        
        Assert.AreNotEqual(boundaryPolygon, densifiedPolygon);
    }

    [TestMethod]
    public async Task TestDifference()
    {
        Polygon boundaryPolygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Polygon subtractor = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(5, 5),
                new MapPoint(5, 15),
                new MapPoint(15, 15),
                new MapPoint(15, 5),
                new MapPoint(5, 5)
            }
        }, spatialReference: new SpatialReference(103002));
        
        Geometry difference = await GeometryEngine.Difference(boundaryPolygon, subtractor);
        Assert.AreNotEqual(boundaryPolygon, difference);
    }
    
    [TestMethod]
    public async Task TestDifferenceMultipleInputs()
    {
        Polygon boundaryPolygon1 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
		Polygon boundaryPolygon2 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(2, 2),
                new MapPoint(2, 12),
                new MapPoint(12, 12),
                new MapPoint(12, 2),
                new MapPoint(2, 2)
            }
        }, spatialReference: new SpatialReference(103002));
        Polygon subtractor = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(5, 5),
                new MapPoint(5, 15),
                new MapPoint(15, 15),
                new MapPoint(15, 5),
                new MapPoint(5, 5)
            }
        }, spatialReference: new SpatialReference(103002));
        
        Geometry[] differences = await GeometryEngine.Difference(new[] {boundaryPolygon1, boundaryPolygon2}, subtractor);
        Assert.AreEqual(2, differences.Length);
    }

	[TestMethod]
	public async Task TestDisjointTrue()
	{
		Polygon polygon1 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Polygon polygon2 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(20, 20),
                new MapPoint(20, 30),
                new MapPoint(30, 30),
                new MapPoint(30, 20),
                new MapPoint(20, 20)
            }
        }, spatialReference: new SpatialReference(103002));
        
        bool disjoint = await GeometryEngine.Disjoint(polygon1, polygon2);
        
        Assert.IsTrue(disjoint);
	}

    [TestMethod]
	public async Task TestDisjointFalse()
	{
		Polygon polygon1 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Polygon polygon2 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(5, 5),
                new MapPoint(5, 15),
                new MapPoint(15, 15),
                new MapPoint(15, 5),
                new MapPoint(5, 5)
            }
        }, spatialReference: new SpatialReference(103002));
        
        bool disjoint = await GeometryEngine.Disjoint(polygon1, polygon2);
        
        Assert.IsFalse(disjoint);
	}

	[TestMethod]
	public async Task TestDistance()
    {
		Point point1 = new Point(0, 0, spatialReference: new SpatialReference(103002));
		Point point2 = new Point(10, 10, spatialReference: new SpatialReference(103002));
		
		double distance = await GeometryEngine.Distance(point1, point2, LinearUnit.Feet);
        
        Assert.AreNotEqual(0, distance);
    }

    [TestMethod]
    public async Task TestAreEqualTrue()
    {
        Polygon polygon1 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Polygon polygon2 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
        bool areEqual = await GeometryEngine.AreEqual(polygon1, polygon2);
        
        Assert.IsTrue(areEqual);
    }

    [TestMethod]
    public async Task TestAreEqualFalse()
    {
        Polygon polygon1 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Polygon polygon2 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(5, 0),
                new MapPoint(5, 10),
                new MapPoint(15, 10),
                new MapPoint(15, 0),
                new MapPoint(5, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        
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
        Polygon polygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Point flipPoint = new Point(5, 5, spatialReference: new SpatialReference(103002));
        Polygon? flippedPolygon = await GeometryEngine.FlipHorizontal(polygon, flipPoint) as Polygon;
        Assert.IsNotNull(flippedPolygon);
        Assert.AreNotEqual(polygon, flippedPolygon);
    }

    [TestMethod]
    public async Task TestFlipVertical()
    {
        Polygon polygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        }, spatialReference: new SpatialReference(103002));
        Point flipPoint = new Point(5, 5, spatialReference: new SpatialReference(103002));
        Polygon? flippedPolygon = await GeometryEngine.FlipVertical(polygon, flipPoint) as Polygon;
        Assert.IsNotNull(flippedPolygon);
        Assert.AreNotEqual(polygon, flippedPolygon);
    }

    [TestMethod]
    public async Task TestGeneralize()
    {
        Polygon complexPolygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(0, 0)
            },
            new MapPath
            {
                new MapPoint(2, 2),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(2, 2)
            },
            new MapPath
            {
                new MapPoint(4, 4),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(_random.NextDouble(), _random.NextDouble()),
                new MapPoint(4, 4)
            }
        }, spatialReference: new SpatialReference(103002));

        Polygon? generalizedPolygon =
            await GeometryEngine.Generalize(complexPolygon, 1, true, 
                LinearUnit.Feet) as Polygon;
        Assert.IsNotNull(generalizedPolygon);
        Assert.AreNotEqual(complexPolygon, generalizedPolygon);
        Assert.IsTrue(complexPolygon.Rings.Select(r => r.Count).Sum() > 
            generalizedPolygon.Rings.Select(r => r.Count).Sum());
    }

    [TestMethod]
    public async Task TestGeodesicArea()
    {
        Polygon polygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        });
        
        double area = await GeometryEngine.GeodesicArea(polygon, ArealUnit.SquareFeet);
        
        Assert.AreNotEqual(0, area);
    }

    [TestMethod]
    public async Task TestGeodesicBuffer()
    {
        Polygon polygon = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        });
        
        Polygon bufferedPolygon = await GeometryEngine.GeodesicBuffer(polygon, 10, LinearUnit.Feet);
        
        Assert.IsNotNull(bufferedPolygon);
        
        Assert.AreNotEqual(polygon, bufferedPolygon);
    }

    [TestMethod]
    public async Task TestGeodesicBufferMultiplePolygons()
    {
        Polygon polygon1 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(0, 0),
                new MapPoint(0, 10),
                new MapPoint(10, 10),
                new MapPoint(10, 0),
                new MapPoint(0, 0)
            }
        });
        Polygon polygon2 = new Polygon(new MapPath[]
        {
            new MapPath
            {
                new MapPoint(5, 0),
                new MapPoint(5, 10),
                new MapPoint(15, 10),
                new MapPoint(15, 0),
                new MapPoint(5, 0)
            }
        });

        Geometry[] bufferedGeometries =
            await GeometryEngine.GeodesicBuffer(new[] { polygon1, polygon2 }, new double[] { 10, 15 }, 
                LinearUnit.Feet);
        
        Assert.IsNotNull(bufferedGeometries);
        Assert.AreEqual(2, bufferedGeometries.Length);
        Assert.AreNotEqual(bufferedGeometries[0], bufferedGeometries[1]);
    }

    // [TestMethod]
    // public async Task GeodesicDensify()
    // {
    //     Polygon polygon = new Polygon(new MapPath[]
    //     {
    //         new MapPath
    //         {
    //             new MapPoint(0, 0),
    //             new MapPoint(0, 10),
    //             new MapPoint(10, 10),
    //             new MapPoint(10, 0)
    //         }
    //     });
    //     
    //     Polygon? densifiedPolygon = await GeometryEngine.GeodesicDensify(polygon, 100, LinearUnit.Feet) as Polygon;
    //     
    //     Assert.IsNotNull(densifiedPolygon);
    //     Assert.AreNotEqual(densifiedPolygon, polygon);
    // }
    
    private readonly Random _random = new();
}