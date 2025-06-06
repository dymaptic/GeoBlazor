// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.WebMapFloorFilter.html">GeoBlazor Docs</a>
///     Floor filtering is controlled by a configurable <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FloorFilter.html">floor filter</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class WebMapFloorFilter : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public WebMapFloorFilter()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="enabled">
    ///     Indicates whether the FloorFilter is active and filtering the displayed content according to the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FloorFilter.html">FloorFilter</a> selection.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="facility">
    ///     Contains the facility ID for the initially selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FloorFilter.html#facility">facility</a> in the floor filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="level">
    ///     Contains the level ID for the initially selected floor, which is used when filtering layers by their configured floor-aware properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="longNames">
    ///     Indicates whether the levels list is showing the long names from longNameField.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minimized">
    ///     Indicates whether the floor filter has been minimized to show only the levels list.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="pinnedLevels">
    ///     Indicates whether the levels portion of the floor filter has been pinned to show the levels list.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="site">
    ///     Contains the site ID for the initially selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FloorFilter.html#site">site</a> in the floor filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public WebMapFloorFilter(
        bool? enabled = null,
        string? facility = null,
        string? level = null,
        bool? longNames = null,
        bool? minimized = null,
        bool? pinnedLevels = null,
        string? site = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Enabled = enabled;
        Facility = facility;
        Level = level;
        LongNames = longNames;
        Minimized = minimized;
        PinnedLevels = pinnedLevels;
        Site = site;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Indicates whether the FloorFilter is active and filtering the displayed content according to the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FloorFilter.html">FloorFilter</a> selection.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }
    
    /// <summary>
    ///     Contains the facility ID for the initially selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FloorFilter.html#facility">facility</a> in the floor filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Facility { get; set; }
    
    /// <summary>
    ///     Contains the level ID for the initially selected floor, which is used when filtering layers by their configured floor-aware properties.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Level { get; set; }
    
    /// <summary>
    ///     Indicates whether the levels list is showing the long names from longNameField.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LongNames { get; set; }
    
    /// <summary>
    ///     Indicates whether the floor filter has been minimized to show only the levels list.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Minimized { get; set; }
    
    /// <summary>
    ///     Indicates whether the levels portion of the floor filter has been pinned to show the levels list.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PinnedLevels { get; set; }
    
    /// <summary>
    ///     Contains the site ID for the initially selected <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-FloorFilter.html#site">site</a> in the floor filter.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebMap.html#FloorFilter">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Site { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Enabled property.
    /// </summary>
    public async Task<bool?> GetEnabled()
    {
        if (CoreJsModule is null)
        {
            return Enabled;
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
            return Enabled;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "enabled");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Enabled = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Enabled)] = Enabled;
        }
         
        return Enabled;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Facility property.
    /// </summary>
    public async Task<string?> GetFacility()
    {
        if (CoreJsModule is null)
        {
            return Facility;
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
            return Facility;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "facility");
        if (result is not null)
        {
#pragma warning disable BL0005
             Facility = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Facility)] = Facility;
        }
         
        return Facility;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Level property.
    /// </summary>
    public async Task<string?> GetLevel()
    {
        if (CoreJsModule is null)
        {
            return Level;
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
            return Level;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "level");
        if (result is not null)
        {
#pragma warning disable BL0005
             Level = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Level)] = Level;
        }
         
        return Level;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the LongNames property.
    /// </summary>
    public async Task<bool?> GetLongNames()
    {
        if (CoreJsModule is null)
        {
            return LongNames;
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
            return LongNames;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "longNames");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             LongNames = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(LongNames)] = LongNames;
        }
         
        return LongNames;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Minimized property.
    /// </summary>
    public async Task<bool?> GetMinimized()
    {
        if (CoreJsModule is null)
        {
            return Minimized;
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
            return Minimized;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "minimized");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Minimized = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Minimized)] = Minimized;
        }
         
        return Minimized;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the PinnedLevels property.
    /// </summary>
    public async Task<bool?> GetPinnedLevels()
    {
        if (CoreJsModule is null)
        {
            return PinnedLevels;
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
            return PinnedLevels;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "pinnedLevels");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             PinnedLevels = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(PinnedLevels)] = PinnedLevels;
        }
         
        return PinnedLevels;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Site property.
    /// </summary>
    public async Task<string?> GetSite()
    {
        if (CoreJsModule is null)
        {
            return Site;
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
            return Site;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "site");
        if (result is not null)
        {
#pragma warning disable BL0005
             Site = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Site)] = Site;
        }
         
        return Site;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Enabled property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetEnabled(bool? value)
    {
#pragma warning disable BL0005
        Enabled = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Enabled)] = value;
        
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
            JsComponentReference, "enabled", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Facility property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetFacility(string? value)
    {
#pragma warning disable BL0005
        Facility = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Facility)] = value;
        
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
            JsComponentReference, "facility", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Level property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLevel(string? value)
    {
#pragma warning disable BL0005
        Level = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Level)] = value;
        
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
            JsComponentReference, "level", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the LongNames property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetLongNames(bool? value)
    {
#pragma warning disable BL0005
        LongNames = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LongNames)] = value;
        
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
            JsComponentReference, "longNames", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Minimized property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMinimized(bool? value)
    {
#pragma warning disable BL0005
        Minimized = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Minimized)] = value;
        
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
            JsComponentReference, "minimized", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the PinnedLevels property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPinnedLevels(bool? value)
    {
#pragma warning disable BL0005
        PinnedLevels = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(PinnedLevels)] = value;
        
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
            JsComponentReference, "pinnedLevels", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Site property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSite(string? value)
    {
#pragma warning disable BL0005
        Site = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Site)] = value;
        
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
            JsComponentReference, "site", value);
    }
    
#endregion

}
