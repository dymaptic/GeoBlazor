namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Defines an Arcade expression used to create an ExpressionContent element in a PopupTemplate. The expression must
///     evaluate to a dictionary, representing a TextContent, FieldsContent, or MediaContent popup element as defined in
///     the Popup Element web map specification.
///     This expression may access data values from the feature, its layer, or other layers in the map or datastore with
///     the $feature, $layer, $map, and $datastore profile variables. See the Popup Element Arcade Profile specification
///     for more information and examples of valid return dictionaries.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[ProtoContract]
[CodeGenerationIgnore]
public class ElementExpressionInfo: MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ElementExpressionInfo()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="expression">
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/arcade/">Arcade</a> expression evaluating to a dictionary.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html#expression">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="returnType">
    ///     The return type of the expression.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html#returnType">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="title">
    ///     The title used to describe the popup element returned by the expression.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public ElementExpressionInfo(
        string? expression = null,
        string? returnType = null,
        string? title = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Expression = expression;
        ReturnType = returnType;
        Title = title;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The Arcade expression evaluating to a dictionary. The dictionary must represent either a TextContent,
    ///     FieldsContent, or a MediaContent popup content element as defined in the Popup Element web map specification.
    ///     This expression may access data values from the feature, its layer, or other layers in the map or datastore with
    ///     the $feature, $layer, $map, and $datastore profile variables. See the Popup Element Arcade Profile specification
    ///     for more information and examples of valid return dictionaries.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html#expression">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? Expression { get; set; }

    /// <summary>
    ///     The return type of the expression. Content element expressions always return dictionaries.
    ///     For ElementExpressionInfo the returnType is always "dictionary".
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html#returnType">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? ReturnType { get; set; }

    /// <summary>
    ///     The title used to describe the popup element returned by the expression.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-ElementExpressionInfo.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? Title { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Expression property.
    /// </summary>
    public async Task<string?> GetExpression()
    {
        if (CoreJsModule is null)
        {
            return Expression;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Expression;
        }

        // get the property value
#pragma warning disable BL0005
        Expression = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "expression");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Expression)] = Expression;
        return Expression;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ReturnType property.
    /// </summary>
    public async Task<string?> GetReturnType()
    {
        if (CoreJsModule is null)
        {
            return ReturnType;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return ReturnType;
        }

        // get the property value
#pragma warning disable BL0005
        ReturnType = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "returnType");
#pragma warning restore BL0005
         ModifiedParameters[nameof(ReturnType)] = ReturnType;
        return ReturnType;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Title property.
    /// </summary>
    public async Task<string?> GetTitle()
    {
        if (CoreJsModule is null)
        {
            return Title;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Title;
        }

        // get the property value
#pragma warning disable BL0005
        Title = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "title");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Title)] = Title;
        return Title;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Expression property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetExpression(string value)
    {
#pragma warning disable BL0005
        Expression = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Expression)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "expression", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ReturnType property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetReturnType(string value)
    {
#pragma warning disable BL0005
        ReturnType = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ReturnType)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "returnType", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Title property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTitle(string value)
    {
#pragma warning disable BL0005
        Title = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Title)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "title", value);
    }
    
#endregion

}