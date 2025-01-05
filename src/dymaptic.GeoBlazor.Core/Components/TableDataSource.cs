namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A table or feature class that resides in a registered workspace (either a folder or geodatabase). In the case of a geodatabase, if versioned, use version to switch to an alternate geodatabase version.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#TableDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class TableDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public TableDataSource()
    {
    }

    /// <summary>
    ///     Creates a new TableDataSource in code with parameters.
    /// </summary>
    /// <param name = "workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name = "dataSourceName">
    ///     The name of the table in the registered workspace.
    /// </param>
    /// <param name = "gdbVersion">
    ///     References the geodatabase version if multiple versions exist in the geodatabase.
    /// </param>
    public TableDataSource(string workspaceId, string dataSourceName, string? gdbVersion = null)
    {
#pragma warning disable BL0005 // Set parameter or member default value.

        WorkspaceId = workspaceId;
        DataSourceName = dataSourceName;
        GdbVersion = gdbVersion;
#pragma warning restore BL0005 // Set parameter or member default value.

    }

    /// <inheritdoc/>
    public override string Type => "table";

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


