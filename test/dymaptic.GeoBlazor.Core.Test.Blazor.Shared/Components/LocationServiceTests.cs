using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;


#pragma warning disable BL0005


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

public class LocationServiceTests : TestRunnerBase
{
    [Inject]
    public required LocationService LocationService { get; set; }

    [TestMethod]
    public async Task TestPerformAddressesToLocation(Action renderHandler)
    {
        List<Address> addresses = [_testAddress1, _testAddress2];
        List<AddressCandidate> locations = await LocationService.AddressesToLocations(addresses);

        AddressCandidate? firstAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddress1));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.IsTrue(LocationsMatch(_expectedLocation1, firstAddress.Location));

        AddressCandidate? secondAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddress2));

        Assert.IsNotNull(secondAddress?.Location);
        Assert.IsTrue(LocationsMatch(_expectedLocation2, secondAddress.Location));
    }

    [TestMethod]
    public async Task TestPerformAddressToLocation(Action renderHandler)
    {
        List<AddressCandidate> location = await LocationService.AddressToLocations(_testAddress1);

        AddressCandidate? firstAddress = location
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddress1));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.IsTrue(LocationsMatch(_expectedLocation1, firstAddress.Location));
    }

    [TestMethod]
    public async Task TestPerformAddressToLocationFromString(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";

        List<AddressCandidate> location = await LocationService.AddressToLocations(addressString);

        AddressCandidate? firstAddress = location
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddress1));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.IsTrue(LocationsMatch(_expectedLocation1, firstAddress.Location));
    }

    [TestMethod]
    public async Task TestPerformAddressesToLocationFromString(Action renderHandler)
    {
        List<string> addresses =
        [
            "132 New York Street, Redlands, CA 92373", 
            "400 New York Street, Redlands, CA 92373"
        ];
        List<AddressCandidate> locations = await LocationService.AddressesToLocations(addresses);

        AddressCandidate? firstAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddress1));

        Assert.IsNotNull(firstAddress?.Location);
        Assert.AreEqual(firstAddress.Location.Latitude, 34.053834157090002);

        var secondAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddress2));

        Assert.IsNotNull(secondAddress?.Location);
        Assert.AreEqual(secondAddress.Location.Latitude, 34.057451663745);
    }
    
    private bool LocationsMatch(Point loc1, Point loc2)
    {
        return Math.Abs(loc1.Latitude!.Value - loc2.Latitude!.Value) < 0.00001 
            && Math.Abs(loc1.Longitude!.Value - loc2.Longitude!.Value) < 0.00001;
    }

    private Address _testAddress1 = new("132 New York Street", "Redlands", "CA", "92373");
    private Address _testAddress2 = new("400 New York Street", "Redlands", "CA", "92373");
    private string _expectedStreetAddress1 = "132 New York St";
    private string _expectedStreetAddress2 = "400 New York St";
    private Point _expectedLocation1 = new(-117.19498330596601, 34.053834157090002);
    private Point _expectedLocation2 = new(-117.195611240849, 34.057451663745);
}