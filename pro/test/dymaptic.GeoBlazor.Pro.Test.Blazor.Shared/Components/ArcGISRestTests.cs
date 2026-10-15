using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Options;
using dymaptic.GeoBlazor.Pro.Model;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;

[TestClass]
[TestCategory(nameof(ProLogicComponent))]
[TestCategory(nameof(LogicComponent))]
public class ArcGISRestTests : ProTestRunnerBase
{
    [Inject]
    public required ArcGISRest ArcGISRest { get; set; }

    [TestMethod]
    public async Task TestRequest()
    {
        // Test making a simple REST request to a public ArcGIS service endpoint
        var url =
            "https://services.arcgis.com/V6ZHFr6zdgNZuVG0/arcgis/rest/services/Landscape_Trees/FeatureServer/0";
        RequestOptions options = new() { Query = new Dictionary<string, object?> { ["f"] = "json" } };

        var response = await ArcGISRest.Request(url, options);

        Assert.IsNotNull(response);
    }

    [TestMethod]
    public async Task TestRequestTyped()
    {
        // Test making a typed REST request that deserializes to a specific type
        var url =
            "https://services.arcgis.com/V6ZHFr6zdgNZuVG0/arcgis/rest/services/Landscape_Trees/FeatureServer/0";
        RequestOptions options = new() { Query = new Dictionary<string, object?> { ["f"] = "json" } };

        var response = await ArcGISRest.Request<FeatureLayerInfo>(url, options);

        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Data);
    }

    [TestMethod]
    public async Task TestQueryDemographicData()
    {
        // Test querying demographic data for a point location
        // Using coordinates for downtown Redlands, CA (Esri headquarters area)
        var point = new Point(-117.19498, 34.05383, spatialReference: new SpatialReference(4326));

        try
        {
            var demographics = await ArcGISRest.QueryDemographicData(point);

            Assert.IsNotNull(demographics);

            // Demographics may or may not have results depending on API key permissions
        }
        catch (Exception ex)
        {
            // This test may fail if the API key doesn't have GeoEnrichment permissions
            // In that case, we just verify the method doesn't throw an unexpected exception type
            Assert.IsTrue(ex.Message.Contains("403") || ex.Message.Contains("GeoEnrichment") ||
                ex.Message.Contains("permission") || ex.Message.Contains("token"),
                $"Unexpected error: {ex.Message}");
        }
    }
}

// Simple record to test typed deserialization
public record FeatureLayerInfo(string? Name, string? Type, string? GeometryType);