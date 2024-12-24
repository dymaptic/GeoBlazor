namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     An enum of all the possible IImageryRenderer types.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ImageryRendererType>))]
public enum ImageryRendererType
{
    ClassBreaks,
    Flow,
    RasterColormap,
    RasterShadedRelief,
    RasterStretch,
    UniqueValue,
    VectorField,
    
}