// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    A customizable toggle used in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-LayerList.html">LayerList</a> widget that performs a specific action(s) which can be toggled on/off.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionToggle.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class ActionToggle
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ActionToggle()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="title">
    ///     The title of the action.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="id">
    ///     The name of the ID assigned to this action.
    /// </param>
    /// <param name="callbackFunction">
    ///     The action function to perform on click.
    /// </param>
    /// <param name="value">
    ///     Indicates the value of whether the action is toggled on/off.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionToggle.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="active">
    ///     Set this property to `true` to display a spinner icon.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#active">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="disabled">
    ///     Indicates whether this action is disabled.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#disabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="visible">
    ///     Indicates if the action is visible.
    /// </param>
    /// <param name="className">
    ///     This adds a CSS class to the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionButton.html">ActionButton's</a> node.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#className">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="icon">
    ///     Calcite icon used for the action.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html#icon">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public ActionToggle(
        string? title = null,
        string? id = null,
        Func<Task>? callbackFunction = null,
        bool? value = null,
        bool? active = null,
        bool? disabled = null,
        bool? visible = null,
        string? className = null,
        string? icon = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Title = title;
        if (id is not null)
        {
            Id = id;
        }
        if (callbackFunction is not null)
        {
            CallbackFunction = callbackFunction;
        }
        Value = value;
        Active = active;
        Disabled = disabled;
        if (visible is not null)
        {
            Visible = visible.Value;
        }
        ClassName = className;
        Icon = icon;
#pragma warning restore BL0005    
    }
    
    
#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Value property.
    /// </summary>
    public async Task<bool?> GetValue()
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
        bool? result = await CoreJsModule!.InvokeAsync<bool?>("getProperty",
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
    ///    Asynchronously set the value of the Value property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetValue(bool value)
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
