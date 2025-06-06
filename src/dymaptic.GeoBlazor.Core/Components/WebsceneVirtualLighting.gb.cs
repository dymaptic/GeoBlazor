// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WebsceneVirtualLighting.html">GeoBlazor Docs</a>
///     The virtual lighting object is part of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webscene-Environment.html">webscene/Environment</a> and contains information relating to how a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a> is lit with a virtual light.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webscene-VirtualLighting.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class WebsceneVirtualLighting : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public WebsceneVirtualLighting()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="directShadowsEnabled">
    ///     Indicates whether to show shadows cast by the light source.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webscene-VirtualLighting.html#directShadowsEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public WebsceneVirtualLighting(
        bool? directShadowsEnabled = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        DirectShadowsEnabled = directShadowsEnabled;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Indicates whether to show shadows cast by the light source.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-webscene-VirtualLighting.html#directShadowsEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DirectShadowsEnabled { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the DirectShadowsEnabled property.
    /// </summary>
    public async Task<bool?> GetDirectShadowsEnabled()
    {
        if (CoreJsModule is null)
        {
            return DirectShadowsEnabled;
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
            return DirectShadowsEnabled;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "directShadowsEnabled");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             DirectShadowsEnabled = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(DirectShadowsEnabled)] = DirectShadowsEnabled;
        }
         
        return DirectShadowsEnabled;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the DirectShadowsEnabled property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetDirectShadowsEnabled(bool? value)
    {
#pragma warning disable BL0005
        DirectShadowsEnabled = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(DirectShadowsEnabled)] = value;
        
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
            JsComponentReference, "directShadowsEnabled", value);
    }
    
#endregion

}
