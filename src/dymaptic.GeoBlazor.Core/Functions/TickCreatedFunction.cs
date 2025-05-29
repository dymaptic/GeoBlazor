namespace dymaptic.GeoBlazor.Core.Functions;

/// <summary>
///     Callback delegate that fires for each tick.
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

