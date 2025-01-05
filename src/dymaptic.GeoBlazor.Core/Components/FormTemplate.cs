namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     A FormTemplate formats and defines the content of a FeatureForm for a specific Layer or Graphic. A FormTemplate allows the user to access values from feature attributes when a feature in the view is selected.
///     The FormTemplate can be set directly on a FeatureLayer, a FeatureForm, or its view model. The template consists of various elements that display a specific type of form data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-FormTemplate.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class FormTemplate : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public FormTemplate()
    {
    }

    /// <summary>
    ///     Creates a new FormTemplate in code with parameters
    /// </summary>
    /// <param name="title">
    ///     The string template for defining how to format the title displayed at the top of a form.
    /// </param>
    /// <param name="description">
    ///     The description of the form.
    /// </param>
    /// <param name="preserveFieldValuesWhenHidden">
    ///     Indicates whether to retain or clear a form's field element values. Use this property when a field element initially displays as visible but then updates to not display as a result of an applied visibilityExpression.
    /// </param>
    /// <param name="elements">
    ///     An array of form element objects that represent an ordered list of form elements.
    /// </param>
    /// <param name="expressionInfos">
    ///     An array of objects or ExpressionInfo[] that reference Arcade expressions following the specification defined by the Form Constraint Profile or the Form Calculation Profile. Form Constraint expressions must return either true or false. Form Calculation expressions must return a string, date, or a number.
    /// </param>
    public FormTemplate(string? title = null, string? description = null, bool? preserveFieldValuesWhenHidden = null, List<FormElement>? elements = null, List<ExpressionInfo>? expressionInfos = null)
    {
#pragma warning disable BL0005
        Title = title;
        Description = description;
        PreserveFieldValuesWhenHidden = preserveFieldValuesWhenHidden;
        Elements = elements;
        ExpressionInfos = expressionInfos;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The description of the form.
    /// </summary>
    [Parameter]
    public string? Description { get; set; }

    /// <summary>
    ///     Indicates whether to retain or clear a form's field element values. Use this property when a field element initially displays as visible but then updates to not display as a result of an applied visibilityExpression.
    /// </summary>
    [Parameter]
    public bool? PreserveFieldValuesWhenHidden { get; set; }

    /// <summary>
    ///     The string template for defining how to format the title displayed at the top of a form.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }
    /// <summary>
    ///     An array of form element objects that represent an ordered list of form elements.
    ///     Elements are designed to allow the form author the ability to define the layout for fields when collecting and/or editing data.
    /// </summary>
    /// <remarks>
    ///     Nested group elements are not supported.
    /// </remarks>
    public List<FormElement>? Elements { get; set; }
    /// <summary>
    ///     An array of objects or ExpressionInfo[] that reference Arcade expressions following the specification defined by the Form Constraint Profile or the Form Calculation Profile. Form Constraint expressions must return either true or false. Form Calculation expressions must return a string, date, or a number.
    /// </summary>
    public List<ExpressionInfo>? ExpressionInfos { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FormElement formElement:
                Elements ??= new List<FormElement>();
                Elements.Add(formElement);
                break;
            case ExpressionInfo expressionInfo:
                ExpressionInfos ??= new List<ExpressionInfo>();
                ExpressionInfos.Add(expressionInfo);
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
            case FormElement formElement:
                Elements?.Remove(formElement);
                break;
            case ExpressionInfo expressionInfo:
                ExpressionInfos?.Remove(expressionInfo);
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}