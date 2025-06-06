// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Orientation.html">GeoBlazor Docs</a>
///     The z axis orientation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Compass-CompassViewModel.html#Orientation">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class Orientation : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Orientation()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="z">
    ///     z axis orientation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Compass-CompassViewModel.html#Orientation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Orientation(
        double? z = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Z = z;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Orientation.html#orientationz-property">GeoBlazor Docs</a>
    ///     z axis orientation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Compass-CompassViewModel.html#Orientation">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Z { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Z property.
    /// </summary>
    public async Task<double?> GetZ()
    {
        if (CoreJsModule is null)
        {
            return Z;
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
            return Z;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "z");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Z = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Z)] = Z;
        }
         
        return Z;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Z property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetZ(double? value)
    {
#pragma warning disable BL0005
        Z = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Z)] = value;
        
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
            JsComponentReference, "z", value);
    }
    
#endregion

}
