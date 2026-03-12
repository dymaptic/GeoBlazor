namespace dymaptic.GeoBlazor.Core.Components;

public partial class SwitchInput : FormInput
{
    /// <inheritdoc/>
    public override string Type => "switch";

    /// <summary>
    ///     Coded value used when the switch state is turned off. Values that are parseable as numbers will be converted.
    /// </summary>
    [Parameter]
    public string? OffValue { get; set; }

    /// <summary>
    ///     Coded value used when the switch state is turned on. Values that are parseable as numbers will be converted.
    /// </summary>
    [Parameter]
    public string? OnValue { get; set; }
}