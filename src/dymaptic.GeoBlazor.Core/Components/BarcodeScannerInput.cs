namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BarcodeScannerInput.html">GeoBlazor Docs</a>
///     The BarcodeScannerInput class defines the desired user interface for a barcode or QR code scanner. This input type will default to the TextBoxInput type as the API does not currently support bar code scanning.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-BarcodeScannerInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class BarcodeScannerInput : FormInput
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public BarcodeScannerInput()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="maxLength">
    /// </param>
    /// <param name="minLength">
    /// </param>
    public BarcodeScannerInput(
        int? maxLength = null,
        int? minLength = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        MaxLength = maxLength;
        MinLength = minLength;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc/>
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


