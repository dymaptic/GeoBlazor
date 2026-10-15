namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class SwipeWidget: ProWidget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Swipe;
    
    /// <summary>
    ///     The direction the Swipe widget moves across the view. If "horizontal", the widget will move left and right and if "vertical", the widget will move up and down.
    /// </summary>
    [Parameter]
    public SwipeDirection Direction { get; set; } = SwipeDirection.Horizontal;
    
    /// <summary>
    ///     When true, sets the widget to a disabled state so the user cannot interact with it.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }
    
    /// <summary>
    ///     When true, sets the widget to a disabled state so the user cannot interact with it.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DragLabel { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Widgets.SwipeWidget.html#swipewidgetleadinglayers-property">GeoBlazor Docs</a>
    ///     A collection of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">Layer</a>s that will show on the left or top side of the Swipe widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Swipe.html#leadingLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [RequiredProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    [CodeGenerationIgnore]
    public IReadOnlyList<Layer> LeadingLayers { get; set; } = null!;
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Widgets.SwipeWidget.html#swipewidgettrailinglayers-property">GeoBlazor Docs</a>
    ///     A collection of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">Layer</a>s that will show on the right or bottom side of the Swipe widget.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Swipe.html#trailingLayers">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [RequiredProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(NonNullablePropertyCollectionConverter<Layer>))]
    [CodeGenerationIgnore]
    public IReadOnlyList<Layer> TrailingLayers { get; set; } = null!;
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the LeadingLayers property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<Layer>?> GetLeadingLayers()
    {
        if (CoreJsModule is null)
        {
            return LeadingLayers;
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
            return LeadingLayers;
        }

        IReadOnlyList<Layer>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<Layer>?>(
            "getLeadingLayers", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            LeadingLayers = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(LeadingLayers)] = LeadingLayers;
        }
        
        return LeadingLayers;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the TrailingLayers property.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<IReadOnlyList<Layer>?> GetTrailingLayers()
    {
        if (CoreJsModule is null)
        {
            return TrailingLayers;
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
            return TrailingLayers;
        }

        IReadOnlyList<Layer>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<Layer>?>(
            "getTrailingLayers", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            TrailingLayers = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(TrailingLayers)] = TrailingLayers;
        }
        
        return TrailingLayers;
    }
    
    /// <summary>
    ///    Asynchronously set the value of the LeadingLayers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetLeadingLayers(IReadOnlyList<Layer> value)
    {
        foreach (Layer item in value)
        {
            item.UpdateGeoBlazorReferences(CoreJsModule!, ProJsModule, View, this, Layer);
        }
        
#pragma warning disable BL0005
        LeadingLayers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(LeadingLayers)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setLeadingLayers", 
            CancellationTokenSource.Token, value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the TrailingLayers property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    [CodeGenerationIgnore]
    public async Task SetTrailingLayers(IReadOnlyList<Layer> value)
    {
        foreach (Layer item in value)
        {
            item.UpdateGeoBlazorReferences(CoreJsModule!, ProJsModule, View, this, Layer);
        }
        
#pragma warning disable BL0005
        TrailingLayers = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(TrailingLayers)] = value;
        
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
        
        await JsComponentReference.InvokeVoidAsync("setTrailingLayers", 
            CancellationTokenSource.Token, value);
    }
    
#region Add to Collection Methods

    /// <summary>
    ///     Asynchronously adds elements to the LeadingLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    [CodeGenerationIgnore]
    public async Task AddToLeadingLayers(params Layer[] values)
    {
        Layer[] join = [..LeadingLayers, ..values];
        await SetLeadingLayers(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the TrailingLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToTrailingLayers(params Layer[] values)
    {
        Layer[] join = [..TrailingLayers, ..values];
        await SetTrailingLayers(join);
    }
    
#endregion

#region Remove From Collection Methods

    
    /// <summary>
    ///     Asynchronously remove an element from the LeadingLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    [CodeGenerationIgnore]
    public async Task RemoveFromLeadingLayers(params Layer[] values)
    {
        await SetLeadingLayers(LeadingLayers.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the TrailingLayers property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    [CodeGenerationIgnore]
    public async Task RemoveFromTrailingLayers(params Layer[] values)
    {
        await SetTrailingLayers(TrailingLayers.Except(values).ToArray());
    }
    
#endregion
}