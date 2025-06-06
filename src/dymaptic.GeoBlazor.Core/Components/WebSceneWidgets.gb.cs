// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WebSceneWidgets.html">GeoBlazor Docs</a>
///     The widgets object contains widgets that are exposed to the user.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#Widgets">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class WebSceneWidgets : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public WebSceneWidgets()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="timeSlider">
    ///     Time animation is controlled by a configurable <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TimeSlider.html">time slider</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#Widgets">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public WebSceneWidgets(
        WebDocTimeSlider? timeSlider = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        TimeSlider = timeSlider;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Time animation is controlled by a configurable <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-TimeSlider.html">time slider</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#Widgets">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WebDocTimeSlider? TimeSlider { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the TimeSlider property.
    /// </summary>
    public async Task<WebDocTimeSlider?> GetTimeSlider()
    {
        if (CoreJsModule is null)
        {
            return TimeSlider;
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
            return TimeSlider;
        }

        WebDocTimeSlider? result = await JsComponentReference.InvokeAsync<WebDocTimeSlider?>(
            "getTimeSlider", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            TimeSlider = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(TimeSlider)] = TimeSlider;
        }
        
        return TimeSlider;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the TimeSlider property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTimeSlider(WebDocTimeSlider? value)
    {
#pragma warning disable BL0005
        TimeSlider = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(TimeSlider)] = value;
        
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
            JsComponentReference, "timeSlider", value);
    }
    
#endregion

}
