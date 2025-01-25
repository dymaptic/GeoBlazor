// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Range domains specify a valid <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#minValue">minimum</a> and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#maxValue">maximum</a> valid value that can be stored in numeric and date <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Field.html#type">fields</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class RangeDomain : IFieldColumnTemplateDomain,
    IFieldInputDomain,
    ISubtypeDomains
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public RangeDomain()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="maxValue">
    ///     The maximum valid value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#maxValue">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minValue">
    ///     The minimum valid value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#minValue">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     The domain name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public RangeDomain(
        string? maxValue = null,
        string? minValue = null,
        string? name = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        MaxValue = maxValue;
        MinValue = minValue;
        Name = name;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The maximum valid value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#maxValue">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MaxValue { get; set; }
    
    /// <summary>
    ///     The minimum valid value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#minValue">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MinValue { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the MaxValue property.
    /// </summary>
    public async Task<string?> GetMaxValue()
    {
        if (CoreJsModule is null)
        {
            return MaxValue;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MaxValue;
        }

        // get the property value
#pragma warning disable BL0005
        MaxValue = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "maxValue");
#pragma warning restore BL0005
         ModifiedParameters[nameof(MaxValue)] = MaxValue;
        return MaxValue;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MinValue property.
    /// </summary>
    public async Task<string?> GetMinValue()
    {
        if (CoreJsModule is null)
        {
            return MinValue;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return MinValue;
        }

        // get the property value
#pragma warning disable BL0005
        MinValue = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "minValue");
#pragma warning restore BL0005
         ModifiedParameters[nameof(MinValue)] = MinValue;
        return MinValue;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the MaxValue property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMaxValue(string value)
    {
#pragma warning disable BL0005
        MaxValue = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MaxValue)] = value;
        
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
            JsComponentReference, "maxValue", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the MinValue property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMinValue(string value)
    {
#pragma warning disable BL0005
        MinValue = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MinValue)] = value;
        
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
            JsComponentReference, "minValue", value);
    }
    
#endregion




}
