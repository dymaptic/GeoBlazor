namespace dymaptic.GeoBlazor.Pro.Model;

/// <summary>
///    This is a read-only support class that represents a field input in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BatchAttributeForm.html">BatchAttributeForm</a>.
/// </summary>
public partial record FieldInput : InputBase, IEditableInput
{
    /// <inheritdoc />
    public override InputType Type => Pro.Enums.InputType.Field;
    
    /// <inheritdoc />
    public bool? Editable { get; }
    
    /// <inheritdoc />
    public EditType? EditType { get; set; }
}

