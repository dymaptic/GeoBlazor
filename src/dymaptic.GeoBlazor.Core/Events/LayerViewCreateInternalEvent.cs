namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     Custom return event from the <see cref="MapView.OnJavascriptLayerViewCreate" /> event.
/// </summary>
/// <param name="LayerObjectRef">
///     A JavaScript object reference for the Layer created.
/// </param>
/// <param name="LayerViewObjectRef">
///     A JavaScript object reference for the LayerView created.
/// </param>
/// <param name="LayerGeoBlazorId">
///     The unique GeoBlazor ID for the Layer created.
/// </param>
/// <param name="Layer">
///     A deserialized copy of the <see cref="Layer" /> object.
/// </param>
/// <param name="LayerView">
///     A deserialized copy of the <see cref="LayerView" /> object.
/// </param>
/// <param name="IsBasemapLayer">
///     A boolean value indicating whether the Layer is a basemap layer.
/// </param>
public record LayerViewCreateInternalEvent(IJSObjectReference LayerObjectRef, IJSObjectReference LayerViewObjectRef,
    Guid LayerGeoBlazorId, Layer? Layer, LayerView? LayerView, bool IsBasemapLayer);

