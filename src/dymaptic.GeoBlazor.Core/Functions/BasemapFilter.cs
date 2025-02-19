namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     This function is used by the filterFunction property to filter basemaps after they are fetched from the Portal.
/// </summary>/// <param name="item">
///    The current Basemap item being assessed in the array.
/// </param>
/// <param name="index">
///    The index of the Basemap being assessed.
/// </param>
/// <param name="array">
///    The array of basemaps being filtered.
/// </param>
public delegate Task<bool> BasemapFilter(Basemap item,
    int index,
    IReadOnlyCollection<Basemap> array);

