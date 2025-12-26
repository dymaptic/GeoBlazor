namespace dymaptic.GeoBlazor.Core.Functions;/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Functions.GetHeader.html">GeoBlazor Docs</a>
///     A function to retrieve headers sent from the server.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-request.html#EsriErrorDetails">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string.
/// </param>
/// <remarks>
///    You may reference the following input parameters by name in your JavaScript: headerName.
/// </remarks>
public record GetHeader(string JavaScriptFunction);

