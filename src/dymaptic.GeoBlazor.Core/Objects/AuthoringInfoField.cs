

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     A numeric field used for generating a relationship renderer
/// </summary>
/// <param name="Field">
///     The name of a numeric field.
/// </param>
/// <param name="NormalizationField">
///     The name of a numeric field used to normalize the given field. In choropleth visualizations it is best practice to normalize your data values if they haven't already been normalized.
/// </param>
/// <param name="ClassBreakInfos">
///     Describes the class breaks generated for this field.
/// </param>
/// <param name="Label">
///     The label used to describe the field or variable in the legend.
/// </param>
public record AuthoringInfoField(string Field, string? NormalizationField, 
    IReadOnlyCollection<ClassBreakInfo>? ClassBreakInfos, string? Label);
    
/// <summary>
///     Describes the class breaks generated for an <see cref="AuthoringInfoField"/>
/// </summary>
/// <param name="MaxValue">
///     The maximum bound of values to visualize in the given field. If a feature's value is greater than this value, then it will be assigned the default symbol of the renderer.
/// </param>
/// <param name="MinValue">
///     The minimum bound of values to visualize in the given field. If a feature's value is less than this value, then it will be assigned the default symbol of the renderer.
/// </param>
public record ClassBreakInfo(double MaxValue, double MinValue);

/// <summary>
///      Contains summary statistics about the data represented by the renderer.
/// </summary>
/// <param name="Max">
///     The maximum data value of the attribute represented by the renderer. Legends displaying above-and-below themed data will not display values greater than this number.
/// </param>
/// <param name="Min">
///     The minimum data value of the attribute represented by the renderer. Legends displaying above-and-below themed data will not display values smaller than this number.
/// </param>
public record AuthoringInfoStatistics(double Max, double Min);

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