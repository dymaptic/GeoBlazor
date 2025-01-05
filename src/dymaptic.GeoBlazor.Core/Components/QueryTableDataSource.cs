namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A query table is a feature class or table defined by a SQL query on the fly. Query layers allow both spatial and nonspatial information stored in a database to be easily integrated into map service operations. Since a query table uses SQL to directly query database tables and views, spatial information used by a query table is not required to be in a geodatabase.
///     This data source is useful for scenarios where you have a table containing multiple records that match to a single geometry in either another table or a map service layer. You can use the QueryTableDataSource to select only a subset of those matching records and join them to the table with geometries so records in both tables have a one-to-one relationship with each other.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#QueryTableDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class QueryTableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public QueryTableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new QueryTableDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="query">
    ///     The SQL query used to filter records.
    /// </param>
    /// <param name="oidFields">
    ///     The field name(s) containing the unique IDs for each record in the table. This can be a comma separated list if the query table is used in a JoinTableDataSource.
    /// </param>
    /// <param name="geometryType">
    ///     The geometry type of each record in the table.
    /// </param>
    /// <param name="spatialReference">
    ///     The spatial reference of the geometry of each feature in the table source.
    /// </param>
    public QueryTableDataSource(string workspaceId, string query, string? oidFields = null, FeatureGeometryType? geometryType = null, SpatialReference? spatialReference = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.

        WorkspaceId = workspaceId;
        Query = query;
        OidFields = oidFields;
        GeometryType = geometryType;
        SpatialReference = spatialReference;
#pragma warning restore BL0005 // Set parameter or member default value.

    }

    /// <inheritdoc/>
    public override string Type => "query-table";

    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }

    /// <summary>
    ///     The SQL query used to filter records.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Query { get; set; }

    /// <summary>
    ///     The field name(s) containing the unique IDs for each record in the table. This can be a comma separated list if the query table is used in a JoinTableDataSource.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? OidFields { get; set; }

    /// <summary>
    ///     The geometry type of each record in the table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public FeatureGeometryType? GeometryType { get; set; }

    /// <summary>
    ///     The spatial reference of the geometry of each feature in the table source.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SpatialReference? SpatialReference { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SpatialReference spatialReference:
                SpatialReference = spatialReference;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case SpatialReference _:
                SpatialReference = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    internal override void ValidateRequiredChildren()
    {
        SpatialReference?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}


