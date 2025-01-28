namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The ComboBoxInput record defines the desired user interface for a combo box group.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-ComboBoxInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     Coded-value domains are required when using this input type. Previously, fields containing values that weren't compatible with their associated coded-value domain(s) displayed the option and would remove it once a user updated the value. The ComboBoxInput will now display and keep the value but will disable it.
/// </remarks>
public record ComboBoxInput : FormInput
{
    /// <inheritdoc/>
    public override string Type => "combo-box";

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


