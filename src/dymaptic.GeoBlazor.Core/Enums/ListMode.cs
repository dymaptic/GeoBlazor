// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <summary>
///          Indicates how the layer should display in the LayerList widget. The possible values are listed below.
///      </summary>
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
