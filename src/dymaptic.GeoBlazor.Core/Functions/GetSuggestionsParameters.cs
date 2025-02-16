namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="parameters">
///    
/// </param>
public delegate Task<SuggestResult[]> GetSuggestionsParameters(string parameters);