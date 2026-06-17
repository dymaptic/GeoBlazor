using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;


namespace dymaptic.GeoBlazor.Core.Test.Unit;

/// <summary>
///     Regression tests for the client-side extent calculation added to <see cref="Geometry.GetExtent" />.
///     The customer reported (against 4.5.1) that a geometry without a cached extent (e.g. a
///     <c>GeometryEngine.Union</c> result) returned a <c>null</c> Extent, breaking <c>map.GoTo(extent)</c>.
///     With no <c>CoreJsModule</c> attached, <c>GetExtent()</c> must fall back to calculating the
///     bounding box from the geometry's own coordinates.
/// </summary>
[TestClass]
public class GeometryExtentTests
{
    [TestMethod]
    public async Task GetExtentCalculatesMissingExtentForPolygon()
    {
        Polygon polygon = new(
            [
                new MapPath(
                    new MapPoint(0, 0),
                    new MapPoint(0, 10),
                    new MapPoint(20, 10),
                    new MapPoint(20, 0),
                    new MapPoint(0, 0))
            ],
            new SpatialReference(102100));

        Assert.IsNull(polygon.Extent);

        Extent? extent = await polygon.GetExtent();

        Assert.IsNotNull(extent);
        Assert.AreEqual(0, extent!.Xmin);
        Assert.AreEqual(20, extent.Xmax);
        Assert.AreEqual(0, extent.Ymin);
        Assert.AreEqual(10, extent.Ymax);
    }

    [TestMethod]
    public async Task GetExtentCalculatesMissingExtentForPolyline()
    {
        Polyline polyline = new(
            [
                new MapPath(
                    new MapPoint(-5, 2),
                    new MapPoint(15, -3),
                    new MapPoint(7, 9))
            ],
            new SpatialReference(102100));

        Extent? extent = await polyline.GetExtent();

        Assert.IsNotNull(extent);
        Assert.AreEqual(-5, extent!.Xmin);
        Assert.AreEqual(15, extent.Xmax);
        Assert.AreEqual(-3, extent.Ymin);
        Assert.AreEqual(9, extent.Ymax);
    }
}
