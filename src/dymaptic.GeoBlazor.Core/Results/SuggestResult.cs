namespace dymaptic.GeoBlazor.Core.Results;

/// <summary>
///    The result object returned from a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#suggest">suggest()</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SuggestResult">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="Key">
///     The key related to the suggest result.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SuggestResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="Text">
///     The string name of the suggested location to geocode.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SuggestResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
/// <param name="SourceIndex">
///     The index of the currently selected result.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search.html#SuggestResult">ArcGIS Maps SDK for JavaScript</a>
/// </param>
[CodeGenerationIgnore]
public record SuggestResult(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [property:JsonConverter(typeof(NumberToStringConverter))]
    string? Key = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    string? Text = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    int? SourceIndex = null);