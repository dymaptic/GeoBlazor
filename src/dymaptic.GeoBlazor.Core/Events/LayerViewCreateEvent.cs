using dymaptic.GeoBlazor.Core.Components.Layers;


namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Fires after each layer in the map has a corresponding LayerView created and rendered in the view.
/// </summary>
/// <param name="Layer">
///     The layer in the map for which the layerView was created.
/// </param>
/// <param name="LayerView">
///     The LayerView rendered in the view representing the layer.
/// </param>
public record LayerViewCreateEvent(Layer Layer, LayerView LayerView);