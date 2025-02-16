namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="Value">
///    
/// </param>
/// <param name="TickElement">
///    
/// </param>
/// <param name="LabelElement">
///    
/// </param>
public delegate Task TickCreatedFunction(double value,
    ElementReference tickElement,
    ElementReference labelElement);