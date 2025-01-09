namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     Filters features from the layer that are within the specified range values. Requires ArcGIS Enterprise services
///     10.5 or greater.This parameter is only supported with MapImageLayer pointing to a map service.
/// </summary>
/// <param name="Name">
///     The range id.
/// </param>
/// <param name="Value">
///     Single value or value range.
/// </param>
public record RangeValue(string Name, object Value);