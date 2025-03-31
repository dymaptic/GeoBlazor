namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Possible types of content in popups
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PopupContentType>))]
public enum PopupContentType
{
#pragma warning disable CS1591
    Attachments,
    Custom,
    Expression,
    Fields,
    Media,
    Relationship,
    Text
#pragma warning restore CS1591
}