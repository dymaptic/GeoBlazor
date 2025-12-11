using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

[TestClass]
public class ExtentGeometryTests: TestRunnerBase
{
    [Inject]
    public required GeometryEngine GeometryEngine { get; set; }

    [TestMethod]
    public async Task TestGetExtentCenter()
    {
        Extent extent = new Extent(11994192.730393518,
            6339075.629744545,
            -809557.7770101484,
            -5134059.089271128,
            spatialReference: new SpatialReference(102100));
        Point? center = await GeometryEngine.GetExtentCenter(extent);
        Assert.IsNotNull(center);
    }

    [TestMethod]
    public async Task TestGetExtentHeight()
    {
        Extent extent = new Extent(11994192.730393518,
            6339075.629744545,
            -809557.7770101484,
            -5134059.089271128,
            spatialReference: new SpatialReference(102100));
        double? height = await GeometryEngine.GetExtentHeight(extent);
        Assert.IsNotNull(height);
    }
    
    [TestMethod]
    public async Task TestGetExtentWidth()
    {
        Extent extent = new Extent(11994192.730393518,
            6339075.629744545,
            -809557.7770101484,
            -5134059.089271128,
            spatialReference: new SpatialReference(102100));
        double? width = await GeometryEngine.GetExtentWidth(extent);
        Assert.IsNotNull(width);
    }
}