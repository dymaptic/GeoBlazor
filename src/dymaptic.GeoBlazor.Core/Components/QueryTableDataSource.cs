namespace dymaptic.GeoBlazor.Core.Components;

public partial class QueryTableDataSource : DynamicDataSource
{


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

}


