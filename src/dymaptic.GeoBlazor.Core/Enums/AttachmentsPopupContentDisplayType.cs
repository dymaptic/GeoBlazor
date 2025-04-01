namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The type of content to display in the AttachmentsPopupContent.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AttachmentsPopupContentDisplayType>))]
public enum AttachmentsPopupContentDisplayType
{
#pragma warning disable CS1591
    Auto,
    Preview,
    List
#pragma warning restore CS1591
}