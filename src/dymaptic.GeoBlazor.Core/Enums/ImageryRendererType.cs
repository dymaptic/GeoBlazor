namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     An enum of all the possible IImageryRenderer types.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ImageryRendererType>))]
public enum ImageryRendererType
{
#pragma warning disable CS1591
    ClassBreaks,
    Flow,
    RasterColormap,
    RasterShadedRelief,
    RasterStretch,
    UniqueValue,
    VectorField
#pragma warning restore CS1591
}