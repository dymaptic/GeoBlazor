using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     JavaScript Drag actions
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DragAction
{
#pragma warning disable CS1591
    Start,
    Added,
    Update,
    Removed,
    End
#pragma warning restore CS1591
}