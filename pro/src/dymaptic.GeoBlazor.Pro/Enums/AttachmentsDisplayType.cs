namespace dymaptic.GeoBlazor.Pro.Enums;

/// <summary>
///     The display type for attachments in the AttachmentsWidget.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AttachmentsDisplayType>))]
public enum AttachmentsDisplayType
{
#pragma warning disable CS1591
    Auto,
    Preview,
    List
#pragma warning restore CS1591
}