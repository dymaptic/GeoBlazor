namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Contains authoring properties of visual variables generated from one of the Smart Mapping methods or sliders.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-AuthoringInfoVisualVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class AuthoringInfoVisualVariable: MapComponent
{
    /// <summary>
    ///     If an age or timeline renderer was generated, indicates the end time of the visualization.
    /// </summary>
    public string? EndTime { get; set; }
    /// <summary>
    ///     Indicates the field name used for generating the data-driven visualization.
    /// </summary>
    public string? Field { get; set; }
    /// <summary>
    ///     Indicates the value of the upper handle if a slider was used to generate the visual variable.
    /// </summary>
    public double? MaxSliderValue { get; set; }
    /// <summary>
    ///     Indicates the value of the lower handle if a slider was used to generate the visual variable.
    /// </summary>
    public double? MinSliderValue { get; set; }
    /// <summary>
    ///     If an age or timeline renderer was generated, indicates the start time of the visualization.
    /// </summary>
    public string? StartTime { get; set; }
    /// <summary>
    ///     If the UI offers the option to display values based on a ratio or percentage, this indicates which selection was made.
    /// </summary>
    public string? Style { get; set; }
    /// <summary>
    ///     Indicates the theme selected by the user when generating a renderer or visual variable with one of the Smart Mapping functions.
    /// </summary>
    public string? Theme { get; set; }
    /// <summary>
    ///     The type of visual variable generated.
    /// </summary>
    public string? Type { get; set; }
    /// <summary>
    ///     If an age or timeline renderer was generated, indicates the time units used.
    /// </summary>
    public string? Units { get; set; }
}