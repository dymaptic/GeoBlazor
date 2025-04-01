namespace dymaptic.GeoBlazor.Core.Components;

public partial class SliderVisibleElements : MapComponent
{


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


