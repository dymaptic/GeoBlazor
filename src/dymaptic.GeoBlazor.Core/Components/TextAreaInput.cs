namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The TextAreaInput record defines the desired user interface as a multi-line text area.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-TextAreaInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public record TextAreaInput : FormInput
{
    /// <inheritdoc/>
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


