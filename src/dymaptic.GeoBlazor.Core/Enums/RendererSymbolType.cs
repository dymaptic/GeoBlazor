namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The type of symbol to generate. Default 2d.
///     <a target="_blank" href="(https://developers.arcgis.com/javascript/latest/api-reference/esri-smartMapping-renderers-color.html#createAgeRenderer">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(RendererSymbolTypeConverter))]
public enum RendererSymbolType
{
    /// <summary>
    ///     2d
    /// </summary>
    TwoDimensional,
    /// <summary>
    ///     3d-flat
    /// </summary>
    ThreeDimensionalFlat,
    /// <summary>
    ///     3d-volumetric
    /// </summary>
    ThreeDimensionalVolumetric,
    /// <summary>
    ///     3d-volumetric-uniform
    /// </summary>
    ThreeDimensionalVolumetricUniform
}

internal class RendererSymbolTypeConverter : JsonConverter<RendererSymbolType>
{
    public override RendererSymbolType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "2d" => RendererSymbolType.TwoDimensional,
            "3d-flat" => RendererSymbolType.ThreeDimensionalFlat,
            "3d-volumetric" => RendererSymbolType.ThreeDimensionalVolumetric,
            "3d-volumetric-uniform" => RendererSymbolType.ThreeDimensionalVolumetricUniform,
            _ => RendererSymbolType.TwoDimensional
        };
    }

    public override void Write(Utf8JsonWriter writer, RendererSymbolType value, JsonSerializerOptions options)
    {
        string type = value switch
        {
            RendererSymbolType.TwoDimensional => "2d",
            RendererSymbolType.ThreeDimensionalFlat => "3d-flat",
            RendererSymbolType.ThreeDimensionalVolumetric => "3d-volumetric",
            RendererSymbolType.ThreeDimensionalVolumetricUniform => "3d-volumetric-uniform",
            _ => string.Empty
        };

        writer.WriteStringValue(type);
    }
}