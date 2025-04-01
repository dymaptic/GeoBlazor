namespace dymaptic.GeoBlazor.Core.Components;

public partial class Portal : MapComponent
{
    /// <summary>
    ///     The URL to the portal instance.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
    
    /// <summary>
    ///     A helper function that returns an array of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ElevationLayer.html">ElevationsLayers</a> derived from the Portal's <a target="_blank" href="https://enterprise.arcgis.com/en/portal/latest/administer/windows/about-utility-services.htm">Limited Error Raster Compression (LERC) elevation helper service</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-Portal.html#createElevationLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task<IElevationLayer[]?> CreateElevationLayers()
    {
        if (JsComponentReference is null) return null;
        
        if (ProNotFound)
        {
            throw new InvalidOperationException(
                "This method is only available in GeoBlazor Pro. Please use the Pro version of GeoBlazor to unlock this feature.");
        }
        
        return await JsComponentReference!.InvokeAsync<IElevationLayer[]?>(
            "createElevationLayers", 
            CancellationTokenSource.Token);
    }
}