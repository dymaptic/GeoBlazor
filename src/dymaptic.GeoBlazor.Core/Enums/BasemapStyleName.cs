using System.Reflection;


namespace dymaptic.GeoBlazor.Core.Enums;

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