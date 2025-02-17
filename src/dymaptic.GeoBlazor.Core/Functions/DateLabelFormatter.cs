namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="Value">
///    
/// </param>
/// <param name="Type">
///    
/// </param>
/// <param name="Element">
///    
/// </param>
/// <param name="Layout">
///    
/// </param>
public delegate Task DateLabelFormatter(DateTime value,
    DateLabelFormatterType type,
    ElementReference element,
    DateLabelFormatterLayout layout);

