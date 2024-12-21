namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The types of pointers recognized by the DOM
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PointerType>))]
public enum PointerType
{
#pragma warning disable CS1591
    Mouse,
    Pen,
    Touch
#pragma warning restore CS1591
}