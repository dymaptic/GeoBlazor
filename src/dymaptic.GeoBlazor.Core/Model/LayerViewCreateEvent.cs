namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Return event from the <see cref = "MapView.OnJavascriptLayerViewCreate"/> event.
/// </summary>
/// <param name="Layer">
///     A deserialized copy of the <see cref = "Layer"/> object.
/// </param>
/// <param name="LayerView">
///     A deserialized copy of the <see cref = "LayerView"/> object.
/// </param>
[CodeGenerationIgnore]
public record LayerViewCreateEvent(Layer? Layer, LayerView? LayerView);