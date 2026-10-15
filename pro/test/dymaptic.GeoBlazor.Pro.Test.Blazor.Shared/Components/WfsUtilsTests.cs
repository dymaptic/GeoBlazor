using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Options;
using dymaptic.GeoBlazor.Pro.Model;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;

[TestClass]
[TestCategory("ProLogicComponent")]
[TestCategory(nameof(LogicComponent))]
public class WfsUtilsTests : ProTestRunnerBase
{
    [Inject]
    public required WfsUtils WfsUtils { get; set; }

    [TestMethod]
    public async Task TestGetCapabilities()
    {
        // Get WFS capabilities from a public WFS service
        WFSCapabilities? capabilities = await WfsUtils.GetCapabilities(WfsServiceUrl);

        Assert.IsNotNull(capabilities);
        Assert.IsNotNull(capabilities.FeatureTypes);
        Assert.IsGreaterThan(0, capabilities.FeatureTypes.Count);
    }

    [TestMethod]
    public async Task TestGetCapabilitiesWithOptions()
    {
        // Get WFS capabilities with options
        var options = new WfsUtilsGetCapabilitiesOptions();
        WFSCapabilities? capabilities = await WfsUtils.GetCapabilities(WfsServiceUrl, options);

        Assert.IsNotNull(capabilities);
        Assert.IsNotNull(capabilities.FeatureTypes);
        Assert.IsGreaterThan(0, capabilities.FeatureTypes.Count);
    }

    [TestMethod]
    public async Task TestGetWFSLayerInfo()
    {
        // First get capabilities
        WFSCapabilities? capabilities = await WfsUtils.GetCapabilities(WfsServiceUrl);
        Assert.IsNotNull(capabilities);
        Assert.IsNotNull(capabilities.FeatureTypes);
        Assert.IsGreaterThan(0, capabilities.FeatureTypes.Count);

        // Get the first feature type name
        WFSFeatureType firstFeature = capabilities.FeatureTypes.First();
        string? featureName = firstFeature.Name;

        // Get layer info for that feature type
        WFSLayerInfo? layerInfo = await WfsUtils.GetWFSLayerInfo(capabilities, featureName);

        Assert.IsNotNull(layerInfo);
    }

    [TestMethod]
    public async Task TestGetWFSLayerInfoWithoutName()
    {
        // Get capabilities first
        WFSCapabilities? capabilities = await WfsUtils.GetCapabilities(WfsServiceUrl);
        Assert.IsNotNull(capabilities);

        // Get layer info without specifying name (should use first layer)
        WFSLayerInfo? layerInfo = await WfsUtils.GetWFSLayerInfo(capabilities);

        Assert.IsNotNull(layerInfo);
    }

    [TestMethod]
    public async Task TestGetLayerFromLayerInfo()
    {
        // Get capabilities
        WFSCapabilities? capabilities = await WfsUtils.GetCapabilities(WfsServiceUrl);
        Assert.IsNotNull(capabilities);

        // Get layer info
        WFSLayerInfo? layerInfo = await WfsUtils.GetWFSLayerInfo(capabilities);
        Assert.IsNotNull(layerInfo);

        // Convert to WFSLayer
        WFSLayer? layer = await WfsUtils.GetLayerFromLayerInfo(layerInfo);

        Assert.IsNotNull(layer);
    }

    [TestMethod]
    public async Task TestFullWfsWorkflow()
    {
        // Complete workflow: GetCapabilities -> GetWFSLayerInfo -> GetLayerFromLayerInfo
        // This mirrors the workflow in the WFSUtils sample page

        // Step 1: Get capabilities
        WFSCapabilities? capabilities = await WfsUtils.GetCapabilities(WfsServiceUrl);
        Assert.IsNotNull(capabilities);
        Assert.IsNotNull(capabilities.FeatureTypes);
        Assert.IsGreaterThan(0, capabilities.FeatureTypes.Count);

        // Step 2: Get layer info for a specific feature type
        WFSFeatureType featureType = capabilities.FeatureTypes.First();
        WFSLayerInfo? layerInfo = await WfsUtils.GetWFSLayerInfo(capabilities, featureType.Name);
        Assert.IsNotNull(layerInfo);

        // Step 3: Create WFSLayer from layer info
        WFSLayer? layer = await WfsUtils.GetLayerFromLayerInfo(layerInfo);
        Assert.IsNotNull(layer);
    }

    // UK Office for National Statistics WFS service (same as used in sample)
    private const string WfsServiceUrl =
        "https://dservices1.arcgis.com/ESMARspQHYMw9BZ9/arcgis/services/Counties_May_2023_Boundaries_EN_BUC/WFSServer?service=wfs";
}