namespace dymaptic.GeoBlazor.Core.Components;

public partial class PortalBasemapsSource : LocalBasemapsSource
{
    /// <summary>
    ///     An query string used to create a custom basemap gallery group query.
    /// </summary>
    /// <remarks>
    ///     User either <see cref="QueryString" /> or <see cref="QueryParams" />
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? QueryString { get; set; }

    /// <summary>
    ///     An object with key-value pairs used to create a custom basemap gallery group query.
    /// </summary>
    /// <remarks>
    ///     User either <see cref="QueryString" /> or <see cref="QueryParams" />
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? QueryParams { get; set; }

#region Public Methods

    /// <summary>
    ///     Refreshes basemaps by fetching them from the Portal.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery-support-PortalBasemapsSource.html#refresh">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public override async ValueTask Refresh()
    {
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference!.InvokeVoidAsync(
            "refresh", 
            CancellationTokenSource.Token);
        await base.Refresh();
    }
    
#endregion
}