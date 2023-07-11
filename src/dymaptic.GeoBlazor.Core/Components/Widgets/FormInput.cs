using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     Abstract base class for Input fields in a form element.
/// </summary>
public abstract class FormInput : MapComponent
{
    /// <summary>
    ///     The type of form element input.
    /// </summary>
    public abstract string Type { get; }
}

/// <summary>
///     The TextBoxInput class defines the desired user interface as a single-line text box.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-TextBoxInput.html">ArcGIS JS API</a>
/// </summary>
public class TextBoxInput : FormInput
{
    /// <inheritdoc />
    public override string Type => "text-box";
    
    /// <summary>
    ///     When set, defines the text input's maximum length.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }
    
    /// <summary>
    ///     When set, defines the text input's minimum length.
    /// </summary>
    [Parameter]
    public int? MinLength { get; set; }
}

/// <summary>
///     The TextAreaInput class defines the desired user interface as a multi-line text area.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-TextAreaInput.html">ArcGIS JS API</a>
/// </summary>
public class TextAreaInput : FormInput
{
    /// <inheritdoc />
    public override string Type => "text-area";
    
    /// <summary>
    ///     When set, defines the text input's maximum length.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }
    
    /// <summary>
    ///     When set, defines the text input's minimum length.
    /// </summary>
    [Parameter]
    public int? MinLength { get; set; }
}

/// <summary>
///     The DateTimePickerInput class defines the desired user interface for editing date fields in a form.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-DateTimePickerInput.html">ArcGIS JS API</a>
/// </summary>
public class DateTimePickerInput : FormInput
{
    /// <inheritdoc />
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

/// <summary>
///     The BarcodeScannerInput class defines the desired user interface for a barcode or QR code scanner. This input type will default to the TextBoxInput type as the API does not currently support bar code scanning.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-BarcodeScannerInput.html">ArcGIS JS API</a>
/// </summary>
public class BarcodeScannerInput : FormInput
{
    /// <inheritdoc />
    public override string Type => "barcode-scanner";
    
    /// <summary>
    ///     When set, defines the text input's maximum length.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }
    
    /// <summary>
    ///     When set, defines the text input's minimum length.
    /// </summary>
    [Parameter]
    public int? MinLength { get; set; }
}

/// <summary>
///     The ComboBoxInput class defines the desired user interface for a combo box group.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-ComboBoxInput.html">ArcGIS JS API</a>
/// </summary>
/// <remarks>
///     Coded-value domains are required when using this input type. Previously, fields containing values that weren't compatible with their associated coded-value domain(s) displayed the option and would remove it once a user updated the value. The ComboBoxInput will now display and keep the value but will disable it.
/// </remarks>
public class ComboBoxInput : FormInput
{
    /// <inheritdoc />
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

/// <summary>
///     https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-RadioButtonsInput.html
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-RadioButtonsInput.html">ArcGIS JS API</a>
/// </summary>
/// <remarks>
///     Coded-value domains are required when using this input type. Previously, fields containing values that weren't compatible with their associated coded-value domain(s) displayed the option and would remove it once a user updated the value. The RadioButtonsInput will now keep the value, but it will not display an option in the user interface.
/// </remarks>
public class RadioButtonsInput : FormInput
{
    /// <inheritdoc />
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

/// <summary>
///     The SwitchInput class defines the desired user interface for a binary switch or toggle. This should be used when selecting between two options.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-SwitchInput.html">ArcGIS JS API</a>
/// </summary>
/// <remarks>
///     Coded-value domains are required when using this input type.
/// </remarks>
public class SwitchInput : FormInput
{
    /// <inheritdoc />
    public override string Type => "switch";
    
    /// <summary>
    ///     Coded value used when the switch state is turned off. Values that are parseable as numbers will be converted.
    /// </summary>
    [Parameter]
    public string? OffValue { get; set; }
    
    /// <summary>
    ///     Coded value used when the switch state is turned on. Values that are parseable as numbers will be converted.
    /// </summary>
    [Parameter]
    public string? OnValue { get; set; }
}