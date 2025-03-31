namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The layout of the date label formatter.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DateLabelFormatterLayout>))]
public enum DateLabelFormatterLayout
{
#pragma warning disable CS1591
    Compact,
    Wide
#pragma warning restore CS1591
}