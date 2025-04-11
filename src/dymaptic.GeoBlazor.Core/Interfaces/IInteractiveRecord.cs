namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Defines a type that has methods calling to JavaScript but is not a MapComponent
/// </summary>
public interface IInteractiveRecord
{
    /// <summary>
    ///     Represents the JavaScript component reference.
    /// </summary>
    public IJSObjectReference? JsComponentReference { get; set; }
    
    /// <summary>
    ///     Allows for transmitting CancellationToken cancel signals to JavaScript.
    /// </summary>
    public AbortManager? AbortManager { get; set; }
    
    /// <summary>
    ///     A unique Id to identify this record in JavaScript.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    ///     Reference to the Core JavaScript module.
    /// </summary>
    public IJSObjectReference? CoreJsModule { get; set; }
}