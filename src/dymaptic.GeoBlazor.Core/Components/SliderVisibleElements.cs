namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The visible elements that are displayed within the widget. This provides the ability to turn individual elements of the widget's display on/off. Alternatively, developers may also use CSS (e.g. display: none) to show/hide elements, such as labels.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Slider.html#VisibleElements">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SliderVisibleElements : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SliderVisibleElements()
    {
    }

    /// <summary>
    ///     Constructor with parameters for use in C# code.
    /// </summary>
    /// <param name="labels">
    ///     Indicates whether to display labels for slider thumbs. By default, labels display input thumb values as floating point values with a precision of two digits. The format of labels can be customized via the labelFormatFunction.
    /// </param>
    /// <param name="rangeLabels">
    ///     Indicates whether to display min or max range values on the slider. The format of labels can be customized via the labelFormatFunction.
    /// </param>
    public SliderVisibleElements(bool? labels = null, bool? rangeLabels = null)
    {
#pragma warning disable BL0005
        Labels = labels;
        RangeLabels = rangeLabels;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     Indicates whether to display labels for slider thumbs. By default, labels display input thumb values as floating point values with a precision of two digits. The format of labels can be customized via the labelFormatFunction.
    ///     Default value: false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Labels { get; set; }

    /// <summary>
    ///     Indicates whether to display min or max range values on the slider. The format of labels can be customized via the labelFormatFunction.
    ///     Default value: false
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RangeLabels { get; set; }
}


