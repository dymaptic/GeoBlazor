namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     Fires after a LayerView is destroyed and is no longer rendered in the view. This happens for example when a layer
///     is removed from the map of the view.
/// </summary>
/// <param name = "Layer">
///     The layer in the map for which the layerView was destroyed.
/// </param>
/// <param name = "LayerView">
///     The LayerView that was destroyed in the view.
/// </param>
public record LayerViewDestroyEvent(Layer Layer, LayerView LayerView);