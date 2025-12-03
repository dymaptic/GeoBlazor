namespace dymaptic.GeoBlazor.Core.Components;

public partial class RadioButtonsInput : FormInput
{
    /// <inheritdoc/>
    public override string Type => "radio-buttons";

    /// <summary>
    ///     The text used to represent a null value.
    /// </summary>
    [Parameter]
    public string? NoValueOptionLabel { get; set; }

    /// <summary>
    ///     Determines whether a null value option is displayed. This only applies to fields that support null values.
    /// </summary>
    [Parameter]
    public bool? ShowNoValueOption { get; set; }
}

