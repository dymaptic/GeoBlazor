using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;


/// <summary>
/// The stretch type defines a histogram stretch that will be applied to the rasters to enhance their appearance. Stretching improves the appearance of the data by spreading the
/// pixel values along a histogram from the minimum and maximum values defined by their bit depth. 
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StretchType>))]
public enum StretchType
{
#pragma warning disable CS1591
    None,
    StandardDeviation,
    HistogramEqualization,
    MinMax,
    PercentClip,
    Sigmoid
#pragma warning restore CS1591
}