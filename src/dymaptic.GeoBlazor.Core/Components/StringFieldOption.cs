using System.Text.Json.Serialization;
using dymaptic.GeoBlazor.Core.Serialization;

namespace dymaptic.GeoBlazor.Core.Components;

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