using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Exceptions;


namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     Add this attribute to any property on any subclass of <see cref="MapComponent" />, and if the user
///     forgets to set that property, this will throw a <see cref="MissingRequiredChildElementException" />
///     or <see cref="MissingRequiredOptionsChildElementException" />. This works for both `[Parameter]`
///     properties as well as Child Components registered with `RegisterChildComponent`
/// </summary>
public class RequiredPropertyAttribute : Attribute
{
    /// <param name="otherOptions">
    ///     If there are two or more acceptable properties that can be set, add the other property names
    ///     here for the validation. Use `nameof(Property)` to ensure you get the right name.
    /// </param>
    public RequiredPropertyAttribute(params string[]? otherOptions)
    {
        OtherOptions = otherOptions;
    }

    /// <summary>
    ///     The other potential properties that can replace this property.
    /// </summary>
    public string[]? OtherOptions { get; }
}

/// <summary>
///     Just a convenience class for <see cref="MapComponent.ValidateRequiredChildren" />
/// </summary>
internal class ComponentOption
{
    public List<string> Options { get; } = new();
    public bool Found { get; set; }
}