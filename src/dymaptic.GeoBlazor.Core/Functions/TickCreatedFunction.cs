namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="value">
///    
/// </param>
/// <param name="tickElement">
///    
/// </param>
/// <param name="labelElement">
///    
/// </param>
public delegate Task TickCreatedFunction(double value,
    ElementReference tickElement,
    ElementReference labelElement);

