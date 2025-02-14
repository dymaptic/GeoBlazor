namespace dymaptic.GeoBlazor.Core.Components;

public partial class RasterDataSource : DynamicDataSource
{


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


