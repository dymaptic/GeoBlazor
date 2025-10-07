namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The Expand widget acts as a clickable button for opening a widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Expand.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class ExpandWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Expand;

    /// <summary>
    ///     Internal mark for GeoBlazor rendering
    /// </summary>
    protected override bool Hidden => true;
    
    /// <summary>
    ///     Tooltip to display to indicate Expand widget can be expanded
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExpandTooltip { get; set; }

    /// <summary>
    ///     Tooltip to display to indicate Expand widget can be collapsed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CollapseTooltip { get; set; }

    /// <summary>
    ///     Automatically collapses the expand widget instance when the view's viewpoint updates.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoCollapse { get; set; }

    /// <summary>
    ///     When true, the Expand widget will close after the Escape key is pressed when the keyboard focus is within its content.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CloseOnEsc { get; set; }
    
    /// <summary>
    ///     This value associates two or more Expand widget instances with each other, allowing one instance to auto collapse when another instance in the same group is expanded.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }

    /// <summary>
    ///     The custom HTML content to display within the expanded Expand widget.
    /// </summary>
    /// <remarks>
    ///     You can now define custom HTML inline in Razor markup inside an Expand widget, instead of using this parameter. 
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HtmlContent { get; set; }

    /// <summary>
    ///     The content to display within the expanded Expand widget.
    /// </summary>
    /// <remarks>
    ///     If adding a Slider, HistogramRangeSlider, or TimeSlider as content to the Expand widget, the container or parent container of the widget must have a width set in CSS for it to render inside the Expand widget.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Widget? WidgetContent { get; set; }

    /// <summary>
    ///     Indicates whether the widget is currently expanded or not.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Expanded { get; set; }

    /// <summary>
    ///    Calcite icon used when the widget is collapsed. Will automatically use the content's icon if it has one.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExpandIcon { get; set; }

    /// <summary>
    ///    Calcite icon used to style the Expand button when the content can be collapsed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CollapseIcon { get; set; }

    /// <summary>
    ///   The mode in which the widget displays.
    /// </summary>
    [Parameter]
    public ExpandMode Mode { get; set; } = ExpandMode.Auto;
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Expand property.
    /// </summary>
    public async Task<bool?> GetExpanded()
    {
        if (CoreJsModule is null)
        {
            return Expanded;
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
            return Expanded;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "expanded");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
            Expanded = result.Value.Value;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Expanded)] = Expanded;
        }
         
        return Expanded;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the CollapseIcon property.
    /// </summary>
    public async Task<string?> GetCollapseIcon()
    {
        if (CoreJsModule is null)
        {
            return CollapseIcon;
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
            return CollapseIcon;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getCollapseIcon",
            CancellationTokenSource.Token);
        if (result is not null)
        {
#pragma warning disable BL0005
            CollapseIcon = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(CollapseIcon)] = CollapseIcon;
        }
         
        return CollapseIcon;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the CollapseTooltip property.
    /// </summary>
    public async Task<string?> GetCollapseTooltip()
    {
        if (CoreJsModule is null)
        {
            return CollapseTooltip;
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
            return CollapseTooltip;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getCollapseTooltip",
            CancellationTokenSource.Token);
        if (result is not null)
        {
#pragma warning disable BL0005
            CollapseTooltip = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(CollapseTooltip)] = CollapseTooltip;
        }
         
        return CollapseTooltip;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ExpandIcon property.
    /// </summary>
    public async Task<string?> GetExpandIcon()
    {
        if (CoreJsModule is null)
        {
            return ExpandIcon;
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
            return ExpandIcon;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getExpandIcon",
            CancellationTokenSource.Token);
        if (result is not null)
        {
#pragma warning disable BL0005
            ExpandIcon = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(ExpandIcon)] = ExpandIcon;
        }
         
        return ExpandIcon;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ExpandTooltip property.
    /// </summary>
    public async Task<string?> GetExpandTooltip()
    {
        if (CoreJsModule is null)
        {
            return ExpandTooltip;
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
            return ExpandTooltip;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getExpandTooltip",
            CancellationTokenSource.Token);
        if (result is not null)
        {
#pragma warning disable BL0005
            ExpandTooltip = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(ExpandTooltip)] = ExpandTooltip;
        }
         
        return ExpandTooltip;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Group property.
    /// </summary>
    public async Task<string?> GetGroup()
    {
        if (CoreJsModule is null)
        {
            return Group;
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
            return Group;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getGroup",
            CancellationTokenSource.Token);
        if (result is not null)
        {
#pragma warning disable BL0005
            Group = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Group)] = Group;
        }
         
        return Group;
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Expanded property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetExpanded(bool? value)
    {
#pragma warning disable BL0005
        Expanded = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Expanded)] = value;
        
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
            JsComponentReference, "expanded", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the CollapseIcon property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCollapseIcon(string? value)
    {
#pragma warning disable BL0005
        CollapseIcon = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(CollapseIcon)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setCollapseIcon", CancellationTokenSource.Token,
            value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the CollapseTooltip property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCollapseTooltip(string? value)
    {
#pragma warning disable BL0005
        CollapseTooltip = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(CollapseTooltip)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setCollapseTooltip", CancellationTokenSource.Token,
            value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ExpandIcon property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetExpandIcon(string? value)
    {
#pragma warning disable BL0005
        ExpandIcon = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ExpandIcon)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setExpandIcon", CancellationTokenSource.Token,
            value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ExpandTooltip property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetExpandTooltip(string? value)
    {
#pragma warning disable BL0005
        ExpandTooltip = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ExpandTooltip)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setExpandTooltip", CancellationTokenSource.Token,
            value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Group property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetGroup(string? value)
    {
#pragma warning disable BL0005
        Group = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Group)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setGroup", CancellationTokenSource.Token,
            value);
    }
    
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Widget widget:
                if (!widget.Equals(WidgetContent))
                {
                    WidgetContent = widget;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Widget _:
                WidgetContent = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}