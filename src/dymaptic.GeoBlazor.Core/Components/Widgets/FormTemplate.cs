using dymaptic.GeoBlazor.Core.Components.Popups;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     A FormTemplate formats and defines the content of a FeatureForm for a specific Layer or Graphic. A FormTemplate allows the user to access values from feature attributes when a feature in the view is selected.
///     The FormTemplate can be set directly on a FeatureLayer, a FeatureForm, or its view model. The template consists of various elements that display a specific type of form data.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-FormTemplate.html">ArcGIS JS API</a>
/// </summary>
public class FormTemplate : MapComponent
{
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
    public HashSet<FormElement>? Elements { get; set; }
    
    /// <summary>
    ///     An array of objects or ExpressionInfo[] that reference Arcade expressions following the specification defined by the Form Constraint Profile or the Form Calculation Profile. Form Constraint expressions must return either true or false. Form Calculation expressions must return a string, date, or a number.
    /// </summary>
    public HashSet<ExpressionInfo>? ExpressionInfos { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FormElement formElement:
                Elements ??= new HashSet<FormElement>();
                
                Elements.Add(formElement);

                break;
            case ExpressionInfo expressionInfo:
                ExpressionInfos ??= new HashSet<ExpressionInfo>();
                
                ExpressionInfos.Add(expressionInfo);

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