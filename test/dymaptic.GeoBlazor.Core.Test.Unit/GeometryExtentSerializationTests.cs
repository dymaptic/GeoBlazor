using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json;

namespace dymaptic.GeoBlazor.Core.Test.Unit;

/// <summary>
///     Regression tests for the geometry deserialization path used by results of
///     <c>GeometryEngine</c> operations (e.g. <c>Union</c>).
///     The customer reported (against 4.5.1) that the unioned geometry arrived in .NET with a
///     <c>null</c> Extent (and therefore <c>GetExtent()</c> also returned <c>null</c>),
///     breaking callers that relied on <c>union.Extent</c> for <c>map.GoTo(extent)</c>.
///     These tests deserialize the exact JSON shape produced by <c>buildDotNetPolygon</c> /
///     <c>buildDotNetExtent</c> (polygon.ts / extent.ts) and assert the Extent survives.
/// </summary>
[TestClass]
public class GeometryExtentSerializationTests
{
    // Mirrors the object returned by buildDotNetPolygon(jsUnion) in geometryEngine.ts -> union(),
    // including the nested extent built by buildDotNetExtent.
    private const string UnionPolygonJson =
        """
        {
            "type": "polygon",
            "rings": [[[0,0],[0,10],[20,10],[20,0],[0,0]]],
            "spatialReference": { "wkid": 102100 },
            "extent": {
                "type": "extent",
                "xmin": 0, "ymin": 0, "xmax": 20, "ymax": 10,
                "spatialReference": { "wkid": 102100 }
            },
            "isSimple": true
        }
        """;

    [TestMethod]
    public void UnionResult_DeserializesWithPopulatedExtent()
    {
        Geometry? geometry = JsonSerializer.Deserialize<Geometry>(UnionPolygonJson,
            GeoBlazorSerialization.JsonSerializerOptions);

        Assert.IsNotNull(geometry);
        Assert.IsInstanceOfType<Polygon>(geometry);
        Assert.IsNotNull(geometry.Extent,
            "The geometry returned from Union must have a populated Extent (regression from 4.5.x).");
        Assert.AreEqual(0.0, geometry.Extent!.Xmin);
        Assert.AreEqual(0.0, geometry.Extent!.Ymin);
        Assert.AreEqual(20.0, geometry.Extent!.Xmax);
        Assert.AreEqual(10.0, geometry.Extent!.Ymax);
        Assert.IsNotNull(geometry.Extent!.SpatialReference);
    }

    [TestMethod]
    public void Polygon_RoundTrip_PreservesExtent()
    {
        Geometry? geometry = JsonSerializer.Deserialize<Geometry>(UnionPolygonJson,
            GeoBlazorSerialization.JsonSerializerOptions);
        Assert.IsNotNull(geometry?.Extent);

        // Re-serialize and re-deserialize to ensure the Extent is not dropped on the way back out.
        string json = JsonSerializer.Serialize(geometry, GeoBlazorSerialization.JsonSerializerOptions);
        Geometry? roundTripped = JsonSerializer.Deserialize<Geometry>(json,
            GeoBlazorSerialization.JsonSerializerOptions);

        Assert.IsNotNull(roundTripped);
        Assert.IsNotNull(roundTripped.Extent,
            "Extent must survive a full serialize/deserialize round-trip.");
        Assert.AreEqual(geometry.Extent!.Xmax, roundTripped.Extent!.Xmax);
        Assert.AreEqual(geometry.Extent!.Ymax, roundTripped.Extent!.Ymax);
    }
}
