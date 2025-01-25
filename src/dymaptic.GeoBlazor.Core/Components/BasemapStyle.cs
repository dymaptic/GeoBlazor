namespace dymaptic.GeoBlazor.Core.Components;

public partial class BasemapStyle : MapComponent
{

    
    /// <summary>
    ///     The language of the place labels in the basemap style. Choose from a variety of supported languages, including global and local.
    ///     If not set, the app's current locale is used. If the app's locale is not supported by the service, the language will fall back to "global".
    ///     <a target="_blank" href="https://developers.arcgis.com/rest/basemap-styles/#languages">ArcGIS REST APIs</a>
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Language { get; set; }
    
    /// <summary>
    ///     The URL to the basemap styles service.
    ///     Default Value:"https://basemapstyles-api.arcgis.com/arcgis/rest/services/styles/v2/webmaps"
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ServiceUrl { get; set; }
}