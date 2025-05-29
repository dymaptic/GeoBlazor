namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="inputElement">
///    
/// </param>
/// <param name="type">
///    
/// </param>
/// <param name="thumbIndex">
///    
/// </param>
public delegate Task InputCreatedFunction(ElementReference inputElement,
    InputCreatedFunctionType type,
    int thumbIndex);

