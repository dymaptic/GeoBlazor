namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     Filters features from the layer based on pre-authored parameterized filters. When value is not specified for any
///     parameter in a request, the default value, that is assigned during authoring time, gets used. Requires an ArcGIS
///     Enterprise service 10.5 or greater. This parameter is only supported with MapImageLayer pointing to a map service.
/// </summary>
/// <param name = "Name">
///     The parameter name.
/// </param>
/// <param name = "Value">
///     Single value or array of values.
/// </param>
public record ParameterValue(string Name, object Value);