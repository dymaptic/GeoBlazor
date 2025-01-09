namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The style of the basemap from the basemap styles service (v2). The basemap styles service is a ready-to-use location service that serves vector and image tiles representing geographic features around the world.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-BasemapStyle.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BasemapStyle : MapComponent
{
    /// <summary>
    ///     The identifying name of the basemap style. The values are of the form {Provider}{Style} where provider is "Arcgis" or "osm". Examples include ArcgisNavigation and OsmStandard. See ArcGIS basemap styles and OSM basemap styles for the full list of available styles.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public BasemapStyleName Name { get; set; }
    
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