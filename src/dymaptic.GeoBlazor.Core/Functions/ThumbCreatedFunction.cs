namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="Index">
///    
/// </param>
/// <param name="Value">
///    
/// </param>
/// <param name="ThumbElement">
///    
/// </param>
/// <param name="LabelElement">
///    
/// </param>
public delegate Task ThumbCreatedFunction(int index,
    double value,
    ElementReference thumbElement,
    ElementReference labelElement);

