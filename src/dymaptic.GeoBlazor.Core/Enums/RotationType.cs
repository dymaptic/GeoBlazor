namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Options for rotation type for <see cref="RotationVariable" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RotationType>))]
public enum RotationType
{
#pragma warning disable CS1591
    Geographic,
    Arithmetic
#pragma warning restore CS1591
}