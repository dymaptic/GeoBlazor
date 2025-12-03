namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The TextBoxInput class defines the desired user interface as a single-line text box.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-inputs-TextBoxInput.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class TextBoxInput : TextInput
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public TextBoxInput()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="maxLength">
    /// </param>
    /// <param name="minLength">
    /// </param>
    public TextBoxInput(
        int? maxLength = null,
        int? minLength = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        MaxLength = maxLength;
        MinLength = minLength;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc/>
    public override string Type => "text-box";
}


