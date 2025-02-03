// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    This class is used by the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a> to define the base colors used by widgets and components to render temporary graphics and labels.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-Theme.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class Theme : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public Theme()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="accentColor">
    ///     The base color used to render temporary graphics in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-Theme.html#accentColor">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="textColor">
    ///     The base color used to render temporary labels in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-Theme.html#textColor">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public Theme(
        MapColor? accentColor = null,
        MapColor? textColor = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        AccentColor = accentColor;
        TextColor = textColor;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The base color used to render temporary graphics in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-Theme.html#accentColor">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? AccentColor { get; set; }
    
    /// <summary>
    ///     The base color used to render temporary labels in the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-View.html">View</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-Theme.html#textColor">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? TextColor { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the AccentColor property.
    /// </summary>
    public async Task<MapColor?> GetAccentColor()
    {
        if (CoreJsModule is null)
        {
            return AccentColor;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return AccentColor;
        }

        // get the property value
        MapColor? result = await JsComponentReference!.InvokeAsync<MapColor?>("getProperty",
            CancellationTokenSource.Token, "accentColor");
        if (result is not null)
        {
#pragma warning disable BL0005
             AccentColor = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(AccentColor)] = AccentColor;
        }
         
        return AccentColor;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the TextColor property.
    /// </summary>
    public async Task<MapColor?> GetTextColor()
    {
        if (CoreJsModule is null)
        {
            return TextColor;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return TextColor;
        }

        // get the property value
        MapColor? result = await JsComponentReference!.InvokeAsync<MapColor?>("getProperty",
            CancellationTokenSource.Token, "textColor");
        if (result is not null)
        {
#pragma warning disable BL0005
             TextColor = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(TextColor)] = TextColor;
        }
         
        return TextColor;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the AccentColor property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAccentColor(MapColor value)
    {
#pragma warning disable BL0005
        AccentColor = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(AccentColor)] = value;
        
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
            JsComponentReference, "accentColor", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the TextColor property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTextColor(MapColor value)
    {
#pragma warning disable BL0005
        TextColor = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(TextColor)] = value;
        
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
            JsComponentReference, "textColor", value);
    }
    
#endregion




}
