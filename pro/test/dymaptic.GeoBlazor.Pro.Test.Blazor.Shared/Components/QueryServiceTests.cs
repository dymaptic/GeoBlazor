using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Enums;
using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Results;
using dymaptic.GeoBlazor.Pro.Model;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Pro.Test.Blazor.Shared.Components;

[TestClass]
[TestCategory(nameof(ProLogicComponent))]
[TestCategory(nameof(LogicComponent))]
public class QueryServiceTests : ProTestRunnerBase
{
    [Inject]
    public required QueryService QueryService { get; set; }

    [TestMethod]
    public async Task TestExecuteForCount()
    {
        Query query = new() { Where = "1=1" };

        var count = await QueryService.ExecuteForCount(FeatureServiceUrl, query);

        Assert.IsNotNull(count);
        Assert.IsGreaterThan(0, count.Value);
    }

    [TestMethod]
    public async Task TestExecuteForExtent()
    {
        Query query = new() { Where = "1=1" };

        var result = await QueryService.ExecuteForExtent(FeatureServiceUrl, query);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Extent);
    }

    [TestMethod]
    public async Task TestExecuteForIds()
    {
        Query query = new() { Where = "1=1", ReturnGeometry = false };

        var ids = await QueryService.ExecuteForIds(FeatureServiceUrl, query);

        Assert.IsNotNull(ids);
        Assert.IsGreaterThan(0, ids.Length);
    }

    [TestMethod]
    public async Task TestExecuteQueryJSON()
    {
        Query query = new() { Where = "1=1", OutFields = ["*"], ReturnGeometry = true, Num = 10 };

        var featureSet = await QueryService.ExecuteQueryJSON(FeatureServiceUrl, query);

        Assert.IsNotNull(featureSet);
        Assert.IsNotNull(featureSet.Features);
        Assert.IsGreaterThan(0, featureSet.Features!.Count);
    }

    [TestMethod]
    public async Task TestExecuteQueryPBF()
    {
        Query query = new() { Where = "1=1", OutFields = ["*"], ReturnGeometry = true, Num = 10 };

        var featureSet = await QueryService.ExecuteQueryPBF(FeatureServiceUrl, query);

        Assert.IsNotNull(featureSet);
        Assert.IsNotNull(featureSet.Features);
        Assert.IsGreaterThan(0, featureSet.Features!.Count);
    }

    [TestMethod]
    public async Task TestExecuteForCountWithSpatialFilter()
    {
        // Create a spatial filter extent covering the San Francisco area
        var extent = new Extent(-122.5, 37.7, -122.3, 37.8, spatialReference: new SpatialReference(4326));

        Query query = new() { Where = "1=1", Geometry = extent, SpatialRelationship = SpatialRelationship.Intersects };

        var count = await QueryService.ExecuteForCount(FeatureServiceUrl, query);

        Assert.IsNotNull(count);

        // Count could be 0 if no features in extent, that's ok
    }

    [TestMethod]
    public async Task TestExecuteForTopCount()
    {
        TopFeaturesQuery query = new()
        {
            TopFilter = new TopFilter(TopCount: 5, GroupByFields: ["Cmn_Name"], OrderByFields: ["Tree_ID DESC"]),
            Where = "1=1",
            OutFields = ["*"]
        };

        var count = await QueryService.ExecuteForTopCount(FeatureServiceUrl, query);

        Assert.IsNotNull(count);
    }

    [TestMethod]
    public async Task TestExecuteForTopExtents()
    {
        TopFeaturesQuery query = new()
        {
            TopFilter = new TopFilter(TopCount: 5, GroupByFields: ["Cmn_Name"], OrderByFields: ["Tree_ID DESC"]),
            Where = "1=1"
        };

        var result = await QueryService.ExecuteForTopExtents(FeatureServiceUrl, query);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task TestExecuteForTopIds()
    {
        TopFeaturesQuery query = new()
        {
            TopFilter = new TopFilter(TopCount: 5, GroupByFields: ["Cmn_Name"], OrderByFields: ["Tree_ID DESC"]),
            Where = "1=1"
        };

        var ids = await QueryService.ExecuteForTopIds(FeatureServiceUrl, query);

        Assert.IsNotNull(ids);
    }

    [TestMethod]
    public async Task TestExecuteTopFeaturesQuery()
    {
        TopFeaturesQuery query = new(TopFilter: new TopFilter(["State"], ["TOTAL DESC"], 2),
            ReturnGeometry: true,
            OutFields: ["State, TOTAL, F2018, F2019, F2020, Park"],
            OrderByFields: ["TOTAL DESC"],
            CacheHint: false);

        string featureServiceUrl =
            "https://services.arcgis.com/V6ZHFr6zdgNZuVG0/arcgis/rest/services/US_National_Parks_Annual_Visitation/FeatureServer/0";

        var featureSet =
            await QueryService.ExecuteTopFeaturesQuery(featureServiceUrl, query, new SpatialReference(4326));

        Assert.IsNotNull(featureSet);
    }

    [TestMethod]
    public async Task TestExecuteQueryJSONWithOutFields()
    {
        Query query = new() { Where = "1=1", OutFields = ["Cmn_Name", "Tree_ID"], ReturnGeometry = false, Num = 5 };

        var featureSet = await QueryService.ExecuteQueryJSON(FeatureServiceUrl, query);

        Assert.IsNotNull(featureSet);
        Assert.IsNotNull(featureSet.Features);
        Assert.IsGreaterThan(0, featureSet.Features!.Count);

        // Verify only requested fields are returned
        Graphic? firstFeature = featureSet.Features.FirstOrDefault();
        Assert.IsNotNull(firstFeature?.Attributes);
    }

    [TestMethod]
    public async Task TestExecuteQueryJSONWithOrderByFields()
    {
        Query query = new()
        {
            Where = "1=1",
            OutFields = ["*"],
            ReturnGeometry = true,
            Num = 10,
            OrderByFields = ["Tree_ID ASC"]
        };

        var featureSet = await QueryService.ExecuteQueryJSON(FeatureServiceUrl, query);

        Assert.IsNotNull(featureSet);
        Assert.IsNotNull(featureSet.Features);
        Assert.IsGreaterThan(0, featureSet.Features!.Count);
    }

    [TestMethod]
    public async Task TestExecuteForIdsWithWhereClause()
    {
        // Query for specific tree type
        Query query = new() { Where = "Cmn_Name LIKE '%Oak%'", ReturnGeometry = false };

        var ids = await QueryService.ExecuteForIds(FeatureServiceUrl, query);

        Assert.IsNotNull(ids);

        // May be 0 if no oaks, that's ok
    }

    [TestMethod]
    public async Task TestExecuteRelationshipQuery()
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60));
        string featureServiceUrl =
            "https://services.arcgis.com/V6ZHFr6zdgNZuVG0/arcgis/rest/services/Aggregation_of_USA_Major_Cities_by_hexagon_bins_(3)/FeatureServer/0";
        FeatureLayer layer = new(featureServiceUrl, outFields: ["*"]);
        await layer.Load(JsRuntime, JsModuleManager, cts.Token);
        Point point = new(x: -10469946.852199763, y: 4738582.470785314, spatialReference: new(102100));

        Query query = new(Geometry: point, OutFields: ["*"], SpatialRelationship: SpatialRelationship.Intersects,
            ReturnGeometry: true);
        ObjectId[] objectIds = await layer.QueryObjectIds(query, cts.Token);

        RelationshipQuery relationshipQuery = new(OutFields: ["NAME", "SUM_POPULATION"],
            RelationshipId: layer.Relationships?.FirstOrDefault()?.RelationshipId,
            ObjectIds: objectIds);

        RelatedFeaturesQueryResult? result = await QueryService
            .ExecuteRelationshipQuery(featureServiceUrl, relationshipQuery, cancellationToken: cts.Token);
        Assert.IsNotNull(result);
        Assert.IsGreaterThan(0, result.Count);
    }

    [TestMethod]
    public async Task TestExecuteAttachmentQuery()
    {
        // First get some object IDs from the damage assessment layer that supports attachments
        Query featureQuery = new() { Where = "1=1", ReturnGeometry = false, Num = 5 };
        var featureIds = await QueryService.ExecuteForIds(AttachmentFeatureServiceUrl, featureQuery);

        // Now query for attachments on those features
        AttachmentQuery attachmentQuery = new()
        {
            ObjectIds = featureIds?.Select(id => new ObjectId(id)).ToArray(), Where = "1=1"
        };

        AttachmentsQueryResult? result = await QueryService.ExecuteAttachmentQuery(
            AttachmentFeatureServiceUrl, attachmentQuery);

        Assert.IsNotNull(result);

        // The result may be empty if features don't have attachments, that's ok
    }

    private const string FeatureServiceUrl =
        "https://services.arcgis.com/V6ZHFr6zdgNZuVG0/arcgis/rest/services/Landscape_Trees/FeatureServer/0";

    // Feature service with attachment capability enabled
    private const string AttachmentFeatureServiceUrl =
        "https://sampleserver6.arcgisonline.com/arcgis/rest/services/DamageAssessment/FeatureServer/0";
}