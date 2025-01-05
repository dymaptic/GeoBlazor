namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Compass widget indicates where north is in relation to the current view rotation or camera heading. Clicking
///     the Compass widget rotates the view to face north (heading = 0). This widget is added to a SceneView by default.
///     The icon for the Compass widget is determined based upon the view's spatial reference. If the view's spatial
///     reference is not Web Mercator or WGS84 a dial icon will be used, however when the spatial reference is Web Mercator
///     or WGS84 the icon will be a north arrow.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Compass.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class CompassWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Compass;

    /// <summary>
    ///     The widget's default label.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }
}