namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The BarcodeScannerInput record defines the desired user interface for a barcode or QR code scanner. This input type will default to the TextBoxInput type as the API does not currently support bar code scanning.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-BarcodeScannerInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record BarcodeScannerInput : FormInput
{
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


