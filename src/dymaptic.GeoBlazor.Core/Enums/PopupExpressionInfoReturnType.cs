namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Enumeration for PopupExpressionInfoReturnType
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PopupExpressionInfoReturnType>))]
public enum PopupExpressionInfoReturnType
{
#pragma warning disable CS1591
    Number,
    String
#pragma warning restore CS1591
}