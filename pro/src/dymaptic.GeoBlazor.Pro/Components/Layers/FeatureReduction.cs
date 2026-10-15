namespace dymaptic.GeoBlazor.Pro.Components.Layers;

/// <summary>
///     Feature reduction is a technique to reduce the number of features that are rendered on the map.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#featureReduction">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(FeatureReductionConverter))]
public abstract class FeatureReduction : MapComponent, IFeatureReduction
{
    /// <summary>
    ///     The type of Feature Reduction
    /// </summary>
    public abstract string Type { get; }
}



internal class FeatureReductionConverter : JsonConverter<FeatureReduction>
{
    public override FeatureReduction? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // clone and then read the type
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement element = document.RootElement.Clone();
        string type = element.GetProperty("type").GetString()!;
        return type switch
        {
            "binning" => JsonSerializer.Deserialize<FeatureReductionBinning>(element.GetRawText(), options),
            "cluster" => JsonSerializer.Deserialize<FeatureReductionCluster>(element.GetRawText(), options),
            "selection" => JsonSerializer.Deserialize<FeatureReductionSelection>(element.GetRawText(), options),
            _ => throw new JsonException($"Unknown FeatureReduction type: {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, FeatureReduction value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}