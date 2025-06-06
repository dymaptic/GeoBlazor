// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.LegendStyle.html">GeoBlazor Docs</a>
///     
/// </summary>
public partial class LegendStyle
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public LegendStyle()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="layout">
    ///     When a `card` type is specified, you can specify one of the following layout options.
    ///     default stack
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public LegendStyle(
        LegendStyleLayout? layout = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Layout = layout;
#pragma warning restore BL0005    
    }
    
    
#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Layout property.
    /// </summary>
    public async Task<LegendStyleLayout?> GetLayout()
    {
        if (CoreJsModule is null)
        {
            return Layout;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return Layout;
        }

        // get the property value
        JsNullableEnumWrapper<LegendStyleLayout>? result = await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<LegendStyleLayout>?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "layout");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Layout = (LegendStyleLayout)result.Value.Value!;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Layout)] = Layout;
        }
         
        return Layout;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Layout property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLayout(LegendStyleLayout? value)
    {
#pragma warning disable BL0005
        Layout = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Layout)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "layout", value);
    }
    
#endregion

}
