namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Contains authoring properties of visual variables generated from one of the Smart Mapping methods or sliders.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-support-AuthoringInfoVisualVariable.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="EndTime">
///     If an age or timeline renderer was generated, indicates the end time of the visualization.
/// </param>
/// <param name="Field">
///     Indicates the field name used for generating the data-driven visualization.
/// </param>
/// <param name="MaxSliderValue">
///     Indicates the value of the upper handle if a slider was used to generate the visual variable.
/// </param>
/// <param name="MinSliderValue">
///     Indicates the value of the lower handle if a slider was used to generate the visual variable.
/// </param>
/// <param name="StartTime">
///     If an age or timeline renderer was generated, indicates the start time of the visualization.
/// </param>
/// <param name="Style">
///     If the UI offers the option to display values based on a ratio or percentage, this indicates which selection was made.
/// </param>
/// <param name="Theme">
///     Indicates the theme selected by the user when generating a renderer or visual variable with one of the Smart Mapping functions.
/// </param>
/// <param name="Type">
///     The type of visual variable generated.
/// </param>
/// <param name="Units">
///     If an age or timeline renderer was generated, indicates the time units used.
/// </param>
public record AuthoringInfoVisualVariable(string EndTime, string Field, double MaxSliderValue, double MinSliderValue,
    string StartTime, string Style, string Theme, string Type, string Units);