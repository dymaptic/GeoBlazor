// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.ElevationInfoMode.html">GeoBlazor Docs</a>
///     Enumeration for ElevationInfoMode
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ElevationInfoMode>))]
public enum ElevationInfoMode
{
#pragma warning disable CS1591
    OnTheGround,
    RelativeToGround,
    AbsoluteHeight,
    RelativeToScene
#pragma warning restore CS1591
}
