namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The coded value in a domain.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-CodedValueDomain.html#CodedValue">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class CodedValue<T> : MapComponent
{
    /// <summary>
    ///     The name of the coded value.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    ///     The value of the code.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public T? Code { get; set; }
}