namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     A collection of options to define when creating a Popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Popup.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record PopupOptions
{
    /// <summary>
    ///     Creates a new PopupOptions
    /// </summary>
    /// <param name="dockOptions">
    ///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
    /// </param>
    /// <param name="visibleElements">
    ///     The visible elements that are displayed within the widget.
    /// </param>
    public PopupOptions(PopupDockOptions? dockOptions = null, PopupVisibleElements? visibleElements = null)
    {
        if (dockOptions is not null)
        {
            DockOptions = dockOptions;
        }

        if (visibleElements is not null)
        {
            VisibleElements = visibleElements;
        }
    }

    /// <summary>
    ///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
    /// </summary>
    public PopupDockOptions DockOptions { get; set; } = new();

    /// <summary>
    ///     The visible elements that are displayed within the widget.
    /// </summary>
    public PopupVisibleElements VisibleElements { get; set; } = new();
}