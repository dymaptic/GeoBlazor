using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;


#pragma warning disable BL0005


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

public class LocationServiceTests : TestRunnerBase
{
    /*
     * test data and expected results
     * 380 New York St, Redlands, California, 92373 100 - 34.056097983409,-117.195426038092
     * 400 New York St, Redlands, California, 92373 100 - 34.057451663745,-117.195611240849
     */
    
    [Inject]
    public required LocationService LocationService { get; set; }

    [TestMethod]
    public async Task TestPerformAddressesToLocation(Action renderHandler)
    {
        var addresses = new List<Address>
        {
            new Address("380 New York Street", "Redlands", "CA", "92373"),
            new Address("400 New York Street", "Redlands", "CA", "92373")
        };
        var locations = await LocationService.AddressesToLocations(addresses);

        var firstAddress = locations.FirstOrDefault(x => x.Address!.Contains("380 New York"));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.AreEqual(firstAddress!.Location.Latitude, 34.056097983409);
        Assert.AreEqual(firstAddress!.Location.Longitude, -117.195426038092);

        var secondAddress = locations.FirstOrDefault(x => x.Address!.Contains("400 New York"));

        Assert.IsNotNull(secondAddress?.Location);
        Assert.AreEqual(secondAddress!.Location.Latitude, 34.057451663745);
        Assert.AreEqual(secondAddress!.Location.Longitude, -117.195611240849);
    }

    [TestMethod]
    public async Task TestPerformAddressToLocation(Action renderHandler)
    {
        var address = new Address("380 New York Street", "Redlands", "CA", "92373");

        var location = await LocationService.AddressToLocations(address);

        var firstAddress = location.FirstOrDefault(x => x.Address!.Contains("380 New York"));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.AreEqual(firstAddress!.Location.Latitude, 34.056097983409);
        Assert.AreEqual(firstAddress!.Location.Longitude, -117.195426038092);
    }

    [TestMethod]
    public async Task TestPerformAddressToLocationString(Action renderHandler)
    {
        var address = "380 New York Street, Redlands, CA 92373";

        var location = await LocationService.AddressToLocations(address);

        var firstAddress = location.FirstOrDefault(x => x.Address!.Contains("380 New York"));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.AreEqual(firstAddress!.Location.Latitude, 34.056097983409);
        Assert.AreEqual(firstAddress!.Location.Longitude, -117.195426038092);
    }

    [TestMethod]
    public async Task TestPerformAddressesToLocationString(Action renderHandler)
    {
        var addresses = new List<string>
        {
            "380 New York Street, Redlands, CA 92373", "400 New York Street, Redlands, CA 92373",
        };
        var locations = await LocationService.AddressesToLocations(addresses);

        var firstAddress = locations.FirstOrDefault(x => x.Address!.Contains("380 New York"));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.AreEqual(firstAddress!.Location.Latitude, 34.056097983409);
        Assert.AreEqual(firstAddress!.Location.Longitude, -117.195426038092);

        var secondAddress = locations.FirstOrDefault(x => x.Address!.Contains("400 New York"));

        Assert.IsNotNull(secondAddress?.Location);
        Assert.AreEqual(secondAddress!.Location.Latitude, 34.057451663745);
        Assert.AreEqual(secondAddress!.Location.Longitude, -117.195611240849);
    }
}