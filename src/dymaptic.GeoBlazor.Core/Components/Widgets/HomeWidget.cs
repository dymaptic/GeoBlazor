namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     Provides a simple widget that switches the View to its initial Viewpoint or a previously defined viewpoint.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Home.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class HomeWidget : Widget
{
    /// <inheritdoc />
    public override string WidgetType => "home";

    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
}