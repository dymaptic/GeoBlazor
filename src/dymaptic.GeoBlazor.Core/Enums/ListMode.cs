using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Indicates how the layer should display in the LayerList widget. The possible values are listed below.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ListMode>))]
public enum ListMode
{
#pragma warning disable CS1591
    Show,
    Hide,
    HideChildren
#pragma warning restore CS1591
}