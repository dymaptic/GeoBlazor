namespace dymaptic.GeoBlazor.Core.Components;

public partial class FieldElement : FormElement
{


    /// <inheritdoc/>
    public override string Type => "field";

    /// <summary>
    ///      A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined in the Form Constraint Profile. Expressions may reference field values using the $feature global input and must return either true or false.
    /// </summary>
    /// <remarks>
    ///     A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined in the Form Constraint Profile. Expressions may reference field values using the $feature global input and must return either true or false.
    ///     The referenced expression must be defined in the form template's expressionInfos. It cannot be set inline within the element object.
    /// </remarks>
    [Parameter]
    public string? EditableExpression { get; set; }

    /// <summary>
    ///     A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined in the Form Constraint Profile. Expressions may reference field values using the $feature global input and must return either true or false.
    ///     When this expression evaluates to true and the field value is required, the element must have a valid value in order for the feature to be created or edited. When the expression evaluates to false, the element is not required. If no expression is provided, the required behavior is defined via the required property.
    ///     If the referenced field is non-nullable, the requiredExpression is ignored and the element is always required.
    /// </summary>
    /// <remarks>
    ///     The referenced expression must be defined in the form template's expressionInfos. It cannot be set inline within the element object.
    /// </remarks>
    [Parameter]
    public string? RequiredExpression { get; set; }

    /// <summary>
    ///     The field name as defined by the feature layer. Set this property to indicate which field to edit.
    /// </summary>
    [Parameter]
    public string? FieldName { get; set; }

    /// <summary>
    ///     Contains a hint used to help editors while editing fields. Set this as a temporary placeholder for text/number inputs in either TextAreaInput or TextBoxInput.
    /// </summary>
    [Parameter]
    public string? Hint { get; set; }

}

