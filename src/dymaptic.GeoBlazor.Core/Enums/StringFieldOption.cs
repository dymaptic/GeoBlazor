using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     StringFieldOption enumeration.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StringFieldOption>))]
public enum StringFieldOption
{
#pragma warning disable CS1591
    RichText,
    TextArea,
    TextBox
#pragma warning restore CS1591
}