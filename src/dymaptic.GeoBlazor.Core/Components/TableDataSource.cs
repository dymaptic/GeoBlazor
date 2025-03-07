namespace dymaptic.GeoBlazor.Core.Components;

public partial class TableDataSource : DynamicDataSource
{


    /// <inheritdoc/>
    public override DynamicDataSourceType Type => DynamicDataSourceType.Table;

    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }

    /// <summary>
    ///     The name of the table in the registered workspace.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DataSourceName { get; set; }

    /// <summary>
    ///     References the geodatabase version if multiple versions exist in the geodatabase.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GdbVersion { get; set; }
}


