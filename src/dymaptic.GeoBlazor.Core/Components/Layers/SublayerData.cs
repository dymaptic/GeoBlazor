namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Describes characteristics of the data in the layer.
/// </summary>
/// <param name="SupportsAttachment">
///     Indicates if attachments are enabled on the layer.
/// </param>
public record SublayerData(bool SupportsAttachment);