using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Creates a new basemap object. Basemaps can be created from a PortalItem, from a well known basemap ID, or can be
///     used for creating custom basemaps. These basemaps may be created from tiled services you publish to your own
///     server, or from tiled services published by third parties.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Basemap.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Basemap : MapComponent
{
    /// <summary>
    ///     The <see cref="PortalItem" />
    /// </summary>
    public PortalItem? PortalItem { get; set; }

    /// <summary>
    ///     A collection of tile layers that make of the basemap's features.
    /// </summary>
    public HashSet<Layer> Layers { get; set; } = new();
    
    /// <summary>
    ///     The style of the basemap from the basemap styles service (v2). The basemap styles service is a ready-to-use location service that serves vector and image tiles representing geographic features around the world.
    ///     You can use the service to display:
    ///          - Streets and navigation styles
    ///          - Imagery, oceanic, and topographic styles
    ///          - OSM standard and streets styles
    ///          - Creative styles such as nova and blue print
    ///          - Localized place labels
    ///     Use of the basemap style service requires authentication via an API key or user authentication. To learn more about API keys, see the API keys section in the ArcGIS Developer documentation.
    /// </summary>
    public BasemapStyle? Style { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
                }

                break;
            case Layer layer:
                await View!.AddLayer(layer, true);

                break;
            case BasemapStyle style:
                if (!style.Equals(Style))
                {
                    Style = style;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem _:
                PortalItem = null;

                break;
            case Layer layer:
                await View!.RemoveLayer(layer, true);

                break;
            case BasemapStyle:
                Style = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
        Style?.ValidateRequiredChildren();

        foreach (Layer layer in Layers)
        {
            layer.ValidateRequiredChildren();
        }
    }
}

