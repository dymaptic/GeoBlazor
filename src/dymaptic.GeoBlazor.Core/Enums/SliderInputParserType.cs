namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The type of the slider input parser.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SliderInputParserType>))]
public enum SliderInputParserType
{
#pragma warning disable CS1591
    Average,
    Min,
    Max,
    Tick,
    Value
#pragma warning restore CS1591
}