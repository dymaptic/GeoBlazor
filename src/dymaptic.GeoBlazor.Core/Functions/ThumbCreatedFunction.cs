namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="index">
///    
/// </param>
/// <param name="value">
///    
/// </param>
/// <param name="thumbElement">
///    
/// </param>
/// <param name="labelElement">
///    
/// </param>
public delegate Task ThumbCreatedFunction(int index,
    double value,
    ElementReference thumbElement,
    ElementReference labelElement);

