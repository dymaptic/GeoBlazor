using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Enums;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Options;
using dymaptic.GeoBlazor.Core.Results;
using Microsoft.AspNetCore.Components;


#pragma warning disable BL0005


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

[TestCategory(nameof(LogicComponent))]
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

    [TestMethod]
    public async Task TestLocationToAddress(Action renderHandler)
    {
        // Reverse geocode: given a location, find the address
        // Using the Esri headquarters location
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));

        AddressCandidate result = await LocationService.LocationToAddress(location);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Address);

        Assert.IsTrue(result.Address.Contains("New York") || result.Address.Contains("Redlands"),
            $"Expected address to contain 'New York' or 'Redlands', got: {result.Address}");
    }

    [TestMethod]
    public async Task TestLocationToAddressWithLocationType(Action renderHandler)
    {
        // Reverse geocode with location type specified
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));

        AddressCandidate result = await LocationService.LocationToAddress(location, LocationType.Rooftop);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Address);
    }

    [TestMethod]
    public async Task TestLocationToAddressWithOutSpatialReference(Action renderHandler)
    {
        // Reverse geocode with output spatial reference
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));
        SpatialReference outSpatialReference = new SpatialReference(102100); // Web Mercator

        AddressCandidate result = await LocationService.LocationToAddress(location, null, outSpatialReference);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Address);
        Assert.IsNotNull(result.Location);

        // Location should be in Web Mercator coordinates
        Assert.IsNotNull(result.Location.SpatialReference);
        Assert.AreEqual(102100, result.Location.SpatialReference.Wkid);
    }

    [TestMethod]
    public async Task TestSuggestLocations(Action renderHandler)
    {
        // Get location suggestions based on partial text
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));
        string searchText = "Starbucks";

        List<SuggestionResult> suggestions = await LocationService.SuggestLocations(location, searchText);

        Assert.IsNotNull(suggestions);
        Assert.IsGreaterThan(0, suggestions.Count);

        // Each suggestion should have text and a magic key
        SuggestionResult firstSuggestion = suggestions[0];
        Assert.IsNotNull(firstSuggestion.Text);
        Assert.IsFalse(string.IsNullOrEmpty(firstSuggestion.Text));
    }

    [TestMethod]
    public async Task TestSuggestLocationsWithCategories(Action renderHandler)
    {
        // Get location suggestions with category filter
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));
        string searchText = "Coffee";
        List<string> categories = ["Coffee Shop", "Food"];

        List<SuggestionResult> suggestions = await LocationService.SuggestLocations(location, searchText, categories);

        Assert.IsNotNull(suggestions);

        // Should return results, though exact count depends on what's near the location
    }

    [TestMethod]
    public async Task TestAddressesToLocationsWithCountryCode(Action renderHandler)
    {
        List<Address> addresses = [_testAddressRedlands];
        List<AddressCandidate> locations = await LocationService.AddressesToLocations(addresses, "USA");

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);

        AddressCandidate? firstAddress = locations
            .FirstOrDefault(x => x.Address!.Contains(_expectedStreetAddressRedlands));

        Assert.IsNotNull(firstAddress?.Location);
    }

    [TestMethod]
    public async Task TestAddressesToLocationsWithCategories(Action renderHandler)
    {
        List<Address> addresses = [_testAddressRedlands];
        List<string> categories = ["Address"];
        List<AddressCandidate> locations = await LocationService.AddressesToLocations(addresses, "USA", categories);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressesToLocationsWithLocationType(Action renderHandler)
    {
        List<Address> addresses = [_testAddressRedlands];

        List<AddressCandidate> locations =
            await LocationService.AddressesToLocations(addresses, "USA", null, LocationType.Rooftop);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressesToLocationsWithOutSpatialReference(Action renderHandler)
    {
        List<Address> addresses = [_testAddressRedlands];
        SpatialReference outSpatialReference = new SpatialReference(102100); // Web Mercator

        List<AddressCandidate> locations = await LocationService.AddressesToLocations(
            addresses, null, null, null, outSpatialReference);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);

        // First address should have location in Web Mercator
        AddressCandidate? firstAddress = locations.FirstOrDefault();
        Assert.IsNotNull(firstAddress?.Location);
    }

    [TestMethod]
    public async Task TestAddressesToLocationsFromStringWithCountryCode(Action renderHandler)
    {
        List<string> addresses = [_expectedFullAddressEugene1];
        List<AddressCandidate> locations = await LocationService.AddressesToLocations(addresses, "USA");

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsWithCategories(Action renderHandler)
    {
        List<string> categories = ["Address"];
        List<AddressCandidate> locations = await LocationService.AddressToLocations(_testAddressRedlands, categories);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsWithCategoriesAndCountryCode(Action renderHandler)
    {
        List<string> categories = ["Address"];

        List<AddressCandidate> locations =
            await LocationService.AddressToLocations(_testAddressRedlands, categories, "USA");

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsWithForStorage(Action renderHandler)
    {
        List<AddressCandidate> locations = await LocationService.AddressToLocations(
            _testAddressRedlands, null, "USA", forStorage: false);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsWithLocationBias(Action renderHandler)
    {
        // Using a location bias near the expected address
        Point locationBias = new Point(-117.19, 34.05, spatialReference: new SpatialReference(4326));

        List<AddressCandidate> locations = await LocationService.AddressToLocations(
            _testAddressRedlands, null, "USA", null, locationBias);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsWithMaxLocations(Action renderHandler)
    {
        List<AddressCandidate> locations = await LocationService.AddressToLocations(_testAddressRedlands,
            maxLocations: 5);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
        Assert.IsLessThanOrEqualTo(5, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithCategories(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";
        List<string> categories = ["Address"];
        List<AddressCandidate> locations = await LocationService.AddressToLocations(addressString, categories);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithCountryCode(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";
        List<AddressCandidate> locations = await LocationService.AddressToLocations(addressString, null, "USA");

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressesToLocationsFromStringWithCategoriesAndLocationType(Action renderHandler)
    {
        List<string> addresses = [_expectedFullAddressEugene1];
        List<string> categories = ["Address"];

        List<AddressCandidate> locations = await LocationService.AddressesToLocations(
            addresses, "USA", categories, LocationType.Rooftop);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithForStorage(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";

        List<AddressCandidate> locations =
            await LocationService.AddressToLocations(addressString, null, "USA", forStorage: false);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithLocationBias(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";
        Point locationBias = new Point(-117.19, 34.05, spatialReference: new SpatialReference(4326));

        List<AddressCandidate> locations =
            await LocationService.AddressToLocations(addressString, null, "USA", null, locationBias);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithLocationType(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";

        List<AddressCandidate> locations = await LocationService.AddressToLocations(
            addressString, null, "USA", null, null, LocationType.Rooftop);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithMagicKey(Action renderHandler)
    {
        // First get a suggestion to get a magicKey
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));
        string searchText = "Starbucks";

        List<SuggestionResult> suggestions = await LocationService.SuggestLocations(location, searchText);
        Assert.IsNotNull(suggestions);

        if (suggestions.Count > 0 && !string.IsNullOrEmpty(suggestions[0].MagicKey))
        {
            // Use the magicKey to get detailed results
            List<AddressCandidate> locations = await LocationService.AddressToLocations(suggestions[0].Text,
                magicKey: suggestions[0].MagicKey);

            Assert.IsNotNull(locations);
            Assert.IsGreaterThan(0, locations.Count);
        }
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithMaxLocations(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";

        List<AddressCandidate> locations = await LocationService.AddressToLocations(addressString, maxLocations: 3);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
        Assert.IsLessThanOrEqualTo(3, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithOutFields(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";
        List<string> outFields = ["Addr_type", "Match_addr", "PlaceName"];

        List<AddressCandidate> locations = await LocationService.AddressToLocations(
            addressString, null, null, null, null, null, null, null, outFields);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithOutSpatialReference(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";
        SpatialReference outSpatialReference = new SpatialReference(102100); // Web Mercator

        List<AddressCandidate> locations = await LocationService.AddressToLocations(addressString, null, null, null,
            null, null, null, null, null, outSpatialReference);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestAddressToLocationsStringWithSearchExtent(Action renderHandler)
    {
        string addressString = "132 New York Street, Redlands, CA 92373";

        // Extent around Redlands area
        Extent searchExtent = new Extent(-117.3, 33.9, -117.1, 34.2, spatialReference: new SpatialReference(4326));

        List<AddressCandidate> locations = await LocationService.AddressToLocations(addressString, null, null, null,
            null, null, null, null, null, null, searchExtent);

        Assert.IsNotNull(locations);
        Assert.IsGreaterThan(0, locations.Count);
    }

    [TestMethod]
    public async Task TestLocationToAddressWithRequestOptions(Action renderHandler)
    {
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));
        RequestOptions requestOptions = new();

        AddressCandidate result = await LocationService.LocationToAddress(location, null, null, requestOptions);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Address);
    }

    [TestMethod]
    public async Task TestSuggestLocationsWithRequestOptions(Action renderHandler)
    {
        Point location = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));
        string searchText = "Coffee";
        List<string> categories = ["Coffee Shop"];
        RequestOptions requestOptions = new();

        List<SuggestionResult> suggestions = await LocationService.SuggestLocations(
            location, searchText, categories, requestOptions);

        Assert.IsNotNull(suggestions);
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