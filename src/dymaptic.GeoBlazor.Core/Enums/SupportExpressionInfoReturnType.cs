namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Return types for the <see cref="SupportExpressionInfo"/>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SupportExpressionInfoReturnType>))]
public enum SupportExpressionInfoReturnType
{
#pragma warning disable CS1591
    String,
    Number
#pragma warning restore CS1591
}