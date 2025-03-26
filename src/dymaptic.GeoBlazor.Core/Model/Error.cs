namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Error is a class that enhances the debugging and error handling process. Rather than returning a generic JavaScript error, this Error returns a standardized error object with several properties. The error class can be useful in many scenarios, such as working with promises, the esriRequest module, and many different layers and widgets.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-Error.html">ArcGIS JS API</a>
/// </summary>
/// <param name="Name">
///     A unique error name.
/// </param>
/// <param name="Message">
///     A message describing the details of the error.
/// </param>
/// <param name="Details">
///     The details object provides additional details specific to the error.
/// </param>
public record Error(string Name, string Message, object Details);