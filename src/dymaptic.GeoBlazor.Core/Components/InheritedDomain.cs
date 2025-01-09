namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Inherited domains apply to domains at the feature type level. It implies that the domain for a given field at the feature
///     type level is the same as the domain for the field at the layer level.
///     NOTE: Name is not used and will always be null.
/// </summary>
public class InheritedDomain : Domain
{
    /// <inheritdoc />
    public override string Type => "inherited";
}