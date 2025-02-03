// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    A `GroupElement` form element defines a container that holds a set of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-FormTemplate.html#elements">form elements</a> that can be expanded, collapsed, or displayed together.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-GroupElement.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class GroupElement
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public GroupElement()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="description">
    ///     The element's description providing the purpose behind it.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-Element.html#description">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="elements">
    ///     An array of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-FieldElement.html">field</a> and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-RelationshipElement.html">relationship</a> elements to display as grouped.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-GroupElement.html#elements">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="initialState">
    ///     Defines if the group should be expanded or collapsed when the form is initially displayed.
    ///     default expanded
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-GroupElement.html#initialState">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="label">
    ///     A string value containing the field alias.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-Element.html#label">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visibilityExpression">
    ///     A reference to the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-ExpressionInfo.html#name">name</a> of an <a target="_blank" href="https://developers.arcgis.com/javascript/latest/arcade/">Arcade</a> expression defined in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-FormTemplate.html#expressionInfos">expressionInfos</a> of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-FormTemplate.html">FormTemplate</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-Element.html#visibilityExpression">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public GroupElement(
        string? description = null,
        IReadOnlyList<FormElement>? elements = null,
        InitialState? initialState = null,
        string? label = null,
        string? visibilityExpression = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Description = description;
        Elements = elements;
        InitialState = initialState;
        Label = label;
        VisibilityExpression = visibilityExpression;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     An array of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-FieldElement.html">field</a> and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-RelationshipElement.html">relationship</a> elements to display as grouped.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-GroupElement.html#elements">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<FormElement>? Elements { get; set; }
    
    /// <summary>
    ///     Defines if the group should be expanded or collapsed when the form is initially displayed.
    ///     default expanded
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-GroupElement.html#initialState">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InitialState? InitialState { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Elements property.
    /// </summary>
    public async Task<IReadOnlyList<FormElement>?> GetElements()
    {
        if (CoreJsModule is null)
        {
            return Elements;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Elements;
        }

        // get the property value
        IReadOnlyList<FormElement>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<FormElement>?>("getProperty",
            CancellationTokenSource.Token, "elements");
        if (result is not null)
        {
#pragma warning disable BL0005
             Elements = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Elements)] = Elements;
        }
         
        return Elements;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the InitialState property.
    /// </summary>
    public async Task<InitialState?> GetInitialState()
    {
        if (CoreJsModule is null)
        {
            return InitialState;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return InitialState;
        }

        // get the property value
        InitialState? result = await JsComponentReference!.InvokeAsync<InitialState?>("getProperty",
            CancellationTokenSource.Token, "initialState");
        if (result is not null)
        {
#pragma warning disable BL0005
             InitialState = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(InitialState)] = InitialState;
        }
         
        return InitialState;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Elements property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetElements(IReadOnlyList<FormElement> value)
    {
#pragma warning disable BL0005
        Elements = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Elements)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "elements", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the InitialState property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetInitialState(InitialState value)
    {
#pragma warning disable BL0005
        InitialState = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(InitialState)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "initialState", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the Elements property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToElements(params FormElement[] values)
    {
        FormElement[] join = Elements is null
            ? values
            : [..Elements, ..values];
        await SetElements(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the Elements property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromElements(params FormElement[] values)
    {
        if (Elements is null)
        {
            return;
        }
        await SetElements(Elements.Except(values).ToArray());
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FormElement elements:
                Elements ??= [];
                if (!Elements.Contains(elements))
                {
                    Elements = [..Elements, elements];
                    
                    ModifiedParameters[nameof(Elements)] = Elements;
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FormElement elements:
                Elements = Elements?.Where(e => e != elements).ToList();
                
                ModifiedParameters[nameof(Elements)] = Elements;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        if (Elements is not null)
        {
            foreach (FormElement child in Elements)
            {
                child.ValidateRequiredGeneratedChildren();
            }
        }
        base.ValidateRequiredGeneratedChildren();
    }
      
}
