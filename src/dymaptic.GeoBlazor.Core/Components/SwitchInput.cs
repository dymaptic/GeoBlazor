namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The SwitchInput class defines the desired user interface for a binary switch or toggle. This should be used when selecting between two options.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-SwitchInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     Coded-value domains are required when using this input type.
/// </remarks>
public class SwitchInput : FormInput
{
    /// <inheritdoc/>
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