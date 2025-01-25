namespace dymaptic.GeoBlazor.Core.Components;

public partial class FormTemplate : MapComponent
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


    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FormElement formElement:
                Elements ??= [];
                Elements = [..Elements, formElement];
                break;
            case ExpressionInfo expressionInfo:
                ExpressionInfos ??= [];
                ExpressionInfos = [..ExpressionInfos, expressionInfo];
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
                Elements = Elements?.Except([formElement]).ToList();
                break;
            case ExpressionInfo expressionInfo:
                ExpressionInfos = ExpressionInfos?.Except([expressionInfo]).ToList();
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}