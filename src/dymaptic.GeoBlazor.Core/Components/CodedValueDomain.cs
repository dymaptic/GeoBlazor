namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///    Information about the coded values belonging to the domain.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-CodedValueDomain.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class CodedValueDomain<T> : Domain,
    IFieldColumnTemplateDomain,
IFieldInputDomain
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public CodedValueDomain()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="codedValues">
    ///     An array of the coded values in the domain.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-CodedValueDomain.html#codedValues">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     The domain name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public CodedValueDomain(
        IReadOnlyList<CodedValue<T>>? codedValues = null,
        string? name = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        CodedValues = codedValues;
        Name = name;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc/>
    public override string Type => "coded-value";
    
        
    /// <summary>
    ///     An array of the coded values in the domain.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<CodedValue<T>>? CodedValues { get; set; }
    
    #region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the CodedValues property.
    /// </summary>
    public async Task<IReadOnlyList<CodedValue<T>>?> GetCodedValues()
    {
        if (CoreJsModule is null)
        {
            return CodedValues;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return CodedValues;
        }

        // get the property value
        IReadOnlyList<CodedValue<T>>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<CodedValue<T>>?>("getProperty",
            CancellationTokenSource.Token, "codedValues");
        if (result is not null)
        {
#pragma warning disable BL0005
             CodedValues = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(CodedValues)] = CodedValues;
        }
         
        return CodedValues;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the CodedValues property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCodedValues(IReadOnlyList<CodedValue<T>>? value)
    {
#pragma warning disable BL0005
        CodedValues = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(CodedValues)] = value;
        
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
            JsComponentReference, "codedValues", value);
    }
    
#endregion

#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the CodedValues property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToCodedValues(params CodedValue<T>[] values)
    {
        CodedValue<T>[] join = CodedValues is null
            ? values
            : [..CodedValues, ..values];
        await SetCodedValues(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the CodedValues property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromCodedValues(params CodedValue<T>[] values)
    {
        if (CodedValues is null)
        {
            return;
        }
        await SetCodedValues(CodedValues.Except(values).ToArray());
    }
    
#endregion

#region Public Methods

    /// <summary>
    ///     Returns the name of the coded-value associated with the specified code.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-CodedValueDomain.html#getName">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    /// <param name="code">
    ///     The code associated with the desired name, e.g. <code>1</code> could be a code used for a returned name of <code>pavement</code>.
    /// </param>
    [ArcGISMethod]
    public async Task<string?> GetName(string code)
    {
        if (JsComponentReference is null) return null;
        
        return await JsComponentReference!.InvokeAsync<string?>(
            "getName", 
            CancellationTokenSource.Token,
            code);
    }
    
#endregion

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CodedValue<T> codedValue:
                CodedValues ??= [];
                CodedValues = [..CodedValues, codedValue];
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
            case CodedValue<T> codedValue:
                CodedValues = CodedValues?.Except([codedValue]).ToList();
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }
}