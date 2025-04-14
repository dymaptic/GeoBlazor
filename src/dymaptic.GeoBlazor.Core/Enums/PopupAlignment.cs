namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     Position of the popup in relation to the selected feature. The default behavior is to display above the feature and adjust if not enough room. If needing to explicitly control where the popup displays in relation to the feature, choose an option besides auto.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<PopupAlignment>))]
public enum PopupAlignment
{
#pragma warning disable CS1591
    Auto,
    TopCenter,
    TopRight,
    BottomLeft,
    BottomCenter,
    BottomRight
#pragma warning restore CS1591
}