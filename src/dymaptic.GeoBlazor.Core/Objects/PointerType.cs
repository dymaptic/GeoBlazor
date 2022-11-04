using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The types of pointers recognized by the DOM
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PointerType
{
#pragma warning disable CS1591
    Mouse,
    Pen,
    Touch
#pragma warning restore CS1591
}