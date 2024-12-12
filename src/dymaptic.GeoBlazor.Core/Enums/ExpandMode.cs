using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
/// The mode in which the Expand widget displays. These modes are listed below.
/// Possible Values:"auto"|"floating"|"drawer"
/// Default Value:"auto"
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ExpandMode>))]
public enum ExpandMode
{
#pragma warning disable CS1591
    Auto,
    Floating,
    Drawer
#pragma warning restore CS1591
}