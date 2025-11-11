namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///    
/// </summary>
/// <param name="LayerId">
///     GeoBlazor ID for the VectorTileLayer where the graphic originates from.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#VectorTileOrigin">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="ArcGISLayerId">
///     The ArcGIS [unique identifier](https://maplibre.org/maplibre-style-spec/layers/#id) of the style layer in the [vector tile style](https://maplibre.org/maplibre-style-spec).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#VectorTileOrigin">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="LayerIndex">
///     The layer index of the style layer in the [vector tile style](https://maplibre.org/maplibre-style-spec).
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html#VectorTileOrigin">ArcGIS Maps SDK for JavaScript</a>
/// </param>
[CodeGenerationIgnore]
public record GraphicOrigin(
    Guid? LayerId = null,
    string? ArcGISLayerId = null,
    int? LayerIndex = null) : VectorTileOrigin(LayerId, ArcGISLayerId, LayerIndex), 
    IProtobufSerializable<GraphicOriginSerializationRecord>
{
    /// <inheritdoc />
    public GraphicOriginSerializationRecord ToProtobuf()
    {
        return new GraphicOriginSerializationRecord(LayerId?.ToString(), ArcGISLayerId, LayerIndex);
    }
}