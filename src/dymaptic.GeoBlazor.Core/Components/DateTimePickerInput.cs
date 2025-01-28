namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The DateTimePickerInput class defines the desired user interface for editing date fields in a form.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-DateTimePickerInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class DateTimePickerInput : FormInput
{
    /// <inheritdoc/>
    public override string Type => "datetime-picker";

    /// <summary>
    ///     Indicates if the input should provide an option to select the time. If not provided, the default value is false.
    /// </summary>
    [Parameter]
    public bool? IncludeTime { get; set; }

    /// <summary>
    ///     The maximum date to allow. The number represents the number of milliseconds since epoch (January 1, 1970) in UTC.
    /// </summary>
    [Parameter]
    public long? Max { get; set; }

    /// <summary>
    ///     The minimum date to allow. The number represents the number of milliseconds since epoch (January 1, 1970) in UTC.
    /// </summary>
    [Parameter]
    public long? Min { get; set; }
}


