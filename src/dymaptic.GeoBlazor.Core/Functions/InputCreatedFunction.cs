namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="InputElement">
///    
/// </param>
/// <param name="Type">
///    
/// </param>
/// <param name="ThumbIndex">
///    
/// </param>
public delegate Task InputCreatedFunction(ElementReference inputElement,
    InputCreatedFunctionType type,
    int thumbIndex);