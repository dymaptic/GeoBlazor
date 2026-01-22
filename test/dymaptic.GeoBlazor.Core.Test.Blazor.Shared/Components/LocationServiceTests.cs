using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;
using Microsoft.AspNetCore.Components;


#pragma warning disable BL0005


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

[TestClass]
public class LocationServiceTests : TestRunnerBase
{
    [Inject]
    public required LocationService LocationService { get; set; }

    [TestMethod]
    public async Task TestPerformAddressesToLocation(Action renderHandler)
    {
        List<Address> addresses = [_testAddressEugene1, _testAddressEugene2];
        List<AddressCandidate> locations = await LocationService.AddressesToLocations(addresses);

        AddressCandidate? firstAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetEugene1));

        Assert.IsNotNull(firstAddress?.Location);

        Assert.IsTrue(LocationsMatch(_expectedLocationEugene1, firstAddress.Location),
            $"Expected Long: {_expectedLocationEugene1.Longitude} Lat: {_expectedLocationEugene1.Latitude}, got Long: {
                firstAddress.Location.Longitude} Lat: {firstAddress.Location.Latitude}");

        AddressCandidate? secondAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetEugene2));

        Assert.IsNotNull(secondAddress?.Location);

        Assert.IsTrue(LocationsMatch(_expectedLocationEugene2, secondAddress.Location),
            $"Expected Long: {_expectedLocationEugene2.Longitude} Lat: {_expectedLocationEugene2.Latitude}, got Long: {
                secondAddress.Location.Longitude} Lat: {secondAddress.Location.Latitude}");
    }

    [TestMethod]
    public async Task TestPerformAddressToLocation(Action renderHandler)
    {
        var location = await LocationService.AddressToLocations(_testAddressRedlands);

        AddressCandidate? firstAddress = location
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddressRedlands));

        Assert.IsNotNull(firstAddress?.Location);

        Assert.IsTrue(LocationsMatch(_expectedLocationRedlands, firstAddress.Location),
            $"Expected Long: {_expectedLocationRedlands.Longitude} Lat: {_expectedLocationRedlands.Latitude
            }, got Long: {firstAddress.Location.Longitude} Lat: {firstAddress.Location.Latitude}");
    }

    [TestMethod]
    public async Task TestPerformAddressToLocationFromString(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";

        List<AddressCandidate> location = await LocationService.AddressToLocations(addressString);

        AddressCandidate? firstAddress = location
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddressRedlands));

        Assert.IsNotNull(firstAddress?.Location);

        Assert.IsTrue(LocationsMatch(_expectedLocationRedlands, firstAddress.Location),
            $"Expected Long: {_expectedLocationRedlands.Longitude} Lat: {_expectedLocationRedlands.Latitude
            }, got Long: {firstAddress.Location.Longitude} Lat: {firstAddress.Location.Latitude}");
    }

    [TestMethod]
    public async Task TestPerformAddressesToLocationFromString(Action renderHandler)
    {
        List<string> addresses =
        [
            _expectedFullAddressEugene1,
            _expectedFullAddressEugene2
        ];
        List<AddressCandidate> locations = await LocationService.AddressesToLocations(addresses);

        AddressCandidate? firstAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetEugene1));

        Assert.IsNotNull(firstAddress?.Location);

        Assert.IsTrue(LocationsMatch(_expectedLocationEugene1, firstAddress.Location),
            $"Expected Long: {_expectedLocationEugene1.Longitude} Lat: {_expectedLocationEugene1.Latitude}, got Long: {
                firstAddress.Location.Longitude} Lat: {firstAddress.Location.Latitude}");

        var secondAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetEugene2));

        Assert.IsNotNull(secondAddress?.Location);

        Assert.IsTrue(LocationsMatch(_expectedLocationEugene2, secondAddress.Location),
            $"Expected Long: {_expectedLocationEugene2.Longitude} Lat: {_expectedLocationEugene2.Latitude}, got Long: {
                secondAddress.Location.Longitude} Lat: {secondAddress.Location.Latitude}");
    }

    private bool LocationsMatch(Point loc1, Point loc2)
    {
        return (Math.Abs(loc1.Latitude!.Value - loc2.Latitude!.Value) < 0.00001)
            && Math.Abs(loc1.Longitude!.Value - loc2.Longitude!.Value) < 0.00001;
    }

    private readonly Address _testAddressRedlands = new("132 New York Street", "Redlands", "CA", "92373");
    private readonly string _expectedStreetAddressRedlands = "132 New York St";
    private readonly Point _expectedLocationRedlands = new(-117.19498330596601, 34.053834157090002);
    private readonly Address _testAddressEugene1 = new("1434 W 25th Ave", "Eugene", "OR", "97405");
    private readonly string _expectedFullAddressEugene1 = "1434 W 25th Ave, Eugene, OR 97405";
    private readonly string _expectedStreetEugene1 = "1434 W 25th Ave";
    private readonly Point _expectedLocationEugene1 = new(-123.114112505277, 44.0307112476);
    private readonly string _expectedFullAddressEugene2 = "85 Oakway Center, Eugene, OR 97401";
    private readonly Address _testAddressEugene2 = new("85 Oakway Center", "Eugene", "OR", "97401");
    private readonly string _expectedStreetEugene2 = "85 Oakway Ctr";
    private readonly Point _expectedLocationEugene2 = new(-123.075320051552, 44.066269543984);
}