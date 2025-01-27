// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Defines a size stop used for creating a continuous size visualization in a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-SizeVariable.html#stops">size visual variable</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class SizeStop
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SizeStop()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="value">
    ///     Specifies the data value to map to the given <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html#size">size</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="size">
    ///     The size value in points (between `0` and `90`) used to render features with the given <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html#value">value</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html#size">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="label">
    ///     A string value used to label the stop in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html">Legend</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-support-SizeStop.html#label">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public SizeStop(
        double value,
        Dimension? size = null,
        string? label = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Value = value;
        Size = size;
        Label = label;
#pragma warning restore BL0005    
    }
    
    
#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Label property.
    /// </summary>
    public async Task<string?> GetLabel()
    {
        if (CoreJsModule is null)
        {
            return Label;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Label;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "label");
        if (result is not null)
        {
#pragma warning disable BL0005
             Label = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Label)] = Label;
        }
         
        return Label;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Size property.
    /// </summary>
    public async Task<Dimension?> GetSize()
    {
        if (CoreJsModule is null)
        {
            return Size;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Size;
        }

        // get the property value
        Dimension? result = await CoreJsModule!.InvokeAsync<Dimension?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "size");
        if (result is not null)
        {
#pragma warning disable BL0005
             Size = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Size)] = Size;
        }
         
        return Size;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Value property.
    /// </summary>
    public async Task<double?> GetValue()
    {
        if (CoreJsModule is null)
        {
            return Value;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Value;
        }

        // get the property value
        double? result = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "value");
        if (result is not null)
        {
#pragma warning disable BL0005
             Value = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Value)] = Value;
        }
         
        return Value;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Label property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLabel(string value)
    {
#pragma warning disable BL0005
        Label = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Label)] = value;
        
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
            JsComponentReference, "label", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Size property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSize(Dimension value)
    {
#pragma warning disable BL0005
        Size = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Size)] = value;
        
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
            JsComponentReference, "size", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Value property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetValue(double value)
    {
#pragma warning disable BL0005
        Value = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Value)] = value;
        
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
            JsComponentReference, "value", value);
    }
    
#endregion




}
