namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="items">
///    
/// </param>
public delegate Task<Basemap[]> UpdateBasemapsCallback(IReadOnlyCollection<Basemap> items);

