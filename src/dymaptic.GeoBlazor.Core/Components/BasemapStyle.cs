namespace dymaptic.GeoBlazor.Core.Components;

public partial class BasemapStyle : MapComponent
{
/// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]    
    public BasemapStyle()
    {
    }
    
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="name">
    ///     The id of the basemap style.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-BasemapStyle.html#id">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="language">
    ///     The language of the place labels in the basemap style.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-BasemapStyle.html#language">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="places">
    ///     Indicates whether to display <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-places.html">places</a> with the basemap style.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-BasemapStyle.html#places">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="serviceUrl">
    ///     The <a target="_blank" href="https://developers.arcgis.com/rest/basemap-styles/#service-url">URL</a> to the basemap styles service.
    ///     default "https://basemapstyles-api.arcgis.com/arcgis/rest/services/styles/v2/webmaps"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-BasemapStyle.html#serviceUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="worldview">
    ///     Displays country boundaries and labels based on a specific view of a country.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-BasemapStyle.html#worldview">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public BasemapStyle(
        BasemapStyleName name,
        string? language = null,
        BasemapStylePlace? places = null,
        string? serviceUrl = null,
        string? worldview = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Language = language;
        Name = name;
        Places = places;
        ServiceUrl = serviceUrl;
        Worldview = worldview;
#pragma warning restore BL0005    
    }
    
    /// <summary>
    ///     The identifying name of the basemap style. The values are of the form {Provider}{Style} where provider is "Arcgis" or "osm". Examples include ArcgisNavigation and OsmStandard. See ArcGIS basemap styles and OSM basemap styles for the full list of available styles.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    [CodeGenerationIgnore]
    public BasemapStyleName? Name { get; set; }
    
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

    public async Task SetName(BasemapStyleName name)
    {
        Name = name;
        ModifiedParameters[nameof(Name)] = name;
        if (CoreJsModule is null || Parent is not Basemap basemap)
        {
            return;
        }
        
        BasemapStyle newStyle = new(name, Language, Places, ServiceUrl, Worldview);
        await basemap.SetStyle(newStyle);
    }
}