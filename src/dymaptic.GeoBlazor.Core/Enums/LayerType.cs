namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     An enum of all the possible ArcGIS Layer types.
/// </summary>
[JsonConverter(typeof(LayerTypeConverter))]
public enum LayerType
{
    BaseDynamic,
    BaseElevation,
    BaseTile,
    BingMaps,
    BuildingScene,
    CatalogDynamicGroup,
    CatalogFootprint,
    Catalog,
    CSV,
    Dimension,
    Elevation,
    Feature,
    GeoJSON,
    GeoRSS,
    Graphics,
    Group,
    Imagery,
    ImageryTile,
    IntegratedMesh3DTiles,
    IntegratedMesh,
    KML,
    KnowledgeGraphSub,
    KnowledgeGraph,
    LineOfSight,
    MapImage,
    MapNotes,
    Media,
    OGCFeature,
    OpenStreetMap,
    OrientedImagery,
    PointCloud,
    Route,
    Scene,
    Stream,
    SubtypeGroup,
    Tile,
    Unknown,
    Unsupported,
    VectorTile,
    Video,
    Voxel,
    WCS,
    WebTile,
    WFS,
    WMS,
    WMTS
}

internal class LayerTypeConverter : JsonConverter<LayerType>
{
    public override LayerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.Replace("-", string.Empty);
        
        return value is not null ? Enum.Parse<LayerType>(value, true) : default;
    }

    public override void Write(Utf8JsonWriter writer, LayerType value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case LayerType.CSV:
                writer.WriteStringValue("csv");

                break;
            case LayerType.GeoJSON:
                writer.WriteStringValue("geojson");

                break;
            case LayerType.GeoRSS:
                writer.WriteStringValue("geo-rss");

                break;
            case LayerType.IntegratedMesh3DTiles:
                writer.WriteStringValue("integrated-mesh-3dtiles");

                break;
            case LayerType.KML:
                writer.WriteStringValue("kml");

                break;
            case LayerType.KnowledgeGraphSub:
                writer.WriteStringValue("knowledge-graph-sublayer");

                break;
            case LayerType.OGCFeature:
                writer.WriteStringValue("ogc-feature");

                break;
            case LayerType.WCS:
                writer.WriteStringValue("wcs");

                break;
            case LayerType.WFS:
                writer.WriteStringValue("wfs");

                break;
            case LayerType.WMS:
                writer.WriteStringValue("wms");

                break;
            case LayerType.WMTS:
                writer.WriteStringValue("wmts");

                break;
             default:
                 writer.WriteStringValue(value.ToString().ToKebabCase());

                 break;
        }
    }
}