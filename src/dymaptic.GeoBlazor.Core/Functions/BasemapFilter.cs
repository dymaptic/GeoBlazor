namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="Item">
///    
/// </param>
/// <param name="Index">
///    
/// </param>
/// <param name="Array">
///    
/// </param>
public delegate Task<bool> BasemapFilter(Basemap item,
    int index,
    IReadOnlyCollection<Basemap> array);