namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Abstract base record for Input fields in a form element.
/// </summary>
public abstract record FormInput
{
    /// <summary>
    ///     The type of form element input.
    /// </summary>
    public abstract string Type { get; }
}

