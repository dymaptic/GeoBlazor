namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Abstract base class for Input fields in a form element.
/// </summary>
public abstract class FormInput: MapComponent
{
    // TODO: V5 - Review and move to a new Namespace/folder
    
    /// <summary>
    ///     The type of form element input.
    /// </summary>
    public abstract string Type { get; }
}

