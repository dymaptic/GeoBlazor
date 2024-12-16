using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Exceptions;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Fires when an error emits during the creation of a LayerView after a layer has been added to the map.
/// </summary>
/// <param name="Layer">
///     The layer in the map for which the view emitting this event failed to create a layer view.
/// </param>
/// <param name="Error">
///     An error object describing why the layer view failed to create.
/// </param>
public record LayerViewCreateErrorEvent(Layer Layer, JavascriptError Error);