namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Indicates the layer's supported capabilities.
/// </summary>
/// <param name="ExportMap">
///     Indicates options supported by the exportMap operation. Will be null if the supportsExportMap is false.
/// </param>
/// <param name="ExportTiles">
///     Indicates options supported by the exportTiles operation. Will be null if the supportsExportTiles is false.
/// </param>
/// <param name="Operations">
///     Indicates operations that can be performed on the service.
/// </param>
public record MapImageLayerCapabilities(
    MapImageExportMap ExportMap,
    MapImageExportTiles ExportTiles,
    MapImageOperations Operations);