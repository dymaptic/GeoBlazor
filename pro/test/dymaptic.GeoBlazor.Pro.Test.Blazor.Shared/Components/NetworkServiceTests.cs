using dymaptic.GeoBlazor.Core;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Pro.Components;
using dymaptic.GeoBlazor.Pro.Model;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;

[TestClass]
[TestCategory(nameof(ProLogicComponent))]
[TestCategory(nameof(LogicComponent))]
public class NetworkServiceTests : ProTestRunnerBase
{
    [Inject]
    public required NetworkService NetworkService { get; set; }

    [Inject]
    public required GeoBlazorSettings GeoBlazorSettings { get; set; }

    [TestMethod]
    public async Task TestFetchServiceDescriptionWithDefaultApiKey()
    {
        ServiceDescription description = await NetworkService.FetchServiceDescription(RouteServiceUrl);

        Assert.IsNotNull(description);
        Assert.IsNotNull(description.SupportedTravelModes);
        Assert.IsGreaterThan(0, description.SupportedTravelModes.Count);
    }

    [TestMethod]
    public async Task TestFetchServiceDescriptionWithExplicitApiKey()
    {
        // Test with explicit null apiKey (will use configured key)
        ServiceDescription description = await NetworkService.FetchServiceDescription(RouteServiceUrl,
            GeoBlazorSettings.RegistrationKey);

        Assert.IsNotNull(description);
    }

    private const string RouteServiceUrl =
        "https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World";
}