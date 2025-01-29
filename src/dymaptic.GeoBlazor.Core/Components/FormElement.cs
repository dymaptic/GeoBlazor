namespace dymaptic.GeoBlazor.Core.Components;

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