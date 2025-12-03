namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Abstract base class for TextAreaInput and TextBoxInput
/// </summary>
[CodeGenerationIgnore]
public abstract class TextInput: FormInput
{
    /// <summary>
    ///     When set, defines the text input's maximum length.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }

    /// <summary>
    ///     When set, defines the text input's minimum length.
    /// </summary>
    [Parameter]
    public int? MinLength { get; set; }
}