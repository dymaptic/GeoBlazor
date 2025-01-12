namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Indicates options supported by the exportTiles operation. Will be null if the supportsExportTiles is false.
/// </summary>
/// <param name="MaxExportTilesCount">
///     Specifies the maximum number of tiles that can be exported to a cache dataset or a tile package.
/// </param>
public record MapImageExportTiles(int MaxExportTilesCount);