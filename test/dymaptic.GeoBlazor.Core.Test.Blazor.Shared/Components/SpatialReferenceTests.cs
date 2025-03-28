using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#pragma warning disable BL0005

namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

public class SpatialReferenceTests : TestRunnerBase
{
    [Inject]
    public Projection Projection { get; set; } = default!;

    [TestMethod]
    public async Task ConvertWktToJSAndBack(Action renderHandler)
    {
        SpatialReference wktSpatialReference = new SpatialReference() { Wkt = """PROJCS["NAD_1983_Contiguous_USA_Albers",GEOGCS["GCS_North_American_1983",DATUM["D_North_American_1983",SPHEROID["GRS_1980",6378137.0,298.257222101]],PRIMEM["Greenwich",0.0],UNIT["Degree",0.0174532925199433]],PROJECTION["Albers"],PARAMETER["False_Easting",0.0],PARAMETER["False_Northing",0.0],PARAMETER["Central_Meridian",-96.0],PARAMETER["Standard_Parallel_1",29.5],PARAMETER["Standard_Parallel_2",45.5],PARAMETER["Latitude_Of_Origin",23.0],UNIT["Meter",1.0]],VERTCS["Unknown VCS",VDATUM["Unknown"],PARAMETER["Vertical_Shift",0.0],PARAMETER["Direction",1.0],UNIT["User_Defined_Unit",0.01]]""" };
        var polyLine = new PolyLine(
         [
         new MapPath( new MapPoint(-113.8147338,  48.0944495 ),new MapPoint( - 113.2431702,  48.0384702 ) )
         ], SpatialReference.Wgs84
         );

        var result = await Projection.Project(polyLine, wktSpatialReference);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.SpatialReference?.Wkt);
    }

    [TestMethod]
    public async Task ConvertWkt2ToJSAndBack(Action renderHandler)
    {
        SpatialReference wktSpatialReference = new SpatialReference() { Wkt2 = """PROJCS["NAD_1983_Contiguous_USA_Albers",GEOGCS["GCS_North_American_1983",DATUM["D_North_American_1983",SPHEROID["GRS_1980",6378137.0,298.257222101]],PRIMEM["Greenwich",0.0],UNIT["Degree",0.0174532925199433]],PROJECTION["Albers"],PARAMETER["False_Easting",0.0],PARAMETER["False_Northing",0.0],PARAMETER["Central_Meridian",-96.0],PARAMETER["Standard_Parallel_1",29.5],PARAMETER["Standard_Parallel_2",45.5],PARAMETER["Latitude_Of_Origin",23.0],UNIT["Meter",1.0]],VERTCS["Unknown VCS",VDATUM["Unknown"],PARAMETER["Vertical_Shift",0.0],PARAMETER["Direction",1.0],UNIT["User_Defined_Unit",0.01]]""" };
        var polyLine = new PolyLine(
            [
                new MapPath( new MapPoint(-113.8147338,  48.0944495 ),new MapPoint( - 113.2431702,  48.0384702 ) )
            ], SpatialReference.Wgs84
        );

        var result = await Projection.Project(polyLine, wktSpatialReference);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.SpatialReference?.Wkt2);
    }

    [TestMethod]
    public async Task ConvertWkidToJSAndBack(Action renderHandler)
    {
        SpatialReference wkidSpatialReference = new SpatialReference() { Wkid = 3857 };
        var polyLine = new PolyLine(
            [
                new MapPath( new MapPoint(-113.8147338,  48.0944495 ),new MapPoint( - 113.2431702,  48.0384702 ) )
            ], SpatialReference.Wgs84
        );

        var result = await Projection.Project(polyLine, wkidSpatialReference);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.SpatialReference?.Wkid);
    }
}
