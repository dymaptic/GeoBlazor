// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BookmarksCapabilities.html">GeoBlazor Docs</a>
///     Specifies the abilities for the Bookmarks widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarksCapabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class BookmarksCapabilities : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public BookmarksCapabilities()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="time">
    ///     Indicates whether the time capability is enabled in the Bookmarks widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarksCapabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public BookmarksCapabilities(
        bool? time = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Time = time;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.BookmarksCapabilities.html#bookmarkscapabilitiestime-property">GeoBlazor Docs</a>
    ///     Indicates whether the time capability is enabled in the Bookmarks widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Bookmarks-BookmarksViewModel.html#BookmarksCapabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Time { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Time property.
    /// </summary>
    public async Task<bool?> GetTime()
    {
        if (CoreJsModule is null)
        {
            return Time;
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
            return Time;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "time");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Time = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Time)] = Time;
        }
         
        return Time;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Time property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTime(bool? value)
    {
#pragma warning disable BL0005
        Time = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Time)] = value;
        
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
            JsComponentReference, "time", value);
    }
    
#endregion

}
