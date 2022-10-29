using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Exceptions;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The error result of a failed layerview-create event.
/// </summary>
/// <param name="Layer">
///     The <see cref="Layer"/> that failed to be added to the view.
/// </param>
/// <param name="Exception">
///     The Javascript error wrapped in a .NET Exception.
/// </param>
public record LayerViewCreateErrorResult(Layer Layer, JavascriptException Exception);