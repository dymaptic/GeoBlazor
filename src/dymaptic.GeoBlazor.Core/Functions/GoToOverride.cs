namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Represents a method that can be used to override the default GoTo behavior of the map.
/// </summary>
public delegate Task GoToOverride(GoToOverrideParameters parameters);