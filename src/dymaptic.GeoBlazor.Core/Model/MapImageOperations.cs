namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Indicates operations that can be performed on the service.
/// </summary>
/// <param name="SupportsExportMap">
///     Indicates if the service can generate images.
/// </param>
/// <param name="SupportsExportTiles">
///     Indicates if the tiles from the service can be exported.
/// </param>
/// <param name="SupportsIdentify">
///     Indicates if the service supports the identify operation.
/// </param>
/// <param name="SupportsQuery">
///     Indicates if features in the sublayers can be queried.
/// </param>
/// <param name="SupportsTileMap">
///     Indicates if the service exposes a tile map that describes the presence of tiles.
/// </param>
public record MapImageOperations(bool SupportsExportMap, bool SupportsExportTiles, bool SupportsIdentify, 
    bool SupportsQuery, bool SupportsTileMap);