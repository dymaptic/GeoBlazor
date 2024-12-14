using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Available modes for graphics to be created.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<CreateOptionsMode>))]
public enum CreateOptionsMode
{
#pragma warning disable CS1591
    Hybrid,
    Freehand,
    Click
#pragma warning restore CS1591
}