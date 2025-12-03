namespace dymaptic.GeoBlazor.Core.Components;

public partial class DateTimePickerInput : FormInput
{
    /// <inheritdoc/>
    public override string Type => "datetime-picker";

    /// <summary>
    ///     Indicates if the input should provide an option to select the time. If not provided, the default value is false.
    /// </summary>
    [Parameter]
    public bool? IncludeTime { get; set; }

}


