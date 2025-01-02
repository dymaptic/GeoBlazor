namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Placement enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LinePlacement>))]
public enum LinePlacement
{
#pragma warning disable CS1591
    Begin,
    End,
    BeginEnd
#pragma warning restore CS1591
}