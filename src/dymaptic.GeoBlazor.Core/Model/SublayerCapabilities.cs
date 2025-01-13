namespace dymaptic.GeoBlazor.Core.Model;
/// <summary>
///     Describes the layer's supported capabilities.
/// </summary>
/// <param name = "Data">
///     Describes characteristics of the data in the layer.
/// </param>
/// <param name = "Operations">
///     Describes operations that can be performed on features in the layer.
/// </param>
public record SublayerCapabilities(SublayerData Data, SublayerOperations Operations);