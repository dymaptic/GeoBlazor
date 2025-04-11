namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Defines a type that has methods calling to JavaScript but is not a MapComponent
/// </summary>
public interface IInteractiveRecord
{
    Guid Id { get; set; }
    IJSObjectReference? CoreJsModule { get; set; }
    IJSObjectReference? JsComponentReference { get; set; }
    AbortManager? AbortManager { get; set; }
}