/// <summary>
///     The style of the basemap from the basemap styles service (v2). The basemap styles service is a ready-to-use location service that serves vector and image tiles representing geographic features around the world.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-BasemapStyle.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BasemapStyle : MapComponent
{
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

/// <summary>
///     All styles available from the ArcGIS Basemap Styles service.
///     <a target="_blank" href="https://developers.arcgis.com/rest/basemap-styles/">ArcGIS REST APIs</a>
/// </summary>
[JsonConverter(typeof(EnumMemberConverter<BasemapStyleName>))]
public enum BasemapStyleName
{
#pragma warning disable 1591
    [EnumMember(Value = "arcgis/imagery")]
    ArcgisImagery,
    [EnumMember(Value = "arcgis/imagery/standard")]
    ArcgisImageryStandard,
    [EnumMember(Value = "arcgis/imagery/labels")]
    ArcgisImageryLabels,
    [EnumMember(Value = "arcgis/light-gray")]
    ArcgisLightGray,
    [EnumMember(Value = "arcgis/light-gray/base")]
    ArcgisLightGrayBase,
    [EnumMember(Value = "arcgis/light-gray/labels")]
    ArcgisLightGrayLabels,
    [EnumMember(Value = "arcgis/dark-gray")]
    ArcgisDarkGray,
    [EnumMember(Value = "arcgis/dark-gray/base")]
    ArcgisDarkGrayBase,
    [EnumMember(Value = "arcgis/dark-gray/labels")]
    ArcgisDarkGrayLabels,
    [EnumMember(Value = "arcgis/navigation")]
    ArcgisNavigation,
    [EnumMember(Value = "arcgis/navigation-night")]
    ArcgisNavigationNight,
    [EnumMember(Value = "arcgis/streets")]
    ArcgisStreets,
    [EnumMember(Value = "arcgis/streets-night")]
    ArcgisStreetsNight,
    [EnumMember(Value = "arcgis/streets-relief")]
    ArcgisStreetsRelief,
    [EnumMember(Value = "arcgis/streets-relief/base")]
    ArcgisStreetsReliefBase,
    [EnumMember(Value = "arcgis/topographic")]
    ArcgisTopographic,
    [EnumMember(Value = "arcgis/topographic/base")]
    ArcgisTopographicBase,
    [EnumMember(Value = "arcgis/oceans")]
    ArcgisOceans,
    [EnumMember(Value = "arcgis/oceans/base")]
    ArcgisOceansBase,
    [EnumMember(Value = "arcgis/oceans/labels")]
    ArcgisOceansLabels,
    [EnumMember(Value = "arcgis/terrain")]
    ArcgisTerrain,
    [EnumMember(Value = "arcgis/terrain/base")]
    ArcgisTerrainBase,
    [EnumMember(Value = "arcgis/terrain/detail")]
    ArcgisTerrainDetail,
    [EnumMember(Value = "arcgis/community")]
    ArcgisCommunity,
    [EnumMember(Value = "arcgis/charted-territory")]
    ArcgisChartedTerritory,
    [EnumMember(Value = "arcgis/charted-territory/base")]
    ArcgisChartedTerritoryBase,
    [EnumMember(Value = "arcgis/colored-pencil")]
    ArcgisColoredPencil,
    [EnumMember(Value = "arcgis/nova")]
    ArcgisNova,
    [EnumMember(Value = "arcgis/modern-antique")]
    ArcgisModernAntique,
    [EnumMember(Value = "arcgis/modern-antique/base")]
    ArcgisModernAntiqueBase,
    [EnumMember(Value = "arcgis/midcentury")]
    ArcgisMidcentury,
    [EnumMember(Value = "arcgis/newspaper")]
    ArcgisNewspaper,
    [EnumMember(Value = "arcgis/hillshade/light")]
    ArcgisHillshadeLight,
    [EnumMember(Value = "arcgis/hillshade/dark")]
    ArcgisHillshadeDark,
    [EnumMember(Value = "arcgis/human-geography")]
    ArcgisHumanGeography,
    [EnumMember(Value = "arcgis/human-geography/base")]
    ArcgisHumanGeographyBase,
    [EnumMember(Value = "arcgis/human-geography/detail")]
    ArcgisHumanGeographyDetail,
    [EnumMember(Value = "arcgis/human-geography/labels")]
    ArcgisHumanGeographyLabels,
    [EnumMember(Value = "arcgis/human-geography-dark")]
    ArcgisHumanGeographyDark,
    [EnumMember(Value = "arcgis/human-geography-dark/base")]
    ArcgisHumanGeographyDarkBase,
    [EnumMember(Value = "arcgis/human-geography-dark/detail")]
    ArcgisHumanGeographyDarkDetail,
    [EnumMember(Value = "arcgis/human-geography-dark/labels")]
    ArcgisHumanGeographyDarkLabels,
    [EnumMember(Value = "arcgis/outdoor")]
    ArcgisOutdoor,
    [EnumMember(Value = "osm/standard")]
    OsmStandard,
    [EnumMember(Value = "osm/standard-relief")]
    OsmStandardRelief,
    [EnumMember(Value = "osm/standard-relief/base")]
    OsmStandardReliefBase,
    [EnumMember(Value = "osm/streets")]
    OsmStreets,
    [EnumMember(Value = "osm/streets-relief")]
    OsmStreetsRelief,
    [EnumMember(Value = "osm/streets-relief/base")]
    OsmStreetsReliefBase,
    [EnumMember(Value = "osm/light-gray")]
    OsmLightGray,
    [EnumMember(Value = "osm/light-gray/base")]
    OsmLightGrayBase,
    [EnumMember(Value = "osm/light-gray/labels")]
    OsmLightGrayLabels,
    [EnumMember(Value = "osm/dark-gray")]
    OsmDarkGray,
    [EnumMember(Value = "osm/dark-gray/base")]
    OsmDarkGrayBase,
    [EnumMember(Value = "osm/dark-gray/labels")]
    OsmDarkGrayLabels,
    [EnumMember(Value = "osm/blueprint")]
    OsmBlueprint,
    [EnumMember(Value = "osm/hybrid")]
    OsmHybrid,
    [EnumMember(Value = "osm/hybrid/detail")]
    OsmHybridDetail,
    [EnumMember(Value = "osm/navigation")]
    OsmNavigation,
    [EnumMember(Value = "osm/navigation-dark")]
    OsmNavigationDark
#pragma warning restore 1591
}

internal class EnumMemberConverter<T> : JsonConverter<T> where T: struct, IConvertible
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        string attrVal = value.GetType()
            .GetField(value.ToString()!)!
            .GetCustomAttribute<EnumMemberAttribute>()!.Value!;
        writer.WriteRawValue($"\"{attrVal}\"");
    }
}