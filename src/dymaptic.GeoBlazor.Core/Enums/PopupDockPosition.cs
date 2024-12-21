namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Dock position in the View.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PopupDockPosition>))]
public enum PopupDockPosition
{
#pragma warning disable CS1591
    Auto,
    TopCenter,
    TopRight,
    TopLeft,
    BottomLeft,
    BottomCenter,
    BottomRight
#pragma warning restore CS1591
}