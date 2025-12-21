namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///     Object specification for the result of the MapView.HitTest method.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#HitTestResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="ScreenPoint">
///     The screen coordinates (or native mouse event) of the click on the view.
/// </param>
[CodeGenerationIgnore]
public record HitTestResult(ScreenPoint ScreenPoint)
{
    /// <summary>
    ///     Ground intersection result, only applies to SceneViews. The ground hit result will always be returned, even if the ground was excluded from the hitTest.
    /// </summary>
    public GroundIntersectionResult? Ground { get; init; }
    /// <summary>
    ///     An array of result objects returned from the hitTest(). Results are returned when the location of the input screen coordinates intersects a Graphic or media element in the view.
    /// </summary>
    public ViewHit[] Results { get; set; } = [];
}

/// <summary>
///     Object specification for the <see cref="HitTestResult.Results" />.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#ViewHit">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Type">
///     The type of hit result. Currently only supporting "graphic".
/// </param>
/// <param name="MapPoint">
///     The point geometry in the spatial reference of the view corresponding with the input screen coordinates.
/// </param>
[JsonConverter(typeof(ViewHitConverter))]
public record ViewHit(string Type, Point MapPoint);

[ProtoContract]
internal record ProtoViewHitCollection
{
    [ProtoMember(1)]
    public ProtoViewHit[]? ViewHits { get; set; }
}

[ProtoContract]
internal record ProtoViewHit
{
    [ProtoMember(1)]
    public string? Type { get; set; }
    
    [ProtoMember(2)]
    public GeometrySerializationRecord? MapPoint { get; set; }
    
    [ProtoMember(3)]
    public GraphicSerializationRecord? Graphic { get; set; }
    
    [ProtoMember(4)]
    public string? LayerId { get; set; }

    public ViewHit FromSerializationRecord()
    {
        if (Type == "graphic")
        {
            Guid? layerId = null;
            if (Guid.TryParse(LayerId, out Guid layerGuid))
            {
                layerId = layerGuid;
            }
            return new GraphicHit(Graphic!.FromSerializationRecord(), layerId, 
                (Point)MapPoint!.FromSerializationRecord());
        }
        return new ViewHit(Type!, (Point)MapPoint!.FromSerializationRecord());
    }
}


internal class ViewHitConverter : JsonConverter<ViewHit>
{
    public override ViewHit? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Utf8JsonReader cloneReader = reader;
        JsonElement json = JsonDocument.ParseValue(ref reader).RootElement;
        string? type = json.GetProperty("type").GetString();
        JsonElement mapPointJson = json.GetProperty("mapPoint");
        Point? mapPoint = mapPointJson.Deserialize<Point>(options);

        if (type is null || mapPoint is null)
        {
            return null;
        }

        return type switch
        {
            "graphic" => JsonSerializer.Deserialize<GraphicHit>(ref cloneReader, options),
            _ => new ViewHit(type, mapPoint)
        };
    }

    public override void Write(Utf8JsonWriter writer, ViewHit value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}