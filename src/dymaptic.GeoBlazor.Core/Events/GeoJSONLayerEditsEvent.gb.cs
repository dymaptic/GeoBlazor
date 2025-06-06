// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Events;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Events.GeoJSONLayerEditsEvent.html">GeoBlazor Docs</a>
///     Event result type for the GeoJSONLayer.OnEdits event.
/// </summary>
/// <param name="AddedFeatures">
///     An array of successfully added features.
/// </param>
/// <param name="DeletedFeatures">
///     An array of successfully deleted features.
/// </param>
/// <param name="UpdatedFeatures">
///     An array of successfully updated features.
/// </param>
public partial record GeoJSONLayerEditsEvent(
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<GeoJSONLayerEditsEventAddedFeatures>? AddedFeatures = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<GeoJSONLayerEditsEventDeletedFeatures>? DeletedFeatures = null,
    [property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    IReadOnlyCollection<GeoJSONLayerEditsEventUpdatedFeatures>? UpdatedFeatures = null);
