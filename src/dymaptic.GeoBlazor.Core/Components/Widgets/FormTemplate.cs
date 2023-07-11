using dymaptic.GeoBlazor.Core.Components.Popups;
using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public class FormTemplate : MapComponent
{
    [Parameter]
    public string? Description { get; set; }
    
    [Parameter]
    public bool? PreserveFieldValuesWhenHidden { get; set; }
    
    [Parameter]
    public string? Title { get; set; }
    
    public HashSet<FormElement>? Elements { get; set; }
    
    public HashSet<ExpressionInfo>? ExpressionInfos { get; set; }

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