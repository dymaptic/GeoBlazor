namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A file-based raster that resides in a registered raster workspace. The raster may only be displayed in the view, not queried or assigned a renderer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Sublayer.html#RasterDataSource">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class RasterDataSource : DynamicDataSource
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    public RasterDataSource()
    {
    }

    /// <summary>
    ///     Creates a new RasterDataSource in code with parameters.
    /// </summary>
    /// <param name="workspaceId">
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </param>
    /// <param name="dataSourceName">
    ///     The name of the raster in the registered workspace.
    /// </param>
    public RasterDataSource(string workspaceId, string dataSourceName)
    {
#pragma warning disable BL0005 // Set parameter or member default value.

        WorkspaceId = workspaceId;
        DataSourceName = dataSourceName;
#pragma warning restore BL0005 // Set parameter or member default value.

    }

    /// <inheritdoc/>
    public override string Type => "raster";

    /// <summary>
    ///     The workspace where the table resides as defined in the ArcGIS Server Manager.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkspaceId { get; set; }

    /// <summary>
    ///     The name of the raster in the registered workspace.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DataSourceName { get; set; }
}


