namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
/// The widget legend style, sets the display style of the legend widget.
/// <a target="_blank" href=" https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#style">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LegendStyle : MapComponent
{
    /// <summary>
    /// The Legend style type.
    /// </summary>
    [Parameter]
    public LegendStyleType? Type { get; set; }

    /// <summary>
    /// The legend style layout when there are multiple legends
    /// </summary>
    [Parameter]
    public LegendStyleLayout? Layout { get; set; }
}