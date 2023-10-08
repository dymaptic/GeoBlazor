using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     Form elements define what should display within the FormTemplate elements. There are three specific element types:
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-Element.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(FormElementConverter))]
public abstract class FormElement: MapComponent
{
    /// <summary>
    ///     The element's description providing the purpose behind it.
    /// </summary>
    [Parameter]
    public string? Description { get; set; }
    
    /// <summary>
    ///     A string value containing the field alias. This is not to Arcade expressions as the title is used instead.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }
    
    /// <summary>
    ///     A reference to the name of an Arcade expression defined in the expressionInfos of the FormTemplate. The expression must follow the specification defined by the Form Constraint Profile. Expressions may reference field values using the $feature profile variable and must return either true or false.
    /// </summary>
    /// <remarks>
    ///     When this expression evaluates to true, the element is displayed. When the expression evaluates to false the element is not displayed. If no expression is provided, the element is always displayed. Care must be taken when defining a visibility expression for a non-nullable field i.e. to make sure that such fields either have default values or are made visible to users so that they can provide a value before submitting the form.
    ///     The referenced expression must be defined in the form template's expressionInfos. It cannot be set inline within the element object.
    /// </remarks>
    [Parameter]
    public string? VisibilityExpression { get; set; }
    
    /// <summary>
    ///     Indicates the type of form element.
    /// </summary>
    public abstract string Type { get; }
}

/// <summary>
///     A FieldElement form element defines how a feature layer's field participates in the FeatureForm. This is the recommended approach to set field configurations within a feature form's or feature layer's formTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-FieldElement.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FieldElement : FormElement
{
    /// <inheritdoc />
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

    /// <inheritdoc />
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
    
    /// <inheritdoc />
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

/// <summary>
///     A GroupElement form element defines a container that holds a set of form elements that can be expanded, collapsed, or displayed together. This is the preferred way to set grouped field configurations within a FeatureForm or Featurelayer formTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-GroupElement.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class GroupElement : FormElement
{
    /// <inheritdoc />
    public override string Type => "group";
    
    /// <summary>
    ///     An array of field elements to display as grouped. These objects represent an ordered list of form elements.
    /// </summary>
    /// <remarks>
    ///     Nested group elements are not supported.
    /// </remarks>
    public List<FieldElement>? Elements { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldElement fieldElement:
                Elements ??= new List<FieldElement>();
                Elements.Add(fieldElement);

                break;
            
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldElement fieldElement:
                Elements?.Remove(fieldElement);

                break;
            
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        if (Elements is not null)
        {
            foreach (FieldElement element in Elements)
            {
                element.ValidateRequiredChildren();
            }
        }
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     Return types for Arcade expressions.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ArcadeReturnType>))]
public enum ArcadeReturnType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Boolean,
    Date,
    Number,
    String
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member    
}

internal class FormElementConverter : JsonConverter<FormElement>
{
    public override FormElement? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement element = document.RootElement;

        if (element.TryGetProperty("type", out JsonElement typeElement))
        {
            string type = typeElement.GetString() ?? string.Empty;

            return type switch
            {
                "field" => JsonSerializer.Deserialize<FieldElement>(element.GetRawText(), options),
                "group" => JsonSerializer.Deserialize<GroupElement>(element.GetRawText(), options),
                _ => throw new JsonException($"Unknown type: {type}")
            };
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, FormElement value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}