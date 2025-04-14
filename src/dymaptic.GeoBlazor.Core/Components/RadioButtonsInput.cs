namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-RadioButtonsInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     Coded-value domains are required when using this input type. Previously, fields containing values that weren't compatible with their associated coded-value domain(s) displayed the option and would remove it once a user updated the value. The RadioButtonsInput will now keep the value, but it will not display an option in the user interface.
/// </remarks>
public class RadioButtonsInput : FormInput
{
    /// <inheritdoc/>
    public override string Type => "radio-buttons";

    /// <summary>
    ///     The text used to represent a null value.
    /// </summary>
    [Parameter]
    public string? NoValueOptionLabel { get; set; }

    /// <summary>
    ///     Determines whether a null value option is displayed. This only applies to fields that support null values.
    /// </summary>
    [Parameter]
    public bool? ShowNoValueOption { get; set; }
}

