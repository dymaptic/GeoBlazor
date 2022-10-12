using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     A collection of options to define when creating a Popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">ArcGIS JS API</a>
/// </summary>
public class PopupOptions
{
    /// <summary>
    ///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
    /// </summary>
    public PopupDockOptions DockOptions { get; set; } = new();

    /// <summary>
    ///     The visible elements that are displayed within the widget.
    /// </summary>
    public PopupVisibleElements VisibleElements { get; set; } = new();
}

/// <summary>
///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices. When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned to it. Rather it is placed in one of the corners of the view or to the top or bottom of it. This property allows the developer to set various options for docking the popup.
/// </summary>
public class PopupDockOptions
{
    /// <summary>
    ///     If true, displays the dock button. If false, hides the dock button from the popup.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ButtonEnabled { get; set; }
}

/// <summary>
///     The visible elements that are displayed within the widget. This provides the ability to turn individual elements of the widget's display on/off.
/// </summary>
public class PopupVisibleElements
{
    /// <summary>
    ///     Indicates whether to display a close button on the popup dialog. Default value is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CloseButton { get; set; }

    /// <summary>
    ///     Indicates whether pagination for feature navigation will be displayed. Default value is true. This allows the user to scroll through various selected features using pagination arrows.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FeatureNavigation { get; set; }
}