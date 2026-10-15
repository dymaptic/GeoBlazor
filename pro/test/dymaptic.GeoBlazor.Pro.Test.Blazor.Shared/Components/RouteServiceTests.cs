
using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Pro.Components;
using dymaptic.GeoBlazor.Pro.Model;
using dymaptic.GeoBlazor.Pro.Results;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;

[TestClass]
[TestCategory(nameof(ProLogicComponent))]
[TestCategory(nameof(LogicComponent))]
public class RouteServiceTests : ProTestRunnerBase
{
    [Inject]
    public required RouteService RouteService { get; set; }

    [TestMethod]
    public async Task TestCanSolveRoute()
    {
        RouteParameters routeParams = new()
        {
            FeatureSetStops = new FeatureSet()
            {
                Features =
                [
                    new Graphic(new Point(-117.195, 34.057)),
                    new Graphic(new Point(-117.918, 33.812)),
                    new Graphic(new Point(-118.149, 33.80))
                ]
            },
            ReturnStops = true,
            ReturnBarriers = true,
            ReturnDirections = true,
            ReturnRoutes = true,
            ReturnPolylineBarriers = true,
            ReturnPolygonBarriers = true,
            ReturnTraversedEdges = true,
            ReturnTraversedJunctions = true,
            ReturnTraversedTurns = true,
            ReturnZ = true
        };
        RouteSolveResult result = await RouteService.Solve(Url, routeParams);
        Assert.IsNotNull(result.RouteResults![0].Route);
    }

    private const string Url = "https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World";
}