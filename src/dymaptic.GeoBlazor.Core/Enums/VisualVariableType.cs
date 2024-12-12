using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     A collection of <see cref="VisualVariable" /> Types
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<VisualVariableType>))]
public enum VisualVariableType
{
#pragma warning disable CS1591
    Size,
    Rotation,
    Color,
    Opacity
#pragma warning restore CS1591
}