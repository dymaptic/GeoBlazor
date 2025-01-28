namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The TextBoxInput r defiecordnes the desired user interface as a single-line text box.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-TextBoxInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record TextBoxInput : FormInput
{
    /// <inheritdoc/>
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


