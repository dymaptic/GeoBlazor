namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(VisualVariableConverter))]
public abstract partial class VisualVariable : MapComponent
{
    /// <summary>
    ///     The visual variable type.
    /// </summary>
    public abstract VisualVariableType Type { get; }

    
    /// <summary>
    ///     An Arcade expression following the specification defined by the Arcade Visualization Profile. Expressions in visual variables may reference field values using the $feature profile variable and must return a number.
    ///     The values returned from this expression are the data used to drive the visualization as defined in the stops. This takes precedence over field. Therefore, this property is typically used as an alternative to field in visual variables.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ValueExpression { get; set; }
    
    /// <summary>
    ///     The title identifying and describing the associated Arcade expression as defined in the valueExpression property. This is displayed as the title of the corresponding visual variable in the Legend in the absence of a provided title in the legendOptions property.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ValueExpressionTitle { get; set; }

}