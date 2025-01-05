namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     A FieldElement form element defines how a feature layer's field participates in the FeatureForm. This is the recommended approach to set field configurations within a feature form's or feature layer's formTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-FieldElement.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FieldElement : FormElement
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public FieldElement()
    {
    }

    /// <summary>
    ///     Creates a new FieldElement in code with parameters
    /// </summary>
    /// <param name = "fieldName">
    ///     The field name as defined by the feature layer. Set this property to indicate which field to edit.
    /// </param>
    /// <param name = "label">
    ///     The string template for defining how to format the title displayed at the top of a form.
    /// </param>
    /// <param name = "description">
    ///     The description of the form.
    /// </param>
    /// <param name = "hint">
    ///     Contains a hint used to help editors while editing fields. Set this as a temporary placeholder for text/number inputs in either TextAreaInput or TextBoxInput.
    /// </param>
    /// <param name = "editableExpression">
    ///     A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined in the Form Constraint Profile. Expressions may reference field values using the $feature global input and must return either true or false.
    /// </param>
    /// <param name = "requiredExpression">
    ///     A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined in the Form Constraint Profile. Expressions may reference field values using the $feature global input and must return either true or false.
    /// </param>
    /// <param name = "valueExpression">
    ///     A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined in the Form Calculation Profile. This expression references field values within an individual feature or in other layers and must return either a date, number, or string value.
    /// </param>
    /// <param name = "domain">
    ///     The coded value domain or range domain of the field.
    /// </param>
    /// <param name = "input">
    ///     The input to use for the element. The client application is responsible for defining the default user interface.
    /// </param>
    public FieldElement(string? fieldName, string? label = null, string? description = null, string? hint = null, string? editableExpression = null, string? requiredExpression = null, string? valueExpression = null, Domain? domain = null, FormInput? input = null)
    {
#pragma warning disable BL0005
        FieldName = fieldName;
        Label = label;
        Description = description;
        Hint = hint;
        EditableExpression = editableExpression;
        RequiredExpression = requiredExpression;
        ValueExpression = valueExpression;
        Domain = domain;
        Input = input;
#pragma warning restore BL0005
    }

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
    /// <summary>
    ///     A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined in the Form Calculation Profile. This expression references field values within an individual feature or in other layers and must return either a date, number, or string value.
    /// </summary>
    /// <remarks>
    ///     Once the expression evaluates, the form's field value updates to the expressions' result.
    ///     It is required to set the view property when instantiating a FeatureForm widget and using expressions that use the $map variable.
    ///     The referenced expression must be defined in the form template's expressionInfos. It cannot be set inline within the element object.
    /// </remarks>
    public string? ValueExpression { get; internal set; }
    /// <summary>
    ///     The coded value domain or range domain of the field.
    /// </summary>
    public Domain? Domain { get; set; }
    /// <summary>
    ///     The input to use for the element. The client application is responsible for defining the default user interface.
    /// </summary>
    public FormInput? Input { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Domain domain:
                Domain = domain;
                break;
            case FormInput formInput:
                Input = formInput;
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Domain _:
                Domain = null;
                break;
            case FormInput _:
                Input = null;
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}


