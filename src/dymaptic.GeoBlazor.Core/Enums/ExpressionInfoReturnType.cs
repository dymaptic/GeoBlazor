using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Indicates the return type of the Arcade expression.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ExpressionInfoReturnType>))]
public enum ExpressionInfoReturnType
{
#pragma warning disable CS1591
    String,
    Number
#pragma warning restore CS1591
}