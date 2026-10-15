namespace dymaptic.GeoBlazor.Pro.Components;

public partial class FeatureFormViewModel : IViewModel
{
    /// <summary>
    ///     A reference to the associated <see cref = "Map"/>
    /// </summary>
    /// <remarks>
    ///     This property is required if working with Arcade expressions in the FeatureForm that make use of the $map global variable.
    /// </remarks>
    public Guid MapId { get; set; }

}


