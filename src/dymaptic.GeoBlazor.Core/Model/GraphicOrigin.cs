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
    int? LayerIndex = null) : VectorTileOrigin(LayerId, ArcGISLayerId, LayerIndex)
{
    internal GraphicOriginSerializationRecord ToSerializationRecord()
    {
        return new GraphicOriginSerializationRecord(LayerId?.ToString(), ArcGISLayerId, LayerIndex);
    }
}

[ProtoContract(Name = "GraphicOrigin")]
internal record GraphicOriginSerializationRecord : MapComponentSerializationRecord
{
    public GraphicOriginSerializationRecord()
    {
    }

    public GraphicOriginSerializationRecord(string? LayerId, string? ArcGISLayerId, int? LayerIndex)
    {
        this.LayerId = LayerId;
        this.ArcGISLayerId = ArcGISLayerId;
        this.LayerIndex = LayerIndex;
    }

    public GraphicOrigin FromSerializationRecord()
    {
        return new GraphicOrigin(LayerId is null ? null : Guid.Parse(LayerId),
            ArcGISLayerId, LayerIndex);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? LayerId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? ArcGISLayerId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public int? LayerIndex { get; init; }
}